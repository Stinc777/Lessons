using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать программу, которая определяет сумму неотрицательных элементов в одномерном
 * массиве. Число элементов в массиве и их тип определяются разработчиком.
 */

namespace Lessons1_task9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Эта программа определяет сумму неотрицательных элементов в одномерном массиве. Число элементов и их тип определяются разработчиком");

            while (true)
            {
                
                Random random = new Random();

                int size = random.Next(1, 10);                                   // размерность массива, от 1 до 10 элементов

                int[] lengths = new int[size];

                ArrayHelper.FillRandomNumbers(lengths, random);                  //наполнение элементов разными числами

                ArrayHelper.OutputArray(lengths);                                //вывод в консоль массива

                int sumnonnegative = ArrayHelper.FindSumOfNonNegative(lengths);  //поиск суммы неотрицательных элементов в массиве               

                Console.WriteLine($"\nСумма неотрицательных элементов в массиве: {sumnonnegative}");

                Console.ReadKey();

                Console.WriteLine();
            }


        }
    }
}
