using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task8
{
    // Базовый класс для игры
    internal class Game
    {
        public int width;
        public int height;
        public int[] bonus_item;
        public int[] rdm_value_obstacles;
    }

    // Класс Карты игры
    class Map : Game
    {

        public Map(int x, int y)
        {
            width = x;
            height = y;
        }

        public void MapBonus()
        {
            Random random = new Random(); // Создаем генератор случайных чисел

            int prcnt_item = ((width * height) / 100) * 20; //Бонусы на карте будут в количестве 20 процентов.
            int value;
            bonus_item = new int[prcnt_item];

            for (int i = 0; i < prcnt_item; i++)
            {
                value = random.Next(0, (width * height));
                bonus_item[i] += value;
            }

            Bonus bonus = new Bonus(bonus_item);

        }

        public void MapObstacles()
        {
            Random randomObstacles = new Random(); // Создаем генератор случайных чисел для препятствий

            int obstacles = ((width * height) / 100) * 10; // Препятствия на карте будут в количестве 10 процентов.
            int value;
            rdm_value_obstacles = new int[obstacles];

            for (int i = 0; i < obstacles; i++)
            {
                do
                {
                    value = randomObstacles.Next(0, (width * height));
                } while (Array.IndexOf(bonus_item, value) == -1); // Проверяем, не содержится ли это значение в массиве бонусов

                rdm_value_obstacles[i] = value;
            }

            Obstacle obstacle = new Obstacle(rdm_value_obstacles);

        }
    }

    // Базовый класс для игровых объектов
    class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Класс игрока
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

    // Класс монстра
    class Monster : GameObject
    {
        public int Damage { get; set; }

        public void MoveTowardsPlayer(Player player)
        {
            // Реализация движения монстра к игроку
        }
    }

    // Класс бонуса
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

    // Класс препятствия
    class Obstacle : GameObject
    {
        public string Type { get; set; }

        private int[] obstacleItems;

        public Obstacle(int[] obstacleItems)
        {
            this.obstacleItems = obstacleItems;
        }
    }


}
