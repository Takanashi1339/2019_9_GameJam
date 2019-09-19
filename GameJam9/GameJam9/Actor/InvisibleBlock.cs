using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class InvisibleBlock : Block
    {
        public InvisibleBlock() 
            : base("", true)
        {
        }

        public override object Clone()
        {
            return new InvisibleBlock();
        }

        public override void Hit(GameObject gameObject)
        {
        }

        public override void Draw()
        {
        }
    }
}
