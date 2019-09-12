using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class TestEnemy01 : Enemy
    {
        private Animation animation;

        public TestEnemy01(Vector2 position) 
            : base("test_enemy", position, new Point(64, 64), 10)
        {
        }

        public TestEnemy01(TestEnemy01 other)
            :this(other.Position)
        {
        }

        public override Entity Spawn(Map map, Vector2 position)
        {
            animation = new Animation(Size, 4, 0.25f);
            return base.Spawn(map, position);
        }

        public override object Clone()
        {
            return new TestEnemy01(this);
        }

        public override void Update(GameTime gameTime)
        {
            Velocity = new Vector2(-0.5f, Velocity.Y);
            animation.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            base.Draw(drawer);
        }
    }
}
