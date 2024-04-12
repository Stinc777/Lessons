using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Lessons2_task4
{
    class MyString
    {
        private char[] characters;

        /// <summary>
        /// Конструктор без параметров – «пустая строка».
        /// </summary>
        public MyString()
        {
            characters = new char[0];
        }

        /// <summary>
        /// Конструктор, принимающий один параметр типа string – создание «строки» из «строки».
        /// </summary>
        public MyString(string str)
        {
            characters = str.ToCharArray();
        }

        /// <summary>
        /// Конструктор, принимающий один параметр типа char[] – создание «строки» из массива символов.
        /// </summary>
        public MyString(char[] chars)
        {
            characters = chars;
        }

        /// <summary>
        /// Перегрузка оператора ‘+’ – добавляет строку в конец текущей.
        /// </summary>
        public static MyString operator +(MyString str1, MyString str2)
        {
            char[] result = new char[str1.characters.Length + str2.characters.Length];
            Array.Copy(str1.characters, result, str1.characters.Length);
            Array.Copy(str2.characters, 0, result, str1.characters.Length, str2.characters.Length);
            return new MyString(result);
        }

        /// <summary>
        /// Перегрузка оператора ‘-’ – удаляет подстроку из текущей строки (только первое вхождение).
        /// </summary>
        public static MyString operator -(MyString str1, MyString str2)
        {
            string s1 = new string(str1.characters);
            string s2 = new string(str2.characters);
            int index = s1.IndexOf(s2);
            if (index != -1)
            {
                s1 = s1.Remove(index, s2.Length);
            }
            return new MyString(s1);
        }

        /// <summary>
        /// Перегрузка оператора ‘==’ – сравнивает два объекта MyString.
        /// </summary>
        public static bool operator ==(MyString str1, MyString str2)
        {
            return new string(str1.characters) == new string(str2.characters);
        }
        
        public static bool operator !=(MyString str1, MyString str2)
        {
            return !(str1 == str2);
        }

        /// <summary>
        /// Метод ToString для получения представления объекта MyString в виде объекта стандартного string.
        /// </summary>
        public override string ToString()
        {
            return new string(characters);
        }
    }
}
