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

namespace Application.Features.AdPerformances.Commands.Create;

public class CreateAdPerformanceCommand : IRequest<CreatedAdPerformanceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required Guid AdGuid { get; set; }
    public required Ad Ad { get; set; }
    public required int Impressions { get; set; }
    public required int Clicks { get; set; }
    public required int Conversions { get; set; }
    public required decimal Cost { get; set; }
    public required DateTime Date { get; set; }

    public string[] Roles => [Admin, Write, AdPerformancesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdPerformances"];

    public class CreateAdPerformanceCommandHandler : IRequestHandler<CreateAdPerformanceCommand, CreatedAdPerformanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdPerformanceRepository _adPerformanceRepository;
        private readonly AdPerformanceBusinessRules _adPerformanceBusinessRules;

        public CreateAdPerformanceCommandHandler(IMapper mapper, IAdPerformanceRepository adPerformanceRepository,
                                         AdPerformanceBusinessRules adPerformanceBusinessRules)
        {
            _mapper = mapper;
            _adPerformanceRepository = adPerformanceRepository;
            _adPerformanceBusinessRules = adPerformanceBusinessRules;
        }

        public async Task<CreatedAdPerformanceResponse> Handle(CreateAdPerformanceCommand request, CancellationToken cancellationToken)
        {
            AdPerformance adPerformance = _mapper.Map<AdPerformance>(request);

            await _adPerformanceRepository.AddAsync(adPerformance);

            CreatedAdPerformanceResponse response = _mapper.Map<CreatedAdPerformanceResponse>(adPerformance);
            return response;
        }
    }
}