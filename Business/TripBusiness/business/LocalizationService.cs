using MWS.Data.Entities;
using MWS.Infrustructure.Context;
using TripBusiness.Ibusiness;

namespace TripBusiness.business
{
    public class LocalizationService : ILocalizationService
    {
        private readonly AGGRDbContext _context;
        private readonly ITripCaching _tripCaching;
        private readonly ILanguageService _languageService;

        public LocalizationService(AGGRDbContext context, ITripCaching tripCaching, ILanguageService languageService)
        {
            _context = context;
            _tripCaching = tripCaching;
            _languageService = languageService;
        }

        public List<Localization> GetStringResource(decimal languageId)
        {
            return _tripCaching.getTrandlationBasedOnLanguage(languageId);
        }
        public string Localize(string? resourceKey)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageService.GetLanguageByCulture(currentCulture);
            if (language != null)
            {
                var stringResource = GetStringResource(language.languageId!.Value);
                var val = stringResource.Where(e => e.keyName == resourceKey).FirstOrDefault()?.value;
                if (stringResource == null || string.IsNullOrEmpty(val))
                {
                    return null;
                }

                return val;
            }

            return resourceKey;
        }
    }
}
