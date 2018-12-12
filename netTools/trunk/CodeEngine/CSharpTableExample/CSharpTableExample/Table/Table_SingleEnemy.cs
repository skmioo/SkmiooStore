//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_SingleEnemy : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/single_enemy.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_NAME,
ID_LEVEL,
ID_CAPTAIN_IMAGE,
ID_FIGHT,
ID_GUNNERY,
ID_TACTICS,
ID_TALENT0,
ID_TALENT1,
ID_TALENT2,
ID_SHIP_IMAGE,
ID_SHIP_TYPE,
ID_HITPIONT,
ID_ARMOUR,
ID_SPEED,
ID_CRITICAL,
ID_DODGE,
ID_SKILL,
ID_MELEE_ATTACK,
ID_MELEE_DEFENCE,
ID_RANGE_ATTACK,
ID_RANGE_DEFENCE,
ID_MAGIC_ATTACK,
ID_MAGIC_DEFENCE,
ID_BASIC_ATTACK,
ID_BASIC_DEFENCE,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int m_Armour;
 public int Armour { get{ return m_Armour;}}

private int m_BasicAttack;
 public int BasicAttack { get{ return m_BasicAttack;}}

private int m_BasicDefence;
 public int BasicDefence { get{ return m_BasicDefence;}}

private string m_CaptainImage;
 public string CaptainImage { get{ return m_CaptainImage;}}

private int m_Critical;
 public int Critical { get{ return m_Critical;}}

private int m_Dodge;
 public int Dodge { get{ return m_Dodge;}}

private int m_Fight;
 public int Fight { get{ return m_Fight;}}

private int m_Gunnery;
 public int Gunnery { get{ return m_Gunnery;}}

private int m_Hitpiont;
 public int Hitpiont { get{ return m_Hitpiont;}}

private int m_Level;
 public int Level { get{ return m_Level;}}

private int m_MagicAttack;
 public int MagicAttack { get{ return m_MagicAttack;}}

private int m_MagicDefence;
 public int MagicDefence { get{ return m_MagicDefence;}}

private int m_MeleeAttack;
 public int MeleeAttack { get{ return m_MeleeAttack;}}

private int m_MeleeDefence;
 public int MeleeDefence { get{ return m_MeleeDefence;}}

private int m_Name;
 public int Name { get{ return m_Name;}}

private int m_RangeAttack;
 public int RangeAttack { get{ return m_RangeAttack;}}

private int m_RangeDefence;
 public int RangeDefence { get{ return m_RangeDefence;}}

private string m_ShipImage;
 public string ShipImage { get{ return m_ShipImage;}}

private int m_ShipType;
 public int ShipType { get{ return m_ShipType;}}

private int m_Skill;
 public int Skill { get{ return m_Skill;}}

private int m_Speed;
 public int Speed { get{ return m_Speed;}}

private int m_Tactics;
 public int Tactics { get{ return m_Tactics;}}

private int[] m_Talent = new int[3];
 public int GetTalentbyIndex(int idx) {
 if(idx>=0 && idx<3) return m_Talent[idx];
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
 Tab_SingleEnemy _values = new Tab_SingleEnemy();
 _values.m_Armour =  Convert.ToInt32(valuesList[(int)_ID.ID_ARMOUR] as string);
_values.m_BasicAttack =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_ATTACK] as string);
_values.m_BasicDefence =  Convert.ToInt32(valuesList[(int)_ID.ID_BASIC_DEFENCE] as string);
_values.m_CaptainImage =  valuesList[(int)_ID.ID_CAPTAIN_IMAGE] as string;
_values.m_Critical =  Convert.ToInt32(valuesList[(int)_ID.ID_CRITICAL] as string);
_values.m_Dodge =  Convert.ToInt32(valuesList[(int)_ID.ID_DODGE] as string);
_values.m_Fight =  Convert.ToInt32(valuesList[(int)_ID.ID_FIGHT] as string);
_values.m_Gunnery =  Convert.ToInt32(valuesList[(int)_ID.ID_GUNNERY] as string);
_values.m_Hitpiont =  Convert.ToInt32(valuesList[(int)_ID.ID_HITPIONT] as string);
_values.m_Level =  Convert.ToInt32(valuesList[(int)_ID.ID_LEVEL] as string);
_values.m_MagicAttack =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_ATTACK] as string);
_values.m_MagicDefence =  Convert.ToInt32(valuesList[(int)_ID.ID_MAGIC_DEFENCE] as string);
_values.m_MeleeAttack =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_ATTACK] as string);
_values.m_MeleeDefence =  Convert.ToInt32(valuesList[(int)_ID.ID_MELEE_DEFENCE] as string);
_values.m_Name =  Convert.ToInt32(valuesList[(int)_ID.ID_NAME] as string);
_values.m_RangeAttack =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_ATTACK] as string);
_values.m_RangeDefence =  Convert.ToInt32(valuesList[(int)_ID.ID_RANGE_DEFENCE] as string);
_values.m_ShipImage =  valuesList[(int)_ID.ID_SHIP_IMAGE] as string;
_values.m_ShipType =  Convert.ToInt32(valuesList[(int)_ID.ID_SHIP_TYPE] as string);
_values.m_Skill =  Convert.ToInt32(valuesList[(int)_ID.ID_SKILL] as string);
_values.m_Speed =  Convert.ToInt32(valuesList[(int)_ID.ID_SPEED] as string);
_values.m_Tactics =  Convert.ToInt32(valuesList[(int)_ID.ID_TACTICS] as string);
_values.m_Talent [ 0 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_TALENT0] as string);
_values.m_Talent [ 1 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_TALENT1] as string);
_values.m_Talent [ 2 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_TALENT2] as string);

 _hash.Add(nKey,_values); }


}
}

