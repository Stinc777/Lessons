using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons1_task9
{
    internal class ArrayHelper
    {

        public static void FillRandomNumbers(int[] array, Random random)  // Заполняем случайными числами диапазоном от -100 до 100
        {
            for (int i = 0; i < array.Length; i++)
            {
                 array[i] = random.Next(-100, 100);
            }
        }

        public static void OutputArray(int[] array)
        {
            Console.Write("Массив: ");
            Console.Write("{");
            for (int i = 0; i < array.Length; i++)            
            {
             
                Console.Write(array[i]);
                if (i != array.Length - 1)
                    Console.Write(", ");

            }
            Console.WriteLine("}");
        }

        public static int FindSumOfNonNegative(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)

                sum += array[i];

            }

            return sum;

        }
    }
}
