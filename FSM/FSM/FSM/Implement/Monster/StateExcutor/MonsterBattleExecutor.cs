namespace FSM
{
    public class MonsterBattleExecutor<T> : IFiniteStateExecutor<T> where T : Monster
    {
        public void execute(FiniteStateMachine<T> finiteStateMachine, T hoster, long now, int duration)
        {
            LogUtil.Log("战斗中,目标剩余血量="+hoster.targetHP);
            hoster.targetHP--;
            if (hoster.targetHP < 0)
            {
                hoster.targetHP = 0;
            }
        }

        public void OnInit(FiniteStateMachine<T> finiteStateMachine, T t, long now, int duration)
        {

        }
    }
    
}
