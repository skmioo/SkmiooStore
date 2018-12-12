//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGContinuousLandOver : PacketDistributed
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
 CGContinuousLandOver _inst = (CGContinuousLandOver) _base;
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
public class CGDailyShare : PacketDistributed
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
 CGDailyShare _inst = (CGDailyShare) _base;
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
public class CGGetLevelRewardOver : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetLevelRewardOver _inst = (CGGetLevelRewardOver) _base;
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
public class CGGetLoginReward : PacketDistributed
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

public const int idFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Id);
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
 
if (HasId) {
output.WriteInt32(2, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetLoginReward _inst = (CGGetLoginReward) _base;
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
 _inst.Id = input.ReadInt32();
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
public class CGGetShareReward : PacketDistributed
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
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetShareReward _inst = (CGGetShareReward) _base;
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
public class CGGetWelfareReward : PacketDistributed
{

public const int welfareTypeFieldNumber = 1;
 private bool hasWelfareType;
 private Int32 welfareType_ = 0;
 public bool HasWelfareType {
 get { return hasWelfareType; }
 }
 public Int32 WelfareType {
 get { return welfareType_; }
 set { SetWelfareType(value); }
 }
 public void SetWelfareType(Int32 value) { 
 hasWelfareType = true;
 welfareType_ = value;
 }

public const int temIdFieldNumber = 2;
 private bool hasTemId;
 private Int32 temId_ = 0;
 public bool HasTemId {
 get { return hasTemId; }
 }
 public Int32 TemId {
 get { return temId_; }
 set { SetTemId(value); }
 }
 public void SetTemId(Int32 value) { 
 hasTemId = true;
 temId_ = value;
 }

public const int sprintTypeFieldNumber = 3;
 private bool hasSprintType;
 private Int32 sprintType_ = 0;
 public bool HasSprintType {
 get { return hasSprintType; }
 }
 public Int32 SprintType {
 get { return sprintType_; }
 set { SetSprintType(value); }
 }
 public void SetSprintType(Int32 value) { 
 hasSprintType = true;
 sprintType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasWelfareType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, WelfareType);
}
 if (HasTemId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TemId);
}
 if (HasSprintType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SprintType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasWelfareType) {
output.WriteInt32(1, WelfareType);
}
 
if (HasTemId) {
output.WriteInt32(2, TemId);
}
 
if (HasSprintType) {
output.WriteInt32(3, SprintType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetWelfareReward _inst = (CGGetWelfareReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.WelfareType = input.ReadInt32();
break;
}
   case  16: {
 _inst.TemId = input.ReadInt32();
break;
}
   case  24: {
 _inst.SprintType = input.ReadInt32();
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
public class CGOpenWelfare : PacketDistributed
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
 CGOpenWelfare _inst = (CGOpenWelfare) _base;
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
public class CGRequestGetReward : PacketDistributed
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
 CGRequestGetReward _inst = (CGRequestGetReward) _base;
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
public class CGRwdOnLineGift : PacketDistributed
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
 CGRwdOnLineGift _inst = (CGRwdOnLineGift) _base;
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
public class GCContinuousLandOverBack : PacketDistributed
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

public const int welfareStructFieldNumber = 2;
 private pbc::PopsicleList<WelfareStruct> welfareStruct_ = new pbc::PopsicleList<WelfareStruct>();
 public scg::IList<WelfareStruct> welfareStructList {
 get { return pbc::Lists.AsReadOnly(welfareStruct_); }
 }
 
 public int welfareStructCount {
 get { return welfareStruct_.Count; }
 }
 
public WelfareStruct GetWelfareStruct(int index) {
 return welfareStruct_[index];
 }
 public void AddWelfareStruct(WelfareStruct value) {
 welfareStruct_.Add(value);
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
{
foreach (WelfareStruct element in welfareStructList) {
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
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}

do{
foreach (WelfareStruct element in welfareStructList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCContinuousLandOverBack _inst = (GCContinuousLandOverBack) _base;
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
    case  18: {
WelfareStruct subBuilder =  new WelfareStruct();
input.ReadMessage(subBuilder);
_inst.AddWelfareStruct(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WelfareStruct element in welfareStructList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDailyShare : PacketDistributed
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
 GCDailyShare _inst = (GCDailyShare) _base;
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
public class GCDoubleExpmsg : PacketDistributed
{

public const int dungeonTypeFieldNumber = 1;
 private pbc::PopsicleList<Int32> dungeonType_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> dungeonTypeList {
 get { return pbc::Lists.AsReadOnly(dungeonType_); }
 }
 
 public int dungeonTypeCount {
 get { return dungeonType_.Count; }
 }
 
public Int32 GetDungeonType(int index) {
 return dungeonType_[index];
 }
 public void AddDungeonType(Int32 value) {
 dungeonType_.Add(value);
 }

public const int stsFieldNumber = 2;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in dungeonTypeList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * dungeonType_.Count;
}
 if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (dungeonType_.Count > 0) {
foreach (Int32 element in dungeonTypeList) {
output.WriteInt32(1,element);
}
}

}
 
if (HasSts) {
output.WriteInt32(2, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDoubleExpmsg _inst = (GCDoubleExpmsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddDungeonType(input.ReadInt32());
break;
}
   case  16: {
 _inst.Sts = input.ReadInt32();
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
public class GCGetLevelRewardOverBack : PacketDistributed
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

public const int welfareStructFieldNumber = 2;
 private pbc::PopsicleList<WelfareStruct> welfareStruct_ = new pbc::PopsicleList<WelfareStruct>();
 public scg::IList<WelfareStruct> welfareStructList {
 get { return pbc::Lists.AsReadOnly(welfareStruct_); }
 }
 
 public int welfareStructCount {
 get { return welfareStruct_.Count; }
 }
 
public WelfareStruct GetWelfareStruct(int index) {
 return welfareStruct_[index];
 }
 public void AddWelfareStruct(WelfareStruct value) {
 welfareStruct_.Add(value);
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
{
foreach (WelfareStruct element in welfareStructList) {
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
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}

do{
foreach (WelfareStruct element in welfareStructList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetLevelRewardOverBack _inst = (GCGetLevelRewardOverBack) _base;
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
    case  18: {
WelfareStruct subBuilder =  new WelfareStruct();
input.ReadMessage(subBuilder);
_inst.AddWelfareStruct(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WelfareStruct element in welfareStructList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetLoginReward : PacketDistributed
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

public const int flagFieldNumber = 2;
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

public const int welfareStructFieldNumber = 3;
 private bool hasWelfareStruct;
 private WelfareStruct welfareStruct_ =  new WelfareStruct();
 public bool HasWelfareStruct {
 get { return hasWelfareStruct; }
 }
 public WelfareStruct WelfareStruct {
 get { return welfareStruct_; }
 set { SetWelfareStruct(value); }
 }
 public void SetWelfareStruct(WelfareStruct value) { 
 hasWelfareStruct = true;
 welfareStruct_ = value;
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
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
}
{
int subsize = WelfareStruct.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)WelfareStruct.SerializedSize());
WelfareStruct.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetLoginReward _inst = (GCGetLoginReward) _base;
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
 _inst.Flag = input.ReadInt32();
break;
}
    case  26: {
WelfareStruct subBuilder =  new WelfareStruct();
 input.ReadMessage(subBuilder);
_inst.WelfareStruct = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasWelfareStruct) {
if (!WelfareStruct.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetShareReward : PacketDistributed
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

public const int rewardInfoFieldNumber = 2;
 private bool hasRewardInfo;
 private ShareRewardInfo rewardInfo_ =  new ShareRewardInfo();
 public bool HasRewardInfo {
 get { return hasRewardInfo; }
 }
 public ShareRewardInfo RewardInfo {
 get { return rewardInfo_; }
 set { SetRewardInfo(value); }
 }
 public void SetRewardInfo(ShareRewardInfo value) { 
 hasRewardInfo = true;
 rewardInfo_ = value;
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
{
int subsize = RewardInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)RewardInfo.SerializedSize());
RewardInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetShareReward _inst = (GCGetShareReward) _base;
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
    case  18: {
ShareRewardInfo subBuilder =  new ShareRewardInfo();
 input.ReadMessage(subBuilder);
_inst.RewardInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasRewardInfo) {
if (!RewardInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetWelfareRewardBack : PacketDistributed
{

public const int welfareTypeFieldNumber = 1;
 private bool hasWelfareType;
 private Int32 welfareType_ = 0;
 public bool HasWelfareType {
 get { return hasWelfareType; }
 }
 public Int32 WelfareType {
 get { return welfareType_; }
 set { SetWelfareType(value); }
 }
 public void SetWelfareType(Int32 value) { 
 hasWelfareType = true;
 welfareType_ = value;
 }

public const int welfareStructFieldNumber = 2;
 private pbc::PopsicleList<WelfareStruct> welfareStruct_ = new pbc::PopsicleList<WelfareStruct>();
 public scg::IList<WelfareStruct> welfareStructList {
 get { return pbc::Lists.AsReadOnly(welfareStruct_); }
 }
 
 public int welfareStructCount {
 get { return welfareStruct_.Count; }
 }
 
public WelfareStruct GetWelfareStruct(int index) {
 return welfareStruct_[index];
 }
 public void AddWelfareStruct(WelfareStruct value) {
 welfareStruct_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasWelfareType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, WelfareType);
}
{
foreach (WelfareStruct element in welfareStructList) {
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
  
if (HasWelfareType) {
output.WriteInt32(1, WelfareType);
}

do{
foreach (WelfareStruct element in welfareStructList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetWelfareRewardBack _inst = (GCGetWelfareRewardBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.WelfareType = input.ReadInt32();
break;
}
    case  18: {
WelfareStruct subBuilder =  new WelfareStruct();
input.ReadMessage(subBuilder);
_inst.AddWelfareStruct(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WelfareStruct element in welfareStructList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOnlineViewSts : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOnlineViewSts _inst = (GCOnlineViewSts) _base;
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
public class GCOpenOnLineWelfareBack : PacketDistributed
{

public const int onlinetimeFieldNumber = 1;
 private bool hasOnlinetime;
 private Int64 onlinetime_ = 0;
 public bool HasOnlinetime {
 get { return hasOnlinetime; }
 }
 public Int64 Onlinetime {
 get { return onlinetime_; }
 set { SetOnlinetime(value); }
 }
 public void SetOnlinetime(Int64 value) { 
 hasOnlinetime = true;
 onlinetime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOnlinetime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Onlinetime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOnlinetime) {
output.WriteInt64(1, Onlinetime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOpenOnLineWelfareBack _inst = (GCOpenOnLineWelfareBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Onlinetime = input.ReadInt64();
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
public class GCPushContinuousLandDayNum : PacketDistributed
{

public const int dayNumFieldNumber = 1;
 private bool hasDayNum;
 private Int32 dayNum_ = 0;
 public bool HasDayNum {
 get { return hasDayNum; }
 }
 public Int32 DayNum {
 get { return dayNum_; }
 set { SetDayNum(value); }
 }
 public void SetDayNum(Int32 value) { 
 hasDayNum = true;
 dayNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDayNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, DayNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDayNum) {
output.WriteInt32(1, DayNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushContinuousLandDayNum _inst = (GCPushContinuousLandDayNum) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.DayNum = input.ReadInt32();
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
public class GCPushWelfare : PacketDistributed
{

public const int welfareTypeFieldNumber = 1;
 private bool hasWelfareType;
 private Int32 welfareType_ = 0;
 public bool HasWelfareType {
 get { return hasWelfareType; }
 }
 public Int32 WelfareType {
 get { return welfareType_; }
 set { SetWelfareType(value); }
 }
 public void SetWelfareType(Int32 value) { 
 hasWelfareType = true;
 welfareType_ = value;
 }

public const int welfareStructFieldNumber = 2;
 private pbc::PopsicleList<WelfareStruct> welfareStruct_ = new pbc::PopsicleList<WelfareStruct>();
 public scg::IList<WelfareStruct> welfareStructList {
 get { return pbc::Lists.AsReadOnly(welfareStruct_); }
 }
 
 public int welfareStructCount {
 get { return welfareStruct_.Count; }
 }
 
public WelfareStruct GetWelfareStruct(int index) {
 return welfareStruct_[index];
 }
 public void AddWelfareStruct(WelfareStruct value) {
 welfareStruct_.Add(value);
 }

public const int sprintTimeFieldNumber = 3;
 private pbc::PopsicleList<SprintTime> sprintTime_ = new pbc::PopsicleList<SprintTime>();
 public scg::IList<SprintTime> sprintTimeList {
 get { return pbc::Lists.AsReadOnly(sprintTime_); }
 }
 
 public int sprintTimeCount {
 get { return sprintTime_.Count; }
 }
 
public SprintTime GetSprintTime(int index) {
 return sprintTime_[index];
 }
 public void AddSprintTime(SprintTime value) {
 sprintTime_.Add(value);
 }

public const int actDaysFieldNumber = 4;
 private bool hasActDays;
 private Int32 actDays_ = 0;
 public bool HasActDays {
 get { return hasActDays; }
 }
 public Int32 ActDays {
 get { return actDays_; }
 set { SetActDays(value); }
 }
 public void SetActDays(Int32 value) { 
 hasActDays = true;
 actDays_ = value;
 }

public const int payNumFieldNumber = 5;
 private bool hasPayNum;
 private Int32 payNum_ = 0;
 public bool HasPayNum {
 get { return hasPayNum; }
 }
 public Int32 PayNum {
 get { return payNum_; }
 set { SetPayNum(value); }
 }
 public void SetPayNum(Int32 value) { 
 hasPayNum = true;
 payNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasWelfareType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, WelfareType);
}
{
foreach (WelfareStruct element in welfareStructList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (SprintTime element in sprintTimeList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasActDays) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ActDays);
}
 if (HasPayNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, PayNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasWelfareType) {
output.WriteInt32(1, WelfareType);
}

do{
foreach (WelfareStruct element in welfareStructList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (SprintTime element in sprintTimeList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasActDays) {
output.WriteInt32(4, ActDays);
}
 
if (HasPayNum) {
output.WriteInt32(5, PayNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushWelfare _inst = (GCPushWelfare) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.WelfareType = input.ReadInt32();
break;
}
    case  18: {
WelfareStruct subBuilder =  new WelfareStruct();
input.ReadMessage(subBuilder);
_inst.AddWelfareStruct(subBuilder);
break;
}
    case  26: {
SprintTime subBuilder =  new SprintTime();
input.ReadMessage(subBuilder);
_inst.AddSprintTime(subBuilder);
break;
}
   case  32: {
 _inst.ActDays = input.ReadInt32();
break;
}
   case  40: {
 _inst.PayNum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WelfareStruct element in welfareStructList) {
if (!element.IsInitialized()) return false;
}
foreach (SprintTime element in sprintTimeList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRequestGetRewardBack : PacketDistributed
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

public const int flagFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
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
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRequestGetRewardBack _inst = (GCRequestGetRewardBack) _base;
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
 _inst.Flag = input.ReadInt32();
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
public class GCRwdOnLineGift : PacketDistributed
{

public const int rwdsFieldNumber = 1;
 private pbc::PopsicleList<WelfareStruct> rwds_ = new pbc::PopsicleList<WelfareStruct>();
 public scg::IList<WelfareStruct> rwdsList {
 get { return pbc::Lists.AsReadOnly(rwds_); }
 }
 
 public int rwdsCount {
 get { return rwds_.Count; }
 }
 
public WelfareStruct GetRwds(int index) {
 return rwds_[index];
 }
 public void AddRwds(WelfareStruct value) {
 rwds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (WelfareStruct element in rwdsList) {
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
foreach (WelfareStruct element in rwdsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRwdOnLineGift _inst = (GCRwdOnLineGift) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
WelfareStruct subBuilder =  new WelfareStruct();
input.ReadMessage(subBuilder);
_inst.AddRwds(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WelfareStruct element in rwdsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCShareRewardInfo : PacketDistributed
{

public const int rewardInfoListFieldNumber = 1;
 private pbc::PopsicleList<ShareRewardInfo> rewardInfoList_ = new pbc::PopsicleList<ShareRewardInfo>();
 public scg::IList<ShareRewardInfo> rewardInfoListList {
 get { return pbc::Lists.AsReadOnly(rewardInfoList_); }
 }
 
 public int rewardInfoListCount {
 get { return rewardInfoList_.Count; }
 }
 
public ShareRewardInfo GetRewardInfoList(int index) {
 return rewardInfoList_[index];
 }
 public void AddRewardInfoList(ShareRewardInfo value) {
 rewardInfoList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ShareRewardInfo element in rewardInfoListList) {
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
foreach (ShareRewardInfo element in rewardInfoListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCShareRewardInfo _inst = (GCShareRewardInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ShareRewardInfo subBuilder =  new ShareRewardInfo();
input.ReadMessage(subBuilder);
_inst.AddRewardInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ShareRewardInfo element in rewardInfoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCWelfare : PacketDistributed
{

public const int sprintTypeFieldNumber = 1;
 private bool hasSprintType;
 private Int32 sprintType_ = 0;
 public bool HasSprintType {
 get { return hasSprintType; }
 }
 public Int32 SprintType {
 get { return sprintType_; }
 set { SetSprintType(value); }
 }
 public void SetSprintType(Int32 value) { 
 hasSprintType = true;
 sprintType_ = value;
 }

public const int stateTimeFieldNumber = 2;
 private bool hasStateTime;
 private string stateTime_ = "";
 public bool HasStateTime {
 get { return hasStateTime; }
 }
 public string StateTime {
 get { return stateTime_; }
 set { SetStateTime(value); }
 }
 public void SetStateTime(string value) { 
 hasStateTime = true;
 stateTime_ = value;
 }

public const int endTimeFieldNumber = 3;
 private bool hasEndTime;
 private string endTime_ = "";
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public string EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(string value) { 
 hasEndTime = true;
 endTime_ = value;
 }

public const int openTypeFieldNumber = 4;
 private bool hasOpenType;
 private Int32 openType_ = 0;
 public bool HasOpenType {
 get { return hasOpenType; }
 }
 public Int32 OpenType {
 get { return openType_; }
 set { SetOpenType(value); }
 }
 public void SetOpenType(Int32 value) { 
 hasOpenType = true;
 openType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSprintType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SprintType);
}
 if (HasStateTime) {
size += pb::CodedOutputStream.ComputeStringSize(2, StateTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeStringSize(3, EndTime);
}
 if (HasOpenType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OpenType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSprintType) {
output.WriteInt32(1, SprintType);
}
 
if (HasStateTime) {
output.WriteString(2, StateTime);
}
 
if (HasEndTime) {
output.WriteString(3, EndTime);
}
 
if (HasOpenType) {
output.WriteInt32(4, OpenType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCWelfare _inst = (GCWelfare) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SprintType = input.ReadInt32();
break;
}
   case  18: {
 _inst.StateTime = input.ReadString();
break;
}
   case  26: {
 _inst.EndTime = input.ReadString();
break;
}
   case  32: {
 _inst.OpenType = input.ReadInt32();
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
public class ShareRewardInfo : PacketDistributed
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

public const int getTimeFieldNumber = 2;
 private bool hasGetTime;
 private Int64 getTime_ = 0;
 public bool HasGetTime {
 get { return hasGetTime; }
 }
 public Int64 GetTime {
 get { return getTime_; }
 set { SetGetTime(value); }
 }
 public void SetGetTime(Int64 value) { 
 hasGetTime = true;
 getTime_ = value;
 }

public const int stateFieldNumber = 3;
 private bool hasState;
 private Int32 state_ = 0;
 public bool HasState {
 get { return hasState; }
 }
 public Int32 State {
 get { return state_; }
 set { SetState(value); }
 }
 public void SetState(Int32 value) { 
 hasState = true;
 state_ = value;
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
 if (HasGetTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, GetTime);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(3, State);
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
 
if (HasGetTime) {
output.WriteInt64(2, GetTime);
}
 
if (HasState) {
output.WriteInt32(3, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ShareRewardInfo _inst = (ShareRewardInfo) _base;
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
 _inst.GetTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.State = input.ReadInt32();
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
public class SprintTime : PacketDistributed
{

public const int sprintTypeFieldNumber = 1;
 private bool hasSprintType;
 private Int32 sprintType_ = 0;
 public bool HasSprintType {
 get { return hasSprintType; }
 }
 public Int32 SprintType {
 get { return sprintType_; }
 set { SetSprintType(value); }
 }
 public void SetSprintType(Int32 value) { 
 hasSprintType = true;
 sprintType_ = value;
 }

public const int stateTimeFieldNumber = 2;
 private bool hasStateTime;
 private string stateTime_ = "";
 public bool HasStateTime {
 get { return hasStateTime; }
 }
 public string StateTime {
 get { return stateTime_; }
 set { SetStateTime(value); }
 }
 public void SetStateTime(string value) { 
 hasStateTime = true;
 stateTime_ = value;
 }

public const int endTimeFieldNumber = 3;
 private bool hasEndTime;
 private string endTime_ = "";
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public string EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(string value) { 
 hasEndTime = true;
 endTime_ = value;
 }

public const int openTypeFieldNumber = 4;
 private bool hasOpenType;
 private Int32 openType_ = 0;
 public bool HasOpenType {
 get { return hasOpenType; }
 }
 public Int32 OpenType {
 get { return openType_; }
 set { SetOpenType(value); }
 }
 public void SetOpenType(Int32 value) { 
 hasOpenType = true;
 openType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSprintType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SprintType);
}
 if (HasStateTime) {
size += pb::CodedOutputStream.ComputeStringSize(2, StateTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeStringSize(3, EndTime);
}
 if (HasOpenType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OpenType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSprintType) {
output.WriteInt32(1, SprintType);
}
 
if (HasStateTime) {
output.WriteString(2, StateTime);
}
 
if (HasEndTime) {
output.WriteString(3, EndTime);
}
 
if (HasOpenType) {
output.WriteInt32(4, OpenType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SprintTime _inst = (SprintTime) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SprintType = input.ReadInt32();
break;
}
   case  18: {
 _inst.StateTime = input.ReadString();
break;
}
   case  26: {
 _inst.EndTime = input.ReadString();
break;
}
   case  32: {
 _inst.OpenType = input.ReadInt32();
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
public class WelfareItem : PacketDistributed
{

public const int temIdFieldNumber = 1;
 private bool hasTemId;
 private Int32 temId_ = 0;
 public bool HasTemId {
 get { return hasTemId; }
 }
 public Int32 TemId {
 get { return temId_; }
 set { SetTemId(value); }
 }
 public void SetTemId(Int32 value) { 
 hasTemId = true;
 temId_ = value;
 }

public const int numFieldNumber = 2;
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

public const int bindFieldNumber = 3;
 private bool hasBind;
 private Int32 bind_ = 0;
 public bool HasBind {
 get { return hasBind; }
 }
 public Int32 Bind {
 get { return bind_; }
 set { SetBind(value); }
 }
 public void SetBind(Int32 value) { 
 hasBind = true;
 bind_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTemId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TemId);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Num);
}
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bind);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTemId) {
output.WriteInt32(1, TemId);
}
 
if (HasNum) {
output.WriteInt32(2, Num);
}
 
if (HasBind) {
output.WriteInt32(3, Bind);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 WelfareItem _inst = (WelfareItem) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TemId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Num = input.ReadInt32();
break;
}
   case  24: {
 _inst.Bind = input.ReadInt32();
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
public class WelfareStruct : PacketDistributed
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

public const int itemsFieldNumber = 2;
 private pbc::PopsicleList<WelfareItem> items_ = new pbc::PopsicleList<WelfareItem>();
 public scg::IList<WelfareItem> itemsList {
 get { return pbc::Lists.AsReadOnly(items_); }
 }
 
 public int itemsCount {
 get { return items_.Count; }
 }
 
public WelfareItem GetItems(int index) {
 return items_[index];
 }
 public void AddItems(WelfareItem value) {
 items_.Add(value);
 }

public const int statusFieldNumber = 3;
 private bool hasStatus;
 private Int32 status_ = 0;
 public bool HasStatus {
 get { return hasStatus; }
 }
 public Int32 Status {
 get { return status_; }
 set { SetStatus(value); }
 }
 public void SetStatus(Int32 value) { 
 hasStatus = true;
 status_ = value;
 }

public const int sprintTypeFieldNumber = 4;
 private bool hasSprintType;
 private Int32 sprintType_ = 0;
 public bool HasSprintType {
 get { return hasSprintType; }
 }
 public Int32 SprintType {
 get { return sprintType_; }
 set { SetSprintType(value); }
 }
 public void SetSprintType(Int32 value) { 
 hasSprintType = true;
 sprintType_ = value;
 }

public const int paramFieldNumber = 5;
 private bool hasParam;
 private Int64 param_ = 0;
 public bool HasParam {
 get { return hasParam; }
 }
 public Int64 Param {
 get { return param_; }
 set { SetParam(value); }
 }
 public void SetParam(Int64 value) { 
 hasParam = true;
 param_ = value;
 }

public const int showRewFieldNumber = 6;
 private bool hasShowRew;
 private string showRew_ = "";
 public bool HasShowRew {
 get { return hasShowRew; }
 }
 public string ShowRew {
 get { return showRew_; }
 set { SetShowRew(value); }
 }
 public void SetShowRew(string value) { 
 hasShowRew = true;
 showRew_ = value;
 }

public const int showNameFieldNumber = 7;
 private bool hasShowName;
 private string showName_ = "";
 public bool HasShowName {
 get { return hasShowName; }
 }
 public string ShowName {
 get { return showName_; }
 set { SetShowName(value); }
 }
 public void SetShowName(string value) { 
 hasShowName = true;
 showName_ = value;
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
{
foreach (WelfareItem element in itemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Status);
}
 if (HasSprintType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, SprintType);
}
 if (HasParam) {
size += pb::CodedOutputStream.ComputeInt64Size(5, Param);
}
 if (HasShowRew) {
size += pb::CodedOutputStream.ComputeStringSize(6, ShowRew);
}
 if (HasShowName) {
size += pb::CodedOutputStream.ComputeStringSize(7, ShowName);
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

do{
foreach (WelfareItem element in itemsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasStatus) {
output.WriteInt32(3, Status);
}
 
if (HasSprintType) {
output.WriteInt32(4, SprintType);
}
 
if (HasParam) {
output.WriteInt64(5, Param);
}
 
if (HasShowRew) {
output.WriteString(6, ShowRew);
}
 
if (HasShowName) {
output.WriteString(7, ShowName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 WelfareStruct _inst = (WelfareStruct) _base;
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
    case  18: {
WelfareItem subBuilder =  new WelfareItem();
input.ReadMessage(subBuilder);
_inst.AddItems(subBuilder);
break;
}
   case  24: {
 _inst.Status = input.ReadInt32();
break;
}
   case  32: {
 _inst.SprintType = input.ReadInt32();
break;
}
   case  40: {
 _inst.Param = input.ReadInt64();
break;
}
   case  50: {
 _inst.ShowRew = input.ReadString();
break;
}
   case  58: {
 _inst.ShowName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WelfareItem element in itemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
