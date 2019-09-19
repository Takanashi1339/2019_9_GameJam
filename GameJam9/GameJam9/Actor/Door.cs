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
    class Door : Entity
    {
        private Animation animation;
        private bool isOpen;
        private float scaleChange;
        private float drawscale;

        public bool IsEnd
        {
            get;
            private set;
        } = false;

        public Door(Vector2 position)
            : base("door", position, new Point(32, 64))
        {
            scaleChange = 0.01f;
            drawscale = 1f;
            isOpen = false;
            animation = new Animation(Size, 4, 0.025f, false);
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
            if (drawscale < 0.5f || drawscale > 1.5f)
            {
                scaleChange *= -1;
            }
            drawscale += scaleChange;
            if(isOpen)
            {
                if (animation.IsEnd)
                {
                    IsEnd = true;
                }
                animation.Update(gameTime);
            }
            base.Update(gameTime);
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
            if(GameObjectManager.Instance.Find<Player>()[0].HasKey)
            {
                var lightDrawer = Drawer.Default;
                lightDrawer.DisplayModify = true;
                lightDrawer.Scale = Vector2.One * drawscale;
                lightDrawer.Origin = new Rectangle(Point.Zero, new Point(96, 96)).Center.ToVector2();
                Renderer.Instance.DrawTexture("itemlight", Position - new Vector2(Size.X, Size.Y / 2), lightDrawer);
            }
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            base.Draw(drawer);
        }
    }
}
