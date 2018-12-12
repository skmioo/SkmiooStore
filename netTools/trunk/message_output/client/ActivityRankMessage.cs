//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class ActivityRankInfo : PacketDistributed
{

public const int playerIDFieldNumber = 1;
 private bool hasPlayerID;
 private Int64 playerID_ = 0;
 public bool HasPlayerID {
 get { return hasPlayerID; }
 }
 public Int64 PlayerID {
 get { return playerID_; }
 set { SetPlayerID(value); }
 }
 public void SetPlayerID(Int64 value) { 
 hasPlayerID = true;
 playerID_ = value;
 }

public const int playerNameFieldNumber = 2;
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

public const int pointsFieldNumber = 4;
 private bool hasPoints;
 private Int32 points_ = 0;
 public bool HasPoints {
 get { return hasPoints; }
 }
 public Int32 Points {
 get { return points_; }
 set { SetPoints(value); }
 }
 public void SetPoints(Int32 value) { 
 hasPoints = true;
 points_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PlayerName);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Rank);
}
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Points);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerID) {
output.WriteInt64(1, PlayerID);
}
 
if (HasPlayerName) {
output.WriteString(2, PlayerName);
}
 
if (HasRank) {
output.WriteInt32(3, Rank);
}
 
if (HasPoints) {
output.WriteInt32(4, Points);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ActivityRankInfo _inst = (ActivityRankInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  18: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  24: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  32: {
 _inst.Points = input.ReadInt32();
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
public class ActivityRankReward : PacketDistributed
{

public const int rankFieldNumber = 1;
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

public const int pointsFieldNumber = 2;
 private bool hasPoints;
 private Int32 points_ = 0;
 public bool HasPoints {
 get { return hasPoints; }
 }
 public Int32 Points {
 get { return points_; }
 set { SetPoints(value); }
 }
 public void SetPoints(Int32 value) { 
 hasPoints = true;
 points_ = value;
 }

public const int rewardFieldNumber = 3;
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

public const int pointRewardFieldNumber = 4;
 private bool hasPointReward;
 private string pointReward_ = "";
 public bool HasPointReward {
 get { return hasPointReward; }
 }
 public string PointReward {
 get { return pointReward_; }
 set { SetPointReward(value); }
 }
 public void SetPointReward(string value) { 
 hasPointReward = true;
 pointReward_ = value;
 }

public const int showRewardFieldNumber = 5;
 private bool hasShowReward;
 private string showReward_ = "";
 public bool HasShowReward {
 get { return hasShowReward; }
 }
 public string ShowReward {
 get { return showReward_; }
 set { SetShowReward(value); }
 }
 public void SetShowReward(string value) { 
 hasShowReward = true;
 showReward_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Rank);
}
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Points);
}
 if (HasReward) {
size += pb::CodedOutputStream.ComputeStringSize(3, Reward);
}
 if (HasPointReward) {
size += pb::CodedOutputStream.ComputeStringSize(4, PointReward);
}
 if (HasShowReward) {
size += pb::CodedOutputStream.ComputeStringSize(5, ShowReward);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRank) {
output.WriteInt32(1, Rank);
}
 
if (HasPoints) {
output.WriteInt32(2, Points);
}
 
if (HasReward) {
output.WriteString(3, Reward);
}
 
if (HasPointReward) {
output.WriteString(4, PointReward);
}
 
if (HasShowReward) {
output.WriteString(5, ShowReward);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ActivityRankReward _inst = (ActivityRankReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  16: {
 _inst.Points = input.ReadInt32();
break;
}
   case  26: {
 _inst.Reward = input.ReadString();
break;
}
   case  34: {
 _inst.PointReward = input.ReadString();
break;
}
   case  42: {
 _inst.ShowReward = input.ReadString();
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
public class CGActivityRank : PacketDistributed
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

public const int typeFieldNumber = 2;
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
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGActivityRank _inst = (CGActivityRank) _base;
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
public class GCActivityRankResult : PacketDistributed
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

public const int chargeRanksFieldNumber = 2;
 private pbc::PopsicleList<ActivityRankInfo> chargeRanks_ = new pbc::PopsicleList<ActivityRankInfo>();
 public scg::IList<ActivityRankInfo> chargeRanksList {
 get { return pbc::Lists.AsReadOnly(chargeRanks_); }
 }
 
 public int chargeRanksCount {
 get { return chargeRanks_.Count; }
 }
 
public ActivityRankInfo GetChargeRanks(int index) {
 return chargeRanks_[index];
 }
 public void AddChargeRanks(ActivityRankInfo value) {
 chargeRanks_.Add(value);
 }

public const int spendRanksFieldNumber = 3;
 private pbc::PopsicleList<ActivityRankInfo> spendRanks_ = new pbc::PopsicleList<ActivityRankInfo>();
 public scg::IList<ActivityRankInfo> spendRanksList {
 get { return pbc::Lists.AsReadOnly(spendRanks_); }
 }
 
 public int spendRanksCount {
 get { return spendRanks_.Count; }
 }
 
public ActivityRankInfo GetSpendRanks(int index) {
 return spendRanks_[index];
 }
 public void AddSpendRanks(ActivityRankInfo value) {
 spendRanks_.Add(value);
 }

public const int playerChargeFieldNumber = 4;
 private bool hasPlayerCharge;
 private ActivityRankInfo playerCharge_ =  new ActivityRankInfo();
 public bool HasPlayerCharge {
 get { return hasPlayerCharge; }
 }
 public ActivityRankInfo PlayerCharge {
 get { return playerCharge_; }
 set { SetPlayerCharge(value); }
 }
 public void SetPlayerCharge(ActivityRankInfo value) { 
 hasPlayerCharge = true;
 playerCharge_ = value;
 }

public const int playerSpendFieldNumber = 5;
 private bool hasPlayerSpend;
 private ActivityRankInfo playerSpend_ =  new ActivityRankInfo();
 public bool HasPlayerSpend {
 get { return hasPlayerSpend; }
 }
 public ActivityRankInfo PlayerSpend {
 get { return playerSpend_; }
 set { SetPlayerSpend(value); }
 }
 public void SetPlayerSpend(ActivityRankInfo value) { 
 hasPlayerSpend = true;
 playerSpend_ = value;
 }

public const int chargeRewardsFieldNumber = 6;
 private pbc::PopsicleList<ActivityRankReward> chargeRewards_ = new pbc::PopsicleList<ActivityRankReward>();
 public scg::IList<ActivityRankReward> chargeRewardsList {
 get { return pbc::Lists.AsReadOnly(chargeRewards_); }
 }
 
 public int chargeRewardsCount {
 get { return chargeRewards_.Count; }
 }
 
public ActivityRankReward GetChargeRewards(int index) {
 return chargeRewards_[index];
 }
 public void AddChargeRewards(ActivityRankReward value) {
 chargeRewards_.Add(value);
 }

public const int spendRewardsFieldNumber = 7;
 private pbc::PopsicleList<ActivityRankReward> spendRewards_ = new pbc::PopsicleList<ActivityRankReward>();
 public scg::IList<ActivityRankReward> spendRewardsList {
 get { return pbc::Lists.AsReadOnly(spendRewards_); }
 }
 
 public int spendRewardsCount {
 get { return spendRewards_.Count; }
 }
 
public ActivityRankReward GetSpendRewards(int index) {
 return spendRewards_[index];
 }
 public void AddSpendRewards(ActivityRankReward value) {
 spendRewards_.Add(value);
 }

public const int typeFieldNumber = 8;
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
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
{
foreach (ActivityRankInfo element in chargeRanksList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankInfo element in spendRanksList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = PlayerCharge.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = PlayerSpend.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (ActivityRankReward element in chargeRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankReward element in spendRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Type);
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
foreach (ActivityRankInfo element in chargeRanksList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankInfo element in spendRanksList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PlayerCharge.SerializedSize());
PlayerCharge.WriteTo(output);

}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PlayerSpend.SerializedSize());
PlayerSpend.WriteTo(output);

}

do{
foreach (ActivityRankReward element in chargeRewardsList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankReward element in spendRewardsList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasType) {
output.WriteInt32(8, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCActivityRankResult _inst = (GCActivityRankResult) _base;
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
ActivityRankInfo subBuilder =  new ActivityRankInfo();
input.ReadMessage(subBuilder);
_inst.AddChargeRanks(subBuilder);
break;
}
    case  26: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
input.ReadMessage(subBuilder);
_inst.AddSpendRanks(subBuilder);
break;
}
    case  34: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
 input.ReadMessage(subBuilder);
_inst.PlayerCharge = subBuilder;
break;
}
    case  42: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
 input.ReadMessage(subBuilder);
_inst.PlayerSpend = subBuilder;
break;
}
    case  50: {
ActivityRankReward subBuilder =  new ActivityRankReward();
input.ReadMessage(subBuilder);
_inst.AddChargeRewards(subBuilder);
break;
}
    case  58: {
ActivityRankReward subBuilder =  new ActivityRankReward();
input.ReadMessage(subBuilder);
_inst.AddSpendRewards(subBuilder);
break;
}
   case  64: {
 _inst.Type = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ActivityRankInfo element in chargeRanksList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankInfo element in spendRanksList) {
if (!element.IsInitialized()) return false;
}
  if (HasPlayerCharge) {
if (!PlayerCharge.IsInitialized()) return false;
}
  if (HasPlayerSpend) {
if (!PlayerSpend.IsInitialized()) return false;
}
foreach (ActivityRankReward element in chargeRewardsList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankReward element in spendRewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
