using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            while (true)
            {
                // Создаем объект класса Employee, передавая данные о сотруднике через конструктор
                Employee employee = new Employee();

                Console.ReadKey();

                Console.WriteLine();
            }
        }

    }
}
