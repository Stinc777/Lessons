using Lessons2_task8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task8
{
    /// <summary>
    /// Базовый класс для игры
    /// </summary>
    internal class Game
    {
        public int WidthMap { get; set; } // Ширина карты
        public int HeightMap { get; set; } // Высота карты
        public int[] BonusItem { get; set; } // Местоположение бонусов
        public int[] RdmValueObstacles { get; set; } // Местоположение препятствий
    }

}

    /// <summary>
    /// Класс Карты игры
    /// </summary>
    class Map : Game
{
        private Random random;

        public Map(int x, int y)
        {
            WidthMap = x;
            HeightMap = y;
            random = new Random(); // Создаем генератор случайных чисел
    }

        public void MapBonus()
        {
            
            int prcnt_item = ((WidthMap * HeightMap) / 100) * 20; //Бонусы на карте будут в количестве 20 процентов.
            int value;
            BonusItem = new int[prcnt_item];

            for (int i = 0; i < prcnt_item; i++)
            {
                value = random.Next(1, (WidthMap * HeightMap));
                BonusItem[i] += value;
            }

            Bonus bonus = new Bonus(BonusItem);

        }

        public void MapObstacles()
        {
            
            int obstacles = ((WidthMap * HeightMap) / 100) * 10; // Препятствия на карте будут в количестве 10 процентов.
            int value;
            RdmValueObstacles = new int[obstacles];

            for (int i = 0; i < obstacles; i++)
            {
                do
                {
                    value = random.Next(1, (WidthMap * HeightMap));
            } while (Array.IndexOf(BonusItem, value) == -1); // Проверяем, не содержится ли это значение в массиве бонусов

                RdmValueObstacles[i] = value;
            }

            Obstacle obstacle = new Obstacle(RdmValueObstacles);

        }
    }

    /// <summary>
    /// Базовый класс для игровых объектов
    /// </summary>
    class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    /// <summary>
    /// Класс игрока
    /// </summary>
    class Player : GameObject
    {
        public int Health { get; set; }
        public int Score { get; set; }

        public void Move(int deltaX, int deltaY)
        {
            // Реализация движения игрока
        }

        public void CollectBonus(Bonus bonus)
        {
            // Реализация подбора бонусов
        }
    }

    /// <summary>
    /// Класс монстра
    /// </summary>
    class Monster : GameObject
    {
        public int Damage { get; set; }

        public void MoveTowardsPlayer(Player player)
        {
            // Реализация движения монстра к игроку
        }
    }

    /// <summary>
    /// Класс бонуса
    /// </summary>
    class Bonus : Game
    {
        public string Type { get; set; }

        private int[] bonusItems;

        public Bonus(int[] bonusItems)
        {
            this.bonusItems = bonusItems;
        }

        public void ApplyToPlayer(Player player)
        {
            // Используйте bonusItems для взаимодействия с бонусами
        }
    }

    /// <summary>
    /// Класс препятствия
    /// </summary>
    class Obstacle : Game
    {
        public string Type { get; set; }

        private int[] obstacleItems;

        public Obstacle(int[] obstacleItems)
        {
            this.obstacleItems = obstacleItems;
        }
    }

