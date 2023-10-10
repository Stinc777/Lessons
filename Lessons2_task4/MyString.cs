using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lessons2_task4
{
    class MyString
    {
        private char[] characters;

        public MyString(string str)
        {
            characters = str.ToCharArray();
        }

        public int Length
        {
            get { return characters.Length; }
        }

        // Операция конкатенации
        public MyString Concatenate(MyString str)
        {
            char[] result = new char[characters.Length + str.Length];
            Array.Copy(characters, result, characters.Length);
            Array.Copy(str.characters, 0, result, characters.Length, str.Length);
            return new MyString(new string(result));
        }

        // Операция сравнения
        public bool Equals(MyString str)
        {
            if (characters.Length != str.Length)
                return false;

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] != str.characters[i])
                    return false;
            }

            return true;
        }

        // Операция поиска символа
        public int IndexOf(char searchChar)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == searchChar)
                    return i;
            }
            return -1; // Если символ не найден
        }

        // Конвертация в массив символов
        public char[] ToCharArray()
        {
            return characters;
        }

        // Конвертация из массива символов
        public static MyString FromCharArray(char[] charArray)
        {
            return new MyString(new string(charArray));
        }
    }
}
