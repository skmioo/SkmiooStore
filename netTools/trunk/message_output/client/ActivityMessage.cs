//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGActivityOprateEvent : PacketDistributed
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

public const int paramsFieldNumber = 2;
 private pbc::PopsicleList<EntryStrStr> params_ = new pbc::PopsicleList<EntryStrStr>();
 public scg::IList<EntryStrStr> paramsList {
 get { return pbc::Lists.AsReadOnly(params_); }
 }
 
 public int paramsCount {
 get { return params_.Count; }
 }
 
public EntryStrStr GetParams(int index) {
 return params_[index];
 }
 public void AddParams(EntryStrStr value) {
 params_.Add(value);
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
foreach (EntryStrStr element in paramsList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}

do{
foreach (EntryStrStr element in paramsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGActivityOprateEvent _inst = (CGActivityOprateEvent) _base;
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
EntryStrStr subBuilder =  new EntryStrStr();
input.ReadMessage(subBuilder);
_inst.AddParams(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EntryStrStr element in paramsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGBuySweetDice : PacketDistributed
{

public const int typeIdFieldNumber = 1;
 private bool hasTypeId;
 private Int32 typeId_ = 0;
 public bool HasTypeId {
 get { return hasTypeId; }
 }
 public Int32 TypeId {
 get { return typeId_; }
 set { SetTypeId(value); }
 }
 public void SetTypeId(Int32 value) { 
 hasTypeId = true;
 typeId_ = value;
 }

public const int buySweetDiceNumFieldNumber = 2;
 private bool hasBuySweetDiceNum;
 private Int32 buySweetDiceNum_ = 0;
 public bool HasBuySweetDiceNum {
 get { return hasBuySweetDiceNum; }
 }
 public Int32 BuySweetDiceNum {
 get { return buySweetDiceNum_; }
 set { SetBuySweetDiceNum(value); }
 }
 public void SetBuySweetDiceNum(Int32 value) { 
 hasBuySweetDiceNum = true;
 buySweetDiceNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTypeId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TypeId);
}
 if (HasBuySweetDiceNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BuySweetDiceNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTypeId) {
output.WriteInt32(1, TypeId);
}
 
if (HasBuySweetDiceNum) {
output.WriteInt32(2, BuySweetDiceNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuySweetDice _inst = (CGBuySweetDice) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TypeId = input.ReadInt32();
break;
}
   case  16: {
 _inst.BuySweetDiceNum = input.ReadInt32();
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
public class CGEggHatch : PacketDistributed
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

public const int operatorFieldNumber = 3;
 private bool hasOperator;
 private Int32 operator_ = 0;
 public bool HasOperator {
 get { return hasOperator; }
 }
 public Int32 Operator {
 get { return operator_; }
 set { SetOperator(value); }
 }
 public void SetOperator(Int32 value) { 
 hasOperator = true;
 operator_ = value;
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
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Num);
}
 if (HasOperator) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Operator);
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
 
if (HasNum) {
output.WriteInt32(2, Num);
}
 
if (HasOperator) {
output.WriteInt32(3, Operator);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEggHatch _inst = (CGEggHatch) _base;
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
 _inst.Num = input.ReadInt32();
break;
}
   case  24: {
 _inst.Operator = input.ReadInt32();
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
public class CGFlowerBabyRank : PacketDistributed
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
 CGFlowerBabyRank _inst = (CGFlowerBabyRank) _base;
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
public class CGGetFlowerBabyInfo : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetFlowerBabyInfo _inst = (CGGetFlowerBabyInfo) _base;
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
public class CGGetRedBag : PacketDistributed
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

public const int operatorFieldNumber = 2;
 private bool hasOperator;
 private Int32 operator_ = 0;
 public bool HasOperator {
 get { return hasOperator; }
 }
 public Int32 Operator {
 get { return operator_; }
 set { SetOperator(value); }
 }
 public void SetOperator(Int32 value) { 
 hasOperator = true;
 operator_ = value;
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
 if (HasOperator) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operator);
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
 
if (HasOperator) {
output.WriteInt32(2, Operator);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetRedBag _inst = (CGGetRedBag) _base;
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
 _inst.Operator = input.ReadInt32();
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
public class CGGetSweetDiceItem : PacketDistributed
{

public const int typeIdFieldNumber = 1;
 private bool hasTypeId;
 private Int32 typeId_ = 0;
 public bool HasTypeId {
 get { return hasTypeId; }
 }
 public Int32 TypeId {
 get { return typeId_; }
 set { SetTypeId(value); }
 }
 public void SetTypeId(Int32 value) { 
 hasTypeId = true;
 typeId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTypeId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TypeId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTypeId) {
output.WriteInt32(1, TypeId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetSweetDiceItem _inst = (CGGetSweetDiceItem) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TypeId = input.ReadInt32();
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
public class CGGiveFlower : PacketDistributed
{

public const int flowerIdFieldNumber = 1;
 private bool hasFlowerId;
 private Int32 flowerId_ = 0;
 public bool HasFlowerId {
 get { return hasFlowerId; }
 }
 public Int32 FlowerId {
 get { return flowerId_; }
 set { SetFlowerId(value); }
 }
 public void SetFlowerId(Int32 value) { 
 hasFlowerId = true;
 flowerId_ = value;
 }

public const int playerIDFieldNumber = 2;
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
  if (HasFlowerId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FlowerId);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PlayerID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlowerId) {
output.WriteInt32(1, FlowerId);
}
 
if (HasPlayerID) {
output.WriteInt64(2, PlayerID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGiveFlower _inst = (CGGiveFlower) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FlowerId = input.ReadInt32();
break;
}
   case  16: {
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
public class CGGiveFlowerReward : PacketDistributed
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
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGiveFlowerReward _inst = (CGGiveFlowerReward) _base;
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
public class CGNewYearLuckyDraw : PacketDistributed
{

public const int operateTypeFieldNumber = 1;
 private bool hasOperateType;
 private Int32 operateType_ = 0;
 public bool HasOperateType {
 get { return hasOperateType; }
 }
 public Int32 OperateType {
 get { return operateType_; }
 set { SetOperateType(value); }
 }
 public void SetOperateType(Int32 value) { 
 hasOperateType = true;
 operateType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperateType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OperateType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOperateType) {
output.WriteInt32(1, OperateType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGNewYearLuckyDraw _inst = (CGNewYearLuckyDraw) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OperateType = input.ReadInt32();
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
public class CGNewYearLuckyDrawRank : PacketDistributed
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
 CGNewYearLuckyDrawRank _inst = (CGNewYearLuckyDrawRank) _base;
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
public class CGOpActivityInfo : PacketDistributed
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
 CGOpActivityInfo _inst = (CGOpActivityInfo) _base;
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
public class CGSweetDice : PacketDistributed
{

public const int typeIdFieldNumber = 1;
 private bool hasTypeId;
 private Int32 typeId_ = 0;
 public bool HasTypeId {
 get { return hasTypeId; }
 }
 public Int32 TypeId {
 get { return typeId_; }
 set { SetTypeId(value); }
 }
 public void SetTypeId(Int32 value) { 
 hasTypeId = true;
 typeId_ = value;
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

public const int freeFlagFieldNumber = 3;
 private bool hasFreeFlag;
 private Int32 freeFlag_ = 0;
 public bool HasFreeFlag {
 get { return hasFreeFlag; }
 }
 public Int32 FreeFlag {
 get { return freeFlag_; }
 set { SetFreeFlag(value); }
 }
 public void SetFreeFlag(Int32 value) { 
 hasFreeFlag = true;
 freeFlag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTypeId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TypeId);
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
 if (HasFreeFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, FreeFlag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTypeId) {
output.WriteInt32(1, TypeId);
}
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}
 
if (HasFreeFlag) {
output.WriteInt32(3, FreeFlag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSweetDice _inst = (CGSweetDice) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TypeId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Operate = input.ReadInt32();
break;
}
   case  24: {
 _inst.FreeFlag = input.ReadInt32();
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
public class CGTreeDayProp : PacketDistributed
{

public const int propIdFieldNumber = 1;
 private bool hasPropId;
 private Int32 propId_ = 0;
 public bool HasPropId {
 get { return hasPropId; }
 }
 public Int32 PropId {
 get { return propId_; }
 set { SetPropId(value); }
 }
 public void SetPropId(Int32 value) { 
 hasPropId = true;
 propId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPropId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, PropId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPropId) {
output.WriteInt32(1, PropId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTreeDayProp _inst = (CGTreeDayProp) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PropId = input.ReadInt32();
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
public class CGTreeDayRank : PacketDistributed
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
 CGTreeDayRank _inst = (CGTreeDayRank) _base;
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
public class CGTreeDayReward : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTreeDayReward _inst = (CGTreeDayReward) _base;
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
public class EggInfo : PacketDistributed
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

public const int statusFieldNumber = 2;
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

public const int hatchEndTimeFieldNumber = 3;
 private bool hasHatchEndTime;
 private Int64 hatchEndTime_ = 0;
 public bool HasHatchEndTime {
 get { return hasHatchEndTime; }
 }
 public Int64 HatchEndTime {
 get { return hatchEndTime_; }
 set { SetHatchEndTime(value); }
 }
 public void SetHatchEndTime(Int64 value) { 
 hasHatchEndTime = true;
 hatchEndTime_ = value;
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 if (HasHatchEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, HatchEndTime);
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 
if (HasHatchEndTime) {
output.WriteInt64(3, HatchEndTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EggInfo _inst = (EggInfo) _base;
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
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.HatchEndTime = input.ReadInt64();
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
public class FlowerBabyHistory : PacketDistributed
{

public const int timeFieldNumber = 1;
 private bool hasTime;
 private Int64 time_ = 0;
 public bool HasTime {
 get { return hasTime; }
 }
 public Int64 Time {
 get { return time_; }
 set { SetTime(value); }
 }
 public void SetTime(Int64 value) { 
 hasTime = true;
 time_ = value;
 }

public const int sendIdFieldNumber = 2;
 private bool hasSendId;
 private Int64 sendId_ = 0;
 public bool HasSendId {
 get { return hasSendId; }
 }
 public Int64 SendId {
 get { return sendId_; }
 set { SetSendId(value); }
 }
 public void SetSendId(Int64 value) { 
 hasSendId = true;
 sendId_ = value;
 }

public const int sendNameFieldNumber = 3;
 private bool hasSendName;
 private string sendName_ = "";
 public bool HasSendName {
 get { return hasSendName; }
 }
 public string SendName {
 get { return sendName_; }
 set { SetSendName(value); }
 }
 public void SetSendName(string value) { 
 hasSendName = true;
 sendName_ = value;
 }

public const int sendVipFieldNumber = 4;
 private bool hasSendVip;
 private Int32 sendVip_ = 0;
 public bool HasSendVip {
 get { return hasSendVip; }
 }
 public Int32 SendVip {
 get { return sendVip_; }
 set { SetSendVip(value); }
 }
 public void SetSendVip(Int32 value) { 
 hasSendVip = true;
 sendVip_ = value;
 }

public const int flowerIdFieldNumber = 5;
 private bool hasFlowerId;
 private Int32 flowerId_ = 0;
 public bool HasFlowerId {
 get { return hasFlowerId; }
 }
 public Int32 FlowerId {
 get { return flowerId_; }
 set { SetFlowerId(value); }
 }
 public void SetFlowerId(Int32 value) { 
 hasFlowerId = true;
 flowerId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Time);
}
 if (HasSendId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, SendId);
}
 if (HasSendName) {
size += pb::CodedOutputStream.ComputeStringSize(3, SendName);
}
 if (HasSendVip) {
size += pb::CodedOutputStream.ComputeInt32Size(4, SendVip);
}
 if (HasFlowerId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, FlowerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTime) {
output.WriteInt64(1, Time);
}
 
if (HasSendId) {
output.WriteInt64(2, SendId);
}
 
if (HasSendName) {
output.WriteString(3, SendName);
}
 
if (HasSendVip) {
output.WriteInt32(4, SendVip);
}
 
if (HasFlowerId) {
output.WriteInt32(5, FlowerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FlowerBabyHistory _inst = (FlowerBabyHistory) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Time = input.ReadInt64();
break;
}
   case  16: {
 _inst.SendId = input.ReadInt64();
break;
}
   case  26: {
 _inst.SendName = input.ReadString();
break;
}
   case  32: {
 _inst.SendVip = input.ReadInt32();
break;
}
   case  40: {
 _inst.FlowerId = input.ReadInt32();
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
public class FlowerRewardItem : PacketDistributed
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

public const int needScoreFieldNumber = 2;
 private bool hasNeedScore;
 private Int32 needScore_ = 0;
 public bool HasNeedScore {
 get { return hasNeedScore; }
 }
 public Int32 NeedScore {
 get { return needScore_; }
 set { SetNeedScore(value); }
 }
 public void SetNeedScore(Int32 value) { 
 hasNeedScore = true;
 needScore_ = value;
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

public const int stateFieldNumber = 4;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasNeedScore) {
size += pb::CodedOutputStream.ComputeInt32Size(2, NeedScore);
}
 if (HasReward) {
size += pb::CodedOutputStream.ComputeStringSize(3, Reward);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(4, State);
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
 
if (HasNeedScore) {
output.WriteInt32(2, NeedScore);
}
 
if (HasReward) {
output.WriteString(3, Reward);
}
 
if (HasState) {
output.WriteInt32(4, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FlowerRewardItem _inst = (FlowerRewardItem) _base;
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
 _inst.NeedScore = input.ReadInt32();
break;
}
   case  26: {
 _inst.Reward = input.ReadString();
break;
}
   case  32: {
 _inst.State = input.ReadInt32();
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
public class GCActivity : PacketDistributed
{

public const int optFieldNumber = 1;
 private bool hasOpt;
 private Int32 opt_ = 0;
 public bool HasOpt {
 get { return hasOpt; }
 }
 public Int32 Opt {
 get { return opt_; }
 set { SetOpt(value); }
 }
 public void SetOpt(Int32 value) { 
 hasOpt = true;
 opt_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOpt) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Opt);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, EndTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOpt) {
output.WriteInt32(1, Opt);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasEndTime) {
output.WriteInt64(3, EndTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCActivity _inst = (GCActivity) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Opt = input.ReadInt32();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.EndTime = input.ReadInt64();
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
public class GCActivityOprateEvent : PacketDistributed
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

public const int flagFieldNumber = 2;
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
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
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
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCActivityOprateEvent _inst = (GCActivityOprateEvent) _base;
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
public class GCEggHatchBack : PacketDistributed
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

public const int eggInfoFieldNumber = 2;
 private bool hasEggInfo;
 private EggInfo eggInfo_ =  new EggInfo();
 public bool HasEggInfo {
 get { return hasEggInfo; }
 }
 public EggInfo EggInfo {
 get { return eggInfo_; }
 set { SetEggInfo(value); }
 }
 public void SetEggInfo(EggInfo value) { 
 hasEggInfo = true;
 eggInfo_ = value;
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
{
int subsize = EggInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)EggInfo.SerializedSize());
EggInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEggHatchBack _inst = (GCEggHatchBack) _base;
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
    case  18: {
EggInfo subBuilder =  new EggInfo();
 input.ReadMessage(subBuilder);
_inst.EggInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasEggInfo) {
if (!EggInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCFlowerBabyRank : PacketDistributed
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

public const int giveRankTitleIdFieldNumber = 2;
 private bool hasGiveRankTitleId;
 private Int32 giveRankTitleId_ = 0;
 public bool HasGiveRankTitleId {
 get { return hasGiveRankTitleId; }
 }
 public Int32 GiveRankTitleId {
 get { return giveRankTitleId_; }
 set { SetGiveRankTitleId(value); }
 }
 public void SetGiveRankTitleId(Int32 value) { 
 hasGiveRankTitleId = true;
 giveRankTitleId_ = value;
 }

public const int receiveRankTitleIdFieldNumber = 3;
 private bool hasReceiveRankTitleId;
 private Int32 receiveRankTitleId_ = 0;
 public bool HasReceiveRankTitleId {
 get { return hasReceiveRankTitleId; }
 }
 public Int32 ReceiveRankTitleId {
 get { return receiveRankTitleId_; }
 set { SetReceiveRankTitleId(value); }
 }
 public void SetReceiveRankTitleId(Int32 value) { 
 hasReceiveRankTitleId = true;
 receiveRankTitleId_ = value;
 }

public const int giveRankRewardsFieldNumber = 4;
 private pbc::PopsicleList<ActivityRankReward> giveRankRewards_ = new pbc::PopsicleList<ActivityRankReward>();
 public scg::IList<ActivityRankReward> giveRankRewardsList {
 get { return pbc::Lists.AsReadOnly(giveRankRewards_); }
 }
 
 public int giveRankRewardsCount {
 get { return giveRankRewards_.Count; }
 }
 
public ActivityRankReward GetGiveRankRewards(int index) {
 return giveRankRewards_[index];
 }
 public void AddGiveRankRewards(ActivityRankReward value) {
 giveRankRewards_.Add(value);
 }

public const int receiveRankRewardsFieldNumber = 5;
 private pbc::PopsicleList<ActivityRankReward> receiveRankRewards_ = new pbc::PopsicleList<ActivityRankReward>();
 public scg::IList<ActivityRankReward> receiveRankRewardsList {
 get { return pbc::Lists.AsReadOnly(receiveRankRewards_); }
 }
 
 public int receiveRankRewardsCount {
 get { return receiveRankRewards_.Count; }
 }
 
public ActivityRankReward GetReceiveRankRewards(int index) {
 return receiveRankRewards_[index];
 }
 public void AddReceiveRankRewards(ActivityRankReward value) {
 receiveRankRewards_.Add(value);
 }

public const int giveRankListFieldNumber = 6;
 private pbc::PopsicleList<ActivityRankInfo> giveRankList_ = new pbc::PopsicleList<ActivityRankInfo>();
 public scg::IList<ActivityRankInfo> giveRankListList {
 get { return pbc::Lists.AsReadOnly(giveRankList_); }
 }
 
 public int giveRankListCount {
 get { return giveRankList_.Count; }
 }
 
public ActivityRankInfo GetGiveRankList(int index) {
 return giveRankList_[index];
 }
 public void AddGiveRankList(ActivityRankInfo value) {
 giveRankList_.Add(value);
 }

public const int receiveRankListFieldNumber = 7;
 private pbc::PopsicleList<ActivityRankInfo> receiveRankList_ = new pbc::PopsicleList<ActivityRankInfo>();
 public scg::IList<ActivityRankInfo> receiveRankListList {
 get { return pbc::Lists.AsReadOnly(receiveRankList_); }
 }
 
 public int receiveRankListCount {
 get { return receiveRankList_.Count; }
 }
 
public ActivityRankInfo GetReceiveRankList(int index) {
 return receiveRankList_[index];
 }
 public void AddReceiveRankList(ActivityRankInfo value) {
 receiveRankList_.Add(value);
 }

public const int myGiveRankFieldNumber = 8;
 private bool hasMyGiveRank;
 private Int32 myGiveRank_ = 0;
 public bool HasMyGiveRank {
 get { return hasMyGiveRank; }
 }
 public Int32 MyGiveRank {
 get { return myGiveRank_; }
 set { SetMyGiveRank(value); }
 }
 public void SetMyGiveRank(Int32 value) { 
 hasMyGiveRank = true;
 myGiveRank_ = value;
 }

public const int myReceiveRankFieldNumber = 9;
 private bool hasMyReceiveRank;
 private Int32 myReceiveRank_ = 0;
 public bool HasMyReceiveRank {
 get { return hasMyReceiveRank; }
 }
 public Int32 MyReceiveRank {
 get { return myReceiveRank_; }
 set { SetMyReceiveRank(value); }
 }
 public void SetMyReceiveRank(Int32 value) { 
 hasMyReceiveRank = true;
 myReceiveRank_ = value;
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
 if (HasGiveRankTitleId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GiveRankTitleId);
}
 if (HasReceiveRankTitleId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ReceiveRankTitleId);
}
{
foreach (ActivityRankReward element in giveRankRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankReward element in receiveRankRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankInfo element in giveRankListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankInfo element in receiveRankListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasMyGiveRank) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MyGiveRank);
}
 if (HasMyReceiveRank) {
size += pb::CodedOutputStream.ComputeInt32Size(9, MyReceiveRank);
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
 
if (HasGiveRankTitleId) {
output.WriteInt32(2, GiveRankTitleId);
}
 
if (HasReceiveRankTitleId) {
output.WriteInt32(3, ReceiveRankTitleId);
}

do{
foreach (ActivityRankReward element in giveRankRewardsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankReward element in receiveRankRewardsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankInfo element in giveRankListList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankInfo element in receiveRankListList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasMyGiveRank) {
output.WriteInt32(8, MyGiveRank);
}
 
if (HasMyReceiveRank) {
output.WriteInt32(9, MyReceiveRank);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFlowerBabyRank _inst = (GCFlowerBabyRank) _base;
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
 _inst.GiveRankTitleId = input.ReadInt32();
break;
}
   case  24: {
 _inst.ReceiveRankTitleId = input.ReadInt32();
break;
}
    case  34: {
ActivityRankReward subBuilder =  new ActivityRankReward();
input.ReadMessage(subBuilder);
_inst.AddGiveRankRewards(subBuilder);
break;
}
    case  42: {
ActivityRankReward subBuilder =  new ActivityRankReward();
input.ReadMessage(subBuilder);
_inst.AddReceiveRankRewards(subBuilder);
break;
}
    case  50: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
input.ReadMessage(subBuilder);
_inst.AddGiveRankList(subBuilder);
break;
}
    case  58: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
input.ReadMessage(subBuilder);
_inst.AddReceiveRankList(subBuilder);
break;
}
   case  64: {
 _inst.MyGiveRank = input.ReadInt32();
break;
}
   case  72: {
 _inst.MyReceiveRank = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ActivityRankReward element in giveRankRewardsList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankReward element in receiveRankRewardsList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankInfo element in giveRankListList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankInfo element in receiveRankListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetFlowerBabyInfoBack : PacketDistributed
{

public const int hisListFieldNumber = 1;
 private pbc::PopsicleList<FlowerBabyHistory> hisList_ = new pbc::PopsicleList<FlowerBabyHistory>();
 public scg::IList<FlowerBabyHistory> hisListList {
 get { return pbc::Lists.AsReadOnly(hisList_); }
 }
 
 public int hisListCount {
 get { return hisList_.Count; }
 }
 
public FlowerBabyHistory GetHisList(int index) {
 return hisList_[index];
 }
 public void AddHisList(FlowerBabyHistory value) {
 hisList_.Add(value);
 }

public const int receiveScoreSumFieldNumber = 2;
 private bool hasReceiveScoreSum;
 private Int32 receiveScoreSum_ = 0;
 public bool HasReceiveScoreSum {
 get { return hasReceiveScoreSum; }
 }
 public Int32 ReceiveScoreSum {
 get { return receiveScoreSum_; }
 set { SetReceiveScoreSum(value); }
 }
 public void SetReceiveScoreSum(Int32 value) { 
 hasReceiveScoreSum = true;
 receiveScoreSum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (FlowerBabyHistory element in hisListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasReceiveScoreSum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ReceiveScoreSum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (FlowerBabyHistory element in hisListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasReceiveScoreSum) {
output.WriteInt32(2, ReceiveScoreSum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetFlowerBabyInfoBack _inst = (GCGetFlowerBabyInfoBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
FlowerBabyHistory subBuilder =  new FlowerBabyHistory();
input.ReadMessage(subBuilder);
_inst.AddHisList(subBuilder);
break;
}
   case  16: {
 _inst.ReceiveScoreSum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FlowerBabyHistory element in hisListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetRedBagBack : PacketDistributed
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

public const int statusFieldNumber = 2;
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

public const int idFieldNumber = 3;
 private pbc::PopsicleList<Int32> id_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> idList {
 get { return pbc::Lists.AsReadOnly(id_); }
 }
 
 public int idCount {
 get { return id_.Count; }
 }
 
public Int32 GetId(int index) {
 return id_[index];
 }
 public void AddId(Int32 value) {
 id_.Add(value);
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
{
int dataSize = 0;
foreach (Int32 element in idList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * id_.Count;
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
{
if (id_.Count > 0) {
foreach (Int32 element in idList) {
output.WriteInt32(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetRedBagBack _inst = (GCGetRedBagBack) _base;
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
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.AddId(input.ReadInt32());
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
public class GCGiveFlowerBack : PacketDistributed
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

public const int giveScoreFieldNumber = 2;
 private bool hasGiveScore;
 private Int32 giveScore_ = 0;
 public bool HasGiveScore {
 get { return hasGiveScore; }
 }
 public Int32 GiveScore {
 get { return giveScore_; }
 set { SetGiveScore(value); }
 }
 public void SetGiveScore(Int32 value) { 
 hasGiveScore = true;
 giveScore_ = value;
 }

public const int receiveScoreFieldNumber = 3;
 private bool hasReceiveScore;
 private Int32 receiveScore_ = 0;
 public bool HasReceiveScore {
 get { return hasReceiveScore; }
 }
 public Int32 ReceiveScore {
 get { return receiveScore_; }
 set { SetReceiveScore(value); }
 }
 public void SetReceiveScore(Int32 value) { 
 hasReceiveScore = true;
 receiveScore_ = value;
 }

public const int giveScoreSumFieldNumber = 4;
 private bool hasGiveScoreSum;
 private Int32 giveScoreSum_ = 0;
 public bool HasGiveScoreSum {
 get { return hasGiveScoreSum; }
 }
 public Int32 GiveScoreSum {
 get { return giveScoreSum_; }
 set { SetGiveScoreSum(value); }
 }
 public void SetGiveScoreSum(Int32 value) { 
 hasGiveScoreSum = true;
 giveScoreSum_ = value;
 }

public const int receiveScoreSumFieldNumber = 5;
 private bool hasReceiveScoreSum;
 private Int32 receiveScoreSum_ = 0;
 public bool HasReceiveScoreSum {
 get { return hasReceiveScoreSum; }
 }
 public Int32 ReceiveScoreSum {
 get { return receiveScoreSum_; }
 set { SetReceiveScoreSum(value); }
 }
 public void SetReceiveScoreSum(Int32 value) { 
 hasReceiveScoreSum = true;
 receiveScoreSum_ = value;
 }

public const int giveRankDailyFieldNumber = 6;
 private pbc::PopsicleList<FlowerRewardItem> giveRankDaily_ = new pbc::PopsicleList<FlowerRewardItem>();
 public scg::IList<FlowerRewardItem> giveRankDailyList {
 get { return pbc::Lists.AsReadOnly(giveRankDaily_); }
 }
 
 public int giveRankDailyCount {
 get { return giveRankDaily_.Count; }
 }
 
public FlowerRewardItem GetGiveRankDaily(int index) {
 return giveRankDaily_[index];
 }
 public void AddGiveRankDaily(FlowerRewardItem value) {
 giveRankDaily_.Add(value);
 }

public const int receiveRankDailyFieldNumber = 7;
 private pbc::PopsicleList<FlowerRewardItem> receiveRankDaily_ = new pbc::PopsicleList<FlowerRewardItem>();
 public scg::IList<FlowerRewardItem> receiveRankDailyList {
 get { return pbc::Lists.AsReadOnly(receiveRankDaily_); }
 }
 
 public int receiveRankDailyCount {
 get { return receiveRankDaily_.Count; }
 }
 
public FlowerRewardItem GetReceiveRankDaily(int index) {
 return receiveRankDaily_[index];
 }
 public void AddReceiveRankDaily(FlowerRewardItem value) {
 receiveRankDaily_.Add(value);
 }

public const int flowerIdListFieldNumber = 8;
 private pbc::PopsicleList<Int32> flowerIdList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> flowerIdListList {
 get { return pbc::Lists.AsReadOnly(flowerIdList_); }
 }
 
 public int flowerIdListCount {
 get { return flowerIdList_.Count; }
 }
 
public Int32 GetFlowerIdList(int index) {
 return flowerIdList_[index];
 }
 public void AddFlowerIdList(Int32 value) {
 flowerIdList_.Add(value);
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
 if (HasGiveScore) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GiveScore);
}
 if (HasReceiveScore) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ReceiveScore);
}
 if (HasGiveScoreSum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GiveScoreSum);
}
 if (HasReceiveScoreSum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, ReceiveScoreSum);
}
{
foreach (FlowerRewardItem element in giveRankDailyList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (FlowerRewardItem element in receiveRankDailyList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int dataSize = 0;
foreach (Int32 element in flowerIdListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * flowerIdList_.Count;
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
 
if (HasGiveScore) {
output.WriteInt32(2, GiveScore);
}
 
if (HasReceiveScore) {
output.WriteInt32(3, ReceiveScore);
}
 
if (HasGiveScoreSum) {
output.WriteInt32(4, GiveScoreSum);
}
 
if (HasReceiveScoreSum) {
output.WriteInt32(5, ReceiveScoreSum);
}

do{
foreach (FlowerRewardItem element in giveRankDailyList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (FlowerRewardItem element in receiveRankDailyList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
if (flowerIdList_.Count > 0) {
foreach (Int32 element in flowerIdListList) {
output.WriteInt32(8,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGiveFlowerBack _inst = (GCGiveFlowerBack) _base;
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
 _inst.GiveScore = input.ReadInt32();
break;
}
   case  24: {
 _inst.ReceiveScore = input.ReadInt32();
break;
}
   case  32: {
 _inst.GiveScoreSum = input.ReadInt32();
break;
}
   case  40: {
 _inst.ReceiveScoreSum = input.ReadInt32();
break;
}
    case  50: {
FlowerRewardItem subBuilder =  new FlowerRewardItem();
input.ReadMessage(subBuilder);
_inst.AddGiveRankDaily(subBuilder);
break;
}
    case  58: {
FlowerRewardItem subBuilder =  new FlowerRewardItem();
input.ReadMessage(subBuilder);
_inst.AddReceiveRankDaily(subBuilder);
break;
}
   case  64: {
 _inst.AddFlowerIdList(input.ReadInt32());
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FlowerRewardItem element in giveRankDailyList) {
if (!element.IsInitialized()) return false;
}
foreach (FlowerRewardItem element in receiveRankDailyList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGiveFlowerRewardBack : PacketDistributed
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
 GCGiveFlowerRewardBack _inst = (GCGiveFlowerRewardBack) _base;
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
public class GCIOSActivityOpen : PacketDistributed
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

public const int cdkOpenFieldNumber = 2;
 private bool hasCdkOpen;
 private Int32 cdkOpen_ = 0;
 public bool HasCdkOpen {
 get { return hasCdkOpen; }
 }
 public Int32 CdkOpen {
 get { return cdkOpen_; }
 set { SetCdkOpen(value); }
 }
 public void SetCdkOpen(Int32 value) { 
 hasCdkOpen = true;
 cdkOpen_ = value;
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
 if (HasCdkOpen) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CdkOpen);
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
 
if (HasCdkOpen) {
output.WriteInt32(2, CdkOpen);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCIOSActivityOpen _inst = (GCIOSActivityOpen) _base;
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
   case  16: {
 _inst.CdkOpen = input.ReadInt32();
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
public class GCInitChickenActivity : PacketDistributed
{

public const int activityIdFieldNumber = 1;
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

public const int contentFieldNumber = 2;
 private bool hasContent;
 private string content_ = "";
 public bool HasContent {
 get { return hasContent; }
 }
 public string Content {
 get { return content_; }
 set { SetContent(value); }
 }
 public void SetContent(string value) { 
 hasContent = true;
 content_ = value;
 }

public const int eggInfoFieldNumber = 3;
 private bool hasEggInfo;
 private EggInfo eggInfo_ =  new EggInfo();
 public bool HasEggInfo {
 get { return hasEggInfo; }
 }
 public EggInfo EggInfo {
 get { return eggInfo_; }
 set { SetEggInfo(value); }
 }
 public void SetEggInfo(EggInfo value) { 
 hasEggInfo = true;
 eggInfo_ = value;
 }

public const int chickenItemArrFieldNumber = 4;
 private pbc::PopsicleList<Iteminfo> chickenItemArr_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> chickenItemArrList {
 get { return pbc::Lists.AsReadOnly(chickenItemArr_); }
 }
 
 public int chickenItemArrCount {
 get { return chickenItemArr_.Count; }
 }
 
public Iteminfo GetChickenItemArr(int index) {
 return chickenItemArr_[index];
 }
 public void AddChickenItemArr(Iteminfo value) {
 chickenItemArr_.Add(value);
 }

public const int hatchEggTemplateFieldNumber = 5;
 private pbc::PopsicleList<HatchEggInfo> hatchEggTemplate_ = new pbc::PopsicleList<HatchEggInfo>();
 public scg::IList<HatchEggInfo> hatchEggTemplateList {
 get { return pbc::Lists.AsReadOnly(hatchEggTemplate_); }
 }
 
 public int hatchEggTemplateCount {
 get { return hatchEggTemplate_.Count; }
 }
 
public HatchEggInfo GetHatchEggTemplate(int index) {
 return hatchEggTemplate_[index];
 }
 public void AddHatchEggTemplate(HatchEggInfo value) {
 hatchEggTemplate_.Add(value);
 }

public const int actTypeFieldNumber = 6;
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

public const int model1FieldNumber = 7;
 private bool hasModel1;
 private string model1_ = "";
 public bool HasModel1 {
 get { return hasModel1; }
 }
 public string Model1 {
 get { return model1_; }
 set { SetModel1(value); }
 }
 public void SetModel1(string value) { 
 hasModel1 = true;
 model1_ = value;
 }

public const int model2FieldNumber = 8;
 private bool hasModel2;
 private string model2_ = "";
 public bool HasModel2 {
 get { return hasModel2; }
 }
 public string Model2 {
 get { return model2_; }
 set { SetModel2(value); }
 }
 public void SetModel2(string value) { 
 hasModel2 = true;
 model2_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActivityId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActivityId);
}
 if (HasContent) {
size += pb::CodedOutputStream.ComputeStringSize(2, Content);
}
{
int subsize = EggInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (Iteminfo element in chickenItemArrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (HatchEggInfo element in hatchEggTemplateList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasActType) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ActType);
}
 if (HasModel1) {
size += pb::CodedOutputStream.ComputeStringSize(7, Model1);
}
 if (HasModel2) {
size += pb::CodedOutputStream.ComputeStringSize(8, Model2);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActivityId) {
output.WriteInt32(1, ActivityId);
}
 
if (HasContent) {
output.WriteString(2, Content);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)EggInfo.SerializedSize());
EggInfo.WriteTo(output);

}

do{
foreach (Iteminfo element in chickenItemArrList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (HatchEggInfo element in hatchEggTemplateList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasActType) {
output.WriteInt32(6, ActType);
}
 
if (HasModel1) {
output.WriteString(7, Model1);
}
 
if (HasModel2) {
output.WriteString(8, Model2);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInitChickenActivity _inst = (GCInitChickenActivity) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActivityId = input.ReadInt32();
break;
}
   case  18: {
 _inst.Content = input.ReadString();
break;
}
    case  26: {
EggInfo subBuilder =  new EggInfo();
 input.ReadMessage(subBuilder);
_inst.EggInfo = subBuilder;
break;
}
    case  34: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddChickenItemArr(subBuilder);
break;
}
    case  42: {
HatchEggInfo subBuilder =  new HatchEggInfo();
input.ReadMessage(subBuilder);
_inst.AddHatchEggTemplate(subBuilder);
break;
}
   case  48: {
 _inst.ActType = input.ReadInt32();
break;
}
   case  58: {
 _inst.Model1 = input.ReadString();
break;
}
   case  66: {
 _inst.Model2 = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasEggInfo) {
if (!EggInfo.IsInitialized()) return false;
}
foreach (Iteminfo element in chickenItemArrList) {
if (!element.IsInitialized()) return false;
}
foreach (HatchEggInfo element in hatchEggTemplateList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCInitRedBagInfo : PacketDistributed
{

public const int redBagArrFieldNumber = 1;
 private pbc::PopsicleList<RedBagInfo> redBagArr_ = new pbc::PopsicleList<RedBagInfo>();
 public scg::IList<RedBagInfo> redBagArrList {
 get { return pbc::Lists.AsReadOnly(redBagArr_); }
 }
 
 public int redBagArrCount {
 get { return redBagArr_.Count; }
 }
 
public RedBagInfo GetRedBagArr(int index) {
 return redBagArr_[index];
 }
 public void AddRedBagArr(RedBagInfo value) {
 redBagArr_.Add(value);
 }

public const int operatorFieldNumber = 2;
 private bool hasOperator;
 private Int32 operator_ = 0;
 public bool HasOperator {
 get { return hasOperator; }
 }
 public Int32 Operator {
 get { return operator_; }
 set { SetOperator(value); }
 }
 public void SetOperator(Int32 value) { 
 hasOperator = true;
 operator_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RedBagInfo element in redBagArrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasOperator) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operator);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (RedBagInfo element in redBagArrList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasOperator) {
output.WriteInt32(2, Operator);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInitRedBagInfo _inst = (GCInitRedBagInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RedBagInfo subBuilder =  new RedBagInfo();
input.ReadMessage(subBuilder);
_inst.AddRedBagArr(subBuilder);
break;
}
   case  16: {
 _inst.Operator = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RedBagInfo element in redBagArrList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCNewYearLuckyDrawBack : PacketDistributed
{

public const int operateTypeFieldNumber = 1;
 private bool hasOperateType;
 private Int32 operateType_ = 0;
 public bool HasOperateType {
 get { return hasOperateType; }
 }
 public Int32 OperateType {
 get { return operateType_; }
 set { SetOperateType(value); }
 }
 public void SetOperateType(Int32 value) { 
 hasOperateType = true;
 operateType_ = value;
 }

public const int noteFieldNumber = 2;
 private bool hasNote;
 private string note_ = "";
 public bool HasNote {
 get { return hasNote; }
 }
 public string Note {
 get { return note_; }
 set { SetNote(value); }
 }
 public void SetNote(string value) { 
 hasNote = true;
 note_ = value;
 }

public const int itemsFieldNumber = 3;
 private bool hasItems;
 private string items_ = "";
 public bool HasItems {
 get { return hasItems; }
 }
 public string Items {
 get { return items_; }
 set { SetItems(value); }
 }
 public void SetItems(string value) { 
 hasItems = true;
 items_ = value;
 }

public const int needScoreFieldNumber = 4;
 private bool hasNeedScore;
 private Int32 needScore_ = 0;
 public bool HasNeedScore {
 get { return hasNeedScore; }
 }
 public Int32 NeedScore {
 get { return needScore_; }
 set { SetNeedScore(value); }
 }
 public void SetNeedScore(Int32 value) { 
 hasNeedScore = true;
 needScore_ = value;
 }

public const int curScoreFieldNumber = 5;
 private bool hasCurScore;
 private Int32 curScore_ = 0;
 public bool HasCurScore {
 get { return hasCurScore; }
 }
 public Int32 CurScore {
 get { return curScore_; }
 set { SetCurScore(value); }
 }
 public void SetCurScore(Int32 value) { 
 hasCurScore = true;
 curScore_ = value;
 }

public const int allScoreFieldNumber = 6;
 private bool hasAllScore;
 private Int32 allScore_ = 0;
 public bool HasAllScore {
 get { return hasAllScore; }
 }
 public Int32 AllScore {
 get { return allScore_; }
 set { SetAllScore(value); }
 }
 public void SetAllScore(Int32 value) { 
 hasAllScore = true;
 allScore_ = value;
 }

public const int drawIndexFieldNumber = 7;
 private bool hasDrawIndex;
 private Int32 drawIndex_ = 0;
 public bool HasDrawIndex {
 get { return hasDrawIndex; }
 }
 public Int32 DrawIndex {
 get { return drawIndex_; }
 set { SetDrawIndex(value); }
 }
 public void SetDrawIndex(Int32 value) { 
 hasDrawIndex = true;
 drawIndex_ = value;
 }

public const int historyListFieldNumber = 8;
 private pbc::PopsicleList<NewYearLuckyDrawHistory> historyList_ = new pbc::PopsicleList<NewYearLuckyDrawHistory>();
 public scg::IList<NewYearLuckyDrawHistory> historyListList {
 get { return pbc::Lists.AsReadOnly(historyList_); }
 }
 
 public int historyListCount {
 get { return historyList_.Count; }
 }
 
public NewYearLuckyDrawHistory GetHistoryList(int index) {
 return historyList_[index];
 }
 public void AddHistoryList(NewYearLuckyDrawHistory value) {
 historyList_.Add(value);
 }

public const int rankRewardListFieldNumber = 9;
 private pbc::PopsicleList<ActivityRankReward> rankRewardList_ = new pbc::PopsicleList<ActivityRankReward>();
 public scg::IList<ActivityRankReward> rankRewardListList {
 get { return pbc::Lists.AsReadOnly(rankRewardList_); }
 }
 
 public int rankRewardListCount {
 get { return rankRewardList_.Count; }
 }
 
public ActivityRankReward GetRankRewardList(int index) {
 return rankRewardList_[index];
 }
 public void AddRankRewardList(ActivityRankReward value) {
 rankRewardList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperateType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OperateType);
}
 if (HasNote) {
size += pb::CodedOutputStream.ComputeStringSize(2, Note);
}
 if (HasItems) {
size += pb::CodedOutputStream.ComputeStringSize(3, Items);
}
 if (HasNeedScore) {
size += pb::CodedOutputStream.ComputeInt32Size(4, NeedScore);
}
 if (HasCurScore) {
size += pb::CodedOutputStream.ComputeInt32Size(5, CurScore);
}
 if (HasAllScore) {
size += pb::CodedOutputStream.ComputeInt32Size(6, AllScore);
}
 if (HasDrawIndex) {
size += pb::CodedOutputStream.ComputeInt32Size(7, DrawIndex);
}
{
foreach (NewYearLuckyDrawHistory element in historyListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankReward element in rankRewardListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOperateType) {
output.WriteInt32(1, OperateType);
}
 
if (HasNote) {
output.WriteString(2, Note);
}
 
if (HasItems) {
output.WriteString(3, Items);
}
 
if (HasNeedScore) {
output.WriteInt32(4, NeedScore);
}
 
if (HasCurScore) {
output.WriteInt32(5, CurScore);
}
 
if (HasAllScore) {
output.WriteInt32(6, AllScore);
}
 
if (HasDrawIndex) {
output.WriteInt32(7, DrawIndex);
}

do{
foreach (NewYearLuckyDrawHistory element in historyListList) {
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankReward element in rankRewardListList) {
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCNewYearLuckyDrawBack _inst = (GCNewYearLuckyDrawBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OperateType = input.ReadInt32();
break;
}
   case  18: {
 _inst.Note = input.ReadString();
break;
}
   case  26: {
 _inst.Items = input.ReadString();
break;
}
   case  32: {
 _inst.NeedScore = input.ReadInt32();
break;
}
   case  40: {
 _inst.CurScore = input.ReadInt32();
break;
}
   case  48: {
 _inst.AllScore = input.ReadInt32();
break;
}
   case  56: {
 _inst.DrawIndex = input.ReadInt32();
break;
}
    case  66: {
NewYearLuckyDrawHistory subBuilder =  new NewYearLuckyDrawHistory();
input.ReadMessage(subBuilder);
_inst.AddHistoryList(subBuilder);
break;
}
    case  74: {
ActivityRankReward subBuilder =  new ActivityRankReward();
input.ReadMessage(subBuilder);
_inst.AddRankRewardList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (NewYearLuckyDrawHistory element in historyListList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankReward element in rankRewardListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCNewYearLuckyDrawRank : PacketDistributed
{

public const int rankListFieldNumber = 1;
 private pbc::PopsicleList<ActivityRankInfo> rankList_ = new pbc::PopsicleList<ActivityRankInfo>();
 public scg::IList<ActivityRankInfo> rankListList {
 get { return pbc::Lists.AsReadOnly(rankList_); }
 }
 
 public int rankListCount {
 get { return rankList_.Count; }
 }
 
public ActivityRankInfo GetRankList(int index) {
 return rankList_[index];
 }
 public void AddRankList(ActivityRankInfo value) {
 rankList_.Add(value);
 }

public const int myRankInfoFieldNumber = 2;
 private bool hasMyRankInfo;
 private ActivityRankInfo myRankInfo_ =  new ActivityRankInfo();
 public bool HasMyRankInfo {
 get { return hasMyRankInfo; }
 }
 public ActivityRankInfo MyRankInfo {
 get { return myRankInfo_; }
 set { SetMyRankInfo(value); }
 }
 public void SetMyRankInfo(ActivityRankInfo value) { 
 hasMyRankInfo = true;
 myRankInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ActivityRankInfo element in rankListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = MyRankInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (ActivityRankInfo element in rankListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)MyRankInfo.SerializedSize());
MyRankInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCNewYearLuckyDrawRank _inst = (GCNewYearLuckyDrawRank) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
input.ReadMessage(subBuilder);
_inst.AddRankList(subBuilder);
break;
}
    case  18: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
 input.ReadMessage(subBuilder);
_inst.MyRankInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ActivityRankInfo element in rankListList) {
if (!element.IsInitialized()) return false;
}
  if (HasMyRankInfo) {
if (!MyRankInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOpActivityInfo : PacketDistributed
{

public const int activityListFieldNumber = 1;
 private pbc::PopsicleList<OpActivityInfo> activityList_ = new pbc::PopsicleList<OpActivityInfo>();
 public scg::IList<OpActivityInfo> activityListList {
 get { return pbc::Lists.AsReadOnly(activityList_); }
 }
 
 public int activityListCount {
 get { return activityList_.Count; }
 }
 
public OpActivityInfo GetActivityList(int index) {
 return activityList_[index];
 }
 public void AddActivityList(OpActivityInfo value) {
 activityList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (OpActivityInfo element in activityListList) {
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
foreach (OpActivityInfo element in activityListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOpActivityInfo _inst = (GCOpActivityInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
OpActivityInfo subBuilder =  new OpActivityInfo();
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
 foreach (OpActivityInfo element in activityListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSweetDice : PacketDistributed
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

public const int sweetDiceDataFieldNumber = 2;
 private pbc::PopsicleList<SweetDiceInfo> sweetDiceData_ = new pbc::PopsicleList<SweetDiceInfo>();
 public scg::IList<SweetDiceInfo> sweetDiceDataList {
 get { return pbc::Lists.AsReadOnly(sweetDiceData_); }
 }
 
 public int sweetDiceDataCount {
 get { return sweetDiceData_.Count; }
 }
 
public SweetDiceInfo GetSweetDiceData(int index) {
 return sweetDiceData_[index];
 }
 public void AddSweetDiceData(SweetDiceInfo value) {
 sweetDiceData_.Add(value);
 }

public const int playerSweetDiceDataFieldNumber = 3;
 private pbc::PopsicleList<PlayerSweetDice> playerSweetDiceData_ = new pbc::PopsicleList<PlayerSweetDice>();
 public scg::IList<PlayerSweetDice> playerSweetDiceDataList {
 get { return pbc::Lists.AsReadOnly(playerSweetDiceData_); }
 }
 
 public int playerSweetDiceDataCount {
 get { return playerSweetDiceData_.Count; }
 }
 
public PlayerSweetDice GetPlayerSweetDiceData(int index) {
 return playerSweetDiceData_[index];
 }
 public void AddPlayerSweetDiceData(PlayerSweetDice value) {
 playerSweetDiceData_.Add(value);
 }

public const int playerSweetDiceFieldNumber = 4;
 private bool hasPlayerSweetDice;
 private PlayerSweetDice playerSweetDice_ =  new PlayerSweetDice();
 public bool HasPlayerSweetDice {
 get { return hasPlayerSweetDice; }
 }
 public PlayerSweetDice PlayerSweetDice {
 get { return playerSweetDice_; }
 set { SetPlayerSweetDice(value); }
 }
 public void SetPlayerSweetDice(PlayerSweetDice value) { 
 hasPlayerSweetDice = true;
 playerSweetDice_ = value;
 }

public const int tenPosListFieldNumber = 5;
 private pbc::PopsicleList<Int32> tenPosList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> tenPosListList {
 get { return pbc::Lists.AsReadOnly(tenPosList_); }
 }
 
 public int tenPosListCount {
 get { return tenPosList_.Count; }
 }
 
public Int32 GetTenPosList(int index) {
 return tenPosList_[index];
 }
 public void AddTenPosList(Int32 value) {
 tenPosList_.Add(value);
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
foreach (SweetDiceInfo element in sweetDiceDataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (PlayerSweetDice element in playerSweetDiceDataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = PlayerSweetDice.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int dataSize = 0;
foreach (Int32 element in tenPosListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * tenPosList_.Count;
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
foreach (SweetDiceInfo element in sweetDiceDataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (PlayerSweetDice element in playerSweetDiceDataList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PlayerSweetDice.SerializedSize());
PlayerSweetDice.WriteTo(output);

}
{
if (tenPosList_.Count > 0) {
foreach (Int32 element in tenPosListList) {
output.WriteInt32(5,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSweetDice _inst = (GCSweetDice) _base;
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
SweetDiceInfo subBuilder =  new SweetDiceInfo();
input.ReadMessage(subBuilder);
_inst.AddSweetDiceData(subBuilder);
break;
}
    case  26: {
PlayerSweetDice subBuilder =  new PlayerSweetDice();
input.ReadMessage(subBuilder);
_inst.AddPlayerSweetDiceData(subBuilder);
break;
}
    case  34: {
PlayerSweetDice subBuilder =  new PlayerSweetDice();
 input.ReadMessage(subBuilder);
_inst.PlayerSweetDice = subBuilder;
break;
}
   case  40: {
 _inst.AddTenPosList(input.ReadInt32());
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SweetDiceInfo element in sweetDiceDataList) {
if (!element.IsInitialized()) return false;
}
foreach (PlayerSweetDice element in playerSweetDiceDataList) {
if (!element.IsInitialized()) return false;
}
  if (HasPlayerSweetDice) {
if (!PlayerSweetDice.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTreeDayPropBack : PacketDistributed
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

public const int myGrowthFieldNumber = 2;
 private bool hasMyGrowth;
 private Int32 myGrowth_ = 0;
 public bool HasMyGrowth {
 get { return hasMyGrowth; }
 }
 public Int32 MyGrowth {
 get { return myGrowth_; }
 set { SetMyGrowth(value); }
 }
 public void SetMyGrowth(Int32 value) { 
 hasMyGrowth = true;
 myGrowth_ = value;
 }

public const int treeGrowthFieldNumber = 3;
 private bool hasTreeGrowth;
 private Int32 treeGrowth_ = 0;
 public bool HasTreeGrowth {
 get { return hasTreeGrowth; }
 }
 public Int32 TreeGrowth {
 get { return treeGrowth_; }
 set { SetTreeGrowth(value); }
 }
 public void SetTreeGrowth(Int32 value) { 
 hasTreeGrowth = true;
 treeGrowth_ = value;
 }

public const int treeIDFieldNumber = 4;
 private bool hasTreeID;
 private Int32 treeID_ = 0;
 public bool HasTreeID {
 get { return hasTreeID; }
 }
 public Int32 TreeID {
 get { return treeID_; }
 set { SetTreeID(value); }
 }
 public void SetTreeID(Int32 value) { 
 hasTreeID = true;
 treeID_ = value;
 }

public const int treeInfoListFieldNumber = 5;
 private pbc::PopsicleList<TreeInfo> treeInfoList_ = new pbc::PopsicleList<TreeInfo>();
 public scg::IList<TreeInfo> treeInfoListList {
 get { return pbc::Lists.AsReadOnly(treeInfoList_); }
 }
 
 public int treeInfoListCount {
 get { return treeInfoList_.Count; }
 }
 
public TreeInfo GetTreeInfoList(int index) {
 return treeInfoList_[index];
 }
 public void AddTreeInfoList(TreeInfo value) {
 treeInfoList_.Add(value);
 }

public const int toolListFieldNumber = 6;
 private pbc::PopsicleList<TreeToolInfo> toolList_ = new pbc::PopsicleList<TreeToolInfo>();
 public scg::IList<TreeToolInfo> toolListList {
 get { return pbc::Lists.AsReadOnly(toolList_); }
 }
 
 public int toolListCount {
 get { return toolList_.Count; }
 }
 
public TreeToolInfo GetToolList(int index) {
 return toolList_[index];
 }
 public void AddToolList(TreeToolInfo value) {
 toolList_.Add(value);
 }

public const int rewardGetListFieldNumber = 7;
 private pbc::PopsicleList<Int32> rewardGetList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> rewardGetListList {
 get { return pbc::Lists.AsReadOnly(rewardGetList_); }
 }
 
 public int rewardGetListCount {
 get { return rewardGetList_.Count; }
 }
 
public Int32 GetRewardGetList(int index) {
 return rewardGetList_[index];
 }
 public void AddRewardGetList(Int32 value) {
 rewardGetList_.Add(value);
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
 if (HasMyGrowth) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MyGrowth);
}
 if (HasTreeGrowth) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TreeGrowth);
}
 if (HasTreeID) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TreeID);
}
{
foreach (TreeInfo element in treeInfoListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (TreeToolInfo element in toolListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int dataSize = 0;
foreach (Int32 element in rewardGetListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * rewardGetList_.Count;
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
 
if (HasMyGrowth) {
output.WriteInt32(2, MyGrowth);
}
 
if (HasTreeGrowth) {
output.WriteInt32(3, TreeGrowth);
}
 
if (HasTreeID) {
output.WriteInt32(4, TreeID);
}

do{
foreach (TreeInfo element in treeInfoListList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (TreeToolInfo element in toolListList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
if (rewardGetList_.Count > 0) {
foreach (Int32 element in rewardGetListList) {
output.WriteInt32(7,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTreeDayPropBack _inst = (GCTreeDayPropBack) _base;
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
 _inst.MyGrowth = input.ReadInt32();
break;
}
   case  24: {
 _inst.TreeGrowth = input.ReadInt32();
break;
}
   case  32: {
 _inst.TreeID = input.ReadInt32();
break;
}
    case  42: {
TreeInfo subBuilder =  new TreeInfo();
input.ReadMessage(subBuilder);
_inst.AddTreeInfoList(subBuilder);
break;
}
    case  50: {
TreeToolInfo subBuilder =  new TreeToolInfo();
input.ReadMessage(subBuilder);
_inst.AddToolList(subBuilder);
break;
}
   case  56: {
 _inst.AddRewardGetList(input.ReadInt32());
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TreeInfo element in treeInfoListList) {
if (!element.IsInitialized()) return false;
}
foreach (TreeToolInfo element in toolListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTreeDayRankBack : PacketDistributed
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

public const int arborRankRewardsFieldNumber = 2;
 private pbc::PopsicleList<ActivityRankReward> arborRankRewards_ = new pbc::PopsicleList<ActivityRankReward>();
 public scg::IList<ActivityRankReward> arborRankRewardsList {
 get { return pbc::Lists.AsReadOnly(arborRankRewards_); }
 }
 
 public int arborRankRewardsCount {
 get { return arborRankRewards_.Count; }
 }
 
public ActivityRankReward GetArborRankRewards(int index) {
 return arborRankRewards_[index];
 }
 public void AddArborRankRewards(ActivityRankReward value) {
 arborRankRewards_.Add(value);
 }

public const int arborRankListFieldNumber = 3;
 private pbc::PopsicleList<ActivityRankInfo> arborRankList_ = new pbc::PopsicleList<ActivityRankInfo>();
 public scg::IList<ActivityRankInfo> arborRankListList {
 get { return pbc::Lists.AsReadOnly(arborRankList_); }
 }
 
 public int arborRankListCount {
 get { return arborRankList_.Count; }
 }
 
public ActivityRankInfo GetArborRankList(int index) {
 return arborRankList_[index];
 }
 public void AddArborRankList(ActivityRankInfo value) {
 arborRankList_.Add(value);
 }

public const int myArborRankFieldNumber = 4;
 private bool hasMyArborRank;
 private Int32 myArborRank_ = 0;
 public bool HasMyArborRank {
 get { return hasMyArborRank; }
 }
 public Int32 MyArborRank {
 get { return myArborRank_; }
 set { SetMyArborRank(value); }
 }
 public void SetMyArborRank(Int32 value) { 
 hasMyArborRank = true;
 myArborRank_ = value;
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
foreach (ActivityRankReward element in arborRankRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ActivityRankInfo element in arborRankListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasMyArborRank) {
size += pb::CodedOutputStream.ComputeInt32Size(4, MyArborRank);
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
foreach (ActivityRankReward element in arborRankRewardsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ActivityRankInfo element in arborRankListList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasMyArborRank) {
output.WriteInt32(4, MyArborRank);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTreeDayRankBack _inst = (GCTreeDayRankBack) _base;
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
ActivityRankReward subBuilder =  new ActivityRankReward();
input.ReadMessage(subBuilder);
_inst.AddArborRankRewards(subBuilder);
break;
}
    case  26: {
ActivityRankInfo subBuilder =  new ActivityRankInfo();
input.ReadMessage(subBuilder);
_inst.AddArborRankList(subBuilder);
break;
}
   case  32: {
 _inst.MyArborRank = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ActivityRankReward element in arborRankRewardsList) {
if (!element.IsInitialized()) return false;
}
foreach (ActivityRankInfo element in arborRankListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTreeDayRewardBack : PacketDistributed
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

public const int rewardGetListFieldNumber = 2;
 private pbc::PopsicleList<Int32> rewardGetList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> rewardGetListList {
 get { return pbc::Lists.AsReadOnly(rewardGetList_); }
 }
 
 public int rewardGetListCount {
 get { return rewardGetList_.Count; }
 }
 
public Int32 GetRewardGetList(int index) {
 return rewardGetList_[index];
 }
 public void AddRewardGetList(Int32 value) {
 rewardGetList_.Add(value);
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
{
int dataSize = 0;
foreach (Int32 element in rewardGetListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * rewardGetList_.Count;
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
{
if (rewardGetList_.Count > 0) {
foreach (Int32 element in rewardGetListList) {
output.WriteInt32(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTreeDayRewardBack _inst = (GCTreeDayRewardBack) _base;
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
 _inst.AddRewardGetList(input.ReadInt32());
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
public class HatchEggInfo : PacketDistributed
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

public const int time2JintiaoFieldNumber = 2;
 private bool hasTime2Jintiao;
 private string time2Jintiao_ = "";
 public bool HasTime2Jintiao {
 get { return hasTime2Jintiao; }
 }
 public string Time2Jintiao {
 get { return time2Jintiao_; }
 set { SetTime2Jintiao(value); }
 }
 public void SetTime2Jintiao(string value) { 
 hasTime2Jintiao = true;
 time2Jintiao_ = value;
 }

public const int needItemsFieldNumber = 3;
 private pbc::PopsicleList<Iteminfo> needItems_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> needItemsList {
 get { return pbc::Lists.AsReadOnly(needItems_); }
 }
 
 public int needItemsCount {
 get { return needItems_.Count; }
 }
 
public Iteminfo GetNeedItems(int index) {
 return needItems_[index];
 }
 public void AddNeedItems(Iteminfo value) {
 needItems_.Add(value);
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
 if (HasTime2Jintiao) {
size += pb::CodedOutputStream.ComputeStringSize(2, Time2Jintiao);
}
{
foreach (Iteminfo element in needItemsList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}
 
if (HasTime2Jintiao) {
output.WriteString(2, Time2Jintiao);
}

do{
foreach (Iteminfo element in needItemsList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 HatchEggInfo _inst = (HatchEggInfo) _base;
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
 _inst.Time2Jintiao = input.ReadString();
break;
}
    case  26: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddNeedItems(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Iteminfo element in needItemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class NewYearLuckyDrawHistory : PacketDistributed
{

public const int timeFieldNumber = 1;
 private bool hasTime;
 private Int64 time_ = 0;
 public bool HasTime {
 get { return hasTime; }
 }
 public Int64 Time {
 get { return time_; }
 set { SetTime(value); }
 }
 public void SetTime(Int64 value) { 
 hasTime = true;
 time_ = value;
 }

public const int itemInfoFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Time);
}
{
int subsize = ItemInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTime) {
output.WriteInt64(1, Time);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
ItemInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NewYearLuckyDrawHistory _inst = (NewYearLuckyDrawHistory) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Time = input.ReadInt64();
break;
}
    case  18: {
Iteminfo subBuilder =  new Iteminfo();
 input.ReadMessage(subBuilder);
_inst.ItemInfo = subBuilder;
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


[Serializable]
public class OpActivityInfo : PacketDistributed
{

public const int btypeFieldNumber = 1;
 private bool hasBtype;
 private Int32 btype_ = 0;
 public bool HasBtype {
 get { return hasBtype; }
 }
 public Int32 Btype {
 get { return btype_; }
 set { SetBtype(value); }
 }
 public void SetBtype(Int32 value) { 
 hasBtype = true;
 btype_ = value;
 }

public const int stypeFieldNumber = 2;
 private bool hasStype;
 private Int32 stype_ = 0;
 public bool HasStype {
 get { return hasStype; }
 }
 public Int32 Stype {
 get { return stype_; }
 set { SetStype(value); }
 }
 public void SetStype(Int32 value) { 
 hasStype = true;
 stype_ = value;
 }

public const int flagFieldNumber = 3;
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

public const int remainTimeFieldNumber = 4;
 private bool hasRemainTime;
 private Int64 remainTime_ = 0;
 public bool HasRemainTime {
 get { return hasRemainTime; }
 }
 public Int64 RemainTime {
 get { return remainTime_; }
 set { SetRemainTime(value); }
 }
 public void SetRemainTime(Int64 value) { 
 hasRemainTime = true;
 remainTime_ = value;
 }

public const int startTimeFieldNumber = 5;
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

public const int endTimeFieldNumber = 6;
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

public const int actIdFieldNumber = 7;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBtype) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Btype);
}
 if (HasStype) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Stype);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Flag);
}
 if (HasRemainTime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, RemainTime);
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, StartTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, EndTime);
}
 if (HasActId) {
size += pb::CodedOutputStream.ComputeInt32Size(7, ActId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBtype) {
output.WriteInt32(1, Btype);
}
 
if (HasStype) {
output.WriteInt32(2, Stype);
}
 
if (HasFlag) {
output.WriteInt32(3, Flag);
}
 
if (HasRemainTime) {
output.WriteInt64(4, RemainTime);
}
 
if (HasStartTime) {
output.WriteInt64(5, StartTime);
}
 
if (HasEndTime) {
output.WriteInt64(6, EndTime);
}
 
if (HasActId) {
output.WriteInt32(7, ActId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 OpActivityInfo _inst = (OpActivityInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Btype = input.ReadInt32();
break;
}
   case  16: {
 _inst.Stype = input.ReadInt32();
break;
}
   case  24: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  32: {
 _inst.RemainTime = input.ReadInt64();
break;
}
   case  40: {
 _inst.StartTime = input.ReadInt64();
break;
}
   case  48: {
 _inst.EndTime = input.ReadInt64();
break;
}
   case  56: {
 _inst.ActId = input.ReadInt32();
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
public class PlayerSweetDice : PacketDistributed
{

public const int typeIdFieldNumber = 1;
 private bool hasTypeId;
 private Int32 typeId_ = 0;
 public bool HasTypeId {
 get { return hasTypeId; }
 }
 public Int32 TypeId {
 get { return typeId_; }
 set { SetTypeId(value); }
 }
 public void SetTypeId(Int32 value) { 
 hasTypeId = true;
 typeId_ = value;
 }

public const int posIdFieldNumber = 2;
 private bool hasPosId;
 private Int32 posId_ = 0;
 public bool HasPosId {
 get { return hasPosId; }
 }
 public Int32 PosId {
 get { return posId_; }
 set { SetPosId(value); }
 }
 public void SetPosId(Int32 value) { 
 hasPosId = true;
 posId_ = value;
 }

public const int freeTimesFieldNumber = 3;
 private bool hasFreeTimes;
 private Int32 freeTimes_ = 0;
 public bool HasFreeTimes {
 get { return hasFreeTimes; }
 }
 public Int32 FreeTimes {
 get { return freeTimes_; }
 set { SetFreeTimes(value); }
 }
 public void SetFreeTimes(Int32 value) { 
 hasFreeTimes = true;
 freeTimes_ = value;
 }

public const int sweetDiceNumFieldNumber = 4;
 private bool hasSweetDiceNum;
 private Int32 sweetDiceNum_ = 0;
 public bool HasSweetDiceNum {
 get { return hasSweetDiceNum; }
 }
 public Int32 SweetDiceNum {
 get { return sweetDiceNum_; }
 set { SetSweetDiceNum(value); }
 }
 public void SetSweetDiceNum(Int32 value) { 
 hasSweetDiceNum = true;
 sweetDiceNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTypeId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TypeId);
}
 if (HasPosId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PosId);
}
 if (HasFreeTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(3, FreeTimes);
}
 if (HasSweetDiceNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, SweetDiceNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTypeId) {
output.WriteInt32(1, TypeId);
}
 
if (HasPosId) {
output.WriteInt32(2, PosId);
}
 
if (HasFreeTimes) {
output.WriteInt32(3, FreeTimes);
}
 
if (HasSweetDiceNum) {
output.WriteInt32(4, SweetDiceNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PlayerSweetDice _inst = (PlayerSweetDice) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TypeId = input.ReadInt32();
break;
}
   case  16: {
 _inst.PosId = input.ReadInt32();
break;
}
   case  24: {
 _inst.FreeTimes = input.ReadInt32();
break;
}
   case  32: {
 _inst.SweetDiceNum = input.ReadInt32();
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
public class RedBagInfo : PacketDistributed
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

public const int statusFieldNumber = 2;
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

public const int createTimeFieldNumber = 3;
 private bool hasCreateTime;
 private Int64 createTime_ = 0;
 public bool HasCreateTime {
 get { return hasCreateTime; }
 }
 public Int64 CreateTime {
 get { return createTime_; }
 set { SetCreateTime(value); }
 }
 public void SetCreateTime(Int64 value) { 
 hasCreateTime = true;
 createTime_ = value;
 }

public const int expiryTimeFieldNumber = 4;
 private bool hasExpiryTime;
 private Int64 expiryTime_ = 0;
 public bool HasExpiryTime {
 get { return hasExpiryTime; }
 }
 public Int64 ExpiryTime {
 get { return expiryTime_; }
 set { SetExpiryTime(value); }
 }
 public void SetExpiryTime(Int64 value) { 
 hasExpiryTime = true;
 expiryTime_ = value;
 }

public const int rewardArrFieldNumber = 5;
 private pbc::PopsicleList<Iteminfo> rewardArr_ = new pbc::PopsicleList<Iteminfo>();
 public scg::IList<Iteminfo> rewardArrList {
 get { return pbc::Lists.AsReadOnly(rewardArr_); }
 }
 
 public int rewardArrCount {
 get { return rewardArr_.Count; }
 }
 
public Iteminfo GetRewardArr(int index) {
 return rewardArr_[index];
 }
 public void AddRewardArr(Iteminfo value) {
 rewardArr_.Add(value);
 }

public const int nameFieldNumber = 6;
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

public const int titleFieldNumber = 7;
 private bool hasTitle;
 private string title_ = "";
 public bool HasTitle {
 get { return hasTitle; }
 }
 public string Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(string value) { 
 hasTitle = true;
 title_ = value;
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 if (HasCreateTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, CreateTime);
}
 if (HasExpiryTime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, ExpiryTime);
}
{
foreach (Iteminfo element in rewardArrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(6, Name);
}
 if (HasTitle) {
size += pb::CodedOutputStream.ComputeStringSize(7, Title);
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 
if (HasCreateTime) {
output.WriteInt64(3, CreateTime);
}
 
if (HasExpiryTime) {
output.WriteInt64(4, ExpiryTime);
}

do{
foreach (Iteminfo element in rewardArrList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasName) {
output.WriteString(6, Name);
}
 
if (HasTitle) {
output.WriteString(7, Title);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RedBagInfo _inst = (RedBagInfo) _base;
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
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.CreateTime = input.ReadInt64();
break;
}
   case  32: {
 _inst.ExpiryTime = input.ReadInt64();
break;
}
    case  42: {
Iteminfo subBuilder =  new Iteminfo();
input.ReadMessage(subBuilder);
_inst.AddRewardArr(subBuilder);
break;
}
   case  50: {
 _inst.Name = input.ReadString();
break;
}
   case  58: {
 _inst.Title = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (Iteminfo element in rewardArrList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SweetDiceInfo : PacketDistributed
{

public const int typeIdFieldNumber = 1;
 private bool hasTypeId;
 private Int32 typeId_ = 0;
 public bool HasTypeId {
 get { return hasTypeId; }
 }
 public Int32 TypeId {
 get { return typeId_; }
 set { SetTypeId(value); }
 }
 public void SetTypeId(Int32 value) { 
 hasTypeId = true;
 typeId_ = value;
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

public const int needmoneyFieldNumber = 3;
 private bool hasNeedmoney;
 private string needmoney_ = "";
 public bool HasNeedmoney {
 get { return hasNeedmoney; }
 }
 public string Needmoney {
 get { return needmoney_; }
 set { SetNeedmoney(value); }
 }
 public void SetNeedmoney(string value) { 
 hasNeedmoney = true;
 needmoney_ = value;
 }

public const int tenneedmoneyFieldNumber = 4;
 private bool hasTenneedmoney;
 private string tenneedmoney_ = "";
 public bool HasTenneedmoney {
 get { return hasTenneedmoney; }
 }
 public string Tenneedmoney {
 get { return tenneedmoney_; }
 set { SetTenneedmoney(value); }
 }
 public void SetTenneedmoney(string value) { 
 hasTenneedmoney = true;
 tenneedmoney_ = value;
 }

public const int itemshowFieldNumber = 5;
 private bool hasItemshow;
 private string itemshow_ = "";
 public bool HasItemshow {
 get { return hasItemshow; }
 }
 public string Itemshow {
 get { return itemshow_; }
 set { SetItemshow(value); }
 }
 public void SetItemshow(string value) { 
 hasItemshow = true;
 itemshow_ = value;
 }

public const int modelFieldNumber = 6;
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

public const int scaleFieldNumber = 7;
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

public const int rotateFieldNumber = 8;
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

public const int positionFieldNumber = 9;
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

public const int noticetxtFieldNumber = 10;
 private bool hasNoticetxt;
 private string noticetxt_ = "";
 public bool HasNoticetxt {
 get { return hasNoticetxt; }
 }
 public string Noticetxt {
 get { return noticetxt_; }
 set { SetNoticetxt(value); }
 }
 public void SetNoticetxt(string value) { 
 hasNoticetxt = true;
 noticetxt_ = value;
 }

public const int iconNameFieldNumber = 11;
 private bool hasIconName;
 private string iconName_ = "";
 public bool HasIconName {
 get { return hasIconName; }
 }
 public string IconName {
 get { return iconName_; }
 set { SetIconName(value); }
 }
 public void SetIconName(string value) { 
 hasIconName = true;
 iconName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTypeId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TypeId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasNeedmoney) {
size += pb::CodedOutputStream.ComputeStringSize(3, Needmoney);
}
 if (HasTenneedmoney) {
size += pb::CodedOutputStream.ComputeStringSize(4, Tenneedmoney);
}
 if (HasItemshow) {
size += pb::CodedOutputStream.ComputeStringSize(5, Itemshow);
}
 if (HasModel) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Model);
}
 if (HasScale) {
size += pb::CodedOutputStream.ComputeStringSize(7, Scale);
}
 if (HasRotate) {
size += pb::CodedOutputStream.ComputeStringSize(8, Rotate);
}
 if (HasPosition) {
size += pb::CodedOutputStream.ComputeStringSize(9, Position);
}
 if (HasNoticetxt) {
size += pb::CodedOutputStream.ComputeStringSize(10, Noticetxt);
}
 if (HasIconName) {
size += pb::CodedOutputStream.ComputeStringSize(11, IconName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTypeId) {
output.WriteInt32(1, TypeId);
}
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasNeedmoney) {
output.WriteString(3, Needmoney);
}
 
if (HasTenneedmoney) {
output.WriteString(4, Tenneedmoney);
}
 
if (HasItemshow) {
output.WriteString(5, Itemshow);
}
 
if (HasModel) {
output.WriteInt32(6, Model);
}
 
if (HasScale) {
output.WriteString(7, Scale);
}
 
if (HasRotate) {
output.WriteString(8, Rotate);
}
 
if (HasPosition) {
output.WriteString(9, Position);
}
 
if (HasNoticetxt) {
output.WriteString(10, Noticetxt);
}
 
if (HasIconName) {
output.WriteString(11, IconName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SweetDiceInfo _inst = (SweetDiceInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TypeId = input.ReadInt32();
break;
}
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  26: {
 _inst.Needmoney = input.ReadString();
break;
}
   case  34: {
 _inst.Tenneedmoney = input.ReadString();
break;
}
   case  42: {
 _inst.Itemshow = input.ReadString();
break;
}
   case  48: {
 _inst.Model = input.ReadInt32();
break;
}
   case  58: {
 _inst.Scale = input.ReadString();
break;
}
   case  66: {
 _inst.Rotate = input.ReadString();
break;
}
   case  74: {
 _inst.Position = input.ReadString();
break;
}
   case  82: {
 _inst.Noticetxt = input.ReadString();
break;
}
   case  90: {
 _inst.IconName = input.ReadString();
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
public class TreeInfo : PacketDistributed
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

public const int needGrowthFieldNumber = 2;
 private bool hasNeedGrowth;
 private Int32 needGrowth_ = 0;
 public bool HasNeedGrowth {
 get { return hasNeedGrowth; }
 }
 public Int32 NeedGrowth {
 get { return needGrowth_; }
 set { SetNeedGrowth(value); }
 }
 public void SetNeedGrowth(Int32 value) { 
 hasNeedGrowth = true;
 needGrowth_ = value;
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

public const int treeNPCFieldNumber = 4;
 private bool hasTreeNPC;
 private Int32 treeNPC_ = 0;
 public bool HasTreeNPC {
 get { return hasTreeNPC; }
 }
 public Int32 TreeNPC {
 get { return treeNPC_; }
 set { SetTreeNPC(value); }
 }
 public void SetTreeNPC(Int32 value) { 
 hasTreeNPC = true;
 treeNPC_ = value;
 }

public const int treeNameFieldNumber = 5;
 private bool hasTreeName;
 private string treeName_ = "";
 public bool HasTreeName {
 get { return hasTreeName; }
 }
 public string TreeName {
 get { return treeName_; }
 set { SetTreeName(value); }
 }
 public void SetTreeName(string value) { 
 hasTreeName = true;
 treeName_ = value;
 }

public const int sceneIdFieldNumber = 6;
 private bool hasSceneId;
 private Int32 sceneId_ = 0;
 public bool HasSceneId {
 get { return hasSceneId; }
 }
 public Int32 SceneId {
 get { return sceneId_; }
 set { SetSceneId(value); }
 }
 public void SetSceneId(Int32 value) { 
 hasSceneId = true;
 sceneId_ = value;
 }

public const int posFieldNumber = 7;
 private bool hasPos;
 private string pos_ = "";
 public bool HasPos {
 get { return hasPos; }
 }
 public string Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(string value) { 
 hasPos = true;
 pos_ = value;
 }

public const int scalingFieldNumber = 8;
 private bool hasScaling;
 private string scaling_ = "";
 public bool HasScaling {
 get { return hasScaling; }
 }
 public string Scaling {
 get { return scaling_; }
 set { SetScaling(value); }
 }
 public void SetScaling(string value) { 
 hasScaling = true;
 scaling_ = value;
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
 if (HasNeedGrowth) {
size += pb::CodedOutputStream.ComputeInt32Size(2, NeedGrowth);
}
 if (HasRewardInfo) {
size += pb::CodedOutputStream.ComputeStringSize(3, RewardInfo);
}
 if (HasTreeNPC) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TreeNPC);
}
 if (HasTreeName) {
size += pb::CodedOutputStream.ComputeStringSize(5, TreeName);
}
 if (HasSceneId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, SceneId);
}
 if (HasPos) {
size += pb::CodedOutputStream.ComputeStringSize(7, Pos);
}
 if (HasScaling) {
size += pb::CodedOutputStream.ComputeStringSize(8, Scaling);
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
 
if (HasNeedGrowth) {
output.WriteInt32(2, NeedGrowth);
}
 
if (HasRewardInfo) {
output.WriteString(3, RewardInfo);
}
 
if (HasTreeNPC) {
output.WriteInt32(4, TreeNPC);
}
 
if (HasTreeName) {
output.WriteString(5, TreeName);
}
 
if (HasSceneId) {
output.WriteInt32(6, SceneId);
}
 
if (HasPos) {
output.WriteString(7, Pos);
}
 
if (HasScaling) {
output.WriteString(8, Scaling);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TreeInfo _inst = (TreeInfo) _base;
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
 _inst.NeedGrowth = input.ReadInt32();
break;
}
   case  26: {
 _inst.RewardInfo = input.ReadString();
break;
}
   case  32: {
 _inst.TreeNPC = input.ReadInt32();
break;
}
   case  42: {
 _inst.TreeName = input.ReadString();
break;
}
   case  48: {
 _inst.SceneId = input.ReadInt32();
break;
}
   case  58: {
 _inst.Pos = input.ReadString();
break;
}
   case  66: {
 _inst.Scaling = input.ReadString();
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
public class TreeToolInfo : PacketDistributed
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

public const int iconFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasIcon) {
size += pb::CodedOutputStream.ComputeStringSize(2, Icon);
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
 
if (HasIcon) {
output.WriteString(2, Icon);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TreeToolInfo _inst = (TreeToolInfo) _base;
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
 _inst.Icon = input.ReadString();
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
