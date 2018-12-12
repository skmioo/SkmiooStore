//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCheckHRUpdate : PacketDistributed
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
 CGCheckHRUpdate _inst = (CGCheckHRUpdate) _base;
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
public class CGHappyRoll : PacketDistributed
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
 CGHappyRoll _inst = (CGHappyRoll) _base;
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
public class CGHappyRollBuyMoney : PacketDistributed
{

public const int buyMoneyNumFieldNumber = 1;
 private bool hasBuyMoneyNum;
 private Int32 buyMoneyNum_ = 0;
 public bool HasBuyMoneyNum {
 get { return hasBuyMoneyNum; }
 }
 public Int32 BuyMoneyNum {
 get { return buyMoneyNum_; }
 set { SetBuyMoneyNum(value); }
 }
 public void SetBuyMoneyNum(Int32 value) { 
 hasBuyMoneyNum = true;
 buyMoneyNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBuyMoneyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, BuyMoneyNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBuyMoneyNum) {
output.WriteInt32(1, BuyMoneyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGHappyRollBuyMoney _inst = (CGHappyRollBuyMoney) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.BuyMoneyNum = input.ReadInt32();
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
public class CGHappyRollGetReward : PacketDistributed
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
 CGHappyRollGetReward _inst = (CGHappyRollGetReward) _base;
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
public class CGLottery : PacketDistributed
{

public const int choseRewardIDListFieldNumber = 1;
 private pbc::PopsicleList<Int32> choseRewardIDList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> choseRewardIDListList {
 get { return pbc::Lists.AsReadOnly(choseRewardIDList_); }
 }
 
 public int choseRewardIDListCount {
 get { return choseRewardIDList_.Count; }
 }
 
public Int32 GetChoseRewardIDList(int index) {
 return choseRewardIDList_[index];
 }
 public void AddChoseRewardIDList(Int32 value) {
 choseRewardIDList_.Add(value);
 }

public const int choseMultipleFieldNumber = 2;
 private bool hasChoseMultiple;
 private Int32 choseMultiple_ = 0;
 public bool HasChoseMultiple {
 get { return hasChoseMultiple; }
 }
 public Int32 ChoseMultiple {
 get { return choseMultiple_; }
 set { SetChoseMultiple(value); }
 }
 public void SetChoseMultiple(Int32 value) { 
 hasChoseMultiple = true;
 choseMultiple_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in choseRewardIDListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * choseRewardIDList_.Count;
}
 if (HasChoseMultiple) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChoseMultiple);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (choseRewardIDList_.Count > 0) {
foreach (Int32 element in choseRewardIDListList) {
output.WriteInt32(1,element);
}
}

}
 
if (HasChoseMultiple) {
output.WriteInt32(2, ChoseMultiple);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLottery _inst = (CGLottery) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddChoseRewardIDList(input.ReadInt32());
break;
}
   case  16: {
 _inst.ChoseMultiple = input.ReadInt32();
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
public class GCHappyRoll : PacketDistributed
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

public const int hrInfoFieldNumber = 2;
 private bool hasHrInfo;
 private HRInfo hrInfo_ =  new HRInfo();
 public bool HasHrInfo {
 get { return hasHrInfo; }
 }
 public HRInfo HrInfo {
 get { return hrInfo_; }
 set { SetHrInfo(value); }
 }
 public void SetHrInfo(HRInfo value) { 
 hasHrInfo = true;
 hrInfo_ = value;
 }

public const int haveMoneyNumFieldNumber = 3;
 private bool hasHaveMoneyNum;
 private Int32 haveMoneyNum_ = 0;
 public bool HasHaveMoneyNum {
 get { return hasHaveMoneyNum; }
 }
 public Int32 HaveMoneyNum {
 get { return haveMoneyNum_; }
 set { SetHaveMoneyNum(value); }
 }
 public void SetHaveMoneyNum(Int32 value) { 
 hasHaveMoneyNum = true;
 haveMoneyNum_ = value;
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
{
int subsize = HrInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasHaveMoneyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, HaveMoneyNum);
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)HrInfo.SerializedSize());
HrInfo.WriteTo(output);

}
 
if (HasHaveMoneyNum) {
output.WriteInt32(3, HaveMoneyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHappyRoll _inst = (GCHappyRoll) _base;
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
    case  18: {
HRInfo subBuilder =  new HRInfo();
 input.ReadMessage(subBuilder);
_inst.HrInfo = subBuilder;
break;
}
   case  24: {
 _inst.HaveMoneyNum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasHrInfo) {
if (!HrInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCHappyRollGetRewardBack : PacketDistributed
{

public const int resultFieldNumber = 1;
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
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResult) {
output.WriteInt32(1, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHappyRollGetRewardBack _inst = (GCHappyRollGetRewardBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class GCHappyRollJackPotList : PacketDistributed
{

public const int showsFieldNumber = 1;
 private pbc::PopsicleList<ShowInfo> shows_ = new pbc::PopsicleList<ShowInfo>();
 public scg::IList<ShowInfo> showsList {
 get { return pbc::Lists.AsReadOnly(shows_); }
 }
 
 public int showsCount {
 get { return shows_.Count; }
 }
 
public ShowInfo GetShows(int index) {
 return shows_[index];
 }
 public void AddShows(ShowInfo value) {
 shows_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ShowInfo element in showsList) {
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
foreach (ShowInfo element in showsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHappyRollJackPotList _inst = (GCHappyRollJackPotList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ShowInfo subBuilder =  new ShowInfo();
input.ReadMessage(subBuilder);
_inst.AddShows(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ShowInfo element in showsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCHappyRollRewardList : PacketDistributed
{

public const int hrRewardListFieldNumber = 1;
 private pbc::PopsicleList<HRRewardInfo> hrRewardList_ = new pbc::PopsicleList<HRRewardInfo>();
 public scg::IList<HRRewardInfo> hrRewardListList {
 get { return pbc::Lists.AsReadOnly(hrRewardList_); }
 }
 
 public int hrRewardListCount {
 get { return hrRewardList_.Count; }
 }
 
public HRRewardInfo GetHrRewardList(int index) {
 return hrRewardList_[index];
 }
 public void AddHrRewardList(HRRewardInfo value) {
 hrRewardList_.Add(value);
 }

public const int hrMulListFieldNumber = 2;
 private pbc::PopsicleList<Int32> hrMulList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> hrMulListList {
 get { return pbc::Lists.AsReadOnly(hrMulList_); }
 }
 
 public int hrMulListCount {
 get { return hrMulList_.Count; }
 }
 
public Int32 GetHrMulList(int index) {
 return hrMulList_[index];
 }
 public void AddHrMulList(Int32 value) {
 hrMulList_.Add(value);
 }

public const int hrMulDesListFieldNumber = 3;
 private pbc::PopsicleList<Int32> hrMulDesList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> hrMulDesListList {
 get { return pbc::Lists.AsReadOnly(hrMulDesList_); }
 }
 
 public int hrMulDesListCount {
 get { return hrMulDesList_.Count; }
 }
 
public Int32 GetHrMulDesList(int index) {
 return hrMulDesList_[index];
 }
 public void AddHrMulDesList(Int32 value) {
 hrMulDesList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (HRRewardInfo element in hrRewardListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int dataSize = 0;
foreach (Int32 element in hrMulListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * hrMulList_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in hrMulDesListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * hrMulDesList_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (HRRewardInfo element in hrRewardListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
if (hrMulList_.Count > 0) {
foreach (Int32 element in hrMulListList) {
output.WriteInt32(2,element);
}
}

}
{
if (hrMulDesList_.Count > 0) {
foreach (Int32 element in hrMulDesListList) {
output.WriteInt32(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHappyRollRewardList _inst = (GCHappyRollRewardList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
HRRewardInfo subBuilder =  new HRRewardInfo();
input.ReadMessage(subBuilder);
_inst.AddHrRewardList(subBuilder);
break;
}
   case  16: {
 _inst.AddHrMulList(input.ReadInt32());
break;
}
   case  24: {
 _inst.AddHrMulDesList(input.ReadInt32());
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (HRRewardInfo element in hrRewardListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLottery : PacketDistributed
{

public const int resultFieldNumber = 1;
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

public const int targetIDFieldNumber = 2;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

public const int integralFieldNumber = 3;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TargetID);
}
 if (HasIntegral) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Integral);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResult) {
output.WriteInt32(1, Result);
}
 
if (HasTargetID) {
output.WriteInt32(2, TargetID);
}
 
if (HasIntegral) {
output.WriteInt32(3, Integral);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLottery _inst = (GCLottery) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Result = input.ReadInt32();
break;
}
   case  16: {
 _inst.TargetID = input.ReadInt32();
break;
}
   case  24: {
 _inst.Integral = input.ReadInt32();
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
public class GCVersion : PacketDistributed
{

public const int versionFieldNumber = 1;
 private bool hasVersion;
 private Int32 version_ = 0;
 public bool HasVersion {
 get { return hasVersion; }
 }
 public Int32 Version {
 get { return version_; }
 set { SetVersion(value); }
 }
 public void SetVersion(Int32 value) { 
 hasVersion = true;
 version_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasVersion) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Version);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasVersion) {
output.WriteInt32(1, Version);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCVersion _inst = (GCVersion) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Version = input.ReadInt32();
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
public class HRInfo : PacketDistributed
{

public const int rewardListFieldNumber = 1;
 private pbc::PopsicleList<string> rewardList_ = new pbc::PopsicleList<string>();
 public scg::IList<string> rewardListList {
 get { return pbc::Lists.AsReadOnly(rewardList_); }
 }
 
 public int rewardListCount {
 get { return rewardList_.Count; }
 }
 
public string GetRewardList(int index) {
 return rewardList_[index];
 }
 public void AddRewardList(string value) {
 rewardList_.Add(value);
 }

public const int startTimeFieldNumber = 2;
 private bool hasStartTime;
 private Int64 startTime_ = 0;
 public bool HasStartTime {
 get { return hasStartTime; }
 }
 public Int64 StartTime {
 get { return startTime_; }
 set { SetStartTime(value); }
 }
 public void SetStartTime(Int64 value) { 
 hasStartTime = true;
 startTime_ = value;
 }

public const int endTimeFieldNumber = 3;
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

public const int jackPotScoreFieldNumber = 4;
 private bool hasJackPotScore;
 private Int32 jackPotScore_ = 0;
 public bool HasJackPotScore {
 get { return hasJackPotScore; }
 }
 public Int32 JackPotScore {
 get { return jackPotScore_; }
 set { SetJackPotScore(value); }
 }
 public void SetJackPotScore(Int32 value) { 
 hasJackPotScore = true;
 jackPotScore_ = value;
 }

public const int jackPotMoneyFieldNumber = 5;
 private bool hasJackPotMoney;
 private Int32 jackPotMoney_ = 0;
 public bool HasJackPotMoney {
 get { return hasJackPotMoney; }
 }
 public Int32 JackPotMoney {
 get { return jackPotMoney_; }
 set { SetJackPotMoney(value); }
 }
 public void SetJackPotMoney(Int32 value) { 
 hasJackPotMoney = true;
 jackPotMoney_ = value;
 }

public const int percentFieldNumber = 6;
 private bool hasPercent;
 private Int32 percent_ = 0;
 public bool HasPercent {
 get { return hasPercent; }
 }
 public Int32 Percent {
 get { return percent_; }
 set { SetPercent(value); }
 }
 public void SetPercent(Int32 value) { 
 hasPercent = true;
 percent_ = value;
 }

public const int integralFieldNumber = 7;
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

public const int maxSelectNumFieldNumber = 8;
 private bool hasMaxSelectNum;
 private Int32 maxSelectNum_ = 0;
 public bool HasMaxSelectNum {
 get { return hasMaxSelectNum; }
 }
 public Int32 MaxSelectNum {
 get { return maxSelectNum_; }
 set { SetMaxSelectNum(value); }
 }
 public void SetMaxSelectNum(Int32 value) { 
 hasMaxSelectNum = true;
 maxSelectNum_ = value;
 }

public const int lastPondFieldNumber = 9;
 private bool hasLastPond;
 private Int32 lastPond_ = 0;
 public bool HasLastPond {
 get { return hasLastPond; }
 }
 public Int32 LastPond {
 get { return lastPond_; }
 set { SetLastPond(value); }
 }
 public void SetLastPond(Int32 value) { 
 hasLastPond = true;
 lastPond_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (string element in rewardListList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * rewardList_.Count;
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, StartTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, EndTime);
}
 if (HasJackPotScore) {
size += pb::CodedOutputStream.ComputeInt32Size(4, JackPotScore);
}
 if (HasJackPotMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(5, JackPotMoney);
}
 if (HasPercent) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Percent);
}
 if (HasIntegral) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Integral);
}
 if (HasMaxSelectNum) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MaxSelectNum);
}
 if (HasLastPond) {
size += pb::CodedOutputStream.ComputeInt32Size(9, LastPond);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (rewardList_.Count > 0) {
foreach (string element in rewardListList) {
output.WriteString(1,element);
}
}

}
 
if (HasStartTime) {
output.WriteInt64(2, StartTime);
}
 
if (HasEndTime) {
output.WriteInt64(3, EndTime);
}
 
if (HasJackPotScore) {
output.WriteInt32(4, JackPotScore);
}
 
if (HasJackPotMoney) {
output.WriteInt32(5, JackPotMoney);
}
 
if (HasPercent) {
output.WriteInt32(6, Percent);
}
 
if (HasIntegral) {
output.WriteInt32(7, Integral);
}
 
if (HasMaxSelectNum) {
output.WriteInt32(8, MaxSelectNum);
}
 
if (HasLastPond) {
output.WriteInt32(9, LastPond);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 HRInfo _inst = (HRInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.AddRewardList(input.ReadString());
break;
}
   case  16: {
 _inst.StartTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.EndTime = input.ReadInt64();
break;
}
   case  32: {
 _inst.JackPotScore = input.ReadInt32();
break;
}
   case  40: {
 _inst.JackPotMoney = input.ReadInt32();
break;
}
   case  48: {
 _inst.Percent = input.ReadInt32();
break;
}
   case  56: {
 _inst.Integral = input.ReadInt32();
break;
}
   case  64: {
 _inst.MaxSelectNum = input.ReadInt32();
break;
}
   case  72: {
 _inst.LastPond = input.ReadInt32();
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
public class HRRewardInfo : PacketDistributed
{

public const int itemInfoFieldNumber = 1;
 private pbc::PopsicleList<Iteminfo> itemInfo_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> itemInfoList {
 get { return pbc::Lists.AsReadOnly(itemInfo_); }
 }
 
 public int itemInfoCount {
 get { return itemInfo_.Count; }
 }
 
public Iteminfo GetItemInfo(int index) {
 return itemInfo_[index];
 }
 public void AddItemInfo(Iteminfo value) {
 itemInfo_.Add(value);
 }

public const int consumeBidFieldNumber = 2;
 private bool hasConsumeBid;
 private Int32 consumeBid_ = 0;
 public bool HasConsumeBid {
 get { return hasConsumeBid; }
 }
 public Int32 ConsumeBid {
 get { return consumeBid_; }
 set { SetConsumeBid(value); }
 }
 public void SetConsumeBid(Int32 value) { 
 hasConsumeBid = true;
 consumeBid_ = value;
 }

public const int consumeSidFieldNumber = 3;
 private bool hasConsumeSid;
 private Int32 consumeSid_ = 0;
 public bool HasConsumeSid {
 get { return hasConsumeSid; }
 }
 public Int32 ConsumeSid {
 get { return consumeSid_; }
 set { SetConsumeSid(value); }
 }
 public void SetConsumeSid(Int32 value) { 
 hasConsumeSid = true;
 consumeSid_ = value;
 }

public const int consumeValueFieldNumber = 4;
 private bool hasConsumeValue;
 private Int32 consumeValue_ = 0;
 public bool HasConsumeValue {
 get { return hasConsumeValue; }
 }
 public Int32 ConsumeValue {
 get { return consumeValue_; }
 set { SetConsumeValue(value); }
 }
 public void SetConsumeValue(Int32 value) { 
 hasConsumeValue = true;
 consumeValue_ = value;
 }

public const int isShowFieldNumber = 5;
 private bool hasIsShow;
 private Int32 isShow_ = 0;
 public bool HasIsShow {
 get { return hasIsShow; }
 }
 public Int32 IsShow {
 get { return isShow_; }
 set { SetIsShow(value); }
 }
 public void SetIsShow(Int32 value) { 
 hasIsShow = true;
 isShow_ = value;
 }

public const int idFieldNumber = 6;
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
 {
foreach (Iteminfo element in itemInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasConsumeBid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ConsumeBid);
}
 if (HasConsumeSid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ConsumeSid);
}
 if (HasConsumeValue) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ConsumeValue);
}
 if (HasIsShow) {
size += pb::CodedOutputStream.ComputeInt32Size(5, IsShow);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Id);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (Iteminfo element in itemInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasConsumeBid) {
output.WriteInt32(2, ConsumeBid);
}
 
if (HasConsumeSid) {
output.WriteInt32(3, ConsumeSid);
}
 
if (HasConsumeValue) {
output.WriteInt32(4, ConsumeValue);
}
 
if (HasIsShow) {
output.WriteInt32(5, IsShow);
}
 
if (HasId) {
output.WriteInt32(6, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 HRRewardInfo _inst = (HRRewardInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddItemInfo(subBuilder);
break;
}
   case  16: {
 _inst.ConsumeBid = input.ReadInt32();
break;
}
   case  24: {
 _inst.ConsumeSid = input.ReadInt32();
break;
}
   case  32: {
 _inst.ConsumeValue = input.ReadInt32();
break;
}
   case  40: {
 _inst.IsShow = input.ReadInt32();
break;
}
   case  48: {
 _inst.Id = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Iteminfo element in itemInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class ShowInfo : PacketDistributed
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

public const int numFieldNumber = 2;
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
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Num);
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
 
if (HasNum) {
output.WriteInt32(2, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ShowInfo _inst = (ShowInfo) _base;
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


}
