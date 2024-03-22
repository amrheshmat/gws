using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MWS.Business.Shared.IBusiness;
using MWS.Infrustructure.Repositories;

namespace MWS.Business.Shared.Business
{
    public class CustomCaching : ICustomCaching
    {
        #region fields
        private readonly IConfiguration _config;
        private readonly IMemoryCache _memoryCache;
        private readonly IRepository _repo;
        #endregion
        #region constructor
        public CustomCaching(IMemoryCache memoryCache, IConfiguration config, IRepositoryFactory repo)
        {
            _memoryCache = memoryCache;
            _config = config;
            _repo = repo.Create("AGGRDB");
        }
        #endregion
        #region public method (get and set)
        public T Get<T>(string key) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new RuntimeBinderException("Messages.RuntimeStorageNullKeyException");
            }
            if (this._memoryCache == null)
            {
                throw new RuntimeBinderException("Messages.RuntimeStorageNoContextException");
            }
            return (this._memoryCache.Get(key) as T);
        }
        public void Set<T>(string key, T t, double lcachingMinutes) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new RuntimeBinderException("Messages.RuntimeStorageNullKeyException");
            }
            if (this._memoryCache == null)
            {
                throw new RuntimeBinderException("Messages.RuntimeStorageNoContextException");
            }
            _memoryCache.Set(key, t, TimeSpan.FromMinutes(lcachingMinutes));
        }
        public void Set<T>(string key, T t) where T : class
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new RuntimeBinderException("Messages.RuntimeStorageNullKeyException");
            }

            if (this._memoryCache == null)
            {
                throw new RuntimeBinderException("Messages.RuntimeStorageNoContextException");
            }
            string lcachingMinutes = _config.GetSection("CachingTime").Value;
            this._memoryCache.Set(key, t, DateTime.UtcNow.AddDays(string.IsNullOrEmpty(lcachingMinutes) ? 1.0 : double.Parse(lcachingMinutes)));
        }
        #endregion
    }
}
