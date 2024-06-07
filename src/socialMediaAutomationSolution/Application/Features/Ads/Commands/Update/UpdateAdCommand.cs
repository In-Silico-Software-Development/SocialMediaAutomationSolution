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

namespace Application.Features.Ads.Commands.Update;

public class UpdateAdCommand : IRequest<UpdatedAdResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Platform { get; set; }
    public required string Content { get; set; }
    public required DateTime ScheduledTime { get; set; }
    public required bool IsPublished { get; set; }
    public required Guid CampaignGuid { get; set; }
    public required Campaign Campaign { get; set; }

    public string[] Roles => [Admin, Write, AdsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAds"];

    public class UpdateAdCommandHandler : IRequestHandler<UpdateAdCommand, UpdatedAdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _adRepository;
        private readonly AdBusinessRules _adBusinessRules;

        public UpdateAdCommandHandler(IMapper mapper, IAdRepository adRepository,
                                         AdBusinessRules adBusinessRules)
        {
            _mapper = mapper;
            _adRepository = adRepository;
            _adBusinessRules = adBusinessRules;
        }

        public async Task<UpdatedAdResponse> Handle(UpdateAdCommand request, CancellationToken cancellationToken)
        {
            Ad? ad = await _adRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _adBusinessRules.AdShouldExistWhenSelected(ad);
            ad = _mapper.Map(request, ad);

            await _adRepository.UpdateAsync(ad!);

            UpdatedAdResponse response = _mapper.Map<UpdatedAdResponse>(ad);
            return response;
        }
    }
}