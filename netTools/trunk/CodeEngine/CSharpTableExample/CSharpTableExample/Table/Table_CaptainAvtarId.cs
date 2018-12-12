//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_CaptainAvtarId : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/captain_avtar_id.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_HUMAN_MAN,
ID_HUMAN_WOMEN,
ID_FISH_MAN,
ID_FISH_WOMEN,
ID_SOULS_MAN,
ID_SOULS_WOMEN,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private string m_FishMan;
 public string FishMan { get{ return m_FishMan;}}

private string m_FishWomen;
 public string FishWomen { get{ return m_FishWomen;}}

private string m_HumanMan;
 public string HumanMan { get{ return m_HumanMan;}}

private string m_HumanWomen;
 public string HumanWomen { get{ return m_HumanWomen;}}

private string m_SoulsMan;
 public string SoulsMan { get{ return m_SoulsMan;}}

private string m_SoulsWomen;
 public string SoulsWomen { get{ return m_SoulsWomen;}}

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
 Tab_CaptainAvtarId _values = new Tab_CaptainAvtarId();
 _values.m_FishMan =  valuesList[(int)_ID.ID_FISH_MAN] as string;
_values.m_FishWomen =  valuesList[(int)_ID.ID_FISH_WOMEN] as string;
_values.m_HumanMan =  valuesList[(int)_ID.ID_HUMAN_MAN] as string;
_values.m_HumanWomen =  valuesList[(int)_ID.ID_HUMAN_WOMEN] as string;
_values.m_SoulsMan =  valuesList[(int)_ID.ID_SOULS_MAN] as string;
_values.m_SoulsWomen =  valuesList[(int)_ID.ID_SOULS_WOMEN] as string;

 _hash.Add(nKey,_values); }


}
}

