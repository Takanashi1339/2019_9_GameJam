using GameJam9.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class TempleBlock : Block
    {
        public TempleBlock()
            : base("temple_block" + GameDevice.Instance().GetRandom().Next(1, 4).ToString(), true)
        {
        }

        public override object Clone()
        {
            return new TempleBlock();
        }

        public override void Hit(GameObject gameObject)
        {
        } 
    }
}
