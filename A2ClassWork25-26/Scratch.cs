using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2ClassWork25_26
{

    internal class Scratch
    {
        static void Main(string[] args)
        {
            int currentMonth = DateTime.Now.Month;
            Console.WriteLine($"current month number is {currentMonth}");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"increment {i} returns month numbe4 {GetMonthNum(currentMonth, i)}");
            }
        }
        private static int GetMonthNum(int currentMonth, int increment)
        {
            int monthNum = (currentMonth + increment) % 13;
           
            //if (currentMonth + increment > 12)
            //{
                
            //}
            //if (monthNum < currentMonth)
            //{
            //    return currentMonth - increment;
            //}
            return monthNum;
        }
    }
}
