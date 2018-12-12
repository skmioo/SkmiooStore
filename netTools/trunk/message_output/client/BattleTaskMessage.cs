//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class BattleTask : PacketDistributed
{

public const int taskIDFieldNumber = 1;
 private bool hasTaskID;
 private Int32 taskID_ = 0;
 public bool HasTaskID {
 get { return hasTaskID; }
 }
 public Int32 TaskID {
 get { return taskID_; }
 set { SetTaskID(value); }
 }
 public void SetTaskID(Int32 value) { 
 hasTaskID = true;
 taskID_ = value;
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

public const int numFieldNumber = 3;
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
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
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
  
if (HasTaskID) {
output.WriteInt32(1, TaskID);
}
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 
if (HasType) {
output.WriteInt32(4, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BattleTask _inst = (BattleTask) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TaskID = input.ReadInt32();
break;
}
   case  16: {
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.Num = input.ReadInt32();
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
public class GCBattleTaskInforBack : PacketDistributed
{

public const int battleTaskFieldNumber = 1;
 private bool hasBattleTask;
 private BattleTask battleTask_ =  new BattleTask();
 public bool HasBattleTask {
 get { return hasBattleTask; }
 }
 public BattleTask BattleTask {
 get { return battleTask_; }
 set { SetBattleTask(value); }
 }
 public void SetBattleTask(BattleTask value) { 
 hasBattleTask = true;
 battleTask_ = value;
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

public const int oldTaskIDFieldNumber = 3;
 private bool hasOldTaskID;
 private Int32 oldTaskID_ = 0;
 public bool HasOldTaskID {
 get { return hasOldTaskID; }
 }
 public Int32 OldTaskID {
 get { return oldTaskID_; }
 set { SetOldTaskID(value); }
 }
 public void SetOldTaskID(Int32 value) { 
 hasOldTaskID = true;
 oldTaskID_ = value;
 }

public const int taskStatusFieldNumber = 4;
 private bool hasTaskStatus;
 private Int32 taskStatus_ = 0;
 public bool HasTaskStatus {
 get { return hasTaskStatus; }
 }
 public Int32 TaskStatus {
 get { return taskStatus_; }
 set { SetTaskStatus(value); }
 }
 public void SetTaskStatus(Int32 value) { 
 hasTaskStatus = true;
 taskStatus_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = BattleTask.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasOldTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, OldTaskID);
}
 if (HasTaskStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TaskStatus);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)BattleTask.SerializedSize());
BattleTask.WriteTo(output);

}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasOldTaskID) {
output.WriteInt32(3, OldTaskID);
}
 
if (HasTaskStatus) {
output.WriteInt32(4, TaskStatus);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBattleTaskInforBack _inst = (GCBattleTaskInforBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BattleTask subBuilder =  new BattleTask();
 input.ReadMessage(subBuilder);
_inst.BattleTask = subBuilder;
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.OldTaskID = input.ReadInt32();
break;
}
   case  32: {
 _inst.TaskStatus = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasBattleTask) {
if (!BattleTask.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCBattleTaskListBack : PacketDistributed
{

public const int battleTasksFieldNumber = 1;
 private pbc::PopsicleList<BattleTask> battleTasks_ = new pbc::PopsicleList<BattleTask>();
 public scg::IList<BattleTask> battleTasksList {
 get { return pbc::Lists.AsReadOnly(battleTasks_); }
 }
 
 public int battleTasksCount {
 get { return battleTasks_.Count; }
 }
 
public BattleTask GetBattleTasks(int index) {
 return battleTasks_[index];
 }
 public void AddBattleTasks(BattleTask value) {
 battleTasks_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (BattleTask element in battleTasksList) {
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
foreach (BattleTask element in battleTasksList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBattleTaskListBack _inst = (GCBattleTaskListBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BattleTask subBuilder =  new BattleTask();
input.ReadMessage(subBuilder);
_inst.AddBattleTasks(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BattleTask element in battleTasksList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
