using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Напишите заготовку для векторного графического редактора. Полная версия редактора должна позволять создавать и выводить на экран такие фигуры как: 
 * Линия, Окружность, Прямоугольник, Круг, Кольцо. Заготовка, для упрощения, должна представлять собой консольное приложение с функционалом:
    1) Создать фигуру выбранного типа по произвольным координатам.
    2) Фигуры должны создаваться в общей коллекции (массиве)
    3) Вывести фигуры на экран (для каждой фигуры вывести на консоль её тип и значения параметров реализовать в методе Draw) с использованием переопределения метода Draw.
 * Требования:
1) Создать базовый класс Figure.
2) Добавить в класс Figure абстрактный метод Draw.
3) Создать классы фигур:
 * линия – Line;
 * окружность – Circle;
 * прямоугольник – Rectangle;
 * круг – Round;
 * кольцо – Ring.
4) Все фигуры должны прямо или косвенно наследовать класс Figure.
5) Переопределить метод Draw у фигур так, чтобы для каждой фигуры он выводил в консоль специфичную для данной фигуры информацию.
6) Продемонстрировать работу классов в консольном приложении: создать массив различных фигур, а затем в цикле «отрисовать» каждую фигуру с помощью метода Draw.
 */

namespace Lessons2_task7_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Векторный графический редактор");

            VectorEditor editor = new VectorEditor();

            editor.AddFigure(new Line(0, 0, 100, 100));
            editor.AddFigure(new Circle(50, 50, 30));
            editor.AddFigure(new Rectangle(10, 20));
            editor.AddFigure(new Round(80, 100, 50));
            editor.AddFigure(new Ring(60, 60, 15, 25));

            editor.DrawAllFigures();

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
