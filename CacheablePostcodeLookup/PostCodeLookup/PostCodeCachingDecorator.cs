using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.Json;
using CacheablePostcodeLookup.Cache;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public class PostCodeCachingDecorator :IPostCodeLookup
    {
        private readonly DataProvider _dataProvider;
        private readonly SimpleCache _simpleCache;

        public PostCodeCachingDecorator(DataProvider dataProvider, SimpleCache simpleCache)
        {
            _dataProvider = dataProvider;
            _simpleCache = simpleCache;
        }

        public List<Address> Lookup(string postCode)
        {
            _simpleCache.Set(postCode, _dataProvider, 30);
            var results = _simpleCache.Get<PostCodeCachingDecorator>(postCode);

            return null;
            //return JsonSerializer.Deserialize<List<Address>>(data);




        }
    }
}