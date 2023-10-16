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

        /// <summary>
        /// Операция конкатенации
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public MyString Concatenate(MyString str)
        {
            //Создается новый массив символов result, который будет использован для хранения символов конкатенированной строки.
            //Размер этого массива равен сумме длин символов текущей строки (characters) и строки str, с которой происходит конкатенация.
            char[] result = new char[characters.Length + str.Length]; 
            Array.Copy(characters, result, characters.Length);
            Array.Copy(str.characters, 0, result, characters.Length, str.Length);
            return new MyString(new string(result));
        }

        /// <summary>
        /// Операция сравнения
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Операция поиска символа
        /// </summary>
        /// <param name="searchChar"></param>
        /// <returns></returns>
        public int IndexOf(char searchChar)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == searchChar)
                    return i;
            }
            return -1; // Если символ не найден
        }

        /// <summary>
        /// Конвертация в массив символов
        /// </summary>
        /// <returns></returns>
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
