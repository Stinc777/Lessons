using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее
«изображение», состоящее из N треугольников:
 */

namespace Lessons1_task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Напишите любую цифру N, я сделаю несколько треугольников заканчиваемщся на N числе:");
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
            for (int triangle = 0; triangle < number; triangle++)
            {
                // Проверяем сколько строк в трегуольнике
                for (int str = 0; str < triangle+1; str++)
                {
                    // Выводим пробелы перед звездочками
                    for (int space = 0; space < number - str - 1; space++)
                    {
                        Console.Write(" ");
                    }

                    // Выводим звездочки
                    for (int star = 0; star < 2 * str + 1; star++)
                    {
                        Console.Write("*");
                    }

                    Console.WriteLine();

                }
            }
        }
    }
}

