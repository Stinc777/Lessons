using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*
Написать программу, которая определяет площадь прямоугольника со сторонами a и b. Если
пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться
сообщение об ошибке. Возможность ввода пользователем строки вида «абвгд» или нецелых чисел
игнорировать.
*/



namespace Lessons1_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            string str;
            int side_a, side_b;

            Console.WriteLine("Введите сторону A прямоугольника:");
            str = Console.ReadLine();
            if (!(int.TryParse(str,out side_a)))
            {
                Console.WriteLine("Вы ввели неккоректные данные");
            }
            else 
            {
                Console.WriteLine("Введите сторону B прямоугольника:");
                str = Console.ReadLine();
                if (!(int.TryParse(str, out side_b)))
                {
                    Console.WriteLine("Вы ввели неккоректные данные");
                }
                else
                {
                    Console.WriteLine("Площадь прямоугольника равна : " + Square(side_a, side_b));
                }
            }

            Console.ReadKey();

        }

        static int Square (int a, int b)
        {
            return a * b;
        }

    }
}

/* 2 вариант 

namespace Lessons1_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            int side_a, side_b;

            side_a = ReadSide("A");
            side_b = ReadSide("B");

            Console.WriteLine("Площадь прямоугольника равна : " + Square(side_a, side_b));

            Console.ReadKey();
        }

        static int ReadSide(string sideName)
        {
            int side;

            while (true)
            {
                Console.WriteLine($"Введите сторону {sideName} прямоугольника:");
                if (int.TryParse(Console.ReadLine(), out side) && side > 0)
                {
                    return side;
                }
                else
                {
                    Console.WriteLine("Вы ввели некорректные данные");
                }
            }
        }

        static int Square(int a, int b)
        {
            return a * b;
        }
    }
}
*/