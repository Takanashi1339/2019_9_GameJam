using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Device;
using GameJam9.Manager;
using GameJam9.Util;
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

        private float scaleChange;
        private float drawscale;
        public DropItem(Item item, Vector2 position)
            : base(item.Name, position, item.Size)
        {
            scaleChange = 0.01f;
            drawscale = 1f;
            Item = item;
            Gravity = 0f;
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

        public override void Draw()
        {
            var lightDrawer = Drawer.Default;
            lightDrawer.DisplayModify = true;
            lightDrawer.Scale = Vector2.One * drawscale;
            lightDrawer.Origin = new Rectangle(Point.Zero, new Point(96, 96)).Center.ToVector2();
            Renderer.Instance.DrawTexture("itemlight", Position - Size.ToVector2(), lightDrawer);
            var drawer = Drawer.Default;
            drawer.Rectangle = Item.GetRectangle();
            base.Draw(drawer);

        }

        public override void Update(GameTime gameTime)
        {
            if (drawscale < 0.5f || drawscale > 1.5f)
            {
                scaleChange *= -1;
            }
            drawscale += scaleChange;
            Item.Update(gameTime);
            base.Update(gameTime);
        }
    }
}
