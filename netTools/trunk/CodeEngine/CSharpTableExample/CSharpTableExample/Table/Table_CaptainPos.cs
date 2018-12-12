//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_CaptainPos : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/captain_pos.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_FACE_POS_X,
ID_FACE_POS_Y,
ID_HAIR_POS_X,
ID_HAIR_POS_Y,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private float m_FacePosX;
 public float FacePosX { get{ return m_FacePosX;}}

private float m_FacePosY;
 public float FacePosY { get{ return m_FacePosY;}}

private float m_HairPosX;
 public float HairPosX { get{ return m_HairPosX;}}

private float m_HairPosY;
 public float HairPosY { get{ return m_HairPosY;}}

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
 Tab_CaptainPos _values = new Tab_CaptainPos();
 _values.m_FacePosX =  Convert.ToSingle(valuesList[(int)_ID.ID_FACE_POS_X] as string);
_values.m_FacePosY =  Convert.ToSingle(valuesList[(int)_ID.ID_FACE_POS_Y] as string);
_values.m_HairPosX =  Convert.ToSingle(valuesList[(int)_ID.ID_HAIR_POS_X] as string);
_values.m_HairPosY =  Convert.ToSingle(valuesList[(int)_ID.ID_HAIR_POS_Y] as string);

 _hash.Add(nKey,_values); }


}
}

