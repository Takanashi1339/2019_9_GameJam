using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class Door : Entity
    {
        private Animation animation;
        private bool isOpen;

        public bool IsEnd
        {
            get;
            private set;
        } = false;

        public Door(Vector2 position)
            : base("door", position, new Point(32, 64))
        {
            isOpen = false;
            animation = new Animation(Size, 4, 0.25f, false);
            Gravity = 0f;
        }

        public Door(Door other)
            :this(other.Position)
        { }
        public override object Clone()
        {
            return new Door(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(isOpen)
            {
                if (animation.IsEnd)
                {
                    IsEnd = true;
                }
                animation.Update(gameTime);
            }
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Player player && player.HasKey)
            {
                isOpen = true;
            }
            base.Hit(gameObject);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            base.Draw(drawer);
        }
    }
}
