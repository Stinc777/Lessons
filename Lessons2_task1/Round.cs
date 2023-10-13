using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task1
{
    internal class Round
    {
        public double valueX;
        public double valueY;
        public double radius;

        /// <summary>
        /// Конструктор для создания объекта класса Round
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="r"></param>
        public Round(int x, int y, int r)
        {
            SetCenter(x, y);
            SetRadius(r);
        }

        /// <summary>
        /// Метод для установки координат центра
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetCenter(double x, double y)
        {
            valueX = x;
            valueY = y;
        }

        /// <summary>
        /// Метод для установки радиуса с проверкой на корректность
        /// </summary>
        /// <param name="r"></param>
        /// <exception cref="ArgumentException"></exception>
        public void SetRadius(double r)
        {
            if (r >= 0)
            {
                radius = r;
            }
            else
            {
                throw new ArgumentException("Радиус не может быть отрицательным.");
            }
        }

        /// <summary>
        /// Метод для вычисления длины описанной окружности
        /// </summary>
        /// <returns></returns>
        public double CalculateCircumference()
        {
            return 2 * Math.PI * radius;
        }

        /// <summary>
        /// Метод для вычисления площади круга
        /// </summary>
        /// <returns></returns>
        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

    }

}
