using Application.Features.AdPerformances.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.AdPerformances.Constants.AdPerformancesOperationClaims;

namespace Application.Features.AdPerformances.Queries.GetList;

public class GetListAdPerformanceQuery : IRequest<GetListResponse<GetListAdPerformanceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAdPerformances({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAdPerformances";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAdPerformanceQueryHandler : IRequestHandler<GetListAdPerformanceQuery, GetListResponse<GetListAdPerformanceListItemDto>>
    {
        private readonly IAdPerformanceRepository _adPerformanceRepository;
        private readonly IMapper _mapper;

        public GetListAdPerformanceQueryHandler(IAdPerformanceRepository adPerformanceRepository, IMapper mapper)
        {
            _adPerformanceRepository = adPerformanceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdPerformanceListItemDto>> Handle(GetListAdPerformanceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<AdPerformance> adPerformances = await _adPerformanceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdPerformanceListItemDto> response = _mapper.Map<GetListResponse<GetListAdPerformanceListItemDto>>(adPerformances);
            return response;
        }
    }
}