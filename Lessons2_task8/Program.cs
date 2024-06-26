﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Создайте иерархию классов и пропишите ключевые методы для компьютерной игры (без
реализации функционала). Суть игры:
• Игрок может передвигаться по прямоугольному полю размером Width на Height;
• На поле располагаются бонусы (яблоко, вишня и т.д.), которые игрок может подобрать для
поднятия каких-либо характеристик;
• За игроком охотятся монстры (волки, медведи и т.д.), которые могут передвигаться по
карте по какому-либо алгоритму;
• На поле располагаются препятствия разных типов (камни, деревья и т.д.), которые игрок и
монстры должны обходить.
Цель игры — собрать все бонусы и не быть «съеденным» монстрами.
*/

/*
 * Класс Game отвечает за саму игру:
 * 1. Генерация элементов
 * 2. Шаги персонажей
 * 
 * Класс Map отвечает за расположение элементов в самой игре
 * 1. Препятствия
 * 2. Бонусы
 * 3. Монстры
 * 4. Игрок
 * Должна быть созданна каждая из этих сущностей (классы)
 *  
 */
namespace Lessons2_task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Создаем экземпляр игры

            Game game = new Game(10, 10); //  10x10 - размер карты
            RenderingGame renderingGame = new RenderingGame(game);

            while (true)
            {
                Console.WriteLine(renderingGame.Rendering());

                ConsoleKeyInfo key;

                while (true)
                {
                    key = Console.ReadKey();

                    if (key.Key == ConsoleKey.LeftArrow 
                        || key.Key == ConsoleKey.RightArrow 
                        || key.Key == ConsoleKey.UpArrow
                        || key.Key == ConsoleKey.DownArrow)
                    {
                        break;
                    }
                }

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.MoveLeftPlayer();
                        break;
                    case ConsoleKey.RightArrow:
                        game.MoveRightPlayer();
                        break;
                    case ConsoleKey.UpArrow:
                        game.MoveUpPlayer();
                        break;
                    case ConsoleKey.DownArrow:
                        game.MoveDownPlayer();
                        break;
                }

                Console.Clear();

            }
        }
    }
}
