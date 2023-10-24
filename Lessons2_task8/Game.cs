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

        Map map;
        private Random random;

        public Game(int width, int height)
        {

            map = new Map(width, height); // Создание объекта карты*/
            random = new Random();
            GeneratingItems();
        }

        /// <summary>
        /// Генерирует объекты (препятствия и бонусы) на карте.
        /// </summary>
        private void GeneratingItems()
        {
            GeneratingObstacle();
            GeneratingBonuses();
            SpawnMonsters();
            SpawnPlayer();
        }

        /// <summary>
        /// Генерирует препятствия на карте.
        /// </summary>
        private void GeneratingObstacle()
        {
            Point value;

            double prcntItem = (map.Height * map.Width) * 10 / 100; //Препятствия на карте будут в количестве 10 процентов.

            int quantity = (int)Math.Round(prcntItem);

            List<Point> points = new List<Point>();

            foreach (var item in map.ItemGames)
            {
                points.Add(item.Point);
            }

            for (int i = 0; i < quantity; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(points.ToArray(), value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    map.ItemGames.Add(new Obstacle(value));
                    points.Add(value);
                }
                else i--;

            }
        }

        private void GeneratingBonuses()
        {
            Point value;

            double prcntItem = (map.Height * map.Width) * 20 / 100; //Бонусы на карте будут в количестве 20 процентов.

            int quantity = (int)Math.Round(prcntItem);

            List<Point> points = new List<Point>();

            foreach (var item in map.ItemGames)
            {
                points.Add(item.Point);
            }

            for (int i = 0; i < quantity; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(points.ToArray(), value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    map.ItemGames.Add(new Bonus(value));
                    points.Add(value);
                }
                else i--;

            }
        }

        private void SpawnPlayer()
        {
            Point value;

            List<Point> points = new List<Point>();

            foreach (var item in map.ItemGames)
            {
                points.Add(item.Point);
            }

            for (int i = 0; i < 1; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(points.ToArray(), value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    map.ItemGames.Add(new Player(value));
                    points.Add(value);
                }
                else i--;

            }
        }

        private void SpawnMonsters()
        {
            Point value;

            // Вычисляем количество монстров в зависимости от размера карты
            int numberOfMonsters = 0;

            int totalTiles = map.Width * map.Height;
            if (totalTiles < 25)
            {
                numberOfMonsters = 1;
            }
            else if (totalTiles < 50)
            {
                numberOfMonsters = 2;
            }
            else if (totalTiles < 75)
            {
                numberOfMonsters = 3;
            }
            else if (totalTiles < 100)
            {
                numberOfMonsters = 4;
            }
            else
            {
                numberOfMonsters = 5;
            }

            List<Point> points = new List<Point>();

            foreach (var item in map.ItemGames)
            {
                points.Add(item.Point);
            }

            for (int i = 0; i < numberOfMonsters; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(points.ToArray(), value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    map.ItemGames.Add(new Monster(value));
                    points.Add(value);
                }
                else i--;

            }
        }


        private bool ContainsCoordinate(Point[] points, Point newPoint)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X == newPoint.X && points[i].Y == newPoint.Y)
                {
                    return true; // Координата уже существует в массиве
                }
            }
            return false; // Координата не существует в массиве
        }

    }

    /// <summary>
    /// Класс Map представляет карту игры.
    /// </summary>
    class Map
    {

        private int _width;
        private int _height;
        public int Width => _width;
        public int Height => _height;

        public List<ItemGame> ItemGames;

        public Map(int width, int height)
        {
            _width = width;
            _height = height;
            ItemGames = new List<ItemGame>();
        }

    }

    public enum ItemType
    {
        ObstacleType,
        BonusType,
        MonsterType,
        Player
    }

    public struct Point
    {
        public int X, Y;
    }

    public class ItemGame
    {
        internal Point _point;
        public Point Point => _point;
        internal ItemType _type;
        public ItemType Type => _type;
        public ItemGame(Point point, ItemType type)
        {
            _point = point;
            _type = type;
        }
    }

    public class Obstacle : ItemGame
    {

        public Obstacle(Point point) : base(point, ItemType.ObstacleType)
        {

        }
    }

    public class Bonus : ItemGame
    {
        public Bonus(Point point) : base(point, ItemType.BonusType)
        {

        }
    }

    public class Unit : ItemGame
    {
        public Unit(Point point, ItemType type) : base(point, type)
        {

        }
    }

    public class Player : Unit
    {
        public Player(Point point) : base(point, ItemType.Player)
        {

        }
    }

    public class Monster : Unit
    {
        public Monster(Point point) : base(point, ItemType.MonsterType)
        {

        }
    }
}






