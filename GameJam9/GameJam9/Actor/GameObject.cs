using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameJam9.Device;
using GameJam9.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    abstract class GameObject : ICloneable
    {
        public Vector2 Positon
        {
            get;
            set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public Point Size
        {
            get;
        }

        public Vector2 Velocity
        {
            get;
            protected set;
        }

        public int Width
        {
            get
            {
                return Size.X;
            }
        }
        public int Height
        {
            get
            {
                return Size.Y;
            }
        }

        public bool IsDead
        {
            get;
            protected set;
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Positon.ToPoint(), Size);
            }
        }

        /// <summary>
        /// ゲームオブジェクト
        /// </summary>
        /// <param name="name">アセット名</param>
        /// <param name="position">座標</param>
        /// <param name="size">サイズ</param>
        public GameObject(string name, Vector2 position, Point size)
        {
            Name = name;
            Positon = position;
            Size = size;
            Initialize();
        }

        public abstract object Clone();

        public virtual void Initialize()
        {
            Velocity = Vector2.Zero;
        }

        public virtual void Update(GameTime gameTime)
        {
            Positon += Velocity;
        }

        public bool IsCollision(GameObject other)
        {
            return Rectangle.Intersects(other.Rectangle);
        }

        public abstract void Hit(GameObject gameObject);

        /// <summary>
        /// 外部から呼び出すのはこちら
        /// </summary>
        public virtual void Draw()
        {
            Draw(Drawer.Default);
        }

        /// <summary>
        /// 継承先から描画する用
        /// 引数無しのDrawメソッドから呼び出す
        /// </summary>
        /// <param name="drawer">Drawer</param>
        protected void Draw(Drawer drawer)
        {
            Renderer.Instance.DrawTexture(Name, Positon, drawer);
        }
    }
}
