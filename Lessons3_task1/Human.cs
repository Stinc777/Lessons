using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons3_task1
{
    internal class Human
    {

        public int HumanQuanity { get; set; }

        public Human (int quanity)
        {
            HumanQuanity = quanity;
        }

        internal int HumanCounting (int value)
        {
            int[] people = new int[value];
            for (int i = 0; i < value; i++)
            {
                people[i] = i + 1;
            }

            int countHuman = value;
            int index = 0;

            while (countHuman > 1)
            {
                                                  // Ищем следующего живого человека
                int nextIndex = (index + 1) % value;
                while (people[nextIndex] == 0)
                {
                    nextIndex = (nextIndex + 1) % value;
                }

                                                 // Удаляем каждого второго человека, считаем по кругу
                people[nextIndex] = 0; 

                countHuman--;                    // уменьшаем количество людей
                index = (nextIndex + 1) % value; // переходим к следующему человеку
            }

            // Находим оставшегося последнего человека
            int lastPerson = Array.Find(people, p => p != 0);
            return lastPerson;
        }


    }
}
