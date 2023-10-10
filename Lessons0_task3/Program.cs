using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Написать функцию, выводящую на экран квадрат из звёздочек со стороной равной N
(положительное нечётное целое число). Центральная звёздочка должна отсутствовать.
Значение N передаётся в функцию в качестве аргумента.*/

namespace Lessons0_task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите любую цифру:");
            string value = Console.ReadLine();
            int value_user = Convert.ToInt16(value);
            PrintSqrt(value_user);
            Console.ReadKey();
        }

        static void PrintSqrt(int number)
        {
            int length, width;

            if (number <= 0 || number % 2 == 0)
            {
                throw new ArgumentException("Вводимое число должно быть положительным нечётным.");
            }

            for (length = 0; length < number; length++)
            {
                for (width = 0; width < number; width++)
                {
                    string s = (length == number / 2) && (width == number / 2) ? " " : "*";
                    Console.Write(s);

                    //if ((length == number / 2) && (width == number / 2))
                    //{
                    //    Console.Write(" ");
                    //}
                    //else
                    //{
                    //    Console.Write("*");
                    //}
                }
                Console.WriteLine();
            }

        }
    }
}
