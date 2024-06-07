using FluentValidation;

namespace Application.Features.AdPerformances.Commands.Delete;

public class DeleteAdPerformanceCommandValidator : AbstractValidator<DeleteAdPerformanceCommand>
{
    public DeleteAdPerformanceCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}