using System.Collections.Generic;
using CacheablePostcodeLookup.Cache;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public class PostCodeCachingDecorator : IPostCodeLookup
    {
        private readonly IPostCodeLookup _postCodeLookup;
        private readonly ISimpleCache _simpleCache;


        public PostCodeCachingDecorator(IPostCodeLookup postCodeLookup, ISimpleCache simpleCache)
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
            var addresses = _postCodeLookup.Lookup(postCode);
            _simpleCache.Set(postCode, addresses, 30);
            return addresses;
        }
    }
}