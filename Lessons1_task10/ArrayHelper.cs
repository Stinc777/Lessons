using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons1_task10
{
    internal class ArrayHelper
    {
        public static void FillingElementArray(int[][] array, int size, Random random)
        {
            for (int i = 0; i < size; i++)
            {
                int arraySize = random.Next(1, 10);             // число элементов в массиве
                array[i] = new int[arraySize];
            }
        }

        public static void FillRandomNumbers(int[][] array, Random random)  // Заполняем случайными числами диапазоном от -100 до 100
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = random.Next(-100, 100);
                }
            }
        }

        public static void OutputArray(int[][] array)
        {
            Console.WriteLine("Массивы: ");
            for (int i = 0; i < array.Length; i++)            //сверка с размерностью массива, и по очереди выводится массивы с их элементами.
            {
                Console.Write("{");
                for (int j = 0; j < array[i].Length; j++)     //по очереди выводится каждый элемент одного массива
                {
                    Console.Write(array[i][j]);
                    if (j < array[i].Length - 1)              // если элемента больше 1, то ставится ","
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine("}");
            }
        }

        public static int SumOfEvenPostionNumbers(int[][] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (i == j)
                        sum += array[i][j];
                }

            }

            return sum;

        }
    }
}
