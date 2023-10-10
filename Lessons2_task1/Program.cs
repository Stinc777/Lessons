using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать класс Round, задающий круг с указанными координатами центра, радиусом, а также
свойствами, позволяющими узнать длину описанной окружности и площадь круга. Обеспечить
нахождение объекта в заведомо корректном состоянии. Написать программу, демонстрирующую
использование данного круга.
 */

namespace Lessons2_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Параметры (координаты) и радиус окружности задаются рандомно значениями от 1 до 10");
            
            Random random = new Random();

            try
            {
                // Создаем объект класса Round
                Round myCircle = new Round(random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

                // Выводим информацию о круге
                Console.WriteLine($"Центр круга: ({myCircle.valueX}, {myCircle.valueY})");
                Console.WriteLine($"Радиус круга: {myCircle.radius:F3}");
                Console.WriteLine($"Длина описанной окружности: {myCircle.CalculateCircumference():F3}");
                Console.WriteLine($"Площадь круга: {myCircle.CalculateArea():F3}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            Console.ReadKey();

            Console.WriteLine();

        }

    }
}
