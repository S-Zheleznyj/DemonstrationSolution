using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProcessMe.Infrastructure.Configurations;
using ProcessMe.Models.DTOs.Incoming;
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
        private readonly JwtConfig _jwtConfig;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, IOptions<JwtConfig> jwtConfig, IConfiguration configuration)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto requestDto)
        {
            var user_exist = await _userManager.FindByEmailAsync(requestDto.Email);
            if (user_exist != null)
            {
                return BadRequest(new AuthResult()
                {
                    Result = false,
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
                EmailConfirmed = false
            };

            var is_created = await _userManager.CreateAsync(new_user, requestDto.Password);

            if (is_created.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(new_user);

                var email_body = "Please confirm your email address <a href=\"#URL#\"Click here>";

                var callback_url = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Authentication", new { userId = new_user.Id, code = code });

                var body = email_body.Replace("#URL", callback_url);

                var result = SendEmail(body, new_user.Email);
                if (result)
                    return Ok("Please, verify your email");

                return Ok("Please, request an email verification link");
                //var token = GenerateJwtToken(new_user);

                //return Ok(new AuthResult()
                //{
                //    Result = true,
                //    Token = token
                //});
            }

            return BadRequest(new AuthResult()
            {
                Errors = new List<string>()
                    {
                        "Server error"
                    },
                Result = false
            });
        }

        [HttpGet]
        [Route("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new()
                    {
                        "Invalid email confirmation url"
                    }
                });

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return BadRequest(new AuthResult()
                {
                    Result = false,
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
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new()
                    {
                        "Invalid payload"
                    }
                });

            if (!existing_user.EmailConfirmed)
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new()
                    {
                        "Email needs to be confirmed"
                    }
                });

            var isCorrect = await _userManager.CheckPasswordAsync(existing_user, loginRequest.Password);

            if (!isCorrect)
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new()
                    {
                        "Invalid credentials"
                    }
                });

            var jwtToken = GenerateJwtToken(existing_user);

            return Ok(new AuthResult()
            {
                Result = true,
                Token = jwtToken
            });
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                }),

                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        private bool SendEmail(string body, string email)
        {
            RestClientOptions options = new();
            options.Authenticator = new HttpBasicAuthenticator("api", _configuration.GetSection("EmailConfig:API_KEY").Value);
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
