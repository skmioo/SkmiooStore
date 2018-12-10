namespace FSM
{
    /// <summary>
    /// FiniteState 有限状态的基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FiniteState<T>
    {
        private int state;
        private IFiniteStateExecutor<T> stateExecutor;

        /// <summary>
        /// 初始化 有限状态
        /// </summary>
        /// <param name="state"></param>
        public FiniteState(int state)
        {
            this.state = state;
        }

        /// <summary>
        /// 初始化 有限状态的执行者
        /// </summary>
        /// <param name="stateExecutor"></param>
        public void SetStateExecutor(IFiniteStateExecutor<T> stateExecutor)
        {
            this.stateExecutor = stateExecutor;
        }

        /// <summary>
        /// 有限状态的执行者的初始化
        /// </summary>
        /// <param name="stateMac"></param>
        /// <param name="t"></param>
        /// <param name="now"></param>
        /// <param name="duration"></param>
        public void onInit(FiniteStateMachine<T> stateMac, T t, long now, int duration)
        {
            stateExecutor.OnInit(stateMac, t, now, duration);
        }

        /// <summary>
        /// 执行状态
        /// </summary>
        /// <param name="finiteStateMachine"></param>
        /// <param name="t"></param>
        /// <param name="now"></param>
        /// <param name="duration"></param>
        public void DoState(FiniteStateMachine<T> stateMac, T t, long now, int duration)
        {
            stateExecutor.execute(stateMac, t, now, duration);
        }


        /// <summary>
        /// 返回状态值
        /// </summary>
        /// <returns></returns>
        public int GetState()
        {
            return state;
        }

        public override string ToString()
        {
            return "FiniteState [state=" + state + "]";
        }

    }
}
