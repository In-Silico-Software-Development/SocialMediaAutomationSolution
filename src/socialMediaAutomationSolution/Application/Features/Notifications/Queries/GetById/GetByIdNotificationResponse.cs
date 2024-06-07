using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notifications.Queries.GetById;

public class GetByIdNotificationResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
}