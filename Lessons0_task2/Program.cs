using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Число считается простым, если его можно разделить без остатка только на единицу и на само себя
(например, 7).
Необходимо написать функцию, определяющую, является ли заданное число N (положительное
целое) простым.
Значение N передаётся в функцию в качестве аргумента.
 */
namespace Lessons0_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите любую цифру");
            string value = Console.ReadLine();
            int value_user = Convert.ToInt16(value);
            Prime_number(value_user);
        }

        static void Prime_number(int number)
        {
            number %= 2;

            if (number == 0)
            {
                Console.WriteLine("Число непростое!");
            }
            else Console.WriteLine("Число простое!");


        }

    }
}
