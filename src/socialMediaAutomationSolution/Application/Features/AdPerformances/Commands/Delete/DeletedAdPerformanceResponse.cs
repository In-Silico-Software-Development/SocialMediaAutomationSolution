using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdPerformances.Commands.Delete;

public class DeletedAdPerformanceResponse : IResponse
{
    public Guid Id { get; set; }
}