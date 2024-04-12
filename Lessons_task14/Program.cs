using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Проведите сравнительный анализ скорости работы классов String и StringBuilder для операции сложения:
 * NOTE: для измерения скорости работы алгоритмов использовать класс Stopwatch.
    NOTE: время измерять в миллисекундах.
    NOTE: результатом работы алгоритмов должен быть объект типа String.
 */

namespace Lessons1_task14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Сравнительный анализ скорости работы классов String и StringBuilder.");

            string str = "";
            StringBuilder sb = new StringBuilder();
            int N = 100;
            Stopwatch stopWatch = new Stopwatch();
            TimeSpan ts;
            double elapsedTimeMilliseconds;

            stopWatch.Start();
            for (int i = 0; i < N; i++)
            {
                str += "*";
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTimeMilliseconds = ts.TotalMilliseconds;
            Console.WriteLine("String: " + elapsedTimeMilliseconds + " ms");

            stopWatch.Restart();
            for (int i = 0; i < N; i++)
            {
                sb.Append("*");
            }
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTimeMilliseconds = ts.TotalMilliseconds;
            Console.WriteLine("StringBuilder: " + elapsedTimeMilliseconds + " ms");

            Console.ReadLine();
        }
    }
}
