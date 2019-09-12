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
        public BackGround3(Vector2 position)
            : base("BG3", position, 0.5f)
        {
        }

        public BackGround3(BackGround3 other)
            : this(other.Position)
        {

        }

        public override object Clone()
        {
            return new BackGround3(this);
        }
    }
}
