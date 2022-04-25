using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace Datas
{
    //功能由装载到预制体上的脚本去实现,这里做这个数据主要是可以承接不同的keys,
    [Serializable]
    public class AddRoomData:DataBase
    {
        //房间附加品模型
        public AssetReferenceGameObject addRoomModel;
        //房间附加品类型
        public AddRoomType addRoomType;

        /// <summary>
        /// 触发物携带的钥匙,如怪物的ID
        /// </summary>
        public List<int> triggerKeys;

        /// <summary>
        /// 触发后--成功时的奖励,可空--,
        /// </summary>
        public List<int> rewards;

    }

    [CreateAssetMenu(menuName = "NewData/Map/MapAddRoomData")]
    [Serializable]
    public class MapAddRoomDataSet : ScriptableObject
    {
        [Header("房间基础数据")]
        [SerializeField] public List<AddRoomData> addRoomData = new List<AddRoomData>();
    }


}

