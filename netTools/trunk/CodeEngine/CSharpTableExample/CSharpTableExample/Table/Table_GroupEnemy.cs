//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_GroupEnemy : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/group_enemy.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_DIALOG,
ID_LEVEL,
ID_ICON,
ID_SITE1,
ID_SITE2,
ID_SITE3,
ID_SITE4,
ID_SITE5,
ID_SITE6,
ID_SITE7,
ID_SITE8,
ID_SITE9,
ID_DROP1_MONEY,
ID_DROP2_HONOUR,
ID_DROP3_ITEM_ID,
ID_DROP3_PRO,
ID_UNLOCK_1,
ID_UNLOCK_2,
ID_UNLOCK_3,
ID_MAP_ID,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private string m_Dialog;
 public string Dialog { get{ return m_Dialog;}}

private int m_Drop1Money;
 public int Drop1Money { get{ return m_Drop1Money;}}

private int m_Drop2Honour;
 public int Drop2Honour { get{ return m_Drop2Honour;}}

private int m_Drop3ItemId;
 public int Drop3ItemId { get{ return m_Drop3ItemId;}}

private int m_Drop3Pro;
 public int Drop3Pro { get{ return m_Drop3Pro;}}

private string m_Icon;
 public string Icon { get{ return m_Icon;}}

private int m_Level;
 public int Level { get{ return m_Level;}}

private int m_MapId;
 public int MapId { get{ return m_MapId;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private int[] m_Site = new int[9];
 public int GetSitebyIndex(int idx) {
 if(idx>=0 && idx<9) return m_Site[idx];
 return -1;
 }

private int[] m_Unlock = new int[3];
 public int GetUnlockbyIndex(int idx) {
 if(idx>=0 && idx<3) return m_Unlock[idx];
 return -1;
 }

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
 Tab_GroupEnemy _values = new Tab_GroupEnemy();
 _values.m_Dialog =  valuesList[(int)_ID.ID_DIALOG] as string;
_values.m_Drop1Money =  Convert.ToInt32(valuesList[(int)_ID.ID_DROP1_MONEY] as string);
_values.m_Drop2Honour =  Convert.ToInt32(valuesList[(int)_ID.ID_DROP2_HONOUR] as string);
_values.m_Drop3ItemId =  Convert.ToInt32(valuesList[(int)_ID.ID_DROP3_ITEM_ID] as string);
_values.m_Drop3Pro =  Convert.ToInt32(valuesList[(int)_ID.ID_DROP3_PRO] as string);
_values.m_Icon =  valuesList[(int)_ID.ID_ICON] as string;
_values.m_Level =  Convert.ToInt32(valuesList[(int)_ID.ID_LEVEL] as string);
_values.m_MapId =  Convert.ToInt32(valuesList[(int)_ID.ID_MAP_ID] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_Site [ 0 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE1] as string);
_values.m_Site [ 1 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE2] as string);
_values.m_Site [ 2 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE3] as string);
_values.m_Site [ 3 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE4] as string);
_values.m_Site [ 4 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE5] as string);
_values.m_Site [ 5 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE6] as string);
_values.m_Site [ 6 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE7] as string);
_values.m_Site [ 7 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE8] as string);
_values.m_Site [ 8 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_SITE9] as string);
_values.m_Unlock [ 0 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_UNLOCK_1] as string);
_values.m_Unlock [ 1 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_UNLOCK_2] as string);
_values.m_Unlock [ 2 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_UNLOCK_3] as string);

 _hash.Add(nKey,_values); }


}
}

