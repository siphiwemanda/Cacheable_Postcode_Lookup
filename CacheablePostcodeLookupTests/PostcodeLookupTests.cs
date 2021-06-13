using CacheablePostcodeLookup.PostCodeLookup;
using NUnit.Framework;

namespace CacheablePostcodeLookupTests
{
    [TestFixture]
    public class PostcodeLookupWill
    {
        [Test]
        public void ReturnAddressesForValidPostCode()
        {
            var lookup = new PostcodeLookup(new DataProvider());
            var results = lookup.Lookup("BL00LT");
            Assert.That(results.Count, Is.EqualTo(10));
        }
        [Test]
        public void ReturnAddressesForOtherValidPostCode()
        {
            var lookup = new PostcodeLookup(new DataProvider());
            var results = lookup.Lookup("SK136NB");
            Assert.That(results.Count, Is.EqualTo(18));
        }
        [Test]
        public void ReturnAddressesForInvalidPostCode()
        {
            var lookup = new PostcodeLookup(new DataProvider());
            var results = lookup.Lookup("TURN1P5");
            Assert.That(results.Count, Is.EqualTo(0));
        }
    }
}

