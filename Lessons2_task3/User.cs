using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task3
{
    internal class User
    {     

        private string name;
        private string subName;
        private string midName;
        private string date;
        private int age;

        // Конструктор для создания объекта класса User
        public User()
        {

            Console.WriteLine("Введите своё имя: ");
            name = Console.ReadLine();

            Console.WriteLine("Введите свою фамилию: ");
            subName = Console.ReadLine();

            Console.WriteLine("Введите своё отчество: ");
            midName = Console.ReadLine();

            Console.WriteLine("Введите свою дату рождения: ");
            date = Console.ReadLine();

            Console.WriteLine("Введите свой возраст: ");
            if (int.TryParse(Console.ReadLine(), out int userAge))
            {
                age = userAge;
            }
            else
            {
                Console.WriteLine("Ошибка: Возраст должен быть числом.");
                age = 0; // Устанавливаем значение по умолчанию.
            }

            Console.WriteLine($"Имя: {name}, Фамилия: {subName}, Отчесвтво: {midName}, Дата рождения: {date}, Возраст: {age} ");

        }

    }
}
