using CacheablePostcodeLookup.Cache;
using CacheablePostcodeLookup.PostCodeLookup;
using NUnit.Framework;

namespace CacheablePostcodeLookupTests
{
    [TestFixture]
    public class CachedPostCodeLookupTests
    {
        [Test]
        public void PassingValidePostcodeRetunsObject()
        {
            var caching = new PostCodeCachingDecorator(new DataProvider(), new SimpleCache());
            var results = caching.Lookup("BL00LT");
            Assert.That(results, Is.Not.Null);;
   
        }
    }
}