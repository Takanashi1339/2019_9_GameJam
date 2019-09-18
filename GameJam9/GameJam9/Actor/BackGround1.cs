using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    //最奥
    class BackGround1 : BackGround
    {
        public BackGround1(Vector2 position)
            : base("BGf1", position, 0.1f)
        {
        }

        public BackGround1(BackGround1 other)
            : this(other.Position)
        {

        }

        public override object Clone()
        {
            return new BackGround1(this);
        }
    }
}
