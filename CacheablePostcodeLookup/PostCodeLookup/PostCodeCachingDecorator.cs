using System.Collections.Generic;
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
            var data = _simpleCache.Get<List<Address>>(postCode);
            return data ?? GetPostCodes(postCode);
        }

        private List<Address> GetPostCodes(string postCode)
        {
            var getPostCodes = _postCodeLookup.Lookup(postCode);
            _simpleCache.Set(postCode, getPostCodes, 30);
            return getPostCodes;
        }
    }
}