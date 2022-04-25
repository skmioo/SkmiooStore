using System;
using System.Collections.Generic;
using UnityEngine;


namespace Datas
{
    /// <summary>
    /// 数据集
    /// </summary>
    [Serializable] 
    public class DataSetItem:DataBase
    {
        /// <summary>
        /// 基础数据对象
        /// </summary>
        public ScriptableObject scriptableObject;
        
    }

    [CreateAssetMenu(menuName = "NewData/DataSet")]
    [Serializable]
    public class DataSet : ScriptableObject
    {
        public string str = "若需要增加,scriptableObjects的数量调大1个值就行了";
        [Header("基础数据集")]
        [SerializeField] public List<DataSetItem> scriptableObjects = new List<DataSetItem>();
    }

}


