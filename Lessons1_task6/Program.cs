using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Для форматирования текста надписи можно использовать различные начертания: полужирное,
* курсивное и подчёркнутое, а также их сочетания. Предложите способ хранения информации о
* форматировании текста надписи и напишите программу, которая позволяет устанавливать и
 * изменять начертание:
 * 
 */
namespace Lessons1_task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count_bold = 0;
            int count_italic = 0;
            int count_underline = 0;

            Typeface selectedFormats = Typeface.None;
            var oldFormats = Typeface.None;

            while (true)
            {
                if (oldFormats != Typeface.None)
                {
                    if ((count_bold != 0) || (count_italic != 0) || (count_underline != 0))
                    Console.Write("Параметры надписи:" + oldFormats);
                    if (selectedFormats != Typeface.None)
                        Console.WriteLine(" " + selectedFormats);
                } 
                else
                {
                    Console.Write("Параметры надписи:" + selectedFormats);
                }
                
                Console.WriteLine();
                Console.WriteLine("Введите:");
                Console.WriteLine("       1:Bold");
                Console.WriteLine("       2:Italic");
                Console.WriteLine("       3:Underline");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= 3)
                    {
                        switch (choice)
                        {
                            case 1:
                                {
                                    count_bold++;
                                    if (count_bold == 1)
                                        Сhanging_the_font(ref selectedFormats, ref oldFormats, choice);
                                    else
                                    {
                                        choice = 0;
                                        Сhanging_the_font(ref selectedFormats, ref  oldFormats, choice);
                                        count_bold = 0;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    count_italic++;
                                    if (count_italic == 1)
                                        Сhanging_the_font(ref selectedFormats, ref oldFormats, choice);
                                    else
                                    {
                                        choice = 0;
                                        Сhanging_the_font(ref selectedFormats, ref oldFormats, choice);
                                        count_italic = 0;
                                    }
                                }
                                break;
                            case 3:
                                {
                                    count_underline++;
                                    if (count_underline == 1)
                                        Сhanging_the_font(ref selectedFormats, ref oldFormats, choice);
                                    else
                                    {
                                        choice = 0;
                                        Сhanging_the_font(ref selectedFormats, ref oldFormats, choice);
                                        count_underline = 0;
                                    }
                                }
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }
                }
            }

        }

        static void Сhanging_the_font(ref Typeface selectedFormats,ref Typeface oldFormats, int choice)
        {
            if (choice != 0)
            {
                oldFormats = selectedFormats;
            }

            selectedFormats = (Typeface)choice;

        }


    }
}


public enum Typeface
{
    None = 0,
    Bold = 1,
    Italic = 2,
    Underline = 3
}