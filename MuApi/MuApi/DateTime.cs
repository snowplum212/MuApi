using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuApi
{
    public class DateTime
    {
        public static void Date()
        {
            Console.WriteLine(System.DateTime.Now);
        }

        public static void Datevalue()
        {
            Console.WriteLine(System.DateTime.Now.ToShortDateString());
        }
        public static int Day(int month)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("month", "1과 12 사이의 값을 입력해야 합니다.");
            }

            // 각 달의 날짜 수 배열
            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            // 윤년 고려
            if (month == 2)
            {
                if (System.DateTime.IsLeapYear(System.DateTime.Now.Year))
                {
                    return 29; // 윤년인 경우
                }
            }

            return daysInMonth[month - 1];
        }
    }
}
