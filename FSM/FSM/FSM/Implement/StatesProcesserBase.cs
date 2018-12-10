namespace FSM
{
    public class StatesProcesserBase<T> : IFiniteStatesProcesser<T>
    {
        public virtual void Process(FiniteStateMachine<T> stateMachine, FiniteState<T> currentState, T hoster, long now, int duration)
        {
        }
    }
}
