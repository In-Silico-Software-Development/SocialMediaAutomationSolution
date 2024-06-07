using NArchitecture.Core.Application.Dtos;

namespace Application.Features.SocialMediaAccounts.Queries.GetList;

public class GetListSocialMediaAccountListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Platform { get; set; }
    public string AccessToken { get; set; }
    public string AccountName { get; set; }
}