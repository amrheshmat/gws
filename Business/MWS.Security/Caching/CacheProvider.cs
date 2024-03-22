using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;

namespace MWS.Security.Caching
{
    public interface ICacheProvider
    {
        public Task<List<USERS>> MemoryCacheUsers();
    }
    public class CacheProvider : ICacheProvider
    {
        private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _config;
        private readonly ICustomCaching _customCaching;
        private IRepository _repository;

        public CacheProvider(IConfiguration config, IMemoryCache memoryCache, ICustomCaching customCaching, IRepositoryFactory repository)
        {
            _memoryCache = memoryCache;
            _config = config;
            _customCaching = customCaching;
            _repository = repository.Create("AGGRDB");
        }
        public async Task<List<USERS>> MemoryCacheUsers()
        {
            // var cacheData = _memoryCache.Get<List<USERS>>("users");
            var cacheData1 = _customCaching.Get<List<USERS>>("USERS");
            if (cacheData1 != null)
            {
                return (cacheData1);
            }
            var expiration = double.Parse(_config.GetSection("CacheExpirationTime").Value ?? "1");
            var expirationTime = DateTimeOffset.Now.AddDays(expiration);
            cacheData1 = await _repository.Filter<USERS>(u => u.ACTIVE == "Y" && u.ISWEB_FLAG == "Y" && u.STATUS == "A").ToListAsync();
            _memoryCache.Set("USERS", cacheData1, expirationTime);
            return (cacheData1);
        }
    }
}
