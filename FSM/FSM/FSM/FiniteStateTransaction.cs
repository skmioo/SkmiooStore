using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态跳转类
    /// </summary>
    public class FiniteStateTransaction<T>
    {
        private List<ITransactionCondition> list = new List<ITransactionCondition>();
        private FiniteState<T> dst;

        public FiniteStateTransaction(FiniteState<T> dst)
        {
            this.dst = dst;
        }

        public void AddCondition(ITransactionCondition fightCondition)
        {
            list.Add(fightCondition);
        }

        /// <summary>
        /// check
        /// </summary>
        /// <param name="intParams"></param>
        /// <param name="boolParams"></param>
        /// <param name="longParams"></param>
        /// <returns></returns>
        public bool Check(Dictionary<string, int> intParams, Dictionary<string, bool> boolParams, Dictionary<string, long> longParams)
        {
            foreach (ITransactionCondition c in list)
            {
                if (!c.Check(intParams, boolParams, longParams))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// dst
        /// </summary>
        /// <returns></returns>
        public FiniteState<T> GetDstState()
        {
            return dst;
        }

    }
}
