using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Lessons2_task3;

/*На основе класса User (см. задание 2.3) создать класс Employee, описывающий сотрудника фирмы.
Дополнить класс свойствами «стаж работы» и «должность». Обеспечить нахождение класса в
заведомо корректном состоянии.*/

namespace Lessons2_task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Данная программа создаёт класс Employee, описывающий сотрудника фирмы.");

            string name, lastName, midName, date, position, dateEmployment;

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

                Console.WriteLine();
                Console.WriteLine("Введите должность:");
                position = Console.ReadLine();
                position = CheckSymbols(position);

                Console.WriteLine();
                Console.WriteLine("Введите дату устройства на работу в формате ДД.ММ.ГГГГ: ");

                dateEmployment = Console.ReadLine();
                dateEmployment = CheckDate(dateEmployment);
                var parsedDateEmployment = DateTime.Parse(dateEmployment);

                while (!(parsedDate.Year < parsedDateEmployment.Year && parsedDateEmployment.Year >= (parsedDate.Year + 14))) 
                {
                    Console.WriteLine("Неккоректная дата утройства на работу");
                    Console.WriteLine("Пожалуйста, проверьте, что год устройства больше вашего возраста, а также, что вы устроились на работу не раньше 14 лет");
                    Console.WriteLine("Введите дату устройства на работу в формате ДД.ММ.ГГГГ: ");

                    dateEmployment = Console.ReadLine();
                    dateEmployment = CheckDate(dateEmployment);
                    parsedDateEmployment = DateTime.Parse(dateEmployment);
                }

                // Создаем объект класса Employee, передавая данные о сотруднике через конструктор
                Employee employee = new Employee(name, lastName, midName, parsedDate, position, parsedDateEmployment);

                Console.WriteLine(employee);

                Console.ReadKey();

                Console.WriteLine();
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
