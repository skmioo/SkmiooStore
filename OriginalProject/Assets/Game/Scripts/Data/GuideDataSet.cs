using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NewData/guideData")]
public class GuideDataSet : ScriptableObject
{
    public enum guideEnum
    {
        /// <summary>
        ///当做测试
        /// 
        /// </summary>
        nothing = -1,
        /// <summary>
        ///进地图
        /// 
        /// </summary>
        inMap = 0,
        /// <summary>
        ///移动
        /// 
        /// </summary>
        move,
        /// <summary>
        ///选择房间
        /// 
        /// </summary>
        selectRoom,
        /// <summary>
        ///进战斗
        /// 
        /// </summary>
        inBattle,
        /// <summary>
        ///战利品
        /// 
        /// </summary>
        trophy,
        /// <summary>
        ///任务结束
        /// 
        /// </summary>
        missionFinish,

        /// <summary>
        ///招募英雄
        /// 
        /// </summary>
        openRecruitingHeros = 10,
        /// <summary>
        ///关闭招募英雄
        /// 
        /// </summary>
        closeRecruitingHeros,
        /// <summary>
        ///出征准备
        /// 
        /// </summary>
        inGoBattle,

        /// <summary>
        ///勋章
        /// 
        /// </summary>
        medal = 15,
        /// <summary>
        ///升级技能
        /// 
        /// </summary>
        skillUp,
        /// <summary>
        ///赌场
        /// 
        /// </summary>
        rollMedal,
        /// <summary>
        ///恢复士气
        /// 
        /// </summary>
        heal,

        /// <summary>
        ///士气变动
        /// </summary>
        morale = 20,
        /// <summary>
        ///士气技能建筑 
        /// </summary>
        moraleSkill,
        /// <summary>
        ///圣物组合
        /// </summary>
        relic,
        /// <summary>
        /// 交互物
        /// </summary>
        interaction,
        /// <summary>
        /// 招募英雄
        /// </summary>
        RecruitingHeros,
        /// <summary>
        /// 濒死
        /// </summary>
        NearDeath,
        /// <summary>
        /// 士气100
        /// </summary>
        morale100,
        /// <summary>
        /// 士气10
        /// </summary>
        morale10,
        /// <summary>
        /// 士气0
        /// </summary>
        morale0,
        /// <summary>
        /// 第二次出征
        /// </summary>
        secondGoBattle,
        /// <summary>
        /// 随机boss
        /// </summary>
        randomBoss,
        /// <summary>
        /// 固定boss
        /// </summary>
        fixedBoss
    }

    [System.Serializable]
    public struct guideStruct
    {
        public string guideName;
        public guideEnum guideType;
        public string guideTitle;
        [TextArea]
        public string guideString;

        public Sprite guideTex;
    }

    public guideStruct[] guideAry;

#if UNITY_EDITOR
    private void OnValidate()
    {
        for (int i = 0; i < guideAry.Length; i++)
            guideAry[i].guideName = guideAry[i].guideType.ToString();
    }
#endif
}
