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
            if (gameObject is Block block)
            {
                CorrectPosition(block);
            }
        }
    }
}
