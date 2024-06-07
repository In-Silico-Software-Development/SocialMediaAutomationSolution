using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Commands.Update;

public class UpdatedNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
}