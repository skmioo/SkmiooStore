//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGNationalOperate : PacketDistributed
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

public const int itemIDFieldNumber = 2;
 private bool hasItemID;
 private Int32 itemID_ = 0;
 public bool HasItemID {
 get { return hasItemID; }
 }
 public Int32 ItemID {
 get { return itemID_; }
 set { SetItemID(value); }
 }
 public void SetItemID(Int32 value) { 
 hasItemID = true;
 itemID_ = value;
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
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasItemID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ItemID);
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
  
if (HasOperate) {
output.WriteInt32(1, Operate);
}
 
if (HasItemID) {
output.WriteInt32(2, ItemID);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGNationalOperate _inst = (CGNationalOperate) _base;
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
 _inst.ItemID = input.ReadInt32();
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
public class GCNationalOperateResult : PacketDistributed
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

public const int nationalRewardsFieldNumber = 2;
 private pbc::PopsicleList<NationalReward> nationalRewards_ = new pbc::PopsicleList<NationalReward>();
 public scg::IList<NationalReward> nationalRewardsList {
 get { return pbc::Lists.AsReadOnly(nationalRewards_); }
 }
 
 public int nationalRewardsCount {
 get { return nationalRewards_.Count; }
 }
 
public NationalReward GetNationalRewards(int index) {
 return nationalRewards_[index];
 }
 public void AddNationalRewards(NationalReward value) {
 nationalRewards_.Add(value);
 }

public const int nationalCashsFieldNumber = 3;
 private pbc::PopsicleList<NationalCash> nationalCashs_ = new pbc::PopsicleList<NationalCash>();
 public scg::IList<NationalCash> nationalCashsList {
 get { return pbc::Lists.AsReadOnly(nationalCashs_); }
 }
 
 public int nationalCashsCount {
 get { return nationalCashs_.Count; }
 }
 
public NationalCash GetNationalCashs(int index) {
 return nationalCashs_[index];
 }
 public void AddNationalCashs(NationalCash value) {
 nationalCashs_.Add(value);
 }

public const int nationalItemsFieldNumber = 4;
 private pbc::PopsicleList<NationalItem> nationalItems_ = new pbc::PopsicleList<NationalItem>();
 public scg::IList<NationalItem> nationalItemsList {
 get { return pbc::Lists.AsReadOnly(nationalItems_); }
 }
 
 public int nationalItemsCount {
 get { return nationalItems_.Count; }
 }
 
public NationalItem GetNationalItems(int index) {
 return nationalItems_[index];
 }
 public void AddNationalItems(NationalItem value) {
 nationalItems_.Add(value);
 }

public const int nationalRanksFieldNumber = 5;
 private pbc::PopsicleList<NationalRank> nationalRanks_ = new pbc::PopsicleList<NationalRank>();
 public scg::IList<NationalRank> nationalRanksList {
 get { return pbc::Lists.AsReadOnly(nationalRanks_); }
 }
 
 public int nationalRanksCount {
 get { return nationalRanks_.Count; }
 }
 
public NationalRank GetNationalRanks(int index) {
 return nationalRanks_[index];
 }
 public void AddNationalRanks(NationalRank value) {
 nationalRanks_.Add(value);
 }

public const int nationalInfosFieldNumber = 6;
 private bool hasNationalInfos;
 private NationalInfo nationalInfos_ =  new NationalInfo();
 public bool HasNationalInfos {
 get { return hasNationalInfos; }
 }
 public NationalInfo NationalInfos {
 get { return nationalInfos_; }
 set { SetNationalInfos(value); }
 }
 public void SetNationalInfos(NationalInfo value) { 
 hasNationalInfos = true;
 nationalInfos_ = value;
 }

public const int multiplesFieldNumber = 7;
 private pbc::PopsicleList<Int32> multiples_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> multiplesList {
 get { return pbc::Lists.AsReadOnly(multiples_); }
 }
 
 public int multiplesCount {
 get { return multiples_.Count; }
 }
 
public Int32 GetMultiples(int index) {
 return multiples_[index];
 }
 public void AddMultiples(Int32 value) {
 multiples_.Add(value);
 }

public const int actTypeFieldNumber = 8;
 private bool hasActType;
 private Int32 actType_ = 0;
 public bool HasActType {
 get { return hasActType; }
 }
 public Int32 ActType {
 get { return actType_; }
 set { SetActType(value); }
 }
 public void SetActType(Int32 value) { 
 hasActType = true;
 actType_ = value;
 }

public const int captionFieldNumber = 9;
 private bool hasCaption;
 private string caption_ = "";
 public bool HasCaption {
 get { return hasCaption; }
 }
 public string Caption {
 get { return caption_; }
 set { SetCaption(value); }
 }
 public void SetCaption(string value) { 
 hasCaption = true;
 caption_ = value;
 }

public const int listNumFieldNumber = 10;
 private bool hasListNum;
 private string listNum_ = "";
 public bool HasListNum {
 get { return hasListNum; }
 }
 public string ListNum {
 get { return listNum_; }
 set { SetListNum(value); }
 }
 public void SetListNum(string value) { 
 hasListNum = true;
 listNum_ = value;
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
foreach (NationalReward element in nationalRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (NationalCash element in nationalCashsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (NationalItem element in nationalItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (NationalRank element in nationalRanksList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = NationalInfos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int dataSize = 0;
foreach (Int32 element in multiplesList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * multiples_.Count;
}
 if (HasActType) {
size += pb::CodedOutputStream.ComputeInt32Size(8, ActType);
}
 if (HasCaption) {
size += pb::CodedOutputStream.ComputeStringSize(9, Caption);
}
 if (HasListNum) {
size += pb::CodedOutputStream.ComputeStringSize(10, ListNum);
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
foreach (NationalReward element in nationalRewardsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (NationalCash element in nationalCashsList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (NationalItem element in nationalItemsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (NationalRank element in nationalRanksList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)NationalInfos.SerializedSize());
NationalInfos.WriteTo(output);

}
{
if (multiples_.Count > 0) {
foreach (Int32 element in multiplesList) {
output.WriteInt32(7,element);
}
}

}
 
if (HasActType) {
output.WriteInt32(8, ActType);
}
 
if (HasCaption) {
output.WriteString(9, Caption);
}
 
if (HasListNum) {
output.WriteString(10, ListNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCNationalOperateResult _inst = (GCNationalOperateResult) _base;
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
NationalReward subBuilder =  new NationalReward();
input.ReadMessage(subBuilder);
_inst.AddNationalRewards(subBuilder);
break;
}
    case  26: {
NationalCash subBuilder =  new NationalCash();
input.ReadMessage(subBuilder);
_inst.AddNationalCashs(subBuilder);
break;
}
    case  34: {
NationalItem subBuilder =  new NationalItem();
input.ReadMessage(subBuilder);
_inst.AddNationalItems(subBuilder);
break;
}
    case  42: {
NationalRank subBuilder =  new NationalRank();
input.ReadMessage(subBuilder);
_inst.AddNationalRanks(subBuilder);
break;
}
    case  50: {
NationalInfo subBuilder =  new NationalInfo();
 input.ReadMessage(subBuilder);
_inst.NationalInfos = subBuilder;
break;
}
   case  56: {
 _inst.AddMultiples(input.ReadInt32());
break;
}
   case  64: {
 _inst.ActType = input.ReadInt32();
break;
}
   case  74: {
 _inst.Caption = input.ReadString();
break;
}
   case  82: {
 _inst.ListNum = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (NationalReward element in nationalRewardsList) {
if (!element.IsInitialized()) return false;
}
foreach (NationalCash element in nationalCashsList) {
if (!element.IsInitialized()) return false;
}
foreach (NationalItem element in nationalItemsList) {
if (!element.IsInitialized()) return false;
}
foreach (NationalRank element in nationalRanksList) {
if (!element.IsInitialized()) return false;
}
  if (HasNationalInfos) {
if (!NationalInfos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class NationalCash : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Points);
}
 if (HasReward) {
size += pb::CodedOutputStream.ComputeStringSize(3, Reward);
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
 
if (HasPoints) {
output.WriteInt32(2, Points);
}
 
if (HasReward) {
output.WriteString(3, Reward);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NationalCash _inst = (NationalCash) _base;
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
 _inst.Points = input.ReadInt32();
break;
}
   case  26: {
 _inst.Reward = input.ReadString();
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
public class NationalInfo : PacketDistributed
{

public const int totalPointsFieldNumber = 1;
 private bool hasTotalPoints;
 private Int32 totalPoints_ = 0;
 public bool HasTotalPoints {
 get { return hasTotalPoints; }
 }
 public Int32 TotalPoints {
 get { return totalPoints_; }
 set { SetTotalPoints(value); }
 }
 public void SetTotalPoints(Int32 value) { 
 hasTotalPoints = true;
 totalPoints_ = value;
 }

public const int dailyPointsFieldNumber = 2;
 private bool hasDailyPoints;
 private Int32 dailyPoints_ = 0;
 public bool HasDailyPoints {
 get { return hasDailyPoints; }
 }
 public Int32 DailyPoints {
 get { return dailyPoints_; }
 set { SetDailyPoints(value); }
 }
 public void SetDailyPoints(Int32 value) { 
 hasDailyPoints = true;
 dailyPoints_ = value;
 }

public const int cashsFieldNumber = 3;
 private pbc::PopsicleList<Int32> cashs_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> cashsList {
 get { return pbc::Lists.AsReadOnly(cashs_); }
 }
 
 public int cashsCount {
 get { return cashs_.Count; }
 }
 
public Int32 GetCashs(int index) {
 return cashs_[index];
 }
 public void AddCashs(Int32 value) {
 cashs_.Add(value);
 }

public const int baseHateFieldNumber = 4;
 private bool hasBaseHate;
 private Int32 baseHate_ = 0;
 public bool HasBaseHate {
 get { return hasBaseHate; }
 }
 public Int32 BaseHate {
 get { return baseHate_; }
 set { SetBaseHate(value); }
 }
 public void SetBaseHate(Int32 value) { 
 hasBaseHate = true;
 baseHate_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTotalPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TotalPoints);
}
 if (HasDailyPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(2, DailyPoints);
}
{
int dataSize = 0;
foreach (Int32 element in cashsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * cashs_.Count;
}
 if (HasBaseHate) {
size += pb::CodedOutputStream.ComputeInt32Size(4, BaseHate);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTotalPoints) {
output.WriteInt32(1, TotalPoints);
}
 
if (HasDailyPoints) {
output.WriteInt32(2, DailyPoints);
}
{
if (cashs_.Count > 0) {
foreach (Int32 element in cashsList) {
output.WriteInt32(3,element);
}
}

}
 
if (HasBaseHate) {
output.WriteInt32(4, BaseHate);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NationalInfo _inst = (NationalInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TotalPoints = input.ReadInt32();
break;
}
   case  16: {
 _inst.DailyPoints = input.ReadInt32();
break;
}
   case  24: {
 _inst.AddCashs(input.ReadInt32());
break;
}
   case  32: {
 _inst.BaseHate = input.ReadInt32();
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
public class NationalItem : PacketDistributed
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

public const int itemInfoFieldNumber = 3;
 private bool hasItemInfo;
 private string itemInfo_ = "";
 public bool HasItemInfo {
 get { return hasItemInfo; }
 }
 public string ItemInfo {
 get { return itemInfo_; }
 set { SetItemInfo(value); }
 }
 public void SetItemInfo(string value) { 
 hasItemInfo = true;
 itemInfo_ = value;
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
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Points);
}
 if (HasItemInfo) {
size += pb::CodedOutputStream.ComputeStringSize(3, ItemInfo);
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
 
if (HasPoints) {
output.WriteInt32(2, Points);
}
 
if (HasItemInfo) {
output.WriteString(3, ItemInfo);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NationalItem _inst = (NationalItem) _base;
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
 _inst.Points = input.ReadInt32();
break;
}
   case  26: {
 _inst.ItemInfo = input.ReadString();
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
public class NationalRank : PacketDistributed
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

public const int pointsFieldNumber = 3;
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

public const int playerIDFieldNumber = 4;
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
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Points);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(4, PlayerID);
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
 
if (HasPoints) {
output.WriteInt32(3, Points);
}
 
if (HasPlayerID) {
output.WriteInt64(4, PlayerID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NationalRank _inst = (NationalRank) _base;
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
 _inst.Points = input.ReadInt32();
break;
}
   case  32: {
 _inst.PlayerID = input.ReadInt64();
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
public class NationalReward : PacketDistributed
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

public const int rewardFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasReward) {
size += pb::CodedOutputStream.ComputeStringSize(2, Reward);
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
 
if (HasReward) {
output.WriteString(2, Reward);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NationalReward _inst = (NationalReward) _base;
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
   case  18: {
 _inst.Reward = input.ReadString();
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
