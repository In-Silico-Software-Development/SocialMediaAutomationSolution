using NArchitecture.Core.Application.Responses;

namespace Application.Features.SocialMediaAccounts.Commands.Create;

public class CreatedSocialMediaAccountResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Platform { get; set; }
    public string AccessToken { get; set; }
    public string AccountName { get; set; }
}