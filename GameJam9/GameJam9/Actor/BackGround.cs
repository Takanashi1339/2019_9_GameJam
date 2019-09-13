using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Def;
using GameJam9.Device;
using GameJam9.Manager;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    abstract class BackGround : GameObject
    {
        protected float speed;

        public BackGround(string name, Vector2 position, float speed) 
            : base(name, position, new Point(Screen.Width, Screen.Height))
        {
            this.speed = speed;
        }
        
        protected override void Draw(Drawer drawer)
        {
            drawer.Color = Clock.Instance.BackGroundColor;
            Renderer.Instance.DrawTexture(Name, Position + new Vector2(Size.X, 0), drawer);
            base.Draw(drawer);
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2((GameDevice.Instance().DisplayModify.X * speed ) % Size.X, 0);
        }
        public override void Hit(GameObject gameObject)
        {
        }
    }
}
