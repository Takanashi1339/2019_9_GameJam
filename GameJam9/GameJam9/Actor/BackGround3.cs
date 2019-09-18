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
    class BackGround3 : BackGround
    {
        private static string[] names = new string[]
        {
            "BG3",
            "BGf3"
        };

        public BackGround3(Vector2 position, MapDictionary.MapType type)
            : base(names[(int)type], position, 0.5f)
        {
        }

        public BackGround3(BackGround3 other)
            : base(other.Name, other.Position, other.speed)
        {

        }

        public override object Clone()
        {
            return new BackGround3(this);
        }
    }
}
