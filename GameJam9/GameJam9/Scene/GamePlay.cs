using System;
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
using GameJam9.Def;

namespace GameJam9.Scene
{
    class GamePlay : IScene
    {
        private bool isEndFlag;
        private Scene next;
        private Clock clock;
        private KeyIcon keyIcon;
        private Fade fade;
        private Sound sound;

        private GameObjectManager gameObjectManager;
        private ParticleManager particleManager;
        private UIManager uiManager;
        private BackGround[] backGrounds;
        private MapDictionary.MapType mapType = MapDictionary.MapType.Plain;

        public GamePlay()
        {
            isEndFlag = false;
            gameObjectManager = new GameObjectManager();
            particleManager = new ParticleManager();
            uiManager = new UIManager();
        }

        public void Draw()
        {
            GameDevice.Instance().GetGraphicsDevice().Clear(clock.BackGroundColor);

            Renderer.Instance.Begin();
            Array.ForEach(backGrounds, bg => bg.Draw());
            gameObjectManager.Draw();
            particleManager.Draw();
            fade.Draw();
            uiManager.Draw();
            Renderer.Instance.End();
        }

        public void Initialize()
        {
            isEndFlag = false;
            next = Scene.Ending;
            gameObjectManager.Initialize();
            particleManager.Initialize();
            uiManager.Initialize();
            mapType = MapDictionary.MapType.Plain;
            sound = GameDevice.Instance().GetSound();
            LoadMap(mapType);
        }

        public void LoadMap(MapDictionary.MapType type)
        {
            gameObjectManager.Initialize();
            particleManager.Initialize();
            uiManager.Initialize();
            mapType = type;
            var reader = GameDevice.Instance().GetCSVReader();
            reader.Read(MapDictionary.MapNames[(int)mapType]);
            var map = new Map(reader.GetData());
            gameObjectManager.Add(map);
            keyIcon = new KeyIcon(Vector2.Zero);
            fade = new Fade(Vector2.Zero,Fade.FadeOption.Out);
            clock = new Clock(Vector2.Zero);
            backGrounds = new BackGround[] {
                new BackGround1(Vector2.Zero, mapType),
                new BackGroundStar(Vector2.Zero, mapType),
                new BackGround2(Vector2.Zero, mapType),
                new BackGround3(Vector2.Zero, mapType),
            };
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

            Array.ForEach(backGrounds, bg => bg.Update(gameTime));
            gameObjectManager.Update(gameTime);
            particleManager.Update(gameTime);
            uiManager.Update(gameTime);
            fade.Update(gameTime);

            if (gameObjectManager.Find<Door>()[0].IsEnd)
            {
                mapType++;
                if ((int)mapType == MapDictionary.MapNames.Count())
                {
                    //シーン移動
                    isEndFlag = true;
                    next = Scene.Ending;
                }
                else
                {
                    sound.StopBGM();
                    LoadMap(mapType);
                }
            }

            if(mapType == MapDictionary.MapType.Forest)
            {
                sound.PlayBGM("forest");
            }
            if(mapType == MapDictionary.MapType.Plain)
            {
                sound.PlayBGM("plain");
            }
            if(mapType == MapDictionary.MapType.Temple)
            {
                sound.PlayBGM("temple");
            }
            if (clock.IsEnd)
            {
                //再スタート
                LoadMap(mapType);
            }
        }
    }
}
