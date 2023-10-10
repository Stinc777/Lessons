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

        // Свойство для вычисления площади кольца
        public double Area
        {
            get
            {
                return Math.PI * (outerRadius * outerRadius - innerRadius * innerRadius);
            }
        }

        // Свойство для вычисления суммарной длины внешней и внутренней окружностей
        public double TotalCircumference
        {
            get
            {
                return 2 * Math.PI * outerRadius + 2 * Math.PI * innerRadius;
            }
        }
    }
}
