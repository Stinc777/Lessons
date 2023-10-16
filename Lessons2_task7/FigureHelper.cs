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
    internal class FigureHelper
    {
        /// <summary>
        /// Свойство, которое запоминает или изменяет тип фигуры 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Вывести тип фигуры и его свойства.
        /// </summary>
        public virtual void Draw()
        {
            Console.WriteLine($"Тип фигуры: {Type}");
        }
    }

    /// <summary>
    /// Класс для представления Линии
    /// </summary>
    class Line : FigureHelper
    {
        private int coordinateX1;
        private int coordinateX2;
        private int coordinateY1;
        private int coordinateY2;

        public Line (int X1, int Y1, int X2, int Y2)
        {
            Type = "Линия";
            coordinateX1 = X1;
            coordinateY1 = Y1;
            coordinateX2 = X2;
            coordinateY2 = Y2;
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Начало линии: ({coordinateX1}, {coordinateY1}), Конец линиии: ({coordinateX2}, {coordinateY2})");
        }

    }

    /// <summary>
    /// Класс для представления окружности
    /// </summary>
    class Circle : FigureHelper
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

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Координаты X и Y (центр): ({crX}, {crY}), Радиус: {radius}");
        }
    }

    /// <summary>
    /// Класс для представления прямоугольника
    /// </summary>
    class Rectangle : FigureHelper
    {
        private int Width;
        private int Height;

        public Rectangle (int width, int height)
        {
            Type = "Прямоугольник";
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Ширина прямоугольника: {Width}, Высота прямоугольника: {Height}");
        }
    }

    /// <summary>
    /// Класс для представления круга
    /// </summary>
    class Ellipse : FigureHelper
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

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Координаты X и Y (центр): ({crX}, {crY}), Большая полуось: {SemiMajorAxis}, Малая полуось: {SemiMinorAxis}");
        }
    }

    /// <summary>
    /// Класс для представления кольца
    /// </summary>
    class Ring : FigureHelper
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
            base.Draw();
            Console.WriteLine($"Координаты X и Y (центр): ({crX}, {crY}), Внутренний радиус: {inRadius}, Внешний радиус: {outRadius}");
        }
    }

    /// <summary>
    /// Класс для векторного графического редактора
    /// </summary>
    class VectorEditor
    {
        List<FigureHelper> figures = new List<FigureHelper>();

        /// <summary>
        /// Метод "Добавления" фигуры
        /// </summary>
        /// <param name="figure"></param>
        public void CreateFigure(FigureHelper figure)
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
