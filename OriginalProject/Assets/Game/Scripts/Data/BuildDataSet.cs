using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Datas
{
    [System.Serializable]
    public class ExpEquip : EquipInfo
    {
        public List<int> unlockLevels;
    }

    [System.Serializable]
    public class TrainSkillEquip : EquipInfo
    {
        public List<float> discounts;
    }

    [System.Serializable]
    public class HealBoxExtend : EquipInfo
    {
        public List<int> unlockBoxNum;
    }

    [System.Serializable]
    public class ResourceSaver : EquipInfo
    {
        public List<float> discounts;
    }

    [System.Serializable]
    public class EfficiencyEquip : EquipInfo
    {
        public List<int> efficiencies;
    }

    [System.Serializable]
    public class ExtendBoxEquip : EquipInfo
    {
        public List<int> extendNums;
    }

    [CreateAssetMenu(menuName = "NewData/BuildDataSet")]
    [System.Serializable]
    public class BuildDataSet : ScriptableObject
    {
        [Header("初代流放者建筑")]
        public ExpEquip skillUpEquip1;
        public TrainSkillEquip skillUpEquip2;
        [Header("复生池建筑")]
        public HealBoxExtend healEquip1;
        public ResourceSaver healEquip2;
        public EfficiencyEquip healEquip3;
        [Header("起源神树建筑")]
        public ResourceSaver moraleSkillEquip1;
        public ExtendBoxEquip moraleSkillEquip2;
        public ExtendBoxEquip moraleSkillEquip3;
        [Header("流放营地建筑")]
        public ExtendBoxEquip recruitEquip1;
        public ExtendBoxEquip recruitEquip2;
        [Header("黑市建筑")]
        public ResourceSaver shopEquip1;
        public ExtendBoxEquip shopEquip2;
    }
}

