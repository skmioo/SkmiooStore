//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class ActiveData : PacketDistributed
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

public const int countFieldNumber = 2;
 private bool hasCount;
 private Int32 count_ = 0;
 public bool HasCount {
 get { return hasCount; }
 }
 public Int32 Count {
 get { return count_; }
 set { SetCount(value); }
 }
 public void SetCount(Int32 value) { 
 hasCount = true;
 count_ = value;
 }

public const int totalCountFieldNumber = 3;
 private bool hasTotalCount;
 private Int32 totalCount_ = 0;
 public bool HasTotalCount {
 get { return hasTotalCount; }
 }
 public Int32 TotalCount {
 get { return totalCount_; }
 set { SetTotalCount(value); }
 }
 public void SetTotalCount(Int32 value) { 
 hasTotalCount = true;
 totalCount_ = value;
 }

public const int activeStateFieldNumber = 4;
 private bool hasActiveState;
 private Int32 activeState_ = 0;
 public bool HasActiveState {
 get { return hasActiveState; }
 }
 public Int32 ActiveState {
 get { return activeState_; }
 set { SetActiveState(value); }
 }
 public void SetActiveState(Int32 value) { 
 hasActiveState = true;
 activeState_ = value;
 }

public const int opentimeFieldNumber = 5;
 private bool hasOpentime;
 private Int64 opentime_ = 0;
 public bool HasOpentime {
 get { return hasOpentime; }
 }
 public Int64 Opentime {
 get { return opentime_; }
 set { SetOpentime(value); }
 }
 public void SetOpentime(Int64 value) { 
 hasOpentime = true;
 opentime_ = value;
 }

public const int openlevelFieldNumber = 6;
 private bool hasOpenlevel;
 private Int32 openlevel_ = 0;
 public bool HasOpenlevel {
 get { return hasOpenlevel; }
 }
 public Int32 Openlevel {
 get { return openlevel_; }
 set { SetOpenlevel(value); }
 }
 public void SetOpenlevel(Int32 value) { 
 hasOpenlevel = true;
 openlevel_ = value;
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
 if (HasCount) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Count);
}
 if (HasTotalCount) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TotalCount);
}
 if (HasActiveState) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ActiveState);
}
 if (HasOpentime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, Opentime);
}
 if (HasOpenlevel) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Openlevel);
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
 
if (HasCount) {
output.WriteInt32(2, Count);
}
 
if (HasTotalCount) {
output.WriteInt32(3, TotalCount);
}
 
if (HasActiveState) {
output.WriteInt32(4, ActiveState);
}
 
if (HasOpentime) {
output.WriteInt64(5, Opentime);
}
 
if (HasOpenlevel) {
output.WriteInt32(6, Openlevel);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ActiveData _inst = (ActiveData) _base;
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
 _inst.Count = input.ReadInt32();
break;
}
   case  24: {
 _inst.TotalCount = input.ReadInt32();
break;
}
   case  32: {
 _inst.ActiveState = input.ReadInt32();
break;
}
   case  40: {
 _inst.Opentime = input.ReadInt64();
break;
}
   case  48: {
 _inst.Openlevel = input.ReadInt32();
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
public class ActiveStruct : PacketDistributed
{

public const int rewardidFieldNumber = 1;
 private bool hasRewardid;
 private Int32 rewardid_ = 0;
 public bool HasRewardid {
 get { return hasRewardid; }
 }
 public Int32 Rewardid {
 get { return rewardid_; }
 set { SetRewardid(value); }
 }
 public void SetRewardid(Int32 value) { 
 hasRewardid = true;
 rewardid_ = value;
 }

public const int statusFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRewardid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Rewardid);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRewardid) {
output.WriteInt32(1, Rewardid);
}
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ActiveStruct _inst = (ActiveStruct) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Rewardid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Status = input.ReadInt32();
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
public class CGDeepThinkOperation : PacketDistributed
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
 CGDeepThinkOperation _inst = (CGDeepThinkOperation) _base;
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
public class CGGetActiveReward : PacketDistributed
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
 CGGetActiveReward _inst = (CGGetActiveReward) _base;
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
public class CGGetCDKReward : PacketDistributed
{

public const int cdkFieldNumber = 1;
 private bool hasCdk;
 private string cdk_ = "";
 public bool HasCdk {
 get { return hasCdk; }
 }
 public string Cdk {
 get { return cdk_; }
 set { SetCdk(value); }
 }
 public void SetCdk(string value) { 
 hasCdk = true;
 cdk_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCdk) {
size += pb::CodedOutputStream.ComputeStringSize(1, Cdk);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCdk) {
output.WriteString(1, Cdk);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetCDKReward _inst = (CGGetCDKReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Cdk = input.ReadString();
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
public class CGGetDeepThinkExp : PacketDistributed
{

public const int multFieldNumber = 1;
 private bool hasMult;
 private Int32 mult_ = 0;
 public bool HasMult {
 get { return hasMult; }
 }
 public Int32 Mult {
 get { return mult_; }
 set { SetMult(value); }
 }
 public void SetMult(Int32 value) { 
 hasMult = true;
 mult_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Mult);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMult) {
output.WriteInt32(1, Mult);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetDeepThinkExp _inst = (CGGetDeepThinkExp) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Mult = input.ReadInt32();
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
public class CGGetNextDayReward : PacketDistributed
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
 CGGetNextDayReward _inst = (CGGetNextDayReward) _base;
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
public class CGGetPowerMedical : PacketDistributed
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
 CGGetPowerMedical _inst = (CGGetPowerMedical) _base;
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
public class CGOpenActive : PacketDistributed
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
 CGOpenActive _inst = (CGOpenActive) _base;
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
public class GCBroadcastSystemNotice : PacketDistributed
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

public const int lauIdFieldNumber = 2;
 private bool hasLauId;
 private Int32 lauId_ = 0;
 public bool HasLauId {
 get { return hasLauId; }
 }
 public Int32 LauId {
 get { return lauId_; }
 set { SetLauId(value); }
 }
 public void SetLauId(Int32 value) { 
 hasLauId = true;
 lauId_ = value;
 }

public const int paramFieldNumber = 3;
 private pbc::PopsicleList<string> param_ = new pbc::PopsicleList<string>();
 public scg::IList<string> paramList {
 get { return pbc::Lists.AsReadOnly(param_); }
 }
 
 public int paramCount {
 get { return param_.Count; }
 }
 
public string GetParam(int index) {
 return param_[index];
 }
 public void AddParam(string value) {
 param_.Add(value);
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
 if (HasLauId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LauId);
}
{
int dataSize = 0;
foreach (string element in paramList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * param_.Count;
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
 
if (HasLauId) {
output.WriteInt32(2, LauId);
}
{
if (param_.Count > 0) {
foreach (string element in paramList) {
output.WriteString(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBroadcastSystemNotice _inst = (GCBroadcastSystemNotice) _base;
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
 _inst.LauId = input.ReadInt32();
break;
}
   case  26: {
 _inst.AddParam(input.ReadString());
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
public class GCDeepThinkOperationBack : PacketDistributed
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

public const int starttimeFieldNumber = 2;
 private bool hasStarttime;
 private Int64 starttime_ = 0;
 public bool HasStarttime {
 get { return hasStarttime; }
 }
 public Int64 Starttime {
 get { return starttime_; }
 set { SetStarttime(value); }
 }
 public void SetStarttime(Int64 value) { 
 hasStarttime = true;
 starttime_ = value;
 }

public const int endtimeFieldNumber = 3;
 private bool hasEndtime;
 private Int64 endtime_ = 0;
 public bool HasEndtime {
 get { return hasEndtime; }
 }
 public Int64 Endtime {
 get { return endtime_; }
 set { SetEndtime(value); }
 }
 public void SetEndtime(Int64 value) { 
 hasEndtime = true;
 endtime_ = value;
 }

public const int durationFieldNumber = 4;
 private bool hasDuration;
 private Int64 duration_ = 0;
 public bool HasDuration {
 get { return hasDuration; }
 }
 public Int64 Duration {
 get { return duration_; }
 set { SetDuration(value); }
 }
 public void SetDuration(Int64 value) { 
 hasDuration = true;
 duration_ = value;
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
 if (HasStarttime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Starttime);
}
 if (HasEndtime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Endtime);
}
 if (HasDuration) {
size += pb::CodedOutputStream.ComputeInt64Size(4, Duration);
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
 
if (HasStarttime) {
output.WriteInt64(2, Starttime);
}
 
if (HasEndtime) {
output.WriteInt64(3, Endtime);
}
 
if (HasDuration) {
output.WriteInt64(4, Duration);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDeepThinkOperationBack _inst = (GCDeepThinkOperationBack) _base;
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
 _inst.Starttime = input.ReadInt64();
break;
}
   case  24: {
 _inst.Endtime = input.ReadInt64();
break;
}
   case  32: {
 _inst.Duration = input.ReadInt64();
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
public class GCGetActiveRewardBack : PacketDistributed
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

public const int rewardidFieldNumber = 2;
 private bool hasRewardid;
 private Int32 rewardid_ = 0;
 public bool HasRewardid {
 get { return hasRewardid; }
 }
 public Int32 Rewardid {
 get { return rewardid_; }
 set { SetRewardid(value); }
 }
 public void SetRewardid(Int32 value) { 
 hasRewardid = true;
 rewardid_ = value;
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
 if (HasRewardid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Rewardid);
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
 
if (HasRewardid) {
output.WriteInt32(2, Rewardid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetActiveRewardBack _inst = (GCGetActiveRewardBack) _base;
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
 _inst.Rewardid = input.ReadInt32();
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
public class GCGetCDKRewardBack : PacketDistributed
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
 GCGetCDKRewardBack _inst = (GCGetCDKRewardBack) _base;
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
public class GCGetDeepThinkExpBack : PacketDistributed
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
 GCGetDeepThinkExpBack _inst = (GCGetDeepThinkExpBack) _base;
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
public class GCGetNextDayRewardBack : PacketDistributed
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
 GCGetNextDayRewardBack _inst = (GCGetNextDayRewardBack) _base;
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
public class GCGetPowerMedicalBack : PacketDistributed
{

public const int powerMedicalDataFieldNumber = 1;
 private pbc::PopsicleList<PowerMedicalData> powerMedicalData_ = new pbc::PopsicleList<PowerMedicalData>();
 public scg::IList<PowerMedicalData> powerMedicalDataList {
 get { return pbc::Lists.AsReadOnly(powerMedicalData_); }
 }
 
 public int powerMedicalDataCount {
 get { return powerMedicalData_.Count; }
 }
 
public PowerMedicalData GetPowerMedicalData(int index) {
 return powerMedicalData_[index];
 }
 public void AddPowerMedicalData(PowerMedicalData value) {
 powerMedicalData_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (PowerMedicalData element in powerMedicalDataList) {
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
foreach (PowerMedicalData element in powerMedicalDataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetPowerMedicalBack _inst = (GCGetPowerMedicalBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
PowerMedicalData subBuilder =  new PowerMedicalData();
input.ReadMessage(subBuilder);
_inst.AddPowerMedicalData(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PowerMedicalData element in powerMedicalDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOpenActiveBack : PacketDistributed
{

public const int sumactFieldNumber = 1;
 private bool hasSumact;
 private Int32 sumact_ = 0;
 public bool HasSumact {
 get { return hasSumact; }
 }
 public Int32 Sumact {
 get { return sumact_; }
 set { SetSumact(value); }
 }
 public void SetSumact(Int32 value) { 
 hasSumact = true;
 sumact_ = value;
 }

public const int activedataFieldNumber = 2;
 private pbc::PopsicleList<ActiveData> activedata_ = new pbc::PopsicleList<ActiveData>();
 public scg::IList<ActiveData> activedataList {
 get { return pbc::Lists.AsReadOnly(activedata_); }
 }
 
 public int activedataCount {
 get { return activedata_.Count; }
 }
 
public ActiveData GetActivedata(int index) {
 return activedata_[index];
 }
 public void AddActivedata(ActiveData value) {
 activedata_.Add(value);
 }

public const int actiestructFieldNumber = 3;
 private pbc::PopsicleList<ActiveStruct> actiestruct_ = new pbc::PopsicleList<ActiveStruct>();
 public scg::IList<ActiveStruct> actiestructList {
 get { return pbc::Lists.AsReadOnly(actiestruct_); }
 }
 
 public int actiestructCount {
 get { return actiestruct_.Count; }
 }
 
public ActiveStruct GetActiestruct(int index) {
 return actiestruct_[index];
 }
 public void AddActiestruct(ActiveStruct value) {
 actiestruct_.Add(value);
 }

public const int resetFlagFieldNumber = 4;
 private bool hasResetFlag;
 private Int32 resetFlag_ = 0;
 public bool HasResetFlag {
 get { return hasResetFlag; }
 }
 public Int32 ResetFlag {
 get { return resetFlag_; }
 set { SetResetFlag(value); }
 }
 public void SetResetFlag(Int32 value) { 
 hasResetFlag = true;
 resetFlag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSumact) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sumact);
}
{
foreach (ActiveData element in activedataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActiveStruct element in actiestructList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasResetFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ResetFlag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSumact) {
output.WriteInt32(1, Sumact);
}

do{
foreach (ActiveData element in activedataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActiveStruct element in actiestructList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasResetFlag) {
output.WriteInt32(4, ResetFlag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOpenActiveBack _inst = (GCOpenActiveBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sumact = input.ReadInt32();
break;
}
    case  18: {
ActiveData subBuilder =  new ActiveData();
input.ReadMessage(subBuilder);
_inst.AddActivedata(subBuilder);
break;
}
    case  26: {
ActiveStruct subBuilder =  new ActiveStruct();
input.ReadMessage(subBuilder);
_inst.AddActiestruct(subBuilder);
break;
}
   case  32: {
 _inst.ResetFlag = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ActiveData element in activedataList) {
if (!element.IsInitialized()) return false;
}
foreach (ActiveStruct element in actiestructList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushNextDayReward : PacketDistributed
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

public const int gettimeFieldNumber = 2;
 private bool hasGettime;
 private Int64 gettime_ = 0;
 public bool HasGettime {
 get { return hasGettime; }
 }
 public Int64 Gettime {
 get { return gettime_; }
 set { SetGettime(value); }
 }
 public void SetGettime(Int64 value) { 
 hasGettime = true;
 gettime_ = value;
 }

public const int servertimeFieldNumber = 3;
 private bool hasServertime;
 private Int64 servertime_ = 0;
 public bool HasServertime {
 get { return hasServertime; }
 }
 public Int64 Servertime {
 get { return servertime_; }
 set { SetServertime(value); }
 }
 public void SetServertime(Int64 value) { 
 hasServertime = true;
 servertime_ = value;
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
 if (HasGettime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Gettime);
}
 if (HasServertime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Servertime);
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
 
if (HasGettime) {
output.WriteInt64(2, Gettime);
}
 
if (HasServertime) {
output.WriteInt64(3, Servertime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushNextDayReward _inst = (GCPushNextDayReward) _base;
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
 _inst.Gettime = input.ReadInt64();
break;
}
   case  24: {
 _inst.Servertime = input.ReadInt64();
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
public class PowerMedicalData : PacketDistributed
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

public const int powerFieldNumber = 2;
 private bool hasPower;
 private Int32 power_ = 0;
 public bool HasPower {
 get { return hasPower; }
 }
 public Int32 Power {
 get { return power_; }
 set { SetPower(value); }
 }
 public void SetPower(Int32 value) { 
 hasPower = true;
 power_ = value;
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
 if (HasPower) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Power);
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
 
if (HasPower) {
output.WriteInt32(2, Power);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PowerMedicalData _inst = (PowerMedicalData) _base;
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
 _inst.Power = input.ReadInt32();
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
