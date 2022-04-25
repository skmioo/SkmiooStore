using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

public class MedalInstance : ShopItem
{
    public MedalInfo medalInfo;
}

public class MedalInfo
{
    public int entryID;
    public MedalMode copyMedalMode;

    public MedalInfo(MedalMode medalMode)
    {
        this.copyMedalMode = medalMode;
    }
}
