using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Напишите заготовку для векторного графического редактора. Полная версия редактора должна позволять создавать и выводить на экран такие фигуры как: 
 * Линия, Окружность, Прямоугольник, Круг, Кольцо. Заготовка, для упрощения, должна представлять собой консольное приложение с функционалом
 * 
 * Короче всё то же самое, просто реализация другая
 */

namespace Lessons2_task7_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Векторный графический редактор");

            List<Figure> figures = new List<Figure>();

            while (true)
            {
                Console.WriteLine("Выберите тип фигуры (1 - Линия, 2 - Окружность, 3 - Прямоугольник):");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Console.WriteLine("Введите координаты начальной точки линии (x1 y1):");
                    string[] coords1 = Console.ReadLine().Split();
                    Console.WriteLine("Введите координаты конечной точки линии (x2 y2):");
                    string[] coords2 = Console.ReadLine().Split();

                    while (coords1.Length != 2 || coords2.Length != 2)
                    {
                        coords1[0] = "";
                        coords1[1] = "";
                        coords2[0] = "";
                        coords2[1] = "";

                        Console.WriteLine("Неверный формат ввода координат.");
                        Console.WriteLine("Введите координаты начальной точки линии (x1 y1):");
                        coords1 = Console.ReadLine().Split();
                        Console.WriteLine("Введите координаты конечной точки линии (x2 y2):");
                        coords2 = Console.ReadLine().Split();
                    }

                    try
                    {
                        int x1 = int.Parse(coords1[0]);
                        int y1 = int.Parse(coords1[1]);
                        int x2 = int.Parse(coords2[0]);
                        int y2 = int.Parse(coords2[1]);

                        figures.Add(new Line(x1, y1, x2, y2));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат ввода координат.");
                    }
                }
                else if (input == "2")
                {
                    Console.WriteLine("Введите координаты центра окружности и её радиус (x y r):");
                    string[] circleCoords = Console.ReadLine().Split();

                    while (circleCoords.Length != 3)
                    {
                        circleCoords[0] = "";
                        circleCoords[1] = "";
                        circleCoords[2] = "";
                        Console.WriteLine("Неверный формат ввода координат.");

                        Console.WriteLine("Введите координаты центра окружности и её радиус (x y r):");
                        circleCoords = Console.ReadLine().Split();
                    }

                    try
                    {
                        int x = int.Parse(circleCoords[0]);
                        int y = int.Parse(circleCoords[1]);
                        int radius = int.Parse(circleCoords[2]);

                        figures.Add(new Circle(x, y, radius));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат ввода координат.");
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine("Введите координаты прямоугольника, его ширину и высоту (width height):");
                    string[] rectangleCoords = Console.ReadLine().Split();

                    while (rectangleCoords.Length != 4)
                    {
                        rectangleCoords[0] = "";
                        rectangleCoords[1] = "";

                        Console.WriteLine("Неверный формат ввода координат.");
                        Console.WriteLine("Введите координаты прямоугольника, его ширину и высоту (width height):");
                        rectangleCoords = Console.ReadLine().Split(); 
                    }

                    try
                    {
                        int width = int.Parse(rectangleCoords[0]);
                        int height = int.Parse(rectangleCoords[1]);

                        figures.Add(new Rectangle(width, height));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Неверный формат ввода координат.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный выбор. Повторите попытку.");
                }

                Console.WriteLine("Хотите добавить ещё фигуру? (да/нет)");
                string answer = Console.ReadLine();

                if (answer.ToLower() != "да")
                    break;
            }

            Console.WriteLine("Отрисовка фигур:");
            foreach (Figure figure in figures)
            {
                figure.Draw();
                Console.WriteLine();
            }

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
