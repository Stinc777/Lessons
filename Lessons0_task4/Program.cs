using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Написать программу, которая заполняет и сортирует многомерный массив. Постановка задачи:
Пользователь вводит с клавиатуры число N (размерность массива), затем последовательно
вводит N чисел – число элементов по каждой размерности. Программа должна:
1. Создать массив заданной размерности и указанной по размерностям длины.
2. Заполнить данный массив случайными числами из диапазона 0..100 (массив считаем
целочисленным).
3. Вывести его на экран.
4. Отсортировать полученный массив.
5. Вывести на экран отсортированный массив.
Примечания:
1. При выводе массива на экран можно ограничивать каждую размерность скобками. Например,
2D массив размером [2,3] может быть выведен на экран так: {{1,2,3,},{4,5,6,},}. Лишние запятые в
конце вполне допустимы.
2. Методы должны получать минимальное количество необходимой информации. Например,
метод сортировки должен получать только сам массив.
*/

namespace Lessons0_task4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Введите размерность массива: ");
            int size = int.Parse(Console.ReadLine());

            int[] lengths = new int[size];
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите число элементов по {i + 1}-й размерности: ");
                lengths[i] = int.Parse(Console.ReadLine());
            }

            //--- Правильный вариант
            int[][] array = new int[size][];
            for (int i = 0; i < size; i++)
            {
                array[i] = new int[lengths[i]];
            }

            FillRandomNambers(array);
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(PrintArrayToString(array));
            SortArray(array);
            Console.WriteLine("Отсортированный массив:");
            Console.WriteLine(PrintArrayToString(array));

            //--- старый вариант
            //int[,] array = new int[lengths.Length, lengths.Max()];

            //Random random = new Random();
            //for (int i = 0; i < array.GetLength(0); i++)
            //{
            //    for (int j = 0; j < lengths[i]; j++)
            //    {
            //        array[i, j] = random.Next(0, 101);
            //    }
            //}

            //Console.WriteLine("Исходный массив:");
            //PrintArray(array);

            //SortArray(array);

            //Console.WriteLine("Отсортированный массив:");
            //PrintArray(array);

            Console.ReadKey();
        }

        static string PrintArrayToString(int[][] array)
        {
            string result;

            result = "{ \n";
            for (int i = 0; i < array.Count(); i++)
            {
                result += "{";

                //--- вариант 2
                result += string.Join(", ", array[i]);

                // --- вариант 1
                //for (int j = 0; j < array[i].Count(); j++)
                //{
                //    result += $"{array[i][j]}, ";
                //}

                result += "},\n";
            }
            result += "}";

            return result;
        }

        static void SortArray(int[][] array)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = 0; j < array[i].Count(); j++)
                {
                    Array.Sort(array[i]);
                }
            }
        }

        static void FillRandomNambers(int[][] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Count(); i++)
            {
                for (int j = 0; j < array[i].Count(); j++)
                {
                    array[i][j] = random.Next(0, 100);
                }
            }
        }


        static void PrintArray(int[,] array)
        {
            Console.Write("{");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("{");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]},");
                }
                Console.Write("},");
            }
            Console.WriteLine("}");
        }

        static void SortArray(int[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            int[] flattenedArray = new int[rows * cols];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flattenedArray[index] = array[i, j];
                    index++;
                }
            }

            Array.Sort(flattenedArray);

            index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = flattenedArray[index];
                    index++;
                }
            }

        }
    }
}
