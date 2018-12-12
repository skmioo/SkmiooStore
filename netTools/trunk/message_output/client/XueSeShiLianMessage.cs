//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGEnterOrExitLingMai : PacketDistributed
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

public const int cityIdFieldNumber = 2;
 private bool hasCityId;
 private Int32 cityId_ = 0;
 public bool HasCityId {
 get { return hasCityId; }
 }
 public Int32 CityId {
 get { return cityId_; }
 set { SetCityId(value); }
 }
 public void SetCityId(Int32 value) { 
 hasCityId = true;
 cityId_ = value;
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
 if (HasCityId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CityId);
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
 
if (HasCityId) {
output.WriteInt32(2, CityId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEnterOrExitLingMai _inst = (CGEnterOrExitLingMai) _base;
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
 _inst.CityId = input.ReadInt32();
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
public class CGEnterOrExitSXSL : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEnterOrExitSXSL _inst = (CGEnterOrExitSXSL) _base;
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
public class CGGetLingMaiRank : PacketDistributed
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

public const int cityIdFieldNumber = 2;
 private bool hasCityId;
 private Int32 cityId_ = 0;
 public bool HasCityId {
 get { return hasCityId; }
 }
 public Int32 CityId {
 get { return cityId_; }
 set { SetCityId(value); }
 }
 public void SetCityId(Int32 value) { 
 hasCityId = true;
 cityId_ = value;
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
 if (HasCityId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CityId);
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
 
if (HasCityId) {
output.WriteInt32(2, CityId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetLingMaiRank _inst = (CGGetLingMaiRank) _base;
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
 _inst.CityId = input.ReadInt32();
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
public class CGGetLingMaiView : PacketDistributed
{

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetLingMaiView _inst = (CGGetLingMaiView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
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
public class CGPickCaoYao : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPickCaoYao _inst = (CGPickCaoYao) _base;
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
   case  16: {
 _inst.Type = input.ReadInt32();
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
public class GCGetLingMaiView : PacketDistributed
{

public const int occupyCityListFieldNumber = 1;
 private pbc::PopsicleList<LingMaiCity> occupyCityList_ = new pbc::PopsicleList<LingMaiCity>();
 public scg::IList<LingMaiCity> occupyCityListList {
 get { return pbc::Lists.AsReadOnly(occupyCityList_); }
 }
 
 public int occupyCityListCount {
 get { return occupyCityList_.Count; }
 }
 
public LingMaiCity GetOccupyCityList(int index) {
 return occupyCityList_[index];
 }
 public void AddOccupyCityList(LingMaiCity value) {
 occupyCityList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (LingMaiCity element in occupyCityListList) {
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
foreach (LingMaiCity element in occupyCityListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetLingMaiView _inst = (GCGetLingMaiView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
LingMaiCity subBuilder =  new LingMaiCity();
input.ReadMessage(subBuilder);
_inst.AddOccupyCityList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (LingMaiCity element in occupyCityListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLingMaiMsg : PacketDistributed
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

public const int occupyGangNameFieldNumber = 2;
 private bool hasOccupyGangName;
 private string occupyGangName_ = "";
 public bool HasOccupyGangName {
 get { return hasOccupyGangName; }
 }
 public string OccupyGangName {
 get { return occupyGangName_; }
 set { SetOccupyGangName(value); }
 }
 public void SetOccupyGangName(string value) { 
 hasOccupyGangName = true;
 occupyGangName_ = value;
 }

public const int gangRankFieldNumber = 3;
 private bool hasGangRank;
 private Int32 gangRank_ = 0;
 public bool HasGangRank {
 get { return hasGangRank; }
 }
 public Int32 GangRank {
 get { return gangRank_; }
 set { SetGangRank(value); }
 }
 public void SetGangRank(Int32 value) { 
 hasGangRank = true;
 gangRank_ = value;
 }

public const int gangSorceFieldNumber = 4;
 private bool hasGangSorce;
 private Int32 gangSorce_ = 0;
 public bool HasGangSorce {
 get { return hasGangSorce; }
 }
 public Int32 GangSorce {
 get { return gangSorce_; }
 set { SetGangSorce(value); }
 }
 public void SetGangSorce(Int32 value) { 
 hasGangSorce = true;
 gangSorce_ = value;
 }

public const int killMonsterNumFieldNumber = 5;
 private bool hasKillMonsterNum;
 private Int32 killMonsterNum_ = 0;
 public bool HasKillMonsterNum {
 get { return hasKillMonsterNum; }
 }
 public Int32 KillMonsterNum {
 get { return killMonsterNum_; }
 set { SetKillMonsterNum(value); }
 }
 public void SetKillMonsterNum(Int32 value) { 
 hasKillMonsterNum = true;
 killMonsterNum_ = value;
 }

public const int killPersonNumFieldNumber = 6;
 private bool hasKillPersonNum;
 private Int32 killPersonNum_ = 0;
 public bool HasKillPersonNum {
 get { return hasKillPersonNum; }
 }
 public Int32 KillPersonNum {
 get { return killPersonNum_; }
 set { SetKillPersonNum(value); }
 }
 public void SetKillPersonNum(Int32 value) { 
 hasKillPersonNum = true;
 killPersonNum_ = value;
 }

public const int totalSorceFieldNumber = 7;
 private bool hasTotalSorce;
 private Int32 totalSorce_ = 0;
 public bool HasTotalSorce {
 get { return hasTotalSorce; }
 }
 public Int32 TotalSorce {
 get { return totalSorce_; }
 set { SetTotalSorce(value); }
 }
 public void SetTotalSorce(Int32 value) { 
 hasTotalSorce = true;
 totalSorce_ = value;
 }

public const int mySorceFieldNumber = 8;
 private bool hasMySorce;
 private Int32 mySorce_ = 0;
 public bool HasMySorce {
 get { return hasMySorce; }
 }
 public Int32 MySorce {
 get { return mySorce_; }
 set { SetMySorce(value); }
 }
 public void SetMySorce(Int32 value) { 
 hasMySorce = true;
 mySorce_ = value;
 }

public const int myKillRankFieldNumber = 9;
 private bool hasMyKillRank;
 private Int32 myKillRank_ = 0;
 public bool HasMyKillRank {
 get { return hasMyKillRank; }
 }
 public Int32 MyKillRank {
 get { return myKillRank_; }
 set { SetMyKillRank(value); }
 }
 public void SetMyKillRank(Int32 value) { 
 hasMyKillRank = true;
 myKillRank_ = value;
 }

public const int cityIdFieldNumber = 10;
 private bool hasCityId;
 private Int32 cityId_ = 0;
 public bool HasCityId {
 get { return hasCityId; }
 }
 public Int32 CityId {
 get { return cityId_; }
 set { SetCityId(value); }
 }
 public void SetCityId(Int32 value) { 
 hasCityId = true;
 cityId_ = value;
 }

public const int occupyCityListFieldNumber = 11;
 private pbc::PopsicleList<LingMaiCity> occupyCityList_ = new pbc::PopsicleList<LingMaiCity>();
 public scg::IList<LingMaiCity> occupyCityListList {
 get { return pbc::Lists.AsReadOnly(occupyCityList_); }
 }
 
 public int occupyCityListCount {
 get { return occupyCityList_.Count; }
 }
 
public LingMaiCity GetOccupyCityList(int index) {
 return occupyCityList_[index];
 }
 public void AddOccupyCityList(LingMaiCity value) {
 occupyCityList_.Add(value);
 }

public const int endTimeFieldNumber = 12;
 private bool hasEndTime;
 private Int64 endTime_ = 0;
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public Int64 EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(Int64 value) { 
 hasEndTime = true;
 endTime_ = value;
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
 if (HasOccupyGangName) {
size += pb::CodedOutputStream.ComputeStringSize(2, OccupyGangName);
}
 if (HasGangRank) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GangRank);
}
 if (HasGangSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GangSorce);
}
 if (HasKillMonsterNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, KillMonsterNum);
}
 if (HasKillPersonNum) {
size += pb::CodedOutputStream.ComputeInt32Size(6, KillPersonNum);
}
 if (HasTotalSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(7, TotalSorce);
}
 if (HasMySorce) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MySorce);
}
 if (HasMyKillRank) {
size += pb::CodedOutputStream.ComputeInt32Size(9, MyKillRank);
}
 if (HasCityId) {
size += pb::CodedOutputStream.ComputeInt32Size(10, CityId);
}
{
foreach (LingMaiCity element in occupyCityListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)11) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(12, EndTime);
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
 
if (HasOccupyGangName) {
output.WriteString(2, OccupyGangName);
}
 
if (HasGangRank) {
output.WriteInt32(3, GangRank);
}
 
if (HasGangSorce) {
output.WriteInt32(4, GangSorce);
}
 
if (HasKillMonsterNum) {
output.WriteInt32(5, KillMonsterNum);
}
 
if (HasKillPersonNum) {
output.WriteInt32(6, KillPersonNum);
}
 
if (HasTotalSorce) {
output.WriteInt32(7, TotalSorce);
}
 
if (HasMySorce) {
output.WriteInt32(8, MySorce);
}
 
if (HasMyKillRank) {
output.WriteInt32(9, MyKillRank);
}
 
if (HasCityId) {
output.WriteInt32(10, CityId);
}

do{
foreach (LingMaiCity element in occupyCityListList) {
output.WriteTag((int)11, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasEndTime) {
output.WriteInt64(12, EndTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLingMaiMsg _inst = (GCLingMaiMsg) _base;
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
 _inst.OccupyGangName = input.ReadString();
break;
}
   case  24: {
 _inst.GangRank = input.ReadInt32();
break;
}
   case  32: {
 _inst.GangSorce = input.ReadInt32();
break;
}
   case  40: {
 _inst.KillMonsterNum = input.ReadInt32();
break;
}
   case  48: {
 _inst.KillPersonNum = input.ReadInt32();
break;
}
   case  56: {
 _inst.TotalSorce = input.ReadInt32();
break;
}
   case  64: {
 _inst.MySorce = input.ReadInt32();
break;
}
   case  72: {
 _inst.MyKillRank = input.ReadInt32();
break;
}
   case  80: {
 _inst.CityId = input.ReadInt32();
break;
}
    case  90: {
LingMaiCity subBuilder =  new LingMaiCity();
input.ReadMessage(subBuilder);
_inst.AddOccupyCityList(subBuilder);
break;
}
   case  96: {
 _inst.EndTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (LingMaiCity element in occupyCityListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLingMaiRank : PacketDistributed
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

public const int ranksFieldNumber = 2;
 private pbc::PopsicleList<LingMaiRank> ranks_ = new pbc::PopsicleList<LingMaiRank>();
 public scg::IList<LingMaiRank> ranksList {
 get { return pbc::Lists.AsReadOnly(ranks_); }
 }
 
 public int ranksCount {
 get { return ranks_.Count; }
 }
 
public LingMaiRank GetRanks(int index) {
 return ranks_[index];
 }
 public void AddRanks(LingMaiRank value) {
 ranks_.Add(value);
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
foreach (LingMaiRank element in ranksList) {
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
foreach (LingMaiRank element in ranksList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLingMaiRank _inst = (GCLingMaiRank) _base;
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
LingMaiRank subBuilder =  new LingMaiRank();
input.ReadMessage(subBuilder);
_inst.AddRanks(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (LingMaiRank element in ranksList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCXueSeShiLian : PacketDistributed
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

public const int endTimeFieldNumber = 2;
 private bool hasEndTime;
 private Int64 endTime_ = 0;
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public Int64 EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(Int64 value) { 
 hasEndTime = true;
 endTime_ = value;
 }

public const int sorceFieldNumber = 3;
 private bool hasSorce;
 private Int32 sorce_ = 0;
 public bool HasSorce {
 get { return hasSorce; }
 }
 public Int32 Sorce {
 get { return sorce_; }
 set { SetSorce(value); }
 }
 public void SetSorce(Int32 value) { 
 hasSorce = true;
 sorce_ = value;
 }

public const int ranksFieldNumber = 4;
 private pbc::PopsicleList<XueSeShiLianRank> ranks_ = new pbc::PopsicleList<XueSeShiLianRank>();
 public scg::IList<XueSeShiLianRank> ranksList {
 get { return pbc::Lists.AsReadOnly(ranks_); }
 }
 
 public int ranksCount {
 get { return ranks_.Count; }
 }
 
public XueSeShiLianRank GetRanks(int index) {
 return ranks_[index];
 }
 public void AddRanks(XueSeShiLianRank value) {
 ranks_.Add(value);
 }

public const int rankFieldNumber = 5;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int enterNextTimeFieldNumber = 6;
 private bool hasEnterNextTime;
 private Int32 enterNextTime_ = 0;
 public bool HasEnterNextTime {
 get { return hasEnterNextTime; }
 }
 public Int32 EnterNextTime {
 get { return enterNextTime_; }
 set { SetEnterNextTime(value); }
 }
 public void SetEnterNextTime(Int32 value) { 
 hasEnterNextTime = true;
 enterNextTime_ = value;
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
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, EndTime);
}
 if (HasSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sorce);
}
{
foreach (XueSeShiLianRank element in ranksList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Rank);
}
 if (HasEnterNextTime) {
size += pb::CodedOutputStream.ComputeInt32Size(6, EnterNextTime);
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
 
if (HasEndTime) {
output.WriteInt64(2, EndTime);
}
 
if (HasSorce) {
output.WriteInt32(3, Sorce);
}

do{
foreach (XueSeShiLianRank element in ranksList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasRank) {
output.WriteInt32(5, Rank);
}
 
if (HasEnterNextTime) {
output.WriteInt32(6, EnterNextTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCXueSeShiLian _inst = (GCXueSeShiLian) _base;
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
 _inst.EndTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.Sorce = input.ReadInt32();
break;
}
    case  34: {
XueSeShiLianRank subBuilder =  new XueSeShiLianRank();
input.ReadMessage(subBuilder);
_inst.AddRanks(subBuilder);
break;
}
   case  40: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  48: {
 _inst.EnterNextTime = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (XueSeShiLianRank element in ranksList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class LingMaiCity : PacketDistributed
{

public const int idFieldNumber = 1;
 private bool hasId;
 private Int32 id_ = 0;
 public bool HasId {
 get { return hasId; }
 }
 public Int32 Id {
 get { return id_; }
 set { SetId(value); }
 }
 public void SetId(Int32 value) { 
 hasId = true;
 id_ = value;
 }

public const int gangIdFieldNumber = 2;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
 }

public const int gangNameFieldNumber = 3;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, GangId);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(3, GangName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasGangId) {
output.WriteInt64(2, GangId);
}
 
if (HasGangName) {
output.WriteString(3, GangName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LingMaiCity _inst = (LingMaiCity) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Id = input.ReadInt32();
break;
}
   case  16: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  26: {
 _inst.GangName = input.ReadString();
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
public class LingMaiRank : PacketDistributed
{

public const int rankIdFieldNumber = 1;
 private bool hasRankId;
 private Int32 rankId_ = 0;
 public bool HasRankId {
 get { return hasRankId; }
 }
 public Int32 RankId {
 get { return rankId_; }
 set { SetRankId(value); }
 }
 public void SetRankId(Int32 value) { 
 hasRankId = true;
 rankId_ = value;
 }

public const int idFieldNumber = 2;
 private bool hasId;
 private Int64 id_ = 0;
 public bool HasId {
 get { return hasId; }
 }
 public Int64 Id {
 get { return id_; }
 set { SetId(value); }
 }
 public void SetId(Int64 value) { 
 hasId = true;
 id_ = value;
 }

public const int nameFieldNumber = 3;
 private bool hasName;
 private string name_ = "";
 public bool HasName {
 get { return hasName; }
 }
 public string Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(string value) { 
 hasName = true;
 name_ = value;
 }

public const int numFieldNumber = 4;
 private bool hasNum;
 private Int32 num_ = 0;
 public bool HasNum {
 get { return hasNum; }
 }
 public Int32 Num {
 get { return num_; }
 set { SetNum(value); }
 }
 public void SetNum(Int32 value) { 
 hasNum = true;
 num_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRankId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RankId);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Id);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(3, Name);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Num);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRankId) {
output.WriteInt32(1, RankId);
}
 
if (HasId) {
output.WriteInt64(2, Id);
}
 
if (HasName) {
output.WriteString(3, Name);
}
 
if (HasNum) {
output.WriteInt32(4, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LingMaiRank _inst = (LingMaiRank) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RankId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Id = input.ReadInt64();
break;
}
   case  26: {
 _inst.Name = input.ReadString();
break;
}
   case  32: {
 _inst.Num = input.ReadInt32();
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
public class XueSeShiLianRank : PacketDistributed
{

public const int idFieldNumber = 1;
 private bool hasId;
 private Int64 id_ = 0;
 public bool HasId {
 get { return hasId; }
 }
 public Int64 Id {
 get { return id_; }
 set { SetId(value); }
 }
 public void SetId(Int64 value) { 
 hasId = true;
 id_ = value;
 }

public const int nameFieldNumber = 2;
 private bool hasName;
 private string name_ = "";
 public bool HasName {
 get { return hasName; }
 }
 public string Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(string value) { 
 hasName = true;
 name_ = value;
 }

public const int playerLvFieldNumber = 3;
 private bool hasPlayerLv;
 private Int32 playerLv_ = 0;
 public bool HasPlayerLv {
 get { return hasPlayerLv; }
 }
 public Int32 PlayerLv {
 get { return playerLv_; }
 set { SetPlayerLv(value); }
 }
 public void SetPlayerLv(Int32 value) { 
 hasPlayerLv = true;
 playerLv_ = value;
 }

public const int professionFieldNumber = 4;
 private bool hasProfession;
 private Int32 profession_ = 0;
 public bool HasProfession {
 get { return hasProfession; }
 }
 public Int32 Profession {
 get { return profession_; }
 set { SetProfession(value); }
 }
 public void SetProfession(Int32 value) { 
 hasProfession = true;
 profession_ = value;
 }

public const int sorceFieldNumber = 5;
 private bool hasSorce;
 private Int32 sorce_ = 0;
 public bool HasSorce {
 get { return hasSorce; }
 }
 public Int32 Sorce {
 get { return sorce_; }
 set { SetSorce(value); }
 }
 public void SetSorce(Int32 value) { 
 hasSorce = true;
 sorce_ = value;
 }

public const int rankFieldNumber = 6;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int sexFieldNumber = 7;
 private bool hasSex;
 private Int32 sex_ = 0;
 public bool HasSex {
 get { return hasSex; }
 }
 public Int32 Sex {
 get { return sex_; }
 set { SetSex(value); }
 }
 public void SetSex(Int32 value) { 
 hasSex = true;
 sex_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Id);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasPlayerLv) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PlayerLv);
}
 if (HasProfession) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Profession);
}
 if (HasSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Sorce);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Rank);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Sex);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasId) {
output.WriteInt64(1, Id);
}
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasPlayerLv) {
output.WriteInt32(3, PlayerLv);
}
 
if (HasProfession) {
output.WriteInt32(4, Profession);
}
 
if (HasSorce) {
output.WriteInt32(5, Sorce);
}
 
if (HasRank) {
output.WriteInt32(6, Rank);
}
 
if (HasSex) {
output.WriteInt32(7, Sex);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 XueSeShiLianRank _inst = (XueSeShiLianRank) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Id = input.ReadInt64();
break;
}
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.PlayerLv = input.ReadInt32();
break;
}
   case  32: {
 _inst.Profession = input.ReadInt32();
break;
}
   case  40: {
 _inst.Sorce = input.ReadInt32();
break;
}
   case  48: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  56: {
 _inst.Sex = input.ReadInt32();
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


}
