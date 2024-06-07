using Application.Features.Ads.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Ads.Rules;

public class AdBusinessRules : BaseBusinessRules
{
    private readonly IAdRepository _adRepository;
    private readonly ILocalizationService _localizationService;

    public AdBusinessRules(IAdRepository adRepository, ILocalizationService localizationService)
    {
        _adRepository = adRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdShouldExistWhenSelected(Ad? ad)
    {
        if (ad == null)
            await throwBusinessException(AdsBusinessMessages.AdNotExists);
    }

    public async Task AdIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Ad? ad = await _adRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdShouldExistWhenSelected(ad);
    }
}