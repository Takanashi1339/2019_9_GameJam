using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class BackGroundStar : BackGround
    {
        private float starAlpha;
        private float StarAlpha
        {
            get
            {
                return starAlpha;
            }
            set
            {
                starAlpha = value;
                if (value > 1) starAlpha = 1;
                if (value < 0) starAlpha = 0;
            }
        }
        public BackGroundStar(Vector2 position) 
            : base("BGS", position, 0.1f)
        {
            StarAlpha = 0f;
            isSkyColor = false;
        }

        public BackGroundStar(BackGroundStar other)
            :this(other.Position)
        { }
        public override object Clone()
        {
            return new BackGroundStar(this);
        }

        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Alpha = StarAlpha;
            base.Draw(drawer);
        }

        public override void Update(GameTime gameTime)
        {
            Console.WriteLine(StarAlpha);
            var angle = Clock.Instance.Angle;
            if (angle > MathHelper.ToRadians(290))
            {
                StarAlpha -= 1 / 200f;
            }
            else if (angle > MathHelper.ToRadians(135))
            {
                StarAlpha += 1 / 200f;
            }
            base.Update(gameTime);
        }
    }
}
