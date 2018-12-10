using System;

namespace FSM
{
    public class MonsterWaitExecutor<T> : IFiniteStateExecutor<T> where T : Monster
    {
        public void execute(FiniteStateMachine<T> finiteStateMachine, T hoster, long now, int duration)
        {
            LogUtil.Log("待机中");
            hoster.target = true;
        }

        public void OnInit(FiniteStateMachine<T> finiteStateMachine, T t, long now, int duration)
        {
            
        }
    }
}
