﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using GameJam9.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Device
{
    /// <summary>
    /// seald => 継承不可
    /// </summary>
    sealed class GameDevice
    {
        private Sound sound;
        private static Random random;
        private ContentManager content;
        private GraphicsDevice graphics;
        private GameTime gameTime;
        private CSVReader reader;

        private Vector2 displayModify;

        private static GameDevice instance;

        private GameDevice(ContentManager content, GraphicsDevice graphics)
        {
            sound = new Sound(content);
            random = new Random();
            this.content = content;
            this.graphics = graphics;
            displayModify = Vector2.Zero;
            reader = new CSVReader();
        }

        public static GameDevice Instance(ContentManager content, GraphicsDevice graphics)
        {
            if (instance == null)
            {
                instance = new GameDevice(content, graphics);
            }
            return instance;
        }

        public static GameDevice Instance()
        {
            return instance;
        }

        public void Initialize()
        {

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="gameTime">ゲーム時間</param>
        public void Update(GameTime gameTime)
        {
            //デバイスで絶対に１回のみ更新が必要なモノ
            Input.Update();
            this.gameTime = gameTime;
        }

        /// <summary>
        /// サウンドオブジェクトの取得
        /// </summary>
        /// <returns>サウンドオブジェクト</returns>
        public Sound GetSound()
        {
            return sound;
        }

        /// <summary>
        /// サウンドオブジェクトの取得
        /// </summary>
        /// <returns>サウンドオブジェクト</returns>
        public CSVReader GetCSVReader()
        {
            return reader;
        }

        /// <summary>
        /// 乱数オブジェクトの取得
        /// </summary>
        /// <returns>乱数オブジェクト</returns>
        public Random GetRandom()
        {
            return random;
        }

        /// <summary>
        /// コンテンツ管理者の取得
        /// </summary>
        /// <returns>コンテンツ管理者オブジェクト</returns>
        public ContentManager GetContentManager()
        {
            return content;
        }

        /// <summary>
        /// グラフィックデバイスの取得
        /// </summary>
        /// <returns>グラフィックデバイスオブジェクト</returns>
        public GraphicsDevice GetGraphicsDevice()
        {
            return graphics;
        }

        /// <summary>
        /// ゲーム時間の取得
        /// </summary>
        /// <returns></returns>
        public GameTime GetGameTime()
        {
            return gameTime;
        }

        public void SetDisplayModify(Vector2 position)
        {
            this.displayModify = position;
        }

        public Vector2 GetDisplayModify()
        {
            return displayModify;
        }
    }
}