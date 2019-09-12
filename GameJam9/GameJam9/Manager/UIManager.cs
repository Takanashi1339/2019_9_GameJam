using GameJam9.Actor;
using GameJam9.Manager.Interface;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Manager
{
    class UIManager : IUIMediator
    {
        private List<UI> addUIs;
        private List<UI> UIs;

        public static IUIMediator Instance
        {
            get;
            private set;
        }

        public UIManager()
        {
            Instance = this;
            Initialize();
        }

        public void Initialize()
        {
            if (UIs == null)
            {
                UIs = new List<UI>();
            }
            else
            {
                UIs.Clear();
            }

            if (addUIs == null)
            {
                addUIs = new List<UI>();
            }
            else
            {
                addUIs.Clear();
            }
        }

        public void Add(UI UI)
        {
            addUIs.Add(UI);
        }

        public void Update(GameTime gameTime)
        {
            UIs.AddRange(addUIs);
            addUIs.Clear();
            UIs.ForEach(p => p.Update(gameTime));
            UIs.RemoveAll(p => p.IsDead);
        }

        public void Draw()
        {
            UIs.ForEach(p => p.Draw());
        }
    }
}
