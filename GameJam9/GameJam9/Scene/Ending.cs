using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameJam9.Device;
using GameJam9.Util;

namespace GameJam9.Scene
{
    class Ending : IScene
    {
        private bool isEndFlag;
        private Renderer renderer;
        private int star;
        private float Alpha
        {
            get
            {
                return (float)Math.Sin((float)star / 10f);
            }
        }

        public Ending()
        {
            isEndFlag = false;
            renderer = Renderer.Instance;
        }

        public void Draw()
        {
            GameDevice.Instance().GetGraphicsDevice().Clear(Color.Black);
            renderer.Begin();
            var drawer = Drawer.Default;
            drawer.Alpha = Alpha;
            renderer.DrawTexture("BGS", Vector2.Zero, drawer);
            renderer.DrawTexture("ending", Vector2.Zero, Drawer.Default);

            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            star = 0;

        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.Title;
        }

        public void Shutdown()
        {
        }

        public void Update(GameTime gameTime)
        {
            if (Input.GetKeyTrigger(Keys.Enter))
            {
                //シーン移動
                isEndFlag = true;
            }
            else
            {
                star++;
            }
        }
    }
}
