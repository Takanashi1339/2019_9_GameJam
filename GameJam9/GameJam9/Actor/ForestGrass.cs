using GameJam9.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Actor
{
    class ForestGrass : Block
    {
        private static string[] grasses = new string[]
        {
            "grass2",
            "grass3",
            "mushroom",
            "zenmaisou",
            "zenmaisou",
            "zenmaisou",
        };

        public ForestGrass()
            : base("grass", false)
        {
            Name = grasses[GameDevice.Instance().GetRandom().Next(grasses.Length)];
        }

        public override object Clone()
        {
            return new ForestGrass();
        }

        public override void Hit(GameObject gameObject)
        {
        }
    }
}
