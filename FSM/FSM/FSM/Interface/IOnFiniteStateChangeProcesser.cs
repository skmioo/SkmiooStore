namespace FSM
{
    /// <summary>
    /// 状态改变处理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOnFiniteStateChangeProcesser<T>
    {
        void OnChange(FiniteStateMachine<T> stateMachine, T hoster, FiniteState<T> oldState, FiniteState<T> newState);
    }
}
