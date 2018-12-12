//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_StoryMap : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/story_map.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_ICON,
ID_TMX,
ID_TYPE,
ID_STORY,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private string m_Icon;
 public string Icon { get{ return m_Icon;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private string m_Story;
 public string Story { get{ return m_Story;}}

private string m_Tmx;
 public string Tmx { get{ return m_Tmx;}}

private int m_Type;
 public int Type { get{ return m_Type;}}

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
 Tab_StoryMap _values = new Tab_StoryMap();
 _values.m_Icon =  valuesList[(int)_ID.ID_ICON] as string;
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_Story =  valuesList[(int)_ID.ID_STORY] as string;
_values.m_Tmx =  valuesList[(int)_ID.ID_TMX] as string;
_values.m_Type =  Convert.ToInt32(valuesList[(int)_ID.ID_TYPE] as string);

 _hash.Add(nKey,_values); }


}
}

