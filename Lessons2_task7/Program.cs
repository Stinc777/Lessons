using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Напишите заготовку для векторного графического редактора. Полная версия редактора должна
позволять создавать и выводить на экран такие фигуры как линия, окружность, прямоугольник,
круг, кольцо. Заготовка, для упрощения, должна представлять собой консольное приложение со
следующим функционалом:
• Создать фигуру выбранного типа по произвольным координатам;
• Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения
параметров).*/

namespace Lessons2_task7
{
    internal class Program
    {
        static void Main()
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            VectorEditor editor = new VectorEditor();

            editor.CreateFigure(new Line(0, 0, 100, 100));
            editor.CreateFigure(new Circle(50, 50, 30));
            editor.CreateFigure(new Rectangle(10, 20));
            editor.CreateFigure(new Ellipse(80, 80, 20, 10));
            editor.CreateFigure(new Ring(60, 60, 15, 25));

            editor.DrawAllFigures();

            Console.ReadKey();

            Console.WriteLine();

        }
    }
}
