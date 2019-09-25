using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam9.Def
{
    static class Sounds
    {
        //テクスチャディレクトリのデフォルトパス
        public static readonly string Path = "./Sound/";

        //SE(wav)読み込み対象データ
        public static readonly string[,] SEData = new string[,]
        {
            //{ "se_name", Path },
            { "jump", Path },
            { "hitenemy", Path },
            { "key_get", Path },
            { "door_open", Path },
            { "clock_reverse", Path },

            //必要に応じて自分で追加
        };


        //BGM(MP3)読み込み対象データ
        public static readonly string[,] BGMData = new string[,]
        {
            //{ "bgm_name", Path },
            { "titleBGM" ,Path },
            { "plain" , Path },
            { "forest" ,Path },
            { "temple", Path },

            //必要に応じて自分で追加
        };
    }
}
