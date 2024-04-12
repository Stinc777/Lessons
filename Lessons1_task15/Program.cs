using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

/*
 * Напишите программу, которая заменяет все найденные в тексте HTML теги на знак “_”.
 */

namespace Lessons1_task15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Программа, которая будет искать палиндромы в введенном тексте.");
            Console.WriteLine();
            Console.WriteLine("Введите текст:");

            string input = Console.ReadLine();

            // Получаем все слова из введенного текста
            string[] words = Regex.Split(input, @"\W+");

            List<string> palindromes = new List<string>();

            // Проверяем каждое слово на палиндром
            foreach (string word in words)
            {
                if (IsPalindrome(word))
                {
                    palindromes.Add(word);
                }
            }

            // Выводим найденные палиндромы
            if (palindromes.Count > 0)
            {
                Console.WriteLine("Найденные палиндромы:");
                foreach (string palindrome in palindromes)
                {
                    Console.WriteLine(palindrome);
                }
            }
            else
            {
                Console.WriteLine("В введенном тексте не найдено палиндромов.");
            }

            Console.ReadLine();
        }

        // Метод для проверки строки на палиндромность
        static bool IsPalindrome(string str)
        {
            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                if (char.ToLower(str[left]) != char.ToLower(str[right]))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}

/*
           static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Программа, которая заменяет все найденные в тексте HTML теги на знак “_”.");
            Console.WriteLine();

            Console.WriteLine("Введите HTML текст:");

            string pattern = @"<[^>]+>";
            string target = "_";

            string strhtml = Console.ReadLine();

            Regex regStr = new Regex(pattern);

            string result = regStr.Replace(strhtml, target);

            Console.WriteLine();

            Console.WriteLine("Результат замены: " + result);  // 18762341298

            Console.ReadLine();
        }
 */

//static void Main(string[] args)
//{
//    System.Console.OutputEncoding = System.Text.Encoding.UTF8;

//    Console.WriteLine("Программа, которая заменяет все найденные в тексте знаки препинания теги на знак “_”.");
//    Console.WriteLine();

//    Console.WriteLine("Введите текст:");

//    string pattern = @"[.,!?;:-]";
//    string target = "_";

//    string strhtml = Console.ReadLine();

//    Regex regStr = new Regex(pattern);

//    string result = regStr.Replace(strhtml, target);

//    Console.WriteLine();

//    Console.WriteLine("Результат замены: " + result);

//    Console.ReadLine();
//}

//static void Main(string[] args)
//{
//    System.Console.OutputEncoding = System.Text.Encoding.UTF8;

//    Console.WriteLine("Программа, которая будет анализировать текст на наличие email адресов и выводить их на экран.");
//    Console.WriteLine();

//    Console.WriteLine("Введите текст:");

//    string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

//    string strhtml = Console.ReadLine();

//    // Применяем регулярное выражение к тексту
//    MatchCollection matches = Regex.Matches(strhtml, pattern);

//    // Выводим найденные адреса на экран
//    Console.WriteLine("Найденные email адреса:");
//    foreach (Match match in matches)
//    {
//        Console.WriteLine(match.Value);
//    }

//    Console.ReadLine();
//}