using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    public class Class2
    {
        /// <summary>
        /// Расчет задания для массива
        /// </summary>
        /// <param name="mas"></param> 
        //Расчет задания для массива
        public static int calculate(int[] mas)
        {
            int proiz = 1;
            for (int i = 0; i < mas.Length; i++)
            {
              proiz *= mas[i]; //вычисляем произведение чисел
            }
            return proiz;
        }
    }
}
