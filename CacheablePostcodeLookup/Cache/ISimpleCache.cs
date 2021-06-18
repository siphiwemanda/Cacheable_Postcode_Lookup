namespace CacheablePostcodeLookup.Cache
{
    public interface ISimpleCache
    {
        void Set(string name, object data, int cacheTimeInMinutes);
        T Get<T>(string name) where T:class;
    }
}