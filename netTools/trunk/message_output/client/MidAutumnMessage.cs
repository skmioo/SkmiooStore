//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGMidAutumn : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TargetID);
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
 
if (HasTargetID) {
output.WriteInt32(2, TargetID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGMidAutumn _inst = (CGMidAutumn) _base;
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
   case  16: {
 _inst.TargetID = input.ReadInt32();
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
public class GCMidAutumn : PacketDistributed
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

public const int targetsFieldNumber = 2;
 private pbc::PopsicleList<MidaTargetInfo> targets_ = new pbc::PopsicleList<MidaTargetInfo>();
 public scg::IList<MidaTargetInfo> targetsList {
 get { return pbc::Lists.AsReadOnly(targets_); }
 }
 
 public int targetsCount {
 get { return targets_.Count; }
 }
 
public MidaTargetInfo GetTargets(int index) {
 return targets_[index];
 }
 public void AddTargets(MidaTargetInfo value) {
 targets_.Add(value);
 }

public const int clientInfoFieldNumber = 3;
 private bool hasClientInfo;
 private MidaClientInfo clientInfo_ =  new MidaClientInfo();
 public bool HasClientInfo {
 get { return hasClientInfo; }
 }
 public MidaClientInfo ClientInfo {
 get { return clientInfo_; }
 set { SetClientInfo(value); }
 }
 public void SetClientInfo(MidaClientInfo value) { 
 hasClientInfo = true;
 clientInfo_ = value;
 }

public const int resultFieldNumber = 4;
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

public const int versionFieldNumber = 5;
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

public const int activityIdFieldNumber = 6;
 private bool hasActivityId;
 private Int32 activityId_ = 0;
 public bool HasActivityId {
 get { return hasActivityId; }
 }
 public Int32 ActivityId {
 get { return activityId_; }
 set { SetActivityId(value); }
 }
 public void SetActivityId(Int32 value) { 
 hasActivityId = true;
 activityId_ = value;
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
foreach (MidaTargetInfo element in targetsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = ClientInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Result);
}
 if (HasVersion) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Version);
}
 if (HasActivityId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ActivityId);
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

do{
foreach (MidaTargetInfo element in targetsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ClientInfo.SerializedSize());
ClientInfo.WriteTo(output);

}
 
if (HasResult) {
output.WriteInt32(4, Result);
}
 
if (HasVersion) {
output.WriteInt32(5, Version);
}
 
if (HasActivityId) {
output.WriteInt32(6, ActivityId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMidAutumn _inst = (GCMidAutumn) _base;
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
MidaTargetInfo subBuilder =  new MidaTargetInfo();
input.ReadMessage(subBuilder);
_inst.AddTargets(subBuilder);
break;
}
    case  26: {
MidaClientInfo subBuilder =  new MidaClientInfo();
 input.ReadMessage(subBuilder);
_inst.ClientInfo = subBuilder;
break;
}
   case  32: {
 _inst.Result = input.ReadInt32();
break;
}
   case  40: {
 _inst.Version = input.ReadInt32();
break;
}
   case  48: {
 _inst.ActivityId = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (MidaTargetInfo element in targetsList) {
if (!element.IsInitialized()) return false;
}
  if (HasClientInfo) {
if (!ClientInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class MidaClientInfo : PacketDistributed
{

public const int modelFieldNumber = 1;
 private bool hasModel;
 private Int32 model_ = 0;
 public bool HasModel {
 get { return hasModel; }
 }
 public Int32 Model {
 get { return model_; }
 set { SetModel(value); }
 }
 public void SetModel(Int32 value) { 
 hasModel = true;
 model_ = value;
 }

public const int scaleFieldNumber = 2;
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

public const int rotateFieldNumber = 3;
 private bool hasRotate;
 private string rotate_ = "";
 public bool HasRotate {
 get { return hasRotate; }
 }
 public string Rotate {
 get { return rotate_; }
 set { SetRotate(value); }
 }
 public void SetRotate(string value) { 
 hasRotate = true;
 rotate_ = value;
 }

public const int positionFieldNumber = 4;
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

public const int titleFieldNumber = 5;
 private bool hasTitle;
 private Int32 title_ = 0;
 public bool HasTitle {
 get { return hasTitle; }
 }
 public Int32 Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(Int32 value) { 
 hasTitle = true;
 title_ = value;
 }

public const int startTimeFieldNumber = 6;
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

public const int endTimeFieldNumber = 7;
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

public const int itemsFieldNumber = 8;
 private pbc::PopsicleList<Iteminfo> items_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> itemsList {
 get { return pbc::Lists.AsReadOnly(items_); }
 }
 
 public int itemsCount {
 get { return items_.Count; }
 }
 
public Iteminfo GetItems(int index) {
 return items_[index];
 }
 public void AddItems(Iteminfo value) {
 items_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasModel) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Model);
}
 if (HasScale) {
size += pb::CodedOutputStream.ComputeStringSize(2, Scale);
}
 if (HasRotate) {
size += pb::CodedOutputStream.ComputeStringSize(3, Rotate);
}
 if (HasPosition) {
size += pb::CodedOutputStream.ComputeStringSize(4, Position);
}
 if (HasTitle) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Title);
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, StartTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, EndTime);
}
{
foreach (Iteminfo element in itemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasModel) {
output.WriteInt32(1, Model);
}
 
if (HasScale) {
output.WriteString(2, Scale);
}
 
if (HasRotate) {
output.WriteString(3, Rotate);
}
 
if (HasPosition) {
output.WriteString(4, Position);
}
 
if (HasTitle) {
output.WriteInt32(5, Title);
}
 
if (HasStartTime) {
output.WriteInt64(6, StartTime);
}
 
if (HasEndTime) {
output.WriteInt64(7, EndTime);
}

do{
foreach (Iteminfo element in itemsList) {
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MidaClientInfo _inst = (MidaClientInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Model = input.ReadInt32();
break;
}
   case  18: {
 _inst.Scale = input.ReadString();
break;
}
   case  26: {
 _inst.Rotate = input.ReadString();
break;
}
   case  34: {
 _inst.Position = input.ReadString();
break;
}
   case  40: {
 _inst.Title = input.ReadInt32();
break;
}
   case  48: {
 _inst.StartTime = input.ReadInt64();
break;
}
   case  56: {
 _inst.EndTime = input.ReadInt64();
break;
}
    case  66: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddItems(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Iteminfo element in itemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class MidaTargetInfo : PacketDistributed
{

public const int itemInfoFieldNumber = 1;
 private bool hasItemInfo;
 private Iteminfo itemInfo_ =  new Iteminfo();
 public bool HasItemInfo {
 get { return hasItemInfo; }
 }
 public Iteminfo ItemInfo {
 get { return itemInfo_; }
 set { SetItemInfo(value); }
 }
 public void SetItemInfo(Iteminfo value) { 
 hasItemInfo = true;
 itemInfo_ = value;
 }

public const int currencyFieldNumber = 2;
 private bool hasCurrency;
 private Int32 currency_ = 0;
 public bool HasCurrency {
 get { return hasCurrency; }
 }
 public Int32 Currency {
 get { return currency_; }
 set { SetCurrency(value); }
 }
 public void SetCurrency(Int32 value) { 
 hasCurrency = true;
 currency_ = value;
 }

public const int consumeValueFieldNumber = 3;
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

public const int isShowFieldNumber = 4;
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

public const int vipLevelFieldNumber = 5;
 private bool hasVipLevel;
 private Int32 vipLevel_ = 0;
 public bool HasVipLevel {
 get { return hasVipLevel; }
 }
 public Int32 VipLevel {
 get { return vipLevel_; }
 set { SetVipLevel(value); }
 }
 public void SetVipLevel(Int32 value) { 
 hasVipLevel = true;
 vipLevel_ = value;
 }

public const int freeNunFieldNumber = 6;
 private bool hasFreeNun;
 private Int32 freeNun_ = 0;
 public bool HasFreeNun {
 get { return hasFreeNun; }
 }
 public Int32 FreeNun {
 get { return freeNun_; }
 set { SetFreeNun(value); }
 }
 public void SetFreeNun(Int32 value) { 
 hasFreeNun = true;
 freeNun_ = value;
 }

public const int maxNunFieldNumber = 7;
 private bool hasMaxNun;
 private Int32 maxNun_ = 0;
 public bool HasMaxNun {
 get { return hasMaxNun; }
 }
 public Int32 MaxNun {
 get { return maxNun_; }
 set { SetMaxNun(value); }
 }
 public void SetMaxNun(Int32 value) { 
 hasMaxNun = true;
 maxNun_ = value;
 }

public const int idFieldNumber = 8;
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

public const int currency2FieldNumber = 9;
 private bool hasCurrency2;
 private Int32 currency2_ = 0;
 public bool HasCurrency2 {
 get { return hasCurrency2; }
 }
 public Int32 Currency2 {
 get { return currency2_; }
 set { SetCurrency2(value); }
 }
 public void SetCurrency2(Int32 value) { 
 hasCurrency2 = true;
 currency2_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = ItemInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasCurrency) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Currency);
}
 if (HasConsumeValue) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ConsumeValue);
}
 if (HasIsShow) {
size += pb::CodedOutputStream.ComputeInt32Size(4, IsShow);
}
 if (HasVipLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(5, VipLevel);
}
 if (HasFreeNun) {
size += pb::CodedOutputStream.ComputeInt32Size(6, FreeNun);
}
 if (HasMaxNun) {
size += pb::CodedOutputStream.ComputeInt32Size(7, MaxNun);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Id);
}
 if (HasCurrency2) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Currency2);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
ItemInfo.WriteTo(output);

}
 
if (HasCurrency) {
output.WriteInt32(2, Currency);
}
 
if (HasConsumeValue) {
output.WriteInt32(3, ConsumeValue);
}
 
if (HasIsShow) {
output.WriteInt32(4, IsShow);
}
 
if (HasVipLevel) {
output.WriteInt32(5, VipLevel);
}
 
if (HasFreeNun) {
output.WriteInt32(6, FreeNun);
}
 
if (HasMaxNun) {
output.WriteInt32(7, MaxNun);
}
 
if (HasId) {
output.WriteInt32(8, Id);
}
 
if (HasCurrency2) {
output.WriteInt32(9, Currency2);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MidaTargetInfo _inst = (MidaTargetInfo) _base;
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
_inst.ItemInfo = subBuilder;
break;
}
   case  16: {
 _inst.Currency = input.ReadInt32();
break;
}
   case  24: {
 _inst.ConsumeValue = input.ReadInt32();
break;
}
   case  32: {
 _inst.IsShow = input.ReadInt32();
break;
}
   case  40: {
 _inst.VipLevel = input.ReadInt32();
break;
}
   case  48: {
 _inst.FreeNun = input.ReadInt32();
break;
}
   case  56: {
 _inst.MaxNun = input.ReadInt32();
break;
}
   case  64: {
 _inst.Id = input.ReadInt32();
break;
}
   case  72: {
 _inst.Currency2 = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasItemInfo) {
if (!ItemInfo.IsInitialized()) return false;
}
 return true;
 }

	}


}
