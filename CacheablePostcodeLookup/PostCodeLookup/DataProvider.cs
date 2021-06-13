using System.Threading;

namespace CacheablePostcodeLookup.PostCodeLookup
{
    public class DataProvider
    {
        public string Search(string postCode)
        {
            Thread.Sleep(10000);
            return postCode switch
            {
                "BL00LT" =>
                    "[{\"Text\": \"60 Bolton Road North\"},{ \"Text\": \"62 Bolton Road North\"},{ \"Text\": \"64 Bolton Road North\"},{ \"Text\": \"66 Bolton Road North\"},{ \"Text\": \"68 Bolton Road North\"},{ \"Text\": \"70 Bolton Road North\"},{ \"Text\": \"84 Bolton Road North\"},{ \"Text\": \"86 Bolton Road North\"},{ \"Text\": \"88 Bolton Road North\"},{ \"Text\": \"90 Bolton Road North\"}]",
                "SK136NB" =>
                    "[{\"Text\": \"1 Cotswold Close\"},{\"Text\": \"2 Cotswold Close\"},{\"Text\": \"3 Cotswold Close\"},{\"Text\": \"4 Cotswold Close\"},{\"Text\": \"5 Cotswold Close\"},{\"Text\": \"6 Cotswold Close\"},{\"Text\": \"7 Cotswold Close\"},{\"Text\": \"8 Cotswold Close\"},{\"Text\": \"9 Cotswold Close\"},{\"Text\": \"10 Cotswold Close\"},{\"Text\": \"11 Cotswold Close\"},{\"Text\": \"12 Cotswold Close\"},{\"Text\": \"14 Cotswold Close\"},{\"Text\": \"16 Cotswold Close\"},{\"Text\": \"18 Cotswold Close\"},{\"Text\": \"20 Cotswold Close\"},{\"Text\": \"22 Cotswold Close\"},{\"Text\": \"24 Cotswold Close\"}]",
                _ => "[]"
            };
        }
    }
}