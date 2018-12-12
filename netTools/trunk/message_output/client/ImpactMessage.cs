//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGTriggerImpact : PacketDistributed
{

public const int targetIdFieldNumber = 1;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTargetId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TargetId);
}
 if (HasImpactId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ImpactId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTargetId) {
output.WriteInt64(1, TargetId);
}
 
if (HasImpactId) {
output.WriteInt32(2, ImpactId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTriggerImpact _inst = (CGTriggerImpact) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TargetId = input.ReadInt64();
break;
}
   case  16: {
 _inst.ImpactId = input.ReadInt32();
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
public class GCSyncImpactList : PacketDistributed
{

public const int guidFieldNumber = 1;
 private bool hasGuid;
 private Int64 guid_ = 0;
 public bool HasGuid {
 get { return hasGuid; }
 }
 public Int64 Guid {
 get { return guid_; }
 set { SetGuid(value); }
 }
 public void SetGuid(Int64 value) { 
 hasGuid = true;
 guid_ = value;
 }

public const int dirtyFlagFieldNumber = 2;
 private pbc::PopsicleList<Int32> dirtyFlag_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> dirtyFlagList {
 get { return pbc::Lists.AsReadOnly(dirtyFlag_); }
 }
 
 public int dirtyFlagCount {
 get { return dirtyFlag_.Count; }
 }
 
public Int32 GetDirtyFlag(int index) {
 return dirtyFlag_[index];
 }
 public void AddDirtyFlag(Int32 value) {
 dirtyFlag_.Add(value);
 }

public const int impactDatasFieldNumber = 3;
 private pbc::PopsicleList<ImpactData> impactDatas_ = new pbc::PopsicleList<ImpactData>();
 public scg::IList<ImpactData> impactDatasList {
 get { return pbc::Lists.AsReadOnly(impactDatas_); }
 }
 
 public int impactDatasCount {
 get { return impactDatas_.Count; }
 }
 
public ImpactData GetImpactDatas(int index) {
 return impactDatas_[index];
 }
 public void AddImpactDatas(ImpactData value) {
 impactDatas_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Guid);
}
{
int dataSize = 0;
foreach (Int32 element in dirtyFlagList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * dirtyFlag_.Count;
}
{
foreach (ImpactData element in impactDatasList) {
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
  
if (HasGuid) {
output.WriteInt64(1, Guid);
}
{
if (dirtyFlag_.Count > 0) {
foreach (Int32 element in dirtyFlagList) {
output.WriteInt32(2,element);
}
}

}

do{
foreach (ImpactData element in impactDatasList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSyncImpactList _inst = (GCSyncImpactList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Guid = input.ReadInt64();
break;
}
   case  16: {
 _inst.AddDirtyFlag(input.ReadInt32());
break;
}
    case  26: {
ImpactData subBuilder =  new ImpactData();
input.ReadMessage(subBuilder);
_inst.AddImpactDatas(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ImpactData element in impactDatasList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTriggerImpact : PacketDistributed
{

public const int guidFieldNumber = 1;
 private bool hasGuid;
 private Int64 guid_ = 0;
 public bool HasGuid {
 get { return hasGuid; }
 }
 public Int64 Guid {
 get { return guid_; }
 set { SetGuid(value); }
 }
 public void SetGuid(Int64 value) { 
 hasGuid = true;
 guid_ = value;
 }

public const int attackIdFieldNumber = 2;
 private bool hasAttackId;
 private Int64 attackId_ = 0;
 public bool HasAttackId {
 get { return hasAttackId; }
 }
 public Int64 AttackId {
 get { return attackId_; }
 set { SetAttackId(value); }
 }
 public void SetAttackId(Int64 value) { 
 hasAttackId = true;
 attackId_ = value;
 }

public const int impactIdsFieldNumber = 3;
 private pbc::PopsicleList<Int32> impactIds_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> impactIdsList {
 get { return pbc::Lists.AsReadOnly(impactIds_); }
 }
 
 public int impactIdsCount {
 get { return impactIds_.Count; }
 }
 
public Int32 GetImpactIds(int index) {
 return impactIds_[index];
 }
 public void AddImpactIds(Int32 value) {
 impactIds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Guid);
}
 if (HasAttackId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AttackId);
}
{
int dataSize = 0;
foreach (Int32 element in impactIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * impactIds_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGuid) {
output.WriteInt64(1, Guid);
}
 
if (HasAttackId) {
output.WriteInt64(2, AttackId);
}
{
if (impactIds_.Count > 0) {
foreach (Int32 element in impactIdsList) {
output.WriteInt32(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTriggerImpact _inst = (GCTriggerImpact) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Guid = input.ReadInt64();
break;
}
   case  16: {
 _inst.AttackId = input.ReadInt64();
break;
}
   case  24: {
 _inst.AddImpactIds(input.ReadInt32());
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
public class ImpactData : PacketDistributed
{

public const int impactIdFieldNumber = 1;
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

public const int paramFieldNumber = 4;
 private pbc::PopsicleList<Int32> param_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> paramList {
 get { return pbc::Lists.AsReadOnly(param_); }
 }
 
 public int paramCount {
 get { return param_.Count; }
 }
 
public Int32 GetParam(int index) {
 return param_[index];
 }
 public void AddParam(Int32 value) {
 param_.Add(value);
 }

public const int attack_idFieldNumber = 5;
 private bool hasAttack_id;
 private Int64 attack_id_ = 0;
 public bool HasAttack_id {
 get { return hasAttack_id; }
 }
 public Int64 Attack_id {
 get { return attack_id_; }
 set { SetAttack_id(value); }
 }
 public void SetAttack_id(Int64 value) { 
 hasAttack_id = true;
 attack_id_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasImpactId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ImpactId);
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, StartTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, EndTime);
}
{
int dataSize = 0;
foreach (Int32 element in paramList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * param_.Count;
}
 if (HasAttack_id) {
size += pb::CodedOutputStream.ComputeInt64Size(5, Attack_id);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasImpactId) {
output.WriteInt32(1, ImpactId);
}
 
if (HasStartTime) {
output.WriteInt64(2, StartTime);
}
 
if (HasEndTime) {
output.WriteInt64(3, EndTime);
}
{
if (param_.Count > 0) {
foreach (Int32 element in paramList) {
output.WriteInt32(4,element);
}
}

}
 
if (HasAttack_id) {
output.WriteInt64(5, Attack_id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ImpactData _inst = (ImpactData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ImpactId = input.ReadInt32();
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
 _inst.AddParam(input.ReadInt32());
break;
}
   case  40: {
 _inst.Attack_id = input.ReadInt64();
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
