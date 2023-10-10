using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Написать функцию, формирующую и возвращающую строку вида 1, 2, 3, … N (положительное
число).
Значение N передаётся в функцию в качестве аргумента.
Пример возвращаемого значения для N=7: 1, 2, 3, 4, 5, 6, 7
*/

namespace Lesson0task_1
{
    internal class Program
    {
        static void Main()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Напишите любую цифру");
            string value = Console.ReadLine();
            
            //int value_user = Convert.ToInt16(value);
            //Series_numbers(value_user);

            int value_user;
            bool result = int.TryParse(value, out value_user);

            while (!result)
            {
                Console.WriteLine("");
                Console.WriteLine("Вы ввели невалидные данные");
                Console.WriteLine("Попробуйте снова");

                value = Console.ReadLine();
                result = int.TryParse(value, out value_user);
            }
        }

        static void Series_numbers(int number)
        {
            for (int order = 0; order < number + 1; order++)
            {
                Console.Write("{0}", order);
                if (order != number)
                    Console.Write(",");
            }

        }

    }
}

//int value_user;
//bool result = int.TryParse(value, out value_user);

//while (!result)
//{
//    Console.WriteLine("");
//    Console.WriteLine("Вы ввели невалидные данные");
//    Console.WriteLine("Попробуйте снова");

//    value = Console.ReadLine();
//    result = int.TryParse(value, out value_user);
//}
