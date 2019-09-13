using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Def;
using GameJam9.Device;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    abstract class Enemy : Entity
    {
        protected bool moveLock = true;

        public int HP
        {
            get;
            protected set;
        }

        public Enemy(string name, Vector2 position, Point size, int maxHp) 
            : base(name, position, size)
        {
            HP = maxHp;
        }

        public void SetDamage(int value)
        {
            HP -= value;
            IsDead = HP <= 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (moveLock)
            {
                if (IsInScreen())
                {
                    moveLock = false;
                }
                else
                {
                    Velocity = Vector2.Zero;
                }
            }
            base.Update(gameTime);
        }
    }
}
