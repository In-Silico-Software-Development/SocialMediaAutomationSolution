using Application.Features.Ads.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Ads.Constants.AdsOperationClaims;

namespace Application.Features.Ads.Queries.GetList;

public class GetListAdQuery : IRequest<GetListResponse<GetListAdListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListAds({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetAds";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListAdQueryHandler : IRequestHandler<GetListAdQuery, GetListResponse<GetListAdListItemDto>>
    {
        private readonly IAdRepository _adRepository;
        private readonly IMapper _mapper;

        public GetListAdQueryHandler(IAdRepository adRepository, IMapper mapper)
        {
            _adRepository = adRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListAdListItemDto>> Handle(GetListAdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Ad> ads = await _adRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListAdListItemDto> response = _mapper.Map<GetListResponse<GetListAdListItemDto>>(ads);
            return response;
        }
    }
}