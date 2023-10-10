using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task7
{
    // Базовый класс для всех фигур
    internal class FigureHelper
    {
        public string Type { get; protected set; }

        public virtual void Draw()
        {
            Console.WriteLine($"Тип фигуры: {Type}");
        }
    }

    // Класс для представления Линии
    class Line : FigureHelper
    {
        public int coordinateX1;
        public int coordinateX2;
        public int coordinateY1;
        public int coordinateY2;

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

    // Класс для представления окружности
    class Circle : FigureHelper
    {
        public int crX;
        public int crY;
        public int radius;

        //почему то не работает без void
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

    // Класс для представления прямоугольника
    class Rectangle : FigureHelper
    {
        public int Width;
        public int Height;

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

    // Класс для представления круга
    class Ellipse : FigureHelper
    {
        public int crX;
        public int crY;
        public int SemiMajorAxis;
        public int SemiMinorAxis;

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

    // Класс для представления кольца
    class Ring : FigureHelper
    {
        public int crX;
        public int crY;
        public int inRadius;
        public int outRadius;

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

    // Класс для векторного графического редактора
    class VectorEditor
    {
        List<FigureHelper> figures = new List<FigureHelper>();

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
