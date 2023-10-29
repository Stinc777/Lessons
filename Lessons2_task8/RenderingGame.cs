using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons2_task8
{
    public class RenderingGame
    {
        private Game _game;

        private Dictionary<Point, ItemType> points;

        public RenderingGame(Game game)
        {
            _game = game;
            points = _game.GetPointsMap();
        }

        public string Rendering()
        {
            StringBuilder map = new StringBuilder();
            Point point;

            for(var i = _game.HeightMap+2; i > 0; i--)
            {
                for(var j = 0; j < _game.WidthMap + 2; j++)
                {
                    if (i == 0 || i == _game.HeightMap + 2)
                    {
                        map.Append(RenderingItems.Border);
                    }
                    else if( j == 0 || j == _game.WidthMap + 2)
                    {
                        map.Append(RenderingItems.Border);
                    }
                    else
                    {
                        ItemType type;
                        point.X = j-1;
                        point.Y = i-1;

                        if (points.TryGetValue(point, out type))
                        {
                            switch (type)
                            {
                                case ItemType.ObstacleType:
                                    map.Append(RenderingItems.Obstacle);
                                    break;
                                case ItemType.BonusType:
                                    map.Append(RenderingItems.Bonus);
                                    break;
                                case ItemType.MonsterType:
                                    map.Append(RenderingItems.Monster);
                                    break;
                                case ItemType.Player:
                                    map.Append(RenderingItems.Player);
                                    break;
                            }
                        }
                        else
                        {
                            map.Append(RenderingItems.Spase);
                        }
                    }
                }
                map.AppendLine();
            }

            return map.ToString();
        }

    }

    public class RenderingItems
    {
        public const string Border = "░";
        public const string Obstacle = "4";
        public const string Bonus = "*";
        public const string Monster = "&";
        public const string Player = "☻";
        public const string Spase = "0";
    }
}
