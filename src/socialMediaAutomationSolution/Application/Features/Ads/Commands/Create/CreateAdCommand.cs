using Application.Features.Ads.Constants;
using Application.Features.Ads.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Ads.Constants.AdsOperationClaims;

namespace Application.Features.Ads.Commands.Create;

public class CreateAdCommand : IRequest<CreatedAdResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Platform { get; set; }
    public required string Content { get; set; }
    public required DateTime ScheduledTime { get; set; }
    public required bool IsPublished { get; set; }
    public required Guid CampaignGuid { get; set; }
    public required Campaign Campaign { get; set; }

    public string[] Roles => [Admin, Write, AdsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAds"];

    public class CreateAdCommandHandler : IRequestHandler<CreateAdCommand, CreatedAdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _adRepository;
        private readonly AdBusinessRules _adBusinessRules;

        public CreateAdCommandHandler(IMapper mapper, IAdRepository adRepository,
                                         AdBusinessRules adBusinessRules)
        {
            _mapper = mapper;
            _adRepository = adRepository;
            _adBusinessRules = adBusinessRules;
        }

        public async Task<CreatedAdResponse> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            Ad ad = _mapper.Map<Ad>(request);

            await _adRepository.AddAsync(ad);

            CreatedAdResponse response = _mapper.Map<CreatedAdResponse>(ad);
            return response;
        }
    }
}