using GameJam9.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class ForestBlock : Block
    {
        public ForestBlock()
            : base("forest_block" + GameDevice.Instance().GetRandom().Next(1, 4).ToString(), true)
        {
        }

        public override object Clone()
        {
            return new ForestBlock();
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
