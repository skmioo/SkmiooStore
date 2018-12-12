//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_ItemRule : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/item_rule.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_PRICE,
ID_SELLING_PRICE,
ID_TYPE,
ID_ICON_NAME,
ID_AVTAR_IMAGE_ID,
ID_NEED_LV,
ID_MELEE_ATT,
ID_MELEE_DEF,
ID_RANGE_ATT,
ID_RANGE_DEF,
ID_MAGIC_ATT,
ID_MAGIC_DEF,
ID_UPGRADE_PRICE_ID,
ID_SELLING_PRICE_PRE_LV,
ID_MELEE_ATT_PRE_LV,
ID_MELEE_DEF_PRE_LV,
ID_RANGE_ATT_PRE_,
ID_RANGE_DEF_PRE_,
ID_MAGIC_ATT_PRE_,
ID_MAGIC_DEF_PRE_,
ID_LV_START,
ID_BASIC_ATTACK,
ID_BASIC_DEFENCE,
ID_BASIC_ATTACK_PRE_,
ID_BASIC_DEFENCE_PRE_,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private string m_AvtarImageId;
 public string AvtarImageId { get{ return m_AvtarImageId;}}

private int m_BasicAttack;
 public int BasicAttack { get{ return m_BasicAttack;}}

private int m_BasicAttackPre;
 public int BasicAttackPre { get{ return m_BasicAttackPre;}}

private int m_BasicDefence;
 public int BasicDefence { get{ return m_BasicDefence;}}

private int m_BasicDefencePre;
 public int BasicDefencePre { get{ return m_BasicDefencePre;}}

private string m_IconName;
 public string IconName { get{ return m_IconName;}}

private int m_LvStart;
 public int LvStart { get{ return m_LvStart;}}

private int m_MagicAtt;
 public int MagicAtt { get{ return m_MagicAtt;}}

private int m_MagicAttPre;
 public int MagicAttPre { get{ return m_MagicAttPre;}}

private int m_MagicDef;
 public int MagicDef { get{ return m_MagicDef;}}

private int m_MagicDefPre;
 public int MagicDefPre { get{ return m_MagicDefPre;}}

private int m_MeleeAtt;
 public int MeleeAtt { get{ return m_MeleeAtt;}}

private int m_MeleeAttPreLv;
 public int MeleeAttPreLv { get{ return m_MeleeAttPreLv;}}

private int m_MeleeDef;
 public int MeleeDef { get{ return m_MeleeDef;}}

private int m_MeleeDefPreLv;
 public int MeleeDefPreLv { get{ return m_MeleeDefPreLv;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private int m_NeedLV;
 public int NeedLV { get{ return m_NeedLV;}}

private int m_Price;
 public int Price { get{ return m_Price;}}

private int m_RangeAtt;
 public int RangeAtt { get{ return m_RangeAtt;}}

private int m_RangeAttPre;
 public int RangeAttPre { get{ return m_RangeAttPre;}}

private int m_RangeDef;
 public int RangeDef { get{ return m_RangeDef;}}

private int m_RangeDefPre;
 public int RangeDefPre { get{ return m_RangeDefPre;}}

private int m_SellingPrice;
 public int SellingPrice { get{ return m_SellingPrice;}}

private int m_SellingPricePreLv;
 public int SellingPricePreLv { get{ return m_SellingPricePreLv;}}

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
 Tab_ItemRule _values = new Tab_ItemRule();
 _values.m_AvtarImageId =  valuesList[(int)_ID.ID_AVTAR_IMAGE_ID] as string;
_values.m_BasicAttack =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_ATTACK] as string);
_values.m_BasicAttackPre =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_ATTACK_PRE_] as string);
_values.m_BasicDefence =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_DEFENCE] as string);
_values.m_BasicDefencePre =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_DEFENCE_PRE_] as string);
_values.m_IconName =  valuesList[(int)_ID.ID_ICON_NAME] as string;
_values.m_LvStart =  Convert.ToInt32(valuesList[(int)_ID.ID_LV_START] as string);
_values.m_MagicAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_ATT] as string);
_values.m_MagicAttPre =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_ATT_PRE_] as string);
_values.m_MagicDef =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_DEF] as string);
_values.m_MagicDefPre =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_DEF_PRE_] as string);
_values.m_MeleeAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_ATT] as string);
_values.m_MeleeAttPreLv =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_ATT_PRE_LV] as string);
_values.m_MeleeDef =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_DEF] as string);
_values.m_MeleeDefPreLv =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_DEF_PRE_LV] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_NeedLV =  Convert.ToInt32(valuesList[(int)_ID.ID_NEED_LV] as string);
_values.m_Price =  Convert.ToInt32(valuesList[(int)_ID.ID_PRICE] as string);
_values.m_RangeAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_ATT] as string);
_values.m_RangeAttPre =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_ATT_PRE_] as string);
_values.m_RangeDef =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_DEF] as string);
_values.m_RangeDefPre =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_DEF_PRE_] as string);
_values.m_SellingPrice =  Convert.ToInt32(valuesList[(int)_ID.ID_SELLING_PRICE] as string);
_values.m_SellingPricePreLv =  Convert.ToInt32(valuesList[(int)_ID.ID_SELLING_PRICE_PRE_LV] as string);
_values.m_Type =  Convert.ToInt32(valuesList[(int)_ID.ID_TYPE] as string);
_values.m_UpgradePriceId =  Convert.ToInt32(valuesList[(int)_ID.ID_UPGRADE_PRICE_ID] as string);

 _hash.Add(nKey,_values); }


}
}

