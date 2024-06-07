using FluentValidation;

namespace Application.Features.AdPerformances.Commands.Update;

public class UpdateAdPerformanceCommandValidator : AbstractValidator<UpdateAdPerformanceCommand>
{
    public UpdateAdPerformanceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.AdGuid).NotEmpty();
        RuleFor(c => c.Ad).NotEmpty();
        RuleFor(c => c.Impressions).NotEmpty();
        RuleFor(c => c.Clicks).NotEmpty();
        RuleFor(c => c.Conversions).NotEmpty();
        RuleFor(c => c.Cost).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
    }
}