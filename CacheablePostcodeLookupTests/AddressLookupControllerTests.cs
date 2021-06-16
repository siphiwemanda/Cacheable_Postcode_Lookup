using CacheablePostcodeLookup;
using NUnit.Framework;

namespace CacheablePostcodeLookupTests
{
    [TestFixture]
    public class AddressLookupControllerTests
    {
        [Test]
        public void ResultsIsNotNull()
        {
            var addressLookUp = new AddressLookupController();
            var results = addressLookUp.LookupAddress("M147WR");
            Assert.That(results.Count, Is.Not.Null);
        }
        
        [Test]
        public void ReturnAddressesForValidPostCode()
        {
            var caching = new AddressLookupController();
            var results = caching.LookupAddress("BL00LT");
            Assert.That(results.Count, Is.EqualTo(10));
        }
        
        [Test]
        public void ReturnAddressesForInvalidPostCode()
        {
            var caching = new AddressLookupController();
            var results = caching.LookupAddress("M147WR");
            Assert.That(results.Count, Is.EqualTo(0));
        }
    }
}