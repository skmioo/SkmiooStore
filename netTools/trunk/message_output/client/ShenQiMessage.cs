//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGShenQiLevelUp : PacketDistributed
{

public const int bidFieldNumber = 1;
 private bool hasBid;
 private Int32 bid_ = 0;
 public bool HasBid {
 get { return hasBid; }
 }
 public Int32 Bid {
 get { return bid_; }
 set { SetBid(value); }
 }
 public void SetBid(Int32 value) { 
 hasBid = true;
 bid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Bid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBid) {
output.WriteInt32(1, Bid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGShenQiLevelUp _inst = (CGShenQiLevelUp) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Bid = input.ReadInt32();
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
public class CGShenQiWear : PacketDistributed
{

public const int bidFieldNumber = 1;
 private bool hasBid;
 private Int32 bid_ = 0;
 public bool HasBid {
 get { return hasBid; }
 }
 public Int32 Bid {
 get { return bid_; }
 set { SetBid(value); }
 }
 public void SetBid(Int32 value) { 
 hasBid = true;
 bid_ = value;
 }

public const int isWearFieldNumber = 2;
 private bool hasIsWear;
 private Int32 isWear_ = 0;
 public bool HasIsWear {
 get { return hasIsWear; }
 }
 public Int32 IsWear {
 get { return isWear_; }
 set { SetIsWear(value); }
 }
 public void SetIsWear(Int32 value) { 
 hasIsWear = true;
 isWear_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Bid);
}
 if (HasIsWear) {
size += pb::CodedOutputStream.ComputeInt32Size(2, IsWear);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBid) {
output.WriteInt32(1, Bid);
}
 
if (HasIsWear) {
output.WriteInt32(2, IsWear);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGShenQiWear _inst = (CGShenQiWear) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  16: {
 _inst.IsWear = input.ReadInt32();
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
public class GCRefreshShenQiSkill : PacketDistributed
{

public const int shenQiSkilldataFieldNumber = 1;
 private bool hasShenQiSkilldata;
 private SkillItemData shenQiSkilldata_ =  new SkillItemData();
 public bool HasShenQiSkilldata {
 get { return hasShenQiSkilldata; }
 }
 public SkillItemData ShenQiSkilldata {
 get { return shenQiSkilldata_; }
 set { SetShenQiSkilldata(value); }
 }
 public void SetShenQiSkilldata(SkillItemData value) { 
 hasShenQiSkilldata = true;
 shenQiSkilldata_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = ShenQiSkilldata.SerializedSize();	
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
output.WriteRawVarint32((uint)ShenQiSkilldata.SerializedSize());
ShenQiSkilldata.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshShenQiSkill _inst = (GCRefreshShenQiSkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
SkillItemData subBuilder =  new SkillItemData();
 input.ReadMessage(subBuilder);
_inst.ShenQiSkilldata = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasShenQiSkilldata) {
if (!ShenQiSkilldata.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCShenQiLevel : PacketDistributed
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

public const int resultFieldNumber = 2;
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

public const int infosFieldNumber = 3;
 private pbc::PopsicleList<ShenQiInfo> infos_ = new pbc::PopsicleList<ShenQiInfo>();
 public scg::IList<ShenQiInfo> infosList {
 get { return pbc::Lists.AsReadOnly(infos_); }
 }
 
 public int infosCount {
 get { return infos_.Count; }
 }
 
public ShenQiInfo GetInfos(int index) {
 return infos_[index];
 }
 public void AddInfos(ShenQiInfo value) {
 infos_.Add(value);
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
foreach (ShenQiInfo element in infosList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}

do{
foreach (ShenQiInfo element in infosList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCShenQiLevel _inst = (GCShenQiLevel) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
ShenQiInfo subBuilder =  new ShenQiInfo();
input.ReadMessage(subBuilder);
_inst.AddInfos(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ShenQiInfo element in infosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class ShenQiInfo : PacketDistributed
{

public const int sidFieldNumber = 1;
 private bool hasSid;
 private Int32 sid_ = 0;
 public bool HasSid {
 get { return hasSid; }
 }
 public Int32 Sid {
 get { return sid_; }
 set { SetSid(value); }
 }
 public void SetSid(Int32 value) { 
 hasSid = true;
 sid_ = value;
 }

public const int canFieldNumber = 2;
 private bool hasCan;
 private Int32 can_ = 0;
 public bool HasCan {
 get { return hasCan; }
 }
 public Int32 Can {
 get { return can_; }
 set { SetCan(value); }
 }
 public void SetCan(Int32 value) { 
 hasCan = true;
 can_ = value;
 }

public const int isWearFieldNumber = 3;
 private bool hasIsWear;
 private Int32 isWear_ = 0;
 public bool HasIsWear {
 get { return hasIsWear; }
 }
 public Int32 IsWear {
 get { return isWear_; }
 set { SetIsWear(value); }
 }
 public void SetIsWear(Int32 value) { 
 hasIsWear = true;
 isWear_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sid);
}
 if (HasCan) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Can);
}
 if (HasIsWear) {
size += pb::CodedOutputStream.ComputeInt32Size(3, IsWear);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSid) {
output.WriteInt32(1, Sid);
}
 
if (HasCan) {
output.WriteInt32(2, Can);
}
 
if (HasIsWear) {
output.WriteInt32(3, IsWear);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ShenQiInfo _inst = (ShenQiInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Can = input.ReadInt32();
break;
}
   case  24: {
 _inst.IsWear = input.ReadInt32();
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
