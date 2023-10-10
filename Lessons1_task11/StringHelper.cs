using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons1_task11
{
    internal class StringHelper
    {
        public static void AverageWordLength(string str)
        {
            int wordCount = 0;
            int totalLength = 0;
            bool inWord = false;

            foreach (char c in str)
            {
                if (Char.IsLetter(c))
                {
                    if (!inWord)
                    {
                        inWord = true;
                        wordCount++;
                    }
                    totalLength++;
                }
                else
                {
                    inWord = false;
                }
            }

            if (wordCount == 0)
            {
                Console.WriteLine("Введенная строка не содержит слов.");
            }
            else
            {
                double averageLength = (double)totalLength / wordCount;
                Console.WriteLine($"Средняя длина слова: {averageLength:F2}");
            }
        }
    }
}
