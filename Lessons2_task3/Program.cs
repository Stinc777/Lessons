using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            while (true)
            {

                User user = new User("Даниил", "Лексин", "Сергеевич", new DateTime(2001,06,08));


                Console.WriteLine($"Имя пользователя: {user.Name}");
                Console.WriteLine($"Фамилия пользователя: {user.SubName}");
                Console.WriteLine($"Отчество пользователя: {user.MidName}");
                Console.WriteLine($"Год рождения: {user.Date.ToString("dd.MM.yyyy")}");
                Console.WriteLine($"Количество полных лет: {user.Age}"); 

                Console.ReadKey();

                Console.WriteLine();
            }
        }
    }
}
