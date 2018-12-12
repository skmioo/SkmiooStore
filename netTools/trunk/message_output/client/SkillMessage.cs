//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class BuffImpactInfo : PacketDistributed
{

public const int buffGuidFieldNumber = 1;
 private bool hasBuffGuid;
 private Int64 buffGuid_ = 0;
 public bool HasBuffGuid {
 get { return hasBuffGuid; }
 }
 public Int64 BuffGuid {
 get { return buffGuid_; }
 set { SetBuffGuid(value); }
 }
 public void SetBuffGuid(Int64 value) { 
 hasBuffGuid = true;
 buffGuid_ = value;
 }

public const int impactIdFieldNumber = 2;
 private bool hasImpactId;
 private Int32 impactId_ = 0;
 public bool HasImpactId {
 get { return hasImpactId; }
 }
 public Int32 ImpactId {
 get { return impactId_; }
 set { SetImpactId(value); }
 }
 public void SetImpactId(Int32 value) { 
 hasImpactId = true;
 impactId_ = value;
 }

public const int restTimeFieldNumber = 3;
 private bool hasRestTime;
 private Int32 restTime_ = 0;
 public bool HasRestTime {
 get { return hasRestTime; }
 }
 public Int32 RestTime {
 get { return restTime_; }
 set { SetRestTime(value); }
 }
 public void SetRestTime(Int32 value) { 
 hasRestTime = true;
 restTime_ = value;
 }

public const int paramsFieldNumber = 4;
 private pbc::PopsicleList<Int32> params_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> paramsList {
 get { return pbc::Lists.AsReadOnly(params_); }
 }
 
 public int paramsCount {
 get { return params_.Count; }
 }
 
public Int32 GetParams(int index) {
 return params_[index];
 }
 public void AddParams(Int32 value) {
 params_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBuffGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, BuffGuid);
}
 if (HasImpactId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ImpactId);
}
 if (HasRestTime) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RestTime);
}
{
int dataSize = 0;
foreach (Int32 element in paramsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * params_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBuffGuid) {
output.WriteInt64(1, BuffGuid);
}
 
if (HasImpactId) {
output.WriteInt32(2, ImpactId);
}
 
if (HasRestTime) {
output.WriteInt32(3, RestTime);
}
{
if (params_.Count > 0) {
foreach (Int32 element in paramsList) {
output.WriteInt32(4,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BuffImpactInfo _inst = (BuffImpactInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.BuffGuid = input.ReadInt64();
break;
}
   case  16: {
 _inst.ImpactId = input.ReadInt32();
break;
}
   case  24: {
 _inst.RestTime = input.ReadInt32();
break;
}
   case  32: {
 _inst.AddParams(input.ReadInt32());
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
public class CGChangeSkill : PacketDistributed
{

public const int skillIdFieldNumber = 1;
 private bool hasSkillId;
 private Int32 skillId_ = 0;
 public bool HasSkillId {
 get { return hasSkillId; }
 }
 public Int32 SkillId {
 get { return skillId_; }
 set { SetSkillId(value); }
 }
 public void SetSkillId(Int32 value) { 
 hasSkillId = true;
 skillId_ = value;
 }

public const int positionFieldNumber = 2;
 private bool hasPosition;
 private Int32 position_ = 0;
 public bool HasPosition {
 get { return hasPosition; }
 }
 public Int32 Position {
 get { return position_; }
 set { SetPosition(value); }
 }
 public void SetPosition(Int32 value) { 
 hasPosition = true;
 position_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSkillId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SkillId);
}
 if (HasPosition) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Position);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSkillId) {
output.WriteInt32(1, SkillId);
}
 
if (HasPosition) {
output.WriteInt32(2, Position);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGChangeSkill _inst = (CGChangeSkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SkillId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Position = input.ReadInt32();
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
public class CGRefreshBuff : PacketDistributed
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
 CGRefreshBuff _inst = (CGRefreshBuff) _base;
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
public class CGUpSkill : PacketDistributed
{

public const int skillIdFieldNumber = 1;
 private bool hasSkillId;
 private Int32 skillId_ = 0;
 public bool HasSkillId {
 get { return hasSkillId; }
 }
 public Int32 SkillId {
 get { return skillId_; }
 set { SetSkillId(value); }
 }
 public void SetSkillId(Int32 value) { 
 hasSkillId = true;
 skillId_ = value;
 }

public const int flagallFieldNumber = 2;
 private bool hasFlagall;
 private Int32 flagall_ = 0;
 public bool HasFlagall {
 get { return hasFlagall; }
 }
 public Int32 Flagall {
 get { return flagall_; }
 set { SetFlagall(value); }
 }
 public void SetFlagall(Int32 value) { 
 hasFlagall = true;
 flagall_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSkillId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SkillId);
}
 if (HasFlagall) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flagall);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSkillId) {
output.WriteInt32(1, SkillId);
}
 
if (HasFlagall) {
output.WriteInt32(2, Flagall);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUpSkill _inst = (CGUpSkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SkillId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Flagall = input.ReadInt32();
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
public class CGUseSkill : PacketDistributed
{

public const int skillIdFieldNumber = 1;
 private bool hasSkillId;
 private Int32 skillId_ = 0;
 public bool HasSkillId {
 get { return hasSkillId; }
 }
 public Int32 SkillId {
 get { return skillId_; }
 set { SetSkillId(value); }
 }
 public void SetSkillId(Int32 value) { 
 hasSkillId = true;
 skillId_ = value;
 }

public const int skillIndexFieldNumber = 2;
 private bool hasSkillIndex;
 private Int32 skillIndex_ = 0;
 public bool HasSkillIndex {
 get { return hasSkillIndex; }
 }
 public Int32 SkillIndex {
 get { return skillIndex_; }
 set { SetSkillIndex(value); }
 }
 public void SetSkillIndex(Int32 value) { 
 hasSkillIndex = true;
 skillIndex_ = value;
 }

public const int attackerPosFieldNumber = 3;
 private bool hasAttackerPos;
 private Vector3Info attackerPos_ =  new Vector3Info();
 public bool HasAttackerPos {
 get { return hasAttackerPos; }
 }
 public Vector3Info AttackerPos {
 get { return attackerPos_; }
 set { SetAttackerPos(value); }
 }
 public void SetAttackerPos(Vector3Info value) { 
 hasAttackerPos = true;
 attackerPos_ = value;
 }

public const int targetObjIdsFieldNumber = 4;
 private pbc::PopsicleList<Int64> targetObjIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> targetObjIdsList {
 get { return pbc::Lists.AsReadOnly(targetObjIds_); }
 }
 
 public int targetObjIdsCount {
 get { return targetObjIds_.Count; }
 }
 
public Int64 GetTargetObjIds(int index) {
 return targetObjIds_[index];
 }
 public void AddTargetObjIds(Int64 value) {
 targetObjIds_.Add(value);
 }

public const int clientStartTimeFieldNumber = 5;
 private bool hasClientStartTime;
 private Int64 clientStartTime_ = 0;
 public bool HasClientStartTime {
 get { return hasClientStartTime; }
 }
 public Int64 ClientStartTime {
 get { return clientStartTime_; }
 set { SetClientStartTime(value); }
 }
 public void SetClientStartTime(Int64 value) { 
 hasClientStartTime = true;
 clientStartTime_ = value;
 }

public const int attackerDirectionFieldNumber = 6;
 private bool hasAttackerDirection;
 private Vector3Info attackerDirection_ =  new Vector3Info();
 public bool HasAttackerDirection {
 get { return hasAttackerDirection; }
 }
 public Vector3Info AttackerDirection {
 get { return attackerDirection_; }
 set { SetAttackerDirection(value); }
 }
 public void SetAttackerDirection(Vector3Info value) { 
 hasAttackerDirection = true;
 attackerDirection_ = value;
 }

public const int attackerIdFieldNumber = 7;
 private bool hasAttackerId;
 private Int64 attackerId_ = 0;
 public bool HasAttackerId {
 get { return hasAttackerId; }
 }
 public Int64 AttackerId {
 get { return attackerId_; }
 set { SetAttackerId(value); }
 }
 public void SetAttackerId(Int64 value) { 
 hasAttackerId = true;
 attackerId_ = value;
 }

public const int targetPosFieldNumber = 8;
 private bool hasTargetPos;
 private Vector3Info targetPos_ =  new Vector3Info();
 public bool HasTargetPos {
 get { return hasTargetPos; }
 }
 public Vector3Info TargetPos {
 get { return targetPos_; }
 set { SetTargetPos(value); }
 }
 public void SetTargetPos(Vector3Info value) { 
 hasTargetPos = true;
 targetPos_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSkillId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SkillId);
}
 if (HasSkillIndex) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SkillIndex);
}
{
int subsize = AttackerPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int dataSize = 0;
foreach (Int64 element in targetObjIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * targetObjIds_.Count;
}
 if (HasClientStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, ClientStartTime);
}
{
int subsize = AttackerDirection.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasAttackerId) {
size += pb::CodedOutputStream.ComputeInt64Size(7, AttackerId);
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSkillId) {
output.WriteInt32(1, SkillId);
}
 
if (HasSkillIndex) {
output.WriteInt32(2, SkillIndex);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)AttackerPos.SerializedSize());
AttackerPos.WriteTo(output);

}
{
if (targetObjIds_.Count > 0) {
foreach (Int64 element in targetObjIdsList) {
output.WriteInt64(4,element);
}
}

}
 
if (HasClientStartTime) {
output.WriteInt64(5, ClientStartTime);
}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)AttackerDirection.SerializedSize());
AttackerDirection.WriteTo(output);

}
 
if (HasAttackerId) {
output.WriteInt64(7, AttackerId);
}
{
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUseSkill _inst = (CGUseSkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SkillId = input.ReadInt32();
break;
}
   case  16: {
 _inst.SkillIndex = input.ReadInt32();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.AttackerPos = subBuilder;
break;
}
   case  32: {
 _inst.AddTargetObjIds(input.ReadInt64());
break;
}
   case  40: {
 _inst.ClientStartTime = input.ReadInt64();
break;
}
    case  50: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.AttackerDirection = subBuilder;
break;
}
   case  56: {
 _inst.AttackerId = input.ReadInt64();
break;
}
    case  66: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasAttackerPos) {
if (!AttackerPos.IsInitialized()) return false;
}
  if (HasAttackerDirection) {
if (!AttackerDirection.IsInitialized()) return false;
}
  if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CombatResult : PacketDistributed
{

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

public const int valueFieldNumber = 3;
 private bool hasValue;
 private Int32 value_ = 0;
 public bool HasValue {
 get { return hasValue; }
 }
 public Int32 Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(Int32 value) { 
 hasValue = true;
 value_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Value);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasValue) {
output.WriteInt32(3, Value);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CombatResult _inst = (CombatResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Value = input.ReadInt32();
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
public class GCAddBuffImpact : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int buffsFieldNumber = 2;
 private pbc::PopsicleList<BuffImpactInfo> buffs_ = new pbc::PopsicleList<BuffImpactInfo>();
 public scg::IList<BuffImpactInfo> buffsList {
 get { return pbc::Lists.AsReadOnly(buffs_); }
 }
 
 public int buffsCount {
 get { return buffs_.Count; }
 }
 
public BuffImpactInfo GetBuffs(int index) {
 return buffs_[index];
 }
 public void AddBuffs(BuffImpactInfo value) {
 buffs_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
{
foreach (BuffImpactInfo element in buffsList) {
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
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}

do{
foreach (BuffImpactInfo element in buffsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAddBuffImpact _inst = (GCAddBuffImpact) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
    case  18: {
BuffImpactInfo subBuilder =  new BuffImpactInfo();
input.ReadMessage(subBuilder);
_inst.AddBuffs(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BuffImpactInfo element in buffsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCChangeMotion : PacketDistributed
{

public const int motionIdFieldNumber = 1;
 private bool hasMotionId;
 private Int32 motionId_ = 0;
 public bool HasMotionId {
 get { return hasMotionId; }
 }
 public Int32 MotionId {
 get { return motionId_; }
 set { SetMotionId(value); }
 }
 public void SetMotionId(Int32 value) { 
 hasMotionId = true;
 motionId_ = value;
 }

public const int objIdFieldNumber = 2;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int effectIdFieldNumber = 3;
 private bool hasEffectId;
 private string effectId_ = "";
 public bool HasEffectId {
 get { return hasEffectId; }
 }
 public string EffectId {
 get { return effectId_; }
 set { SetEffectId(value); }
 }
 public void SetEffectId(string value) { 
 hasEffectId = true;
 effectId_ = value;
 }

public const int atkIdFieldNumber = 4;
 private bool hasAtkId;
 private Int64 atkId_ = 0;
 public bool HasAtkId {
 get { return hasAtkId; }
 }
 public Int64 AtkId {
 get { return atkId_; }
 set { SetAtkId(value); }
 }
 public void SetAtkId(Int64 value) { 
 hasAtkId = true;
 atkId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMotionId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MotionId);
}
 if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ObjId);
}
 if (HasEffectId) {
size += pb::CodedOutputStream.ComputeStringSize(3, EffectId);
}
 if (HasAtkId) {
size += pb::CodedOutputStream.ComputeInt64Size(4, AtkId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMotionId) {
output.WriteInt32(1, MotionId);
}
 
if (HasObjId) {
output.WriteInt64(2, ObjId);
}
 
if (HasEffectId) {
output.WriteString(3, EffectId);
}
 
if (HasAtkId) {
output.WriteInt64(4, AtkId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChangeMotion _inst = (GCChangeMotion) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MotionId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  26: {
 _inst.EffectId = input.ReadString();
break;
}
   case  32: {
 _inst.AtkId = input.ReadInt64();
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
public class GCChangeSkillOK : PacketDistributed
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

public const int skilldataFieldNumber = 2;
 private pbc::PopsicleList<SkillItemData> skilldata_ = new pbc::PopsicleList<SkillItemData>();
 public scg::IList<SkillItemData> skilldataList {
 get { return pbc::Lists.AsReadOnly(skilldata_); }
 }
 
 public int skilldataCount {
 get { return skilldata_.Count; }
 }
 
public SkillItemData GetSkilldata(int index) {
 return skilldata_[index];
 }
 public void AddSkilldata(SkillItemData value) {
 skilldata_.Add(value);
 }

public const int skillFlagFieldNumber = 3;
 private bool hasSkillFlag;
 private Int32 skillFlag_ = 0;
 public bool HasSkillFlag {
 get { return hasSkillFlag; }
 }
 public Int32 SkillFlag {
 get { return skillFlag_; }
 set { SetSkillFlag(value); }
 }
 public void SetSkillFlag(Int32 value) { 
 hasSkillFlag = true;
 skillFlag_ = value;
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
{
foreach (SkillItemData element in skilldataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSkillFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SkillFlag);
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

do{
foreach (SkillItemData element in skilldataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSkillFlag) {
output.WriteInt32(3, SkillFlag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChangeSkillOK _inst = (GCChangeSkillOK) _base;
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
    case  18: {
SkillItemData subBuilder =  new SkillItemData();
input.ReadMessage(subBuilder);
_inst.AddSkilldata(subBuilder);
break;
}
   case  24: {
 _inst.SkillFlag = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SkillItemData element in skilldataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCombatResult : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int resultFieldNumber = 2;
 private pbc::PopsicleList<CombatResult> result_ = new pbc::PopsicleList<CombatResult>();
 public scg::IList<CombatResult> resultList {
 get { return pbc::Lists.AsReadOnly(result_); }
 }
 
 public int resultCount {
 get { return result_.Count; }
 }
 
public CombatResult GetResult(int index) {
 return result_[index];
 }
 public void AddResult(CombatResult value) {
 result_.Add(value);
 }

public const int srcObjIdFieldNumber = 3;
 private bool hasSrcObjId;
 private Int64 srcObjId_ = 0;
 public bool HasSrcObjId {
 get { return hasSrcObjId; }
 }
 public Int64 SrcObjId {
 get { return srcObjId_; }
 set { SetSrcObjId(value); }
 }
 public void SetSrcObjId(Int64 value) { 
 hasSrcObjId = true;
 srcObjId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
{
foreach (CombatResult element in resultList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSrcObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, SrcObjId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}

do{
foreach (CombatResult element in resultList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSrcObjId) {
output.WriteInt64(3, SrcObjId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCombatResult _inst = (GCCombatResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
    case  18: {
CombatResult subBuilder =  new CombatResult();
input.ReadMessage(subBuilder);
_inst.AddResult(subBuilder);
break;
}
   case  24: {
 _inst.SrcObjId = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CombatResult element in resultList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDelBuffImpact : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int buffGuidsFieldNumber = 2;
 private pbc::PopsicleList<Int64> buffGuids_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> buffGuidsList {
 get { return pbc::Lists.AsReadOnly(buffGuids_); }
 }
 
 public int buffGuidsCount {
 get { return buffGuids_.Count; }
 }
 
public Int64 GetBuffGuids(int index) {
 return buffGuids_[index];
 }
 public void AddBuffGuids(Int64 value) {
 buffGuids_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
{
int dataSize = 0;
foreach (Int64 element in buffGuidsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * buffGuids_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
{
if (buffGuids_.Count > 0) {
foreach (Int64 element in buffGuidsList) {
output.WriteInt64(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDelBuffImpact _inst = (GCDelBuffImpact) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  16: {
 _inst.AddBuffGuids(input.ReadInt64());
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
public class GCRefreshBuffBack : PacketDistributed
{

public const int buffsFieldNumber = 1;
 private pbc::PopsicleList<BuffImpactInfo> buffs_ = new pbc::PopsicleList<BuffImpactInfo>();
 public scg::IList<BuffImpactInfo> buffsList {
 get { return pbc::Lists.AsReadOnly(buffs_); }
 }
 
 public int buffsCount {
 get { return buffs_.Count; }
 }
 
public BuffImpactInfo GetBuffs(int index) {
 return buffs_[index];
 }
 public void AddBuffs(BuffImpactInfo value) {
 buffs_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (BuffImpactInfo element in buffsList) {
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
foreach (BuffImpactInfo element in buffsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshBuffBack _inst = (GCRefreshBuffBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BuffImpactInfo subBuilder =  new BuffImpactInfo();
input.ReadMessage(subBuilder);
_inst.AddBuffs(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BuffImpactInfo element in buffsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshSkillCDInfo : PacketDistributed
{

public const int cdInfoFieldNumber = 1;
 private pbc::PopsicleList<SkillCDInfo> cdInfo_ = new pbc::PopsicleList<SkillCDInfo>();
 public scg::IList<SkillCDInfo> cdInfoList {
 get { return pbc::Lists.AsReadOnly(cdInfo_); }
 }
 
 public int cdInfoCount {
 get { return cdInfo_.Count; }
 }
 
public SkillCDInfo GetCdInfo(int index) {
 return cdInfo_[index];
 }
 public void AddCdInfo(SkillCDInfo value) {
 cdInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (SkillCDInfo element in cdInfoList) {
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
foreach (SkillCDInfo element in cdInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshSkillCDInfo _inst = (GCRefreshSkillCDInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
SkillCDInfo subBuilder =  new SkillCDInfo();
input.ReadMessage(subBuilder);
_inst.AddCdInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SkillCDInfo element in cdInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTriggerMotion : PacketDistributed
{

public const int motionIdFieldNumber = 1;
 private bool hasMotionId;
 private Int32 motionId_ = 0;
 public bool HasMotionId {
 get { return hasMotionId; }
 }
 public Int32 MotionId {
 get { return motionId_; }
 set { SetMotionId(value); }
 }
 public void SetMotionId(Int32 value) { 
 hasMotionId = true;
 motionId_ = value;
 }

public const int targetIdFieldNumber = 2;
 private bool hasTargetId;
 private Int64 targetId_ = 0;
 public bool HasTargetId {
 get { return hasTargetId; }
 }
 public Int64 TargetId {
 get { return targetId_; }
 set { SetTargetId(value); }
 }
 public void SetTargetId(Int64 value) { 
 hasTargetId = true;
 targetId_ = value;
 }

public const int targetPosFieldNumber = 3;
 private bool hasTargetPos;
 private Vector3Info targetPos_ =  new Vector3Info();
 public bool HasTargetPos {
 get { return hasTargetPos; }
 }
 public Vector3Info TargetPos {
 get { return targetPos_; }
 set { SetTargetPos(value); }
 }
 public void SetTargetPos(Vector3Info value) { 
 hasTargetPos = true;
 targetPos_ = value;
 }

public const int targetDirFieldNumber = 4;
 private bool hasTargetDir;
 private Vector3Info targetDir_ =  new Vector3Info();
 public bool HasTargetDir {
 get { return hasTargetDir; }
 }
 public Vector3Info TargetDir {
 get { return targetDir_; }
 set { SetTargetDir(value); }
 }
 public void SetTargetDir(Vector3Info value) { 
 hasTargetDir = true;
 targetDir_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMotionId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MotionId);
}
 if (HasTargetId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetId);
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TargetDir.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMotionId) {
output.WriteInt32(1, MotionId);
}
 
if (HasTargetId) {
output.WriteInt64(2, TargetId);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetDir.SerializedSize());
TargetDir.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTriggerMotion _inst = (GCTriggerMotion) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MotionId = input.ReadInt32();
break;
}
   case  16: {
 _inst.TargetId = input.ReadInt64();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetDir = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
  if (HasTargetDir) {
if (!TargetDir.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUpSkillOK : PacketDistributed
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

public const int skilldataFieldNumber = 2;
 private pbc::PopsicleList<SkillItemData> skilldata_ = new pbc::PopsicleList<SkillItemData>();
 public scg::IList<SkillItemData> skilldataList {
 get { return pbc::Lists.AsReadOnly(skilldata_); }
 }
 
 public int skilldataCount {
 get { return skilldata_.Count; }
 }
 
public SkillItemData GetSkilldata(int index) {
 return skilldata_[index];
 }
 public void AddSkilldata(SkillItemData value) {
 skilldata_.Add(value);
 }

public const int skillFlagFieldNumber = 3;
 private bool hasSkillFlag;
 private Int32 skillFlag_ = 0;
 public bool HasSkillFlag {
 get { return hasSkillFlag; }
 }
 public Int32 SkillFlag {
 get { return skillFlag_; }
 set { SetSkillFlag(value); }
 }
 public void SetSkillFlag(Int32 value) { 
 hasSkillFlag = true;
 skillFlag_ = value;
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
{
foreach (SkillItemData element in skilldataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSkillFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SkillFlag);
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

do{
foreach (SkillItemData element in skilldataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSkillFlag) {
output.WriteInt32(3, SkillFlag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpSkillOK _inst = (GCUpSkillOK) _base;
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
    case  18: {
SkillItemData subBuilder =  new SkillItemData();
input.ReadMessage(subBuilder);
_inst.AddSkilldata(subBuilder);
break;
}
   case  24: {
 _inst.SkillFlag = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SkillItemData element in skilldataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUseSkill : PacketDistributed
{

public const int attackerIdFieldNumber = 1;
 private bool hasAttackerId;
 private Int64 attackerId_ = 0;
 public bool HasAttackerId {
 get { return hasAttackerId; }
 }
 public Int64 AttackerId {
 get { return attackerId_; }
 set { SetAttackerId(value); }
 }
 public void SetAttackerId(Int64 value) { 
 hasAttackerId = true;
 attackerId_ = value;
 }

public const int skillIdFieldNumber = 2;
 private bool hasSkillId;
 private Int32 skillId_ = 0;
 public bool HasSkillId {
 get { return hasSkillId; }
 }
 public Int32 SkillId {
 get { return skillId_; }
 set { SetSkillId(value); }
 }
 public void SetSkillId(Int32 value) { 
 hasSkillId = true;
 skillId_ = value;
 }

public const int skillIndexFieldNumber = 3;
 private bool hasSkillIndex;
 private Int32 skillIndex_ = 0;
 public bool HasSkillIndex {
 get { return hasSkillIndex; }
 }
 public Int32 SkillIndex {
 get { return skillIndex_; }
 set { SetSkillIndex(value); }
 }
 public void SetSkillIndex(Int32 value) { 
 hasSkillIndex = true;
 skillIndex_ = value;
 }

public const int attackerPosFieldNumber = 4;
 private bool hasAttackerPos;
 private Vector3Info attackerPos_ =  new Vector3Info();
 public bool HasAttackerPos {
 get { return hasAttackerPos; }
 }
 public Vector3Info AttackerPos {
 get { return attackerPos_; }
 set { SetAttackerPos(value); }
 }
 public void SetAttackerPos(Vector3Info value) { 
 hasAttackerPos = true;
 attackerPos_ = value;
 }

public const int targetObjIdsFieldNumber = 5;
 private pbc::PopsicleList<Int64> targetObjIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> targetObjIdsList {
 get { return pbc::Lists.AsReadOnly(targetObjIds_); }
 }
 
 public int targetObjIdsCount {
 get { return targetObjIds_.Count; }
 }
 
public Int64 GetTargetObjIds(int index) {
 return targetObjIds_[index];
 }
 public void AddTargetObjIds(Int64 value) {
 targetObjIds_.Add(value);
 }

public const int clientStartTimeFieldNumber = 6;
 private bool hasClientStartTime;
 private Int64 clientStartTime_ = 0;
 public bool HasClientStartTime {
 get { return hasClientStartTime; }
 }
 public Int64 ClientStartTime {
 get { return clientStartTime_; }
 set { SetClientStartTime(value); }
 }
 public void SetClientStartTime(Int64 value) { 
 hasClientStartTime = true;
 clientStartTime_ = value;
 }

public const int attackerDirectionFieldNumber = 7;
 private bool hasAttackerDirection;
 private Vector3Info attackerDirection_ =  new Vector3Info();
 public bool HasAttackerDirection {
 get { return hasAttackerDirection; }
 }
 public Vector3Info AttackerDirection {
 get { return attackerDirection_; }
 set { SetAttackerDirection(value); }
 }
 public void SetAttackerDirection(Vector3Info value) { 
 hasAttackerDirection = true;
 attackerDirection_ = value;
 }

public const int attackRelationListFieldNumber = 8;
 private pbc::PopsicleList<SkillAttackRelation> attackRelationList_ = new pbc::PopsicleList<SkillAttackRelation>();
 public scg::IList<SkillAttackRelation> attackRelationListList {
 get { return pbc::Lists.AsReadOnly(attackRelationList_); }
 }
 
 public int attackRelationListCount {
 get { return attackRelationList_.Count; }
 }
 
public SkillAttackRelation GetAttackRelationList(int index) {
 return attackRelationList_[index];
 }
 public void AddAttackRelationList(SkillAttackRelation value) {
 attackRelationList_.Add(value);
 }

public const int targetPosFieldNumber = 9;
 private bool hasTargetPos;
 private Vector3Info targetPos_ =  new Vector3Info();
 public bool HasTargetPos {
 get { return hasTargetPos; }
 }
 public Vector3Info TargetPos {
 get { return targetPos_; }
 set { SetTargetPos(value); }
 }
 public void SetTargetPos(Vector3Info value) { 
 hasTargetPos = true;
 targetPos_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAttackerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, AttackerId);
}
 if (HasSkillId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SkillId);
}
 if (HasSkillIndex) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SkillIndex);
}
{
int subsize = AttackerPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int dataSize = 0;
foreach (Int64 element in targetObjIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * targetObjIds_.Count;
}
 if (HasClientStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, ClientStartTime);
}
{
int subsize = AttackerDirection.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (SkillAttackRelation element in attackRelationListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAttackerId) {
output.WriteInt64(1, AttackerId);
}
 
if (HasSkillId) {
output.WriteInt32(2, SkillId);
}
 
if (HasSkillIndex) {
output.WriteInt32(3, SkillIndex);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)AttackerPos.SerializedSize());
AttackerPos.WriteTo(output);

}
{
if (targetObjIds_.Count > 0) {
foreach (Int64 element in targetObjIdsList) {
output.WriteInt64(5,element);
}
}

}
 
if (HasClientStartTime) {
output.WriteInt64(6, ClientStartTime);
}
{
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)AttackerDirection.SerializedSize());
AttackerDirection.WriteTo(output);

}

do{
foreach (SkillAttackRelation element in attackRelationListList) {
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUseSkill _inst = (GCUseSkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AttackerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.SkillId = input.ReadInt32();
break;
}
   case  24: {
 _inst.SkillIndex = input.ReadInt32();
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.AttackerPos = subBuilder;
break;
}
   case  40: {
 _inst.AddTargetObjIds(input.ReadInt64());
break;
}
   case  48: {
 _inst.ClientStartTime = input.ReadInt64();
break;
}
    case  58: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.AttackerDirection = subBuilder;
break;
}
    case  66: {
SkillAttackRelation subBuilder =  new SkillAttackRelation();
input.ReadMessage(subBuilder);
_inst.AddAttackRelationList(subBuilder);
break;
}
    case  74: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasAttackerPos) {
if (!AttackerPos.IsInitialized()) return false;
}
  if (HasAttackerDirection) {
if (!AttackerDirection.IsInitialized()) return false;
}
foreach (SkillAttackRelation element in attackRelationListList) {
if (!element.IsInitialized()) return false;
}
  if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUseSkillResult : PacketDistributed
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

public const int cdInfoFieldNumber = 2;
 private bool hasCdInfo;
 private SkillCDInfo cdInfo_ =  new SkillCDInfo();
 public bool HasCdInfo {
 get { return hasCdInfo; }
 }
 public SkillCDInfo CdInfo {
 get { return cdInfo_; }
 set { SetCdInfo(value); }
 }
 public void SetCdInfo(SkillCDInfo value) { 
 hasCdInfo = true;
 cdInfo_ = value;
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
{
int subsize = CdInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)CdInfo.SerializedSize());
CdInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUseSkillResult _inst = (GCUseSkillResult) _base;
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
    case  18: {
SkillCDInfo subBuilder =  new SkillCDInfo();
 input.ReadMessage(subBuilder);
_inst.CdInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasCdInfo) {
if (!CdInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SkillCDInfo : PacketDistributed
{

public const int skillIdFieldNumber = 1;
 private bool hasSkillId;
 private Int32 skillId_ = 0;
 public bool HasSkillId {
 get { return hasSkillId; }
 }
 public Int32 SkillId {
 get { return skillId_; }
 set { SetSkillId(value); }
 }
 public void SetSkillId(Int32 value) { 
 hasSkillId = true;
 skillId_ = value;
 }

public const int cdEndTimeFieldNumber = 2;
 private bool hasCdEndTime;
 private Int64 cdEndTime_ = 0;
 public bool HasCdEndTime {
 get { return hasCdEndTime; }
 }
 public Int64 CdEndTime {
 get { return cdEndTime_; }
 set { SetCdEndTime(value); }
 }
 public void SetCdEndTime(Int64 value) { 
 hasCdEndTime = true;
 cdEndTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSkillId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SkillId);
}
 if (HasCdEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, CdEndTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSkillId) {
output.WriteInt32(1, SkillId);
}
 
if (HasCdEndTime) {
output.WriteInt64(2, CdEndTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SkillCDInfo _inst = (SkillCDInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SkillId = input.ReadInt32();
break;
}
   case  16: {
 _inst.CdEndTime = input.ReadInt64();
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
