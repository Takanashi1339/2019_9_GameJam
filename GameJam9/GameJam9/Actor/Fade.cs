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
    class Fade : GameObject
    {
        private Vector2 scale;
        private float scaleRate = 0.1f;
        private float alpha;
        private float alphaSpeed = 0.05f;
        private FadeOption option;

        public enum FadeOption
        {
            In,
            Out,
        }
        public Fade(Vector2 position,FadeOption option)
            : base("fade", position, new Point(800, 600))
        {
            this.option = option;
            if (option == FadeOption.Out)
            {
                scale = Vector2.One * 2;
                alpha = 1f;
            }
            else
            {
                scale = Vector2.Zero;
                alpha = 0f;
            }
        }

        public Fade(Fade other)
            :this(other.Position, other.option)
        { }
        public override object Clone()
        {
            return new Fade(this);
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Update(GameTime gameTime)
        {
            var scaleValue = Vector2.One * scaleRate;
            var alphaValue = alphaSpeed;
            if (option == FadeOption.Out)
            {
                scaleValue *= -1;
                alphaValue *= -1;
            }
            alpha += alphaValue;
            scale += scaleValue;
            if (scale.X < 0 ||scale.Y < 0)
            {
                scale = Vector2.Zero;
            }
            if(scale.X > 2 ||scale.Y > 2)
            {
                scale = Vector2.One * 2;
            }
            if(alpha < 0)
            {
                alpha = 0;
            }
            if(alpha > 1)
            {
                alpha = 1;
            }
            if(GameObjectManager.Instance.Find<Player>().First().MoveLock)
            {
                option = FadeOption.In;
            }
            base.Update(gameTime);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Origin = Rectangle.Center.ToVector2();
            drawer.Scale = scale;
            drawer.Alpha = alpha;
            base.Draw(drawer);
        }
    }
}
