//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGChallengeBatchOperate : PacketDistributed
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
 CGChallengeBatchOperate _inst = (CGChallengeBatchOperate) _base;
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
public class GCChallengeBatchInfo : PacketDistributed
{

public const int boFieldNumber = 1;
 private bool hasBo;
 private Int32 bo_ = 0;
 public bool HasBo {
 get { return hasBo; }
 }
 public Int32 Bo {
 get { return bo_; }
 set { SetBo(value); }
 }
 public void SetBo(Int32 value) { 
 hasBo = true;
 bo_ = value;
 }

public const int mopNumFieldNumber = 2;
 private bool hasMopNum;
 private Int32 mopNum_ = 0;
 public bool HasMopNum {
 get { return hasMopNum; }
 }
 public Int32 MopNum {
 get { return mopNum_; }
 set { SetMopNum(value); }
 }
 public void SetMopNum(Int32 value) { 
 hasMopNum = true;
 mopNum_ = value;
 }

public const int maxBoFieldNumber = 3;
 private bool hasMaxBo;
 private Int32 maxBo_ = 0;
 public bool HasMaxBo {
 get { return hasMaxBo; }
 }
 public Int32 MaxBo {
 get { return maxBo_; }
 set { SetMaxBo(value); }
 }
 public void SetMaxBo(Int32 value) { 
 hasMaxBo = true;
 maxBo_ = value;
 }

public const int maxMopNumFieldNumber = 4;
 private bool hasMaxMopNum;
 private Int32 maxMopNum_ = 0;
 public bool HasMaxMopNum {
 get { return hasMaxMopNum; }
 }
 public Int32 MaxMopNum {
 get { return maxMopNum_; }
 set { SetMaxMopNum(value); }
 }
 public void SetMaxMopNum(Int32 value) { 
 hasMaxMopNum = true;
 maxMopNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBo) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Bo);
}
 if (HasMopNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MopNum);
}
 if (HasMaxBo) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MaxBo);
}
 if (HasMaxMopNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, MaxMopNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBo) {
output.WriteInt32(1, Bo);
}
 
if (HasMopNum) {
output.WriteInt32(2, MopNum);
}
 
if (HasMaxBo) {
output.WriteInt32(3, MaxBo);
}
 
if (HasMaxMopNum) {
output.WriteInt32(4, MaxMopNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChallengeBatchInfo _inst = (GCChallengeBatchInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Bo = input.ReadInt32();
break;
}
   case  16: {
 _inst.MopNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.MaxBo = input.ReadInt32();
break;
}
   case  32: {
 _inst.MaxMopNum = input.ReadInt32();
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
public class GCChallengeBatchOperateBack : PacketDistributed
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChallengeBatchOperateBack _inst = (GCChallengeBatchOperateBack) _base;
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
public class GCChallengeBatchRefreshTime : PacketDistributed
{

public const int totalTimeFieldNumber = 1;
 private bool hasTotalTime;
 private Int32 totalTime_ = 0;
 public bool HasTotalTime {
 get { return hasTotalTime; }
 }
 public Int32 TotalTime {
 get { return totalTime_; }
 set { SetTotalTime(value); }
 }
 public void SetTotalTime(Int32 value) { 
 hasTotalTime = true;
 totalTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTotalTime) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TotalTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTotalTime) {
output.WriteInt32(1, TotalTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChallengeBatchRefreshTime _inst = (GCChallengeBatchRefreshTime) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TotalTime = input.ReadInt32();
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
public class GCChallengeBatchReward : PacketDistributed
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

public const int boFieldNumber = 3;
 private bool hasBo;
 private Int32 bo_ = 0;
 public bool HasBo {
 get { return hasBo; }
 }
 public Int32 Bo {
 get { return bo_; }
 set { SetBo(value); }
 }
 public void SetBo(Int32 value) { 
 hasBo = true;
 bo_ = value;
 }

public const int mopNumFieldNumber = 4;
 private bool hasMopNum;
 private Int32 mopNum_ = 0;
 public bool HasMopNum {
 get { return hasMopNum; }
 }
 public Int32 MopNum {
 get { return mopNum_; }
 set { SetMopNum(value); }
 }
 public void SetMopNum(Int32 value) { 
 hasMopNum = true;
 mopNum_ = value;
 }

public const int rewardItemsFieldNumber = 5;
 private pbc::PopsicleList<Iteminfo> rewardItems_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> rewardItemsList {
 get { return pbc::Lists.AsReadOnly(rewardItems_); }
 }
 
 public int rewardItemsCount {
 get { return rewardItems_.Count; }
 }
 
public Iteminfo GetRewardItems(int index) {
 return rewardItems_[index];
 }
 public void AddRewardItems(Iteminfo value) {
 rewardItems_.Add(value);
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 if (HasBo) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bo);
}
 if (HasMopNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, MopNum);
}
{
foreach (Iteminfo element in rewardItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 
if (HasBo) {
output.WriteInt32(3, Bo);
}
 
if (HasMopNum) {
output.WriteInt32(4, MopNum);
}

do{
foreach (Iteminfo element in rewardItemsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChallengeBatchReward _inst = (GCChallengeBatchReward) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
   case  24: {
 _inst.Bo = input.ReadInt32();
break;
}
   case  32: {
 _inst.MopNum = input.ReadInt32();
break;
}
    case  42: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddRewardItems(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Iteminfo element in rewardItemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
