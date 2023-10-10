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

        // Конструктор для создания объекта класса Round
        public Round(double x, double y, double r)
        {
            SetCenter(x, y);
            SetRadius(r);
        }

        // Метод для установки координат центра
        public void SetCenter(double x, double y)
        {
            valueX = x;
            valueY = y;
        }

        // Метод для установки радиуса с проверкой на корректность
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

            // Метод для вычисления длины описанной окружности
        public double CalculateCircumference()
        {
            return 2 * Math.PI * radius;
        }

        // Метод для вычисления площади круга
        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

    }

}
