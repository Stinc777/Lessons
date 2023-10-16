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
            string bonusLocations = string.Join(", ", gameMap.BonusItem);
            Console.WriteLine(bonusLocations);

            Console.WriteLine();

            Console.WriteLine("Местоположение препятствий:");
            string obstaclesLocations = string.Join(", ", gameMap.RdmValueObstacles);
            Console.WriteLine(obstaclesLocations);

            Console.WriteLine();

            Console.ReadKey();

            Console.WriteLine();
        }
    }
}
