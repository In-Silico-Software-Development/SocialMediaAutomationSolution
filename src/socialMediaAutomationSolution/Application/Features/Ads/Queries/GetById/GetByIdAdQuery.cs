using Application.Features.Ads.Constants;
using Application.Features.Ads.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Ads.Constants.AdsOperationClaims;

namespace Application.Features.Ads.Queries.GetById;

public class GetByIdAdQuery : IRequest<GetByIdAdResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdAdQueryHandler : IRequestHandler<GetByIdAdQuery, GetByIdAdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _adRepository;
        private readonly AdBusinessRules _adBusinessRules;

        public GetByIdAdQueryHandler(IMapper mapper, IAdRepository adRepository, AdBusinessRules adBusinessRules)
        {
            _mapper = mapper;
            _adRepository = adRepository;
            _adBusinessRules = adBusinessRules;
        }

        public async Task<GetByIdAdResponse> Handle(GetByIdAdQuery request, CancellationToken cancellationToken)
        {
            Ad? ad = await _adRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _adBusinessRules.AdShouldExistWhenSelected(ad);

            GetByIdAdResponse response = _mapper.Map<GetByIdAdResponse>(ad);
            return response;
        }
    }
}