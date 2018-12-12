//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGTowerSend : PacketDistributed
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

public const int buyNumFieldNumber = 2;
 private bool hasBuyNum;
 private Int32 buyNum_ = 0;
 public bool HasBuyNum {
 get { return hasBuyNum; }
 }
 public Int32 BuyNum {
 get { return buyNum_; }
 set { SetBuyNum(value); }
 }
 public void SetBuyNum(Int32 value) { 
 hasBuyNum = true;
 buyNum_ = value;
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
 if (HasBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BuyNum);
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
 
if (HasBuyNum) {
output.WriteInt32(2, BuyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTowerSend _inst = (CGTowerSend) _base;
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
 _inst.BuyNum = input.ReadInt32();
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
public class GCTowerPush : PacketDistributed
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

public const int timeStampFieldNumber = 2;
 private bool hasTimeStamp;
 private Int64 timeStamp_ = 0;
 public bool HasTimeStamp {
 get { return hasTimeStamp; }
 }
 public Int64 TimeStamp {
 get { return timeStamp_; }
 set { SetTimeStamp(value); }
 }
 public void SetTimeStamp(Int64 value) { 
 hasTimeStamp = true;
 timeStamp_ = value;
 }

public const int towerInfoFieldNumber = 3;
 private bool hasTowerInfo;
 private TowerInfo towerInfo_ =  new TowerInfo();
 public bool HasTowerInfo {
 get { return hasTowerInfo; }
 }
 public TowerInfo TowerInfo {
 get { return towerInfo_; }
 set { SetTowerInfo(value); }
 }
 public void SetTowerInfo(TowerInfo value) { 
 hasTowerInfo = true;
 towerInfo_ = value;
 }

public const int rewardItemsFieldNumber = 4;
 private pbc::PopsicleList<RewardItem> rewardItems_ = new pbc::PopsicleList<RewardItem>();
 public scg::IList<RewardItem> rewardItemsList {
 get { return pbc::Lists.AsReadOnly(rewardItems_); }
 }
 
 public int rewardItemsCount {
 get { return rewardItems_.Count; }
 }
 
public RewardItem GetRewardItems(int index) {
 return rewardItems_[index];
 }
 public void AddRewardItems(RewardItem value) {
 rewardItems_.Add(value);
 }

public const int firstRewardsFieldNumber = 5;
 private pbc::PopsicleList<RewardItem> firstRewards_ = new pbc::PopsicleList<RewardItem>();
 public scg::IList<RewardItem> firstRewardsList {
 get { return pbc::Lists.AsReadOnly(firstRewards_); }
 }
 
 public int firstRewardsCount {
 get { return firstRewards_.Count; }
 }
 
public RewardItem GetFirstRewards(int index) {
 return firstRewards_[index];
 }
 public void AddFirstRewards(RewardItem value) {
 firstRewards_.Add(value);
 }

public const int towerIDFieldNumber = 6;
 private bool hasTowerID;
 private Int32 towerID_ = 0;
 public bool HasTowerID {
 get { return hasTowerID; }
 }
 public Int32 TowerID {
 get { return towerID_; }
 set { SetTowerID(value); }
 }
 public void SetTowerID(Int32 value) { 
 hasTowerID = true;
 towerID_ = value;
 }

public const int beginTimeFieldNumber = 7;
 private bool hasBeginTime;
 private Int64 beginTime_ = 0;
 public bool HasBeginTime {
 get { return hasBeginTime; }
 }
 public Int64 BeginTime {
 get { return beginTime_; }
 set { SetBeginTime(value); }
 }
 public void SetBeginTime(Int64 value) { 
 hasBeginTime = true;
 beginTime_ = value;
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
 if (HasTimeStamp) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TimeStamp);
}
{
int subsize = TowerInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (RewardItem element in rewardItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (RewardItem element in firstRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasTowerID) {
size += pb::CodedOutputStream.ComputeInt32Size(6, TowerID);
}
 if (HasBeginTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, BeginTime);
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
 
if (HasTimeStamp) {
output.WriteInt64(2, TimeStamp);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TowerInfo.SerializedSize());
TowerInfo.WriteTo(output);

}

do{
foreach (RewardItem element in rewardItemsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (RewardItem element in firstRewardsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasTowerID) {
output.WriteInt32(6, TowerID);
}
 
if (HasBeginTime) {
output.WriteInt64(7, BeginTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTowerPush _inst = (GCTowerPush) _base;
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
 _inst.TimeStamp = input.ReadInt64();
break;
}
    case  26: {
TowerInfo subBuilder =  new TowerInfo();
 input.ReadMessage(subBuilder);
_inst.TowerInfo = subBuilder;
break;
}
    case  34: {
RewardItem subBuilder =  new RewardItem();
input.ReadMessage(subBuilder);
_inst.AddRewardItems(subBuilder);
break;
}
    case  42: {
RewardItem subBuilder =  new RewardItem();
input.ReadMessage(subBuilder);
_inst.AddFirstRewards(subBuilder);
break;
}
   case  48: {
 _inst.TowerID = input.ReadInt32();
break;
}
   case  56: {
 _inst.BeginTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTowerInfo) {
if (!TowerInfo.IsInitialized()) return false;
}
foreach (RewardItem element in rewardItemsList) {
if (!element.IsInitialized()) return false;
}
foreach (RewardItem element in firstRewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class RewardItem : PacketDistributed
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
 RewardItem _inst = (RewardItem) _base;
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
public class TowerInfo : PacketDistributed
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

public const int limitNumFieldNumber = 2;
 private bool hasLimitNum;
 private Int32 limitNum_ = 0;
 public bool HasLimitNum {
 get { return hasLimitNum; }
 }
 public Int32 LimitNum {
 get { return limitNum_; }
 set { SetLimitNum(value); }
 }
 public void SetLimitNum(Int32 value) { 
 hasLimitNum = true;
 limitNum_ = value;
 }

public const int clearNumFieldNumber = 3;
 private bool hasClearNum;
 private Int32 clearNum_ = 0;
 public bool HasClearNum {
 get { return hasClearNum; }
 }
 public Int32 ClearNum {
 get { return clearNum_; }
 set { SetClearNum(value); }
 }
 public void SetClearNum(Int32 value) { 
 hasClearNum = true;
 clearNum_ = value;
 }

public const int pileNumFieldNumber = 4;
 private bool hasPileNum;
 private Int32 pileNum_ = 0;
 public bool HasPileNum {
 get { return hasPileNum; }
 }
 public Int32 PileNum {
 get { return pileNum_; }
 set { SetPileNum(value); }
 }
 public void SetPileNum(Int32 value) { 
 hasPileNum = true;
 pileNum_ = value;
 }

public const int statusFieldNumber = 5;
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

public const int beginTimeFieldNumber = 6;
 private bool hasBeginTime;
 private Int64 beginTime_ = 0;
 public bool HasBeginTime {
 get { return hasBeginTime; }
 }
 public Int64 BeginTime {
 get { return beginTime_; }
 set { SetBeginTime(value); }
 }
 public void SetBeginTime(Int64 value) { 
 hasBeginTime = true;
 beginTime_ = value;
 }

public const int topNumFieldNumber = 7;
 private bool hasTopNum;
 private Int32 topNum_ = 0;
 public bool HasTopNum {
 get { return hasTopNum; }
 }
 public Int32 TopNum {
 get { return topNum_; }
 set { SetTopNum(value); }
 }
 public void SetTopNum(Int32 value) { 
 hasTopNum = true;
 topNum_ = value;
 }

public const int clearPileNumFieldNumber = 8;
 private bool hasClearPileNum;
 private Int32 clearPileNum_ = 0;
 public bool HasClearPileNum {
 get { return hasClearPileNum; }
 }
 public Int32 ClearPileNum {
 get { return clearPileNum_; }
 set { SetClearPileNum(value); }
 }
 public void SetClearPileNum(Int32 value) { 
 hasClearPileNum = true;
 clearPileNum_ = value;
 }

public const int maxVipNumFieldNumber = 9;
 private bool hasMaxVipNum;
 private Int32 maxVipNum_ = 0;
 public bool HasMaxVipNum {
 get { return hasMaxVipNum; }
 }
 public Int32 MaxVipNum {
 get { return maxVipNum_; }
 set { SetMaxVipNum(value); }
 }
 public void SetMaxVipNum(Int32 value) { 
 hasMaxVipNum = true;
 maxVipNum_ = value;
 }

public const int alreadyBuyFieldNumber = 10;
 private bool hasAlreadyBuy;
 private Int32 alreadyBuy_ = 0;
 public bool HasAlreadyBuy {
 get { return hasAlreadyBuy; }
 }
 public Int32 AlreadyBuy {
 get { return alreadyBuy_; }
 set { SetAlreadyBuy(value); }
 }
 public void SetAlreadyBuy(Int32 value) { 
 hasAlreadyBuy = true;
 alreadyBuy_ = value;
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
 if (HasLimitNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LimitNum);
}
 if (HasClearNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ClearNum);
}
 if (HasPileNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, PileNum);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Status);
}
 if (HasBeginTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, BeginTime);
}
 if (HasTopNum) {
size += pb::CodedOutputStream.ComputeInt32Size(7, TopNum);
}
 if (HasClearPileNum) {
size += pb::CodedOutputStream.ComputeInt32Size(8, ClearPileNum);
}
 if (HasMaxVipNum) {
size += pb::CodedOutputStream.ComputeInt32Size(9, MaxVipNum);
}
 if (HasAlreadyBuy) {
size += pb::CodedOutputStream.ComputeInt32Size(10, AlreadyBuy);
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
 
if (HasLimitNum) {
output.WriteInt32(2, LimitNum);
}
 
if (HasClearNum) {
output.WriteInt32(3, ClearNum);
}
 
if (HasPileNum) {
output.WriteInt32(4, PileNum);
}
 
if (HasStatus) {
output.WriteInt32(5, Status);
}
 
if (HasBeginTime) {
output.WriteInt64(6, BeginTime);
}
 
if (HasTopNum) {
output.WriteInt32(7, TopNum);
}
 
if (HasClearPileNum) {
output.WriteInt32(8, ClearPileNum);
}
 
if (HasMaxVipNum) {
output.WriteInt32(9, MaxVipNum);
}
 
if (HasAlreadyBuy) {
output.WriteInt32(10, AlreadyBuy);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TowerInfo _inst = (TowerInfo) _base;
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
   case  16: {
 _inst.LimitNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.ClearNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.PileNum = input.ReadInt32();
break;
}
   case  40: {
 _inst.Status = input.ReadInt32();
break;
}
   case  48: {
 _inst.BeginTime = input.ReadInt64();
break;
}
   case  56: {
 _inst.TopNum = input.ReadInt32();
break;
}
   case  64: {
 _inst.ClearPileNum = input.ReadInt32();
break;
}
   case  72: {
 _inst.MaxVipNum = input.ReadInt32();
break;
}
   case  80: {
 _inst.AlreadyBuy = input.ReadInt32();
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
