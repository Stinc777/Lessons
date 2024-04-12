using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*
 * Напишите программу, которая проверяет текстовую строку на соответствие имеющегося в ней текста формату вещественного числа и выводит, в каком формате оно записано.
 *  Число может быть записано в обычной нотации.
 *  Число может быть записано в научной нотации (например, 127 = 1.27*102 = 1.27e2, -0.0055 = -5.5*10-3 = -5.5e-3).
 */
namespace Lessons1_task16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Программа, которая проверяет текстовую строку на соответствие имеющегося в ней текста формату вещественного числа и выводит, в каком формате оно записано.");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Введите число:");

                string input = Console.ReadLine();

                if (IsValidNumber(input))
                {
                    Console.WriteLine("Это число в обычной нотации");
                }
                else if (IsValidScientificNotation(input))
                {
                    Console.WriteLine("Это число в научной нотации");
                }
                else
                {
                    Console.WriteLine("Введенное значение не является числом");
                }

                Console.WriteLine();
            }
        }

        // Метод для проверки, является ли строка числом в обычной нотации
        static bool IsValidNumber(string input)
        {
            return double.TryParse(input, out _);
        }

        // Метод для проверки, является ли строка числом в научной нотации
        static bool IsValidScientificNotation(string input)
        {
            return double.TryParse(input, System.Globalization.NumberStyles.Float | System.Globalization.NumberStyles.AllowThousands, System.Globalization.CultureInfo.InvariantCulture, out _);
        }

    }

}
