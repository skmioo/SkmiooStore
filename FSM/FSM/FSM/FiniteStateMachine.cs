using System;
using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 有限状态机的核心类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FiniteStateMachine<T>
    {
        //当前状态的跳转条件
        private List<FiniteStateTransaction<T>> stateTransactions = new List<FiniteStateTransaction<T>>();
        //上一次的状态
        private FiniteState<T> lastState;
        //当前状态
        private FiniteState<T> currentState;
        //所有的状态
        private Dictionary<int, FiniteState<T>> allState = new Dictionary<int, FiniteState<T>>();
        //所有状态跳转的条件
        private Dictionary<FiniteState<T>, List<FiniteStateTransaction<T>>> transactions = new Dictionary<FiniteState<T>, List<FiniteStateTransaction<T>>>();
        //跳转状态的参数
        private Dictionary<string, int> intParams = new Dictionary<string, int>();
        private Dictionary<string, bool> boolParams = new Dictionary<string, bool>();
        private Dictionary<string, long> longParams = new Dictionary<string, long>();

        //状态处理器
        private IFiniteStatesProcesser<T> statesProcesser;
        //状态改变处理器
        private IOnFiniteStateChangeProcesser<T> onStateChangeProcesser;

        public FiniteStateMachine(IFiniteStatesProcesser<T> statesProcesser, IOnFiniteStateChangeProcesser<T> onStateChangeProcesser)
        {
            if (statesProcesser == null)
            {
                statesProcesser = new StatesProcesserBase<T>();
            }
            this.statesProcesser = statesProcesser;
            if (onStateChangeProcesser == null)
            {
                onStateChangeProcesser = new OnStateChangeProcesserBase<T>();
            }
            this.onStateChangeProcesser = onStateChangeProcesser;
        }

        /// <summary>
        /// 将一个状态设置为默认状态
        /// </summary>
        /// <param name="state"></param>
        public void setDefaultState(int state)
        {
            FiniteState<T> defaultState = allState[state];
            if (defaultState == null)
            {
                throw new NullReferenceException("Can not found such state " + state + " as default state.");
            }
            setDefaultState(defaultState);
        }

        /// <summary>
        /// 将一个状态设置为默认状态
        /// </summary>
        /// <param name="fightState"></param>
        public void setDefaultState(FiniteState<T> defaultState)
        {
            if (defaultState == null)
            {
                throw new NullReferenceException("Can not found such state " + defaultState + " as default state.");
            }
            currentState = defaultState;
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>

        public void SetInt(string key, int value)
        {
            intParams.Add(key, value);
        }

        public void SetBool(string key, bool value)
        {
            boolParams.Add(key, value);
        }

        /// <summary>
        /// tick方法即是状态机的触发，你只要在每帧中调用这个方法，
        /// 状态机就会自己根据一些输入的情况进行状态跳转，并执行当前状态下应该执行的行为。
        /// </summary>
        /// <param name="t"></param>
        /// <param name="now"></param>
        /// <param name="duration"></param>

        public void Tick(T t, long now, int duration)
        {
            if (lastState != currentState)
            {
                currentState.onInit(this, t, now, duration);
                LogUtil.Log("Change State -- old state=" + lastState + ", new state=" + currentState);
                onStateChangeProcesser.OnChange(this, t, lastState, currentState);
                lastState = currentState;
            }
            currentState.DoState(this, t, now, duration);
            ProcessOnCurrentState(currentState, t, now, duration);
            checkCurrentState();
        }

        public void ProcessOnCurrentState(FiniteState<T> currentState, T t, long now, int duration)
        {
            statesProcesser.Process(this, currentState, t, now, duration);
        }

        private void checkCurrentState()
        {
            FiniteState<T> state = null;
            List<FiniteStateTransaction<T>> list = transactions[currentState];
            foreach (FiniteStateTransaction<T> t in list)
            {
                if (t.Check(intParams, boolParams, longParams))
                {
                    state = t.getDstState();
                    break;
                }
            }
            if (state != null && state != currentState)
            {
                currentState = state;
            }
        }

        /// <summary>
        /// 增加一个状态，如果已存在，则不添加。
        /// </summary>
        /// <param name="state">返回当前状态。</param>
        /// <returns></returns>
        public FiniteState<T> AddState(int state)
        {
            FiniteState<T> fightState = allState[state];
            if (fightState == null)
            {
                fightState = new FiniteState<T>(state);
                allState.Add(state, fightState);

                if (transactions[fightState] == null)
                {
                    transactions.Add(fightState, stateTransactions);
                }
            }
            return fightState;
        }


        public FiniteState<T> AddState(int state, IFiniteStateExecutor<T> executor)
        {
            FiniteState<T> addState = AddState(state);
            addState.SetStateExecutor(executor);
            return addState;
        }

        /**
       * 为两个状态之间添加关联。如果两个状态已经存在关联，则返回该关联。
       * 
       * @param src
       * @param dst
       * @return
       */
        public FiniteStateTransaction<T> AddTranscation(FiniteState<T> src, FiniteState<T> dst)
        {
            List<FiniteStateTransaction<T>> list = transactions[src];
            bool checkContains = true;
            if (list == stateTransactions)
            {
                list = new List<FiniteStateTransaction<T>>();
                transactions.put(src, list);
                checkContains = false;
            }
            FiniteStateTransaction<T> fightTransaction = null;
            if (checkContains)
            {
                foreach (FiniteStateTransaction<T> t in list)
                {
                    if (t.GetDstState() == dst)
                    {
                        fightTransaction = t;
                        break;
                    }
                }
            }
            if (fightTransaction == null)
            {
                fightTransaction = new FiniteStateTransaction<T>(dst);
                list.Add(fightTransaction);
            }
            return fightTransaction;
        }

        /// <summary>
        /// 获取当前状态
        /// </summary>
        /// <returns></returns>
        public FiniteState<T> GetCurrentState()
        {
            return currentState;
        }


        public override string ToString()
        {
            return "FightState<T>Machine [currentState=" + currentState + ", intParams=" + intParams + ", boolParams=" + boolParams + "]";
        }
    }
}
