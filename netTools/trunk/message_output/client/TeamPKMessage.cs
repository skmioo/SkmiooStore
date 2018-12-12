//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGTeamPKHoldFightFlag : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTeamPKHoldFightFlag _inst = (CGTeamPKHoldFightFlag) _base;
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
public class CGTeamPKSend : PacketDistributed
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

public const int rewardIdFieldNumber = 2;
 private bool hasRewardId;
 private Int32 rewardId_ = 0;
 public bool HasRewardId {
 get { return hasRewardId; }
 }
 public Int32 RewardId {
 get { return rewardId_; }
 set { SetRewardId(value); }
 }
 public void SetRewardId(Int32 value) { 
 hasRewardId = true;
 rewardId_ = value;
 }

public const int teamPKTypeFieldNumber = 3;
 private bool hasTeamPKType;
 private Int32 teamPKType_ = 0;
 public bool HasTeamPKType {
 get { return hasTeamPKType; }
 }
 public Int32 TeamPKType {
 get { return teamPKType_; }
 set { SetTeamPKType(value); }
 }
 public void SetTeamPKType(Int32 value) { 
 hasTeamPKType = true;
 teamPKType_ = value;
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
 if (HasRewardId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RewardId);
}
 if (HasTeamPKType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TeamPKType);
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
 
if (HasRewardId) {
output.WriteInt32(2, RewardId);
}
 
if (HasTeamPKType) {
output.WriteInt32(3, TeamPKType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTeamPKSend _inst = (CGTeamPKSend) _base;
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
 _inst.RewardId = input.ReadInt32();
break;
}
   case  24: {
 _inst.TeamPKType = input.ReadInt32();
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
public class GCTeamPKHoldFightFlag : PacketDistributed
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

public const int campFieldNumber = 2;
 private bool hasCamp;
 private Int32 camp_ = 0;
 public bool HasCamp {
 get { return hasCamp; }
 }
 public Int32 Camp {
 get { return camp_; }
 set { SetCamp(value); }
 }
 public void SetCamp(Int32 value) { 
 hasCamp = true;
 camp_ = value;
 }

public const int playerIdFieldNumber = 3;
 private bool hasPlayerId;
 private Int64 playerId_ = 0;
 public bool HasPlayerId {
 get { return hasPlayerId; }
 }
 public Int64 PlayerId {
 get { return playerId_; }
 set { SetPlayerId(value); }
 }
 public void SetPlayerId(Int64 value) { 
 hasPlayerId = true;
 playerId_ = value;
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
 if (HasCamp) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Camp);
}
 if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, PlayerId);
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
 
if (HasCamp) {
output.WriteInt32(2, Camp);
}
 
if (HasPlayerId) {
output.WriteInt64(3, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTeamPKHoldFightFlag _inst = (GCTeamPKHoldFightFlag) _base;
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
 _inst.Camp = input.ReadInt32();
break;
}
   case  24: {
 _inst.PlayerId = input.ReadInt64();
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
public class GCTeamPKPush : PacketDistributed
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

public const int teamPKInfoFieldNumber = 2;
 private pbc::PopsicleList<TeamPKInfo> teamPKInfo_ = new pbc::PopsicleList<TeamPKInfo>();
 public scg::IList<TeamPKInfo> teamPKInfoList {
 get { return pbc::Lists.AsReadOnly(teamPKInfo_); }
 }
 
 public int teamPKInfoCount {
 get { return teamPKInfo_.Count; }
 }
 
public TeamPKInfo GetTeamPKInfo(int index) {
 return teamPKInfo_[index];
 }
 public void AddTeamPKInfo(TeamPKInfo value) {
 teamPKInfo_.Add(value);
 }

public const int lastReadyTimeFieldNumber = 3;
 private bool hasLastReadyTime;
 private Int32 lastReadyTime_ = 0;
 public bool HasLastReadyTime {
 get { return hasLastReadyTime; }
 }
 public Int32 LastReadyTime {
 get { return lastReadyTime_; }
 set { SetLastReadyTime(value); }
 }
 public void SetLastReadyTime(Int32 value) { 
 hasLastReadyTime = true;
 lastReadyTime_ = value;
 }

public const int diePuidFieldNumber = 4;
 private bool hasDiePuid;
 private Int64 diePuid_ = 0;
 public bool HasDiePuid {
 get { return hasDiePuid; }
 }
 public Int64 DiePuid {
 get { return diePuid_; }
 set { SetDiePuid(value); }
 }
 public void SetDiePuid(Int64 value) { 
 hasDiePuid = true;
 diePuid_ = value;
 }

public const int killPuidFieldNumber = 5;
 private bool hasKillPuid;
 private Int64 killPuid_ = 0;
 public bool HasKillPuid {
 get { return hasKillPuid; }
 }
 public Int64 KillPuid {
 get { return killPuid_; }
 set { SetKillPuid(value); }
 }
 public void SetKillPuid(Int64 value) { 
 hasKillPuid = true;
 killPuid_ = value;
 }

public const int dieNameFieldNumber = 6;
 private bool hasDieName;
 private string dieName_ = "";
 public bool HasDieName {
 get { return hasDieName; }
 }
 public string DieName {
 get { return dieName_; }
 set { SetDieName(value); }
 }
 public void SetDieName(string value) { 
 hasDieName = true;
 dieName_ = value;
 }

public const int killNameFieldNumber = 7;
 private bool hasKillName;
 private string killName_ = "";
 public bool HasKillName {
 get { return hasKillName; }
 }
 public string KillName {
 get { return killName_; }
 set { SetKillName(value); }
 }
 public void SetKillName(string value) { 
 hasKillName = true;
 killName_ = value;
 }

public const int flagFieldNumber = 8;
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

public const int resultFieldNumber = 9;
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

public const int camp1FieldNumber = 10;
 private bool hasCamp1;
 private MapLongAry camp1_ =  new MapLongAry();
 public bool HasCamp1 {
 get { return hasCamp1; }
 }
 public MapLongAry Camp1 {
 get { return camp1_; }
 set { SetCamp1(value); }
 }
 public void SetCamp1(MapLongAry value) { 
 hasCamp1 = true;
 camp1_ = value;
 }

public const int camp2FieldNumber = 11;
 private bool hasCamp2;
 private MapLongAry camp2_ =  new MapLongAry();
 public bool HasCamp2 {
 get { return hasCamp2; }
 }
 public MapLongAry Camp2 {
 get { return camp2_; }
 set { SetCamp2(value); }
 }
 public void SetCamp2(MapLongAry value) { 
 hasCamp2 = true;
 camp2_ = value;
 }

public const int scoreBattle1FieldNumber = 12;
 private bool hasScoreBattle1;
 private Int32 scoreBattle1_ = 0;
 public bool HasScoreBattle1 {
 get { return hasScoreBattle1; }
 }
 public Int32 ScoreBattle1 {
 get { return scoreBattle1_; }
 set { SetScoreBattle1(value); }
 }
 public void SetScoreBattle1(Int32 value) { 
 hasScoreBattle1 = true;
 scoreBattle1_ = value;
 }

public const int scoreBattle2FieldNumber = 13;
 private bool hasScoreBattle2;
 private Int32 scoreBattle2_ = 0;
 public bool HasScoreBattle2 {
 get { return hasScoreBattle2; }
 }
 public Int32 ScoreBattle2 {
 get { return scoreBattle2_; }
 set { SetScoreBattle2(value); }
 }
 public void SetScoreBattle2(Int32 value) { 
 hasScoreBattle2 = true;
 scoreBattle2_ = value;
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
foreach (TeamPKInfo element in teamPKInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasLastReadyTime) {
size += pb::CodedOutputStream.ComputeInt32Size(3, LastReadyTime);
}
 if (HasDiePuid) {
size += pb::CodedOutputStream.ComputeInt64Size(4, DiePuid);
}
 if (HasKillPuid) {
size += pb::CodedOutputStream.ComputeInt64Size(5, KillPuid);
}
 if (HasDieName) {
size += pb::CodedOutputStream.ComputeStringSize(6, DieName);
}
 if (HasKillName) {
size += pb::CodedOutputStream.ComputeStringSize(7, KillName);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Flag);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Result);
}
{
int subsize = Camp1.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)10) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Camp2.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)11) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasScoreBattle1) {
size += pb::CodedOutputStream.ComputeInt32Size(12, ScoreBattle1);
}
 if (HasScoreBattle2) {
size += pb::CodedOutputStream.ComputeInt32Size(13, ScoreBattle2);
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
foreach (TeamPKInfo element in teamPKInfoList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasLastReadyTime) {
output.WriteInt32(3, LastReadyTime);
}
 
if (HasDiePuid) {
output.WriteInt64(4, DiePuid);
}
 
if (HasKillPuid) {
output.WriteInt64(5, KillPuid);
}
 
if (HasDieName) {
output.WriteString(6, DieName);
}
 
if (HasKillName) {
output.WriteString(7, KillName);
}
 
if (HasFlag) {
output.WriteInt32(8, Flag);
}
 
if (HasResult) {
output.WriteInt32(9, Result);
}
{
output.WriteTag((int)10, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Camp1.SerializedSize());
Camp1.WriteTo(output);

}
{
output.WriteTag((int)11, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Camp2.SerializedSize());
Camp2.WriteTo(output);

}
 
if (HasScoreBattle1) {
output.WriteInt32(12, ScoreBattle1);
}
 
if (HasScoreBattle2) {
output.WriteInt32(13, ScoreBattle2);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTeamPKPush _inst = (GCTeamPKPush) _base;
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
TeamPKInfo subBuilder =  new TeamPKInfo();
input.ReadMessage(subBuilder);
_inst.AddTeamPKInfo(subBuilder);
break;
}
   case  24: {
 _inst.LastReadyTime = input.ReadInt32();
break;
}
   case  32: {
 _inst.DiePuid = input.ReadInt64();
break;
}
   case  40: {
 _inst.KillPuid = input.ReadInt64();
break;
}
   case  50: {
 _inst.DieName = input.ReadString();
break;
}
   case  58: {
 _inst.KillName = input.ReadString();
break;
}
   case  64: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  72: {
 _inst.Result = input.ReadInt32();
break;
}
    case  82: {
MapLongAry subBuilder =  new MapLongAry();
 input.ReadMessage(subBuilder);
_inst.Camp1 = subBuilder;
break;
}
    case  90: {
MapLongAry subBuilder =  new MapLongAry();
 input.ReadMessage(subBuilder);
_inst.Camp2 = subBuilder;
break;
}
   case  96: {
 _inst.ScoreBattle1 = input.ReadInt32();
break;
}
   case  104: {
 _inst.ScoreBattle2 = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TeamPKInfo element in teamPKInfoList) {
if (!element.IsInitialized()) return false;
}
  if (HasCamp1) {
if (!Camp1.IsInitialized()) return false;
}
  if (HasCamp2) {
if (!Camp2.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TeamPKInfo : PacketDistributed
{

public const int teamPKTypeFieldNumber = 1;
 private bool hasTeamPKType;
 private Int32 teamPKType_ = 0;
 public bool HasTeamPKType {
 get { return hasTeamPKType; }
 }
 public Int32 TeamPKType {
 get { return teamPKType_; }
 set { SetTeamPKType(value); }
 }
 public void SetTeamPKType(Int32 value) { 
 hasTeamPKType = true;
 teamPKType_ = value;
 }

public const int teamPKCountFieldNumber = 2;
 private bool hasTeamPKCount;
 private Int32 teamPKCount_ = 0;
 public bool HasTeamPKCount {
 get { return hasTeamPKCount; }
 }
 public Int32 TeamPKCount {
 get { return teamPKCount_; }
 set { SetTeamPKCount(value); }
 }
 public void SetTeamPKCount(Int32 value) { 
 hasTeamPKCount = true;
 teamPKCount_ = value;
 }

public const int teamPKWinCountFieldNumber = 3;
 private bool hasTeamPKWinCount;
 private Int32 teamPKWinCount_ = 0;
 public bool HasTeamPKWinCount {
 get { return hasTeamPKWinCount; }
 }
 public Int32 TeamPKWinCount {
 get { return teamPKWinCount_; }
 set { SetTeamPKWinCount(value); }
 }
 public void SetTeamPKWinCount(Int32 value) { 
 hasTeamPKWinCount = true;
 teamPKWinCount_ = value;
 }

public const int teamPKSuccessionCountFieldNumber = 4;
 private bool hasTeamPKSuccessionCount;
 private Int32 teamPKSuccessionCount_ = 0;
 public bool HasTeamPKSuccessionCount {
 get { return hasTeamPKSuccessionCount; }
 }
 public Int32 TeamPKSuccessionCount {
 get { return teamPKSuccessionCount_; }
 set { SetTeamPKSuccessionCount(value); }
 }
 public void SetTeamPKSuccessionCount(Int32 value) { 
 hasTeamPKSuccessionCount = true;
 teamPKSuccessionCount_ = value;
 }

public const int teamPKRewardStateFieldNumber = 5;
 private bool hasTeamPKRewardState;
 private Int32 teamPKRewardState_ = 0;
 public bool HasTeamPKRewardState {
 get { return hasTeamPKRewardState; }
 }
 public Int32 TeamPKRewardState {
 get { return teamPKRewardState_; }
 set { SetTeamPKRewardState(value); }
 }
 public void SetTeamPKRewardState(Int32 value) { 
 hasTeamPKRewardState = true;
 teamPKRewardState_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTeamPKType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TeamPKType);
}
 if (HasTeamPKCount) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TeamPKCount);
}
 if (HasTeamPKWinCount) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TeamPKWinCount);
}
 if (HasTeamPKSuccessionCount) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TeamPKSuccessionCount);
}
 if (HasTeamPKRewardState) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TeamPKRewardState);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTeamPKType) {
output.WriteInt32(1, TeamPKType);
}
 
if (HasTeamPKCount) {
output.WriteInt32(2, TeamPKCount);
}
 
if (HasTeamPKWinCount) {
output.WriteInt32(3, TeamPKWinCount);
}
 
if (HasTeamPKSuccessionCount) {
output.WriteInt32(4, TeamPKSuccessionCount);
}
 
if (HasTeamPKRewardState) {
output.WriteInt32(5, TeamPKRewardState);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TeamPKInfo _inst = (TeamPKInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TeamPKType = input.ReadInt32();
break;
}
   case  16: {
 _inst.TeamPKCount = input.ReadInt32();
break;
}
   case  24: {
 _inst.TeamPKWinCount = input.ReadInt32();
break;
}
   case  32: {
 _inst.TeamPKSuccessionCount = input.ReadInt32();
break;
}
   case  40: {
 _inst.TeamPKRewardState = input.ReadInt32();
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
