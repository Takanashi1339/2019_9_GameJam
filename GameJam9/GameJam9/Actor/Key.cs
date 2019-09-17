using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class Key : Item
    {
        private Animation animation;
        public Key()
            :base("key", new Point(32, 32))
        {
            animation = new Animation(Size, 4, 0.2f);
        }

        public override Rectangle GetRectangle()
        {
            return animation.GetRectangle();
        }

        public override void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
