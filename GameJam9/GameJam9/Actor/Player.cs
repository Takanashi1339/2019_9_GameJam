using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GameJam9.Util;

namespace GameJam9.Actor
{
    class Player : Entity
    {
        private bool isJump;
        private bool isLeft;
        private float speed;
        public Player(Vector2 position)
            : base("test_player", position , new Point(32 , 64))
        {
            isJump = false;
            isLeft = false;
            speed = 3f;
        }

        public Player(Player other)
            :this(other.Position)
        { }

        public override object Clone()
        {
            return new Player(this);
        }

        public override void Update(GameTime gameTime)
        {
            var velocity = Velocity;
            if (Input.GetKeyTrigger(Keys.W) && !isJump)
            {
                velocity.Y = -10.0f;//仮の移動量
                isJump = true;
            }

            velocity.X = Input.Velocity().X * speed;
            Velocity = velocity;
            if (Velocity.Y == 0f)
            {
                isJump = false;
            }
            else if(Velocity.Y > 0.6f)
            {
                isJump = true;
            }
            if (Velocity.X > 0)
            {
                isLeft = false;
            }
            if(Velocity.X < 0)
            {
                isLeft = true;
            }
            base.Update(gameTime);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            if (!isLeft)
            {
                drawer.SpriteEffects = SpriteEffects.None;
            }
            if (isLeft)
            {
                drawer.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            base.Draw(drawer);
        }
    }
}
