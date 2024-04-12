using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/*
 * Напишите программу, которая определяет, сколько раз в тексте встречается время. Необходимо учесть, что в сутках только 24 часа, а в часе – 60 минут.
 */
namespace Lessons1_task17
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            double elapsedTimeMilliseconds;

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine(@"Программа, которая будет анализировать текст на наличие ""времени"" и выводить их на экран.");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Введите текст:");

                string str = Console.ReadLine();

                stopWatch.Restart();

                DateTime result;
                if (DateTime.TryParse(str, out result))
                {
                    Console.WriteLine($"Найденное время: {result.Hour}:{result.Minute}");
                }
                else
                {
                    Console.WriteLine("В тексте не найдено время.");
                }

                stopWatch.Stop();
                ts = stopWatch.Elapsed;
                elapsedTimeMilliseconds = ts.TotalSeconds;
                Console.WriteLine();
                Console.WriteLine("Время: " + elapsedTimeMilliseconds + " ms");

            }
        }
    }
}

//string pattern = @"(?:[01]?[0-9]|2[0-3]):[0-5][0-9]";

//// Применяем регулярное выражение к тексту
//MatchCollection matches = Regex.Matches(strhtml, pattern);

//// Выводим найденное время на экран
//Console.WriteLine();
//Console.WriteLine("Время в тексте присутствует:");

//int cnt = 0;

//foreach (Match match in matches)
//{
//    cnt++;
//}
//Console.WriteLine("Время в тексте присутствует:");
//foreach (Match match in matches)
//{
//    Console.WriteLine(match.Value);
//}