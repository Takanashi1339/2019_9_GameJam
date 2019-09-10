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
            : base("test_block", true)
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
