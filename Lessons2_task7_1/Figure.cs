using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task7_1
{

    internal abstract class Figure
    {
        public string Type { get; set; }
        public abstract void Draw();
    }

    class Line : Figure
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;

        public Line(int X1, int Y1, int X2, int Y2)
        {
            Type = "Линия";
            this.x1 = X1;
            this.y1 = Y1;
            this.x2 = X2;
            this.y2 = Y2;
        }
        public override void Draw() 
        {
            Console.WriteLine($"Тип фигуры: {Type} , координаты ({x1},{y1}) ({x2},{y2})");
        }
    }

    class Circle : Figure
    {
        private int crX;
        private int crY;
        private int radius;
        public Circle(int X, int Y, int R)
        {
            Type = "Окружность";
            crX = X;
            crY = Y;
            radius = R;
        }
        public override void Draw() 
        {
            Console.WriteLine($"Тип фигуры: {Type} , координаты ({crX},{crY}), радиус = {radius}");
        }
    }

    class Rectangle : Figure
    {
        private int width;
        private int height;
        public Rectangle(int width, int height)
        {
            Type = "Прямоугольник";
            this.width = width;
            this.height = height;
        }
        public override void Draw()
        {
            Console.WriteLine($"Тип фигуры: {Type} , ширина = {width} высота = {height}");
        }
    }

    class Round : Figure
    {
        private int crX;
        private int crY;
        private int radius;
        public Round(int X, int Y, int radius)
        {
            Type = "Круг";
            crX = X;
            crY = Y;
            this.radius = radius;
        }
    
        public override void Draw() 
        {
            Console.WriteLine($"Тип фигуры: {Type} , координаты ({crX},{crY}), радиус = {radius}");
        }
    }

    class Ring : Figure
    {
        private int crX;
        private int crY;
        private int inRadius;
        private int outRadius;
        public Ring(int x, int y, int innerRadius, int outerRadius)
        {
            Type = "Кольцо";
            crX = x;
            crY = y;
            inRadius = innerRadius;
            outRadius = outerRadius;
        }
        public override void Draw()
        {
            Console.WriteLine($"Тип фигуры: {Type} , координаты ({crX},{crY}), радиус внутренний = {inRadius}, радиус внутренний = {outRadius} ");
        }
    }

    class VectorEditor
    {
        List<Figure> figures = new List<Figure>();

        /// <summary>
        /// Метод "Добавления" фигуры
        /// </summary>
        public void AddFigure(Figure figure)
        {
            figures.Add(figure);
        }

        public void DrawAllFigures()
        {
            foreach (var figure in figures)
            {
                figure.Draw();
            }
        }

    }


}
