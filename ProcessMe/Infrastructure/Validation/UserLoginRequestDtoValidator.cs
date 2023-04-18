using FluentValidation;
using ProcessMe.Models.DTOs.Incoming;

namespace ProcessMe.Infrastructure.Validation
{
    public class UserLoginRequestDtoValidator : AbstractValidator<UserLoginRequestDto>
    {
        public UserLoginRequestDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError)
                .EmailAddress()
                .WithMessage(ValidationMessages.EmailError);

            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
