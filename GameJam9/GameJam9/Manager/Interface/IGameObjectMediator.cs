using GameJam9.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Manager.Interface
{
    interface IGameObjectMediator
    {
        void Add(GameObject gameObject);

        List<T> Find<T>() where T : GameObject;
    }
}
