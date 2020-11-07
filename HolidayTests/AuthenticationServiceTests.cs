using System;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Lib;
using Moq;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private IProfile _profile;
        private IToken _token;
        private INotification _notification;
        private AuthenticationService _target;

        [Test()]
        public void valid()
        {
            GivenToken("000000");
            GivenPassword("joey", "91");
            ShouldBeValid("joey", "91000000");
        }

        [Test()]
        public void invalid()
        {
            GivenToken("000000");
            GivenPassword("joey", "91");
            ShouldBeInValid("joey", "wrong password");
        }

        [Test()]
        public void should_send_message_to_account_when_invalid()
        {
            GivenToken("000000");
            GivenPassword("joey", "91");
            _target.IsValid("joey", "wrong password");

            _notification.Received(1).
                Send(Arg.Is<string>
                    (s => s.Contains("login failed") && s.Contains("joey")));
        }

        private void ShouldBeValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.IsTrue(actual);
        }

        private void ShouldBeInValid(string account, string password)
        {
            var actual = _target.IsValid(account, password);
            Assert.False(actual);
        }

        private void GivenToken(string token)
        {
            _token.GetRandom("").ReturnsForAnyArgs(token);
        }

        private void GivenPassword(string account, string password)
        {
            _profile.GetPassword(account).Returns(password);
        }

        [SetUp]
        public void Setup()
        {
            _profile = Substitute.For<IProfile>();
            _token = Substitute.For<IToken>();
            _notification = Substitute.For<INotification>();
            _target = new AuthenticationService(_profile, _token, _notification);
        }
    }
}