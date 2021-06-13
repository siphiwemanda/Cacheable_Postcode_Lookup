using System.Collections.Generic;
using System.Text.Json;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public class PostcodeLookup : IPostCodeLookup
    {
        private readonly DataProvider _dataProvider;

        public PostcodeLookup(DataProvider dataProvider) { _dataProvider = dataProvider; }

        public List<Address> Lookup(string postCode)
        {
            var data = _dataProvider.Search(postCode);
            return JsonSerializer.Deserialize<List<Address>>(data);
        }
    }
}