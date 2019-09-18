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

        static MapDictionary()
        {
            Data = new Dictionary<string, GameObject>();
            Data.Add("0", new Space());
            Data.Add("1", new TestBlock());
            Data.Add("2", new Log(3));
            Data.Add("g", new RandomGrass());
            Data.Add("P", new Player(Vector2.Zero));
            Data.Add("E", new Fox(Vector2.Zero));
            Data.Add("E2", new Bird(Vector2.Zero));
            Data.Add("E3", new MagicEnemy(Vector2.Zero));
            Data.Add("iK", new DropItem(new Key(), Vector2.Zero));
            Data.Add("d", new Door(Vector2.Zero));
            Data.Add("S1", new Stump(0));
            Data.Add("S2", new Stump(1));
            Data.Add("L1", new Log(0));
            Data.Add("L2", new Log(1));
            Data.Add("L2", new Log(2));
            Data.Add("L2", new Log(3));
            //ここにEntity/Blockを追加
        }
    }
}
