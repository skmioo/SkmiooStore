//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class GRCheckMoveToRayCastTest : PacketDistributed
{

public const int sceneInstanceIdFieldNumber = 1;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int mapFileNameFieldNumber = 2;
 private bool hasMapFileName;
 private string mapFileName_ = "";
 public bool HasMapFileName {
 get { return hasMapFileName; }
 }
 public string MapFileName {
 get { return mapFileName_; }
 set { SetMapFileName(value); }
 }
 public void SetMapFileName(string value) { 
 hasMapFileName = true;
 mapFileName_ = value;
 }

public const int charGuidFieldNumber = 3;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int orderIdFieldNumber = 4;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int startPosFieldNumber = 5;
 private bool hasStartPos;
 private Vector3Info startPos_ =  new Vector3Info();
 public bool HasStartPos {
 get { return hasStartPos; }
 }
 public Vector3Info StartPos {
 get { return startPos_; }
 set { SetStartPos(value); }
 }
 public void SetStartPos(Vector3Info value) { 
 hasStartPos = true;
 startPos_ = value;
 }

public const int targetPosFieldNumber = 6;
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
  if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneInstanceId);
}
 if (HasMapFileName) {
size += pb::CodedOutputStream.ComputeStringSize(2, MapFileName);
}
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, CharGuid);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OrderId);
}
{
int subsize = StartPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneInstanceId) {
output.WriteInt32(1, SceneInstanceId);
}
 
if (HasMapFileName) {
output.WriteString(2, MapFileName);
}
 
if (HasCharGuid) {
output.WriteInt64(3, CharGuid);
}
 
if (HasOrderId) {
output.WriteInt32(4, OrderId);
}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StartPos.SerializedSize());
StartPos.WriteTo(output);

}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GRCheckMoveToRayCastTest _inst = (GRCheckMoveToRayCastTest) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  18: {
 _inst.MapFileName = input.ReadString();
break;
}
   case  24: {
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  32: {
 _inst.OrderId = input.ReadInt32();
break;
}
    case  42: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StartPos = subBuilder;
break;
}
    case  50: {
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
   if (HasStartPos) {
if (!StartPos.IsInitialized()) return false;
}
  if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GRMoveStepOnPath : PacketDistributed
{

public const int sceneInstanceIdFieldNumber = 1;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int mapFileNameFieldNumber = 2;
 private bool hasMapFileName;
 private string mapFileName_ = "";
 public bool HasMapFileName {
 get { return hasMapFileName; }
 }
 public string MapFileName {
 get { return mapFileName_; }
 set { SetMapFileName(value); }
 }
 public void SetMapFileName(string value) { 
 hasMapFileName = true;
 mapFileName_ = value;
 }

public const int charGuidFieldNumber = 3;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int orderIdFieldNumber = 4;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int moveStepFieldNumber = 5;
 private bool hasMoveStep;
 private Int32 moveStep_ = 0;
 public bool HasMoveStep {
 get { return hasMoveStep; }
 }
 public Int32 MoveStep {
 get { return moveStep_; }
 set { SetMoveStep(value); }
 }
 public void SetMoveStep(Int32 value) { 
 hasMoveStep = true;
 moveStep_ = value;
 }

public const int stopRangeFieldNumber = 6;
 private bool hasStopRange;
 private Int32 stopRange_ = 0;
 public bool HasStopRange {
 get { return hasStopRange; }
 }
 public Int32 StopRange {
 get { return stopRange_; }
 set { SetStopRange(value); }
 }
 public void SetStopRange(Int32 value) { 
 hasStopRange = true;
 stopRange_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneInstanceId);
}
 if (HasMapFileName) {
size += pb::CodedOutputStream.ComputeStringSize(2, MapFileName);
}
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, CharGuid);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OrderId);
}
 if (HasMoveStep) {
size += pb::CodedOutputStream.ComputeInt32Size(5, MoveStep);
}
 if (HasStopRange) {
size += pb::CodedOutputStream.ComputeInt32Size(6, StopRange);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneInstanceId) {
output.WriteInt32(1, SceneInstanceId);
}
 
if (HasMapFileName) {
output.WriteString(2, MapFileName);
}
 
if (HasCharGuid) {
output.WriteInt64(3, CharGuid);
}
 
if (HasOrderId) {
output.WriteInt32(4, OrderId);
}
 
if (HasMoveStep) {
output.WriteInt32(5, MoveStep);
}
 
if (HasStopRange) {
output.WriteInt32(6, StopRange);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GRMoveStepOnPath _inst = (GRMoveStepOnPath) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  18: {
 _inst.MapFileName = input.ReadString();
break;
}
   case  24: {
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  32: {
 _inst.OrderId = input.ReadInt32();
break;
}
   case  40: {
 _inst.MoveStep = input.ReadInt32();
break;
}
   case  48: {
 _inst.StopRange = input.ReadInt32();
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
public class GRStartMove : PacketDistributed
{

public const int sceneInstanceIdFieldNumber = 1;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int mapFileNameFieldNumber = 2;
 private bool hasMapFileName;
 private string mapFileName_ = "";
 public bool HasMapFileName {
 get { return hasMapFileName; }
 }
 public string MapFileName {
 get { return mapFileName_; }
 set { SetMapFileName(value); }
 }
 public void SetMapFileName(string value) { 
 hasMapFileName = true;
 mapFileName_ = value;
 }

public const int charGuidFieldNumber = 3;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int orderIdFieldNumber = 4;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int startPosFieldNumber = 5;
 private bool hasStartPos;
 private Vector3Info startPos_ =  new Vector3Info();
 public bool HasStartPos {
 get { return hasStartPos; }
 }
 public Vector3Info StartPos {
 get { return startPos_; }
 set { SetStartPos(value); }
 }
 public void SetStartPos(Vector3Info value) { 
 hasStartPos = true;
 startPos_ = value;
 }

public const int targetPosFieldNumber = 6;
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

public const int startTimeFieldNumber = 7;
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

public const int moveSpeedFieldNumber = 8;
 private bool hasMoveSpeed;
 private Int32 moveSpeed_ = 0;
 public bool HasMoveSpeed {
 get { return hasMoveSpeed; }
 }
 public Int32 MoveSpeed {
 get { return moveSpeed_; }
 set { SetMoveSpeed(value); }
 }
 public void SetMoveSpeed(Int32 value) { 
 hasMoveSpeed = true;
 moveSpeed_ = value;
 }

public const int stopRangeFieldNumber = 9;
 private bool hasStopRange;
 private Int32 stopRange_ = 0;
 public bool HasStopRange {
 get { return hasStopRange; }
 }
 public Int32 StopRange {
 get { return stopRange_; }
 set { SetStopRange(value); }
 }
 public void SetStopRange(Int32 value) { 
 hasStopRange = true;
 stopRange_ = value;
 }

public const int useRaycastFieldNumber = 10;
 private bool hasUseRaycast;
 private Int32 useRaycast_ = 0;
 public bool HasUseRaycast {
 get { return hasUseRaycast; }
 }
 public Int32 UseRaycast {
 get { return useRaycast_; }
 set { SetUseRaycast(value); }
 }
 public void SetUseRaycast(Int32 value) { 
 hasUseRaycast = true;
 useRaycast_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneInstanceId);
}
 if (HasMapFileName) {
size += pb::CodedOutputStream.ComputeStringSize(2, MapFileName);
}
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, CharGuid);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OrderId);
}
{
int subsize = StartPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, StartTime);
}
 if (HasMoveSpeed) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MoveSpeed);
}
 if (HasStopRange) {
size += pb::CodedOutputStream.ComputeInt32Size(9, StopRange);
}
 if (HasUseRaycast) {
size += pb::CodedOutputStream.ComputeInt32Size(10, UseRaycast);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneInstanceId) {
output.WriteInt32(1, SceneInstanceId);
}
 
if (HasMapFileName) {
output.WriteString(2, MapFileName);
}
 
if (HasCharGuid) {
output.WriteInt64(3, CharGuid);
}
 
if (HasOrderId) {
output.WriteInt32(4, OrderId);
}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StartPos.SerializedSize());
StartPos.WriteTo(output);

}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 
if (HasStartTime) {
output.WriteInt64(7, StartTime);
}
 
if (HasMoveSpeed) {
output.WriteInt32(8, MoveSpeed);
}
 
if (HasStopRange) {
output.WriteInt32(9, StopRange);
}
 
if (HasUseRaycast) {
output.WriteInt32(10, UseRaycast);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GRStartMove _inst = (GRStartMove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  18: {
 _inst.MapFileName = input.ReadString();
break;
}
   case  24: {
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  32: {
 _inst.OrderId = input.ReadInt32();
break;
}
    case  42: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StartPos = subBuilder;
break;
}
    case  50: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}
   case  56: {
 _inst.StartTime = input.ReadInt64();
break;
}
   case  64: {
 _inst.MoveSpeed = input.ReadInt32();
break;
}
   case  72: {
 _inst.StopRange = input.ReadInt32();
break;
}
   case  80: {
 _inst.UseRaycast = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasStartPos) {
if (!StartPos.IsInitialized()) return false;
}
  if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GRStopMoving : PacketDistributed
{

public const int charGuidFieldNumber = 1;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int sceneInstanceIdFieldNumber = 2;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int orderIdFieldNumber = 3;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int needBackFieldNumber = 4;
 private bool hasNeedBack;
 private Int32 needBack_ = 0;
 public bool HasNeedBack {
 get { return hasNeedBack; }
 }
 public Int32 NeedBack {
 get { return needBack_; }
 set { SetNeedBack(value); }
 }
 public void SetNeedBack(Int32 value) { 
 hasNeedBack = true;
 needBack_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, CharGuid);
}
 if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SceneInstanceId);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, OrderId);
}
 if (HasNeedBack) {
size += pb::CodedOutputStream.ComputeInt32Size(4, NeedBack);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCharGuid) {
output.WriteInt64(1, CharGuid);
}
 
if (HasSceneInstanceId) {
output.WriteInt32(2, SceneInstanceId);
}
 
if (HasOrderId) {
output.WriteInt32(3, OrderId);
}
 
if (HasNeedBack) {
output.WriteInt32(4, NeedBack);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GRStopMoving _inst = (GRStopMoving) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  16: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  24: {
 _inst.OrderId = input.ReadInt32();
break;
}
   case  32: {
 _inst.NeedBack = input.ReadInt32();
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
public class GRUpdateMoveSpeed : PacketDistributed
{

public const int charGuidFieldNumber = 1;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int sceneInstanceIdFieldNumber = 2;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int orderIdFieldNumber = 3;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int moveSpeedFieldNumber = 4;
 private bool hasMoveSpeed;
 private Int32 moveSpeed_ = 0;
 public bool HasMoveSpeed {
 get { return hasMoveSpeed; }
 }
 public Int32 MoveSpeed {
 get { return moveSpeed_; }
 set { SetMoveSpeed(value); }
 }
 public void SetMoveSpeed(Int32 value) { 
 hasMoveSpeed = true;
 moveSpeed_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, CharGuid);
}
 if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SceneInstanceId);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, OrderId);
}
 if (HasMoveSpeed) {
size += pb::CodedOutputStream.ComputeInt32Size(4, MoveSpeed);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCharGuid) {
output.WriteInt64(1, CharGuid);
}
 
if (HasSceneInstanceId) {
output.WriteInt32(2, SceneInstanceId);
}
 
if (HasOrderId) {
output.WriteInt32(3, OrderId);
}
 
if (HasMoveSpeed) {
output.WriteInt32(4, MoveSpeed);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GRUpdateMoveSpeed _inst = (GRUpdateMoveSpeed) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  16: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  24: {
 _inst.OrderId = input.ReadInt32();
break;
}
   case  32: {
 _inst.MoveSpeed = input.ReadInt32();
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
public class RGCheckMoveToRayCastTest : PacketDistributed
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

public const int charGuidFieldNumber = 2;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int sceneInstanceIdFieldNumber = 3;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int orderIdFieldNumber = 4;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int startPosFieldNumber = 5;
 private bool hasStartPos;
 private Vector3Info startPos_ =  new Vector3Info();
 public bool HasStartPos {
 get { return hasStartPos; }
 }
 public Vector3Info StartPos {
 get { return startPos_; }
 set { SetStartPos(value); }
 }
 public void SetStartPos(Vector3Info value) { 
 hasStartPos = true;
 startPos_ = value;
 }

public const int targetPosFieldNumber = 6;
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
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, CharGuid);
}
 if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SceneInstanceId);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OrderId);
}
{
int subsize = StartPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasCharGuid) {
output.WriteInt64(2, CharGuid);
}
 
if (HasSceneInstanceId) {
output.WriteInt32(3, SceneInstanceId);
}
 
if (HasOrderId) {
output.WriteInt32(4, OrderId);
}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StartPos.SerializedSize());
StartPos.WriteTo(output);

}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RGCheckMoveToRayCastTest _inst = (RGCheckMoveToRayCastTest) _base;
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
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  24: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  32: {
 _inst.OrderId = input.ReadInt32();
break;
}
    case  42: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StartPos = subBuilder;
break;
}
    case  50: {
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
   if (HasStartPos) {
if (!StartPos.IsInitialized()) return false;
}
  if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class RGMoveStepOnPathBack : PacketDistributed
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

public const int charGuidFieldNumber = 2;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int sceneInstanceIdFieldNumber = 3;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int posFieldNumber = 4;
 private bool hasPos;
 private Vector3Info pos_ =  new Vector3Info();
 public bool HasPos {
 get { return hasPos; }
 }
 public Vector3Info Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Vector3Info value) { 
 hasPos = true;
 pos_ = value;
 }

public const int directionFieldNumber = 5;
 private bool hasDirection;
 private Vector3Info direction_ =  new Vector3Info();
 public bool HasDirection {
 get { return hasDirection; }
 }
 public Vector3Info Direction {
 get { return direction_; }
 set { SetDirection(value); }
 }
 public void SetDirection(Vector3Info value) { 
 hasDirection = true;
 direction_ = value;
 }

public const int orderIdFieldNumber = 6;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
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
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, CharGuid);
}
 if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SceneInstanceId);
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, OrderId);
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
 
if (HasCharGuid) {
output.WriteInt64(2, CharGuid);
}
 
if (HasSceneInstanceId) {
output.WriteInt32(3, SceneInstanceId);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
 
if (HasOrderId) {
output.WriteInt32(6, OrderId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RGMoveStepOnPathBack _inst = (RGMoveStepOnPathBack) _base;
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
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  24: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  42: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}
   case  48: {
 _inst.OrderId = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPos) {
if (!Pos.IsInitialized()) return false;
}
  if (HasDirection) {
if (!Direction.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class RGStartMoveBack : PacketDistributed
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

public const int charGuidFieldNumber = 2;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int sceneInstanceIdFieldNumber = 3;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int startPosFieldNumber = 4;
 private bool hasStartPos;
 private Vector3Info startPos_ =  new Vector3Info();
 public bool HasStartPos {
 get { return hasStartPos; }
 }
 public Vector3Info StartPos {
 get { return startPos_; }
 set { SetStartPos(value); }
 }
 public void SetStartPos(Vector3Info value) { 
 hasStartPos = true;
 startPos_ = value;
 }

public const int targetPosFieldNumber = 5;
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

public const int orderIdFieldNumber = 6;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
 }

public const int startTimeFieldNumber = 7;
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

public const int moveSpeedFieldNumber = 8;
 private bool hasMoveSpeed;
 private Int32 moveSpeed_ = 0;
 public bool HasMoveSpeed {
 get { return hasMoveSpeed; }
 }
 public Int32 MoveSpeed {
 get { return moveSpeed_; }
 set { SetMoveSpeed(value); }
 }
 public void SetMoveSpeed(Int32 value) { 
 hasMoveSpeed = true;
 moveSpeed_ = value;
 }

public const int stopRangeFieldNumber = 9;
 private bool hasStopRange;
 private Int32 stopRange_ = 0;
 public bool HasStopRange {
 get { return hasStopRange; }
 }
 public Int32 StopRange {
 get { return stopRange_; }
 set { SetStopRange(value); }
 }
 public void SetStopRange(Int32 value) { 
 hasStopRange = true;
 stopRange_ = value;
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
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, CharGuid);
}
 if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SceneInstanceId);
}
{
int subsize = StartPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TargetPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, OrderId);
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, StartTime);
}
 if (HasMoveSpeed) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MoveSpeed);
}
 if (HasStopRange) {
size += pb::CodedOutputStream.ComputeInt32Size(9, StopRange);
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
 
if (HasCharGuid) {
output.WriteInt64(2, CharGuid);
}
 
if (HasSceneInstanceId) {
output.WriteInt32(3, SceneInstanceId);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StartPos.SerializedSize());
StartPos.WriteTo(output);

}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TargetPos.SerializedSize());
TargetPos.WriteTo(output);

}
 
if (HasOrderId) {
output.WriteInt32(6, OrderId);
}
 
if (HasStartTime) {
output.WriteInt64(7, StartTime);
}
 
if (HasMoveSpeed) {
output.WriteInt32(8, MoveSpeed);
}
 
if (HasStopRange) {
output.WriteInt32(9, StopRange);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RGStartMoveBack _inst = (RGStartMoveBack) _base;
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
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  24: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StartPos = subBuilder;
break;
}
    case  42: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.TargetPos = subBuilder;
break;
}
   case  48: {
 _inst.OrderId = input.ReadInt32();
break;
}
   case  56: {
 _inst.StartTime = input.ReadInt64();
break;
}
   case  64: {
 _inst.MoveSpeed = input.ReadInt32();
break;
}
   case  72: {
 _inst.StopRange = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasStartPos) {
if (!StartPos.IsInitialized()) return false;
}
  if (HasTargetPos) {
if (!TargetPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class RGStopMovingBack : PacketDistributed
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

public const int charGuidFieldNumber = 2;
 private bool hasCharGuid;
 private Int64 charGuid_ = 0;
 public bool HasCharGuid {
 get { return hasCharGuid; }
 }
 public Int64 CharGuid {
 get { return charGuid_; }
 set { SetCharGuid(value); }
 }
 public void SetCharGuid(Int64 value) { 
 hasCharGuid = true;
 charGuid_ = value;
 }

public const int sceneInstanceIdFieldNumber = 3;
 private bool hasSceneInstanceId;
 private Int32 sceneInstanceId_ = 0;
 public bool HasSceneInstanceId {
 get { return hasSceneInstanceId; }
 }
 public Int32 SceneInstanceId {
 get { return sceneInstanceId_; }
 set { SetSceneInstanceId(value); }
 }
 public void SetSceneInstanceId(Int32 value) { 
 hasSceneInstanceId = true;
 sceneInstanceId_ = value;
 }

public const int orderIdFieldNumber = 4;
 private bool hasOrderId;
 private Int32 orderId_ = 0;
 public bool HasOrderId {
 get { return hasOrderId; }
 }
 public Int32 OrderId {
 get { return orderId_; }
 set { SetOrderId(value); }
 }
 public void SetOrderId(Int32 value) { 
 hasOrderId = true;
 orderId_ = value;
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
 if (HasCharGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, CharGuid);
}
 if (HasSceneInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SceneInstanceId);
}
 if (HasOrderId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OrderId);
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
 
if (HasCharGuid) {
output.WriteInt64(2, CharGuid);
}
 
if (HasSceneInstanceId) {
output.WriteInt32(3, SceneInstanceId);
}
 
if (HasOrderId) {
output.WriteInt32(4, OrderId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RGStopMovingBack _inst = (RGStopMovingBack) _base;
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
 _inst.CharGuid = input.ReadInt64();
break;
}
   case  24: {
 _inst.SceneInstanceId = input.ReadInt32();
break;
}
   case  32: {
 _inst.OrderId = input.ReadInt32();
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
public class RecastRegist : PacketDistributed
{

public const int recastIdFieldNumber = 1;
 private bool hasRecastId;
 private Int32 recastId_ = 0;
 public bool HasRecastId {
 get { return hasRecastId; }
 }
 public Int32 RecastId {
 get { return recastId_; }
 set { SetRecastId(value); }
 }
 public void SetRecastId(Int32 value) { 
 hasRecastId = true;
 recastId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRecastId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RecastId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRecastId) {
output.WriteInt32(1, RecastId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RecastRegist _inst = (RecastRegist) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RecastId = input.ReadInt32();
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
