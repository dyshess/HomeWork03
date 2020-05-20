using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_005
{
    class Akkerman
    {
        /// <summary>
        /// Функция аккермана
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int Akk(int n, int m)
        {
            if (n == 0)
            {
                return m + 1;
            }
            else if (n != 0 & m == 0)
            {
                return Akk(n - 1, 1);
            }
            else
            {
                return Akk(n - 1, Akk(n, m - 1));
            }
        }
    }
}
