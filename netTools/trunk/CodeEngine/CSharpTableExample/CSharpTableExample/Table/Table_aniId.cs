//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_AniId : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/ani_id.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_FEATURE,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_Feature;
 public int Feature { get{ return m_Feature;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

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
 Tab_AniId _values = new Tab_AniId();
 _values.m_Feature =  Convert.ToInt32(valuesList[(int)_ID.ID_FEATURE] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;

 _hash.Add(nKey,_values); }


}
}

