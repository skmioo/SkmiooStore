//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGEnterSnowInstance : PacketDistributed
{

public const int snowManGuidFieldNumber = 1;
 private bool hasSnowManGuid;
 private Int64 snowManGuid_ = 0;
 public bool HasSnowManGuid {
 get { return hasSnowManGuid; }
 }
 public Int64 SnowManGuid {
 get { return snowManGuid_; }
 set { SetSnowManGuid(value); }
 }
 public void SetSnowManGuid(Int64 value) { 
 hasSnowManGuid = true;
 snowManGuid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSnowManGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SnowManGuid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSnowManGuid) {
output.WriteInt64(1, SnowManGuid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEnterSnowInstance _inst = (CGEnterSnowInstance) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SnowManGuid = input.ReadInt64();
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
public class CGOperSnowBoss : PacketDistributed
{

public const int operFieldNumber = 1;
 private bool hasOper;
 private Int32 oper_ = 0;
 public bool HasOper {
 get { return hasOper; }
 }
 public Int32 Oper {
 get { return oper_; }
 set { SetOper(value); }
 }
 public void SetOper(Int32 value) { 
 hasOper = true;
 oper_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOper) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Oper);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOper) {
output.WriteInt32(1, Oper);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGOperSnowBoss _inst = (CGOperSnowBoss) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Oper = input.ReadInt32();
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
public class CGRefreshSnowActivityData : PacketDistributed
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
 CGRefreshSnowActivityData _inst = (CGRefreshSnowActivityData) _base;
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
public class FightRankInfo : PacketDistributed
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

public const int damageFieldNumber = 3;
 private bool hasDamage;
 private Int32 damage_ = 0;
 public bool HasDamage {
 get { return hasDamage; }
 }
 public Int32 Damage {
 get { return damage_; }
 set { SetDamage(value); }
 }
 public void SetDamage(Int32 value) { 
 hasDamage = true;
 damage_ = value;
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
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PlayerName);
}
 if (HasDamage) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Damage);
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
 
if (HasPlayerName) {
output.WriteString(2, PlayerName);
}
 
if (HasDamage) {
output.WriteInt32(3, Damage);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FightRankInfo _inst = (FightRankInfo) _base;
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
   case  18: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  24: {
 _inst.Damage = input.ReadInt32();
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
public class GCRefreshFightRankList : PacketDistributed
{

public const int myRankFieldNumber = 1;
 private bool hasMyRank;
 private Int32 myRank_ = 0;
 public bool HasMyRank {
 get { return hasMyRank; }
 }
 public Int32 MyRank {
 get { return myRank_; }
 set { SetMyRank(value); }
 }
 public void SetMyRank(Int32 value) { 
 hasMyRank = true;
 myRank_ = value;
 }

public const int myDamageFieldNumber = 2;
 private bool hasMyDamage;
 private Int32 myDamage_ = 0;
 public bool HasMyDamage {
 get { return hasMyDamage; }
 }
 public Int32 MyDamage {
 get { return myDamage_; }
 set { SetMyDamage(value); }
 }
 public void SetMyDamage(Int32 value) { 
 hasMyDamage = true;
 myDamage_ = value;
 }

public const int rankListFieldNumber = 3;
 private pbc::PopsicleList<FightRankInfo> rankList_ = new pbc::PopsicleList<FightRankInfo>();
 public scg::IList<FightRankInfo> rankListList {
 get { return pbc::Lists.AsReadOnly(rankList_); }
 }
 
 public int rankListCount {
 get { return rankList_.Count; }
 }
 
public FightRankInfo GetRankList(int index) {
 return rankList_[index];
 }
 public void AddRankList(FightRankInfo value) {
 rankList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMyRank) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MyRank);
}
 if (HasMyDamage) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MyDamage);
}
{
foreach (FightRankInfo element in rankListList) {
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
  
if (HasMyRank) {
output.WriteInt32(1, MyRank);
}
 
if (HasMyDamage) {
output.WriteInt32(2, MyDamage);
}

do{
foreach (FightRankInfo element in rankListList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshFightRankList _inst = (GCRefreshFightRankList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MyRank = input.ReadInt32();
break;
}
   case  16: {
 _inst.MyDamage = input.ReadInt32();
break;
}
    case  26: {
FightRankInfo subBuilder =  new FightRankInfo();
input.ReadMessage(subBuilder);
_inst.AddRankList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FightRankInfo element in rankListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshRankRewardsList : PacketDistributed
{

public const int rewardListFieldNumber = 1;
 private pbc::PopsicleList<RankRewardsInfo> rewardList_ = new pbc::PopsicleList<RankRewardsInfo>();
 public scg::IList<RankRewardsInfo> rewardListList {
 get { return pbc::Lists.AsReadOnly(rewardList_); }
 }
 
 public int rewardListCount {
 get { return rewardList_.Count; }
 }
 
public RankRewardsInfo GetRewardList(int index) {
 return rewardList_[index];
 }
 public void AddRewardList(RankRewardsInfo value) {
 rewardList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RankRewardsInfo element in rewardListList) {
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
foreach (RankRewardsInfo element in rewardListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshRankRewardsList _inst = (GCRefreshRankRewardsList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RankRewardsInfo subBuilder =  new RankRewardsInfo();
input.ReadMessage(subBuilder);
_inst.AddRewardList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RankRewardsInfo element in rewardListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshSnowBossActitivy : PacketDistributed
{

public const int nameFieldNumber = 1;
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

public const int ruleExplainFieldNumber = 2;
 private bool hasRuleExplain;
 private string ruleExplain_ = "";
 public bool HasRuleExplain {
 get { return hasRuleExplain; }
 }
 public string RuleExplain {
 get { return ruleExplain_; }
 set { SetRuleExplain(value); }
 }
 public void SetRuleExplain(string value) { 
 hasRuleExplain = true;
 ruleExplain_ = value;
 }

public const int iconFieldNumber = 3;
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

public const int buttonNameFieldNumber = 4;
 private bool hasButtonName;
 private string buttonName_ = "";
 public bool HasButtonName {
 get { return hasButtonName; }
 }
 public string ButtonName {
 get { return buttonName_; }
 set { SetButtonName(value); }
 }
 public void SetButtonName(string value) { 
 hasButtonName = true;
 buttonName_ = value;
 }

public const int levelFieldNumber = 5;
 private bool hasLevel;
 private Int32 level_ = 0;
 public bool HasLevel {
 get { return hasLevel; }
 }
 public Int32 Level {
 get { return level_; }
 set { SetLevel(value); }
 }
 public void SetLevel(Int32 value) { 
 hasLevel = true;
 level_ = value;
 }

public const int playerStatusFieldNumber = 6;
 private bool hasPlayerStatus;
 private Int32 playerStatus_ = 0;
 public bool HasPlayerStatus {
 get { return hasPlayerStatus; }
 }
 public Int32 PlayerStatus {
 get { return playerStatus_; }
 set { SetPlayerStatus(value); }
 }
 public void SetPlayerStatus(Int32 value) { 
 hasPlayerStatus = true;
 playerStatus_ = value;
 }

public const int needClearCacheFieldNumber = 7;
 private bool hasNeedClearCache;
 private Int32 needClearCache_ = 0;
 public bool HasNeedClearCache {
 get { return hasNeedClearCache; }
 }
 public Int32 NeedClearCache {
 get { return needClearCache_; }
 set { SetNeedClearCache(value); }
 }
 public void SetNeedClearCache(Int32 value) { 
 hasNeedClearCache = true;
 needClearCache_ = value;
 }

public const int canEnterTimeFieldNumber = 8;
 private bool hasCanEnterTime;
 private Int64 canEnterTime_ = 0;
 public bool HasCanEnterTime {
 get { return hasCanEnterTime; }
 }
 public Int64 CanEnterTime {
 get { return canEnterTime_; }
 set { SetCanEnterTime(value); }
 }
 public void SetCanEnterTime(Int64 value) { 
 hasCanEnterTime = true;
 canEnterTime_ = value;
 }

public const int bossidFieldNumber = 9;
 private bool hasBossid;
 private Int32 bossid_ = 0;
 public bool HasBossid {
 get { return hasBossid; }
 }
 public Int32 Bossid {
 get { return bossid_; }
 set { SetBossid(value); }
 }
 public void SetBossid(Int32 value) { 
 hasBossid = true;
 bossid_ = value;
 }

public const int positionFieldNumber = 10;
 private bool hasPosition;
 private string position_ = "";
 public bool HasPosition {
 get { return hasPosition; }
 }
 public string Position {
 get { return position_; }
 set { SetPosition(value); }
 }
 public void SetPosition(string value) { 
 hasPosition = true;
 position_ = value;
 }

public const int rotationFieldNumber = 11;
 private bool hasRotation;
 private string rotation_ = "";
 public bool HasRotation {
 get { return hasRotation; }
 }
 public string Rotation {
 get { return rotation_; }
 set { SetRotation(value); }
 }
 public void SetRotation(string value) { 
 hasRotation = true;
 rotation_ = value;
 }

public const int scaleFieldNumber = 12;
 private bool hasScale;
 private string scale_ = "";
 public bool HasScale {
 get { return hasScale; }
 }
 public string Scale {
 get { return scale_; }
 set { SetScale(value); }
 }
 public void SetScale(string value) { 
 hasScale = true;
 scale_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(1, Name);
}
 if (HasRuleExplain) {
size += pb::CodedOutputStream.ComputeStringSize(2, RuleExplain);
}
 if (HasIcon) {
size += pb::CodedOutputStream.ComputeStringSize(3, Icon);
}
 if (HasButtonName) {
size += pb::CodedOutputStream.ComputeStringSize(4, ButtonName);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Level);
}
 if (HasPlayerStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(6, PlayerStatus);
}
 if (HasNeedClearCache) {
size += pb::CodedOutputStream.ComputeInt32Size(7, NeedClearCache);
}
 if (HasCanEnterTime) {
size += pb::CodedOutputStream.ComputeInt64Size(8, CanEnterTime);
}
 if (HasBossid) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Bossid);
}
 if (HasPosition) {
size += pb::CodedOutputStream.ComputeStringSize(10, Position);
}
 if (HasRotation) {
size += pb::CodedOutputStream.ComputeStringSize(11, Rotation);
}
 if (HasScale) {
size += pb::CodedOutputStream.ComputeStringSize(12, Scale);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasName) {
output.WriteString(1, Name);
}
 
if (HasRuleExplain) {
output.WriteString(2, RuleExplain);
}
 
if (HasIcon) {
output.WriteString(3, Icon);
}
 
if (HasButtonName) {
output.WriteString(4, ButtonName);
}
 
if (HasLevel) {
output.WriteInt32(5, Level);
}
 
if (HasPlayerStatus) {
output.WriteInt32(6, PlayerStatus);
}
 
if (HasNeedClearCache) {
output.WriteInt32(7, NeedClearCache);
}
 
if (HasCanEnterTime) {
output.WriteInt64(8, CanEnterTime);
}
 
if (HasBossid) {
output.WriteInt32(9, Bossid);
}
 
if (HasPosition) {
output.WriteString(10, Position);
}
 
if (HasRotation) {
output.WriteString(11, Rotation);
}
 
if (HasScale) {
output.WriteString(12, Scale);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshSnowBossActitivy _inst = (GCRefreshSnowBossActitivy) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Name = input.ReadString();
break;
}
   case  18: {
 _inst.RuleExplain = input.ReadString();
break;
}
   case  26: {
 _inst.Icon = input.ReadString();
break;
}
   case  34: {
 _inst.ButtonName = input.ReadString();
break;
}
   case  40: {
 _inst.Level = input.ReadInt32();
break;
}
   case  48: {
 _inst.PlayerStatus = input.ReadInt32();
break;
}
   case  56: {
 _inst.NeedClearCache = input.ReadInt32();
break;
}
   case  64: {
 _inst.CanEnterTime = input.ReadInt64();
break;
}
   case  72: {
 _inst.Bossid = input.ReadInt32();
break;
}
   case  82: {
 _inst.Position = input.ReadString();
break;
}
   case  90: {
 _inst.Rotation = input.ReadString();
break;
}
   case  98: {
 _inst.Scale = input.ReadString();
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
public class RankRewardsInfo : PacketDistributed
{

public const int ranksFieldNumber = 1;
 private bool hasRanks;
 private string ranks_ = "";
 public bool HasRanks {
 get { return hasRanks; }
 }
 public string Ranks {
 get { return ranks_; }
 set { SetRanks(value); }
 }
 public void SetRanks(string value) { 
 hasRanks = true;
 ranks_ = value;
 }

public const int rewardsFieldNumber = 2;
 private pbc::PopsicleList<Iteminfo> rewards_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> rewardsList {
 get { return pbc::Lists.AsReadOnly(rewards_); }
 }
 
 public int rewardsCount {
 get { return rewards_.Count; }
 }
 
public Iteminfo GetRewards(int index) {
 return rewards_[index];
 }
 public void AddRewards(Iteminfo value) {
 rewards_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRanks) {
size += pb::CodedOutputStream.ComputeStringSize(1, Ranks);
}
{
foreach (Iteminfo element in rewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRanks) {
output.WriteString(1, Ranks);
}

do{
foreach (Iteminfo element in rewardsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RankRewardsInfo _inst = (RankRewardsInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Ranks = input.ReadString();
break;
}
    case  18: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddRewards(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Iteminfo element in rewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
