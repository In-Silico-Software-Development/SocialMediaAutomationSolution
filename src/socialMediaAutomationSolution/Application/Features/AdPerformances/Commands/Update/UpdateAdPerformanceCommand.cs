using Application.Features.AdPerformances.Constants;
using Application.Features.AdPerformances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.AdPerformances.Constants.AdPerformancesOperationClaims;

namespace Application.Features.AdPerformances.Commands.Update;

public class UpdateAdPerformanceCommand : IRequest<UpdatedAdPerformanceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid AdGuid { get; set; }
    public required Ad Ad { get; set; }
    public required int Impressions { get; set; }
    public required int Clicks { get; set; }
    public required int Conversions { get; set; }
    public required decimal Cost { get; set; }
    public required DateTime Date { get; set; }

    public string[] Roles => [Admin, Write, AdPerformancesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdPerformances"];

    public class UpdateAdPerformanceCommandHandler : IRequestHandler<UpdateAdPerformanceCommand, UpdatedAdPerformanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdPerformanceRepository _adPerformanceRepository;
        private readonly AdPerformanceBusinessRules _adPerformanceBusinessRules;

        public UpdateAdPerformanceCommandHandler(IMapper mapper, IAdPerformanceRepository adPerformanceRepository,
                                         AdPerformanceBusinessRules adPerformanceBusinessRules)
        {
            _mapper = mapper;
            _adPerformanceRepository = adPerformanceRepository;
            _adPerformanceBusinessRules = adPerformanceBusinessRules;
        }

        public async Task<UpdatedAdPerformanceResponse> Handle(UpdateAdPerformanceCommand request, CancellationToken cancellationToken)
        {
            AdPerformance? adPerformance = await _adPerformanceRepository.GetAsync(predicate: ap => ap.Id == request.Id, cancellationToken: cancellationToken);
            await _adPerformanceBusinessRules.AdPerformanceShouldExistWhenSelected(adPerformance);
            adPerformance = _mapper.Map(request, adPerformance);

            await _adPerformanceRepository.UpdateAsync(adPerformance!);

            UpdatedAdPerformanceResponse response = _mapper.Map<UpdatedAdPerformanceResponse>(adPerformance);
            return response;
        }
    }
}