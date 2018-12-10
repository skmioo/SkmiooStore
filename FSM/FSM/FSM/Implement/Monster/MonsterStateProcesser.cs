using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSM
{
    public class MonsterStateProcesser<T> : StatesProcesserBase<T> where T : Monster
    {


        public override void Process(FiniteStateMachine<T> stateMachine, FiniteState<T> currentState, T hoster, long now, int duration)
        {
            stateMachine.SetBool(Monster.KEY_TARGET_EXIST, hoster.target);
            stateMachine.SetBool(Monster.KEY_TARGET_DEAD, hoster.targetHP == 0);
            stateMachine.SetInt(Monster.KET_DISTANCE, hoster.distance2Target);
        }
    }
}
