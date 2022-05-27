using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UYMO
{
    public class LayerIndex
    {
        public const int Water = 4;
        public const int UI = 5;
        public const int MapSurface1 = 8;
        public const int MapSurface2 = 9;
        /// <summary>
        /// 地表碰撞层
        /// </summary>
        public const int MapSurface3 = 10;
        public const int Creature = 11;
        public const int User = 12;
        public const int UIEffect = 13;
        public const int HideUI = 14;
        public const int UICreature = 15;
        public const int RefractionEffect = 16;
        public const int WorldSpaceUI = 17;
        public const int PassCheck = 18;
        /// <summary>
        /// 地表类型定义层
        /// </summary>
        public const int MapSurface4 = 19;
        public const int NoClip = 31;
        public const int ALL = 0x7fffffff;
    }
}
