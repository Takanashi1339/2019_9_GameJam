﻿using System;
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
        public Player(Vector2 position)
            : base("test_player", position , new Point(32 , 64))
        {
            isJump = false;
            isLeft = false;
            speed = 2f;
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

            UpdateDisplayModify();
        }

        public override void Hit(GameObject gameObject)
        {
            base.Hit(gameObject);

            UpdateDisplayModify();
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
    }
}
