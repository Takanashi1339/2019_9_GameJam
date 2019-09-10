using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameJam9.Manager;

namespace GameJam9.Actor
{
    abstract class Entity : GameObject
    {
        public static readonly float Gravity = 0.3f;
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
            Direction dir = CheckDirection(gameObject);

            if (gameObject is Block block && block.IsSolid)
            {
                CorrectPosition(block);
                var velocity = Velocity;
                if (dir == Direction.Top)
                {
                    velocity.Y = 0.0f;
                }
                else if (dir == Direction.Bottom)
                {
                    velocity.Y = 0.0f;
                }
                Velocity = velocity;
            }
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
            base.Update(gameTime);
        }
    }
}
