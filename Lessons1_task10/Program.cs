using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Элемент двумерного массива считается стоящим на чётной позиции, если сумма номеров его
 * позиций по обеим размерностям является чётным числом (например, [1,1] — чётная позиция, а
 * [1,2] — нет). Определить сумму элементов массива, стоящих на чётных позициях.
 */

namespace Lessons1_task10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Эта программа определяет сумму элементов двумерного массива, стоящих на чётных позициях ([0,0], [1,1] и т.д.). Число элементов и их тип определяются разработчиком");

            while (true)
            {

                Random random = new Random();

                int size = random.Next(1, 10);                          // размерность массива, от 1 до 10 элементов

                int[][] lengths = new int[size][];

                ArrayHelper.FillingElementArray(lengths, size, random); //наполнение размерности массива;

                ArrayHelper.FillRandomNumbers(lengths, random);         //наполнение элементов массивов разными числами от -100 до 100

                ArrayHelper.OutputArray(lengths);                       //вывод в консоль массивы

                int sum = ArrayHelper.SumOfEvenPostionNumbers(lengths);  //поиск суммы неотрицательных элементов в массиве               

                Console.WriteLine($"\nСумма элементов стоящих на чётных позициях: {sum}");

                Console.ReadKey();

                Console.WriteLine();
            }

        }
    }
}
