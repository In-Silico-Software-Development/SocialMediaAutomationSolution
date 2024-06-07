using FluentValidation;

namespace Application.Features.Ads.Commands.Update;

public class UpdateAdCommandValidator : AbstractValidator<UpdateAdCommand>
{
    public UpdateAdCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Platform).NotEmpty();
        RuleFor(c => c.Content).NotEmpty();
        RuleFor(c => c.ScheduledTime).NotEmpty();
        RuleFor(c => c.IsPublished).NotEmpty();
        RuleFor(c => c.CampaignGuid).NotEmpty();
        RuleFor(c => c.Campaign).NotEmpty();
    }
}