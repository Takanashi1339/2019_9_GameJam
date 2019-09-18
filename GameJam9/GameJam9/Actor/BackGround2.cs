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
        public BackGround2(Vector2 position)
            : base("BGf2", position, 0.2f)
        {
        }

        public BackGround2(BackGround2 other)
            : this(other.Position)
        {

        }

        public override object Clone()
        {
            return new BackGround2(this);
        }
    }
}
