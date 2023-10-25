using Lessons2_task8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lessons2_task8.Game;

namespace Lessons2_task8
{
    /// <summary>
    /// Базовый класс для игры
    /// </summary>
    internal class Game
    {

        Map map;
        private Random random;
        public Point PlauerPosition { get; set; }

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

            for (int i = 0; i < quantity; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);


                if (!ContainsCoordinate(map.Obstacles, map.Bonuses, value))
                {
                    map.Obstacles.Add(new Obstacle(value));
                }
                else
                {
                    i--;
                }

            }
        }

        /// <summary>
        /// Генерирует бонусы на карте.
        /// </summary>
        private void GeneratingBonuses()
        {
            Point value;

            double prcntItem = (map.Height * map.Width) * 20 / 100; //Бонусы на карте будут в количестве 20 процентов.

            int quantity = (int)Math.Round(prcntItem);       

            for (int i = 0; i < quantity; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(map.Obstacles, map.Bonuses, value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    map.Bonuses.Add(new Bonus(value));

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

            for (int i = 0; i < 1; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(map.Obstacles, map.Bonuses, value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    PlauerPosition = value;
                }
                else i--;

            }

        }

        /// <summary>
        /// Генерирует монстров на карте.
        /// </summary>
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

            for (int i = 0; i < numberOfMonsters; i++)
            {

                value.X = random.Next(1, map.Width);
                value.Y = random.Next(1, map.Height);

                if (!ContainsCoordinate(map.Obstacles, map.Bonuses, value))    // Проверяем, не содержится ли это значение в массиве объектов на карте
                {
                    map.Monsters.Add(new Monster(value));
                }
                else i--;

            }
        }

        /// <summary>
        /// Проверка содержания значений координат с другими объектами на карте.
        /// </summary>
        private bool ContainsCoordinate(List<Obstacle> obstacles, List<Bonus> bonuses, Point newPoint)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.Point.X == newPoint.X && obstacle.Point.Y == newPoint.Y)
                {
                    return true; // Координата уже существует среди препятствий
                }
            }

            foreach (var bonus in bonuses)
            {
                if (bonus.Point.X == newPoint.X && bonus.Point.Y == newPoint.Y)
                {
                    return true; // Координата уже существует среди бонусов
                }
            }

            return false; // Координата не существует в обоих списках
        }

        /// <summary>
        /// Перемещает игрока вверх.
        /// </summary>
        public void MoveUpPlayer()
        {
            Point newPlayerPosition;

            newPlayerPosition = PlauerPosition;

            newPlayerPosition.Y = newPlayerPosition.Y + 1;

            if (CheckAbroadAndObstacles(newPlayerPosition))
            {

                CheckBonusSelection(newPlayerPosition);

                PlauerPosition = newPlayerPosition;

            }

        }

        /// <summary>
        /// Перемещает игрока вниз.
        /// </summary>
        public void MoveDownPlayer()
        {
            Point newPlayerPosition;

            newPlayerPosition = PlauerPosition;

            newPlayerPosition.Y = newPlayerPosition.Y - 1;

            if (CheckAbroadAndObstacles(newPlayerPosition))
            {

                CheckBonusSelection(newPlayerPosition);

                PlauerPosition = newPlayerPosition;

            }

        }

        /// <summary>
        /// Перемещает игрока вправо.
        /// </summary>
        public void MoveRightPlayer()
        {
            Point newPlayerPosition;

            newPlayerPosition = PlauerPosition;

            newPlayerPosition.X = newPlayerPosition.X + 1;

            if (CheckAbroadAndObstacles(newPlayerPosition))
            {

                CheckBonusSelection(newPlayerPosition);

                PlauerPosition = newPlayerPosition;

            }

        }

        /// <summary>
        /// Перемещает игрока влево.
        /// </summary>
        public void MoveLeftPlayer()
        {
            Point newPlayerPosition;

            newPlayerPosition = PlauerPosition;

            newPlayerPosition.X = newPlayerPosition.X - 1;

            if (CheckAbroadAndObstacles(newPlayerPosition))
            {

                CheckBonusSelection(newPlayerPosition);

                PlauerPosition = newPlayerPosition;

            }

        }

        /// <summary>
        /// Проверка выхода за границы карты, а также наличие препятсвий и бонуса на новой позиции Игрока.
        /// </summary>
        private bool CheckAbroadAndObstacles(Point newPosition)
        {
            // Проверяем, не выходит ли новая позиция за границы карты
            if (map.IsInsideMap(newPosition))
            {
                // Проверяем, не содержится ли она в списке препятствий
                if (!map.IsObstacle(newPosition))
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Проверка наличия бонуса на новой позиции игрока.
        /// </summary>
        private void CheckBonusSelection (Point newPosition)
        {
            // Ищем бонус на новой позиции игрока
            Bonus bonus = map.Bonuses.Find(b => b.Point.X == newPosition.X && b.Point.Y == newPosition.Y);

            if (bonus != null)
            {
                // Если бонус найден, удалите его из списка Bonuses
                map.Bonuses.Remove(bonus);
            }
        }

        /// <summary>
        /// Перемещение монстров.
        /// </summary>
        private void MoveMonsters()
        {
            foreach (Monster monster in map.Monsters)
            {
                // Генерируем случайное число от 0 до 3, которое представляет одно из четырех направлений:
                // 0 - влево, 1 - вправо, 2 - вверх, 3 - вниз
                int randomDirection = random.Next(4);

                // Получаем текущее положение монстра
                Point currentMonsterPosition = monster.Point;

                // Создаем новую точку, куда монстр может переместиться
                Point newMonsterPosition = currentMonsterPosition;

                // В зависимости от сгенерированного случайного направления, обновляем новую позицию монстра
                switch (randomDirection)
                {
                    case 0: // Двигаемся влево
                        newMonsterPosition.X -= 1;
                        break;
                    case 1: // Двигаемся вправо
                        newMonsterPosition.X += 1;
                        break;
                    case 2: // Двигаемся вверх
                        newMonsterPosition.Y += 1;
                        break;
                    case 3: // Двигаемся вниз
                        newMonsterPosition.Y -= 1;
                        break;
                }

                // Проверяем, не выходит ли новая позиция за границы карты и не пересекается ли с препятствиями
                if (map.IsInsideMap(newMonsterPosition) && !map.IsObstacle(newMonsterPosition))
                {
                    // Если монстр не видит игрока, он двигается случайно
                    if (!IsPlayerVisible(currentMonsterPosition, PlayerPosition))
                    {
                        monster.Point = newMonsterPosition;
                    }
                    else
                    {
                        // Если монстр видит игрока, используем метод Harassment
                        Harassment(monster);
                    }
                }
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
                return distance == 1 || distance == 2;
            }
            else if (monsterPosition.Y == PlayerPosition.Y)
            {
                int distance = Math.Abs(monsterPosition.X - PlayerPosition.X);
                return distance == 1 || distance == 2;
            }
            return false;
        }

        /// <summary>
        /// Проверка содержания значений координат на наличие препятствий и игрока.
        /// </summary>
        private bool ContainsObstacleOrPlayer(List<Obstacle> obstacles,  Point newPoint)
        {
            foreach (var obstacle in obstacles)
            {
                if (obstacle.Point.X == newPoint.X && obstacle.Point.Y == newPoint.Y)
                {
                    return true; // Координата уже существует среди препятствий
                }
            }

            if (PlauerPosition.X == newPoint.X && PlauerPosition.Y == newPoint.Y)
            {
                 // Нанесение урона игроку
            }

            return false; // Координата не существует в обоих списках

        }

        /// <summary>
        /// Преследование игрока.
        /// </summary>
        /// <param name="monster"></param>
        private void Harassment(Monster monster)
        {
            Point monsterPosition = monster.Point;
            Point playerPosition = PlauerPosition; 

            // Вычисляем разницу между позициями монстра и игрока по горизонтали и вертикали
            int diffX = playerPosition.X - monsterPosition.X;
            int diffY = playerPosition.Y - monsterPosition.Y;

            // Передвигаем монстра ближе к игроку в направлении, в котором тот находится
            if (Math.Abs(diffX) > Math.Abs(diffY))
            {
                if (diffX > 0)
                {
                    monsterPosition.X += 1;
                }
                else
                {
                    monsterPosition.X -= 1;
                }
            }
            else
            {
                if (diffY > 0)
                {
                    monsterPosition.Y += 1;
                }
                else
                {
                    monsterPosition.Y -= 1;
                }
            }

            // Проверяем, не выходит ли новая позиция за границы карты и не пересекается ли с препятствиями
            if (map.IsInsideMap(monsterPosition) && !map.IsObstacle(monsterPosition))
            {
                monster.Point = monsterPosition;
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

            /*public List<ItemGame> ItemGames;*/

            // Отдельные списки для каждого элемента
            public List<Obstacle> Obstacles { get; }
            public List<Bonus> Bonuses { get; }
            public List<Monster> Monsters { get; }

            public Map(int width, int height)
            {
                _width = width;
                _height = height;
                /*ItemGames = new List<ItemGame>();*/
                Obstacles = new List<Obstacle>();
                Bonuses = new List<Bonus>();
                Monsters = new List<Monster>();
            }

            /// <summary>
            /// Проверка выхода за пределы карты
            /// </summary>
            /// <param name="position"></param>
            /// <returns></returns>
            public bool IsInsideMap(Point position)
            {
                return position.X >= 1 && position.X <= Width && position.Y >= 1 && position.Y <= Height;
            }

            /// <summary>
            /// Проверка сталкивания с препятствием
            /// </summary>
            /// <param name="position"></param>
            /// <returns></returns>
            public bool IsObstacle(Point position)
            {
                return Obstacles.Any(obstacle => obstacle.Point.X == position.X && obstacle.Point.Y == position.Y);
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
}






