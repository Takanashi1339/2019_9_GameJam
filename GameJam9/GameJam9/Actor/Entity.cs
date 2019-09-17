using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameJam9.Manager;
using GameJam9.Util;
using GameJam9.Def;
using GameJam9.Device;

namespace GameJam9.Actor
{
    abstract class Entity : GameObject
    {
        public float Gravity
        {
            get;
            protected set;
        } = 0.4f;

        protected bool shiftable = true;

        public static readonly float MaxFallSpeed = 9.8f;

        public Entity(string name, Vector2 position, Point size)
            : base(name, position, size)
        {
        }

        public virtual Entity Spawn(Map map, Vector2 position)
        {
            Position = position;
            GameObjectManager.Instance.Add(this);
            return this;
        }

        public override void Hit(GameObject gameObject)
        {

            if (gameObject is Block block && block.IsSolid)
            {
                Direction dir = CheckDirection(block);
                CorrectPosition(block);
                var velocity = Velocity;
                if (dir == Direction.Top)
                {
                    velocity.Y = 0.0f;
                }
                else if (dir == Direction.Bottom)
                {
                    velocity.Y = 0.01f;
                }
                Velocity = velocity;
            }
        }

        public void Shift()
        {
            if (!shiftable) return;
            var map = GameObjectManager.Instance.Map;

            var displayModify = (int)(-GameDevice.Instance().DisplayModify.X / Map.BlockSize);
            var entityModify = Position.X / Map.BlockSize;
            var shiftPosition = Position;
            if (displayModify + map.Width / (Map.BlockSize * 2) < entityModify)
            {
                shiftPosition.X -= map.Width;
            }
            else if (displayModify - map.Width / (Map.BlockSize * 2) > entityModify)
            {
                shiftPosition.X += map.Width;
            }
            Position = shiftPosition;
        }

        public bool IsInScreen()
        {
            var modify = GameDevice.Instance().DisplayModify;
            return Position.X + modify.X + Size.X >= 0 
                && Position.X + modify.X <= Screen.Width
                && Position.Y + modify.Y + Size.Y >= 0
                && Position.Y + modify.Y <= Screen.Height;
        }

        protected override void Draw(Drawer drawer)
        {
            drawer.DisplayModify = true;
            drawer.Color = Clock.Instance.EntityColor;
            base.Draw(drawer);
        }

        public override void Update(GameTime gameTime)
        {
            var velocity = Velocity;
            velocity.Y += Gravity;
            if (velocity.Y > MaxFallSpeed)
            {
                velocity.Y = MaxFallSpeed;
            }
            Velocity = velocity;
            Shift();
            base.Update(gameTime);
        }
    }
}
