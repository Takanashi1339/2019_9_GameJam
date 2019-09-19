using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class TutorialBlock : Block
    {
        public TutorialBlock() 
            : base("tutorial", true)
        {
        }

        public override object Clone()
        {
            return new TutorialBlock();
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
