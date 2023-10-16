using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task7
{
    /// <summary>
    /// Базовый класс для всех фигур
    /// </summary>
    internal class Figure
    {
        /// <summary>
        /// Свойство, которое запоминает или изменяет тип фигуры 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Вывести тип фигуры и его свойства.
        /// </summary>
        public void Draw()
        {
            Console.WriteLine($"Тип фигуры: {Type}");
        }
    }

    /// <summary>
    /// Класс для представления Линии
    /// </summary>
    class Line : Figure
    {
        private Point _start;
        private Point _end;

        public Line(Point start, Point end)
        {
            _start = start;
            _end = end;
        }

        public Line (int X1, int Y1, int X2, int Y2)
        {
            Type = "Линия";
            _start.x = X1;
            _start.y = Y1;
            _end.x = X2;
            _end.y = Y2;
        }

        public void Draw()
        {
            base.Draw();
            Console.WriteLine($"Начало линии: ({_start.x}, {_start.y}), Конец линиии: ({_end.x}, {_end.y})");
        }

    }

    struct Point 
    {
        public int x;
        public int y;
    }

    /// <summary>
    /// Класс для представления окружности
    /// </summary>
    class Circle : Figure
    {
        private int crX;
        private int crY;
        private int radius;

        public  Circle (int X, int Y, int R)
        {
            Type = "Окружность";
            crX = X;
            crY = Y;
            radius = R;
        }

        public void Draw()
        {
            base.Draw();
            Console.WriteLine($"Координаты X и Y (центр): ({crX}, {crY}), Радиус: {radius}");
        }
    }

    /// <summary>
    /// Класс для представления прямоугольника
    /// </summary>
    class Rectangle : Figure
    {
        private int Width;
        private int Height;

        public Rectangle (int width, int height)
        {
            Type = "Прямоугольник";
            Width = width;
            Height = height;
        }

        public void Draw()
        {
            base.Draw();
            Console.WriteLine($"Ширина прямоугольника: {Width}, Высота прямоугольника: {Height}");
        }
    }

    /// <summary>
    /// Класс для представления круга
    /// </summary>
    class Ellipse : Figure
    {
        private int crX;
        private int crY;
        private int SemiMajorAxis;
        private int SemiMinorAxis;

        public Ellipse(int X, int Y, int major, int minor)
        {
            Type = "Круг";
            crX = X;
            crY = Y;
            SemiMajorAxis = major;
            SemiMinorAxis = minor;
        }

        public void Draw()
        {
            base.Draw();
            Console.WriteLine($"Координаты X и Y (центр): ({crX}, {crY}), Большая полуось: {SemiMajorAxis}, Малая полуось: {SemiMinorAxis}");
        }
    }

    /// <summary>
    /// Класс для представления кольца
    /// </summary>
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

        public void Draw()
        {
            base.Draw();
            Console.WriteLine($"Координаты X и Y (центр): ({crX}, {crY}), Внутренний радиус: {inRadius}, Внешний радиус: {outRadius}");
        }
    }

    /// <summary>
    /// Класс для векторного графического редактора
    /// </summary>
    class VectorEditor
    {
        List<Figure> figures = new List<Figure>();

        /// <summary>
        /// Метод "Добавления" фигуры
        /// </summary>
        /// <param name="figure"></param>
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
