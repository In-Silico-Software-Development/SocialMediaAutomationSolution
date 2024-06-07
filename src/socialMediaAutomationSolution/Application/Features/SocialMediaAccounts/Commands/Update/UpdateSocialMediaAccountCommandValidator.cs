using FluentValidation;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdateSocialMediaAccountCommandValidator : AbstractValidator<UpdateSocialMediaAccountCommand>
{
    public UpdateSocialMediaAccountCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.Platform).NotEmpty();
        RuleFor(c => c.AccessToken).NotEmpty();
        RuleFor(c => c.AccountName).NotEmpty();
    }
}