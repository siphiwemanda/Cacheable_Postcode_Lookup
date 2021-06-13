using System.Collections.Generic;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public interface IPostCodeLookup
    {
        List<Address> Lookup(string postCode);
    }
}