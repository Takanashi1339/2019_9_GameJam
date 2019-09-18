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
    class Bat : Enemy
    {
        private Animation animation;
        private Timer rlTimer,udTimer,movetimer;
        private float flySpeed = -2f;
        private float upSpeed = 1f;

        public Bat(Vector2 position)
            : base("bat", position, new Point(64, 64), 10)
        {
            Gravity = 0;
            Velocity = new Vector2(flySpeed, upSpeed);
            rlTimer = new Timer(2, true);
            udTimer = new Timer(0.6f, true);
            movetimer = new Timer(30f, false);
        }

        public Bat(Bat other)
            : this(other.Position)
        {
        }

        public override Entity Spawn(Map map, Vector2 position)
        {
            animation = new Animation(Size, 2, 0.1f);
            return base.Spawn(map, position);
        }

        public override object Clone()
        {
            return new Bat(this);
        }

        public override void Update(GameTime gameTime)
        {
            movetimer.Update(gameTime);
            if (movetimer.IsTime)
            {
                rlTimer.Update(gameTime);
                udTimer.Update(gameTime);
                if (rlTimer.IsTime)
                {
                    flySpeed *= -1;
                }
                if (udTimer.IsTime)
                {
                    upSpeed *= -1;
                }
                Velocity = new Vector2(flySpeed, upSpeed);
                animation.Update(gameTime);
                base.Update(gameTime);
            }
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            if(!movetimer.IsTime)
            {
                Name = "bat1";
            }
            else
            {
                Name = "bat";
            }
            if (Velocity.X > 0)
            {
                drawer.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            base.Draw(drawer);
        }
    }
}
