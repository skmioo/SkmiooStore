//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGEscortOperate : PacketDistributed
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

public const int dartTypeFieldNumber = 2;
 private bool hasDartType;
 private Int32 dartType_ = 0;
 public bool HasDartType {
 get { return hasDartType; }
 }
 public Int32 DartType {
 get { return dartType_; }
 set { SetDartType(value); }
 }
 public void SetDartType(Int32 value) { 
 hasDartType = true;
 dartType_ = value;
 }

public const int dartIDFieldNumber = 3;
 private bool hasDartID;
 private Int32 dartID_ = 0;
 public bool HasDartID {
 get { return hasDartID; }
 }
 public Int32 DartID {
 get { return dartID_; }
 set { SetDartID(value); }
 }
 public void SetDartID(Int32 value) { 
 hasDartID = true;
 dartID_ = value;
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
 if (HasDartType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, DartType);
}
 if (HasDartID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, DartID);
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
 
if (HasDartType) {
output.WriteInt32(2, DartType);
}
 
if (HasDartID) {
output.WriteInt32(3, DartID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEscortOperate _inst = (CGEscortOperate) _base;
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
 _inst.DartType = input.ReadInt32();
break;
}
   case  24: {
 _inst.DartID = input.ReadInt32();
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
public class CGFollowDart : PacketDistributed
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
 CGFollowDart _inst = (CGFollowDart) _base;
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
public class GCEscortOperateResult : PacketDistributed
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

public const int escortCntFieldNumber = 2;
 private bool hasEscortCnt;
 private Int32 escortCnt_ = 0;
 public bool HasEscortCnt {
 get { return hasEscortCnt; }
 }
 public Int32 EscortCnt {
 get { return escortCnt_; }
 set { SetEscortCnt(value); }
 }
 public void SetEscortCnt(Int32 value) { 
 hasEscortCnt = true;
 escortCnt_ = value;
 }

public const int robCntFieldNumber = 3;
 private bool hasRobCnt;
 private Int32 robCnt_ = 0;
 public bool HasRobCnt {
 get { return hasRobCnt; }
 }
 public Int32 RobCnt {
 get { return robCnt_; }
 set { SetRobCnt(value); }
 }
 public void SetRobCnt(Int32 value) { 
 hasRobCnt = true;
 robCnt_ = value;
 }

public const int dartIDFieldNumber = 4;
 private bool hasDartID;
 private Int32 dartID_ = 0;
 public bool HasDartID {
 get { return hasDartID; }
 }
 public Int32 DartID {
 get { return dartID_; }
 set { SetDartID(value); }
 }
 public void SetDartID(Int32 value) { 
 hasDartID = true;
 dartID_ = value;
 }

public const int rewardFieldNumber = 5;
 private bool hasReward;
 private string reward_ = "";
 public bool HasReward {
 get { return hasReward; }
 }
 public string Reward {
 get { return reward_; }
 set { SetReward(value); }
 }
 public void SetReward(string value) { 
 hasReward = true;
 reward_ = value;
 }

public const int playerNameFieldNumber = 6;
 private bool hasPlayerName;
 private string playerName_ = "";
 public bool HasPlayerName {
 get { return hasPlayerName; }
 }
 public string PlayerName {
 get { return playerName_; }
 set { SetPlayerName(value); }
 }
 public void SetPlayerName(string value) { 
 hasPlayerName = true;
 playerName_ = value;
 }

public const int dartPidFieldNumber = 7;
 private bool hasDartPid;
 private Int64 dartPid_ = 0;
 public bool HasDartPid {
 get { return hasDartPid; }
 }
 public Int64 DartPid {
 get { return dartPid_; }
 set { SetDartPid(value); }
 }
 public void SetDartPid(Int64 value) { 
 hasDartPid = true;
 dartPid_ = value;
 }

public const int endTimeFieldNumber = 8;
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

public const int failTimeFieldNumber = 9;
 private bool hasFailTime;
 private Int64 failTime_ = 0;
 public bool HasFailTime {
 get { return hasFailTime; }
 }
 public Int64 FailTime {
 get { return failTime_; }
 set { SetFailTime(value); }
 }
 public void SetFailTime(Int64 value) { 
 hasFailTime = true;
 failTime_ = value;
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
 if (HasEscortCnt) {
size += pb::CodedOutputStream.ComputeInt32Size(2, EscortCnt);
}
 if (HasRobCnt) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RobCnt);
}
 if (HasDartID) {
size += pb::CodedOutputStream.ComputeInt32Size(4, DartID);
}
 if (HasReward) {
size += pb::CodedOutputStream.ComputeStringSize(5, Reward);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(6, PlayerName);
}
 if (HasDartPid) {
size += pb::CodedOutputStream.ComputeInt64Size(7, DartPid);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(8, EndTime);
}
 if (HasFailTime) {
size += pb::CodedOutputStream.ComputeInt64Size(9, FailTime);
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
 
if (HasEscortCnt) {
output.WriteInt32(2, EscortCnt);
}
 
if (HasRobCnt) {
output.WriteInt32(3, RobCnt);
}
 
if (HasDartID) {
output.WriteInt32(4, DartID);
}
 
if (HasReward) {
output.WriteString(5, Reward);
}
 
if (HasPlayerName) {
output.WriteString(6, PlayerName);
}
 
if (HasDartPid) {
output.WriteInt64(7, DartPid);
}
 
if (HasEndTime) {
output.WriteInt64(8, EndTime);
}
 
if (HasFailTime) {
output.WriteInt64(9, FailTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEscortOperateResult _inst = (GCEscortOperateResult) _base;
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
 _inst.EscortCnt = input.ReadInt32();
break;
}
   case  24: {
 _inst.RobCnt = input.ReadInt32();
break;
}
   case  32: {
 _inst.DartID = input.ReadInt32();
break;
}
   case  42: {
 _inst.Reward = input.ReadString();
break;
}
   case  50: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  56: {
 _inst.DartPid = input.ReadInt64();
break;
}
   case  64: {
 _inst.EndTime = input.ReadInt64();
break;
}
   case  72: {
 _inst.FailTime = input.ReadInt64();
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
public class GCFollowDartResult : PacketDistributed
{

public const int sceneIDFieldNumber = 1;
 private bool hasSceneID;
 private Int32 sceneID_ = 0;
 public bool HasSceneID {
 get { return hasSceneID; }
 }
 public Int32 SceneID {
 get { return sceneID_; }
 set { SetSceneID(value); }
 }
 public void SetSceneID(Int32 value) { 
 hasSceneID = true;
 sceneID_ = value;
 }

public const int posXFieldNumber = 2;
 private bool hasPosX;
 private Int32 posX_ = 0;
 public bool HasPosX {
 get { return hasPosX; }
 }
 public Int32 PosX {
 get { return posX_; }
 set { SetPosX(value); }
 }
 public void SetPosX(Int32 value) { 
 hasPosX = true;
 posX_ = value;
 }

public const int posZFieldNumber = 3;
 private bool hasPosZ;
 private Int32 posZ_ = 0;
 public bool HasPosZ {
 get { return hasPosZ; }
 }
 public Int32 PosZ {
 get { return posZ_; }
 set { SetPosZ(value); }
 }
 public void SetPosZ(Int32 value) { 
 hasPosZ = true;
 posZ_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSceneID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneID);
}
 if (HasPosX) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PosX);
}
 if (HasPosZ) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PosZ);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneID) {
output.WriteInt32(1, SceneID);
}
 
if (HasPosX) {
output.WriteInt32(2, PosX);
}
 
if (HasPosZ) {
output.WriteInt32(3, PosZ);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFollowDartResult _inst = (GCFollowDartResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneID = input.ReadInt32();
break;
}
   case  16: {
 _inst.PosX = input.ReadInt32();
break;
}
   case  24: {
 _inst.PosZ = input.ReadInt32();
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
