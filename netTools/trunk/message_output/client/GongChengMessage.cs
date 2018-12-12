//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBeforeDonateStick : PacketDistributed
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
 CGBeforeDonateStick _inst = (CGBeforeDonateStick) _base;
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
public class CGDonateStick : PacketDistributed
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
 CGDonateStick _inst = (CGDonateStick) _base;
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
public class CGEnterGongCheng : PacketDistributed
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
 CGEnterGongCheng _inst = (CGEnterGongCheng) _base;
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
public class CGGongChengCanStatue : PacketDistributed
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
 CGGongChengCanStatue _inst = (CGGongChengCanStatue) _base;
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
public class CGGongChengGetStatueAward : PacketDistributed
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
 CGGongChengGetStatueAward _inst = (CGGongChengGetStatueAward) _base;
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
public class CGGongChengLeave : PacketDistributed
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
 CGGongChengLeave _inst = (CGGongChengLeave) _base;
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
public class CGGongChengReceiveAward : PacketDistributed
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
 CGGongChengReceiveAward _inst = (CGGongChengReceiveAward) _base;
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
public class CGOpenGongChengUI : PacketDistributed
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
 CGOpenGongChengUI _inst = (CGOpenGongChengUI) _base;
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
public class GCBeforeDonateStick : PacketDistributed
{

public const int moneyFieldNumber = 1;
 private bool hasMoney;
 private Int32 money_ = 0;
 public bool HasMoney {
 get { return hasMoney; }
 }
 public Int32 Money {
 get { return money_; }
 set { SetMoney(value); }
 }
 public void SetMoney(Int32 value) { 
 hasMoney = true;
 money_ = value;
 }

public const int percentFieldNumber = 2;
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

public const int canNextFieldNumber = 3;
 private bool hasCanNext;
 private Int32 canNext_ = 0;
 public bool HasCanNext {
 get { return hasCanNext; }
 }
 public Int32 CanNext {
 get { return canNext_; }
 set { SetCanNext(value); }
 }
 public void SetCanNext(Int32 value) { 
 hasCanNext = true;
 canNext_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Money);
}
 if (HasPercent) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Percent);
}
 if (HasCanNext) {
size += pb::CodedOutputStream.ComputeInt32Size(3, CanNext);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMoney) {
output.WriteInt32(1, Money);
}
 
if (HasPercent) {
output.WriteInt32(2, Percent);
}
 
if (HasCanNext) {
output.WriteInt32(3, CanNext);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBeforeDonateStick _inst = (GCBeforeDonateStick) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Money = input.ReadInt32();
break;
}
   case  16: {
 _inst.Percent = input.ReadInt32();
break;
}
   case  24: {
 _inst.CanNext = input.ReadInt32();
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
public class GCDonateStick : PacketDistributed
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
 GCDonateStick _inst = (GCDonateStick) _base;
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
public class GCDoorHurtPercent : PacketDistributed
{

public const int gangHurtInfoFieldNumber = 1;
 private pbc::PopsicleList<GongChengDoorInfo> gangHurtInfo_ = new pbc::PopsicleList<GongChengDoorInfo>();
 public scg::IList<GongChengDoorInfo> gangHurtInfoList {
 get { return pbc::Lists.AsReadOnly(gangHurtInfo_); }
 }
 
 public int gangHurtInfoCount {
 get { return gangHurtInfo_.Count; }
 }
 
public GongChengDoorInfo GetGangHurtInfo(int index) {
 return gangHurtInfo_[index];
 }
 public void AddGangHurtInfo(GongChengDoorInfo value) {
 gangHurtInfo_.Add(value);
 }

public const int selfGangHurtInfoFieldNumber = 2;
 private bool hasSelfGangHurtInfo;
 private GongChengDoorInfo selfGangHurtInfo_ =  new GongChengDoorInfo();
 public bool HasSelfGangHurtInfo {
 get { return hasSelfGangHurtInfo; }
 }
 public GongChengDoorInfo SelfGangHurtInfo {
 get { return selfGangHurtInfo_; }
 set { SetSelfGangHurtInfo(value); }
 }
 public void SetSelfGangHurtInfo(GongChengDoorInfo value) { 
 hasSelfGangHurtInfo = true;
 selfGangHurtInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GongChengDoorInfo element in gangHurtInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = SelfGangHurtInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (GongChengDoorInfo element in gangHurtInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SelfGangHurtInfo.SerializedSize());
SelfGangHurtInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDoorHurtPercent _inst = (GCDoorHurtPercent) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GongChengDoorInfo subBuilder =  new GongChengDoorInfo();
input.ReadMessage(subBuilder);
_inst.AddGangHurtInfo(subBuilder);
break;
}
    case  18: {
GongChengDoorInfo subBuilder =  new GongChengDoorInfo();
 input.ReadMessage(subBuilder);
_inst.SelfGangHurtInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GongChengDoorInfo element in gangHurtInfoList) {
if (!element.IsInitialized()) return false;
}
  if (HasSelfGangHurtInfo) {
if (!SelfGangHurtInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDoorScore : PacketDistributed
{

public const int gangScoreInfoFieldNumber = 1;
 private pbc::PopsicleList<GongChengDoorInfo> gangScoreInfo_ = new pbc::PopsicleList<GongChengDoorInfo>();
 public scg::IList<GongChengDoorInfo> gangScoreInfoList {
 get { return pbc::Lists.AsReadOnly(gangScoreInfo_); }
 }
 
 public int gangScoreInfoCount {
 get { return gangScoreInfo_.Count; }
 }
 
public GongChengDoorInfo GetGangScoreInfo(int index) {
 return gangScoreInfo_[index];
 }
 public void AddGangScoreInfo(GongChengDoorInfo value) {
 gangScoreInfo_.Add(value);
 }

public const int selfGangScoreInfoFieldNumber = 2;
 private bool hasSelfGangScoreInfo;
 private GongChengDoorInfo selfGangScoreInfo_ =  new GongChengDoorInfo();
 public bool HasSelfGangScoreInfo {
 get { return hasSelfGangScoreInfo; }
 }
 public GongChengDoorInfo SelfGangScoreInfo {
 get { return selfGangScoreInfo_; }
 set { SetSelfGangScoreInfo(value); }
 }
 public void SetSelfGangScoreInfo(GongChengDoorInfo value) { 
 hasSelfGangScoreInfo = true;
 selfGangScoreInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GongChengDoorInfo element in gangScoreInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = SelfGangScoreInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (GongChengDoorInfo element in gangScoreInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SelfGangScoreInfo.SerializedSize());
SelfGangScoreInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDoorScore _inst = (GCDoorScore) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GongChengDoorInfo subBuilder =  new GongChengDoorInfo();
input.ReadMessage(subBuilder);
_inst.AddGangScoreInfo(subBuilder);
break;
}
    case  18: {
GongChengDoorInfo subBuilder =  new GongChengDoorInfo();
 input.ReadMessage(subBuilder);
_inst.SelfGangScoreInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GongChengDoorInfo element in gangScoreInfoList) {
if (!element.IsInitialized()) return false;
}
  if (HasSelfGangScoreInfo) {
if (!SelfGangScoreInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCEnterGongCheng : PacketDistributed
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

public const int stateFieldNumber = 2;
 private bool hasState;
 private Int32 state_ = 0;
 public bool HasState {
 get { return hasState; }
 }
 public Int32 State {
 get { return state_; }
 set { SetState(value); }
 }
 public void SetState(Int32 value) { 
 hasState = true;
 state_ = value;
 }

public const int doorStateFieldNumber = 3;
 private bool hasDoorState;
 private Int32 doorState_ = 0;
 public bool HasDoorState {
 get { return hasDoorState; }
 }
 public Int32 DoorState {
 get { return doorState_; }
 set { SetDoorState(value); }
 }
 public void SetDoorState(Int32 value) { 
 hasDoorState = true;
 doorState_ = value;
 }

public const int campStateFieldNumber = 4;
 private bool hasCampState;
 private Int32 campState_ = 0;
 public bool HasCampState {
 get { return hasCampState; }
 }
 public Int32 CampState {
 get { return campState_; }
 set { SetCampState(value); }
 }
 public void SetCampState(Int32 value) { 
 hasCampState = true;
 campState_ = value;
 }

public const int restTimeFieldNumber = 5;
 private bool hasRestTime;
 private Int64 restTime_ = 0;
 public bool HasRestTime {
 get { return hasRestTime; }
 }
 public Int64 RestTime {
 get { return restTime_; }
 set { SetRestTime(value); }
 }
 public void SetRestTime(Int64 value) { 
 hasRestTime = true;
 restTime_ = value;
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
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(2, State);
}
 if (HasDoorState) {
size += pb::CodedOutputStream.ComputeInt32Size(3, DoorState);
}
 if (HasCampState) {
size += pb::CodedOutputStream.ComputeInt32Size(4, CampState);
}
 if (HasRestTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, RestTime);
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
 
if (HasState) {
output.WriteInt32(2, State);
}
 
if (HasDoorState) {
output.WriteInt32(3, DoorState);
}
 
if (HasCampState) {
output.WriteInt32(4, CampState);
}
 
if (HasRestTime) {
output.WriteInt64(5, RestTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEnterGongCheng _inst = (GCEnterGongCheng) _base;
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
 _inst.State = input.ReadInt32();
break;
}
   case  24: {
 _inst.DoorState = input.ReadInt32();
break;
}
   case  32: {
 _inst.CampState = input.ReadInt32();
break;
}
   case  40: {
 _inst.RestTime = input.ReadInt64();
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
public class GCGongChengCanStatue : PacketDistributed
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

public const int canGetFieldNumber = 2;
 private bool hasCanGet;
 private Int32 canGet_ = 0;
 public bool HasCanGet {
 get { return hasCanGet; }
 }
 public Int32 CanGet {
 get { return canGet_; }
 set { SetCanGet(value); }
 }
 public void SetCanGet(Int32 value) { 
 hasCanGet = true;
 canGet_ = value;
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
 if (HasCanGet) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CanGet);
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
 
if (HasCanGet) {
output.WriteInt32(2, CanGet);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongChengCanStatue _inst = (GCGongChengCanStatue) _base;
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
 _inst.CanGet = input.ReadInt32();
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
public class GCGongChengChangeSchedule : PacketDistributed
{

public const int stateFieldNumber = 2;
 private bool hasState;
 private Int32 state_ = 0;
 public bool HasState {
 get { return hasState; }
 }
 public Int32 State {
 get { return state_; }
 set { SetState(value); }
 }
 public void SetState(Int32 value) { 
 hasState = true;
 state_ = value;
 }

public const int restTimeFieldNumber = 5;
 private bool hasRestTime;
 private Int64 restTime_ = 0;
 public bool HasRestTime {
 get { return hasRestTime; }
 }
 public Int64 RestTime {
 get { return restTime_; }
 set { SetRestTime(value); }
 }
 public void SetRestTime(Int64 value) { 
 hasRestTime = true;
 restTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(2, State);
}
 if (HasRestTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, RestTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasState) {
output.WriteInt32(2, State);
}
 
if (HasRestTime) {
output.WriteInt64(5, RestTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongChengChangeSchedule _inst = (GCGongChengChangeSchedule) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  16: {
 _inst.State = input.ReadInt32();
break;
}
   case  40: {
 _inst.RestTime = input.ReadInt64();
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
public class GCGongChengGetStatueAward : PacketDistributed
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
 GCGongChengGetStatueAward _inst = (GCGongChengGetStatueAward) _base;
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
public class GCGongChengLeader : PacketDistributed
{

public const int flagFieldNumber = 1;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongChengLeader _inst = (GCGongChengLeader) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
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
public class GCGongChengLeave : PacketDistributed
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
 GCGongChengLeave _inst = (GCGongChengLeave) _base;
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
public class GCGongChengLeaveTime : PacketDistributed
{

public const int leaveTimeFieldNumber = 1;
 private bool hasLeaveTime;
 private Int32 leaveTime_ = 0;
 public bool HasLeaveTime {
 get { return hasLeaveTime; }
 }
 public Int32 LeaveTime {
 get { return leaveTime_; }
 set { SetLeaveTime(value); }
 }
 public void SetLeaveTime(Int32 value) { 
 hasLeaveTime = true;
 leaveTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLeaveTime) {
size += pb::CodedOutputStream.ComputeInt32Size(1, LeaveTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLeaveTime) {
output.WriteInt32(1, LeaveTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongChengLeaveTime _inst = (GCGongChengLeaveTime) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.LeaveTime = input.ReadInt32();
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
public class GCGongChengLongBelong : PacketDistributed
{

public const int longStickInfoFieldNumber = 1;
 private pbc::PopsicleList<GongChengDoorInfo> longStickInfo_ = new pbc::PopsicleList<GongChengDoorInfo>();
 public scg::IList<GongChengDoorInfo> longStickInfoList {
 get { return pbc::Lists.AsReadOnly(longStickInfo_); }
 }
 
 public int longStickInfoCount {
 get { return longStickInfo_.Count; }
 }
 
public GongChengDoorInfo GetLongStickInfo(int index) {
 return longStickInfo_[index];
 }
 public void AddLongStickInfo(GongChengDoorInfo value) {
 longStickInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GongChengDoorInfo element in longStickInfoList) {
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
foreach (GongChengDoorInfo element in longStickInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongChengLongBelong _inst = (GCGongChengLongBelong) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GongChengDoorInfo subBuilder =  new GongChengDoorInfo();
input.ReadMessage(subBuilder);
_inst.AddLongStickInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GongChengDoorInfo element in longStickInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGongChengReceiveAward : PacketDistributed
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
 GCGongChengReceiveAward _inst = (GCGongChengReceiveAward) _base;
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
public class GCGongChengScoreCount : PacketDistributed
{

public const int gangScoreInfoFieldNumber = 1;
 private pbc::PopsicleList<GongChengDoorInfo> gangScoreInfo_ = new pbc::PopsicleList<GongChengDoorInfo>();
 public scg::IList<GongChengDoorInfo> gangScoreInfoList {
 get { return pbc::Lists.AsReadOnly(gangScoreInfo_); }
 }
 
 public int gangScoreInfoCount {
 get { return gangScoreInfo_.Count; }
 }
 
public GongChengDoorInfo GetGangScoreInfo(int index) {
 return gangScoreInfo_[index];
 }
 public void AddGangScoreInfo(GongChengDoorInfo value) {
 gangScoreInfo_.Add(value);
 }

public const int closeTimeFieldNumber = 3;
 private bool hasCloseTime;
 private Int32 closeTime_ = 0;
 public bool HasCloseTime {
 get { return hasCloseTime; }
 }
 public Int32 CloseTime {
 get { return closeTime_; }
 set { SetCloseTime(value); }
 }
 public void SetCloseTime(Int32 value) { 
 hasCloseTime = true;
 closeTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GongChengDoorInfo element in gangScoreInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasCloseTime) {
size += pb::CodedOutputStream.ComputeInt32Size(3, CloseTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (GongChengDoorInfo element in gangScoreInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasCloseTime) {
output.WriteInt32(3, CloseTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongChengScoreCount _inst = (GCGongChengScoreCount) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GongChengDoorInfo subBuilder =  new GongChengDoorInfo();
input.ReadMessage(subBuilder);
_inst.AddGangScoreInfo(subBuilder);
break;
}
   case  24: {
 _inst.CloseTime = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GongChengDoorInfo element in gangScoreInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGongchengAddScore : PacketDistributed
{

public const int scoreFieldNumber = 1;
 private bool hasScore;
 private Int32 score_ = 0;
 public bool HasScore {
 get { return hasScore; }
 }
 public Int32 Score {
 get { return score_; }
 set { SetScore(value); }
 }
 public void SetScore(Int32 value) { 
 hasScore = true;
 score_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasScore) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Score);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasScore) {
output.WriteInt32(1, Score);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGongchengAddScore _inst = (GCGongchengAddScore) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Score = input.ReadInt32();
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
public class GCOpenGongChengEnterBoard : PacketDistributed
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
 GCOpenGongChengEnterBoard _inst = (GCOpenGongChengEnterBoard) _base;
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
public class GCOpenGongChengUI : PacketDistributed
{

public const int characterInfoFieldNumber = 1;
 private bool hasCharacterInfo;
 private CharacterInfo characterInfo_ =  new CharacterInfo();
 public bool HasCharacterInfo {
 get { return hasCharacterInfo; }
 }
 public CharacterInfo CharacterInfo {
 get { return characterInfo_; }
 set { SetCharacterInfo(value); }
 }
 public void SetCharacterInfo(CharacterInfo value) { 
 hasCharacterInfo = true;
 characterInfo_ = value;
 }

public const int stateFieldNumber = 2;
 private bool hasState;
 private Int32 state_ = 0;
 public bool HasState {
 get { return hasState; }
 }
 public Int32 State {
 get { return state_; }
 set { SetState(value); }
 }
 public void SetState(Int32 value) { 
 hasState = true;
 state_ = value;
 }

public const int gangNameFieldNumber = 3;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = CharacterInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(2, State);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(3, GangName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)CharacterInfo.SerializedSize());
CharacterInfo.WriteTo(output);

}
 
if (HasState) {
output.WriteInt32(2, State);
}
 
if (HasGangName) {
output.WriteString(3, GangName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOpenGongChengUI _inst = (GCOpenGongChengUI) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.CharacterInfo = subBuilder;
break;
}
   case  16: {
 _inst.State = input.ReadInt32();
break;
}
   case  26: {
 _inst.GangName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasCharacterInfo) {
if (!CharacterInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GongChengDoorInfo : PacketDistributed
{

public const int gangNameFieldNumber = 1;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

public const int gangIdFieldNumber = 2;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
 }

public const int gangDataFieldNumber = 3;
 private bool hasGangData;
 private Int32 gangData_ = 0;
 public bool HasGangData {
 get { return hasGangData; }
 }
 public Int32 GangData {
 get { return gangData_; }
 set { SetGangData(value); }
 }
 public void SetGangData(Int32 value) { 
 hasGangData = true;
 gangData_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(1, GangName);
}
 if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, GangId);
}
 if (HasGangData) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GangData);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGangName) {
output.WriteString(1, GangName);
}
 
if (HasGangId) {
output.WriteInt64(2, GangId);
}
 
if (HasGangData) {
output.WriteInt32(3, GangData);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GongChengDoorInfo _inst = (GongChengDoorInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.GangName = input.ReadString();
break;
}
   case  16: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  24: {
 _inst.GangData = input.ReadInt32();
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
