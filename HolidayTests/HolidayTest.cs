using System;
using Lib;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTest
    {
        [Test]
        public void today_is_xmas()
        {
            Assert.True(true);

            var holiday = new HolidayForTest();

            Assert.True(holiday.SayHello() == "Merry Xmas");
        }

        private class HolidayForTest : Holiday
        {
            protected override DateTime GetToday()
            {
                return new DateTime(2000, 12, 25);
            }
        }
    }

  
}