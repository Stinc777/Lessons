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

        public int WidthMap { get; set; }
        public int HeightMap { get; set; }

        public Game(int x, int y)
        {

            WidthMap = x;
            HeightMap = y;

            Map map = new Map(WidthMap, HeightMap); // Создание объекта карты*/
            Characters characters = new Characters(WidthMap, HeightMap);
        }

    }


    /// <summary>
    /// Класс Карты игры
    /// </summary>
    class Map
    {

        private Random random;

        private int[] valueBonusX;
        private int[] valueBonusY;
        private int[] valueObstaclesX;
        private int[] valueObstaclesY;

        public int[] ValueBonusX { get;}

        public int[] ValueBonusY { get; }
        public int[] ValueObstaclesX { get; }
        public int[] ValueObstaclesY { get; }


        public Map(int x, int y)
        {
            random = new Random(); // Инициализация объекта random

            MapBonus(x, y);
            MapObstacles(x, y);

            ValueBonusX = valueBonusX;
            ValueBonusY = valueBonusY;
            ValueObstaclesX = valueObstaclesX;
            ValueObstaclesY = valueObstaclesY;

        }

        public void MapBonus(int x, int y)
        {
            int valueX;
            int valueY;

            double prcntItem = (x * y) * 20 / 100; //Бонусы на карте будут в количестве 20 процентов.

            int item = (int)Math.Ceiling(prcntItem);

            valueBonusX = new int[item];
            valueBonusY = new int[item];

            for (int i = 0; i < item; i++)
            {
                
                valueX = random.Next(1, x);
                valueY = random.Next(1, y);

                if (!ContainsCoordinate(valueBonusX, valueBonusY, valueX, valueY))    // Проверяем, не содержится ли это значение в массиве бонусов
                {
                    valueBonusX[i] = valueX;
                    valueBonusY[i] = valueY;
                }
                else i--;

            }
        }

        public void MapObstacles(int x, int y)
        {

            int valueX;
            int valueY;

            double prcntObstacles = (x * y) * 10 / 100; // Препятствия на карте будут в количестве 10 процентов.          

            int obstacles = (int)Math.Ceiling(prcntObstacles);

            valueObstaclesX = new int[obstacles];
            valueObstaclesY = new int[obstacles];

            for (int i = 0; i < obstacles; i++)
            {

                valueX = random.Next(1, (x));
                valueY = random.Next(1, (y));

                if (!ContainsCoordinate(valueBonusX, valueBonusY, valueX, valueY) &&     // Проверяем, не содержится ли это значение в массиве бонусов
                !ContainsCoordinate(valueObstaclesX, valueObstaclesY, valueX, valueY))    // А также нет ли повторений в массиве препятствий
                {
                    valueObstaclesX[i] = valueX;
                    valueObstaclesY[i] = valueY;
                }
                else i--;

            }

        }

        private bool ContainsCoordinate(int[] xArray, int[] yArray, int x, int y)
        {
            for (int i = 0; i < xArray.Length; i++)
            {
                if (xArray[i] == x && yArray[i] == y)
                {
                    return true; // Координата уже существует в массиве
                }
            }
            return false; // Координата не существует в массиве
        }

    }

    class Characters
    {

        private Random random;

        private int valueSpawnPlayerX;
        private int valueSpawnPlayerY;

        private int[] valueSpawnMonstersX;
        private int[] valueSpawnMonstersY;

        private Map map; // Создайте поле для хранения экземпляра класса Map

        public Characters(int x, int y)
        {

            random = new Random(); // Инициализация объекта random

            map = new Map(x, y);

            RespawnPlayer(x, y);

            RespawnMonsters(x, y);

        }
        public void RespawnPlayer(int x, int y)
        {
            int valueX;
            int valueY;


            for (int i = 0; i < 1; i++)
            {
                valueX = random.Next(1, x);
                valueY = random.Next(1, y);

                // Проверяем, что координаты не совпадают ни в одном из массивов бонусов или препятствий
                if (!(
                    (Array.IndexOf(map.ValueBonusX, valueX) != -1 && Array.IndexOf(map.ValueBonusY, valueY) != -1) ||
                    (Array.IndexOf(map.ValueObstaclesX, valueX) != -1 && Array.IndexOf(map.ValueObstaclesY, valueY) != -1)
                ))
                {
                    valueSpawnPlayerX = valueX;
                    valueSpawnPlayerY = valueY;
                }
                else i--;
            }
        }

        public void RespawnMonsters(int x, int y)
        {
            int valueX;
            int valueY;

            // Вычисляем количество монстров в зависимости от размера карты
            int numberOfMonsters = 0;

            int totalMapValue = x * y;
            if (totalMapValue < 25)
            {
                numberOfMonsters = 1;
            }
            else if (totalMapValue < 50)
            {
                numberOfMonsters = 2;
            }
            else if (totalMapValue < 75)
            {
                numberOfMonsters = 3;
            }
            else if (totalMapValue < 100)
            {
                numberOfMonsters = 4;
            }
            else
            {
                numberOfMonsters = 5;
            }

            valueSpawnMonstersX = new int[numberOfMonsters];
            valueSpawnMonstersY = new int[numberOfMonsters];

            for (int i = 0; i < numberOfMonsters; i++)
            {
                valueX = random.Next(1, x);
                valueY = random.Next(1, y);

                if (IsInBonusOrObstacle(valueX, valueY))    
                {
                    valueSpawnMonstersX[i] = valueX;
                    valueSpawnMonstersY[i] = valueY;
                }
                else i--;

            }
        }

        public bool IsInBonusOrObstacle(int x, int y)
        {
            return !(
                    (Array.IndexOf(map.ValueBonusX, x) != -1 && Array.IndexOf(map.ValueBonusY, y) != -1) ||
                    (Array.IndexOf(map.ValueObstaclesX, x) != -1 && Array.IndexOf(map.ValueObstaclesY, y) != -1) ||
                    (valueSpawnPlayerX != x && valueSpawnPlayerY != y)
                    );
        }

    }


}



