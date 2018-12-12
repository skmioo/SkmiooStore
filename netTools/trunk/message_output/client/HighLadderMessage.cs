//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetAchievementData : PacketDistributed
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
 CGGetAchievementData _inst = (CGGetAchievementData) _base;
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
public class CGGetHighLadderReward : PacketDistributed
{

public const int conditionFieldNumber = 1;
 private bool hasCondition;
 private Int32 condition_ = 0;
 public bool HasCondition {
 get { return hasCondition; }
 }
 public Int32 Condition {
 get { return condition_; }
 set { SetCondition(value); }
 }
 public void SetCondition(Int32 value) { 
 hasCondition = true;
 condition_ = value;
 }

public const int achievementidFieldNumber = 2;
 private bool hasAchievementid;
 private Int32 achievementid_ = 0;
 public bool HasAchievementid {
 get { return hasAchievementid; }
 }
 public Int32 Achievementid {
 get { return achievementid_; }
 set { SetAchievementid(value); }
 }
 public void SetAchievementid(Int32 value) { 
 hasAchievementid = true;
 achievementid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCondition) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Condition);
}
 if (HasAchievementid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Achievementid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCondition) {
output.WriteInt32(1, Condition);
}
 
if (HasAchievementid) {
output.WriteInt32(2, Achievementid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetHighLadderReward _inst = (CGGetHighLadderReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Condition = input.ReadInt32();
break;
}
   case  16: {
 _inst.Achievementid = input.ReadInt32();
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
public class CGLockTitle : PacketDistributed
{

public const int lockFieldNumber = 1;
 private bool hasLock;
 private Int32 lock_ = 0;
 public bool HasLock {
 get { return hasLock; }
 }
 public Int32 Lock {
 get { return lock_; }
 set { SetLock(value); }
 }
 public void SetLock(Int32 value) { 
 hasLock = true;
 lock_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLock) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Lock);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLock) {
output.WriteInt32(1, Lock);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLockTitle _inst = (CGLockTitle) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Lock = input.ReadInt32();
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
public class CGUseTitle : PacketDistributed
{

public const int titleidFieldNumber = 1;
 private bool hasTitleid;
 private Int32 titleid_ = 0;
 public bool HasTitleid {
 get { return hasTitleid; }
 }
 public Int32 Titleid {
 get { return titleid_; }
 set { SetTitleid(value); }
 }
 public void SetTitleid(Int32 value) { 
 hasTitleid = true;
 titleid_ = value;
 }

public const int operateTypeFieldNumber = 2;
 private bool hasOperateType;
 private Int32 operateType_ = 0;
 public bool HasOperateType {
 get { return hasOperateType; }
 }
 public Int32 OperateType {
 get { return operateType_; }
 set { SetOperateType(value); }
 }
 public void SetOperateType(Int32 value) { 
 hasOperateType = true;
 operateType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTitleid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Titleid);
}
 if (HasOperateType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, OperateType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTitleid) {
output.WriteInt32(1, Titleid);
}
 
if (HasOperateType) {
output.WriteInt32(2, OperateType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUseTitle _inst = (CGUseTitle) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Titleid = input.ReadInt32();
break;
}
   case  16: {
 _inst.OperateType = input.ReadInt32();
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
public class GCGetAchievementDataBack : PacketDistributed
{

public const int mvtFieldNumber = 1;
 private pbc::PopsicleList<Achievement> mvt_ = new pbc::PopsicleList<Achievement>();
 public scg::IList<Achievement> mvtList {
 get { return pbc::Lists.AsReadOnly(mvt_); }
 }
 
 public int mvtCount {
 get { return mvt_.Count; }
 }
 
public Achievement GetMvt(int index) {
 return mvt_[index];
 }
 public void AddMvt(Achievement value) {
 mvt_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (Achievement element in mvtList) {
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
foreach (Achievement element in mvtList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetAchievementDataBack _inst = (GCGetAchievementDataBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Achievement subBuilder =  new Achievement();
input.ReadMessage(subBuilder);
_inst.AddMvt(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Achievement element in mvtList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetHighLadderRewardBack : PacketDistributed
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

public const int nextachievementidFieldNumber = 2;
 private bool hasNextachievementid;
 private Int32 nextachievementid_ = 0;
 public bool HasNextachievementid {
 get { return hasNextachievementid; }
 }
 public Int32 Nextachievementid {
 get { return nextachievementid_; }
 set { SetNextachievementid(value); }
 }
 public void SetNextachievementid(Int32 value) { 
 hasNextachievementid = true;
 nextachievementid_ = value;
 }

public const int isoverFieldNumber = 3;
 private bool hasIsover;
 private Int32 isover_ = 0;
 public bool HasIsover {
 get { return hasIsover; }
 }
 public Int32 Isover {
 get { return isover_; }
 set { SetIsover(value); }
 }
 public void SetIsover(Int32 value) { 
 hasIsover = true;
 isover_ = value;
 }

public const int curachievementidFieldNumber = 4;
 private bool hasCurachievementid;
 private Int32 curachievementid_ = 0;
 public bool HasCurachievementid {
 get { return hasCurachievementid; }
 }
 public Int32 Curachievementid {
 get { return curachievementid_; }
 set { SetCurachievementid(value); }
 }
 public void SetCurachievementid(Int32 value) { 
 hasCurachievementid = true;
 curachievementid_ = value;
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
 if (HasNextachievementid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Nextachievementid);
}
 if (HasIsover) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Isover);
}
 if (HasCurachievementid) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Curachievementid);
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
 
if (HasNextachievementid) {
output.WriteInt32(2, Nextachievementid);
}
 
if (HasIsover) {
output.WriteInt32(3, Isover);
}
 
if (HasCurachievementid) {
output.WriteInt32(4, Curachievementid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetHighLadderRewardBack _inst = (GCGetHighLadderRewardBack) _base;
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
 _inst.Nextachievementid = input.ReadInt32();
break;
}
   case  24: {
 _inst.Isover = input.ReadInt32();
break;
}
   case  32: {
 _inst.Curachievementid = input.ReadInt32();
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
public class GCHighLadderOver : PacketDistributed
{

public const int mvtFieldNumber = 1;
 private bool hasMvt;
 private Achievement mvt_ =  new Achievement();
 public bool HasMvt {
 get { return hasMvt; }
 }
 public Achievement Mvt {
 get { return mvt_; }
 set { SetMvt(value); }
 }
 public void SetMvt(Achievement value) { 
 hasMvt = true;
 mvt_ = value;
 }

public const int titleFieldNumber = 2;
 private bool hasTitle;
 private Titlel title_ =  new Titlel();
 public bool HasTitle {
 get { return hasTitle; }
 }
 public Titlel Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(Titlel value) { 
 hasTitle = true;
 title_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Mvt.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Title.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Mvt.SerializedSize());
Mvt.WriteTo(output);

}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Title.SerializedSize());
Title.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHighLadderOver _inst = (GCHighLadderOver) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Achievement subBuilder =  new Achievement();
 input.ReadMessage(subBuilder);
_inst.Mvt = subBuilder;
break;
}
    case  18: {
Titlel subBuilder =  new Titlel();
 input.ReadMessage(subBuilder);
_inst.Title = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasMvt) {
if (!Mvt.IsInitialized()) return false;
}
  if (HasTitle) {
if (!Title.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLockTitleBack : PacketDistributed
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

public const int lockFieldNumber = 2;
 private bool hasLock;
 private Int32 lock_ = 0;
 public bool HasLock {
 get { return hasLock; }
 }
 public Int32 Lock {
 get { return lock_; }
 set { SetLock(value); }
 }
 public void SetLock(Int32 value) { 
 hasLock = true;
 lock_ = value;
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
 if (HasLock) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Lock);
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
 
if (HasLock) {
output.WriteInt32(2, Lock);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLockTitleBack _inst = (GCLockTitleBack) _base;
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
 _inst.Lock = input.ReadInt32();
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
public class GCPushHighLadderListBack : PacketDistributed
{

public const int titlelistFieldNumber = 1;
 private pbc::PopsicleList<Titlel> titlelist_ = new pbc::PopsicleList<Titlel>();
 public scg::IList<Titlel> titlelistList {
 get { return pbc::Lists.AsReadOnly(titlelist_); }
 }
 
 public int titlelistCount {
 get { return titlelist_.Count; }
 }
 
public Titlel GetTitlelist(int index) {
 return titlelist_[index];
 }
 public void AddTitlelist(Titlel value) {
 titlelist_.Add(value);
 }

public const int lockedFieldNumber = 2;
 private bool hasLocked;
 private Int32 locked_ = 0;
 public bool HasLocked {
 get { return hasLocked; }
 }
 public Int32 Locked {
 get { return locked_; }
 set { SetLocked(value); }
 }
 public void SetLocked(Int32 value) { 
 hasLocked = true;
 locked_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (Titlel element in titlelistList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasLocked) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Locked);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (Titlel element in titlelistList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasLocked) {
output.WriteInt32(2, Locked);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushHighLadderListBack _inst = (GCPushHighLadderListBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Titlel subBuilder =  new Titlel();
input.ReadMessage(subBuilder);
_inst.AddTitlelist(subBuilder);
break;
}
   case  16: {
 _inst.Locked = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Titlel element in titlelistList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUseTitleBack : PacketDistributed
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

public const int titleFieldNumber = 2;
 private bool hasTitle;
 private Titlel title_ =  new Titlel();
 public bool HasTitle {
 get { return hasTitle; }
 }
 public Titlel Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(Titlel value) { 
 hasTitle = true;
 title_ = value;
 }

public const int operateTypeFieldNumber = 3;
 private bool hasOperateType;
 private Int32 operateType_ = 0;
 public bool HasOperateType {
 get { return hasOperateType; }
 }
 public Int32 OperateType {
 get { return operateType_; }
 set { SetOperateType(value); }
 }
 public void SetOperateType(Int32 value) { 
 hasOperateType = true;
 operateType_ = value;
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
int subsize = Title.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasOperateType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, OperateType);
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
output.WriteRawVarint32((uint)Title.SerializedSize());
Title.WriteTo(output);

}
 
if (HasOperateType) {
output.WriteInt32(3, OperateType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUseTitleBack _inst = (GCUseTitleBack) _base;
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
Titlel subBuilder =  new Titlel();
 input.ReadMessage(subBuilder);
_inst.Title = subBuilder;
break;
}
   case  24: {
 _inst.OperateType = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTitle) {
if (!Title.IsInitialized()) return false;
}
 return true;
 }

	}


}
