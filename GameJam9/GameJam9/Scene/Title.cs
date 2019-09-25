﻿using System;
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
        private Timer timer;
        private bool pressVisible;

        public Title()
        {
            isEndFlag = false;
            renderer = Renderer.Instance;

        }

        public void Draw()
        {
            GameDevice.Instance().GetGraphicsDevice().Clear(Color.Aqua);

            renderer.Begin();

            renderer.DrawTexture("title", new Vector2(75,0),Drawer.Default);

            if (pressVisible)
            {
                renderer.DrawTexture("press_enter", new Vector2(100, 500), Drawer.Default);
            }


            renderer.End();

        }

        public void Initialize()
        {
            isEndFlag = false;
            sound = GameDevice.Instance().GetSound();
            sound.PlayBGM("titleBGM");
            timer = new Timer(0.4f, true);
            pressVisible = true;
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
            else
            {
                timer.Update(gameTime);
                if(timer.IsTime)
                {
                    pressVisible = !pressVisible;
                }
            }
        }
    }
}
