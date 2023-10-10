using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на
нули. Число элементов в массиве и их тип определяются разработчиком.
 * 
 */

namespace Lessons1_task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {

                Console.WriteLine("Эта программа заменяет все положительные элементы в трёхмерном массиве на нули. Число элементов и их тип определяются разработчиком");

                Random random = new Random();

                int xSize = random.Next(1, 5);
                int ySize = random.Next(1, 5);
                int zSize = random.Next(1, 5);

                int[,,] array = new int[xSize, ySize, zSize];

                ArrayHelper.FillRandomNumbers(array, xSize, ySize, zSize, random);      // Заполнение массива случайными значениями, числами диапазоном от -100 до 100

                Console.WriteLine();

                Console.WriteLine("Исходный массив:");

                ArrayHelper.Print3DArray(array);                                        // Вывод трёхмерного массива

                ArrayHelper.ReplacementArray(array, xSize, ySize, zSize);               // Замена положительных элементов на нули

                Console.WriteLine();
                Console.WriteLine("Массив после замены:");                                  // Вывод трёхмерного массива

                ArrayHelper.Print3DArray(array);

                Console.ReadKey();

                Console.WriteLine();
            }
        }       

    }
}
