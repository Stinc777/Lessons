using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

/*Написать класс Triangle, описывающий треугольник со сторонами a, b, c и позволяющий
 *осуществить расчёт его площади и периметра. Написать программу, демонстрирующую
 *использование данного треугольника.
 */

namespace Lessons2_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Параметры треугольника задаются рандомно значениями от 1 до 10");

            Console.WriteLine();

            Random random = new Random();

            while (true)
            {
                try
                {
                    Triangle triangle = new Triangle(random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));

                    Console.WriteLine($"Площадь треугольника: {triangle.Square():F2}");
                    Console.WriteLine($"Периметр треугольника: {triangle.Perimeter():F2}");
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
}
