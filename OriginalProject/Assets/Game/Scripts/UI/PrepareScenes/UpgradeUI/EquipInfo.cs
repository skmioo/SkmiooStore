using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EquipInfo
{
    public List<Vector2Int> requireMents;
    public List<string> descriptions;
    public List<Limitation> limitations;
}

[System.Serializable]
public struct Limitation
{
    public string name;
    public int value;
}

public enum EquipType
{
    Experience,
    TrainSkill,
    BoxExtend,
    ResourceSaver,
    EfficiencyEquip,
    HeroRecruiting,
    HeroStore,
    RollNum,
    RollStoreBox
}
