using System;
using UnityEngine;

namespace Datas
{
    [Serializable]
    /// <summary>
    /// 单个数据对象原始基类
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name;
        /// <summary>
        /// 唯一标识,因大部分数据都会用DIC字典,请尽量使用4位以上唯一值如600001
        /// </summary>
        public int id;
        [TextArea]
        [Tooltip("描述")]
        /// <summary>
        /// 描述
        /// </summary>
        public string describe;

        [TextArea]
        [Tooltip("英文描述")]
        /// <summary>
        /// 英文描述
        /// </summary>
        public string describe_EN;
    }
}
