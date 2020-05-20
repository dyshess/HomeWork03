using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_005
{
    class IdentifyProgression
    {
        /// <summary>
        /// Проверка на наличие прогрессии в массиве чисел
        /// </summary>
        /// <param name="numbers">Массив чисел int[]</param>
        /// <returns>Результат в виде строки</returns>
        public string Identify(int[] numbers)
        {
            string result;
            bool isArifmetic =  IdentifyArifmetic(numbers);
            bool isGeometric = IdentifyGeometric(numbers);
            if (isArifmetic)
            {
                result = "Арифметическая прогрессия";
            }
            else if (isGeometric)
            {
                result = "Геометрическая прогрессия";
            }
            else
            {
                result = "Не является прогрессией";
            }
            return result;
        }
        /// <summary>
        /// Проверка на наличие Арифметической прогрессии
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private bool IdentifyArifmetic(int[] numbers)
        {
            bool result = true;
            int argument = numbers[1] - numbers[0];
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (argument != numbers[i + 1] - numbers[i])
                {
                    result = false;
                }
            }
            return result;
        }
        /// <summary>
        /// Проверка на наличие Геометрической прогрессии
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        private bool IdentifyGeometric(int[] numbers)
        {
            bool result = true;
            int argument = numbers[1] / numbers[0];
            for (int i = 1; i < numbers.Length - 1; i++)
            {
                if (argument != numbers[i + 1] / numbers[i])
                {
                    result = false;
                }
            }
            return result;
        }
    }
}
