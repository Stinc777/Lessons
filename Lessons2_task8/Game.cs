using Lessons2_task8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Lessons2_task8.Game;

namespace Lessons2_task8
{
    /// <summary>
    /// Базовый класс для игры
    /// </summary>
    public class Game
    {
        Map map;
        private Random random;
        public Point PlauerPosition { get; set; }
        private Player player;

        public int WidthMap => map.Width;
        public int HeightMap => map.Height;

        public Dictionary<Point, ItemType> GetPointsMap()
        {
            Dictionary<Point, ItemType> points = new Dictionary<Point, ItemType>();

            List<ItemGame> items = new List<ItemGame>();

            foreach(var item in map.ItemGames)
            {
                items.Add(item);
            }

            for (int i = 0; i < items.Count-1; i++)
            {
                for (int j = i+1; j < items.Count;  j++)
                {
                    if (items[i].Point == items[j].Point)
                    {
                        if (items[i].Type == ItemType.MonsterType)
                        {
                            items.Remove(items[j]);
                        }
                        else
                        {
                            items.Remove(items[i]);
                        }
                        
                        if (i > 0)
                        {
                            i--;
                        }
                        
                        if(j > 0)
                        {
                            j--;
                        }
                    }
                }
            }


            foreach (var item in items)
            {
                points.Add(item.Point, item.Type);
            }

            return points;
        }

        public Game(int width, int height)
        {
            map = new Map(width, height); // Создание объекта карты*/
            random = new Random();
            GeneratingItems();
        }

        public void MoveUpPlayer ()
        {
            MoveUp(player);
            MoveMonsters();
        }

        public void MoveDownPlayer()
        {
            MoveDown(player);
            MoveMonsters();
        }
        public void MoveRightPlayer()
        {
            MoveRight(player);
            MoveMonsters();
        }
        public void MoveLeftPlayer()
        {
            MoveLeft(player);
            MoveMonsters();
        }

        /// <summary>
        /// Генерирует объекты (препятствия и бонусы) на карте.
        /// </summary>
        private void GeneratingItems()
        {
            GeneratingObjects(20, ItemType.BonusType);
            GeneratingObjects(10, ItemType.ObstacleType);
            GeneratingObjects(0, ItemType.MonsterType);
            SpawnPlayer();
        }

        /// <summary>
        /// Генерирует объекты на карте.
        /// </summary>
        private void GeneratingObjects(int prcntObject, ItemType type)
        {
            Point pointObject;

            int quantity;

            if (type == ItemType.MonsterType)
            {
                quantity = totalMonsters();
            }
            else
            {
                double valueObject = (map.Height * map.Width) * prcntObject / 100; //Бонусы на карте будут в количестве 20 процентов.

                quantity = (int)Math.Round(valueObject);
            }

            for (int i = 0; i < quantity; i++)
            {

                pointObject.X = random.Next(0, map.Width);
                pointObject.Y = random.Next(0, map.Height);

                if (!ContainsCoordinate(map.ItemGames, pointObject))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    switch (type)
                    {
                        case ItemType.ObstacleType:
                            map.ItemGames.Add(new Obstacle(pointObject));
                            break;
                        case ItemType.BonusType:
                            map.ItemGames.Add(new Bonus(pointObject));
                            break;
                        case ItemType.MonsterType:
                            map.ItemGames.Add(new Monster(pointObject));
                            break;
                    }
                 
                }
                else i--;

            }
        }

        /// <summary>
        /// Генерирует игрока на карте.
        /// </summary>
        private void SpawnPlayer()
        {
            Point value = new Point();

            bool contains = true;
            while (contains)
            {
                value.X = random.Next(0, map.Width);
                value.Y = random.Next(0, map.Height);

                contains = ContainsCoordinate(map.ItemGames, value);

                if (!contains)    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    player = new Player(value);
                    map.ItemGames.Add(player);
                }
            }
        }

        private int totalMonsters ()
        {

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

            return numberOfMonsters;

        }

        /// <summary>
        /// Проверка содержания значений координат с другими объектами на карте.
        /// </summary>
        private bool ContainsCoordinate(List<ItemGame> items, Point newPoint)
        {
            foreach (var item in items)
            {
                if (item.Point == newPoint)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Перемещает юнита вверх.
        /// </summary>
        private void MoveUp(ItemGame item)
        {

            Point newPoint = item.Point;

            newPoint.Y++;

            if (CheckNewPoints(newPoint, item.Type))
            {
                item.Point = newPoint;
            }
        }

        /// <summary>
        /// Перемещает юнита вниз.
        /// </summary>
        private void MoveDown(ItemGame item)
        {
            Point newPoint = item.Point;

            newPoint.Y--;

            if (CheckNewPoints(newPoint, item.Type))
            {
                item.Point = newPoint;
            }
        }

        /// <summary>
        /// Перемещает юнита вправо.
        /// </summary>
        private void MoveRight(ItemGame item)
        {
            Point newPoint = item.Point;

            newPoint.X++;

            if (CheckNewPoints(newPoint, item.Type))
            {
                item.Point = newPoint;
            }
        }

        /// <summary>
        /// Перемещает юнита влево.
        /// </summary>
        private void MoveLeft(ItemGame item)
        {
            Point newPoint = item.Point;

            newPoint.X--;

            if (CheckNewPoints(newPoint, item.Type))
            {
                item.Point = newPoint;
            }
        }

        
        private bool CheckNewPoints(Point newPoint,  ItemType type)
        {
            if (CheckAbroadAndObstacles(newPoint))
            {
                if (type == ItemType.Player)
                    CheckBonusSelection(newPoint);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверка выхода за границы карты, а также наличие препятсвий и бонуса на новой позиции Игрока.
        /// </summary>
        private bool CheckAbroadAndObstacles(Point newPosition)
        {
            return map.IsInsideMap(newPosition) && !map.IsObstacle(newPosition);
        }

        /// <summary>
        /// Проверка наличия бонуса на новой позиции игрока.
        /// </summary>
        private void CheckBonusSelection (Point newPosition)
        {
            for (int i = 0; i < map.ItemGames.Count; i++)
            {
                if (map.ItemGames[i].Type == ItemType.BonusType)
                {
                    if (map.ItemGames[i].Point == newPosition)
                    {
                        map.ItemGames.Remove(map.ItemGames[i]);
                        i--;
                    }
                }
            }
        }

        /// <summary>
        /// Перемещение монстров.
        /// </summary>
        private void MoveMonsters()
        {
            foreach (var item in map.ItemGames)
            {

                if (item.Type == ItemType.MonsterType)
                {
                    // Если монстр видит игрока, используем метод Harassment
                    if (IsPlayerVisible(item.Point, player.Point))
                    {
                        Harassment(item);
                    }
                    else
                    {
                        RandomMoveMonster(item);
                    }
                }
            }
        }

        private void RandomMoveMonster (ItemGame monster)
        {
            // Генерируем случайное число от 0 до 3, которое представляет одно из четырех направлений:              
            int randomDirection = random.Next(4);
            // В зависимости от сгенерированного случайного направления, обновляем новую позицию монстра
            switch (randomDirection)
            {
                case 0: // Двигаемся влево
                    MoveLeft(monster);
                    break;
                case 1: // Двигаемся вправо
                    MoveRight(monster);
                    break;
                case 2: // Двигаемся вверх
                    MoveUp(monster);
                    break;
                case 3: // Двигаемся вниз
                    MoveDown(monster);
                    break;
            }
        }

        /// <summary>
        /// Проверка, видит ли монстр игрока.
        /// </summary>
        /// <param name="monsterPosition"></param>
        /// <param name="PlayerPosition"></param>
        /// <returns></returns>
        private bool IsPlayerVisible(Point monsterPosition, Point PlayerPosition)
        {
            // Проверяем, находится ли игрок на одной линии по горизонтали или вертикали с монстром
            if (monsterPosition.X == PlayerPosition.X)
            {
                int distance = Math.Abs(monsterPosition.Y - PlayerPosition.Y);
                return distance < 3; 
            }
            else if (monsterPosition.Y == PlayerPosition.Y)
            {
                int distance = Math.Abs(monsterPosition.X - PlayerPosition.X);
                return distance < 3;
            }
            return false;
        }

        /// <summary>
        /// Преследование игрока.
        /// </summary>
        /// <param name="monster"></param>
        private void Harassment(ItemGame monster)
        {
            Point monsterPosition = monster.Point;
            Point playerPosition = player.Point;

            // Вычисляем разницу между позициями монстра и игрока по горизонтали и вертикали
            int diffX = playerPosition.X - monsterPosition.X;
            int diffY = playerPosition.Y - monsterPosition.Y;

            // Передвигаем монстра ближе к игроку в направлении, в котором тот находится
            if (Math.Abs(diffX) < Math.Abs(diffY))
            {
                if (diffX > 0)
                {
                    MoveRight(monster);
                }
                else
                {
                    MoveLeft(monster);
                }
            }
            else
            {
                if (diffY > 0)
                {
                    MoveUp(monster);
                }
                else
                {
                    MoveDown(monster);
                }
            }
        }
    }

    /// <summary>
    /// Класс Map представляет карту игры.
    /// </summary>
    public class Map
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

        /// <summary>
        /// Проверка выхода за пределы карты
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsInsideMap(Point position)
        {
            return position.X >= 0 && position.X <= Width && position.Y >= 0 && position.Y <= Height;
        }

        /// <summary>
        /// Проверка сталкивания с препятствием
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsObstacle(Point position)
        {
            foreach (var item in ItemGames)
            {
                if (item.Type == ItemType.ObstacleType)
                {
                    if (item.Point.X == position.X && item.Point.Y == position.Y)
                        return true;
                }
            }
            return false;
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

        public static bool operator !=(Point pointA, Point pointB)
        {
            return (pointA.X != pointB.X || pointA.Y != pointB.Y);
        }

        public static bool operator ==(Point pointA, Point pointB)
        {
            return pointA.X == pointB.X && pointA.Y == pointB.Y;
        }
    }

    public class ItemGame
    {
        public Point Point { get; set; }
        internal ItemType _type;
        public ItemType Type => _type;
        public ItemGame(Point point, ItemType type)
        {
            Point = point;
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






