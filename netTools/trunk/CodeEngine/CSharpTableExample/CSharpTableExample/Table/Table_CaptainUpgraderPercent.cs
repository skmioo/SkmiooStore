//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_CaptainUpgraderPercent : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/captain_upgrader_percent.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_PERCENT,
ID_FIGHT,
ID_ARTILLERY,
ID_STRATEGY,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_ARTILLERY;
 public int ARTILLERY { get{ return m_ARTILLERY;}}

private int m_FIGHT;
 public int FIGHT { get{ return m_FIGHT;}}

private int m_STRATEGY;
 public int STRATEGY { get{ return m_STRATEGY;}}

private int m_Percent;
 public int Percent { get{ return m_Percent;}}

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
 Tab_CaptainUpgraderPercent _values = new Tab_CaptainUpgraderPercent();
 _values.m_ARTILLERY =  Convert.ToInt32(valuesList[(int)_ID.ID_ARTILLERY] as string);
_values.m_FIGHT =  Convert.ToInt32(valuesList[(int)_ID.ID_FIGHT] as string);
_values.m_STRATEGY =  Convert.ToInt32(valuesList[(int)_ID.ID_STRATEGY] as string);
_values.m_Percent =  Convert.ToInt32(valuesList[(int)_ID.ID_PERCENT] as string);

 _hash.Add(nKey,_values); }


}
}

