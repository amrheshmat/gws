using MWS.Data.Entities;

namespace TripBusiness.Ibusiness
{
    public interface ITripCaching
    {
        public List<Localization> getTrandlationBasedOnLanguage(decimal languageId);
        public Task<List<User>> getUsers();
    }
}
