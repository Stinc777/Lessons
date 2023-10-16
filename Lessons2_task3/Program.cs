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

                Console.WriteLine(user);

                Console.ReadKey();

                Console.WriteLine();
            }
        }
    }
}
