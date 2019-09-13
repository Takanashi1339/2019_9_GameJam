using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class Pointer : UI
    {
        public Pointer(Vector2 position) 
            : base("pointer", position, new Point(64, 64), 1, 0)
        {
        }

        public Pointer(Pointer other)
            :this(other.Position)
        {

        }

        public override object Clone()
        {
            return new Pointer(this);
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Position = Input.MousePosition - Size.ToVector2() / 2;
            base.Update(gameTime);
        }
    }
}
