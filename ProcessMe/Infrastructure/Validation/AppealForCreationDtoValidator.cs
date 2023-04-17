using FluentValidation;
using ProcessMe.Models.DTOs.Incoming;

namespace ProcessMe.Infrastructure.Validation
{
    public class AppealForCreationDtoValidator : AbstractValidator<AppealForCreationDto>
    {
        public AppealForCreationDtoValidator()
        {
            RuleFor(x => x.ClientEmail)
                .EmailAddress()
                .WithMessage(ValidationMessages.EmailError);

            RuleFor(x => x.ClientEmail)
                .NotNull().When(x => string.IsNullOrEmpty(x.ClientPhone))
                .WithMessage(ValidationMessages.EmailOrPhoneError);

            RuleFor(x => x.ClientPhone)
                .NotNull().When(x => string.IsNullOrEmpty(x.ClientEmail))
                .WithMessage(ValidationMessages.EmailOrPhoneError);

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError);

            RuleFor(x => x.ClientName)
                .NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError);
        }
    }
}
