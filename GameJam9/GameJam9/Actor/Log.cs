using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class Log : Block
    {
        private static string[] parts = new string[]
        {
            "log1",
            "log2",
            "log3",
            "log4"
        };

        private int index;
        public Log(int index) 
            : base(parts[index], true)
        {
            this.index = index;
        }

        public override object Clone()
        {
            return new Log(index);
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
