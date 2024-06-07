using Application.Features.AdPerformances.Constants;
using Application.Features.AdPerformances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.AdPerformances.Constants.AdPerformancesOperationClaims;

namespace Application.Features.AdPerformances.Queries.GetById;

public class GetByIdAdPerformanceQuery : IRequest<GetByIdAdPerformanceResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAdPerformanceQueryHandler : IRequestHandler<GetByIdAdPerformanceQuery, GetByIdAdPerformanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdPerformanceRepository _adPerformanceRepository;
        private readonly AdPerformanceBusinessRules _adPerformanceBusinessRules;

        public GetByIdAdPerformanceQueryHandler(IMapper mapper, IAdPerformanceRepository adPerformanceRepository, AdPerformanceBusinessRules adPerformanceBusinessRules)
        {
            _mapper = mapper;
            _adPerformanceRepository = adPerformanceRepository;
            _adPerformanceBusinessRules = adPerformanceBusinessRules;
        }

        public async Task<GetByIdAdPerformanceResponse> Handle(GetByIdAdPerformanceQuery request, CancellationToken cancellationToken)
        {
            AdPerformance? adPerformance = await _adPerformanceRepository.GetAsync(predicate: ap => ap.Id == request.Id, cancellationToken: cancellationToken);
            await _adPerformanceBusinessRules.AdPerformanceShouldExistWhenSelected(adPerformance);

            GetByIdAdPerformanceResponse response = _mapper.Map<GetByIdAdPerformanceResponse>(adPerformance);
            return response;
        }
    }
}