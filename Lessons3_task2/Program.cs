using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/*
 * Задан английский текст. Выделить отдельные слова и для каждого посчитать частоту встречаемости. 
 * Слова, отличающиеся регистром, считать одинаковыми. В качестве разделителей считать пробел и точку.
 */

namespace Lessons3_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введите текст на английском");

            string strText = Console.ReadLine();

            List<string> strWords = new List<string>();

            int quanityWords = 0;
            bool statusWord = true;

            while (statusWord)
            {
                Console.WriteLine("Введите слова, которые могут встретиться в тексте, для их подсчёта");
                Console.WriteLine("Для завершения, отправьте любую цифру");

                string word = Console.ReadLine();
                int check;              

                if ((int.TryParse(word, out check)))
                {
                    statusWord = false;
                }
                else if (!string.IsNullOrEmpty(word))
                {
                    strWords.Add(word);
                }
                else
                {
                    Console.WriteLine("Вы ввели неккоректные данные, попробуйте ещё раз");
                    Console.WriteLine();
                }
            }

            for (int i = 0; i < strWords.Count; i++)
            {
                quanityWords = WordsCounting(strText, strWords[i]);

                Console.WriteLine($"Слово: {strWords[i]} встречается {quanityWords} раз");

                quanityWords = 0;
            }

            Console.ReadKey();

            Console.WriteLine();

        }
        
        static int WordsCounting(string text, string word)
        {
            int count = 0;
            int index = 0;
            
            while ((index = text.IndexOf(word,index, StringComparison.OrdinalIgnoreCase))!= -1)
            {
                count++;
                index += word.Length;
            }

            return count;

        }
    }
}
