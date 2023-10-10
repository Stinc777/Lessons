using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее
 * «изображение», состоящее из N строк:
 *
 **
 ***
 ****
 */
namespace Lessons1_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Напишите любую цифру:");
            string value = Console.ReadLine();

            int value_user;
            bool result = int.TryParse(value, out value_user);

            while (!result || value_user == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Вы ввели невалидные данные");
                Console.WriteLine("Попробуйте снова");

                value = Console.ReadLine();
                result = int.TryParse(value, out value_user);
            }

            PrintTriangle(value_user);
            Console.ReadKey();

        }

        static void PrintTriangle(int number)
        {
            for (int star = 0; star <= number; star++)
            {
                for (int i = 0; i < star; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }

        }

    }
}
