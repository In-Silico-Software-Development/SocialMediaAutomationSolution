using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdPerformances.Commands.Create;

public class CreatedAdPerformanceResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid AdGuid { get; set; }
    public Ad Ad { get; set; }
    public int Impressions { get; set; }
    public int Clicks { get; set; }
    public int Conversions { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
}