using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class AuthenticationServiceTests : IToken
    {
        [Test()]
        public void is_valid()
        {
            var target = new AuthenticationService(new ProfileDao(), this);

            var actual = target.IsValid("joey", "91000000");

            //always failed
            Assert.IsTrue(actual);
        }

        public string GetRandom(string account)
        {
            return "000000";
        }
    }
}