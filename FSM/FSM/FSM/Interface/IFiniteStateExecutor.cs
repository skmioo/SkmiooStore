namespace FSM
{
    /// <summary>
    /// 状态机的执行者接口
    /// </summary>
    public interface IFiniteStateExecutor<T>
    {
        void execute(FiniteStateMachine<T> finiteStateMachine, T hoster, long now, int duration);

        void OnInit(FiniteStateMachine<T> finiteStateMachine,T t,long now, int duration);
    }
}
