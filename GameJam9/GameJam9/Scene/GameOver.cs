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
    class GameOver : IScene
    {
        private bool isEndFlag;
        private Renderer renderer;

        public GameOver()
        {
            isEndFlag = false;
            renderer = Renderer.Instance;
        }

        public void Draw()
        {
            GameDevice.Instance().GetGraphicsDevice().Clear(Color.Red);
            renderer.Begin();

            renderer.DrawTexture("gameover", Vector2.Zero, Drawer.Default);

            renderer.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
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
        }
    }
}
