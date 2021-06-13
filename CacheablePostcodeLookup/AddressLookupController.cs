using System.Collections.Generic;
using CacheablePostcodeLookup.PostCodeLookup;

namespace CacheablePostcodeLookup
{
    public class AddressLookupController
    {
        private readonly IPostCodeLookup _lookup = new PostcodeLookup(new DataProvider()); //Yes! This should be injected into the constructor 
        public List<Address> LookupAddress(string postcode)
        {
            return _lookup.Lookup(postcode);
        }
    }
}
