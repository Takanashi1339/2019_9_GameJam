using Microsoft.Xna.Framework;
using GameJam9.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Scene
{
    interface IScene
    {
        void Initialize();//初期化
        void Update(GameTime gameTime);//更新
        void Draw();//描画
        void Shutdown();//終了

        //シーン管理用
        bool IsEnd();//終了チェック
        Scene Next();//次のシーンへ
    }
}
