using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать программу, которая определяет среднюю длину слова во введённой текстовой строке.
 * Учесть, что символы пунктуации на длину слов влиять не должны. Регулярные выражения не
 * использовать. И не пытайтесь прописать все символы-разделители ручками. Используйте
 * стандартные методы классов String и Char.
 */

namespace Lessons1_task11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Эта программа определяет среднюю длину слова во введённой текстовой строке.");

            while (true)
            {
                Console.WriteLine("Введите строку:");
                string str = Console.ReadLine();

                StringHelper.AverageWordLength(str);

                Console.WriteLine();
            }
        }
    }
}
