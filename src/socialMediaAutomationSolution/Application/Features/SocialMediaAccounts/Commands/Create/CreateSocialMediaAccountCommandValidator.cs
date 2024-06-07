using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreateSocialMediaAccountCommandValidator : AbstractValidator<CreateSocialMediaAccountCommand>
{
    public CreateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.Platform).NotEmpty();
        RuleFor(c => c.AccessToken).NotEmpty();
        RuleFor(c => c.AccountName).NotEmpty();
    }
}