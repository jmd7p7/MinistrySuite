using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinistrySuite.Util
{
    public static class DateHelper
    {
        public static int GetNumOfDaysFromSunday(this DateTimeOffset date)
        {
            return (int)date.DayOfWeek;
        }

        public static int GetNumOfDaysUntilSaturday(this DateTimeOffset date)
        {
            return 6 - (int)date.DayOfWeek;
        }
    }
}
