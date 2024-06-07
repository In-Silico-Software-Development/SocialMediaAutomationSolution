using FluentValidation;

namespace Application.Features.Notifications.Commands.Create;

public class CreateNotificationCommandValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.User).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.IsRead).NotEmpty();
    }
}