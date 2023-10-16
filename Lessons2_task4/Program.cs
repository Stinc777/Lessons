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

            MyString str1 = new MyString("Hello");
            MyString str2 = new MyString("World");

            MyString concatenated = str1.Concatenate(str2);
            Console.WriteLine("Объединение строк: " + new string(concatenated.ToCharArray()));

            bool isEqual = str1.Equals(str2);
            Console.WriteLine("Сравнение срок: " + isEqual);

            MyString fromArray = MyString.FromCharArray(str1.ToCharArray());
            Console.WriteLine("Строку в символы: " + new string(fromArray.ToCharArray()));

            int indexOfO = str1.IndexOf('o');
            Console.WriteLine("Поиск символа 'о' в первой строке: " + indexOfO);

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}

//Coment test
