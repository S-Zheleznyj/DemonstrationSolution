using FluentValidation;
using ProcessMe.Models.DTOs.Incoming;

namespace ProcessMe.Infrastructure.Validation
{
    public class UserRegistrationRequestDtoValidator : AbstractValidator<UserRegistrationRequestDto>
    {
        public UserRegistrationRequestDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError);

            RuleFor(x => x.Email).NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError)
                .EmailAddress()
                .WithMessage(ValidationMessages.EmailError);

            RuleFor(x => x.Password).NotEmpty().WithMessage(ValidationMessages.EmptyStringError)
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
        }
    }
}
