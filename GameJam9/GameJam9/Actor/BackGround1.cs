using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Def;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    //最奥
    class BackGround1 : BackGround
    {
        private static string[] names = new string[]
        {
            "BG1",
            "BGf1"
        };

        public BackGround1(Vector2 position, MapDictionary.MapType type)
            : base(names[(int)type], position, 0.1f)
        {
        }

        public BackGround1(BackGround1 other)
            : base(other.Name, other.Position, other.speed)
        {

        }

        public override object Clone()
        {
            return new BackGround1(this);
        }
    }
}
