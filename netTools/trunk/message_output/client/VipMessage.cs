//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetRewardData : PacketDistributed
{

public const int vipFieldNumber = 1;
 private bool hasVip;
 private Int32 vip_ = 0;
 public bool HasVip {
 get { return hasVip; }
 }
 public Int32 Vip {
 get { return vip_; }
 set { SetVip(value); }
 }
 public void SetVip(Int32 value) { 
 hasVip = true;
 vip_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Vip);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasVip) {
output.WriteInt32(1, Vip);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetRewardData _inst = (CGGetRewardData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Vip = input.ReadInt32();
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
public class GCGetRewardDataBack : PacketDistributed
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

public const int vipFieldNumber = 2;
 private bool hasVip;
 private Int32 vip_ = 0;
 public bool HasVip {
 get { return hasVip; }
 }
 public Int32 Vip {
 get { return vip_; }
 set { SetVip(value); }
 }
 public void SetVip(Int32 value) { 
 hasVip = true;
 vip_ = value;
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
 if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Vip);
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
 
if (HasVip) {
output.WriteInt32(2, Vip);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetRewardDataBack _inst = (GCGetRewardDataBack) _base;
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
 _inst.Vip = input.ReadInt32();
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
public class GCPushVipBack : PacketDistributed
{

public const int vipFieldNumber = 1;
 private bool hasVip;
 private Int32 vip_ = 0;
 public bool HasVip {
 get { return hasVip; }
 }
 public Int32 Vip {
 get { return vip_; }
 set { SetVip(value); }
 }
 public void SetVip(Int32 value) { 
 hasVip = true;
 vip_ = value;
 }

public const int summoneyFieldNumber = 2;
 private bool hasSummoney;
 private Int32 summoney_ = 0;
 public bool HasSummoney {
 get { return hasSummoney; }
 }
 public Int32 Summoney {
 get { return summoney_; }
 set { SetSummoney(value); }
 }
 public void SetSummoney(Int32 value) { 
 hasSummoney = true;
 summoney_ = value;
 }

public const int vipdataFieldNumber = 3;
 private pbc::PopsicleList<VipData> vipdata_ = new pbc::PopsicleList<VipData>();
 public scg::IList<VipData> vipdataList {
 get { return pbc::Lists.AsReadOnly(vipdata_); }
 }
 
 public int vipdataCount {
 get { return vipdata_.Count; }
 }
 
public VipData GetVipdata(int index) {
 return vipdata_[index];
 }
 public void AddVipdata(VipData value) {
 vipdata_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Vip);
}
 if (HasSummoney) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Summoney);
}
{
foreach (VipData element in vipdataList) {
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
  
if (HasVip) {
output.WriteInt32(1, Vip);
}
 
if (HasSummoney) {
output.WriteInt32(2, Summoney);
}

do{
foreach (VipData element in vipdataList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushVipBack _inst = (GCPushVipBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Vip = input.ReadInt32();
break;
}
   case  16: {
 _inst.Summoney = input.ReadInt32();
break;
}
    case  26: {
VipData subBuilder =  new VipData();
input.ReadMessage(subBuilder);
_inst.AddVipdata(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (VipData element in vipdataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
