namespace FSM
{
    public class MonsterCharseExecutor<T> : IFiniteStateExecutor<T> where T : Monster
    {
        public void execute(FiniteStateMachine<T> finiteStateMachine, T hoster, long now, int duration)
        {
            hoster.distance2Target -= 250;
            if (hoster.distance2Target < 0)
            {
                hoster.distance2Target = 0;
            }
            LogUtil.Log("追击中，距离=" + hoster.distance2Target);

        }

        public void OnInit(FiniteStateMachine<T> finiteStateMachine, T t, long now, int duration)
        {

        }
    }
}
