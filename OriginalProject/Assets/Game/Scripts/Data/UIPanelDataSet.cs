using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Datas
{
    [Serializable]
    /// <summary>
    /// UI面板的数据,主要为了方便UI管理器取值
    /// </summary>
    public class PanelData:DataBase
    { 
        /// <summary>
        /// UI的类型
        /// </summary>
        public UIPanelType panelType;
        /// <summary>
        /// UI的预制体
        /// </summary>
        public AssetReferenceGameObject PanelMode;
        /// <summary>
        /// BG
        /// </summary>
        //public AssetReferenceAtlasedSprite bgSprite;
    }

   
    [CreateAssetMenu(menuName = "NewData/UI/UIPanelData")]
    [Serializable]
    public class UIPanelDataSet : ScriptableObject
    {
        [Header("UI面板基础数据")]
        [SerializeField] public List<PanelData> panelDatas = new List<PanelData>();
    }
}

