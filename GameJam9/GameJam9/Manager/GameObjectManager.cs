﻿using Microsoft.Xna.Framework;
using GameJam9.Actor;
using GameJam9.Manager.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Manager
{
    class GameObjectManager : IGameObjectMediator
    {
        private List<GameObject> addGameObjects;
        private List<GameObject> gameObjects;
        private Map nextMap;
        public Map Map
        {
            get;
            private set;
        }

        public static IGameObjectMediator Instance
        {
            get;
            private set;
        }

        public GameObjectManager()
        {
            Instance = this;
            Initialize();
        }

        public void Initialize()
        {
            var instance = new GameObjectManager();
            Instance = instance;

            if (instance.gameObjects == null)
            {
                instance.gameObjects = new List<GameObject>();
            }
            else
            {
                instance.gameObjects.Clear();
            }

            if (instance.addGameObjects == null)
            {
                instance.addGameObjects = new List<GameObject>();
            }
            else
            {
                instance.addGameObjects.Clear();
            }
        }

        public void Add(GameObject obj)
        {
            addGameObjects.Add(obj);
        }

        public void Add(Map map)
        {
            if (Map == null)
            {
                Map = map;
            }
            else
            {
                nextMap = map;
            }
        }

        public void Update(GameTime gameTime)
        {
            gameObjects.AddRange(addGameObjects);
            addGameObjects.Clear();
            Map.Update(gameTime);
            gameObjects.ForEach(obj => obj.Update(gameTime));
            HitToMap();
            HitToGameObject();

            gameObjects.RemoveAll(obj => obj.IsDead);
            if (nextMap != null)
            {
                Map = nextMap;
                nextMap = null;
            }
        }

        public void Draw()
        {
            Map.Draw();
            gameObjects.ForEach(obj => obj.Draw());
        }

        /// <summary>
        /// T型のGameObjectのListを取得する
        /// </summary>
        /// <typeparam name="T">GameObjectを継承した型引数</typeparam>
        /// <returns>GameObjectManagerに登録されているT型のList</returns>
        public List<T> Find<T>()
            where T : GameObject
        {
            var result = new List<T>();
            foreach (var obj in gameObjects)
            {
                if (obj is T objT)
                {
                    result.Add(objT);
                }
            }
            return result;
        }

        public void HitToMap()
        {
            gameObjects.ForEach(obj => Map.Hit(obj));
        }

        public void HitToGameObject()
        {
            gameObjects.ForEach(obj1 =>
            {
                gameObjects.ForEach(obj2 =>
                {
                    if (obj1.Equals(obj2) ||
                        obj1.IsDead ||
                        obj2.IsDead)
                    {
                        return;
                    }

                    if (obj1.IsCollision(obj2))
                    {
                        obj1.Hit(obj2);
                        obj2.Hit(obj1);
                    }
                });
            });
        }
    }
}