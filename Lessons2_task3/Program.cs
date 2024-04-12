using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

/*Написать класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).
Написать программу, демонстрирующую использование этого класса.
 */

namespace Lessons2_task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Данная программа создаёт класс User, описывающий человека (Фамилия, Имя, Отчество, Дата рождения, Возраст).");

            string name;
            string lastName;
            string midName;
            string date;

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Напишите имя:");

                name = Console.ReadLine();
             
                name = CheckSymbols(name);

                Console.WriteLine();
                Console.WriteLine("Напишите Фамилию:");

                lastName = Console.ReadLine();

                lastName = CheckSymbols(lastName);

                Console.WriteLine();
                Console.WriteLine("Напишите Отчество:");

                midName = Console.ReadLine();

                midName = CheckSymbols(midName);

                Console.WriteLine();
                Console.WriteLine("Напишите Дату рождения в формате ДД.ММ.ГГГГ:");

                date = Console.ReadLine();

                date = CheckDate(date);

                var parsedDate = DateTime.Parse(date);

                User user = new User(name, lastName, midName, parsedDate);

                //Changing(user, "Михаил");

                Console.WriteLine(user);

                Console.WriteLine();

                Console.ReadKey();

            }
        }

        static string CheckSymbols(string str)
        {
            while (Regex.IsMatch(str, @"[0-9!?.,;:'""]"))
            {
                Console.WriteLine();
                Console.WriteLine("В тексте обнаружены посторонние символы, исправьте:");
                str = Console.ReadLine();
            }
            return str;
        }
        static string CheckDate(string str)
        {
            while (!Regex.IsMatch(str, @"(?:[012]?[1-9]|3[0-1]).(?:[0]?[1-9]|1[0-2]).(19\d{2}|20(?:0[0-9]|1[0-9]|2[0-4]))"))
            {
                Console.WriteLine();
                Console.WriteLine("Дата не соответсвует действительности. исправьте:");
                str = Console.ReadLine();
            }
            return str;
        }

    }
}
