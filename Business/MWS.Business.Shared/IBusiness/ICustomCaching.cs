namespace MWS.Business.Shared.IBusiness
{
    public interface ICustomCaching
    {
        T Get<T>(string key) where T : class;
        void Remove<T>(string key) where T : class;
        void Set<T>(string key, T t, double lcachingMinutes) where T : class;
        void Set<T>(string key, T t) where T : class;
    }
}
