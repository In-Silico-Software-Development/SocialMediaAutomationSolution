using Application.Features.AdPerformances.Constants;
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

namespace Application.Features.AdPerformances.Commands.Delete;

public class DeleteAdPerformanceCommand : IRequest<DeletedAdPerformanceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AdPerformancesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAdPerformances"];

    public class DeleteAdPerformanceCommandHandler : IRequestHandler<DeleteAdPerformanceCommand, DeletedAdPerformanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdPerformanceRepository _adPerformanceRepository;
        private readonly AdPerformanceBusinessRules _adPerformanceBusinessRules;

        public DeleteAdPerformanceCommandHandler(IMapper mapper, IAdPerformanceRepository adPerformanceRepository,
                                         AdPerformanceBusinessRules adPerformanceBusinessRules)
        {
            _mapper = mapper;
            _adPerformanceRepository = adPerformanceRepository;
            _adPerformanceBusinessRules = adPerformanceBusinessRules;
        }

        public async Task<DeletedAdPerformanceResponse> Handle(DeleteAdPerformanceCommand request, CancellationToken cancellationToken)
        {
            AdPerformance? adPerformance = await _adPerformanceRepository.GetAsync(predicate: ap => ap.Id == request.Id, cancellationToken: cancellationToken);
            await _adPerformanceBusinessRules.AdPerformanceShouldExistWhenSelected(adPerformance);

            await _adPerformanceRepository.DeleteAsync(adPerformance!);

            DeletedAdPerformanceResponse response = _mapper.Map<DeletedAdPerformanceResponse>(adPerformance);
            return response;
        }
    }
}