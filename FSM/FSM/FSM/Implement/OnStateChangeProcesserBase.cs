namespace FSM
{
    public class OnStateChangeProcesserBase<T> : IOnFiniteStateChangeProcesser<T>
    {
        public virtual void OnChange(FiniteStateMachine<T> stateMachine, T hoster, FiniteState<T> oldState, FiniteState<T> newState)
        {
           
        }
    }
}
