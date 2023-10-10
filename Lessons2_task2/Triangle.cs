using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Написать класс Triangle, описывающий треугольник со сторонами a, b, c и позволяющий
 *осуществить расчёт его площади и периметра. Написать программу, демонстрирующую
 *использование данного треугольника.
 */

namespace Lessons2_task2
{
    internal class Triangle
    {

        Random random = new Random();

        private double sideA;
        private double sideB;
        private double sideC;

        // Конструктор для создания объекта класса Triangle
        public Triangle()
        {

            Random random = new Random();
            sideA = random.Next(1, 11);
            sideB = random.Next(1, 11);
            sideC = random.Next(1, 11);

            Console.WriteLine($"Сторона A: {sideA}, Сторона B: {sideB}, Сторона C: {sideC}");

            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Треугольник с такими сторонами не существует. Поскольку a + b > c И a + c > b И b + c > a");
            }

        }

        // Метод расчёта площади треугольника
        public double Square()
        {
            double value;
            value = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(value * (value - sideA) * (value - sideB) * (value - sideC));
        }

        // Метод расчёта периметра треугольника
        public double Perimeter()
        {
            return sideA + sideB + sideC;
        }

        // Проверка на существование треугольника
        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

    }
}
