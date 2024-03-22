using MWS.Data.Entities;

namespace TripBusiness.Ibusiness
{
    public interface ILocalizationService
    {
        public List<Localization> GetStringResource(decimal languageId);
        public string Localize(string? resourceKey);
    }
}
