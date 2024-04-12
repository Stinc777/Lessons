using Lessons2_task4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Написать свой собственный класс MyString, описывающий строку как массив символов.

Класс должен содержать:

1. Конструктор без параметров – «пустая строка».

2. Конструктор, принимающий один параметр типа string – создание «строки» из «строки».

3. Конструктор, принимающий один параметр типа char[] – создание «строки» из массива символов.

4. Перегруженные операторы:
‘+’ – добавляет строку в конец текущей;
‘-’ – удаляет подстроку из текущей строки (только первое вхождение);
‘==’ – сравнивает два объекта MyString.
Метод ToString для получения представления объекта MyString в виде объекта стандартного string.

Требования
1) Обеспечить нахождение объектов класса MyString в заведомо корректном состоянии.
2) Продемонстрировать использование класса MyString в консольном приложении.
3) Продемонстрировать использование объекта класса MyString в проверке на null.
 */

namespace Lessons2_task4_1
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

            MyString concatenated = str1 + str2;
            Console.WriteLine(concatenated.ToString()); // Выводит "HelloWorld"

            MyString substr = new MyString("World");
            MyString result = concatenated - substr;
            Console.WriteLine(result.ToString()); // Выводит "Hello"

            Console.WriteLine(str1 == str2); // Выводит "False"

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
