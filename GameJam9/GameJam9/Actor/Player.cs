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
            : base("player", position , new Point(32 , 64))
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
            var velocity = Velocity;
            if (Input.GetKeyTrigger(Keys.W) && isJump)
            {
                velocity.Y = -10.0f;//仮の移動量
                isJump = true;
            }
            velocity.X = Input.Velocity().X;
            Velocity = velocity;
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

        private void HitBlock(GameObject gameObject)
        {
            Direction direction = CheckDirection(gameObject);
            var position = Position;
            var velocity = Velocity;

            if(direction == Direction.Top)
            {
                if(Position.Y > 0f)
                {
                    position.Y = gameObject.Rectangle.Top;
                    velocity.Y = 0f;
                    isJump = false;
                }
            }
            else if(direction == Direction.Right)
            {
                position.X = gameObject.Rectangle.Right;
            }
            else if(direction == Direction.Left)
            {
                position.X = gameObject.Rectangle.Left - Width;
            }
            else if(direction == Direction.Bottom)
            {
                position.Y = gameObject.Rectangle.Bottom;
                if(isJump)
                {
                    velocity.Y = 0.0f;
                }
            }
            Position = position;
            Velocity = velocity;
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
