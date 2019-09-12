using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Def
{
    static class Textures
    {
        //テクスチャディレクトリのデフォルトパス
        private static readonly string Path = "./Texture/";


        //読み込み対象データ
        public static readonly string[,] Data = new string[,]
            {
                //{ "texture_name", Path},
                { "test_block", Path },
                { "test_player", Path},
                { "clock", Path },
                { "clock_hand", Path },
                { "test_enemy", Path}

                //必要に応じて自分で追加
            };
    }
}
