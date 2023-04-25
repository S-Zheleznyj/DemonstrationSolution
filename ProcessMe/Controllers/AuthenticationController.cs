using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcessMe.Data;
using ProcessMe.Domain.Managers.Interfaces;
using ProcessMe.Infrastructure.Configurations;
using ProcessMe.Models.DTOs.Incoming;
using ProcessMe.Models.DTOs.Outgoing;
using ProcessMe.Models.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProcessMe.Controllers
{
    public class AuthenticationController : ProcessMeBaseController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IJwtTokenManager _tokenManager;

        public AuthenticationController(UserManager<IdentityUser> userManager, IConfiguration configuration, 
            IJwtTokenManager tokenManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _tokenManager = tokenManager;
        }

        /// <summary> Регистрирует пользователя системы</summary>
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            var user_exist = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user_exist != null)
            {
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new List<string>()
                        {
                            "Email already exist"
                        }
                });
            }

            var new_user = new IdentityUser()
            {
                Email = requestDto.Email,
                UserName = requestDto.Email,
                //EmailConfirmed = false    Учетку на mailgun заблокировали. Пока сразу будет верифицированный email
                EmailConfirmed = true,
            };
            var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);

            if (is_created.Succeeded)
            {
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(new_user);

                //var email_body = "Please confirm your email address <a href=\"#URL#\"Click here>";

                //var callback_url = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Authentication", new { userId = new_user.Id, code = code });

                //var body = email_body.Replace("#URL", callback_url);

                //var result = SendEmail(body, new_user.Email);
                //if (result)
                //    return Ok("Please, verify your email");

                //return Ok("Please, request an email verification link");
                //var token = await GenerateJwtToken(new_user);
                return Ok(is_created);
            }

            return BadRequest(new OutgoingResult()
            {
                Errors = new List<string>()
                    {
                        "Server error"
                    },
                IsSuccess = false
            });
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new()
                    {
                        "Invalid email confirmation url"
                    }
                });

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new()
                    {
                        "Invalid email parameters"
                    }
                });

            //code = Encoding.UTF8.GetString(Convert.FromBase64String(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            var status = result.Succeeded ? "Thank you for confirming your email" : "Your email is not confirmed, please try again later";
            return Ok(status);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
        {
            var existing_user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (existing_user == null)
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new()
                    {
                        "Invalid payload"
                    }
                });

            if (!existing_user.EmailConfirmed)
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new()
                    {
                        "Email needs to be confirmed"
                    }
                });

            var isCorrect = await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);

            if (!isCorrect)
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new()
                    {
                        "Invalid credentials"
                    }
                });
            var roles = await _userManager.GetRolesAsync(existing_user);
            var jwtToken = await _tokenManager.GenerateJwtTokenAsync(existing_user, roles);

            return Ok(jwtToken);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequestDto tokenRequest)
        {
            var verifyTokenResult = _tokenManager.VerifyToken(tokenRequest.Token, out string jti);
            if (!verifyTokenResult.IsSuccess)
                return BadRequest(verifyTokenResult);

            var storedRefreshToken = await _tokenManager.GetRefreshTokenByValueAsync(tokenRequest.RefreshToken);
            if (storedRefreshToken == null)
                return BadRequest(new OutgoingResult()
                {
                    IsSuccess = false,
                    Errors = new() { "Token is not exist" }
                });

            var verifyRefreshTokenResult = _tokenManager.VerifyRefreshToken(storedRefreshToken, jti, out string userId);
            if (!verifyRefreshTokenResult.IsSuccess)
                return BadRequest(verifyRefreshTokenResult);

            storedRefreshToken.SetIsUsed();
            await _tokenManager.UpdateRefreshTokenAsync(storedRefreshToken);


            var dbUser = await _userManager.FindByIdAsync(userId);

            var roles = await _userManager.GetRolesAsync(dbUser);
            var result = await _tokenManager.GenerateJwtTokenAsync(dbUser, roles);
            return Ok(result);
        }

        private bool SendEmail(string body, string email)
        {
            RestClientOptions options = new();
            options.Authenticator = new HttpBasicAuthenticator("api", "key-a64900"+_configuration.GetSection("EmailConfig:API_KEY").Value);
            options.BaseUrl = new("https://api.mailgun.net/v3");
            var client = new RestClient(options);

            var request = new RestRequest("", Method.Post);
            request.AddParameter("domain", "sandbox288b29f02f7e41ecbbacc7aefc6417a8.mailgun.org");
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "My own sandbox Mailgun <postmaster@sandbox288b29f02f7e41ecbbacc7aefc6417a8.mailgun.org>");
            request.AddParameter("to", email);
            request.AddParameter("subject", "Email verification");
            request.AddParameter("text", body);
            request.Method = Method.Post;

            var response = client.Execute(request);

            return response.IsSuccessful;
        }
    }
}
