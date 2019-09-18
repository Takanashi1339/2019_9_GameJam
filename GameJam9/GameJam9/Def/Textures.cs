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
                { "player_stand", Path },
                { "player_walk", Path },
                { "player_fly", Path },
                { "clock", Path },
                { "clock_hand", Path },
                { "pointer", Path},
                { "test_enemy", Path},
                { "BG1", Path},
                { "BG2", Path},
                { "BG3", Path},
                { "grass_block1", Path },
                { "grass_block2", Path },
                { "grass_block3", Path },
                { "forest_block1", Path },
                { "forest_block2", Path },
                { "forest_block3", Path },
                { "dirt_block", Path },
                { "bird",Path},
                { "flower1", Path },
                { "flower2", Path },
                { "flower3", Path },
                { "flower4", Path },
                { "flower5", Path },
                { "grass", Path },
                { "grass2", Path },
                { "grass3", Path },
                { "zenmaisou", Path },
                { "temple_block1" , Path },
                { "temple_block2", Path },
                { "temple_block3", Path },
                { "magic_enemy" ,Path },
                { "test_bullet", Path },
                {"fox",Path },
                {"caterpillar",Path },
                {"door",Path },
                {"title",Path },
                { "key" ,Path },
                {"gameover",Path },
                {"ending", Path },
                { "attack_magic_enemy", Path },
                { "BGS", Path },

                //必要に応じて自分で追加
            };
    }
}
