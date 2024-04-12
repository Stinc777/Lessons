using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Разработать консольное приложение, которое выводит на экран (в виде таблицы) отличия в параметрах культур:
    "ru" vs "en"
    "en" vs "invariant"
    "ru" vs "invariant"

    Необходимо вывести на экране отличия в:

    формате отображения даты и времени,
    формате отображения числовых данных (разделитель дробной и целой части, разделитель групп разрядов и т.п.)
    NOTE: Целесообразно реализовать отдельный метод, который принимает на входе объекты CultureInfo и выводит отличия на экран. 
    Повторно использовать этот метод (Code Reuse) для вывода различных пар культур.
 */
namespace Lessons1_task13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Приложение выводит на экран в виде таблицы отличия в параметрах культур");
            Console.WriteLine();

            CompareCultures(CultureInfo.InvariantCulture, new CultureInfo("ru-RU", false), "invariant vs ru");
            CompareCultures(CultureInfo.InvariantCulture, new CultureInfo("en-US", false), "invariant vs en");
            CompareCultures(new CultureInfo("ru-RU", false), new CultureInfo("en-US", false), "ru vs en");

            Console.ReadLine();

        }

        static void CompareCultures(CultureInfo culture1, CultureInfo culture2, string title)
        {
            Console.WriteLine($"Отличия в параметрах культур: {title}");
            Console.WriteLine();

            // Отличия в формате отображения даты и времени
            Console.WriteLine($"Формат даты и времени: {DateTime.Now.ToString(culture1.DateTimeFormat)} vs {DateTime.Now.ToString(culture2.DateTimeFormat)}");

            // Отличия в формате отображения числовых данных
            Console.WriteLine($"Формат числовых данных: {1.35343.ToString(culture1.NumberFormat)} vs {1.35343.ToString(culture2.NumberFormat)}");

            Console.WriteLine();
        }

    }
}
