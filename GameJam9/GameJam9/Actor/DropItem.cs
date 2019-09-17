using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Manager;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class DropItem : Entity
    {
        public Item Item
        {
            get;
            private set;
        }
        public DropItem(Item item, Vector2 position)
            : base(item.Name, position, item.Size)
        {
            Item = item;
        }

        public DropItem(DropItem other)
            :this(other.Item, other.Position)
        { }
        
        public override object Clone()
        {
            return new DropItem(this);
        }
        
        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Player)
            {
                IsDead = true;
            }
            base.Hit(gameObject);
        }
    }
}
