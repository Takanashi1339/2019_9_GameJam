using GameJam9.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class TestBlock : Block
    {
        public TestBlock()
            : base("grass_block" + GameDevice.Instance().GetRandom().Next(1, 4).ToString(), true)
        {
        }

        public override object Clone()
        {
            return new TestBlock();
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
