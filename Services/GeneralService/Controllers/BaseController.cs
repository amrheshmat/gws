using Microsoft.AspNetCore.Mvc;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;

        public BaseController(ILanguageService languageService, ILocalizationService localizationService)
        {
            _languageService = languageService;
            _localizationService = localizationService;
        }

        public async Task<string> Localize(string? resourceKey)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageService.GetLanguageByCulture(currentCulture);
            if (language != null)
            {
                var stringResource = _localizationService.GetStringResource(language.languageId!.Value);
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
