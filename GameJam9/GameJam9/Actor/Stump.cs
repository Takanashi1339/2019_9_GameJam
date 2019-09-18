using GameJam9.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class Stump : Block
    {

        private static string[] parts = new string[]
        {
            "stump1",
            "stump2"
        };

        private int index;
        public Stump(int index) 
            : base(parts[index], true)
        {
            this.index = index;
        }

        public override object Clone()
        {
            return new Stump(index);
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
