using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 翻译选项控制类
/// </summary>
public static class LanguageController
{
    /// <summary>
    /// 英文翻译
    /// </summary>
    // static Dictionary<string, string> LangMap_CN1 = new Dictionary<string, string>{
    // };

    static Dictionary<string, string> LangMap_EN1 = new Dictionary<string, string>{
        {"语言", "Language"},
        {"继续放逐", "Continue"},
        {"新的起源", "New Origin"},
        {"开始放逐", "Banish"},
        {"存档", "File"},
        {"请为此次放逐命名", "Name the banishment"},
        {"设置", "Options"},
        {"制作组", "Production team"},
        {"退出", "Exit"},
        {"控制选项", "Control"},
        {"图像选项", "Video"},
        {"音频选项", "Audio"},
        {"其他选项", "Other"},
        {"帮助", "Help"},
        {"返回主界面", "Go Back"},
        {"退出游戏", "Exit"},
        {"全屏游戏", "Full screen"},
        {"窗口最大化", "Borderless windowed"},
        {"窗口模式", "Windowed"},
        {"分辨率", "Resolution"},
        {"键盘设置", "Keybroad"},
        {"在任意画面打开帮助界面", "Help"},
        {"查看英雄人物页", "Hero's Page"},
        {"浏览人物页时切换到上一个英雄", "Last Hero"},
        {"浏览人物页时切换到下一个英雄", "Next Hero"},
        {"向左移动（任务中）", "Move left(In mission)"},
        {"向右移动（任务中）", "Move right(In mission)"},
        {"快速施放第1个技能（任务中）", "First skill(In mission)"},
        {"快速施放第2个技能（任务中）", "Second skill(In mission)"},
        {"快速施放第3个技能（任务中）", "Third skill(In mission)"},
        {"快速施放第4个技能（任务中）", "Forth skill(In mission)"},
        {"快速施放士气技能（任务中）", "Morale skill(In mission)"},
        {"换位（任务中）", "Switch position(In mission)"},
        {"战利品窗口显示时，全部拿走（任务中）", "Take all loots(In mission)"},
        {"在地图和背包之间切换（任务中）", "Map/Bag switch(In mission)"},
        {"进入下一个房间/与交互物互动（任务中）", "Enter/Interact(In mission)"},
        {"静音", "Mute"},
        {"后台静音", "Mute in background"},
        {"主音量", "Master volume"},
        {"音效音量", "Effect volume"},
        {"确定", "Confirm"},
        {"取消", "Cancel"},

        // 出征任务
        {"地图大小", "Size"},
        {"地图难度", "Difficulty"},
        {"镂空之地", "Hollow ground"},
        {"冥河矿洞", "Styx mine"},
        {"狭小", "Narrow"},
        {"宽敞", "Spacious"},
        {"人迹罕至", "Uncharted"},
        {"危机四伏", "Menace"},
        {"艰难险阻", "Difficulties and obstacles"},
        {"扫荡", "Mopping up"},
        {"侦察", "investigate"},
        {"营救人物", "Rescue"},
        {"布置陷阱", "Set Trap"},
        {"BOSS任务", "BOSS mission"},
        {"突袭", "Sudden Strike"},
        {"清剿", "Suppress"},
        {"清理", "Clean up"},
        {"搜救", "Search and Rescue"},
        {"救援", "Rescue"},
        {"杀死主祭司以利", " Kill Eli the chief priest"},
        {"杀死粘稠圣者", "Kill the Viscous Saint"},
        {"出征", "Fight"},
        {"奖励", "Award"},

        // 物品
        {"鳞甲兽肉干", "Jerky of Squamate"},
        {"食腐蛆虫的唾液", "Maggot saliva"},
        {"地锦草", "Lichens"},
        {"永黯花", "Dark flower"},
        {"低语蘑菇", "Whisper mushroom"},
        {"鳞片", "Scales"},
        {"影晶", "Shadow crystal"},
        {"虫果", "Insect fruit"},
        {"耀石", "Obsidian"},
        {"星火", "Starfire"},
        {"亡骨", "Monster bone"},
        {"疗愈经文", "Healing scriptures"},
        {"提振经文", "Boost Scripture"},
        {"未知经文", "Unknown Scripture"},

        // 饰品
        {"“初始”之舌", "\"Initial\" tongue"},
        {"缄默圣经", "Silent Bible"},
        {"叹息之墙", "Wailing wall"},
        {"行刑剃刀", "Execution razor"},
        {"死亡骰盅", "Death dice"},
        {"异化之胫", "Alienate shin"},
        {"异化之爪", "Alienate claw"},
        {"无柄匕首", "Handleless dagger"},
        {"异化浆果", "Alienate berry"},
        {"行者", "Pedestrian"},
        {"饮血圣杯", "Grail of Blood"},
        {"畏死假面", "Death fearing mask"},
        {"恶语经文", "Vicious Scripture"},
        {"沉重指虎", "Heavy brass kunckle"},
        {"源生植物", "Originate flora"},
        {"鳞甲盾", "Scaly shield"},
        {"狂暴护符", "Rampage amulet"},
        {"救赎护符", "Redemption amulet"},
        {"眩晕护符", "Stun amulet"},
        {"防御护符", "Defense amulet"},
        {"闪避护符", "Dodge amulet"},
        {"灵巧护符", "Dexterity amulet"},
        {"复仇护符", "Revenge amulet"},
        {"过期杀虫剂", "Expired insecticide"},
        {"夜之花", "Flowers of the night"},
        {"水之花", "Flower of the water"},
        {"瘴之花", "Flower of the Miasma"},
        {"石之花", "Flower of the stone"},

        // 圣物
        {"《初章》", "《Foreword》"},
        {"《希望》", "《Hope》"},
        {"《惊变》", "《Change》"},
        {"《新人》", "《New blood》"},
        {"《终章》", "《Epilogue》"},
        {"守望者", "Watchmen"},
        {"银翼杀手/银翼杀手2049", "Blade Runner/Blade Runner2049"},
        {"两杆大烟枪", "Lock, Stock and Two Smoking Barrels"},
        {"魔兽争霸4", "Warcraft IV"},
        {"半条命3", "Half-life III"},
        {"三体", "The three body problem"},
        {"乌合之众", "The Crowd： A Study of the Popular Mind"},
        {"时间简史", "A Brief History of Time"},
        {"AJ", "Air Jordan"},
        {"古董纸钞", "Antique banknotes"},

        // 勋章
        {"白骨勋章", "Skeleton Medal"},
        {"青石勋章", "Bluestone Medal"},
        {"赤银勋章", "Red silver Medal"},
        {"黑金勋章", "Black gold Medal"},
        {"血髓勋章", "Blood marrow Medal"},
        {"原黯勋章", "Original dark Medal"},

#region 建筑
        {"勋章", "Medal"},
        {"饰品", "Ornaments"},
        {"是否出售", "Whether to sell"},
        {"换取", "Exchange"},

        //建筑
        {"先决条件:", "prerequisite:"},
        {"箴戒酒馆", "Exhortation Tavern"},
        {"新维加斯", "New Vegas"},
        {"残骸旅社", "Wreckage Inn"},
        {"起源神树", "Tree of Origin"},
        {"葬骨地", "Boneyard"},
        {"黑市", "Black Market"},
        {"辉光圣所", "Sanctuary"},
        {"启程", "Launch"},

        //招募建筑
        {"升级流亡营地可以增加每次招募的英雄数量或增加英雄列表上限", "Upgrade to increase the number of heroes recruited each time or to upper the limit of the hero list"},
        {"营地扩张", "Expansion"},
        {"壮大队伍", "Strengthen"},
        {"增加可招募英雄数量，该增加将在下次任务结束后生效", "Increase the number of heros,，take effect after next mission finished"},
        {"增加英雄列表上限", "Increase the upper limit of hero list"},
        {"营地已无可招募人员，等到下一次放逐后再来进行招募吧", "There are no recruits left in camp. Wait until the next exile for recruitment"},

        //初代流亡者建筑
        {"升级初代流放者允许你训练技能到更高级", "Upgrade to improve your skill to higher level."},
        {"战斗心得", "Combat Experience"},
        {"训练技法", "Training techniques"},
        {"解锁更高级的战斗技能", "Unlock advanced combative skills"},
        {"减少升级费用", "Reduce upgrade costs"},
        {"拖入英雄", "drag in the hero"},

        //黑市建筑
        {"升级黑市能增加可购买的饰品数量以及降低他们的价钱", "Upgrade to increase the number of goods and decrease their prices"},
        {"黑市网络", "Market supply"},
        {"渠道扩张", "Channle expension"},
        {"增加饰品刷新数量", "Increase the number of goods to"},
        {"饰品已购买一空，请下次放逐后再来", "No more goods, come back next time."},
        {"减少购买饰品花费的资源", "Reduce the resources spent on buying a ornament"},

        //新维加斯建筑
        {"拖入勋章", "Drag medal in"},
        {"获得", "You win the"},
        {"LV勋章", "LV medal"},
        {"没获得任何奖励", "didn't get any awards"},
        {"份", "part"},
        {"转动", "turn"},

        //恢复士气建筑
        {"升级复生池可以解锁治疗栏位，减少治疗花费", "Upgrade to unlock treatment field and decrease the cost"},
        {"开源", "Increase revenue"},
        {"节流", "reduce expenditure"},
        {"透支", "Overdraft"},
        {"增加更多恢复栏位", "Add more treatment fields"},
        {"减少花费的资源", "Reduce the cost of treatment"},
        {"增加恢复的士气数值", "Recover more morales"},
        {"需要开源等级", "Need Increase revenue level"},
        {"英雄可出征，但维持原士气且已花费资源不退回，是否确定？", "Heros can go on battle but the morale will stay same and source will not refund.Are you sure?"},

        //起源神树建筑
        {"抽取", "Extraction"},
        {"已装备", "Equipped"},
        {"未装备", "Not equipped"},
        {"放置装备", "Place equiption"},
        {"随机栏", "Random field"},
        {"升级起源神树可增加每次抽取技能数或解锁储备区及装备区技能栏位", "Upgrade to increase skill extraction time or unlock store and equipment skill field"},
        {"压榨", "Exploit"},
        {"迸发", "Burst"},
        {"减少抽取费用", "Decrease cost of extraction"},
        {"增加抽取技能数", "Increase number of extracted skill"},
        {"被替换技能将消失", "The replaced skill will disappear"},
        {"确定替换", "Whether to replace"},
        {"为", "to"},
        {"请招募英雄", "Please recruit heroes"},

        //无光回廊建筑
        {"放置圣物", "Place haildom"},
        {"力量源自羁绊，真理藏于荒谬", "Power comes from bond, Truth hides in absurdity"},
        {"你还未领悟力量的真谛", "You have not yet learned the true meaning of power"},
        {"你确定?", "You sure ?"},
#endregion
    };

    //static Dictionary<string, string> LangMap_CN2 = new Dictionary<string, string>{
    //};
    
    //static Dictionary<string, string> LangMap_EN2 = new Dictionary<string, string>{
    //    { "攻击","Attact"},
    //    {  "减伤","Damage Reduction"},
    //    { "精准"  ,"Experise"},
    //    { "速度"  ,"Speed"},
    //    { "闪避"  ,"Dodge"},
    //    { "暴击"  ,"Critical Strike"},
    //    { "中毒抗性"    ,"Poison resistance"},
    //    { "眩晕抗性"    ,"Stun Resistance"},
    //    { "流血抗性"    ,"Bleed Resistance"},
    //    { "死亡抗性"    ,"Death Resistance"},
    //    { "位移抗性"    ,"Move Resistance"},
    //    { "暴击抗性"    ,"Critical Resistance"},
    //    { "天赋"  ,"Masteries"},
    //    { "触发条件"    ,"Trigger Condition"},
    //    { "战斗中流血结束后"    ,"In combat, after bleeding"},
    //    { "战斗中被治疗3次后"   ,"In combat,healed 3 times"},
    //    { "战斗中位移2次后"    ,"In combat, moved 2times"},
    //    { "战斗中释放治疗技能后"  ,"In combat, casted healing skill"},
    //    { "战斗中被暴击后" ,"In combat, taken critical strike"},
    //    { "秩序效果"    ,"Order"},
    //    { "获得额外行动点" ,"Gain extra action point"}

    // };

    //static Dictionary<string, Dictionary<LanguageOption, string>> LangMap_EN2_1 = new Dictionary<string, Dictionary<LanguageOption, string>> {
    //    {
    //        "角色基础属性_文字描述_攻击",
    //        new Dictionary<LanguageOption, string>{ { LanguageOption.简体中文, "攻击" }, { LanguageOption.English, "Attact" } }
    //    },
    //     {
    //        "角色基础属性_文字描述_减伤",
    //        new Dictionary<LanguageOption, string>{ { LanguageOption.简体中文, "减伤" }, { LanguageOption.English, "Damage Reduction" } }
    //    },
    //    {
    //        "角色基础属性_文字描述_精准",
    //        new Dictionary<LanguageOption, string>{ { LanguageOption.简体中文, "精准" }, { LanguageOption.English, "Experise" } }
    //    },
    //    {
    //        "角色基础属性_文字描述_速度",
    //        new Dictionary<LanguageOption, string>{ { LanguageOption.简体中文, "速度" }, { LanguageOption.English, "Speed" } }
    //    }
    //    ,
    //    {
    //        "角色基础属性_文字描述_闪避",
    //        new Dictionary<LanguageOption, string>{ { LanguageOption.简体中文, "闪避" }, { LanguageOption.English, "Dodge" } }
    //    }  ,
    //    {
    //        "角色基础属性_文字描述_暴击",
    //        new Dictionary<LanguageOption, string>{ { LanguageOption.简体中文, "暴击" }, { LanguageOption.English, "Critical Strike" } }
    //    }
    //};

    // static Dictionary<string, string> LangMap_CN3 = new Dictionary<string, string>{
    // };

    // static Dictionary<string, string> LangMap_EN3 = new Dictionary<string, string>{
    // };

    public enum LanguageOption { 简体中文, English, }

    public static LanguageOption languageOption;

    public static void SetLanguageOption(LanguageOption _LanguageOption)
    {
        languageOption = _LanguageOption;

        UIManager.Instance.OnLanguageChanged();
    }

    public static LanguageOption GetLanguageOption()
    {
        return languageOption;
    }


    public static string GetValue(string sKey)
    {
        if(sKey == null)
            return "";
            
        switch (languageOption)
        {
            case LanguageOption.简体中文:
                {
                     string sChangeName = sKey;
                    // if(LangMap_CN1.ContainsKey(sKey))
                    //     sChangeName = LangMap_CN1[sKey];
                    // else if(LangMap_CN2.ContainsKey(sKey))
                    //     sChangeName = LangMap_CN2[sKey];
                    // else if(LangMap_CN3.ContainsKey(sKey))
                    //     sChangeName = LangMap_CN3[sKey];
                    // return sChangeName;


                    //if (LangMap_EN2_1.ContainsKey(sKey)) {
                    //    sChangeName = LangMap_EN2_1[sKey][languageOption];
                    //}
                    
                    return sChangeName;
                }

            case LanguageOption.English:
                {
                    string sChangeName = sKey;
                    if (LangMap_EN1.ContainsKey(sKey))
                        sChangeName = LangMap_EN1[sKey];
                    // else if(LangMap_EN2.ContainsKey(sKey))
                    //     sChangeName = LangMap_EN2[sKey];
                   //else if (LangMap_EN2_1.ContainsKey(sKey))
                   // {
                   //     sChangeName =  LangMap_EN2_1[sKey][languageOption];
                   // }
                    // else if(LangMap_EN3.ContainsKey(sKey))
                    //     sChangeName = LangMap_EN3[sKey];

                    return sChangeName;
                }

            default:
                return sKey;

        }
    }

    public static string GetDescribe(Datas.DataBase oObjData)
    {
        if(languageOption == LanguageOption.English)
        {
            return oObjData.describe_EN;
        }
        else
        {
            return oObjData.describe;
        }
    }
}