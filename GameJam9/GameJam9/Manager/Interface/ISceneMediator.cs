using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameJam9.Scene;

namespace GameJam9.Manager.Interface
{
    interface ISceneMediator
    {
        void Change(Scene.Scene name);
        void Add(Scene.Scene name, IScene scene);
    }
}
