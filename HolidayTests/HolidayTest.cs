using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class Holidaytest
    {
        [Test]
        public void today_is_xmas()
        {
            var holiday = new HolidayForTest();

            holiday.today = new DateTime(2000, 12, 25);

            Assert.True(holiday.SayHello() == "Merry Xmas");
        }

        [Test]
        public void today_is_not_xmas()
        {
            var holiday = new Holiday();

            Assert.True(holiday.SayHello() == "Today is not Xmas");
        }

        private class HolidayForTest : Holiday
        {
            public DateTime today= DateTime.Now;

            protected override DateTime GetToday()
            {
                return today;
            }
        }
    }

  
}