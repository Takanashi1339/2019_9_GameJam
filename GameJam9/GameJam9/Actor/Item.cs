using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameJam9.Actor
{
    abstract class Item
    {

        public Point Size
        {
            get;
            protected set;
        }

        public string Name
        {
            get;
            protected set;
        }

        public Item(string name, Point size)
        {
            Name = name;
            Size = size;
        }
    }
}
