using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Util;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    abstract class Block : GameObject
    {
        //当たり判定を持つかどうか
        public bool IsSolid
        {
            get;
            protected set;
        }

        public Block(string name, bool isSolid)
            : base(name, Vector2.Zero, new Point(Map.BlockSize, Map.BlockSize))
        {
            IsSolid = isSolid;
        }
        protected override void Draw(Drawer drawer)
        {
            drawer.Color = Clock.Instance.BlockColor;
            drawer.DisplayModify = true;
            base.Draw(drawer);
        }


        public virtual Block Set(Map map, Vector2 position)
        {
            Position = position;
            return this;
        }
    }
}
