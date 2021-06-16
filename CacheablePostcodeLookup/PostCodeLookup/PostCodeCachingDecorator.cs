using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.Json;
using CacheablePostcodeLookup.Cache;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public class PostCodeCachingDecorator :IPostCodeLookup
    {
        private readonly IPostCodeLookup _postCodeLookup;
        private readonly SimpleCache _simpleCache;


        public PostCodeCachingDecorator(IPostCodeLookup postCodeLookup, SimpleCache simpleCache)
        {
            _postCodeLookup = postCodeLookup;
            _simpleCache = simpleCache;
        }

        public List<Address> Lookup(string postCode)
        {
            var data = _simpleCache.Get<string>(postCode);
            
            return data == null ? _postCodeLookup.Lookup(postCode) : JsonSerializer.Deserialize<List<Address>>(data);
        }
    }
}