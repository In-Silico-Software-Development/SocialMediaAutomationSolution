using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Update;

public class UpdatedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Platform { get; set; }
    public string AccessToken { get; set; }
    public string AccountName { get; set; }
}