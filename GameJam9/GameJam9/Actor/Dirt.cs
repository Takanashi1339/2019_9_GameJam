using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class Dirt : Block
    {
        public Dirt()
            : base("dirt_block", true)
        {
        }

        public override object Clone()
        {
            return new Dirt();
        }

        public override void Hit(GameObject gameObject)
        {
            ;
        }
    }
}
