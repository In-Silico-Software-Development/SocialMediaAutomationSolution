using Application.Features.AdPerformances.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.AdPerformances.Rules;

public class AdPerformanceBusinessRules : BaseBusinessRules
{
    private readonly IAdPerformanceRepository _adPerformanceRepository;
    private readonly ILocalizationService _localizationService;

    public AdPerformanceBusinessRules(IAdPerformanceRepository adPerformanceRepository, ILocalizationService localizationService)
    {
        _adPerformanceRepository = adPerformanceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, AdPerformancesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task AdPerformanceShouldExistWhenSelected(AdPerformance? adPerformance)
    {
        if (adPerformance == null)
            await throwBusinessException(AdPerformancesBusinessMessages.AdPerformanceNotExists);
    }

    public async Task AdPerformanceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        AdPerformance? adPerformance = await _adPerformanceRepository.GetAsync(
            predicate: ap => ap.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await AdPerformanceShouldExistWhenSelected(adPerformance);
    }
}