using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
*Написать программу, которая генерирует случайным образом элементы массива (число элементов
в массиве и их тип определяются разработчиком), определяет для него максимальное и
минимальное значения, сортирует массив и выводит полученный результат на экран.
Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном
задании запрещается.
*/

namespace Lessons1_task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("Эта программа генерирует случайным образом размерность и элементы массива. Число элементов и их тип определяются разработчиком");

                Random random = new Random();

                int size = random.Next(1, 10);                              // размерность массива, от 1 до 10 элементов

                int[][] lengths = new int[size][];

                ArrayHelper.FillingElementArray(lengths, size, random); //размерность элементов массива;

                ArrayHelper.FillRandomNumbers(lengths, random);         //наполнение элементов разными числами

                ArrayHelper.OutputArray(lengths);                       //вывод в консоль массивы

                int min = ArrayHelper.FindMin(lengths);                 //поиск минимального значения элемента среди всех массивов
                int max = ArrayHelper.FindMax(lengths);                 //поиск минимального значения элемента среди всех массивов

                Console.WriteLine($"\nМинимальное значение: {min}");
                Console.WriteLine($"Максимальное значение: {max}");

                Console.WriteLine("Отсортированные массивы:");

                ArrayHelper.SortArray(lengths);                         //вывод в консоль отсортированных массивов

                Console.ReadKey();

                Console.WriteLine();
            }
        }
    }
}