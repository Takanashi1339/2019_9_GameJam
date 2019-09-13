using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam9.Actor
{
    class Bird : Enemy
    {
        private Animation animation;
        private Vector2 leftPosition;
        private Vector2 rightPosition;
        private int moveRange;
        private float flySpeed = -2f;

        public Bird(Vector2 position) 
            : base("bird", position, new Point(64,64), 10)
        {
            moveRange = 3;
            Gravity = 0;
            Velocity = new Vector2(flySpeed, 0);
        }

        public Bird(Bird other)
            :this(other.Position)
        {
        }

        public override Entity Spawn(Map map, Vector2 position)
        {
            leftPosition.X = position.X - Size.X * moveRange;
            rightPosition.X = position.X + Size.X * moveRange;
            animation = new Animation(Size, 2, 0.1f);
            return base.Spawn(map, position);
        }

        public override object Clone()
        {
            return new Bird(this);
        }

        public override void Update(GameTime gameTime)
        {
            if (Position.X <= leftPosition.X ||
                Position.X >= rightPosition.X)
            {
                flySpeed *= -1;
            }
            Velocity = new Vector2(flySpeed, Velocity.Y);
            animation.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            if(Velocity.X > 0)
            {
                drawer.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            base.Draw(drawer);
        }
    }
}
