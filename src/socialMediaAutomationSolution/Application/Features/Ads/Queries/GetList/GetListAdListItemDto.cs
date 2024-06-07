using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Ads.Queries.GetList;

public class GetListAdListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Platform { get; set; }
    public string Content { get; set; }
    public DateTime ScheduledTime { get; set; }
    public bool IsPublished { get; set; }
    public Guid CampaignGuid { get; set; }
    public Campaign Campaign { get; set; }
}