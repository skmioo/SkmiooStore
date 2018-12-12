//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_SkillBase : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/skill_base.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_SKILL_TYPE,
ID_COST,
ID_TARGET_FORCE,
ID_TARGET_TYPE,
ID_DAM_PER,
ID_BUFF_ID,
ID_BUFF_ODD,
ID_RELEASE_EFFECT_ID_BUTTOM,
ID_RECEIVE_EFFECT_ID_BUTTOM,
ID_RELEASE_EFFECT_ID_TOP,
ID_RECEIVE_EFFECT_ID_TOP,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_BuffId;
 public int BuffId { get{ return m_BuffId;}}

private int m_BuffOdd;
 public int BuffOdd { get{ return m_BuffOdd;}}

private int m_Cost;
 public int Cost { get{ return m_Cost;}}

private int m_DamPer;
 public int DamPer { get{ return m_DamPer;}}

private string m_Name;
 public string Name { get{ return m_Name;}}

private int m_ReceiveEffectIdButtom;
 public int ReceiveEffectIdButtom { get{ return m_ReceiveEffectIdButtom;}}

private int m_ReceiveEffectIdTop;
 public int ReceiveEffectIdTop { get{ return m_ReceiveEffectIdTop;}}

private int m_ReleaseEffectIdButtom;
 public int ReleaseEffectIdButtom { get{ return m_ReleaseEffectIdButtom;}}

private int m_ReleaseEffectIdTop;
 public int ReleaseEffectIdTop { get{ return m_ReleaseEffectIdTop;}}

private int m_SkillType;
 public int SkillType { get{ return m_SkillType;}}

private int m_TargetForce;
 public int TargetForce { get{ return m_TargetForce;}}

private int m_TargetType;
 public int TargetType { get{ return m_TargetType;}}

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
 Tab_SkillBase _values = new Tab_SkillBase();
 _values.m_BuffId =  Convert.ToInt32(valuesList[(int)_ID.ID_BUFF_ID] as string);
_values.m_BuffOdd =  Convert.ToInt32(valuesList[(int)_ID.ID_BUFF_ODD] as string);
_values.m_Cost =  Convert.ToInt32(valuesList[(int)_ID.ID_COST] as string);
_values.m_DamPer =  Convert.ToInt32(valuesList[(int)_ID.ID_DAM_PER] as string);
_values.m_Name =  valuesList[(int)_ID.ID_NAME] as string;
_values.m_ReceiveEffectIdButtom =  Convert.ToInt32(valuesList[(int)_ID.ID_RECEIVE_EFFECT_ID_BUTTOM] as string);
_values.m_ReceiveEffectIdTop =  Convert.ToInt32(valuesList[(int)_ID.ID_RECEIVE_EFFECT_ID_TOP] as string);
_values.m_ReleaseEffectIdButtom =  Convert.ToInt32(valuesList[(int)_ID.ID_RELEASE_EFFECT_ID_BUTTOM] as string);
_values.m_ReleaseEffectIdTop =  Convert.ToInt32(valuesList[(int)_ID.ID_RELEASE_EFFECT_ID_TOP] as string);
_values.m_SkillType =  Convert.ToInt32(valuesList[(int)_ID.ID_SKILL_TYPE] as string);
_values.m_TargetForce =  Convert.ToInt32(valuesList[(int)_ID.ID_TARGET_FORCE] as string);
_values.m_TargetType =  Convert.ToInt32(valuesList[(int)_ID.ID_TARGET_TYPE] as string);

 _hash.Add(nKey,_values); }


}
}

