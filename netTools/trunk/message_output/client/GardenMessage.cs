//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGardenMakeMedicine : PacketDistributed
{

public const int configIDFieldNumber = 1;
 private bool hasConfigID;
 private Int32 configID_ = 0;
 public bool HasConfigID {
 get { return hasConfigID; }
 }
 public Int32 ConfigID {
 get { return configID_; }
 set { SetConfigID(value); }
 }
 public void SetConfigID(Int32 value) { 
 hasConfigID = true;
 configID_ = value;
 }

public const int fireIDFieldNumber = 2;
 private bool hasFireID;
 private Int32 fireID_ = 0;
 public bool HasFireID {
 get { return hasFireID; }
 }
 public Int32 FireID {
 get { return fireID_; }
 set { SetFireID(value); }
 }
 public void SetFireID(Int32 value) { 
 hasFireID = true;
 fireID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasConfigID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ConfigID);
}
 if (HasFireID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, FireID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasConfigID) {
output.WriteInt32(1, ConfigID);
}
 
if (HasFireID) {
output.WriteInt32(2, FireID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGardenMakeMedicine _inst = (CGGardenMakeMedicine) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ConfigID = input.ReadInt32();
break;
}
   case  16: {
 _inst.FireID = input.ReadInt32();
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
public class CGGardenOperate : PacketDistributed
{

public const int operateFieldNumber = 1;
 private bool hasOperate;
 private Int32 operate_ = 0;
 public bool HasOperate {
 get { return hasOperate; }
 }
 public Int32 Operate {
 get { return operate_; }
 set { SetOperate(value); }
 }
 public void SetOperate(Int32 value) { 
 hasOperate = true;
 operate_ = value;
 }

public const int seedIDFieldNumber = 2;
 private bool hasSeedID;
 private Int32 seedID_ = 0;
 public bool HasSeedID {
 get { return hasSeedID; }
 }
 public Int32 SeedID {
 get { return seedID_; }
 set { SetSeedID(value); }
 }
 public void SetSeedID(Int32 value) { 
 hasSeedID = true;
 seedID_ = value;
 }

public const int fieldIDFieldNumber = 3;
 private bool hasFieldID;
 private Int32 fieldID_ = 0;
 public bool HasFieldID {
 get { return hasFieldID; }
 }
 public Int32 FieldID {
 get { return fieldID_; }
 set { SetFieldID(value); }
 }
 public void SetFieldID(Int32 value) { 
 hasFieldID = true;
 fieldID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasSeedID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SeedID);
}
 if (HasFieldID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, FieldID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOperate) {
output.WriteInt32(1, Operate);
}
 
if (HasSeedID) {
output.WriteInt32(2, SeedID);
}
 
if (HasFieldID) {
output.WriteInt32(3, FieldID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGardenOperate _inst = (CGGardenOperate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Operate = input.ReadInt32();
break;
}
   case  16: {
 _inst.SeedID = input.ReadInt32();
break;
}
   case  24: {
 _inst.FieldID = input.ReadInt32();
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
public class GCGardenMakeMedicine : PacketDistributed
{

public const int resultFieldNumber = 1;
 private bool hasResult;
 private Int32 result_ = 0;
 public bool HasResult {
 get { return hasResult; }
 }
 public Int32 Result {
 get { return result_; }
 set { SetResult(value); }
 }
 public void SetResult(Int32 value) { 
 hasResult = true;
 result_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResult) {
output.WriteInt32(1, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGardenMakeMedicine _inst = (GCGardenMakeMedicine) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Result = input.ReadInt32();
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
public class GCGardenOperateResult : PacketDistributed
{

public const int operateFieldNumber = 1;
 private bool hasOperate;
 private Int32 operate_ = 0;
 public bool HasOperate {
 get { return hasOperate; }
 }
 public Int32 Operate {
 get { return operate_; }
 set { SetOperate(value); }
 }
 public void SetOperate(Int32 value) { 
 hasOperate = true;
 operate_ = value;
 }

public const int fieldInfoFieldNumber = 2;
 private pbc::PopsicleList<GardenFieldInfo> fieldInfo_ = new pbc::PopsicleList<GardenFieldInfo>();
 public scg::IList<GardenFieldInfo> fieldInfoList {
 get { return pbc::Lists.AsReadOnly(fieldInfo_); }
 }
 
 public int fieldInfoCount {
 get { return fieldInfo_.Count; }
 }
 
public GardenFieldInfo GetFieldInfo(int index) {
 return fieldInfo_[index];
 }
 public void AddFieldInfo(GardenFieldInfo value) {
 fieldInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
{
foreach (GardenFieldInfo element in fieldInfoList) {
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
  
if (HasOperate) {
output.WriteInt32(1, Operate);
}

do{
foreach (GardenFieldInfo element in fieldInfoList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGardenOperateResult _inst = (GCGardenOperateResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Operate = input.ReadInt32();
break;
}
    case  18: {
GardenFieldInfo subBuilder =  new GardenFieldInfo();
input.ReadMessage(subBuilder);
_inst.AddFieldInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GardenFieldInfo element in fieldInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GardenFieldInfo : PacketDistributed
{

public const int fieldIDFieldNumber = 1;
 private bool hasFieldID;
 private Int32 fieldID_ = 0;
 public bool HasFieldID {
 get { return hasFieldID; }
 }
 public Int32 FieldID {
 get { return fieldID_; }
 set { SetFieldID(value); }
 }
 public void SetFieldID(Int32 value) { 
 hasFieldID = true;
 fieldID_ = value;
 }

public const int herbalInfoFieldNumber = 2;
 private bool hasHerbalInfo;
 private GardenHerbalInfo herbalInfo_ =  new GardenHerbalInfo();
 public bool HasHerbalInfo {
 get { return hasHerbalInfo; }
 }
 public GardenHerbalInfo HerbalInfo {
 get { return herbalInfo_; }
 set { SetHerbalInfo(value); }
 }
 public void SetHerbalInfo(GardenHerbalInfo value) { 
 hasHerbalInfo = true;
 herbalInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFieldID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FieldID);
}
{
int subsize = HerbalInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFieldID) {
output.WriteInt32(1, FieldID);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)HerbalInfo.SerializedSize());
HerbalInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GardenFieldInfo _inst = (GardenFieldInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FieldID = input.ReadInt32();
break;
}
    case  18: {
GardenHerbalInfo subBuilder =  new GardenHerbalInfo();
 input.ReadMessage(subBuilder);
_inst.HerbalInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasHerbalInfo) {
if (!HerbalInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GardenHerbalInfo : PacketDistributed
{

public const int herbalIDFieldNumber = 1;
 private bool hasHerbalID;
 private Int32 herbalID_ = 0;
 public bool HasHerbalID {
 get { return hasHerbalID; }
 }
 public Int32 HerbalID {
 get { return herbalID_; }
 set { SetHerbalID(value); }
 }
 public void SetHerbalID(Int32 value) { 
 hasHerbalID = true;
 herbalID_ = value;
 }

public const int herbalLvFieldNumber = 2;
 private bool hasHerbalLv;
 private Int32 herbalLv_ = 0;
 public bool HasHerbalLv {
 get { return hasHerbalLv; }
 }
 public Int32 HerbalLv {
 get { return herbalLv_; }
 set { SetHerbalLv(value); }
 }
 public void SetHerbalLv(Int32 value) { 
 hasHerbalLv = true;
 herbalLv_ = value;
 }

public const int qualityFieldNumber = 3;
 private bool hasQuality;
 private Int32 quality_ = 0;
 public bool HasQuality {
 get { return hasQuality; }
 }
 public Int32 Quality {
 get { return quality_; }
 set { SetQuality(value); }
 }
 public void SetQuality(Int32 value) { 
 hasQuality = true;
 quality_ = value;
 }

public const int completeTimeFieldNumber = 4;
 private bool hasCompleteTime;
 private Int64 completeTime_ = 0;
 public bool HasCompleteTime {
 get { return hasCompleteTime; }
 }
 public Int64 CompleteTime {
 get { return completeTime_; }
 set { SetCompleteTime(value); }
 }
 public void SetCompleteTime(Int64 value) { 
 hasCompleteTime = true;
 completeTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHerbalID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, HerbalID);
}
 if (HasHerbalLv) {
size += pb::CodedOutputStream.ComputeInt32Size(2, HerbalLv);
}
 if (HasQuality) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Quality);
}
 if (HasCompleteTime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, CompleteTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHerbalID) {
output.WriteInt32(1, HerbalID);
}
 
if (HasHerbalLv) {
output.WriteInt32(2, HerbalLv);
}
 
if (HasQuality) {
output.WriteInt32(3, Quality);
}
 
if (HasCompleteTime) {
output.WriteInt64(4, CompleteTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GardenHerbalInfo _inst = (GardenHerbalInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.HerbalID = input.ReadInt32();
break;
}
   case  16: {
 _inst.HerbalLv = input.ReadInt32();
break;
}
   case  24: {
 _inst.Quality = input.ReadInt32();
break;
}
   case  32: {
 _inst.CompleteTime = input.ReadInt64();
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
