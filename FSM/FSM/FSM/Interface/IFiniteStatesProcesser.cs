namespace FSM
{
    /// <summary>
    /// 状态处理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFiniteStatesProcesser<T>
    {
        void Process(FiniteStateMachine<T> stateMachine, FiniteState<T> currentState, T hoster, long now, int duration);
    }
}
