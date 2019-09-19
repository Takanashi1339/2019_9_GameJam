using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Manager;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class KeyIcon : UI
    {
        private Rectangle rectangle;
        public KeyIcon(Vector2 position)
            : base("keyicon",position, new Point(128, 64), 1, 1)
        {
            Position = new Vector2(128, 0);
        }

        public KeyIcon(KeyIcon other)
            :this(other.Position)
        { }
        public override object Clone()
        {
            return new KeyIcon(this);
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
            rectangle = Rectangle;
            if(!(GameObjectManager.Instance.Find<Player>().First().HasKey))
            {
                rectangle = new Rectangle(Point.Zero, new Point(Size.X / 2, Size.Y));
            }
            else
            {
                rectangle = new Rectangle(new Point(Size.X / 2, 0), Size);
            }
            base.Update(gameTime);
        }
        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = rectangle;
            base.Draw(drawer);
        }
    }
}
