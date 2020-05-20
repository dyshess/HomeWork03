using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    /// <summary>
    /// Представляет собой генератор месячных отчётов со случайными параметрами 
    /// </summary>
    class MonthlyReport
    {
        private List<Month> Report { get; set; } = new List<Month>();
        private List<Month> MinProfit { get; set; } = new List<Month>();
        /// <summary>
        /// Создание отчёта
        /// </summary>
        /// <returns>Возвращает отчёт в виде списка месяцев</returns>
        public List<Month> GenerateReport()
        {
            Random random = new Random();
            for (int i = 1; i < 13; i++)
            {
                var temp = new Month();
                temp.MonthNumber = i;
                temp.Income = random.Next(0, 10) * 1000;
                temp.Outlay = random.Next(0, 10) * 1000;
                temp.Profit = temp.Income - temp.Outlay;
                this.Report.Add(temp);
            }
            return Report;
        }

        /// <summary>
        /// Метод для поиска месяцев с минимальной прибылью
        /// </summary>
        /// <param name="months">Список месяцев</param>
        /// <param name="count">Количество худших доходов</param>
        /// <returns>Возвращает месяцы с минимальными доходами</returns>
        public List<Month> FindMinProfit(List<Month> months, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var tempMonths = months.FindAll(b => b.Profit == months.Min(d => d.Profit)).ToList();
                MinProfit.AddRange(tempMonths);

                foreach (var item in tempMonths)
                {
                    months.Remove(item);
                }
            }
            return MinProfit;
        }
        /// <summary>
        /// Метод вывода на экран переменных отчёта
        /// </summary>
        public void Print()
        {
            foreach (var month in this.Report)
            {
                Console.WriteLine(month.MonthNumber + "\t\t" + month.Income + "\t\t" + month.Outlay + "\t\t" + month.Profit);
            }
        }
        /// <summary>
        /// Метод вывода на экран номеров месяцев
        /// </summary>
        /// <param name="months">Список месяцев</param>
        public void PrintMonthNumbers(IEnumerable<Month> months)
        {
            foreach (var month in months)
            {
                Console.Write(month.MonthNumber + "\t");
            }
        }
    }
}
