using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using GameJam9.Util;
using GameJam9.Def;
using GameJam9.Device;
using GameJam9.Manager;

namespace GameJam9.Actor
{
    class Player : Entity
    {
        private bool isJump;
        private bool isLeft;
        private float speed;
        private Animation animation;
        private bool hasKey;

        public Player(Vector2 position)
            : base("player_stand", position , new Point(32 , 64))
        {
            isJump = false;
            isLeft = false;
            hasKey = false;
            animation = new Animation(Size, 4, 0.1f);
            speed = 3f;
            shiftable = false;
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
            if(Input.Velocity().X < 0 && Velocity.X > -speed
            || Input.Velocity().X > 0 && Velocity.X < speed){
                if (isJump)
                {
                    velocity.X += Input.Velocity().X * speed/10;
                }
                else {
                    velocity.X += Input.Velocity().X * speed;
                }
            }
            else if (Math.Abs(velocity.X) < speed / 10)
            {
                velocity.X = 0;
            }else
            {
                velocity.X -= Math.Sign(velocity.X) * speed/10;
            }

            Velocity = velocity;
            if (Velocity.Y == 0f)
            {
                isJump = false;
            }
            else if (Velocity.Y > 0.6f)
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
            animation.Update(gameTime);

            UpdateDisplayModify();
        }

        public override void Hit(GameObject gameObject)
        {
            base.Hit(gameObject);
            if (gameObject is Enemy enemy)
            {
                Velocity = new Vector2(Math.Sign(Position.X+Size.X/2 - (enemy.Position.X + enemy.Size.X / 2)) * 14f, -10f);
                isJump = true;
            }
            if(gameObject is DropItem dropItem && dropItem.Item is Key)
            {
                hasKey = true;
            }
            UpdateDisplayModify();
        }

        public override void Draw()
        {
            if (!isJump && Math.Abs(Input.Velocity().X) > 0)
            {
                Name = "player_walk";
            }
            else if (isJump)
            {
                Name = "player_fly";
            }
            else
            {
                Name = "player_stand";
            }
            var drawer = Drawer.Default;
            if (isLeft)
            {
                drawer.SpriteEffects = SpriteEffects.None;
            }
            if (!isLeft)
            {
                drawer.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            drawer.Rectangle = animation.GetRectangle();
            base.Draw(drawer);
        }

        /*
        private void UpdateDisplayModify()
        {
            if (Position.X - Screen.Width / 2 + Size.X / 2 < 0)
            {
                GameDevice.Instance().DisplayModify = Vector2.Zero;
                return;
            }

            if (Position.X + Screen.Width / 2 + Size.X / 2 > GameObjectManager.Instance.Map.Width)
            {
                GameDevice.Instance().DisplayModify = new Vector2(-1 * (GameObjectManager.Instance.Map.Width - Screen.Width), 0);
                return;
            }
            GameDevice.Instance().DisplayModify = new Vector2(-Position.X + (Screen.Width / 2 - Size.X / 2), 0.0f);
        }
        */

        private void UpdateDisplayModify()
        {
            GameDevice.Instance().DisplayModify = new Vector2(-Position.X + (Screen.Width / 2 - Size.X / 2), 0.0f);
        }
    }
}
