using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task7_2
{
    abstract class Figure
    {
        public abstract void Draw();
    }

    class Line : Figure
    {
        private int x1, y1, x2, y2;

        public Line(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        public override void Draw()
        {
            Console.WriteLine($"Линия: начальные координаты ({x1}, {y1}), конечные координаты ({x2}, {y2})");
        }
    }

    class Circle : Figure
    {
        private int x, y, radius;

        public Circle(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine($"Окружность: центр ({x}, {y}), радиус {radius}");
        }
    }

    class Rectangle : Figure
    {
        private int  width, height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Прямоугольник:  ширина {width}, высота {height}");
        }
    }
}
