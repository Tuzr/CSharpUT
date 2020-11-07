using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class Holidaytest
    {
        private HolidayForTest _holiday;

        [SetUp]
        public void Setup()
        {
            _holiday = new HolidayForTest();
        }

        [Test]
        public void today_is_xmas()
        {
            GivenToday(12, 25);
            ResponseShouldBe("Merry Xmas");
        }

        [Test]
        public void today_is_xmas_when_1224()
        {
            GivenToday(12, 24);
            ResponseShouldBe("Merry Xmas");
        }

        [Test]
        public void today_is_not_xmas()
        {
            GivenToday(12, 26);
            ResponseShouldBe("Today is not Xmas");
        }

        private void ResponseShouldBe(string expected)
        {
            Assert.AreEqual(expected,_holiday.SayHello());
        }

        private void GivenToday(int month, int day)
        {
            _holiday.today = new DateTime(2000, month, day);
        }

        private class HolidayForTest : Holiday
        {
            public DateTime today = DateTime.Now;

            protected override DateTime GetToday()
            {
                return today;
            }
        }
    }

  
}