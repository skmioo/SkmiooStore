//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGIntegralOperate : PacketDistributed
{

public const int playerIdFieldNumber = 1;
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
  if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerId) {
output.WriteInt64(1, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGIntegralOperate _inst = (CGIntegralOperate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class CurcyIntegralItemInfo : PacketDistributed
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

public const int sidFieldNumber = 2;
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

public const int numFieldNumber = 3;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
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
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CurcyIntegralItemInfo _inst = (CurcyIntegralItemInfo) _base;
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
 _inst.Sid = input.ReadInt32();
break;
}
   case  24: {
 _inst.Num = input.ReadInt32();
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
public class GCIntegralResult : PacketDistributed
{

public const int rankInfosFieldNumber = 1;
 private pbc::PopsicleList<IntegralRankInfo> rankInfos_ = new pbc::PopsicleList<IntegralRankInfo>();
 public scg::IList<IntegralRankInfo> rankInfosList {
 get { return pbc::Lists.AsReadOnly(rankInfos_); }
 }
 
 public int rankInfosCount {
 get { return rankInfos_.Count; }
 }
 
public IntegralRankInfo GetRankInfos(int index) {
 return rankInfos_[index];
 }
 public void AddRankInfos(IntegralRankInfo value) {
 rankInfos_.Add(value);
 }

public const int rewardInfosFieldNumber = 2;
 private pbc::PopsicleList<IntegralRewardInfo> rewardInfos_ = new pbc::PopsicleList<IntegralRewardInfo>();
 public scg::IList<IntegralRewardInfo> rewardInfosList {
 get { return pbc::Lists.AsReadOnly(rewardInfos_); }
 }
 
 public int rewardInfosCount {
 get { return rewardInfos_.Count; }
 }
 
public IntegralRewardInfo GetRewardInfos(int index) {
 return rewardInfos_[index];
 }
 public void AddRewardInfos(IntegralRewardInfo value) {
 rewardInfos_.Add(value);
 }

public const int rankFieldNumber = 3;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int rankRewardFieldNumber = 4;
 private bool hasRankReward;
 private Int32 rankReward_ = 0;
 public bool HasRankReward {
 get { return hasRankReward; }
 }
 public Int32 RankReward {
 get { return rankReward_; }
 set { SetRankReward(value); }
 }
 public void SetRankReward(Int32 value) { 
 hasRankReward = true;
 rankReward_ = value;
 }

public const int integralFieldNumber = 5;
 private bool hasIntegral;
 private Int32 integral_ = 0;
 public bool HasIntegral {
 get { return hasIntegral; }
 }
 public Int32 Integral {
 get { return integral_; }
 set { SetIntegral(value); }
 }
 public void SetIntegral(Int32 value) { 
 hasIntegral = true;
 integral_ = value;
 }

public const int integralSpaceFieldNumber = 6;
 private bool hasIntegralSpace;
 private Int32 integralSpace_ = 0;
 public bool HasIntegralSpace {
 get { return hasIntegralSpace; }
 }
 public Int32 IntegralSpace {
 get { return integralSpace_; }
 set { SetIntegralSpace(value); }
 }
 public void SetIntegralSpace(Int32 value) { 
 hasIntegralSpace = true;
 integralSpace_ = value;
 }

public const int uiIdFieldNumber = 7;
 private bool hasUiId;
 private string uiId_ = "";
 public bool HasUiId {
 get { return hasUiId; }
 }
 public string UiId {
 get { return uiId_; }
 set { SetUiId(value); }
 }
 public void SetUiId(string value) { 
 hasUiId = true;
 uiId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (IntegralRankInfo element in rankInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (IntegralRewardInfo element in rewardInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Rank);
}
 if (HasRankReward) {
size += pb::CodedOutputStream.ComputeInt32Size(4, RankReward);
}
 if (HasIntegral) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Integral);
}
 if (HasIntegralSpace) {
size += pb::CodedOutputStream.ComputeInt32Size(6, IntegralSpace);
}
 if (HasUiId) {
size += pb::CodedOutputStream.ComputeStringSize(7, UiId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (IntegralRankInfo element in rankInfosList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (IntegralRewardInfo element in rewardInfosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasRank) {
output.WriteInt32(3, Rank);
}
 
if (HasRankReward) {
output.WriteInt32(4, RankReward);
}
 
if (HasIntegral) {
output.WriteInt32(5, Integral);
}
 
if (HasIntegralSpace) {
output.WriteInt32(6, IntegralSpace);
}
 
if (HasUiId) {
output.WriteString(7, UiId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCIntegralResult _inst = (GCIntegralResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
IntegralRankInfo subBuilder =  new IntegralRankInfo();
input.ReadMessage(subBuilder);
_inst.AddRankInfos(subBuilder);
break;
}
    case  18: {
IntegralRewardInfo subBuilder =  new IntegralRewardInfo();
input.ReadMessage(subBuilder);
_inst.AddRewardInfos(subBuilder);
break;
}
   case  24: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  32: {
 _inst.RankReward = input.ReadInt32();
break;
}
   case  40: {
 _inst.Integral = input.ReadInt32();
break;
}
   case  48: {
 _inst.IntegralSpace = input.ReadInt32();
break;
}
   case  58: {
 _inst.UiId = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (IntegralRankInfo element in rankInfosList) {
if (!element.IsInitialized()) return false;
}
foreach (IntegralRewardInfo element in rewardInfosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class IntegralRankInfo : PacketDistributed
{

public const int playerIdFieldNumber = 1;
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

public const int rankFieldNumber = 2;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int nameFieldNumber = 3;
 private bool hasName;
 private string name_ = "";
 public bool HasName {
 get { return hasName; }
 }
 public string Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(string value) { 
 hasName = true;
 name_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerId);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Rank);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(3, Name);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerId) {
output.WriteInt64(1, PlayerId);
}
 
if (HasRank) {
output.WriteInt32(2, Rank);
}
 
if (HasName) {
output.WriteString(3, Name);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 IntegralRankInfo _inst = (IntegralRankInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  26: {
 _inst.Name = input.ReadString();
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
public class IntegralRewardInfo : PacketDistributed
{

public const int stageFieldNumber = 1;
 private bool hasStage;
 private Int32 stage_ = 0;
 public bool HasStage {
 get { return hasStage; }
 }
 public Int32 Stage {
 get { return stage_; }
 set { SetStage(value); }
 }
 public void SetStage(Int32 value) { 
 hasStage = true;
 stage_ = value;
 }

public const int integralFieldNumber = 2;
 private bool hasIntegral;
 private Int32 integral_ = 0;
 public bool HasIntegral {
 get { return hasIntegral; }
 }
 public Int32 Integral {
 get { return integral_; }
 set { SetIntegral(value); }
 }
 public void SetIntegral(Int32 value) { 
 hasIntegral = true;
 integral_ = value;
 }

public const int rewardFieldNumber = 3;
 private pbc::PopsicleList<CurcyIntegralItemInfo> reward_ = new pbc::PopsicleList<CurcyIntegralItemInfo>();
 public scg::IList<CurcyIntegralItemInfo> rewardList {
 get { return pbc::Lists.AsReadOnly(reward_); }
 }
 
 public int rewardCount {
 get { return reward_.Count; }
 }
 
public CurcyIntegralItemInfo GetReward(int index) {
 return reward_[index];
 }
 public void AddReward(CurcyIntegralItemInfo value) {
 reward_.Add(value);
 }

public const int iconFieldNumber = 4;
 private bool hasIcon;
 private string icon_ = "";
 public bool HasIcon {
 get { return hasIcon; }
 }
 public string Icon {
 get { return icon_; }
 set { SetIcon(value); }
 }
 public void SetIcon(string value) { 
 hasIcon = true;
 icon_ = value;
 }

public const int playerNameFieldNumber = 5;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasStage) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Stage);
}
 if (HasIntegral) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Integral);
}
{
foreach (CurcyIntegralItemInfo element in rewardList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasIcon) {
size += pb::CodedOutputStream.ComputeStringSize(4, Icon);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(5, PlayerName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasStage) {
output.WriteInt32(1, Stage);
}
 
if (HasIntegral) {
output.WriteInt32(2, Integral);
}

do{
foreach (CurcyIntegralItemInfo element in rewardList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasIcon) {
output.WriteString(4, Icon);
}
 
if (HasPlayerName) {
output.WriteString(5, PlayerName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 IntegralRewardInfo _inst = (IntegralRewardInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Stage = input.ReadInt32();
break;
}
   case  16: {
 _inst.Integral = input.ReadInt32();
break;
}
    case  26: {
CurcyIntegralItemInfo subBuilder =  new CurcyIntegralItemInfo();
input.ReadMessage(subBuilder);
_inst.AddReward(subBuilder);
break;
}
   case  34: {
 _inst.Icon = input.ReadString();
break;
}
   case  42: {
 _inst.PlayerName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CurcyIntegralItemInfo element in rewardList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
