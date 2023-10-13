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

        private double sideA;
        private double sideB;
        private double sideC;

        /// <summary>
        /// Конструктор для создания объекта класса Triangle
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(int x, int y, int r)
        {

            sideA = x;
            sideB = y;
            sideC = r;

            Console.WriteLine($"Сторона A: {sideA}, Сторона B: {sideB}, Сторона C: {sideC}");

            if (!IsValidTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("Треугольник с такими сторонами не существует. Поскольку a + b > c И a + c > b И b + c > a");
            }

        }

        /// <summary>
        /// Метод расчёта площади треугольника
        /// </summary>
        /// <returns></returns>
        public double Square()
        {
            double value;
            value = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(value * (value - sideA) * (value - sideB) * (value - sideC));
        }

        /// <summary>
        /// Метод расчёта периметра треугольника
        /// </summary>
        /// <returns></returns>
        public double Perimeter()
        {
            return sideA + sideB + sideC;
        }

        /// <summary>
        /// Проверка на существование треугольника
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

    }
}
