using CacheablePostcodeLookup;
using CacheablePostcodeLookup.Cache;
using CacheablePostcodeLookup.PostCodeLookup;
using NUnit.Framework;

namespace CacheablePostcodeLookupTests
{
    [TestFixture]
    public class CachedPostCodeLookupTests
    {
        [Test]
        public void ReturnIsNotNull()
        {
            var caching = new PostCodeCachingDecorator(new PostcodeLookup(new DataProvider()), new SimpleCache());
            var results = caching.Lookup("BL00LT");
            Assert.That(results, Is.Not.Null);;
   
        }
        [Test]
        public void ReturnAddressesForValidPostCode()
        {
            var caching = new PostCodeCachingDecorator(new PostcodeLookup(new DataProvider()), new SimpleCache());
            var results = caching.Lookup("BL00LT");
            Assert.That(results.Count, Is.EqualTo(10));
        }
        
        [Test]
        public void ReturnAddressesForInvalidPostCode()
        {
            var caching = new PostCodeCachingDecorator(new PostcodeLookup(new DataProvider()), new SimpleCache());
            var results = caching.Lookup("M147WR");
            Assert.That(results.Count, Is.EqualTo(0));
        }
        
        [Test]
        public void TestValueIsReturnedFromTheCache()
        {
            var caching = new PostCodeCachingDecorator(new PostcodeLookup(new DataProvider()), new SimpleCache());
            var results = caching.Lookup("BL00LT");
            var cachedResults = caching.Lookup("BL00LT");
            Assert.That(cachedResults.Count, Is.EqualTo(10));
        }

    }
}