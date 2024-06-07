using Application.Features.Ads.Constants;
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

namespace Application.Features.Ads.Commands.Delete;

public class DeleteAdCommand : IRequest<DeletedAdResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, AdsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetAds"];

    public class DeleteAdCommandHandler : IRequestHandler<DeleteAdCommand, DeletedAdResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAdRepository _adRepository;
        private readonly AdBusinessRules _adBusinessRules;

        public DeleteAdCommandHandler(IMapper mapper, IAdRepository adRepository,
                                         AdBusinessRules adBusinessRules)
        {
            _mapper = mapper;
            _adRepository = adRepository;
            _adBusinessRules = adBusinessRules;
        }

        public async Task<DeletedAdResponse> Handle(DeleteAdCommand request, CancellationToken cancellationToken)
        {
            Ad? ad = await _adRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            await _adBusinessRules.AdShouldExistWhenSelected(ad);

            await _adRepository.DeleteAsync(ad!);

            DeletedAdResponse response = _mapper.Map<DeletedAdResponse>(ad);
            return response;
        }
    }
}