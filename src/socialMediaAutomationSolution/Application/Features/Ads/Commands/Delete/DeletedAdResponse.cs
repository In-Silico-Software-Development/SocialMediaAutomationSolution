using NArchitecture.Core.Application.Responses;

namespace Application.Features.Ads.Commands.Delete;

public class DeletedAdResponse : IResponse
{
    public Guid Id { get; set; }
}