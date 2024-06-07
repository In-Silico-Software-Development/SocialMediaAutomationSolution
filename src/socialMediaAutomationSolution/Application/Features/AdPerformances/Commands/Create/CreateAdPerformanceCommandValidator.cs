using FluentValidation;

namespace Application.Features.AdPerformances.Commands.Create;

public class CreateAdPerformanceCommandValidator : AbstractValidator<CreateAdPerformanceCommand>
{
    public CreateAdPerformanceCommandValidator()
    {
        RuleFor(c => c.AdGuid).NotEmpty();
        RuleFor(c => c.Ad).NotEmpty();
        RuleFor(c => c.Impressions).NotEmpty();
        RuleFor(c => c.Clicks).NotEmpty();
        RuleFor(c => c.Conversions).NotEmpty();
        RuleFor(c => c.Cost).NotEmpty();
        RuleFor(c => c.Date).NotEmpty();
    }
}