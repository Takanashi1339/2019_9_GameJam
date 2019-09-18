using GameJam9.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class Caterpillar : Enemy
    {
        private Animation animation;
        private float walkSpeed = -1f;

        public Caterpillar(Vector2 position)
            : base("caterpillar", position, new Point(64,32), 10)
        {
        }

        public Caterpillar(Caterpillar other)
            : this(other.Position)
        {
        }

        public override Entity Spawn(Map map, Vector2 position)
        {
            animation = new Animation(Size, 2, 0.3f);
            return base.Spawn(map, position);
        }

        public override object Clone()
        {
            return new Caterpillar(this);
        }

        public override void Update(GameTime gameTime)
        {
            Velocity = new Vector2(walkSpeed, Velocity.Y);
            animation.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Hit(GameObject gameObject)
        {
            if (gameObject is Block block && block.IsSolid)
            {
                var direction = CheckDirection(block);
                if (direction == Direction.Left || direction == Direction.Right)
                {
                    walkSpeed *= -1;
                }
            }
            base.Hit(gameObject);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            if (walkSpeed > 0)
            {
                drawer.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            base.Draw(drawer);
        }
    }
}
