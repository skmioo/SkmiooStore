//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBadvellyOperate : PacketDistributed
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

public const int missionIdFieldNumber = 2;
 private bool hasMissionId;
 private Int32 missionId_ = 0;
 public bool HasMissionId {
 get { return hasMissionId; }
 }
 public Int32 MissionId {
 get { return missionId_; }
 set { SetMissionId(value); }
 }
 public void SetMissionId(Int32 value) { 
 hasMissionId = true;
 missionId_ = value;
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
 if (HasMissionId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MissionId);
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
 
if (HasMissionId) {
output.WriteInt32(2, MissionId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBadvellyOperate _inst = (CGBadvellyOperate) _base;
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
 _inst.MissionId = input.ReadInt32();
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
public class GCBadvellyOperateBack : PacketDistributed
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

public const int scenceIdFieldNumber = 2;
 private bool hasScenceId;
 private Int32 scenceId_ = 0;
 public bool HasScenceId {
 get { return hasScenceId; }
 }
 public Int32 ScenceId {
 get { return scenceId_; }
 set { SetScenceId(value); }
 }
 public void SetScenceId(Int32 value) { 
 hasScenceId = true;
 scenceId_ = value;
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

public const int langueIdFieldNumber = 4;
 private bool hasLangueId;
 private Int32 langueId_ = 0;
 public bool HasLangueId {
 get { return hasLangueId; }
 }
 public Int32 LangueId {
 get { return langueId_; }
 set { SetLangueId(value); }
 }
 public void SetLangueId(Int32 value) { 
 hasLangueId = true;
 langueId_ = value;
 }

public const int resultFieldNumber = 5;
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

public const int missionIdFieldNumber = 6;
 private bool hasMissionId;
 private Int32 missionId_ = 0;
 public bool HasMissionId {
 get { return hasMissionId; }
 }
 public Int32 MissionId {
 get { return missionId_; }
 set { SetMissionId(value); }
 }
 public void SetMissionId(Int32 value) { 
 hasMissionId = true;
 missionId_ = value;
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
 if (HasScenceId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ScenceId);
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasLangueId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, LangueId);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Result);
}
 if (HasMissionId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, MissionId);
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
 
if (HasScenceId) {
output.WriteInt32(2, ScenceId);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 
if (HasLangueId) {
output.WriteInt32(4, LangueId);
}
 
if (HasResult) {
output.WriteInt32(5, Result);
}
 
if (HasMissionId) {
output.WriteInt32(6, MissionId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBadvellyOperateBack _inst = (GCBadvellyOperateBack) _base;
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
 _inst.ScenceId = input.ReadInt32();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}
   case  32: {
 _inst.LangueId = input.ReadInt32();
break;
}
   case  40: {
 _inst.Result = input.ReadInt32();
break;
}
   case  48: {
 _inst.MissionId = input.ReadInt32();
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
 return true;
 }

	}


}
