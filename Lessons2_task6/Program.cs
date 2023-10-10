using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создать класс Ring, описывающий кольцо, заданное координатами центра, внешним и внутренним
радиусами, а также свойствами, позволяющими узнать площадь кольца и суммарную длину
внешней и внутренней окружностей. Обеспечить нахождение класса в заведомо корректном
состоянии.*/

namespace Lessons2_task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Ring myRing = new Ring(3, 5, 3.0, 6.0);

            double area = myRing.Area;
            double circumference = myRing.TotalCircumference;

            Console.WriteLine($"Площадь кольца: {area:F5}");
            Console.WriteLine($"Суммарная длина окружностей: {circumference:F5}");

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
