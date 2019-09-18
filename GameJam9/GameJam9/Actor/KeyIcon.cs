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
        public KeyIcon(Vector2 position)
            : base("keyicon",position, new Point(32, 32), 1, 1)
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

        public override void Draw()
        {
            var drawer = Drawer.Default;
            if (GameObjectManager.Instance.Find<Player>()[0].HasKey)
            {
                base.Draw(drawer);
            }
        }
    }
}
