//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_ItemUpgraderPercent : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/item_upgrader_percent.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_PERCENT,
ID_MELEE_ATT,
ID_MELEE_DEF,
ID_RANGE_ATT,
ID_RAGNE_DEF,
ID_MAGIC_ATT,
ID_MAGIC_DEF,
ID_BASIC_ATT,
ID_BASIC_DEF,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_BasicAtt;
 public int BasicAtt { get{ return m_BasicAtt;}}

private int m_BasicDef;
 public int BasicDef { get{ return m_BasicDef;}}

private int m_MagicAtt;
 public int MagicAtt { get{ return m_MagicAtt;}}

private int m_MagicDef;
 public int MagicDef { get{ return m_MagicDef;}}

private int m_MeleeAtt;
 public int MeleeAtt { get{ return m_MeleeAtt;}}

private int m_MeleeDef;
 public int MeleeDef { get{ return m_MeleeDef;}}

private int m_Percent;
 public int Percent { get{ return m_Percent;}}

private int m_RagneDef;
 public int RagneDef { get{ return m_RagneDef;}}

private int m_RangeAtt;
 public int RangeAtt { get{ return m_RangeAtt;}}

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
 Tab_ItemUpgraderPercent _values = new Tab_ItemUpgraderPercent();
 _values.m_BasicAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_ATT] as string);
_values.m_BasicDef =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_DEF] as string);
_values.m_MagicAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_ATT] as string);
_values.m_MagicDef =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_DEF] as string);
_values.m_MeleeAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_ATT] as string);
_values.m_MeleeDef =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_DEF] as string);
_values.m_Percent =  Convert.ToInt32(valuesList[(int)_ID.ID_PERCENT] as string);
_values.m_RagneDef =  Convert.ToInt32(valuesList[(int)_ID.ID_RAGNE_DEF] as string);
_values.m_RangeAtt =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_ATT] as string);

 _hash.Add(nKey,_values); }


}
}

