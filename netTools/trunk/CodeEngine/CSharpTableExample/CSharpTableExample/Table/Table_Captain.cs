//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_Captain : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/captain.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_TYPE,
ID_SHIPID,
ID_SEX,
ID_CAPTAIN_POS_ID,
ID_FACE,
ID_HAIR,
ID_DRESS,
ID_SHIP,
ID_FIGHT,
ID_ARTILLERY,
ID_STRATEGY,
ID_SKILL0,
ID_SKILL1,
ID_SKILL2,
ID_PRICE,
ID_MELEE_ATT,
ID_MELEE_DEF,
ID_RANGE_ATT,
ID_RANGE_DEF,
ID_MAGIC_ATT,
ID_MAGIC_DEF,
ID_FIGHT_LV,
ID_ARTILLERY_LV,
ID_STRATEGY_LV,
ID_BASIC_ATTACK,
ID_BASIC_DEFENCE,
ID_UPGRADE_PRICE_ID,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_Artillery;
 public int Artillery { get{ return m_Artillery;}}

private int m_ArtilleryLv;
 public int ArtilleryLv { get{ return m_ArtilleryLv;}}

private int m_BasicAttack;
 public int BasicAttack { get{ return m_BasicAttack;}}

private int m_BasicDefence;
 public int BasicDefence { get{ return m_BasicDefence;}}

private string m_CaptainPosId;
 public string CaptainPosId { get{ return m_CaptainPosId;}}

private string m_Dress;
 public string Dress { get{ return m_Dress;}}

private string m_Face;
 public string Face { get{ return m_Face;}}

private int m_Fight;
 public int Fight { get{ return m_Fight;}}

private int m_FightLv;
 public int FightLv { get{ return m_FightLv;}}

private string m_Hair;
 public string Hair { get{ return m_Hair;}}

private int m_MagicAtt;
 public int MagicAtt { get{ return m_MagicAtt;}}

private int m_MagicDef;
 public int MagicDef { get{ return m_MagicDef;}}

private int m_MeleeAtt;
 public int MeleeAtt { get{ return m_MeleeAtt;}}

private int m_MeleeDef;
 public int MeleeDef { get{ return m_MeleeDef;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private int m_Price;
 public int Price { get{ return m_Price;}}

private int m_RangeAtt;
 public int RangeAtt { get{ return m_RangeAtt;}}

private int m_RangeDef;
 public int RangeDef { get{ return m_RangeDef;}}

private int m_Sex;
 public int Sex { get{ return m_Sex;}}

private int m_Ship;
 public int Ship { get{ return m_Ship;}}

private int m_Shipid;
 public int Shipid { get{ return m_Shipid;}}

private int[] m_Skill = new int[3];
 public int GetSkillbyIndex(int idx) {
 if(idx>=0 && idx<3) return m_Skill[idx];
 return -1;
 }

private int m_Strategy;
 public int Strategy { get{ return m_Strategy;}}

private int m_StrategyLv;
 public int StrategyLv { get{ return m_StrategyLv;}}

private int m_Type;
 public int Type { get{ return m_Type;}}

private int m_UpgradePriceId;
 public int UpgradePriceId { get{ return m_UpgradePriceId;}}

public IEnumerator LoadTable(Hashtable _tab)
 {
 if(!TableManager.ReaderPList(GetInstanceFile(),SerializableTable,_tab))
 {
 throw TableException.ErrorReader("Load File{0} Fail!!!",GetInstanceFile());
 }
 yield return null;
 }
 public void SerializableTable(ArrayList valuesList,string skey,Hashtable _hash)
 {
 if (string.IsNullOrEmpty(skey))
 {
 throw TableException.ErrorReader("Read File{0} as key is Empty Fail!!!", GetInstanceFile());
 }

 if ((int)_ID.MAX_RECORD!=valuesList.Count)
 {
 throw TableException.ErrorReader("Load {0} error as CodeSize:{1} not Equal DataSize:{2}", GetInstanceFile(),_ID.MAX_RECORD,valuesList.Count);
 }
 Int32 nKey = Convert.ToInt32(skey);
 Tab_Captain _values = new Tab_Captain();
 _values.m_Artillery =  Convert.ToInt32(valuesList[(int)_ID.ID_ARTILLERY] as string);
_values.m_ArtilleryLv =  Convert.ToInt32(valuesList[(int)_ID.ID_ARTILLERY_LV] as string);
_values.m_BasicAttack =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_ATTACK] as string);
_values.m_BasicDefence =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_DEFENCE] as string);
_values.m_CaptainPosId =  valuesList[(int)_ID.ID_CAPTAIN_POS_ID] as string;
_values.m_Dress =  valuesList[(int)_ID.ID_DRESS] as string;
_values.m_Face =  valuesList[(int)_ID.ID_FACE] as string;
_values.m_Fight =  Convert.ToInt32(valuesList[(int)_ID.ID_FIGHT] as string);
_values.m_FightLv =  Convert.ToInt32(valuesList[(int)_ID.ID_FIGHT_LV] as string);
_values.m_Hair =  valuesList[(int)_ID.ID_HAIR] as string;
_values.m_MagicAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_ATT] as string);
_values.m_MagicDef =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_DEF] as string);
_values.m_MeleeAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_ATT] as string);
_values.m_MeleeDef =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_DEF] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_Price =  Convert.ToInt32(valuesList[(int)_ID.ID_PRICE] as string);
_values.m_RangeAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_ATT] as string);
_values.m_RangeDef =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_DEF] as string);
_values.m_Sex =  Convert.ToInt32(valuesList[(int)_ID.ID_SEX] as string);
_values.m_Ship =  Convert.ToInt32(valuesList[(int)_ID.ID_SHIP] as string);
_values.m_Shipid =  Convert.ToInt32(valuesList[(int)_ID.ID_SHIPID] as string);
_values.m_Skill [ 0 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SKILL0] as string);
_values.m_Skill [ 1 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SKILL1] as string);
_values.m_Skill [ 2 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SKILL2] as string);
_values.m_Strategy =  Convert.ToInt32(valuesList[(int)_ID.ID_STRATEGY] as string);
_values.m_StrategyLv =  Convert.ToInt32(valuesList[(int)_ID.ID_STRATEGY_LV] as string);
_values.m_Type =  Convert.ToInt32(valuesList[(int)_ID.ID_TYPE] as string);
_values.m_UpgradePriceId =  Convert.ToInt32(valuesList[(int)_ID.ID_UPGRADE_PRICE_ID] as string);

 _hash.Add(nKey,_values); }


}
}

