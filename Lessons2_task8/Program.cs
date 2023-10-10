using System;
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
namespace Lessons2_task8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Создаем экземпляр игры
            Map gameMap = new Map(10, 10); //  10x10 - размер карты

            // Генерируем бонусы и препятствия
            gameMap.MapBonus();
            gameMap.MapObstacles();

            // Выводим массивы местоположения бонусов и препятствий
            Console.WriteLine("Местоположение бонусов:");
            foreach (int location in gameMap.bonus_item)
            {
                Console.WriteLine(location);
            }

            Console.WriteLine("Местоположение препятствий:");
            foreach (int location in gameMap.rdm_value_obstacles)
            {
                Console.WriteLine(location);
            }

            Console.ReadKey();

            Console.WriteLine();//22
        }
    }
}
