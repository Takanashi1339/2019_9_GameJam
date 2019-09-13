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
                { "test_enemy", Path},
                { "BG1", Path},
                { "BG2", Path},
                { "BG3", Path},
                { "test_enemy", Path},
                { "grass_block1", Path },
                { "grass_block2", Path },
                { "grass_block3", Path },
                { "forest_block1", Path },
                { "forest_block2", Path },
                { "forest_block3", Path },
                { "dirt_block", Path },
                { "flower1", Path},
                { "flower2", Path},
                { "flower3", Path},
                { "flower4", Path},
                { "flower5", Path},
                { "grass", Path},
                { "grass2", Path},
                { "grass3", Path},
                { "zenmaisou", Path},
                { "bird",Path},

                //必要に応じて自分で追加
            };
    }
}
