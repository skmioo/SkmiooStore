using Datas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResPanel : MonoBehaviour
{
    public Text moneyText, crystalText, fruitText, lightStoneText, starFireText, boneText;
    private static ResPanel instance;
    private Dictionary<string, ObjData> resObjDic;
    private ModeData modeData;

    public static ResPanel Instance
    {
        get => instance;
    }

    public int Money => modeData.moneyMode.count;
    public int Crystal => modeData.crystalMode.count;
    public int Fruit => modeData.crystalMode.count;
    public int LightStone => modeData.lightStoneMode.count;
    public int StarFire => modeData.starFireMode.count;
    public int Bone => modeData.boneMode.count;

    private void Awake()
    {
        instance = this;
        modeData = DataManager.Instance.modeData;
        resObjDic = new Dictionary<string, ObjData>();
        DataSetItem objDataItem = DataManager.Instance.GetData("ObjData");
        ObjDataSet objData = objDataItem.scriptableObject as ObjDataSet;
        foreach (var obj in objData.porpDatas)
        {
            if (obj.levelType.Equals(LevelType.资源))
            {
                resObjDic.Add(obj.name, obj);
            }
        }
        ChangeResource();

    }
    /// <summary>
    /// 增减资源
    /// </summary>
    /// <param name="money">鳞片</param>
    /// <param name="crystal">影晶</param>
    /// <param name="fruit">虫果</param>
    /// <param name="lightStone">耀石</param>
    /// <param name="starFire">星火</param>
    /// <param name="bone">亡骨</param>
    public void ChangeResource(int money=0,int crystal=0,int fruit=0,int lightStone=0,int starFire=0,int bone=0)
    {
       if(money < 0) AudioManager.Instance.PlayAudio(AudioName.COINS_Rattle_01_mono, AudioType.Common);
        modeData.moneyMode.count += money;
        modeData.crystalMode.count += crystal;
        modeData.fruitMode.count += fruit;
        modeData.lightStoneMode.count += lightStone;
        modeData.starFireMode.count += starFire;
        modeData.boneMode.count += bone;
        moneyText.text = modeData.moneyMode.count.ToString();
        crystalText.text = modeData.crystalMode.count.ToString();
        fruitText.text = modeData.fruitMode.count.ToString();
        lightStoneText.text = modeData.lightStoneMode.count.ToString();
        starFireText.text = modeData.starFireMode.count.ToString();
        boneText.text = modeData.boneMode.count.ToString();
    }
}
