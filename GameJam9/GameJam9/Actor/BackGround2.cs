using GameJam9.Def;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    //最奥
    class BackGround2 : BackGround
    {
        private static readonly string[] names = new string[]
        {
            "BG2",
            "BGf2"
        };
        public BackGround2(Vector2 position, MapDictionary.MapType type)
            : base(names[(int)type], position, 0.1f)
        {
        }

        public BackGround2(BackGround2 other)
            : base(other.Name, other.Position, other.speed)
        {

        }

        public override object Clone()
        {
            return new BackGround2(this);
        }
    }
}
