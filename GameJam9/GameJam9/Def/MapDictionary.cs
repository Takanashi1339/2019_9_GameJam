using GameJam9.Actor;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Def
{
    static class MapDictionary
    {
        public static readonly Dictionary<string, GameObject> Data;

        public enum MapType
        {
            Plain = 0,
            Forest = 1
        }

        public static readonly string[] MapNames = {
            "Maptest.csv",
            "Maptest2.csv"
        };

        static MapDictionary()
        {
            Data = new Dictionary<string, GameObject>();
            Data.Add("0", new Space());
            Data.Add("1", new TestBlock());
            Data.Add("2", new Dirt());
            Data.Add("3", new ForestBlock());
            Data.Add("g", new RandomGrass());
            Data.Add("fg", new ForestGrass());
            Data.Add("P", new Player(Vector2.Zero));
            Data.Add("E", new Fox(Vector2.Zero));
            Data.Add("E2", new Bird(Vector2.Zero));
            Data.Add("E3", new MagicEnemy(Vector2.Zero));
            Data.Add("E4", new Caterpillar(Vector2.Zero));
            Data.Add("iK", new DropItem(new Key(), Vector2.Zero));
            Data.Add("d", new Door(Vector2.Zero));
            Data.Add("S1", new Stump(0));
            Data.Add("S2", new Stump(1));
            Data.Add("L1", new Log(0));
            Data.Add("L2", new Log(1));
            Data.Add("L3", new Log(2));
            Data.Add("L4", new Log(3));
            //ここにEntity/Blockを追加
        }
    }
}
