using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Def;
using GameJam9.Device;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class TestBullet : Enemy
    {
        private float speed;
        private Vector2 velocity;
        public TestBullet(Vector2 position, Vector2 velocity)
            : base("test_bullet", position, new Point(16, 16), 1)
        {
            this.velocity = velocity;
            speed = 3f;
            Gravity = 0;
        }

        public TestBullet(TestBullet other)
            :this(other.Position, other.Velocity)
        { }

        public override object Clone()
        {
            return new TestBullet(this);
        }

        public override void Hit(GameObject gameObject)
        {
            var modify = GameDevice.Instance().DisplayModify;
            if (!(Position.X + modify.X + Size.X >= 0 && Position.X + modify.X <= Screen.Width)
                || Position.Y > Screen.Height || Position.Y <= 0)
            {
                IsDead = true;
            }
            if (gameObject is Block block && block.IsSolid)
            {
                IsDead = true;
            }
            base.Hit(gameObject);
        }

        public override void Update(GameTime gameTime)
        {
            Velocity = velocity * speed;
            base.Update(gameTime);
        }
    }
}
