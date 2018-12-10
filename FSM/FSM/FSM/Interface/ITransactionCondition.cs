using System.Collections.Generic;

namespace FSM
{
    /// <summary>
    /// 状态切换的条件定义
    /// </summary>
    public interface ITransactionCondition
    {
        bool Check(Dictionary<string, int> intParams, Dictionary<string, bool> boolParams, Dictionary<string, long> longParams);
    }
}
