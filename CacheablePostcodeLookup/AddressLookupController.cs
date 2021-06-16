using System.Collections.Generic;
using CacheablePostcodeLookup.Cache;
using CacheablePostcodeLookup.PostCodeLookup;

namespace CacheablePostcodeLookup
{
    public class AddressLookupController
    {
        private readonly IPostCodeLookup _lookup = new PostCodeCachingDecorator(new PostcodeLookup(new DataProvider()), new SimpleCache()); //Yes! This should be injected into the constructor 
        public List<Address> LookupAddress(string postcode)
        {
            return _lookup.Lookup(postcode);
        }
        
    }
}
