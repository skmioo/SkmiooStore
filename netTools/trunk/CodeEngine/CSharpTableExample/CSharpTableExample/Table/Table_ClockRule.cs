//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_ClockRule : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/clock_rule.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_TYPE,
ID_LIMIT,
ID_COST,
ID_IMAGE,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_Cost;
 public int Cost { get{ return m_Cost;}}

private string m_Image;
 public string Image { get{ return m_Image;}}

private int m_Limit;
 public int Limit { get{ return m_Limit;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private string m_Type;
 public string Type { get{ return m_Type;}}

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
 Tab_ClockRule _values = new Tab_ClockRule();
 _values.m_Cost =  Convert.ToInt32(valuesList[(int)_ID.ID_COST] as string);
_values.m_Image =  valuesList[(int)_ID.ID_IMAGE] as string;
_values.m_Limit =  Convert.ToInt32(valuesList[(int)_ID.ID_LIMIT] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_Type =  valuesList[(int)_ID.ID_TYPE] as string;

 _hash.Add(nKey,_values); }


}
}

