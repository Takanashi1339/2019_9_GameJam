using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Device;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    class Clock : UI
    {
        private Timer timer;
        private float angle;
        private string clockHand = "clock_hand";

        //時間別の色
        private static readonly Color[] SkyColors = 
        {
            new Color(155, 177, 177), //朝
            new Color(210, 255, 255), //昼
            new Color(255, 72, 0), //夕方？
            new Color(85, 24, 0),
            new Color(42, 12, 0),
            new Color(0, 0, 0), //夜
        };
       

        public Color BackGroundColor
        {
            get
            {
                var colorIndex = (int) Math.Floor(timer.Location * SkyColors.Length);
                var colorLocation = timer.Location * SkyColors.Length - colorIndex;
                var startColor = SkyColors[colorIndex];
                if(colorIndex == SkyColors.Length - 1)
                {
                    colorIndex = -1;
                }
                var endColor = SkyColors[colorIndex + 1];

                return Color.Lerp(startColor, endColor, colorLocation);
            }
        }
        public Clock( Vector2 position)
            : base("clock", position, new Point(128, 128), 1, 1)
        {
            timer = new Timer(60f);
        }

        public override void Update(GameTime gameTime)
        {
            timer.Update(gameTime);
            angle = MathHelper.ToRadians(360 * timer.Location);
        }

        public Clock(Clock other)
            :this(other.Position)
        { }

        public override object Clone()
        {
            return new Clock(this);
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Draw()
        {
            base.Draw();
            var drawer = Drawer.Default;
            drawer.Origin = Size.ToVector2() / 2;
            drawer.Rotation = angle;
            Renderer.Instance.DrawTexture(clockHand, Position, drawer);
        }
    }
}
