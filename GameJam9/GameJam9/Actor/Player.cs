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
        public Player(Vector2 position)
            : base("test_player", position , new Point(32 , 64))
        {
            isJump = true;
            isLeft = false;
        }

        public Player(Player other)
            :this(other.Position)
        { }

        public override object Clone()
        {
            return new Player(this);
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if(Input.GetKeyTrigger(Keys.W) && isJump)
            {
                var velocity = Velocity;
                velocity.Y = -10.0f;//仮の移動量
                Velocity = velocity;
                isJump = true;
            }
            if(Velocity.X > 0)
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
