﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GameJam9.Actor;
using GameJam9.Device;
using GameJam9.Manager;
using GameJam9.Util;

namespace GameJam9.Scene
{
    class GamePlay : IScene
    {
        private bool isEndFlag;
        private Scene next;

        private GameObjectManager gameObjectManager;
        private ParticleManager particleManager;

        public GamePlay()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();
            particleManager = new ParticleManager();
        }

        public void Draw()
        {
            GameDevice.Instance().GetGraphicsDevice().Clear(Color.Blue);

            Renderer.Instance.Begin();
            gameObjectManager.Draw();
            particleManager.Draw();
            Renderer.Instance.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            next = Scene.Ending;

            // csvからマップを読み込む場合
            /*
            var reader = GameDevice.Instance().GetCSVReader();
            reader.Read("map_name.csv");
            var map = new Map(reader.GetData());
            gameObjectManager.Add(map);
            */
        }

        public bool IsEnd()
        {
            return isEndFlag;
        }

        public Scene Next()
        {
            return next; ;
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
                next = Scene.Ending;
            }

            if (Input.GetKeyTrigger(Keys.Space))
            {
                //シーン移動
                isEndFlag = true;
                next = Scene.GameOver;
            }

            gameObjectManager.Update(gameTime);
            particleManager.Update(gameTime);
        }
    }
}