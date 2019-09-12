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
            Data.Add("2", new Dirt());
            Data.Add("g", new RandomGrass());
            Data.Add("P", new Player(Vector2.Zero));
            Data.Add("E", new TestEnemy01(Vector2.Zero));
            //ここにEntity/Blockを追加
        }
    }
}
