using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class DirtWall : Block
    {
        public DirtWall()
            : base("dirt_wall", false)
        {
        }

        public override object Clone()
        {
            return new DirtWall();
        }

        public override void Hit(GameObject gameObject)
        {
            ;
        }
    }
}
