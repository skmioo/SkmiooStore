//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_ShipUpgraderPercent : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/ship_upgrader_percent.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_PERCENT,
ID_POWER,
ID_HITPOINT,
ID_ARMOR,
ID_ACTIVE,
ID_AVIOD,
ID_CRITICAL,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_Active;
 public int Active { get{ return m_Active;}}

private int m_Armor;
 public int Armor { get{ return m_Armor;}}

private int m_Aviod;
 public int Aviod { get{ return m_Aviod;}}

private int m_Critical;
 public int Critical { get{ return m_Critical;}}

private int m_Hitpoint;
 public int Hitpoint { get{ return m_Hitpoint;}}

private int m_Percent;
 public int Percent { get{ return m_Percent;}}

private int m_Power;
 public int Power { get{ return m_Power;}}

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
 Tab_ShipUpgraderPercent _values = new Tab_ShipUpgraderPercent();
 _values.m_Active =  Convert.ToInt32(valuesList[(int)_ID.ID_ACTIVE] as string);
_values.m_Armor =  Convert.ToInt32(valuesList[(int)_ID.ID_ARMOR] as string);
_values.m_Aviod =  Convert.ToInt32(valuesList[(int)_ID.ID_AVIOD] as string);
_values.m_Critical =  Convert.ToInt32(valuesList[(int)_ID.ID_CRITICAL] as string);
_values.m_Hitpoint =  Convert.ToInt32(valuesList[(int)_ID.ID_HITPOINT] as string);
_values.m_Percent =  Convert.ToInt32(valuesList[(int)_ID.ID_PERCENT] as string);
_values.m_Power =  Convert.ToInt32(valuesList[(int)_ID.ID_POWER] as string);

 _hash.Add(nKey,_values); }


}
}

