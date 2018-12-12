//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_Ship : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/ship.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_ANI_ID,
ID_IMAGE,
ID_TYPE_1,
ID_TYPE_2,
ID_LV_START,
ID_BUY_PRICE,
ID_ITEMS_FORBUILDER,
ID_STORY,
ID_SELL_PRICE,
ID_POWER,
ID_DURABLE,
ID_ARMOR,
ID_ACTIVE,
ID_AVOID,
ID_CRITICAL,
ID_SELL_PRICE_LV,
ID_POWER_LV,
ID_DURABLE_LV,
ID_ARMOR_LV,
ID_ACTIVE_LV,
ID_AVOID_LV,
ID_CRITICAL_LV,
ID_UPGRADE_PRICE_ID,
ID_SHADOW_ID,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_Active;
 public int Active { get{ return m_Active;}}

private int m_ActiveLv;
 public int ActiveLv { get{ return m_ActiveLv;}}

private int m_AniId;
 public int AniId { get{ return m_AniId;}}

private int m_Armor;
 public int Armor { get{ return m_Armor;}}

private int m_ArmorLv;
 public int ArmorLv { get{ return m_ArmorLv;}}

private int m_Avoid;
 public int Avoid { get{ return m_Avoid;}}

private int m_AvoidLv;
 public int AvoidLv { get{ return m_AvoidLv;}}

private int m_BuyPrice;
 public int BuyPrice { get{ return m_BuyPrice;}}

private int m_Critical;
 public int Critical { get{ return m_Critical;}}

private int m_CriticalLv;
 public int CriticalLv { get{ return m_CriticalLv;}}

private int m_Durable;
 public int Durable { get{ return m_Durable;}}

private int m_DurableLv;
 public int DurableLv { get{ return m_DurableLv;}}

private string m_Image;
 public string Image { get{ return m_Image;}}

private int m_ItemsForBuilder;
 public int ItemsForBuilder { get{ return m_ItemsForBuilder;}}

private int m_LvStart;
 public int LvStart { get{ return m_LvStart;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private int m_Power;
 public int Power { get{ return m_Power;}}

private int m_PowerLv;
 public int PowerLv { get{ return m_PowerLv;}}

private int m_SellPrice;
 public int SellPrice { get{ return m_SellPrice;}}

private int m_SellPriceLv;
 public int SellPriceLv { get{ return m_SellPriceLv;}}

private string m_ShadowId;
 public string ShadowId { get{ return m_ShadowId;}}

private string m_Story;
 public string Story { get{ return m_Story;}}

private int[] m_Type = new int[2];
 public int GetTypebyIndex(int idx) {
 if(idx>=0 && idx<2) return m_Type[idx];
 return -1;
 }

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
 Tab_Ship _values = new Tab_Ship();
 _values.m_Active =  Convert.ToInt32(valuesList[(int)_ID.ID_ACTIVE] as string);
_values.m_ActiveLv =  Convert.ToInt32(valuesList[(int)_ID.ID_ACTIVE_LV] as string);
_values.m_AniId =  Convert.ToInt32(valuesList[(int)_ID.ID_ANI_ID] as string);
_values.m_Armor =  Convert.ToInt32(valuesList[(int)_ID.ID_ARMOR] as string);
_values.m_ArmorLv =  Convert.ToInt32(valuesList[(int)_ID.ID_ARMOR_LV] as string);
_values.m_Avoid =  Convert.ToInt32(valuesList[(int)_ID.ID_AVOID] as string);
_values.m_AvoidLv =  Convert.ToInt32(valuesList[(int)_ID.ID_AVOID_LV] as string);
_values.m_BuyPrice =  Convert.ToInt32(valuesList[(int)_ID.ID_BUY_PRICE] as string);
_values.m_Critical =  Convert.ToInt32(valuesList[(int)_ID.ID_CRITICAL] as string);
_values.m_CriticalLv =  Convert.ToInt32(valuesList[(int)_ID.ID_CRITICAL_LV] as string);
_values.m_Durable =  Convert.ToInt32(valuesList[(int)_ID.ID_DURABLE] as string);
_values.m_DurableLv =  Convert.ToInt32(valuesList[(int)_ID.ID_DURABLE_LV] as string);
_values.m_Image =  valuesList[(int)_ID.ID_IMAGE] as string;
_values.m_ItemsForBuilder =  Convert.ToInt32(valuesList[(int)_ID.ID_ITEMS_FORBUILDER] as string);
_values.m_LvStart =  Convert.ToInt32(valuesList[(int)_ID.ID_LV_START] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_Power =  Convert.ToInt32(valuesList[(int)_ID.ID_POWER] as string);
_values.m_PowerLv =  Convert.ToInt32(valuesList[(int)_ID.ID_POWER_LV] as string);
_values.m_SellPrice =  Convert.ToInt32(valuesList[(int)_ID.ID_SELL_PRICE] as string);
_values.m_SellPriceLv =  Convert.ToInt32(valuesList[(int)_ID.ID_SELL_PRICE_LV] as string);
_values.m_ShadowId =  valuesList[(int)_ID.ID_SHADOW_ID] as string;
_values.m_Story =  valuesList[(int)_ID.ID_STORY] as string;
_values.m_Type [ 0 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_TYPE_1] as string);
_values.m_Type [ 1 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_TYPE_2] as string);
_values.m_UpgradePriceId =  Convert.ToInt32(valuesList[(int)_ID.ID_UPGRADE_PRICE_ID] as string);

 _hash.Add(nKey,_values); }


}
}

