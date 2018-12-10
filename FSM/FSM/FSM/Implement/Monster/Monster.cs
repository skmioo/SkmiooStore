using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    /// <summary>
    /// 怪物
    /// </summary>
    public class Monster
    {
        //key:
        public const string KEY_TARGET_EXIST = "tar";
        public const string KET_DISTANCE = "dis";
        public const string KEY_TARGET_DEAD = "tarDead";

        //state
        public const int STATE_WAIT = 0;
        public const int STATE_BATTLE = 1;
        public const int STATE_CHARSE = 2;

        // 自身属性
        public const int ATTACK_RANGE = 300;
        public bool target;
        public int distance2Target = 800;
        public int targetHP = 3;

       
    }
}
