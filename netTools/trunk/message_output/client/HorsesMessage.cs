//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGChoseHorse : PacketDistributed
{

public const int horseidFieldNumber = 1;
 private bool hasHorseid;
 private Int64 horseid_ = 0;
 public bool HasHorseid {
 get { return hasHorseid; }
 }
 public Int64 Horseid {
 get { return horseid_; }
 set { SetHorseid(value); }
 }
 public void SetHorseid(Int64 value) { 
 hasHorseid = true;
 horseid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHorseid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Horseid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHorseid) {
output.WriteInt64(1, Horseid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGChoseHorse _inst = (CGChoseHorse) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Horseid = input.ReadInt64();
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
public class CGCultureToUpStar : PacketDistributed
{

public const int horseidFieldNumber = 1;
 private bool hasHorseid;
 private Int64 horseid_ = 0;
 public bool HasHorseid {
 get { return hasHorseid; }
 }
 public Int64 Horseid {
 get { return horseid_; }
 set { SetHorseid(value); }
 }
 public void SetHorseid(Int64 value) { 
 hasHorseid = true;
 horseid_ = value;
 }

public const int usegemflagFieldNumber = 2;
 private bool hasUsegemflag;
 private Int32 usegemflag_ = 0;
 public bool HasUsegemflag {
 get { return hasUsegemflag; }
 }
 public Int32 Usegemflag {
 get { return usegemflag_; }
 set { SetUsegemflag(value); }
 }
 public void SetUsegemflag(Int32 value) { 
 hasUsegemflag = true;
 usegemflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHorseid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Horseid);
}
 if (HasUsegemflag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Usegemflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHorseid) {
output.WriteInt64(1, Horseid);
}
 
if (HasUsegemflag) {
output.WriteInt32(2, Usegemflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCultureToUpStar _inst = (CGCultureToUpStar) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Horseid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Usegemflag = input.ReadInt32();
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
public class CGLookHorse : PacketDistributed
{

public const int playerUidFieldNumber = 1;
 private bool hasPlayerUid;
 private Int64 playerUid_ = 0;
 public bool HasPlayerUid {
 get { return hasPlayerUid; }
 }
 public Int64 PlayerUid {
 get { return playerUid_; }
 set { SetPlayerUid(value); }
 }
 public void SetPlayerUid(Int64 value) { 
 hasPlayerUid = true;
 playerUid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerUid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerUid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerUid) {
output.WriteInt64(1, PlayerUid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLookHorse _inst = (CGLookHorse) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerUid = input.ReadInt64();
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
public class CGUseHorse : PacketDistributed
{

public const int useflagFieldNumber = 1;
 private bool hasUseflag;
 private Int32 useflag_ = 0;
 public bool HasUseflag {
 get { return hasUseflag; }
 }
 public Int32 Useflag {
 get { return useflag_; }
 set { SetUseflag(value); }
 }
 public void SetUseflag(Int32 value) { 
 hasUseflag = true;
 useflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasUseflag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Useflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasUseflag) {
output.WriteInt32(1, Useflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUseHorse _inst = (CGUseHorse) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Useflag = input.ReadInt32();
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
public class GCBackHorseData : PacketDistributed
{

public const int horseInfoFieldNumber = 1;
 private pbc::PopsicleList<HorseInfo> horseInfo_ = new pbc::PopsicleList<HorseInfo>();
 public scg::IList<HorseInfo> horseInfoList {
 get { return pbc::Lists.AsReadOnly(horseInfo_); }
 }
 
 public int horseInfoCount {
 get { return horseInfo_.Count; }
 }
 
public HorseInfo GetHorseInfo(int index) {
 return horseInfo_[index];
 }
 public void AddHorseInfo(HorseInfo value) {
 horseInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (HorseInfo element in horseInfoList) {
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
foreach (HorseInfo element in horseInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackHorseData _inst = (GCBackHorseData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
HorseInfo subBuilder =  new HorseInfo();
input.ReadMessage(subBuilder);
_inst.AddHorseInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (HorseInfo element in horseInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCChoseHorseBack : PacketDistributed
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
 GCChoseHorseBack _inst = (GCChoseHorseBack) _base;
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
public class GCCultureToUpStarBack : PacketDistributed
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

public const int luckflagFieldNumber = 2;
 private bool hasLuckflag;
 private Int32 luckflag_ = 0;
 public bool HasLuckflag {
 get { return hasLuckflag; }
 }
 public Int32 Luckflag {
 get { return luckflag_; }
 set { SetLuckflag(value); }
 }
 public void SetLuckflag(Int32 value) { 
 hasLuckflag = true;
 luckflag_ = value;
 }

public const int horseInfoFieldNumber = 3;
 private bool hasHorseInfo;
 private HorseInfo horseInfo_ =  new HorseInfo();
 public bool HasHorseInfo {
 get { return hasHorseInfo; }
 }
 public HorseInfo HorseInfo {
 get { return horseInfo_; }
 set { SetHorseInfo(value); }
 }
 public void SetHorseInfo(HorseInfo value) { 
 hasHorseInfo = true;
 horseInfo_ = value;
 }

public const int newhorseInfoFieldNumber = 4;
 private bool hasNewhorseInfo;
 private HorseInfo newhorseInfo_ =  new HorseInfo();
 public bool HasNewhorseInfo {
 get { return hasNewhorseInfo; }
 }
 public HorseInfo NewhorseInfo {
 get { return newhorseInfo_; }
 set { SetNewhorseInfo(value); }
 }
 public void SetNewhorseInfo(HorseInfo value) { 
 hasNewhorseInfo = true;
 newhorseInfo_ = value;
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
 if (HasLuckflag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Luckflag);
}
{
int subsize = HorseInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = NewhorseInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasLuckflag) {
output.WriteInt32(2, Luckflag);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)HorseInfo.SerializedSize());
HorseInfo.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)NewhorseInfo.SerializedSize());
NewhorseInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCultureToUpStarBack _inst = (GCCultureToUpStarBack) _base;
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
 _inst.Luckflag = input.ReadInt32();
break;
}
    case  26: {
HorseInfo subBuilder =  new HorseInfo();
 input.ReadMessage(subBuilder);
_inst.HorseInfo = subBuilder;
break;
}
    case  34: {
HorseInfo subBuilder =  new HorseInfo();
 input.ReadMessage(subBuilder);
_inst.NewhorseInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasHorseInfo) {
if (!HorseInfo.IsInitialized()) return false;
}
  if (HasNewhorseInfo) {
if (!NewhorseInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetNewHorse : PacketDistributed
{

public const int horseIdFieldNumber = 1;
 private bool hasHorseId;
 private Int32 horseId_ = 0;
 public bool HasHorseId {
 get { return hasHorseId; }
 }
 public Int32 HorseId {
 get { return horseId_; }
 set { SetHorseId(value); }
 }
 public void SetHorseId(Int32 value) { 
 hasHorseId = true;
 horseId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHorseId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, HorseId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHorseId) {
output.WriteInt32(1, HorseId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetNewHorse _inst = (GCGetNewHorse) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.HorseId = input.ReadInt32();
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
public class GCLookHorseBack : PacketDistributed
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

public const int horseIdFieldNumber = 2;
 private bool hasHorseId;
 private Int32 horseId_ = 0;
 public bool HasHorseId {
 get { return hasHorseId; }
 }
 public Int32 HorseId {
 get { return horseId_; }
 set { SetHorseId(value); }
 }
 public void SetHorseId(Int32 value) { 
 hasHorseId = true;
 horseId_ = value;
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
 if (HasHorseId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, HorseId);
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
 
if (HasHorseId) {
output.WriteInt32(2, HorseId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLookHorseBack _inst = (GCLookHorseBack) _base;
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
 _inst.HorseId = input.ReadInt32();
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
public class GCUseHorseBack : PacketDistributed
{

public const int guidFieldNumber = 1;
 private bool hasGuid;
 private Int64 guid_ = 0;
 public bool HasGuid {
 get { return hasGuid; }
 }
 public Int64 Guid {
 get { return guid_; }
 set { SetGuid(value); }
 }
 public void SetGuid(Int64 value) { 
 hasGuid = true;
 guid_ = value;
 }

public const int useflagFieldNumber = 2;
 private bool hasUseflag;
 private Int32 useflag_ = 0;
 public bool HasUseflag {
 get { return hasUseflag; }
 }
 public Int32 Useflag {
 get { return useflag_; }
 set { SetUseflag(value); }
 }
 public void SetUseflag(Int32 value) { 
 hasUseflag = true;
 useflag_ = value;
 }

public const int flagFieldNumber = 3;
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
  if (HasGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Guid);
}
 if (HasUseflag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Useflag);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGuid) {
output.WriteInt64(1, Guid);
}
 
if (HasUseflag) {
output.WriteInt32(2, Useflag);
}
 
if (HasFlag) {
output.WriteInt32(3, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUseHorseBack _inst = (GCUseHorseBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Guid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Useflag = input.ReadInt32();
break;
}
   case  24: {
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


}
