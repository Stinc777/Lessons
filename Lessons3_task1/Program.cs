using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

/*
 * В кругу стоят N человек, пронумерованных от 1 до N. 
 * При ведении счета по кругу вычёркивается каждый второй человек, пока не останется один. 
 * Составить программу, моделирующую процесс.
 */
namespace Lessons3_task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Введите количество людей, находящихся в круге");

            string str = Console.ReadLine();

            int userValue;

            bool result = int.TryParse(str, out userValue);

            while (!result || userValue == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Вы ввели неккоректные данные, людей должно быть больше 0");
                Console.WriteLine("Попробуйте снова");

                str = Console.ReadLine();
                result = int.TryParse(str, out userValue);
            }

            Human myHuman = new Human(userValue);

            int count = myHuman.HumanCounting(myHuman.HumanQuanity);

            Console.WriteLine(count);

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
