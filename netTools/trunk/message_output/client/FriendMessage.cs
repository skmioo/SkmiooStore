//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGFairy : PacketDistributed
{

public const int contentFieldNumber = 1;
 private bool hasContent;
 private string content_ = "";
 public bool HasContent {
 get { return hasContent; }
 }
 public string Content {
 get { return content_; }
 set { SetContent(value); }
 }
 public void SetContent(string value) { 
 hasContent = true;
 content_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasContent) {
size += pb::CodedOutputStream.ComputeStringSize(1, Content);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasContent) {
output.WriteString(1, Content);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGFairy _inst = (CGFairy) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Content = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  return true;
 }

	}


[Serializable]
public class CGFriendListData : PacketDistributed
{

public const int typeFieldNumber = 1;
 private bool hasType;
 private Int32 type_ = 0;
 public bool HasType {
 get { return hasType; }
 }
 public Int32 Type {
 get { return type_; }
 set { SetType(value); }
 }
 public void SetType(Int32 value) { 
 hasType = true;
 type_ = value;
 }

public const int playernameFieldNumber = 2;
 private bool hasPlayername;
 private string playername_ = "";
 public bool HasPlayername {
 get { return hasPlayername; }
 }
 public string Playername {
 get { return playername_; }
 set { SetPlayername(value); }
 }
 public void SetPlayername(string value) { 
 hasPlayername = true;
 playername_ = value;
 }

public const int regionFieldNumber = 3;
 private bool hasRegion;
 private Int32 region_ = 0;
 public bool HasRegion {
 get { return hasRegion; }
 }
 public Int32 Region {
 get { return region_; }
 set { SetRegion(value); }
 }
 public void SetRegion(Int32 value) { 
 hasRegion = true;
 region_ = value;
 }

public const int genderFieldNumber = 4;
 private bool hasGender;
 private Int32 gender_ = 0;
 public bool HasGender {
 get { return hasGender; }
 }
 public Int32 Gender {
 get { return gender_; }
 set { SetGender(value); }
 }
 public void SetGender(Int32 value) { 
 hasGender = true;
 gender_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasPlayername) {
size += pb::CodedOutputStream.ComputeStringSize(2, Playername);
}
 if (HasRegion) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Region);
}
 if (HasGender) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Gender);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasType) {
output.WriteInt32(1, Type);
}
 
if (HasPlayername) {
output.WriteString(2, Playername);
}
 
if (HasRegion) {
output.WriteInt32(3, Region);
}
 
if (HasGender) {
output.WriteInt32(4, Gender);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGFriendListData _inst = (CGFriendListData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Type = input.ReadInt32();
break;
}
   case  18: {
 _inst.Playername = input.ReadString();
break;
}
   case  24: {
 _inst.Region = input.ReadInt32();
break;
}
   case  32: {
 _inst.Gender = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  return true;
 }

	}


[Serializable]
public class CGGetFriendData : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetFriendData _inst = (CGGetFriendData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  return true;
 }

	}


[Serializable]
public class CGOptionFriend : PacketDistributed
{

public const int typeFieldNumber = 1;
 private bool hasType;
 private Int32 type_ = 0;
 public bool HasType {
 get { return hasType; }
 }
 public Int32 Type {
 get { return type_; }
 set { SetType(value); }
 }
 public void SetType(Int32 value) { 
 hasType = true;
 type_ = value;
 }

public const int objIdFieldNumber = 2;
 private pbc::PopsicleList<Int64> objId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdList {
 get { return pbc::Lists.AsReadOnly(objId_); }
 }
 
 public int objIdCount {
 get { return objId_.Count; }
 }
 
public Int64 GetObjId(int index) {
 return objId_[index];
 }
 public void AddObjId(Int64 value) {
 objId_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
{
int dataSize = 0;
foreach (Int64 element in objIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objId_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasType) {
output.WriteInt32(1, Type);
}
{
if (objId_.Count > 0) {
foreach (Int64 element in objIdList) {
output.WriteInt64(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGOptionFriend _inst = (CGOptionFriend) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Type = input.ReadInt32();
break;
}
   case  16: {
 _inst.AddObjId(input.ReadInt64());
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  return true;
 }

	}


[Serializable]
public class CGTrackEnemy : PacketDistributed
{

public const int enemyPlayerIdFieldNumber = 1;
 private bool hasEnemyPlayerId;
 private Int64 enemyPlayerId_ = 0;
 public bool HasEnemyPlayerId {
 get { return hasEnemyPlayerId; }
 }
 public Int64 EnemyPlayerId {
 get { return enemyPlayerId_; }
 set { SetEnemyPlayerId(value); }
 }
 public void SetEnemyPlayerId(Int64 value) { 
 hasEnemyPlayerId = true;
 enemyPlayerId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasEnemyPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, EnemyPlayerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasEnemyPlayerId) {
output.WriteInt64(1, EnemyPlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTrackEnemy _inst = (CGTrackEnemy) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.EnemyPlayerId = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  return true;
 }

	}


[Serializable]
public class GCFriendListDataBack : PacketDistributed
{

public const int typeFieldNumber = 1;
 private bool hasType;
 private Int32 type_ = 0;
 public bool HasType {
 get { return hasType; }
 }
 public Int32 Type {
 get { return type_; }
 set { SetType(value); }
 }
 public void SetType(Int32 value) { 
 hasType = true;
 type_ = value;
 }

public const int frienddataFieldNumber = 2;
 private pbc::PopsicleList<FriendData> frienddata_ = new pbc::PopsicleList<FriendData>();
 public scg::IList<FriendData> frienddataList {
 get { return pbc::Lists.AsReadOnly(frienddata_); }
 }
 
 public int frienddataCount {
 get { return frienddata_.Count; }
 }
 
public FriendData GetFrienddata(int index) {
 return frienddata_[index];
 }
 public void AddFrienddata(FriendData value) {
 frienddata_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
{
foreach (FriendData element in frienddataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasType) {
output.WriteInt32(1, Type);
}

do{
foreach (FriendData element in frienddataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFriendListDataBack _inst = (GCFriendListDataBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Type = input.ReadInt32();
break;
}
    case  18: {
FriendData subBuilder =  new FriendData();
input.ReadMessage(subBuilder);
_inst.AddFrienddata(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FriendData element in frienddataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetFriendDataBack : PacketDistributed
{

public const int frienddataFieldNumber = 1;
 private bool hasFrienddata;
 private FriendData frienddata_ =  new FriendData();
 public bool HasFrienddata {
 get { return hasFrienddata; }
 }
 public FriendData Frienddata {
 get { return frienddata_; }
 set { SetFrienddata(value); }
 }
 public void SetFrienddata(FriendData value) { 
 hasFrienddata = true;
 frienddata_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Frienddata.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Frienddata.SerializedSize());
Frienddata.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetFriendDataBack _inst = (GCGetFriendDataBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
FriendData subBuilder =  new FriendData();
 input.ReadMessage(subBuilder);
_inst.Frienddata = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasFrienddata) {
if (!Frienddata.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOptionFriendBack : PacketDistributed
{

public const int flagFieldNumber = 1;
 private bool hasFlag;
 private Int32 flag_ = 0;
 public bool HasFlag {
 get { return hasFlag; }
 }
 public Int32 Flag {
 get { return flag_; }
 set { SetFlag(value); }
 }
 public void SetFlag(Int32 value) { 
 hasFlag = true;
 flag_ = value;
 }

public const int typeFieldNumber = 2;
 private bool hasType;
 private Int32 type_ = 0;
 public bool HasType {
 get { return hasType; }
 }
 public Int32 Type {
 get { return type_; }
 set { SetType(value); }
 }
 public void SetType(Int32 value) { 
 hasType = true;
 type_ = value;
 }

public const int frienddataFieldNumber = 3;
 private pbc::PopsicleList<FriendData> frienddata_ = new pbc::PopsicleList<FriendData>();
 public scg::IList<FriendData> frienddataList {
 get { return pbc::Lists.AsReadOnly(frienddata_); }
 }
 
 public int frienddataCount {
 get { return frienddata_.Count; }
 }
 
public FriendData GetFrienddata(int index) {
 return frienddata_[index];
 }
 public void AddFrienddata(FriendData value) {
 frienddata_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
{
foreach (FriendData element in frienddataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}

do{
foreach (FriendData element in frienddataList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOptionFriendBack _inst = (GCOptionFriendBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
    case  26: {
FriendData subBuilder =  new FriendData();
input.ReadMessage(subBuilder);
_inst.AddFrienddata(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FriendData element in frienddataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushAddFriend : PacketDistributed
{

public const int frienddataFieldNumber = 1;
 private pbc::PopsicleList<FriendData> frienddata_ = new pbc::PopsicleList<FriendData>();
 public scg::IList<FriendData> frienddataList {
 get { return pbc::Lists.AsReadOnly(frienddata_); }
 }
 
 public int frienddataCount {
 get { return frienddata_.Count; }
 }
 
public FriendData GetFrienddata(int index) {
 return frienddata_[index];
 }
 public void AddFrienddata(FriendData value) {
 frienddata_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (FriendData element in frienddataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (FriendData element in frienddataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushAddFriend _inst = (GCPushAddFriend) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
FriendData subBuilder =  new FriendData();
input.ReadMessage(subBuilder);
_inst.AddFrienddata(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FriendData element in frienddataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushPersonMessage : PacketDistributed
{

public const int permsgFieldNumber = 1;
 private pbc::PopsicleList<PersonalMessagees> permsg_ = new pbc::PopsicleList<PersonalMessagees>();
 public scg::IList<PersonalMessagees> permsgList {
 get { return pbc::Lists.AsReadOnly(permsg_); }
 }
 
 public int permsgCount {
 get { return permsg_.Count; }
 }
 
public PersonalMessagees GetPermsg(int index) {
 return permsg_[index];
 }
 public void AddPermsg(PersonalMessagees value) {
 permsg_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (PersonalMessagees element in permsgList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (PersonalMessagees element in permsgList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushPersonMessage _inst = (GCPushPersonMessage) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
PersonalMessagees subBuilder =  new PersonalMessagees();
input.ReadMessage(subBuilder);
_inst.AddPermsg(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PersonalMessagees element in permsgList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTrackEnemy : PacketDistributed
{

public const int targetPosFieldNumber = 2;
 private bool hasTargetPos;
 private Vector3Info targetPos_ =  new Vector3Info();
 public bool HasTargetPos {
 get { return hasTargetPos; }
 }
 public Vector3Info TargetPos {
 get { return targetPos_; }
 set { SetTargetPos(value); }
 }
 public void SetTargetPos(Vector3Info value) { 
 hasTargetPos = true;
 targetPos_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTrackEnemy _inst = (GCTrackEnemy) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


}
