//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCatchComplate : PacketDistributed
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

public const int stageFieldNumber = 2;
 private bool hasStage;
 private Int32 stage_ = 0;
 public bool HasStage {
 get { return hasStage; }
 }
 public Int32 Stage {
 get { return stage_; }
 set { SetStage(value); }
 }
 public void SetStage(Int32 value) { 
 hasStage = true;
 stage_ = value;
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
 if (HasStage) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Stage);
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
 
if (HasStage) {
output.WriteInt32(2, Stage);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCatchComplate _inst = (CGCatchComplate) _base;
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
 _inst.Stage = input.ReadInt32();
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
public class CGCatchCreatMonster : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCatchCreatMonster _inst = (CGCatchCreatMonster) _base;
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
public class CGCatchCreatProp : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCatchCreatProp _inst = (CGCatchCreatProp) _base;
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
public class CGCatchGiveUpTask : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCatchGiveUpTask _inst = (CGCatchGiveUpTask) _base;
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
public class CGDeliverTask : PacketDistributed
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

public const int isDoubleFieldNumber = 2;
 private bool hasIsDouble;
 private Int32 isDouble_ = 0;
 public bool HasIsDouble {
 get { return hasIsDouble; }
 }
 public Int32 IsDouble {
 get { return isDouble_; }
 set { SetIsDouble(value); }
 }
 public void SetIsDouble(Int32 value) { 
 hasIsDouble = true;
 isDouble_ = value;
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
 if (HasIsDouble) {
size += pb::CodedOutputStream.ComputeInt32Size(2, IsDouble);
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
 
if (HasIsDouble) {
output.WriteInt32(2, IsDouble);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGDeliverTask _inst = (CGDeliverTask) _base;
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
 _inst.IsDouble = input.ReadInt32();
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
public class CGFinishTask : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGFinishTask _inst = (CGFinishTask) _base;
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
public class CGOpenDialog : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGOpenDialog _inst = (CGOpenDialog) _base;
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
public class CGReciveTask : PacketDistributed
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

public const int taskIDFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TaskID);
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
 
if (HasTaskID) {
output.WriteInt32(2, TaskID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGReciveTask _inst = (CGReciveTask) _base;
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
 _inst.TaskID = input.ReadInt32();
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
public class GCCreatMonsterBack : PacketDistributed
{

public const int successFieldNumber = 1;
 private bool hasSuccess;
 private Int32 success_ = 0;
 public bool HasSuccess {
 get { return hasSuccess; }
 }
 public Int32 Success {
 get { return success_; }
 set { SetSuccess(value); }
 }
 public void SetSuccess(Int32 value) { 
 hasSuccess = true;
 success_ = value;
 }

public const int taskIDFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSuccess) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Success);
}
 if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TaskID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSuccess) {
output.WriteInt32(1, Success);
}
 
if (HasTaskID) {
output.WriteInt32(2, TaskID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreatMonsterBack _inst = (GCCreatMonsterBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Success = input.ReadInt32();
break;
}
   case  16: {
 _inst.TaskID = input.ReadInt32();
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
public class GCMenverOpenDialog : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TaskID);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMenverOpenDialog _inst = (GCMenverOpenDialog) _base;
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
public class GCSendMainTasks : PacketDistributed
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

public const int taskIdsFieldNumber = 2;
 private pbc::PopsicleList<Int32> taskIds_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> taskIdsList {
 get { return pbc::Lists.AsReadOnly(taskIds_); }
 }
 
 public int taskIdsCount {
 get { return taskIds_.Count; }
 }
 
public Int32 GetTaskIds(int index) {
 return taskIds_[index];
 }
 public void AddTaskIds(Int32 value) {
 taskIds_.Add(value);
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
foreach (Int32 element in taskIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * taskIds_.Count;
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
if (taskIds_.Count > 0) {
foreach (Int32 element in taskIdsList) {
output.WriteInt32(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendMainTasks _inst = (GCSendMainTasks) _base;
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
 _inst.AddTaskIds(input.ReadInt32());
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
public class GCSendTaskMonster : PacketDistributed
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

public const int mosnterIDFieldNumber = 2;
 private bool hasMosnterID;
 private Int32 mosnterID_ = 0;
 public bool HasMosnterID {
 get { return hasMosnterID; }
 }
 public Int32 MosnterID {
 get { return mosnterID_; }
 set { SetMosnterID(value); }
 }
 public void SetMosnterID(Int32 value) { 
 hasMosnterID = true;
 mosnterID_ = value;
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
 if (HasMosnterID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MosnterID);
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
 
if (HasMosnterID) {
output.WriteInt32(2, MosnterID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendTaskMonster _inst = (GCSendTaskMonster) _base;
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
 _inst.MosnterID = input.ReadInt32();
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
public class GCSendTaskOver : PacketDistributed
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
 GCSendTaskOver _inst = (GCSendTaskOver) _base;
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
public class GCSendTaskReward : PacketDistributed
{

public const int rewardItemsFieldNumber = 1;
 private pbc::PopsicleList<RewardItem> rewardItems_ = new pbc::PopsicleList<RewardItem>();
 public scg::IList<RewardItem> rewardItemsList {
 get { return pbc::Lists.AsReadOnly(rewardItems_); }
 }
 
 public int rewardItemsCount {
 get { return rewardItems_.Count; }
 }
 
public RewardItem GetRewardItems(int index) {
 return rewardItems_[index];
 }
 public void AddRewardItems(RewardItem value) {
 rewardItems_.Add(value);
 }

public const int attrRewardsFieldNumber = 2;
 private pbc::PopsicleList<RewardItem> attrRewards_ = new pbc::PopsicleList<RewardItem>();
 public scg::IList<RewardItem> attrRewardsList {
 get { return pbc::Lists.AsReadOnly(attrRewards_); }
 }
 
 public int attrRewardsCount {
 get { return attrRewards_.Count; }
 }
 
public RewardItem GetAttrRewards(int index) {
 return attrRewards_[index];
 }
 public void AddAttrRewards(RewardItem value) {
 attrRewards_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RewardItem element in rewardItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (RewardItem element in attrRewardsList) {
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
 
do{
foreach (RewardItem element in rewardItemsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (RewardItem element in attrRewardsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendTaskReward _inst = (GCSendTaskReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RewardItem subBuilder =  new RewardItem();
input.ReadMessage(subBuilder);
_inst.AddRewardItems(subBuilder);
break;
}
    case  18: {
RewardItem subBuilder =  new RewardItem();
input.ReadMessage(subBuilder);
_inst.AddAttrRewards(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RewardItem element in rewardItemsList) {
if (!element.IsInitialized()) return false;
}
foreach (RewardItem element in attrRewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTaskInforBack : PacketDistributed
{

public const int taskInforsFieldNumber = 1;
 private bool hasTaskInfors;
 private TaskInfor taskInfors_ =  new TaskInfor();
 public bool HasTaskInfors {
 get { return hasTaskInfors; }
 }
 public TaskInfor TaskInfors {
 get { return taskInfors_; }
 set { SetTaskInfors(value); }
 }
 public void SetTaskInfors(TaskInfor value) { 
 hasTaskInfors = true;
 taskInfors_ = value;
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

public const int stageInfoFieldNumber = 4;
 private pbc::PopsicleList<TaskInfor> stageInfo_ = new pbc::PopsicleList<TaskInfor>();
 public scg::IList<TaskInfor> stageInfoList {
 get { return pbc::Lists.AsReadOnly(stageInfo_); }
 }
 
 public int stageInfoCount {
 get { return stageInfo_.Count; }
 }
 
public TaskInfor GetStageInfo(int index) {
 return stageInfo_[index];
 }
 public void AddStageInfo(TaskInfor value) {
 stageInfo_.Add(value);
 }

public const int taskStatusFieldNumber = 5;
 private pbc::PopsicleList<TaskStatus> taskStatus_ = new pbc::PopsicleList<TaskStatus>();
 public scg::IList<TaskStatus> taskStatusList {
 get { return pbc::Lists.AsReadOnly(taskStatus_); }
 }
 
 public int taskStatusCount {
 get { return taskStatus_.Count; }
 }
 
public TaskStatus GetTaskStatus(int index) {
 return taskStatus_[index];
 }
 public void AddTaskStatus(TaskStatus value) {
 taskStatus_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = TaskInfors.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasOldTaskID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, OldTaskID);
}
{
foreach (TaskInfor element in stageInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (TaskStatus element in taskStatusList) {
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
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TaskInfors.SerializedSize());
TaskInfors.WriteTo(output);

}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasOldTaskID) {
output.WriteInt32(3, OldTaskID);
}

do{
foreach (TaskInfor element in stageInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (TaskStatus element in taskStatusList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTaskInforBack _inst = (GCTaskInforBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TaskInfor subBuilder =  new TaskInfor();
 input.ReadMessage(subBuilder);
_inst.TaskInfors = subBuilder;
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
    case  34: {
TaskInfor subBuilder =  new TaskInfor();
input.ReadMessage(subBuilder);
_inst.AddStageInfo(subBuilder);
break;
}
    case  42: {
TaskStatus subBuilder =  new TaskStatus();
input.ReadMessage(subBuilder);
_inst.AddTaskStatus(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTaskInfors) {
if (!TaskInfors.IsInitialized()) return false;
}
foreach (TaskInfor element in stageInfoList) {
if (!element.IsInitialized()) return false;
}
foreach (TaskStatus element in taskStatusList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCTaskListBack : PacketDistributed
{

public const int taskInforsFieldNumber = 1;
 private pbc::PopsicleList<TaskInfor> taskInfors_ = new pbc::PopsicleList<TaskInfor>();
 public scg::IList<TaskInfor> taskInforsList {
 get { return pbc::Lists.AsReadOnly(taskInfors_); }
 }
 
 public int taskInforsCount {
 get { return taskInfors_.Count; }
 }
 
public TaskInfor GetTaskInfors(int index) {
 return taskInfors_[index];
 }
 public void AddTaskInfors(TaskInfor value) {
 taskInfors_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (TaskInfor element in taskInforsList) {
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
foreach (TaskInfor element in taskInforsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTaskListBack _inst = (GCTaskListBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TaskInfor subBuilder =  new TaskInfor();
input.ReadMessage(subBuilder);
_inst.AddTaskInfors(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TaskInfor element in taskInforsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TaskInfor : PacketDistributed
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

public const int stageFieldNumber = 4;
 private bool hasStage;
 private Int32 stage_ = 0;
 public bool HasStage {
 get { return hasStage; }
 }
 public Int32 Stage {
 get { return stage_; }
 set { SetStage(value); }
 }
 public void SetStage(Int32 value) { 
 hasStage = true;
 stage_ = value;
 }

public const int totalFieldNumber = 5;
 private bool hasTotal;
 private Int32 total_ = 0;
 public bool HasTotal {
 get { return hasTotal; }
 }
 public Int32 Total {
 get { return total_; }
 set { SetTotal(value); }
 }
 public void SetTotal(Int32 value) { 
 hasTotal = true;
 total_ = value;
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

public const int levelFieldNumber = 7;
 private bool hasLevel;
 private Int32 level_ = 0;
 public bool HasLevel {
 get { return hasLevel; }
 }
 public Int32 Level {
 get { return level_; }
 set { SetLevel(value); }
 }
 public void SetLevel(Int32 value) { 
 hasLevel = true;
 level_ = value;
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
 if (HasStage) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Stage);
}
 if (HasTotal) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Total);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Type);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Level);
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
 
if (HasStage) {
output.WriteInt32(4, Stage);
}
 
if (HasTotal) {
output.WriteInt32(5, Total);
}
 
if (HasType) {
output.WriteInt32(6, Type);
}
 
if (HasLevel) {
output.WriteInt32(7, Level);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TaskInfor _inst = (TaskInfor) _base;
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
 _inst.Stage = input.ReadInt32();
break;
}
   case  40: {
 _inst.Total = input.ReadInt32();
break;
}
   case  48: {
 _inst.Type = input.ReadInt32();
break;
}
   case  56: {
 _inst.Level = input.ReadInt32();
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
public class TaskStatus : PacketDistributed
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

public const int stageFieldNumber = 3;
 private bool hasStage;
 private Int32 stage_ = 0;
 public bool HasStage {
 get { return hasStage; }
 }
 public Int32 Stage {
 get { return stage_; }
 set { SetStage(value); }
 }
 public void SetStage(Int32 value) { 
 hasStage = true;
 stage_ = value;
 }

public const int totalFieldNumber = 4;
 private bool hasTotal;
 private Int32 total_ = 0;
 public bool HasTotal {
 get { return hasTotal; }
 }
 public Int32 Total {
 get { return total_; }
 set { SetTotal(value); }
 }
 public void SetTotal(Int32 value) { 
 hasTotal = true;
 total_ = value;
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
 if (HasStage) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Stage);
}
 if (HasTotal) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Total);
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
 
if (HasStage) {
output.WriteInt32(3, Stage);
}
 
if (HasTotal) {
output.WriteInt32(4, Total);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TaskStatus _inst = (TaskStatus) _base;
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
 _inst.Stage = input.ReadInt32();
break;
}
   case  32: {
 _inst.Total = input.ReadInt32();
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
