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
    class Clock : UI
    {
        private Timer timer;
        private string clockHand = "clock_hand";

        public float Angle
        {
            get;
            private set;
        }
        public static Clock Instance
        {
            get;
            private set;
        }

        public bool IsEnd
        {
            get;
            private set;
        }

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
       

        public Color SkyColor
        {
            get
            {
                var colorIndex = (int) Math.Floor(timer.Location * SkyColors.Length);
                var colorLocation = timer.Location * SkyColors.Length - colorIndex;
                if (colorIndex == SkyColors.Length)
                {
                    IsEnd = true;
                    return SkyColors[0];
                }
                var startColor = SkyColors[colorIndex];
                if(colorIndex == SkyColors.Length - 1)
                {
                    colorIndex = -1;
                }
                var endColor = SkyColors[colorIndex + 1];

                return Color.Lerp(startColor, endColor, colorLocation);
            }
        }

        public Color BackGroundColor
        {
            get
            {
                var color = Color.White;
                var bgColor = SkyColor;
                byte rate = 6;
                color.R -= bgColor.R;
                color.R /= rate;
                color.R += bgColor.R;
                color.G -= bgColor.G;
                color.G /= rate;
                color.G += bgColor.G;
                color.B -= bgColor.B;
                color.B /= rate;
                color.B += bgColor.B;
                return color;
            }
        }


        public Color EntityColor
        {
            get
            {
                var color = Color.White;
                var bgColor = SkyColor;
                byte rate = 2;
                color.R -= bgColor.R;
                color.R /= rate;
                color.R += bgColor.R;
                color.G -= bgColor.G;
                color.G /= rate;
                color.G += bgColor.G;
                color.B -= bgColor.B;
                color.B /= rate;
                color.B += bgColor.B;
                return color;
            }
        }

        public Color BlockColor
        {
            get
            {
                var color = Color.White;
                var bgColor = SkyColor;
                byte rate = 2;
                color.R -= bgColor.R;
                color.R /= rate;
                color.R += bgColor.R;
                color.G -= bgColor.G;
                color.G /= rate;
                color.G += bgColor.G;
                color.B -= bgColor.B;
                color.B /= rate;
                color.B += bgColor.B;
                return color;
            }
        }

        public Clock( Vector2 position)
            : base("clock", position, new Point(128, 128), 1, 1)
        {
            timer = new Timer(60f);
            IsEnd = false;
            Instance = this;
        }

        public override void Update(GameTime gameTime)
        {
            if (!GameObjectManager.Instance.Find<Player>()[0].MoveLock)
            {
                timer.Update(gameTime);
            }
            Angle = MathHelper.ToRadians(360 * timer.Location);
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
            drawer.Rotation = Angle;
            Renderer.Instance.DrawTexture(clockHand, Position, drawer);
        }
    }
}
