using System.Collections.Generic;
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
            Assert.That(results, Is.Not.Null);
   
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
            var list = new List<Address>() {new Address() {Text = "60 Bolton Road North"}};
            const string postcode = "BL00LT";
            var cache = new SimpleCache();
            cache.Set(postcode, list, 30);
            var caching = new PostCodeCachingDecorator(new PostcodeLookup(new DataProvider()), cache);
            var cachedResults = caching.Lookup("BL00LT");
            Assert.That(cachedResults.Count, Is.EqualTo(1));
        }

    }
}