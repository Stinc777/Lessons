using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lessons2_task5
{
    internal class User
    {

        protected string name;
        protected string subName;
        protected string midName;
        protected string date;
        protected int age;

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

        }

    }

    internal class Employee : User // Наследуем User для использования его свойств и методов
    {
        private int experience; // Стаж работы
        private string position; // Должность

        public Employee()
        {
            Console.WriteLine("Введите стаж работы (в годах): ");
            if (int.TryParse(Console.ReadLine(), out int exp))
            {
                experience = exp;
            }
            else
            {
                Console.WriteLine("Ошибка: Стаж работы должен быть числом.");
                experience = 0;
            }

            Console.WriteLine("Введите должность: ");
            position = Console.ReadLine();

            // Можем использовать поля из класса User напрямую
            Console.WriteLine($"Имя: {name}, Фамилия: {subName}, Отчество: {midName}, Дата рождения: {date}, Возраст: {age}, Стаж работы: {experience} года(лет), Должность: {position}");
        }
    }

}
