using Lessons1_task12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать программу, которая удваивает в первой введённой строке все символы, принадлежащие
 * второй введённой строке.
 * Пример:
 * Введите первую строку: написать программу, которая
 * Введите вторую строку: описание
 * Результирующая строка: ннааппииссаать ппроограамму, коотоораая
 */
namespace Lessons1_task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("удваивает в первой введённой строке все символы, принадлежащие второй введённой строке.");

            while (true)
            {
                Console.WriteLine("Введите первую строку:");
                string strmain = Console.ReadLine();

                Console.WriteLine("Введите вторую строку:");
                string strsub = Console.ReadLine();

                Console.WriteLine($"Результат: {StringHelper.DoubleCharactersInString(strmain, strsub)}");

                Console.WriteLine();
            }
        }

    }
}
