using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons1_task7
{
    public class ArrayHelper
    {


        public static void FillingElementArray(int[][] array, int size, Random random)
        {
            for (int i = 0; i < size; i++)
            {
                int arraySize = random.Next(1, 15);             // число элементов в массиве
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
            Console.Write("Массив: ");
            Console.Write("{");
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
                Console.Write("}");
                if (i < array.Length - 1)                     // запятая после выведения целого массива
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("}");
        }


        public static int FindMin(int[][] array)            // каждый элемент массива в каждом массива сравнивается с первым элементом первого массива, который присвается переменной min. 
        {                                                   // Если элемент меньше первого элемента, то он становится min
            int min = array[0][0];      
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                    }
                }
            }
            return min;
        }

        public static int FindMax(int[][] array)            // каждый элемент массива в каждом массиве сравнивается с первым элементом первого массива, который присвается переменной max. 
        {                                                   // Если элемент больше первого элемента, то он становится max
            int max = array[0][0];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                    }
                }
            }
            return max;
        }

        public static void SortArray(int[][] array)         //Сортировка происходит по проверке каждого элемента массива со следующим элементом. Если первый элемент больше, то они меняются местами со вторым.
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    for (int k = 0; k < array[i].Length - j - 1; k++)
                    {
                        if (array[i][k] > array[i][k + 1])
                        {
                            int temp = array[i][k];
                            array[i][k] = array[i][k + 1];
                            array[i][k + 1] = temp;
                        }
                    }
                }
            }

            for (int i = 0; i < array.Length; i++)            //выводится каждый массив со своими отсортированными элементами.
            {
                Console.Write("{");
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j]);
                    if (j < array[i].Length - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write("}");
                Console.WriteLine();
            }

        }
    }
}
