using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать свой собственный класс MyString, описывающий строку как массив символов.
 * Реализовать для этого класса типовые операции (сравнение, конкатенация, поиск символов,
 * конвертация из/в массив символов, ...).
 */
namespace Lessons2_task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Данная программа создаёт класс MyString, описывающий строку как массив символов. И работает со строками");

            Console.WriteLine();
            Console.WriteLine("Введите первую строку");

            string userStr1 = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Введите вторую строку");

            string userStr2 = Console.ReadLine();

            MyString str1 = new MyString(userStr1);
            MyString str2 = new MyString(userStr2);

            MyString concatenated = str1.Concatenate(str2);
            Console.WriteLine("Объединение строк: " + concatenated);

            bool isEqual = str1.Equals(str2);
            Console.WriteLine("Сравнение срок: " + isEqual);

            MyString fromArray = MyString.FromCharArray(str1.ToCharArray());
            Console.WriteLine("Строку в символы: " + fromArray);

            Console.WriteLine();
            Console.WriteLine("Какой символ найти в первой строке?");

            string userChar = Console.ReadLine();

            while (userChar.Length > 1)
            {
                Console.WriteLine("Вы ввели больше одного символа. Попробуйте ещё раз:");
                userChar = Console.ReadLine();
            }

            Console.WriteLine("Поиск символа {0} в первой строке: {1}", userChar, str1.IndexOf(char.Parse(userChar)));

            Console.ReadKey();

            Console.WriteLine();
        }

        static bool CheckDigits(string str)
        {
            foreach (char c in str)
            {
                if (char.IsDigit(c) || char.IsPunctuation(c))
                    return true;
            }

            return false;
        }
    }
}

//Coment test
