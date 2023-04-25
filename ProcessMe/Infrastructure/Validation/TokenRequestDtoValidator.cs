using FluentValidation;
using ProcessMe.Models.DTOs.Incoming;

namespace ProcessMe.Infrastructure.Validation
{
    public class TokenRequestDtoValidator : AbstractValidator<TokenRequestDto>
    {
        public TokenRequestDtoValidator()
        {
            RuleFor(x => x.Token).NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError);

            RuleFor(x => x.RefreshToken).NotEmpty()
                .WithMessage(ValidationMessages.EmptyStringError);
        }
    }
}
