//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetCombineActivityReward : PacketDistributed
{

public const int actIdFieldNumber = 1;
 private bool hasActId;
 private Int32 actId_ = 0;
 public bool HasActId {
 get { return hasActId; }
 }
 public Int32 ActId {
 get { return actId_; }
 set { SetActId(value); }
 }
 public void SetActId(Int32 value) { 
 hasActId = true;
 actId_ = value;
 }

public const int idFieldNumber = 2;
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
  if (HasActId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActId);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Id);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActId) {
output.WriteInt32(1, ActId);
}
 
if (HasId) {
output.WriteInt32(2, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetCombineActivityReward _inst = (CGGetCombineActivityReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActId = input.ReadInt32();
break;
}
   case  16: {
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
public class CombineActivity : PacketDistributed
{

public const int actIdFieldNumber = 1;
 private bool hasActId;
 private Int32 actId_ = 0;
 public bool HasActId {
 get { return hasActId; }
 }
 public Int32 ActId {
 get { return actId_; }
 set { SetActId(value); }
 }
 public void SetActId(Int32 value) { 
 hasActId = true;
 actId_ = value;
 }

public const int infoListFieldNumber = 2;
 private pbc::PopsicleList<CombineActivityInfo> infoList_ = new pbc::PopsicleList<CombineActivityInfo>();
 public scg::IList<CombineActivityInfo> infoListList {
 get { return pbc::Lists.AsReadOnly(infoList_); }
 }
 
 public int infoListCount {
 get { return infoList_.Count; }
 }
 
public CombineActivityInfo GetInfoList(int index) {
 return infoList_[index];
 }
 public void AddInfoList(CombineActivityInfo value) {
 infoList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActId);
}
{
foreach (CombineActivityInfo element in infoListList) {
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
  
if (HasActId) {
output.WriteInt32(1, ActId);
}

do{
foreach (CombineActivityInfo element in infoListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CombineActivity _inst = (CombineActivity) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActId = input.ReadInt32();
break;
}
    case  18: {
CombineActivityInfo subBuilder =  new CombineActivityInfo();
input.ReadMessage(subBuilder);
_inst.AddInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CombineActivityInfo element in infoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CombineActivityBuyItem : PacketDistributed
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

public const int descFieldNumber = 2;
 private bool hasDesc;
 private string desc_ = "";
 public bool HasDesc {
 get { return hasDesc; }
 }
 public string Desc {
 get { return desc_; }
 set { SetDesc(value); }
 }
 public void SetDesc(string value) { 
 hasDesc = true;
 desc_ = value;
 }

public const int rewardInfoFieldNumber = 3;
 private bool hasRewardInfo;
 private string rewardInfo_ = "";
 public bool HasRewardInfo {
 get { return hasRewardInfo; }
 }
 public string RewardInfo {
 get { return rewardInfo_; }
 set { SetRewardInfo(value); }
 }
 public void SetRewardInfo(string value) { 
 hasRewardInfo = true;
 rewardInfo_ = value;
 }

public const int needMoneyFieldNumber = 4;
 private bool hasNeedMoney;
 private string needMoney_ = "";
 public bool HasNeedMoney {
 get { return hasNeedMoney; }
 }
 public string NeedMoney {
 get { return needMoney_; }
 set { SetNeedMoney(value); }
 }
 public void SetNeedMoney(string value) { 
 hasNeedMoney = true;
 needMoney_ = value;
 }

public const int getTimesFieldNumber = 5;
 private bool hasGetTimes;
 private Int32 getTimes_ = 0;
 public bool HasGetTimes {
 get { return hasGetTimes; }
 }
 public Int32 GetTimes {
 get { return getTimes_; }
 set { SetGetTimes(value); }
 }
 public void SetGetTimes(Int32 value) { 
 hasGetTimes = true;
 getTimes_ = value;
 }

public const int getTimesLimitFieldNumber = 6;
 private bool hasGetTimesLimit;
 private Int32 getTimesLimit_ = 0;
 public bool HasGetTimesLimit {
 get { return hasGetTimesLimit; }
 }
 public Int32 GetTimesLimit {
 get { return getTimesLimit_; }
 set { SetGetTimesLimit(value); }
 }
 public void SetGetTimesLimit(Int32 value) { 
 hasGetTimesLimit = true;
 getTimesLimit_ = value;
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
 if (HasDesc) {
size += pb::CodedOutputStream.ComputeStringSize(2, Desc);
}
 if (HasRewardInfo) {
size += pb::CodedOutputStream.ComputeStringSize(3, RewardInfo);
}
 if (HasNeedMoney) {
size += pb::CodedOutputStream.ComputeStringSize(4, NeedMoney);
}
 if (HasGetTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(5, GetTimes);
}
 if (HasGetTimesLimit) {
size += pb::CodedOutputStream.ComputeInt32Size(6, GetTimesLimit);
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
 
if (HasDesc) {
output.WriteString(2, Desc);
}
 
if (HasRewardInfo) {
output.WriteString(3, RewardInfo);
}
 
if (HasNeedMoney) {
output.WriteString(4, NeedMoney);
}
 
if (HasGetTimes) {
output.WriteInt32(5, GetTimes);
}
 
if (HasGetTimesLimit) {
output.WriteInt32(6, GetTimesLimit);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CombineActivityBuyItem _inst = (CombineActivityBuyItem) _base;
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
 _inst.Desc = input.ReadString();
break;
}
   case  26: {
 _inst.RewardInfo = input.ReadString();
break;
}
   case  34: {
 _inst.NeedMoney = input.ReadString();
break;
}
   case  40: {
 _inst.GetTimes = input.ReadInt32();
break;
}
   case  48: {
 _inst.GetTimesLimit = input.ReadInt32();
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
public class CombineActivityExchangeItem : PacketDistributed
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

public const int descFieldNumber = 2;
 private bool hasDesc;
 private string desc_ = "";
 public bool HasDesc {
 get { return hasDesc; }
 }
 public string Desc {
 get { return desc_; }
 set { SetDesc(value); }
 }
 public void SetDesc(string value) { 
 hasDesc = true;
 desc_ = value;
 }

public const int rewardInfoFieldNumber = 3;
 private bool hasRewardInfo;
 private string rewardInfo_ = "";
 public bool HasRewardInfo {
 get { return hasRewardInfo; }
 }
 public string RewardInfo {
 get { return rewardInfo_; }
 set { SetRewardInfo(value); }
 }
 public void SetRewardInfo(string value) { 
 hasRewardInfo = true;
 rewardInfo_ = value;
 }

public const int needItemListFieldNumber = 4;
 private bool hasNeedItemList;
 private string needItemList_ = "";
 public bool HasNeedItemList {
 get { return hasNeedItemList; }
 }
 public string NeedItemList {
 get { return needItemList_; }
 set { SetNeedItemList(value); }
 }
 public void SetNeedItemList(string value) { 
 hasNeedItemList = true;
 needItemList_ = value;
 }

public const int getTimesFieldNumber = 5;
 private bool hasGetTimes;
 private Int32 getTimes_ = 0;
 public bool HasGetTimes {
 get { return hasGetTimes; }
 }
 public Int32 GetTimes {
 get { return getTimes_; }
 set { SetGetTimes(value); }
 }
 public void SetGetTimes(Int32 value) { 
 hasGetTimes = true;
 getTimes_ = value;
 }

public const int getTimesLimitFieldNumber = 6;
 private bool hasGetTimesLimit;
 private Int32 getTimesLimit_ = 0;
 public bool HasGetTimesLimit {
 get { return hasGetTimesLimit; }
 }
 public Int32 GetTimesLimit {
 get { return getTimesLimit_; }
 set { SetGetTimesLimit(value); }
 }
 public void SetGetTimesLimit(Int32 value) { 
 hasGetTimesLimit = true;
 getTimesLimit_ = value;
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
 if (HasDesc) {
size += pb::CodedOutputStream.ComputeStringSize(2, Desc);
}
 if (HasRewardInfo) {
size += pb::CodedOutputStream.ComputeStringSize(3, RewardInfo);
}
 if (HasNeedItemList) {
size += pb::CodedOutputStream.ComputeStringSize(4, NeedItemList);
}
 if (HasGetTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(5, GetTimes);
}
 if (HasGetTimesLimit) {
size += pb::CodedOutputStream.ComputeInt32Size(6, GetTimesLimit);
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
 
if (HasDesc) {
output.WriteString(2, Desc);
}
 
if (HasRewardInfo) {
output.WriteString(3, RewardInfo);
}
 
if (HasNeedItemList) {
output.WriteString(4, NeedItemList);
}
 
if (HasGetTimes) {
output.WriteInt32(5, GetTimes);
}
 
if (HasGetTimesLimit) {
output.WriteInt32(6, GetTimesLimit);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CombineActivityExchangeItem _inst = (CombineActivityExchangeItem) _base;
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
 _inst.Desc = input.ReadString();
break;
}
   case  26: {
 _inst.RewardInfo = input.ReadString();
break;
}
   case  34: {
 _inst.NeedItemList = input.ReadString();
break;
}
   case  40: {
 _inst.GetTimes = input.ReadInt32();
break;
}
   case  48: {
 _inst.GetTimesLimit = input.ReadInt32();
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
public class CombineActivityInfo : PacketDistributed
{

public const int actIdFieldNumber = 1;
 private bool hasActId;
 private Int32 actId_ = 0;
 public bool HasActId {
 get { return hasActId; }
 }
 public Int32 ActId {
 get { return actId_; }
 set { SetActId(value); }
 }
 public void SetActId(Int32 value) { 
 hasActId = true;
 actId_ = value;
 }

public const int nameFieldNumber = 2;
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

public const int tabidFieldNumber = 3;
 private bool hasTabid;
 private Int32 tabid_ = 0;
 public bool HasTabid {
 get { return hasTabid; }
 }
 public Int32 Tabid {
 get { return tabid_; }
 set { SetTabid(value); }
 }
 public void SetTabid(Int32 value) { 
 hasTabid = true;
 tabid_ = value;
 }

public const int tabimgFieldNumber = 4;
 private bool hasTabimg;
 private string tabimg_ = "";
 public bool HasTabimg {
 get { return hasTabimg; }
 }
 public string Tabimg {
 get { return tabimg_; }
 set { SetTabimg(value); }
 }
 public void SetTabimg(string value) { 
 hasTabimg = true;
 tabimg_ = value;
 }

public const int tabDescFieldNumber = 5;
 private bool hasTabDesc;
 private string tabDesc_ = "";
 public bool HasTabDesc {
 get { return hasTabDesc; }
 }
 public string TabDesc {
 get { return tabDesc_; }
 set { SetTabDesc(value); }
 }
 public void SetTabDesc(string value) { 
 hasTabDesc = true;
 tabDesc_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasTabid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Tabid);
}
 if (HasTabimg) {
size += pb::CodedOutputStream.ComputeStringSize(4, Tabimg);
}
 if (HasTabDesc) {
size += pb::CodedOutputStream.ComputeStringSize(5, TabDesc);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActId) {
output.WriteInt32(1, ActId);
}
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasTabid) {
output.WriteInt32(3, Tabid);
}
 
if (HasTabimg) {
output.WriteString(4, Tabimg);
}
 
if (HasTabDesc) {
output.WriteString(5, TabDesc);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CombineActivityInfo _inst = (CombineActivityInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActId = input.ReadInt32();
break;
}
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.Tabid = input.ReadInt32();
break;
}
   case  34: {
 _inst.Tabimg = input.ReadString();
break;
}
   case  42: {
 _inst.TabDesc = input.ReadString();
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
public class CombineActivityListItem : PacketDistributed
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

public const int descFieldNumber = 2;
 private bool hasDesc;
 private string desc_ = "";
 public bool HasDesc {
 get { return hasDesc; }
 }
 public string Desc {
 get { return desc_; }
 set { SetDesc(value); }
 }
 public void SetDesc(string value) { 
 hasDesc = true;
 desc_ = value;
 }

public const int rewardInfoFieldNumber = 3;
 private bool hasRewardInfo;
 private string rewardInfo_ = "";
 public bool HasRewardInfo {
 get { return hasRewardInfo; }
 }
 public string RewardInfo {
 get { return rewardInfo_; }
 set { SetRewardInfo(value); }
 }
 public void SetRewardInfo(string value) { 
 hasRewardInfo = true;
 rewardInfo_ = value;
 }

public const int progressTextFieldNumber = 4;
 private bool hasProgressText;
 private string progressText_ = "";
 public bool HasProgressText {
 get { return hasProgressText; }
 }
 public string ProgressText {
 get { return progressText_; }
 set { SetProgressText(value); }
 }
 public void SetProgressText(string value) { 
 hasProgressText = true;
 progressText_ = value;
 }

public const int curValueFieldNumber = 5;
 private bool hasCurValue;
 private Int32 curValue_ = 0;
 public bool HasCurValue {
 get { return hasCurValue; }
 }
 public Int32 CurValue {
 get { return curValue_; }
 set { SetCurValue(value); }
 }
 public void SetCurValue(Int32 value) { 
 hasCurValue = true;
 curValue_ = value;
 }

public const int needValueFieldNumber = 6;
 private bool hasNeedValue;
 private Int32 needValue_ = 0;
 public bool HasNeedValue {
 get { return hasNeedValue; }
 }
 public Int32 NeedValue {
 get { return needValue_; }
 set { SetNeedValue(value); }
 }
 public void SetNeedValue(Int32 value) { 
 hasNeedValue = true;
 needValue_ = value;
 }

public const int getTimesFieldNumber = 7;
 private bool hasGetTimes;
 private Int32 getTimes_ = 0;
 public bool HasGetTimes {
 get { return hasGetTimes; }
 }
 public Int32 GetTimes {
 get { return getTimes_; }
 set { SetGetTimes(value); }
 }
 public void SetGetTimes(Int32 value) { 
 hasGetTimes = true;
 getTimes_ = value;
 }

public const int getTimesLimitFieldNumber = 8;
 private bool hasGetTimesLimit;
 private Int32 getTimesLimit_ = 0;
 public bool HasGetTimesLimit {
 get { return hasGetTimesLimit; }
 }
 public Int32 GetTimesLimit {
 get { return getTimesLimit_; }
 set { SetGetTimesLimit(value); }
 }
 public void SetGetTimesLimit(Int32 value) { 
 hasGetTimesLimit = true;
 getTimesLimit_ = value;
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
 if (HasDesc) {
size += pb::CodedOutputStream.ComputeStringSize(2, Desc);
}
 if (HasRewardInfo) {
size += pb::CodedOutputStream.ComputeStringSize(3, RewardInfo);
}
 if (HasProgressText) {
size += pb::CodedOutputStream.ComputeStringSize(4, ProgressText);
}
 if (HasCurValue) {
size += pb::CodedOutputStream.ComputeInt32Size(5, CurValue);
}
 if (HasNeedValue) {
size += pb::CodedOutputStream.ComputeInt32Size(6, NeedValue);
}
 if (HasGetTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(7, GetTimes);
}
 if (HasGetTimesLimit) {
size += pb::CodedOutputStream.ComputeInt32Size(8, GetTimesLimit);
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
 
if (HasDesc) {
output.WriteString(2, Desc);
}
 
if (HasRewardInfo) {
output.WriteString(3, RewardInfo);
}
 
if (HasProgressText) {
output.WriteString(4, ProgressText);
}
 
if (HasCurValue) {
output.WriteInt32(5, CurValue);
}
 
if (HasNeedValue) {
output.WriteInt32(6, NeedValue);
}
 
if (HasGetTimes) {
output.WriteInt32(7, GetTimes);
}
 
if (HasGetTimesLimit) {
output.WriteInt32(8, GetTimesLimit);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CombineActivityListItem _inst = (CombineActivityListItem) _base;
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
 _inst.Desc = input.ReadString();
break;
}
   case  26: {
 _inst.RewardInfo = input.ReadString();
break;
}
   case  34: {
 _inst.ProgressText = input.ReadString();
break;
}
   case  40: {
 _inst.CurValue = input.ReadInt32();
break;
}
   case  48: {
 _inst.NeedValue = input.ReadInt32();
break;
}
   case  56: {
 _inst.GetTimes = input.ReadInt32();
break;
}
   case  64: {
 _inst.GetTimesLimit = input.ReadInt32();
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
public class GCCombineActivityItemUpdate : PacketDistributed
{

public const int actIdFieldNumber = 1;
 private bool hasActId;
 private Int32 actId_ = 0;
 public bool HasActId {
 get { return hasActId; }
 }
 public Int32 ActId {
 get { return actId_; }
 set { SetActId(value); }
 }
 public void SetActId(Int32 value) { 
 hasActId = true;
 actId_ = value;
 }

public const int operateFieldNumber = 2;
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

public const int listItemsFieldNumber = 3;
 private pbc::PopsicleList<CombineActivityListItem> listItems_ = new pbc::PopsicleList<CombineActivityListItem>();
 public scg::IList<CombineActivityListItem> listItemsList {
 get { return pbc::Lists.AsReadOnly(listItems_); }
 }
 
 public int listItemsCount {
 get { return listItems_.Count; }
 }
 
public CombineActivityListItem GetListItems(int index) {
 return listItems_[index];
 }
 public void AddListItems(CombineActivityListItem value) {
 listItems_.Add(value);
 }

public const int exchangeItemsFieldNumber = 4;
 private pbc::PopsicleList<CombineActivityExchangeItem> exchangeItems_ = new pbc::PopsicleList<CombineActivityExchangeItem>();
 public scg::IList<CombineActivityExchangeItem> exchangeItemsList {
 get { return pbc::Lists.AsReadOnly(exchangeItems_); }
 }
 
 public int exchangeItemsCount {
 get { return exchangeItems_.Count; }
 }
 
public CombineActivityExchangeItem GetExchangeItems(int index) {
 return exchangeItems_[index];
 }
 public void AddExchangeItems(CombineActivityExchangeItem value) {
 exchangeItems_.Add(value);
 }

public const int buyItemsFieldNumber = 5;
 private pbc::PopsicleList<CombineActivityBuyItem> buyItems_ = new pbc::PopsicleList<CombineActivityBuyItem>();
 public scg::IList<CombineActivityBuyItem> buyItemsList {
 get { return pbc::Lists.AsReadOnly(buyItems_); }
 }
 
 public int buyItemsCount {
 get { return buyItems_.Count; }
 }
 
public CombineActivityBuyItem GetBuyItems(int index) {
 return buyItems_[index];
 }
 public void AddBuyItems(CombineActivityBuyItem value) {
 buyItems_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActId);
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
{
foreach (CombineActivityListItem element in listItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (CombineActivityExchangeItem element in exchangeItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (CombineActivityBuyItem element in buyItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActId) {
output.WriteInt32(1, ActId);
}
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}

do{
foreach (CombineActivityListItem element in listItemsList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (CombineActivityExchangeItem element in exchangeItemsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (CombineActivityBuyItem element in buyItemsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCombineActivityItemUpdate _inst = (GCCombineActivityItemUpdate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Operate = input.ReadInt32();
break;
}
    case  26: {
CombineActivityListItem subBuilder =  new CombineActivityListItem();
input.ReadMessage(subBuilder);
_inst.AddListItems(subBuilder);
break;
}
    case  34: {
CombineActivityExchangeItem subBuilder =  new CombineActivityExchangeItem();
input.ReadMessage(subBuilder);
_inst.AddExchangeItems(subBuilder);
break;
}
    case  42: {
CombineActivityBuyItem subBuilder =  new CombineActivityBuyItem();
input.ReadMessage(subBuilder);
_inst.AddBuyItems(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CombineActivityListItem element in listItemsList) {
if (!element.IsInitialized()) return false;
}
foreach (CombineActivityExchangeItem element in exchangeItemsList) {
if (!element.IsInitialized()) return false;
}
foreach (CombineActivityBuyItem element in buyItemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCombineActivityList : PacketDistributed
{

public const int activityListFieldNumber = 1;
 private pbc::PopsicleList<CombineActivity> activityList_ = new pbc::PopsicleList<CombineActivity>();
 public scg::IList<CombineActivity> activityListList {
 get { return pbc::Lists.AsReadOnly(activityList_); }
 }
 
 public int activityListCount {
 get { return activityList_.Count; }
 }
 
public CombineActivity GetActivityList(int index) {
 return activityList_[index];
 }
 public void AddActivityList(CombineActivity value) {
 activityList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (CombineActivity element in activityListList) {
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
foreach (CombineActivity element in activityListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCombineActivityList _inst = (GCCombineActivityList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CombineActivity subBuilder =  new CombineActivity();
input.ReadMessage(subBuilder);
_inst.AddActivityList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CombineActivity element in activityListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetCombineActivityRewardBack : PacketDistributed
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

public const int actIdFieldNumber = 2;
 private bool hasActId;
 private Int32 actId_ = 0;
 public bool HasActId {
 get { return hasActId; }
 }
 public Int32 ActId {
 get { return actId_; }
 set { SetActId(value); }
 }
 public void SetActId(Int32 value) { 
 hasActId = true;
 actId_ = value;
 }

public const int idFieldNumber = 3;
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

public const int getTimesFieldNumber = 4;
 private bool hasGetTimes;
 private Int32 getTimes_ = 0;
 public bool HasGetTimes {
 get { return hasGetTimes; }
 }
 public Int32 GetTimes {
 get { return getTimes_; }
 set { SetGetTimes(value); }
 }
 public void SetGetTimes(Int32 value) { 
 hasGetTimes = true;
 getTimes_ = value;
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
 if (HasActId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ActId);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Id);
}
 if (HasGetTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GetTimes);
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
 
if (HasActId) {
output.WriteInt32(2, ActId);
}
 
if (HasId) {
output.WriteInt32(3, Id);
}
 
if (HasGetTimes) {
output.WriteInt32(4, GetTimes);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetCombineActivityRewardBack _inst = (GCGetCombineActivityRewardBack) _base;
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
 _inst.ActId = input.ReadInt32();
break;
}
   case  24: {
 _inst.Id = input.ReadInt32();
break;
}
   case  32: {
 _inst.GetTimes = input.ReadInt32();
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
