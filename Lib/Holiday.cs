using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Holiday
    {
        public Holiday()
        {

        }

        public string SayHello()
        {
            var today = GetToday();
            if (today.Month ==12 && (today.Day==25 || today.Day==24))
            {
                return "Merry Xmas";
            }
            else
            {
                return "Today is not Xmas";
            }
        }

        protected virtual DateTime GetToday()
        {
            var today = new DateTime();
            return today;
        }
    }
}
