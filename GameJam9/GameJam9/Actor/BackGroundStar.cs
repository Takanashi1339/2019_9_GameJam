using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Def;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class BackGroundStar : BackGround
    {
        private MapDictionary.MapType type;
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
        public BackGroundStar(Vector2 position, MapDictionary.MapType type) 
            : base("BGS", position, 0.1f)
        {
            this.type = type;
            StarAlpha = 0f;
            isSkyColor = false;
        }

        public BackGroundStar(BackGroundStar other)
            :this(other.Position, other.type)
        { }
        public override object Clone()
        {
            return new BackGroundStar(this);
        }

        public override void Draw()
        {
            if (type == MapDictionary.MapType.Temple)
            {
                return;
            }
            var drawer = Drawer.Default;
            drawer.Alpha = StarAlpha;
            base.Draw(drawer);
        }

        public override void Update(GameTime gameTime)
        {
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
