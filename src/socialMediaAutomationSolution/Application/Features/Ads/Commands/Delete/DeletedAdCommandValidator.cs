using FluentValidation;

namespace Application.Features.Ads.Commands.Delete;

public class DeleteAdCommandValidator : AbstractValidator<DeleteAdCommand>
{
    public DeleteAdCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}