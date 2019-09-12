using GameJam9.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class RandomGrass : Block
    {
        private static string[] grasses = new string[]
        {
            "flower1",
            "flower2",
            "flower3",
            "flower4",
            "flower5",
            "grass",
            "zenmaisou",
        };

        public RandomGrass() 
            : base("grass", false)
        {
            Name = grasses[GameDevice.Instance().GetRandom().Next(grasses.Length)];
        }

        public override object Clone()
        {
            return new RandomGrass();
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
