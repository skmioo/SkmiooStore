//This code create by CodeEngine mrd.cyou.com ,don't modify
using System;
 using System.Collections.Generic;
 using System.Collections;

namespace GCGame.Table{

[Serializable]
 public class Tab_ShipPrice : ITableOperate
{ private const string TAB_FILE_DATA = "./GameData/ship_price.plist";
 enum _ID
 {
 INVLAID_INDEX=-1,
ID_LV1,
ID_LV2,
ID_LV3,
ID_LV4,
ID_LV5,
ID_LV6,
ID_LV7,
ID_LV8,
ID_LV9,
ID_LV10,
ID_LV11,
ID_LV12,
ID_LV13,
ID_LV14,
ID_LV15,
ID_LV16,
ID_LV17,
ID_LV18,
ID_LV19,
ID_LV20,
ID_LV21,
ID_LV22,
ID_LV23,
ID_LV24,
ID_LV25,
ID_LV26,
ID_LV27,
ID_LV28,
ID_LV29,
ID_LV30,
ID_LV31,
ID_LV32,
ID_LV33,
ID_LV34,
ID_LV35,
ID_LV36,
ID_LV37,
ID_LV38,
ID_LV39,
ID_LV40,
ID_LV41,
ID_LV42,
ID_LV43,
ID_LV44,
ID_LV45,
ID_LV46,
ID_LV47,
ID_LV48,
ID_LV49,
ID_LV50,
ID_LV51,
ID_LV52,
ID_LV53,
ID_LV54,
ID_LV55,
ID_LV56,
ID_LV57,
ID_LV58,
ID_LV59,
ID_LV60,
MAX_RECORD
 }
 public string GetInstanceFile(){return TAB_FILE_DATA; }

private int[] m_LV = new int[60];
 public int GetLVbyIndex(int idx) {
 if(idx>=0 && idx<60) return m_LV[idx];
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
 Tab_ShipPrice _values = new Tab_ShipPrice();
 _values.m_LV [ 0 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV1] as string);
_values.m_LV [ 1 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV2] as string);
_values.m_LV [ 2 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV3] as string);
_values.m_LV [ 3 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV4] as string);
_values.m_LV [ 4 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV5] as string);
_values.m_LV [ 5 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV6] as string);
_values.m_LV [ 6 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV7] as string);
_values.m_LV [ 7 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV8] as string);
_values.m_LV [ 8 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV9] as string);
_values.m_LV [ 9 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV10] as string);
_values.m_LV [ 10 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV11] as string);
_values.m_LV [ 11 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV12] as string);
_values.m_LV [ 12 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV13] as string);
_values.m_LV [ 13 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV14] as string);
_values.m_LV [ 14 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV15] as string);
_values.m_LV [ 15 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV16] as string);
_values.m_LV [ 16 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV17] as string);
_values.m_LV [ 17 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV18] as string);
_values.m_LV [ 18 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV19] as string);
_values.m_LV [ 19 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV20] as string);
_values.m_LV [ 20 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV21] as string);
_values.m_LV [ 21 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV22] as string);
_values.m_LV [ 22 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV23] as string);
_values.m_LV [ 23 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV24] as string);
_values.m_LV [ 24 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV25] as string);
_values.m_LV [ 25 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV26] as string);
_values.m_LV [ 26 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV27] as string);
_values.m_LV [ 27 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV28] as string);
_values.m_LV [ 28 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV29] as string);
_values.m_LV [ 29 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV30] as string);
_values.m_LV [ 30 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV31] as string);
_values.m_LV [ 31 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV32] as string);
_values.m_LV [ 32 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV33] as string);
_values.m_LV [ 33 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV34] as string);
_values.m_LV [ 34 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV35] as string);
_values.m_LV [ 35 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV36] as string);
_values.m_LV [ 36 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV37] as string);
_values.m_LV [ 37 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV38] as string);
_values.m_LV [ 38 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV39] as string);
_values.m_LV [ 39 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV40] as string);
_values.m_LV [ 40 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV41] as string);
_values.m_LV [ 41 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV42] as string);
_values.m_LV [ 42 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV43] as string);
_values.m_LV [ 43 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV44] as string);
_values.m_LV [ 44 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV45] as string);
_values.m_LV [ 45 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV46] as string);
_values.m_LV [ 46 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV47] as string);
_values.m_LV [ 47 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV48] as string);
_values.m_LV [ 48 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV49] as string);
_values.m_LV [ 49 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV50] as string);
_values.m_LV [ 50 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV51] as string);
_values.m_LV [ 51 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV52] as string);
_values.m_LV [ 52 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV53] as string);
_values.m_LV [ 53 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV54] as string);
_values.m_LV [ 54 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV55] as string);
_values.m_LV [ 55 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV56] as string);
_values.m_LV [ 56 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV57] as string);
_values.m_LV [ 57 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV58] as string);
_values.m_LV [ 58 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV59] as string);
_values.m_LV [ 59 ] =  Convert.ToInt32(valuesList[(int)_ID.ID_LV60] as string);

 _hash.Add(nKey,_values); }


}
}

