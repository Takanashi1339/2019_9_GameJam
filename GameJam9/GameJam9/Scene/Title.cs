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
    class Title : IScene
    {
        private bool isEndFlag;
        private Renderer renderer;
        private Sound sound;

        public Title()
        {
            isEndFlag = false;
            renderer = Renderer.Instance;
        }

        public void Draw()
        {
            GameDevice.Instance().GetGraphicsDevice().Clear(Color.Aqua);

            renderer.Begin();

            renderer.DrawTexture("title", Vector2.Zero,Drawer.Default);

            renderer.End();

        }

        public void Initialize()
        {
            isEndFlag = false;
            sound = GameDevice.Instance().GetSound();
            sound.PlayBGM("titleBGM");
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return Scene.GamePlay;
        }

        public void Shutdown()
        {
            sound.StopBGM();
        }

        public void Update(GameTime gameTime)
        {
            if (Input.GetKeyTrigger(Keys.Enter))
            {
                //シーン移動
                isEndFlag = true;
            }
        }
    }
}
