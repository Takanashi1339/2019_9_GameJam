using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Manager;
using GameJam9.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameJam9.Actor
{
    class MagicEnemy : Enemy
    {
        private Animation animation;
        private float walkSpeed = -1f;
        private Vector2 rotate;
        private Timer timer;

        public MagicEnemy( Vector2 position)
            : base("magic_enemy", position, new Point(32, 64), 20)
        {
            timer = new Timer(2f, true);
        }

        public void AnimationInitialize()
        {
            Name = "magic_enemy";
            animation = new Animation(Size, 4, 0.25f);
        }
        public MagicEnemy(MagicEnemy other)
            :this(other.Position)
        { }

        public override Entity Spawn(Map map, Vector2 position)
        {
            animation = new Animation(Size, 4, 0.25f);
            return base.Spawn(map, position);
        }

        public override object Clone()
        {
            return new MagicEnemy(this);
        }

        public override void Update(GameTime gameTime)
        {
            var PlayerPosition = GameObjectManager.Instance.Find<Player>()[0].Position;
            rotate = PlayerPosition - Position;
            rotate.Normalize();
            timer.Update(gameTime);
            if(timer.Location == 0.5f)
            {
                Name = "attack_" + Name;
                animation = new Animation(Size, 4, 0.25f, false);
            }
            if (timer.IsTime)
            {
                new TestBullet(Position, rotate).Spawn(GameObjectManager.Instance.Map, Position);

            }
            if (animation.IsEnd)
            {
                AnimationInitialize();
            }
            Velocity = new Vector2(walkSpeed, Velocity.Y);
            animation.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Hit(GameObject gameObject)
        {
            if(gameObject is Block block && block.IsSolid)
            {
                var direction = CheckDirection(block);
                if(direction == Direction.Left || direction == Direction.Right)
                {
                    walkSpeed *= -1;
                }
            }
            base.Hit(gameObject);
        }
        public override void Draw()
        {
            var drawer = Drawer.Default;
            drawer.Rectangle = animation.GetRectangle();
            if(walkSpeed > 0)
            {
                drawer.SpriteEffects = SpriteEffects.FlipHorizontally;
            }
            base.Draw(drawer);
        }

    }
}
