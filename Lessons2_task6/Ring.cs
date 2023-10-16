using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task6
{
    internal class Ring
    {
        private double centerX;        // Координата x центра кольца
        private double centerY;        // Координата y центра кольца
        private double innerRadius;    // Внутренний радиус кольца
        private double outerRadius;    // Внешний радиус кольца

        /// <summary>
        /// Конструктор для создания объекта класса Ring
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="innerRadius"></param>
        /// <param name="outerRadius"></param>
        /// <exception cref="ArgumentException"></exception>
        
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double InnerRadius { get; set; }
        public double OuterRadius { get; set; }

        public Ring(double x, double y, double innerRadius, double outerRadius)
        {
            // Проверяем, что внешний радиус больше внутреннего радиуса
            if (outerRadius <= innerRadius)
            {
                throw new ArgumentException("Внешний радиус должен быть больше внутреннего радиуса.");
            }

            centerX = x;
            centerY = y;
            this.innerRadius = innerRadius;
            this.outerRadius = outerRadius;
        }

        /// <summary>
        /// Свойство для вычисления площади кольца
        /// </summary>
        public double Area
        {
            get
            {
                return Math.PI * (outerRadius * outerRadius - innerRadius * innerRadius);
            }
        }

        /// <summary>
        /// Свойство для вычисления суммарной длины внешней и внутренней окружностей
        /// </summary>
        public double TotalCircumference
        {
            get
            {
                return 2 * Math.PI * outerRadius + 2 * Math.PI * innerRadius;
            }
        }

    }
}
