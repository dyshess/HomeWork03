using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    class Month
    {
        private int monthNumber;
        public int MonthNumber
        {
            get { return monthNumber; }
            set { if (value <= 12 & value > 0) { monthNumber = value; } else { Console.WriteLine("Неправильное значение месяца"); } }
        }
        public int Income { get; set; }
        public int Outlay { get; set; }
        public int Profit { get; set; }
    }
}
