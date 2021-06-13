using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.Json;
using CacheablePostcodeLookup.Cache;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public class PostCodeCachingDecorator :IPostCodeLookup
    {
        private readonly DataProvider _dataProvider;
        private  SimpleCache _simpleCache;


        public PostCodeCachingDecorator(DataProvider dataProvider, SimpleCache simpleCache)
        {
            _dataProvider = dataProvider;
            _simpleCache = simpleCache;
        }

        public List<Address> Lookup(string postCode)
        {
            var data = _simpleCache.Get<string>(postCode);

            if (data != null)
            {
                return JsonSerializer.Deserialize<List<Address>>(data);
            }
            else
            {
                _simpleCache.Set(postCode, _dataProvider.Search(postCode), 30);
                data = _simpleCache.Get<string>(postCode);
                return JsonSerializer.Deserialize<List<Address>>(data);
            }
      
        }
    }
}