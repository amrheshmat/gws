using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace TripBusiness.business
{
    public class TripCaching : ITripCaching
    {
        #region fields
        private readonly IConfiguration _config;
        private readonly IRepository _repo;
        private List<Localization> cachedPartnerPlanTraffic = null!;
        private ICustomCaching _customCache;
        #endregion
        #region constrcutor(s)
        public TripCaching(IConfiguration config, IRepositoryFactory repo, ICustomCaching customCache)
        {
            _config = config;
            _repo = repo.Create("AGGRDB");
            _customCache = customCache;
        }
        #endregion
        #region custom methods
        public List<Localization> getTrandlationBasedOnLanguage(decimal languageId)
        {
            var cachedLookup = _customCache.Get<List<Localization>>("LanguageId_" + languageId);
            if (cachedLookup != null)
            {
                return cachedLookup;
            }

            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedLookup = _repo.Filter<Localization>(e => e.languageId == languageId).ToList();
            _customCache.Set("LanguageId_" + languageId, cachedLookup, expiration);
            return cachedLookup;
        }
        public async Task<List<User>> getUsers()
        {
            var cachedLookup = _customCache.Get<List<User>>("users");
            if (cachedLookup != null)
            {
                return cachedLookup;
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            cachedLookup = await _repo.GetAll<User>().ToListAsync();
            _customCache.Set("usrs", cachedLookup, expiration);
            return cachedLookup;
        }
        public void UpdateTranlsation(decimal languageId)
        {
            _customCache.Remove<List<Localization>>("LanguageId_" + languageId);
            var translations = getTrandlationBasedOnLanguage(languageId);
        }
        #endregion
    }
}
