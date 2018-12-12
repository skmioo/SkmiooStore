//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGChangeAttackState : PacketDistributed
{

public const int stateFieldNumber = 1;
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
  if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(1, State);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasState) {
output.WriteInt32(1, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGChangeAttackState _inst = (CGChangeAttackState) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class CGCommonGetherDevice : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCommonGetherDevice _inst = (CGCommonGetherDevice) _base;
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
public class CGEnterScene : PacketDistributed
{

public const int sceneIdFieldNumber = 1;
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

public const int posFieldNumber = 2;
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

public const int directionFieldNumber = 3;
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

public const int notBackGCEnterSceneFieldNumber = 4;
 private bool hasNotBackGCEnterScene;
 private Int32 notBackGCEnterScene_ = 0;
 public bool HasNotBackGCEnterScene {
 get { return hasNotBackGCEnterScene; }
 }
 public Int32 NotBackGCEnterScene {
 get { return notBackGCEnterScene_; }
 set { SetNotBackGCEnterScene(value); }
 }
 public void SetNotBackGCEnterScene(Int32 value) { 
 hasNotBackGCEnterScene = true;
 notBackGCEnterScene_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSceneId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneId);
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasNotBackGCEnterScene) {
size += pb::CodedOutputStream.ComputeInt32Size(4, NotBackGCEnterScene);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneId) {
output.WriteInt32(1, SceneId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
 
if (HasNotBackGCEnterScene) {
output.WriteInt32(4, NotBackGCEnterScene);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEnterScene _inst = (CGEnterScene) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneId = input.ReadInt32();
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}
   case  32: {
 _inst.NotBackGCEnterScene = input.ReadInt32();
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
public class CGEnterSceneOk : PacketDistributed
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
 CGEnterSceneOk _inst = (CGEnterSceneOk) _base;
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
public class CGFly : PacketDistributed
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
 CGFly _inst = (CGFly) _base;
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
public class CGGetherDevice : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetherDevice _inst = (CGGetherDevice) _base;
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
public class CGMoveInJog : PacketDistributed
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
 CGMoveInJog _inst = (CGMoveInJog) _base;
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
public class CGSendMove : PacketDistributed
{

public const int startPosFieldNumber = 1;
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

public const int targetPosFieldNumber = 2;
 private pbc::PopsicleList<Vector3Info> targetPos_ = new pbc::PopsicleList<Vector3Info>();
 public scg::IList<Vector3Info> targetPosList {
 get { return pbc::Lists.AsReadOnly(targetPos_); }
 }
 
 public int targetPosCount {
 get { return targetPos_.Count; }
 }
 
public Vector3Info GetTargetPos(int index) {
 return targetPos_[index];
 }
 public void AddTargetPos(Vector3Info value) {
 targetPos_.Add(value);
 }

public const int clientTimeFieldNumber = 3;
 private bool hasClientTime;
 private Int64 clientTime_ = 0;
 public bool HasClientTime {
 get { return hasClientTime; }
 }
 public Int64 ClientTime {
 get { return clientTime_; }
 set { SetClientTime(value); }
 }
 public void SetClientTime(Int64 value) { 
 hasClientTime = true;
 clientTime_ = value;
 }

public const int flyHeightFieldNumber = 4;
 private bool hasFlyHeight;
 private Int32 flyHeight_ = 0;
 public bool HasFlyHeight {
 get { return hasFlyHeight; }
 }
 public Int32 FlyHeight {
 get { return flyHeight_; }
 set { SetFlyHeight(value); }
 }
 public void SetFlyHeight(Int32 value) { 
 hasFlyHeight = true;
 flyHeight_ = value;
 }

public const int typeFieldNumber = 5;
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

public const int speedFieldNumber = 6;
 private bool hasSpeed;
 private Int32 speed_ = 0;
 public bool HasSpeed {
 get { return hasSpeed; }
 }
 public Int32 Speed {
 get { return speed_; }
 set { SetSpeed(value); }
 }
 public void SetSpeed(Int32 value) { 
 hasSpeed = true;
 speed_ = value;
 }

public const int flowFieldNumber = 7;
 private bool hasFlow;
 private Int32 flow_ = 0;
 public bool HasFlow {
 get { return hasFlow; }
 }
 public Int32 Flow {
 get { return flow_; }
 set { SetFlow(value); }
 }
 public void SetFlow(Int32 value) { 
 hasFlow = true;
 flow_ = value;
 }

public const int objectIdFieldNumber = 8;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = StartPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (Vector3Info element in targetPosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasClientTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, ClientTime);
}
 if (HasFlyHeight) {
size += pb::CodedOutputStream.ComputeInt32Size(4, FlyHeight);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Type);
}
 if (HasSpeed) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Speed);
}
 if (HasFlow) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Flow);
}
 if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(8, ObjectId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StartPos.SerializedSize());
StartPos.WriteTo(output);

}

do{
foreach (Vector3Info element in targetPosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasClientTime) {
output.WriteInt64(3, ClientTime);
}
 
if (HasFlyHeight) {
output.WriteInt32(4, FlyHeight);
}
 
if (HasType) {
output.WriteInt32(5, Type);
}
 
if (HasSpeed) {
output.WriteInt32(6, Speed);
}
 
if (HasFlow) {
output.WriteInt32(7, Flow);
}
 
if (HasObjectId) {
output.WriteInt64(8, ObjectId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSendMove _inst = (CGSendMove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StartPos = subBuilder;
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
input.ReadMessage(subBuilder);
_inst.AddTargetPos(subBuilder);
break;
}
   case  24: {
 _inst.ClientTime = input.ReadInt64();
break;
}
   case  32: {
 _inst.FlyHeight = input.ReadInt32();
break;
}
   case  40: {
 _inst.Type = input.ReadInt32();
break;
}
   case  48: {
 _inst.Speed = input.ReadInt32();
break;
}
   case  56: {
 _inst.Flow = input.ReadInt32();
break;
}
   case  64: {
 _inst.ObjectId = input.ReadInt64();
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
foreach (Vector3Info element in targetPosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGStopMove : PacketDistributed
{

public const int stopPositionFieldNumber = 1;
 private bool hasStopPosition;
 private Vector3Info stopPosition_ =  new Vector3Info();
 public bool HasStopPosition {
 get { return hasStopPosition; }
 }
 public Vector3Info StopPosition {
 get { return stopPosition_; }
 set { SetStopPosition(value); }
 }
 public void SetStopPosition(Vector3Info value) { 
 hasStopPosition = true;
 stopPosition_ = value;
 }

public const int dirPositionFieldNumber = 2;
 private bool hasDirPosition;
 private Vector3Info dirPosition_ =  new Vector3Info();
 public bool HasDirPosition {
 get { return hasDirPosition; }
 }
 public Vector3Info DirPosition {
 get { return dirPosition_; }
 set { SetDirPosition(value); }
 }
 public void SetDirPosition(Vector3Info value) { 
 hasDirPosition = true;
 dirPosition_ = value;
 }

public const int flyHeightFieldNumber = 3;
 private bool hasFlyHeight;
 private Int32 flyHeight_ = 0;
 public bool HasFlyHeight {
 get { return hasFlyHeight; }
 }
 public Int32 FlyHeight {
 get { return flyHeight_; }
 set { SetFlyHeight(value); }
 }
 public void SetFlyHeight(Int32 value) { 
 hasFlyHeight = true;
 flyHeight_ = value;
 }

public const int typeFieldNumber = 4;
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

public const int objectIdFieldNumber = 5;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = StopPosition.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = DirPosition.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasFlyHeight) {
size += pb::CodedOutputStream.ComputeInt32Size(3, FlyHeight);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Type);
}
 if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(5, ObjectId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StopPosition.SerializedSize());
StopPosition.WriteTo(output);

}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)DirPosition.SerializedSize());
DirPosition.WriteTo(output);

}
 
if (HasFlyHeight) {
output.WriteInt32(3, FlyHeight);
}
 
if (HasType) {
output.WriteInt32(4, Type);
}
 
if (HasObjectId) {
output.WriteInt64(5, ObjectId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGStopMove _inst = (CGStopMove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StopPosition = subBuilder;
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.DirPosition = subBuilder;
break;
}
   case  24: {
 _inst.FlyHeight = input.ReadInt32();
break;
}
   case  32: {
 _inst.Type = input.ReadInt32();
break;
}
   case  40: {
 _inst.ObjectId = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasStopPosition) {
if (!StopPosition.IsInitialized()) return false;
}
  if (HasDirPosition) {
if (!DirPosition.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGSynPlayerPos : PacketDistributed
{

public const int positionFieldNumber = 1;
 private bool hasPosition;
 private Vector3Info position_ =  new Vector3Info();
 public bool HasPosition {
 get { return hasPosition; }
 }
 public Vector3Info Position {
 get { return position_; }
 set { SetPosition(value); }
 }
 public void SetPosition(Vector3Info value) { 
 hasPosition = true;
 position_ = value;
 }

public const int dirPositionFieldNumber = 2;
 private bool hasDirPosition;
 private Vector3Info dirPosition_ =  new Vector3Info();
 public bool HasDirPosition {
 get { return hasDirPosition; }
 }
 public Vector3Info DirPosition {
 get { return dirPosition_; }
 set { SetDirPosition(value); }
 }
 public void SetDirPosition(Vector3Info value) { 
 hasDirPosition = true;
 dirPosition_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Position.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = DirPosition.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Position.SerializedSize());
Position.WriteTo(output);

}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)DirPosition.SerializedSize());
DirPosition.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSynPlayerPos _inst = (CGSynPlayerPos) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Position = subBuilder;
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.DirPosition = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPosition) {
if (!Position.IsInitialized()) return false;
}
  if (HasDirPosition) {
if (!DirPosition.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGTeleport : PacketDistributed
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

public const int posFieldNumber = 2;
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

public const int directionFieldNumber = 3;
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

public const int navMeshIdFieldNumber = 4;
 private bool hasNavMeshId;
 private Int32 navMeshId_ = 0;
 public bool HasNavMeshId {
 get { return hasNavMeshId; }
 }
 public Int32 NavMeshId {
 get { return navMeshId_; }
 set { SetNavMeshId(value); }
 }
 public void SetNavMeshId(Int32 value) { 
 hasNavMeshId = true;
 navMeshId_ = value;
 }

public const int objIdFieldNumber = 5;
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
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasNavMeshId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, NavMeshId);
}
 if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(5, ObjId);
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
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
 
if (HasNavMeshId) {
output.WriteInt32(4, NavMeshId);
}
 
if (HasObjId) {
output.WriteInt64(5, ObjId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTeleport _inst = (CGTeleport) _base;
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
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}
   case  32: {
 _inst.NavMeshId = input.ReadInt32();
break;
}
   case  40: {
 _inst.ObjId = input.ReadInt64();
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
public class CharacterHurtInfo : PacketDistributed
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

public const int totalHurtFieldNumber = 2;
 private bool hasTotalHurt;
 private Int32 totalHurt_ = 0;
 public bool HasTotalHurt {
 get { return hasTotalHurt; }
 }
 public Int32 TotalHurt {
 get { return totalHurt_; }
 set { SetTotalHurt(value); }
 }
 public void SetTotalHurt(Int32 value) { 
 hasTotalHurt = true;
 totalHurt_ = value;
 }

public const int charNameFieldNumber = 3;
 private bool hasCharName;
 private string charName_ = "";
 public bool HasCharName {
 get { return hasCharName; }
 }
 public string CharName {
 get { return charName_; }
 set { SetCharName(value); }
 }
 public void SetCharName(string value) { 
 hasCharName = true;
 charName_ = value;
 }

public const int typeFieldNumber = 4;
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
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasTotalHurt) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TotalHurt);
}
 if (HasCharName) {
size += pb::CodedOutputStream.ComputeStringSize(3, CharName);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Type);
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
 
if (HasTotalHurt) {
output.WriteInt32(2, TotalHurt);
}
 
if (HasCharName) {
output.WriteString(3, CharName);
}
 
if (HasType) {
output.WriteInt32(4, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CharacterHurtInfo _inst = (CharacterHurtInfo) _base;
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
 _inst.TotalHurt = input.ReadInt32();
break;
}
   case  26: {
 _inst.CharName = input.ReadString();
break;
}
   case  32: {
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
public class GCCharObjDieBack : PacketDistributed
{

public const int objIdsFieldNumber = 1;
 private pbc::PopsicleList<Int64> objIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdsList {
 get { return pbc::Lists.AsReadOnly(objIds_); }
 }
 
 public int objIdsCount {
 get { return objIds_.Count; }
 }
 
public Int64 GetObjIds(int index) {
 return objIds_[index];
 }
 public void AddObjIds(Int64 value) {
 objIds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in objIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objIds_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (objIds_.Count > 0) {
foreach (Int64 element in objIdsList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCharObjDieBack _inst = (GCCharObjDieBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddObjIds(input.ReadInt64());
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
public class GCCharacterChangeMotion : PacketDistributed
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
 private pbc::PopsicleList<Int64> objId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdList {
 get { return pbc::Lists.AsReadOnly(objId_); }
 }
 
 public int objIdCount {
 get { return objId_.Count; }
 }
 
public Int64 GetObjId(int index) {
 return objId_[index];
 }
 public void AddObjId(Int64 value) {
 objId_.Add(value);
 }

public const int targetObjIdFieldNumber = 3;
 private bool hasTargetObjId;
 private Int64 targetObjId_ = 0;
 public bool HasTargetObjId {
 get { return hasTargetObjId; }
 }
 public Int64 TargetObjId {
 get { return targetObjId_; }
 set { SetTargetObjId(value); }
 }
 public void SetTargetObjId(Int64 value) { 
 hasTargetObjId = true;
 targetObjId_ = value;
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
{
int dataSize = 0;
foreach (Int64 element in objIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objId_.Count;
}
 if (HasTargetObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, TargetObjId);
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
{
if (objId_.Count > 0) {
foreach (Int64 element in objIdList) {
output.WriteInt64(2,element);
}
}

}
 
if (HasTargetObjId) {
output.WriteInt64(3, TargetObjId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCharacterChangeMotion _inst = (GCCharacterChangeMotion) _base;
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
 _inst.AddObjId(input.ReadInt64());
break;
}
   case  24: {
 _inst.TargetObjId = input.ReadInt64();
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
public class GCCharacterObjsInView : PacketDistributed
{

public const int characterObjsFieldNumber = 1;
 private pbc::PopsicleList<CharacterInfo> characterObjs_ = new pbc::PopsicleList<CharacterInfo>();
 public scg::IList<CharacterInfo> characterObjsList {
 get { return pbc::Lists.AsReadOnly(characterObjs_); }
 }
 
 public int characterObjsCount {
 get { return characterObjs_.Count; }
 }
 
public CharacterInfo GetCharacterObjs(int index) {
 return characterObjs_[index];
 }
 public void AddCharacterObjs(CharacterInfo value) {
 characterObjs_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (CharacterInfo element in characterObjsList) {
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
foreach (CharacterInfo element in characterObjsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCharacterObjsInView _inst = (GCCharacterObjsInView) _base;
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
_inst.AddCharacterObjs(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CharacterInfo element in characterObjsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCharacterRelation : PacketDistributed
{

public const int objectIdFieldNumber = 1;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int attackStsFieldNumber = 2;
 private bool hasAttackSts;
 private Int32 attackSts_ = 0;
 public bool HasAttackSts {
 get { return hasAttackSts; }
 }
 public Int32 AttackSts {
 get { return attackSts_; }
 set { SetAttackSts(value); }
 }
 public void SetAttackSts(Int32 value) { 
 hasAttackSts = true;
 attackSts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjectId);
}
 if (HasAttackSts) {
size += pb::CodedOutputStream.ComputeInt32Size(2, AttackSts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjectId) {
output.WriteInt64(1, ObjectId);
}
 
if (HasAttackSts) {
output.WriteInt32(2, AttackSts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCharacterRelation _inst = (GCCharacterRelation) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjectId = input.ReadInt64();
break;
}
   case  16: {
 _inst.AttackSts = input.ReadInt32();
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
public class GCDelCharacterHurtInfo : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private pbc::PopsicleList<Int64> objId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdList {
 get { return pbc::Lists.AsReadOnly(objId_); }
 }
 
 public int objIdCount {
 get { return objId_.Count; }
 }
 
public Int64 GetObjId(int index) {
 return objId_[index];
 }
 public void AddObjId(Int64 value) {
 objId_.Add(value);
 }

public const int refreshTypeFieldNumber = 2;
 private bool hasRefreshType;
 private Int32 refreshType_ = 0;
 public bool HasRefreshType {
 get { return hasRefreshType; }
 }
 public Int32 RefreshType {
 get { return refreshType_; }
 set { SetRefreshType(value); }
 }
 public void SetRefreshType(Int32 value) { 
 hasRefreshType = true;
 refreshType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in objIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objId_.Count;
}
 if (HasRefreshType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RefreshType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (objId_.Count > 0) {
foreach (Int64 element in objIdList) {
output.WriteInt64(1,element);
}
}

}
 
if (HasRefreshType) {
output.WriteInt32(2, RefreshType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDelCharacterHurtInfo _inst = (GCDelCharacterHurtInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddObjId(input.ReadInt64());
break;
}
   case  16: {
 _inst.RefreshType = input.ReadInt32();
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
public class GCDelObjInSceneBack : PacketDistributed
{

public const int objIdsFieldNumber = 1;
 private pbc::PopsicleList<Int64> objIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdsList {
 get { return pbc::Lists.AsReadOnly(objIds_); }
 }
 
 public int objIdsCount {
 get { return objIds_.Count; }
 }
 
public Int64 GetObjIds(int index) {
 return objIds_[index];
 }
 public void AddObjIds(Int64 value) {
 objIds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in objIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objIds_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (objIds_.Count > 0) {
foreach (Int64 element in objIdsList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDelObjInSceneBack _inst = (GCDelObjInSceneBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddObjIds(input.ReadInt64());
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
public class GCEnterScene : PacketDistributed
{

public const int sceneIdFieldNumber = 1;
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

public const int reasonFieldNumber = 2;
 private bool hasReason;
 private Int32 reason_ = 0;
 public bool HasReason {
 get { return hasReason; }
 }
 public Int32 Reason {
 get { return reason_; }
 set { SetReason(value); }
 }
 public void SetReason(Int32 value) { 
 hasReason = true;
 reason_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSceneId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneId);
}
 if (HasReason) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Reason);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneId) {
output.WriteInt32(1, SceneId);
}
 
if (HasReason) {
output.WriteInt32(2, Reason);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEnterScene _inst = (GCEnterScene) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Reason = input.ReadInt32();
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
public class GCEnterSceneOk : PacketDistributed
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
 GCEnterSceneOk _inst = (GCEnterSceneOk) _base;
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
public class GCPickDevice : PacketDistributed
{

public const int objIdsFieldNumber = 1;
 private pbc::PopsicleList<Int64> objIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdsList {
 get { return pbc::Lists.AsReadOnly(objIds_); }
 }
 
 public int objIdsCount {
 get { return objIds_.Count; }
 }
 
public Int64 GetObjIds(int index) {
 return objIds_[index];
 }
 public void AddObjIds(Int64 value) {
 objIds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in objIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objIds_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (objIds_.Count > 0) {
foreach (Int64 element in objIdsList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPickDevice _inst = (GCPickDevice) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddObjIds(input.ReadInt64());
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
public class GCPutDeviceInfo : PacketDistributed
{

public const int deviceInfoFieldNumber = 1;
 private pbc::PopsicleList<DeviceInfo> deviceInfo_ = new pbc::PopsicleList<DeviceInfo>();
 public scg::IList<DeviceInfo> deviceInfoList {
 get { return pbc::Lists.AsReadOnly(deviceInfo_); }
 }
 
 public int deviceInfoCount {
 get { return deviceInfo_.Count; }
 }
 
public DeviceInfo GetDeviceInfo(int index) {
 return deviceInfo_[index];
 }
 public void AddDeviceInfo(DeviceInfo value) {
 deviceInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (DeviceInfo element in deviceInfoList) {
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
foreach (DeviceInfo element in deviceInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPutDeviceInfo _inst = (GCPutDeviceInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
DeviceInfo subBuilder =  new DeviceInfo();
input.ReadMessage(subBuilder);
_inst.AddDeviceInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (DeviceInfo element in deviceInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshCharacterHurtInfo : PacketDistributed
{

public const int hurtInfoArrFieldNumber = 1;
 private pbc::PopsicleList<CharacterHurtInfo> hurtInfoArr_ = new pbc::PopsicleList<CharacterHurtInfo>();
 public scg::IList<CharacterHurtInfo> hurtInfoArrList {
 get { return pbc::Lists.AsReadOnly(hurtInfoArr_); }
 }
 
 public int hurtInfoArrCount {
 get { return hurtInfoArr_.Count; }
 }
 
public CharacterHurtInfo GetHurtInfoArr(int index) {
 return hurtInfoArr_[index];
 }
 public void AddHurtInfoArr(CharacterHurtInfo value) {
 hurtInfoArr_.Add(value);
 }

public const int selfHurtInfoFieldNumber = 2;
 private bool hasSelfHurtInfo;
 private CharacterHurtInfo selfHurtInfo_ =  new CharacterHurtInfo();
 public bool HasSelfHurtInfo {
 get { return hasSelfHurtInfo; }
 }
 public CharacterHurtInfo SelfHurtInfo {
 get { return selfHurtInfo_; }
 set { SetSelfHurtInfo(value); }
 }
 public void SetSelfHurtInfo(CharacterHurtInfo value) { 
 hasSelfHurtInfo = true;
 selfHurtInfo_ = value;
 }

public const int damageObjIdFieldNumber = 3;
 private bool hasDamageObjId;
 private Int64 damageObjId_ = 0;
 public bool HasDamageObjId {
 get { return hasDamageObjId; }
 }
 public Int64 DamageObjId {
 get { return damageObjId_; }
 set { SetDamageObjId(value); }
 }
 public void SetDamageObjId(Int64 value) { 
 hasDamageObjId = true;
 damageObjId_ = value;
 }

public const int refreshTypeFieldNumber = 4;
 private bool hasRefreshType;
 private Int32 refreshType_ = 0;
 public bool HasRefreshType {
 get { return hasRefreshType; }
 }
 public Int32 RefreshType {
 get { return refreshType_; }
 set { SetRefreshType(value); }
 }
 public void SetRefreshType(Int32 value) { 
 hasRefreshType = true;
 refreshType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (CharacterHurtInfo element in hurtInfoArrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = SelfHurtInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasDamageObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, DamageObjId);
}
 if (HasRefreshType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, RefreshType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (CharacterHurtInfo element in hurtInfoArrList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SelfHurtInfo.SerializedSize());
SelfHurtInfo.WriteTo(output);

}
 
if (HasDamageObjId) {
output.WriteInt64(3, DamageObjId);
}
 
if (HasRefreshType) {
output.WriteInt32(4, RefreshType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshCharacterHurtInfo _inst = (GCRefreshCharacterHurtInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterHurtInfo subBuilder =  new CharacterHurtInfo();
input.ReadMessage(subBuilder);
_inst.AddHurtInfoArr(subBuilder);
break;
}
    case  18: {
CharacterHurtInfo subBuilder =  new CharacterHurtInfo();
 input.ReadMessage(subBuilder);
_inst.SelfHurtInfo = subBuilder;
break;
}
   case  24: {
 _inst.DamageObjId = input.ReadInt64();
break;
}
   case  32: {
 _inst.RefreshType = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CharacterHurtInfo element in hurtInfoArrList) {
if (!element.IsInitialized()) return false;
}
  if (HasSelfHurtInfo) {
if (!SelfHurtInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshDeviceInfo : PacketDistributed
{

public const int deviceInfoFieldNumber = 1;
 private bool hasDeviceInfo;
 private DeviceInfo deviceInfo_ =  new DeviceInfo();
 public bool HasDeviceInfo {
 get { return hasDeviceInfo; }
 }
 public DeviceInfo DeviceInfo {
 get { return deviceInfo_; }
 set { SetDeviceInfo(value); }
 }
 public void SetDeviceInfo(DeviceInfo value) { 
 hasDeviceInfo = true;
 deviceInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = DeviceInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)DeviceInfo.SerializedSize());
DeviceInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshDeviceInfo _inst = (GCRefreshDeviceInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
DeviceInfo subBuilder =  new DeviceInfo();
 input.ReadMessage(subBuilder);
_inst.DeviceInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasDeviceInfo) {
if (!DeviceInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshPlayerAttr : PacketDistributed
{

public const int mySelfFieldNumber = 1;
 private bool hasMySelf;
 private CharacterInfo mySelf_ =  new CharacterInfo();
 public bool HasMySelf {
 get { return hasMySelf; }
 }
 public CharacterInfo MySelf {
 get { return mySelf_; }
 set { SetMySelf(value); }
 }
 public void SetMySelf(CharacterInfo value) { 
 hasMySelf = true;
 mySelf_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = MySelf.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)MySelf.SerializedSize());
MySelf.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshPlayerAttr _inst = (GCRefreshPlayerAttr) _base;
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
_inst.MySelf = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasMySelf) {
if (!MySelf.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshTrapData : PacketDistributed
{

public const int trapDataFieldNumber = 1;
 private pbc::PopsicleList<TrapData> trapData_ = new pbc::PopsicleList<TrapData>();
 public scg::IList<TrapData> trapDataList {
 get { return pbc::Lists.AsReadOnly(trapData_); }
 }
 
 public int trapDataCount {
 get { return trapData_.Count; }
 }
 
public TrapData GetTrapData(int index) {
 return trapData_[index];
 }
 public void AddTrapData(TrapData value) {
 trapData_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (TrapData element in trapDataList) {
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
foreach (TrapData element in trapDataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshTrapData _inst = (GCRefreshTrapData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TrapData subBuilder =  new TrapData();
input.ReadMessage(subBuilder);
_inst.AddTrapData(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TrapData element in trapDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendMove : PacketDistributed
{

public const int startPosFieldNumber = 1;
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

public const int targetPosFieldNumber = 2;
 private pbc::PopsicleList<Vector3Info> targetPos_ = new pbc::PopsicleList<Vector3Info>();
 public scg::IList<Vector3Info> targetPosList {
 get { return pbc::Lists.AsReadOnly(targetPos_); }
 }
 
 public int targetPosCount {
 get { return targetPos_.Count; }
 }
 
public Vector3Info GetTargetPos(int index) {
 return targetPos_[index];
 }
 public void AddTargetPos(Vector3Info value) {
 targetPos_.Add(value);
 }

public const int objectIdFieldNumber = 3;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int startMoveTimeFieldNumber = 4;
 private bool hasStartMoveTime;
 private Int64 startMoveTime_ = 0;
 public bool HasStartMoveTime {
 get { return hasStartMoveTime; }
 }
 public Int64 StartMoveTime {
 get { return startMoveTime_; }
 set { SetStartMoveTime(value); }
 }
 public void SetStartMoveTime(Int64 value) { 
 hasStartMoveTime = true;
 startMoveTime_ = value;
 }

public const int flyHeightFieldNumber = 5;
 private bool hasFlyHeight;
 private Int32 flyHeight_ = 0;
 public bool HasFlyHeight {
 get { return hasFlyHeight; }
 }
 public Int32 FlyHeight {
 get { return flyHeight_; }
 set { SetFlyHeight(value); }
 }
 public void SetFlyHeight(Int32 value) { 
 hasFlyHeight = true;
 flyHeight_ = value;
 }

public const int typeFieldNumber = 6;
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

public const int speedFieldNumber = 7;
 private bool hasSpeed;
 private Int32 speed_ = 0;
 public bool HasSpeed {
 get { return hasSpeed; }
 }
 public Int32 Speed {
 get { return speed_; }
 set { SetSpeed(value); }
 }
 public void SetSpeed(Int32 value) { 
 hasSpeed = true;
 speed_ = value;
 }

public const int flowFieldNumber = 8;
 private bool hasFlow;
 private Int32 flow_ = 0;
 public bool HasFlow {
 get { return hasFlow; }
 }
 public Int32 Flow {
 get { return flow_; }
 set { SetFlow(value); }
 }
 public void SetFlow(Int32 value) { 
 hasFlow = true;
 flow_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = StartPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (Vector3Info element in targetPosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, ObjectId);
}
 if (HasStartMoveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, StartMoveTime);
}
 if (HasFlyHeight) {
size += pb::CodedOutputStream.ComputeInt32Size(5, FlyHeight);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Type);
}
 if (HasSpeed) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Speed);
}
 if (HasFlow) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Flow);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StartPos.SerializedSize());
StartPos.WriteTo(output);

}

do{
foreach (Vector3Info element in targetPosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasObjectId) {
output.WriteInt64(3, ObjectId);
}
 
if (HasStartMoveTime) {
output.WriteInt64(4, StartMoveTime);
}
 
if (HasFlyHeight) {
output.WriteInt32(5, FlyHeight);
}
 
if (HasType) {
output.WriteInt32(6, Type);
}
 
if (HasSpeed) {
output.WriteInt32(7, Speed);
}
 
if (HasFlow) {
output.WriteInt32(8, Flow);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendMove _inst = (GCSendMove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StartPos = subBuilder;
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
input.ReadMessage(subBuilder);
_inst.AddTargetPos(subBuilder);
break;
}
   case  24: {
 _inst.ObjectId = input.ReadInt64();
break;
}
   case  32: {
 _inst.StartMoveTime = input.ReadInt64();
break;
}
   case  40: {
 _inst.FlyHeight = input.ReadInt32();
break;
}
   case  48: {
 _inst.Type = input.ReadInt32();
break;
}
   case  56: {
 _inst.Speed = input.ReadInt32();
break;
}
   case  64: {
 _inst.Flow = input.ReadInt32();
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
foreach (Vector3Info element in targetPosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCShowHideObjInSceneBack : PacketDistributed
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

public const int objIdsFieldNumber = 2;
 private pbc::PopsicleList<Int64> objIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdsList {
 get { return pbc::Lists.AsReadOnly(objIds_); }
 }
 
 public int objIdsCount {
 get { return objIds_.Count; }
 }
 
public Int64 GetObjIds(int index) {
 return objIds_[index];
 }
 public void AddObjIds(Int64 value) {
 objIds_.Add(value);
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
int dataSize = 0;
foreach (Int64 element in objIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objIds_.Count;
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
if (objIds_.Count > 0) {
foreach (Int64 element in objIdsList) {
output.WriteInt64(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCShowHideObjInSceneBack _inst = (GCShowHideObjInSceneBack) _base;
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
 _inst.AddObjIds(input.ReadInt64());
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
public class GCStopMove : PacketDistributed
{

public const int objectIdFieldNumber = 1;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int stopPositionFieldNumber = 2;
 private bool hasStopPosition;
 private Vector3Info stopPosition_ =  new Vector3Info();
 public bool HasStopPosition {
 get { return hasStopPosition; }
 }
 public Vector3Info StopPosition {
 get { return stopPosition_; }
 set { SetStopPosition(value); }
 }
 public void SetStopPosition(Vector3Info value) { 
 hasStopPosition = true;
 stopPosition_ = value;
 }

public const int dirPositionFieldNumber = 3;
 private bool hasDirPosition;
 private Vector3Info dirPosition_ =  new Vector3Info();
 public bool HasDirPosition {
 get { return hasDirPosition; }
 }
 public Vector3Info DirPosition {
 get { return dirPosition_; }
 set { SetDirPosition(value); }
 }
 public void SetDirPosition(Vector3Info value) { 
 hasDirPosition = true;
 dirPosition_ = value;
 }

public const int flyHeightFieldNumber = 4;
 private bool hasFlyHeight;
 private Int32 flyHeight_ = 0;
 public bool HasFlyHeight {
 get { return hasFlyHeight; }
 }
 public Int32 FlyHeight {
 get { return flyHeight_; }
 set { SetFlyHeight(value); }
 }
 public void SetFlyHeight(Int32 value) { 
 hasFlyHeight = true;
 flyHeight_ = value;
 }

public const int typeFieldNumber = 5;
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
  if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjectId);
}
{
int subsize = StopPosition.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = DirPosition.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasFlyHeight) {
size += pb::CodedOutputStream.ComputeInt32Size(4, FlyHeight);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjectId) {
output.WriteInt64(1, ObjectId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)StopPosition.SerializedSize());
StopPosition.WriteTo(output);

}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)DirPosition.SerializedSize());
DirPosition.WriteTo(output);

}
 
if (HasFlyHeight) {
output.WriteInt32(4, FlyHeight);
}
 
if (HasType) {
output.WriteInt32(5, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCStopMove _inst = (GCStopMove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjectId = input.ReadInt64();
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.StopPosition = subBuilder;
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.DirPosition = subBuilder;
break;
}
   case  32: {
 _inst.FlyHeight = input.ReadInt32();
break;
}
   case  40: {
 _inst.Type = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasStopPosition) {
if (!StopPosition.IsInitialized()) return false;
}
  if (HasDirPosition) {
if (!DirPosition.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSyncCharacterPos : PacketDistributed
{

public const int objectIdFieldNumber = 1;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int positionFieldNumber = 2;
 private bool hasPosition;
 private Vector3Info position_ =  new Vector3Info();
 public bool HasPosition {
 get { return hasPosition; }
 }
 public Vector3Info Position {
 get { return position_; }
 set { SetPosition(value); }
 }
 public void SetPosition(Vector3Info value) { 
 hasPosition = true;
 position_ = value;
 }

public const int dirFieldNumber = 3;
 private bool hasDir;
 private Vector3Info dir_ =  new Vector3Info();
 public bool HasDir {
 get { return hasDir; }
 }
 public Vector3Info Dir {
 get { return dir_; }
 set { SetDir(value); }
 }
 public void SetDir(Vector3Info value) { 
 hasDir = true;
 dir_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjectId);
}
{
int subsize = Position.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Dir.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjectId) {
output.WriteInt64(1, ObjectId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Position.SerializedSize());
Position.WriteTo(output);

}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Dir.SerializedSize());
Dir.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSyncCharacterPos _inst = (GCSyncCharacterPos) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjectId = input.ReadInt64();
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Position = subBuilder;
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Dir = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPosition) {
if (!Position.IsInitialized()) return false;
}
  if (HasDir) {
if (!Dir.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSyncCharacterRelation : PacketDistributed
{

public const int relationsFieldNumber = 1;
 private pbc::PopsicleList<GCCharacterRelation> relations_ = new pbc::PopsicleList<GCCharacterRelation>();
 public scg::IList<GCCharacterRelation> relationsList {
 get { return pbc::Lists.AsReadOnly(relations_); }
 }
 
 public int relationsCount {
 get { return relations_.Count; }
 }
 
public GCCharacterRelation GetRelations(int index) {
 return relations_[index];
 }
 public void AddRelations(GCCharacterRelation value) {
 relations_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GCCharacterRelation element in relationsList) {
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
foreach (GCCharacterRelation element in relationsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSyncCharacterRelation _inst = (GCSyncCharacterRelation) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GCCharacterRelation subBuilder =  new GCCharacterRelation();
input.ReadMessage(subBuilder);
_inst.AddRelations(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCCharacterRelation element in relationsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTeleport : PacketDistributed
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

public const int posFieldNumber = 3;
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

public const int directionFieldNumber = 4;
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

public const int navMeshIdFieldNumber = 5;
 private bool hasNavMeshId;
 private Int32 navMeshId_ = 0;
 public bool HasNavMeshId {
 get { return hasNavMeshId; }
 }
 public Int32 NavMeshId {
 get { return navMeshId_; }
 set { SetNavMeshId(value); }
 }
 public void SetNavMeshId(Int32 value) { 
 hasNavMeshId = true;
 navMeshId_ = value;
 }

public const int objIdFieldNumber = 6;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasNavMeshId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, NavMeshId);
}
 if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(6, ObjId);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
 
if (HasNavMeshId) {
output.WriteInt32(5, NavMeshId);
}
 
if (HasObjId) {
output.WriteInt64(6, ObjId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTeleport _inst = (GCTeleport) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}
   case  40: {
 _inst.NavMeshId = input.ReadInt32();
break;
}
   case  48: {
 _inst.ObjId = input.ReadInt64();
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
public class GCTrapItemStartMove : PacketDistributed
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

public const int itemIndexFieldNumber = 2;
 private pbc::PopsicleList<Int32> itemIndex_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> itemIndexList {
 get { return pbc::Lists.AsReadOnly(itemIndex_); }
 }
 
 public int itemIndexCount {
 get { return itemIndex_.Count; }
 }
 
public Int32 GetItemIndex(int index) {
 return itemIndex_[index];
 }
 public void AddItemIndex(Int32 value) {
 itemIndex_.Add(value);
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
foreach (Int32 element in itemIndexList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * itemIndex_.Count;
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
if (itemIndex_.Count > 0) {
foreach (Int32 element in itemIndexList) {
output.WriteInt32(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTrapItemStartMove _inst = (GCTrapItemStartMove) _base;
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
 _inst.AddItemIndex(input.ReadInt32());
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
public class GGEnterExistScene : PacketDistributed
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

public const int posFieldNumber = 2;
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

public const int directionFieldNumber = 3;
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

public const int objIdFieldNumber = 4;
 private pbc::PopsicleList<Int64> objId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdList {
 get { return pbc::Lists.AsReadOnly(objId_); }
 }
 
 public int objIdCount {
 get { return objId_.Count; }
 }
 
public Int64 GetObjId(int index) {
 return objId_[index];
 }
 public void AddObjId(Int64 value) {
 objId_.Add(value);
 }

public const int notBackGCEnterSceneFieldNumber = 5;
 private bool hasNotBackGCEnterScene;
 private Int32 notBackGCEnterScene_ = 0;
 public bool HasNotBackGCEnterScene {
 get { return hasNotBackGCEnterScene; }
 }
 public Int32 NotBackGCEnterScene {
 get { return notBackGCEnterScene_; }
 set { SetNotBackGCEnterScene(value); }
 }
 public void SetNotBackGCEnterScene(Int32 value) { 
 hasNotBackGCEnterScene = true;
 notBackGCEnterScene_ = value;
 }

public const int reasonFieldNumber = 6;
 private bool hasReason;
 private Int32 reason_ = 0;
 public bool HasReason {
 get { return hasReason; }
 }
 public Int32 Reason {
 get { return reason_; }
 set { SetReason(value); }
 }
 public void SetReason(Int32 value) { 
 hasReason = true;
 reason_ = value;
 }

public const int reasonParamsFieldNumber = 7;
 private pbc::PopsicleList<string> reasonParams_ = new pbc::PopsicleList<string>();
 public scg::IList<string> reasonParamsList {
 get { return pbc::Lists.AsReadOnly(reasonParams_); }
 }
 
 public int reasonParamsCount {
 get { return reasonParams_.Count; }
 }
 
public string GetReasonParams(int index) {
 return reasonParams_[index];
 }
 public void AddReasonParams(string value) {
 reasonParams_.Add(value);
 }

public const int sameMuiltLineSceneFieldNumber = 8;
 private bool hasSameMuiltLineScene;
 private Int32 sameMuiltLineScene_ = 0;
 public bool HasSameMuiltLineScene {
 get { return hasSameMuiltLineScene; }
 }
 public Int32 SameMuiltLineScene {
 get { return sameMuiltLineScene_; }
 set { SetSameMuiltLineScene(value); }
 }
 public void SetSameMuiltLineScene(Int32 value) { 
 hasSameMuiltLineScene = true;
 sameMuiltLineScene_ = value;
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
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int dataSize = 0;
foreach (Int64 element in objIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objId_.Count;
}
 if (HasNotBackGCEnterScene) {
size += pb::CodedOutputStream.ComputeInt32Size(5, NotBackGCEnterScene);
}
 if (HasReason) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Reason);
}
{
int dataSize = 0;
foreach (string element in reasonParamsList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * reasonParams_.Count;
}
 if (HasSameMuiltLineScene) {
size += pb::CodedOutputStream.ComputeInt32Size(8, SameMuiltLineScene);
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
{
if (objId_.Count > 0) {
foreach (Int64 element in objIdList) {
output.WriteInt64(4,element);
}
}

}
 
if (HasNotBackGCEnterScene) {
output.WriteInt32(5, NotBackGCEnterScene);
}
 
if (HasReason) {
output.WriteInt32(6, Reason);
}
{
if (reasonParams_.Count > 0) {
foreach (string element in reasonParamsList) {
output.WriteString(7,element);
}
}

}
 
if (HasSameMuiltLineScene) {
output.WriteInt32(8, SameMuiltLineScene);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GGEnterExistScene _inst = (GGEnterExistScene) _base;
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
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}
   case  32: {
 _inst.AddObjId(input.ReadInt64());
break;
}
   case  40: {
 _inst.NotBackGCEnterScene = input.ReadInt32();
break;
}
   case  48: {
 _inst.Reason = input.ReadInt32();
break;
}
   case  58: {
 _inst.AddReasonParams(input.ReadString());
break;
}
   case  64: {
 _inst.SameMuiltLineScene = input.ReadInt32();
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
public class GGLeaveScene : PacketDistributed
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

public const int objIdFieldNumber = 2;
 private pbc::PopsicleList<Int64> objId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> objIdList {
 get { return pbc::Lists.AsReadOnly(objId_); }
 }
 
 public int objIdCount {
 get { return objId_.Count; }
 }
 
public Int64 GetObjId(int index) {
 return objId_[index];
 }
 public void AddObjId(Int64 value) {
 objId_.Add(value);
 }

public const int reasonFieldNumber = 3;
 private bool hasReason;
 private Int32 reason_ = 0;
 public bool HasReason {
 get { return hasReason; }
 }
 public Int32 Reason {
 get { return reason_; }
 set { SetReason(value); }
 }
 public void SetReason(Int32 value) { 
 hasReason = true;
 reason_ = value;
 }

public const int reasonParamsFieldNumber = 4;
 private pbc::PopsicleList<string> reasonParams_ = new pbc::PopsicleList<string>();
 public scg::IList<string> reasonParamsList {
 get { return pbc::Lists.AsReadOnly(reasonParams_); }
 }
 
 public int reasonParamsCount {
 get { return reasonParams_.Count; }
 }
 
public string GetReasonParams(int index) {
 return reasonParams_[index];
 }
 public void AddReasonParams(string value) {
 reasonParams_.Add(value);
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
{
int dataSize = 0;
foreach (Int64 element in objIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * objId_.Count;
}
 if (HasReason) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Reason);
}
{
int dataSize = 0;
foreach (string element in reasonParamsList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * reasonParams_.Count;
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
{
if (objId_.Count > 0) {
foreach (Int64 element in objIdList) {
output.WriteInt64(2,element);
}
}

}
 
if (HasReason) {
output.WriteInt32(3, Reason);
}
{
if (reasonParams_.Count > 0) {
foreach (string element in reasonParamsList) {
output.WriteString(4,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GGLeaveScene _inst = (GGLeaveScene) _base;
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
   case  16: {
 _inst.AddObjId(input.ReadInt64());
break;
}
   case  24: {
 _inst.Reason = input.ReadInt32();
break;
}
   case  34: {
 _inst.AddReasonParams(input.ReadString());
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
