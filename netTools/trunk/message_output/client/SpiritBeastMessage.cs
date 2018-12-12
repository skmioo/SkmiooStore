//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGSpiritBeastBreed : PacketDistributed
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

public const int breedTypeFieldNumber = 2;
 private bool hasBreedType;
 private Int32 breedType_ = 0;
 public bool HasBreedType {
 get { return hasBreedType; }
 }
 public Int32 BreedType {
 get { return breedType_; }
 set { SetBreedType(value); }
 }
 public void SetBreedType(Int32 value) { 
 hasBreedType = true;
 breedType_ = value;
 }

public const int pidFieldNumber = 3;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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
 if (HasBreedType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BreedType);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Pid);
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
 
if (HasBreedType) {
output.WriteInt32(2, BreedType);
}
 
if (HasPid) {
output.WriteInt64(3, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastBreed _inst = (CGSpiritBeastBreed) _base;
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
 _inst.BreedType = input.ReadInt32();
break;
}
   case  24: {
 _inst.Pid = input.ReadInt64();
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
public class CGSpiritBeastCatch : PacketDistributed
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

public const int pidFieldNumber = 2;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Pid);
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
 
if (HasPid) {
output.WriteInt64(2, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastCatch _inst = (CGSpiritBeastCatch) _base;
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
 _inst.Pid = input.ReadInt64();
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
public class CGSpiritBeastFree : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastFree _inst = (CGSpiritBeastFree) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
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
public class CGSpiritBeastHatch : PacketDistributed
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
 CGSpiritBeastHatch _inst = (CGSpiritBeastHatch) _base;
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
public class CGSpiritBeastInherit : PacketDistributed
{

public const int targetPidFieldNumber = 1;
 private bool hasTargetPid;
 private Int64 targetPid_ = 0;
 public bool HasTargetPid {
 get { return hasTargetPid; }
 }
 public Int64 TargetPid {
 get { return targetPid_; }
 set { SetTargetPid(value); }
 }
 public void SetTargetPid(Int64 value) { 
 hasTargetPid = true;
 targetPid_ = value;
 }

public const int stuffPidFieldNumber = 2;
 private bool hasStuffPid;
 private Int64 stuffPid_ = 0;
 public bool HasStuffPid {
 get { return hasStuffPid; }
 }
 public Int64 StuffPid {
 get { return stuffPid_; }
 set { SetStuffPid(value); }
 }
 public void SetStuffPid(Int64 value) { 
 hasStuffPid = true;
 stuffPid_ = value;
 }

public const int isSavvyFieldNumber = 3;
 private bool hasIsSavvy;
 private Int32 isSavvy_ = 0;
 public bool HasIsSavvy {
 get { return hasIsSavvy; }
 }
 public Int32 IsSavvy {
 get { return isSavvy_; }
 set { SetIsSavvy(value); }
 }
 public void SetIsSavvy(Int32 value) { 
 hasIsSavvy = true;
 isSavvy_ = value;
 }

public const int isSkillFieldNumber = 4;
 private bool hasIsSkill;
 private Int32 isSkill_ = 0;
 public bool HasIsSkill {
 get { return hasIsSkill; }
 }
 public Int32 IsSkill {
 get { return isSkill_; }
 set { SetIsSkill(value); }
 }
 public void SetIsSkill(Int32 value) { 
 hasIsSkill = true;
 isSkill_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTargetPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TargetPid);
}
 if (HasStuffPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, StuffPid);
}
 if (HasIsSavvy) {
size += pb::CodedOutputStream.ComputeInt32Size(3, IsSavvy);
}
 if (HasIsSkill) {
size += pb::CodedOutputStream.ComputeInt32Size(4, IsSkill);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTargetPid) {
output.WriteInt64(1, TargetPid);
}
 
if (HasStuffPid) {
output.WriteInt64(2, StuffPid);
}
 
if (HasIsSavvy) {
output.WriteInt32(3, IsSavvy);
}
 
if (HasIsSkill) {
output.WriteInt32(4, IsSkill);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastInherit _inst = (CGSpiritBeastInherit) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TargetPid = input.ReadInt64();
break;
}
   case  16: {
 _inst.StuffPid = input.ReadInt64();
break;
}
   case  24: {
 _inst.IsSavvy = input.ReadInt32();
break;
}
   case  32: {
 _inst.IsSkill = input.ReadInt32();
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
public class CGSpiritBeastLevelUp : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int pelletIDFieldNumber = 2;
 private bool hasPelletID;
 private Int32 pelletID_ = 0;
 public bool HasPelletID {
 get { return hasPelletID; }
 }
 public Int32 PelletID {
 get { return pelletID_; }
 set { SetPelletID(value); }
 }
 public void SetPelletID(Int32 value) { 
 hasPelletID = true;
 pelletID_ = value;
 }

public const int pelletNumFieldNumber = 3;
 private bool hasPelletNum;
 private Int32 pelletNum_ = 0;
 public bool HasPelletNum {
 get { return hasPelletNum; }
 }
 public Int32 PelletNum {
 get { return pelletNum_; }
 set { SetPelletNum(value); }
 }
 public void SetPelletNum(Int32 value) { 
 hasPelletNum = true;
 pelletNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasPelletID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PelletID);
}
 if (HasPelletNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PelletNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasPelletID) {
output.WriteInt32(2, PelletID);
}
 
if (HasPelletNum) {
output.WriteInt32(3, PelletNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastLevelUp _inst = (CGSpiritBeastLevelUp) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.PelletID = input.ReadInt32();
break;
}
   case  24: {
 _inst.PelletNum = input.ReadInt32();
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
public class CGSpiritBeastOperate : PacketDistributed
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

public const int pidFieldNumber = 2;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int offPidFieldNumber = 3;
 private bool hasOffPid;
 private Int64 offPid_ = 0;
 public bool HasOffPid {
 get { return hasOffPid; }
 }
 public Int64 OffPid {
 get { return offPid_; }
 set { SetOffPid(value); }
 }
 public void SetOffPid(Int64 value) { 
 hasOffPid = true;
 offPid_ = value;
 }

public const int developTypeFieldNumber = 4;
 private bool hasDevelopType;
 private Int32 developType_ = 0;
 public bool HasDevelopType {
 get { return hasDevelopType; }
 }
 public Int32 DevelopType {
 get { return developType_; }
 set { SetDevelopType(value); }
 }
 public void SetDevelopType(Int32 value) { 
 hasDevelopType = true;
 developType_ = value;
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
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Pid);
}
 if (HasOffPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, OffPid);
}
 if (HasDevelopType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, DevelopType);
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
 
if (HasPid) {
output.WriteInt64(2, Pid);
}
 
if (HasOffPid) {
output.WriteInt64(3, OffPid);
}
 
if (HasDevelopType) {
output.WriteInt32(4, DevelopType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastOperate _inst = (CGSpiritBeastOperate) _base;
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
 _inst.Pid = input.ReadInt64();
break;
}
   case  24: {
 _inst.OffPid = input.ReadInt64();
break;
}
   case  32: {
 _inst.DevelopType = input.ReadInt32();
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
public class CGSpiritBeastOperateSkill : PacketDistributed
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

public const int pidFieldNumber = 2;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int targetIDFieldNumber = 3;
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
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Pid);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TargetID);
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
 
if (HasPid) {
output.WriteInt64(2, Pid);
}
 
if (HasTargetID) {
output.WriteInt32(3, TargetID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastOperateSkill _inst = (CGSpiritBeastOperateSkill) _base;
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
 _inst.Pid = input.ReadInt64();
break;
}
   case  24: {
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
public class CGSpiritBeastUniteOperate : PacketDistributed
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

public const int targetFieldNumber = 2;
 private bool hasTarget;
 private Int32 target_ = 0;
 public bool HasTarget {
 get { return hasTarget; }
 }
 public Int32 Target {
 get { return target_; }
 set { SetTarget(value); }
 }
 public void SetTarget(Int32 value) { 
 hasTarget = true;
 target_ = value;
 }

public const int zhenIDFieldNumber = 3;
 private bool hasZhenID;
 private Int32 zhenID_ = 0;
 public bool HasZhenID {
 get { return hasZhenID; }
 }
 public Int32 ZhenID {
 get { return zhenID_; }
 set { SetZhenID(value); }
 }
 public void SetZhenID(Int32 value) { 
 hasZhenID = true;
 zhenID_ = value;
 }

public const int posIDFieldNumber = 4;
 private bool hasPosID;
 private Int32 posID_ = 0;
 public bool HasPosID {
 get { return hasPosID; }
 }
 public Int32 PosID {
 get { return posID_; }
 set { SetPosID(value); }
 }
 public void SetPosID(Int32 value) { 
 hasPosID = true;
 posID_ = value;
 }

public const int pidFieldNumber = 5;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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
 if (HasTarget) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Target);
}
 if (HasZhenID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ZhenID);
}
 if (HasPosID) {
size += pb::CodedOutputStream.ComputeInt32Size(4, PosID);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(5, Pid);
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
 
if (HasTarget) {
output.WriteInt32(2, Target);
}
 
if (HasZhenID) {
output.WriteInt32(3, ZhenID);
}
 
if (HasPosID) {
output.WriteInt32(4, PosID);
}
 
if (HasPid) {
output.WriteInt64(5, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSpiritBeastUniteOperate _inst = (CGSpiritBeastUniteOperate) _base;
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
 _inst.Target = input.ReadInt32();
break;
}
   case  24: {
 _inst.ZhenID = input.ReadInt32();
break;
}
   case  32: {
 _inst.PosID = input.ReadInt32();
break;
}
   case  40: {
 _inst.Pid = input.ReadInt64();
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
public class GCSpiritBeastBreedResult : PacketDistributed
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

public const int breedTypeFieldNumber = 2;
 private bool hasBreedType;
 private Int32 breedType_ = 0;
 public bool HasBreedType {
 get { return hasBreedType; }
 }
 public Int32 BreedType {
 get { return breedType_; }
 set { SetBreedType(value); }
 }
 public void SetBreedType(Int32 value) { 
 hasBreedType = true;
 breedType_ = value;
 }

public const int objectTypeFieldNumber = 3;
 private bool hasObjectType;
 private Int32 objectType_ = 0;
 public bool HasObjectType {
 get { return hasObjectType; }
 }
 public Int32 ObjectType {
 get { return objectType_; }
 set { SetObjectType(value); }
 }
 public void SetObjectType(Int32 value) { 
 hasObjectType = true;
 objectType_ = value;
 }

public const int sbInfoFieldNumber = 4;
 private pbc::PopsicleList<SpiritBeastInfo> sbInfo_ = new pbc::PopsicleList<SpiritBeastInfo>();
 public scg::IList<SpiritBeastInfo> sbInfoList {
 get { return pbc::Lists.AsReadOnly(sbInfo_); }
 }
 
 public int sbInfoCount {
 get { return sbInfo_.Count; }
 }
 
public SpiritBeastInfo GetSbInfo(int index) {
 return sbInfo_[index];
 }
 public void AddSbInfo(SpiritBeastInfo value) {
 sbInfo_.Add(value);
 }

public const int receiveTimeFieldNumber = 5;
 private bool hasReceiveTime;
 private Int64 receiveTime_ = 0;
 public bool HasReceiveTime {
 get { return hasReceiveTime; }
 }
 public Int64 ReceiveTime {
 get { return receiveTime_; }
 set { SetReceiveTime(value); }
 }
 public void SetReceiveTime(Int64 value) { 
 hasReceiveTime = true;
 receiveTime_ = value;
 }

public const int objectNameFieldNumber = 6;
 private bool hasObjectName;
 private string objectName_ = "";
 public bool HasObjectName {
 get { return hasObjectName; }
 }
 public string ObjectName {
 get { return objectName_; }
 set { SetObjectName(value); }
 }
 public void SetObjectName(string value) { 
 hasObjectName = true;
 objectName_ = value;
 }

public const int luckyFieldNumber = 7;
 private bool hasLucky;
 private Int32 lucky_ = 0;
 public bool HasLucky {
 get { return hasLucky; }
 }
 public Int32 Lucky {
 get { return lucky_; }
 set { SetLucky(value); }
 }
 public void SetLucky(Int32 value) { 
 hasLucky = true;
 lucky_ = value;
 }

public const int breedResultFieldNumber = 8;
 private bool hasBreedResult;
 private string breedResult_ = "";
 public bool HasBreedResult {
 get { return hasBreedResult; }
 }
 public string BreedResult {
 get { return breedResult_; }
 set { SetBreedResult(value); }
 }
 public void SetBreedResult(string value) { 
 hasBreedResult = true;
 breedResult_ = value;
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
 if (HasBreedType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BreedType);
}
 if (HasObjectType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ObjectType);
}
{
foreach (SpiritBeastInfo element in sbInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasReceiveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, ReceiveTime);
}
 if (HasObjectName) {
size += pb::CodedOutputStream.ComputeStringSize(6, ObjectName);
}
 if (HasLucky) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Lucky);
}
 if (HasBreedResult) {
size += pb::CodedOutputStream.ComputeStringSize(8, BreedResult);
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
 
if (HasBreedType) {
output.WriteInt32(2, BreedType);
}
 
if (HasObjectType) {
output.WriteInt32(3, ObjectType);
}

do{
foreach (SpiritBeastInfo element in sbInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasReceiveTime) {
output.WriteInt64(5, ReceiveTime);
}
 
if (HasObjectName) {
output.WriteString(6, ObjectName);
}
 
if (HasLucky) {
output.WriteInt32(7, Lucky);
}
 
if (HasBreedResult) {
output.WriteString(8, BreedResult);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastBreedResult _inst = (GCSpiritBeastBreedResult) _base;
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
 _inst.BreedType = input.ReadInt32();
break;
}
   case  24: {
 _inst.ObjectType = input.ReadInt32();
break;
}
    case  34: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
input.ReadMessage(subBuilder);
_inst.AddSbInfo(subBuilder);
break;
}
   case  40: {
 _inst.ReceiveTime = input.ReadInt64();
break;
}
   case  50: {
 _inst.ObjectName = input.ReadString();
break;
}
   case  56: {
 _inst.Lucky = input.ReadInt32();
break;
}
   case  66: {
 _inst.BreedResult = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SpiritBeastInfo element in sbInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastCatchResult : PacketDistributed
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

public const int pidFieldNumber = 2;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int playerPidFieldNumber = 3;
 private bool hasPlayerPid;
 private Int64 playerPid_ = 0;
 public bool HasPlayerPid {
 get { return hasPlayerPid; }
 }
 public Int64 PlayerPid {
 get { return playerPid_; }
 set { SetPlayerPid(value); }
 }
 public void SetPlayerPid(Int64 value) { 
 hasPlayerPid = true;
 playerPid_ = value;
 }

public const int timeFieldNumber = 4;
 private bool hasTime;
 private Int32 time_ = 0;
 public bool HasTime {
 get { return hasTime; }
 }
 public Int32 Time {
 get { return time_; }
 set { SetTime(value); }
 }
 public void SetTime(Int32 value) { 
 hasTime = true;
 time_ = value;
 }

public const int sbInfoFieldNumber = 5;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
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
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Pid);
}
 if (HasPlayerPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, PlayerPid);
}
 if (HasTime) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Time);
}
{
int subsize = SbInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasPid) {
output.WriteInt64(2, Pid);
}
 
if (HasPlayerPid) {
output.WriteInt64(3, PlayerPid);
}
 
if (HasTime) {
output.WriteInt32(4, Time);
}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastCatchResult _inst = (GCSpiritBeastCatchResult) _base;
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
 _inst.Pid = input.ReadInt64();
break;
}
   case  24: {
 _inst.PlayerPid = input.ReadInt64();
break;
}
   case  32: {
 _inst.Time = input.ReadInt32();
break;
}
    case  42: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastFreeResult : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastFreeResult _inst = (GCSpiritBeastFreeResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
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
public class GCSpiritBeastHatchResult : PacketDistributed
{

public const int sbInfoFieldNumber = 1;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = SbInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastHatchResult _inst = (GCSpiritBeastHatchResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastInheritResult : PacketDistributed
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

public const int stuffPidFieldNumber = 2;
 private bool hasStuffPid;
 private Int64 stuffPid_ = 0;
 public bool HasStuffPid {
 get { return hasStuffPid; }
 }
 public Int64 StuffPid {
 get { return stuffPid_; }
 set { SetStuffPid(value); }
 }
 public void SetStuffPid(Int64 value) { 
 hasStuffPid = true;
 stuffPid_ = value;
 }

public const int sbInfoFieldNumber = 3;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
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
 if (HasStuffPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, StuffPid);
}
{
int subsize = SbInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasStuffPid) {
output.WriteInt64(2, StuffPid);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastInheritResult _inst = (GCSpiritBeastInheritResult) _base;
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
 _inst.StuffPid = input.ReadInt64();
break;
}
    case  26: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastLevelUpResult : PacketDistributed
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

public const int sbInfoFieldNumber = 2;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
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
int subsize = SbInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastLevelUpResult _inst = (GCSpiritBeastLevelUpResult) _base;
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
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastOperateResult : PacketDistributed
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

public const int resultFieldNumber = 2;
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

public const int sbInfoFieldNumber = 3;
 private pbc::PopsicleList<SpiritBeastInfo> sbInfo_ = new pbc::PopsicleList<SpiritBeastInfo>();
 public scg::IList<SpiritBeastInfo> sbInfoList {
 get { return pbc::Lists.AsReadOnly(sbInfo_); }
 }
 
 public int sbInfoCount {
 get { return sbInfo_.Count; }
 }
 
public SpiritBeastInfo GetSbInfo(int index) {
 return sbInfo_[index];
 }
 public void AddSbInfo(SpiritBeastInfo value) {
 sbInfo_.Add(value);
 }

public const int petFightFieldNumber = 4;
 private bool hasPetFight;
 private Int64 petFight_ = 0;
 public bool HasPetFight {
 get { return hasPetFight; }
 }
 public Int64 PetFight {
 get { return petFight_; }
 set { SetPetFight(value); }
 }
 public void SetPetFight(Int64 value) { 
 hasPetFight = true;
 petFight_ = value;
 }

public const int battleArrayFieldNumber = 5;
 private pbc::PopsicleList<Int64> battleArray_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> battleArrayList {
 get { return pbc::Lists.AsReadOnly(battleArray_); }
 }
 
 public int battleArrayCount {
 get { return battleArray_.Count; }
 }
 
public Int64 GetBattleArray(int index) {
 return battleArray_[index];
 }
 public void AddBattleArray(Int64 value) {
 battleArray_.Add(value);
 }

public const int sbUniteFieldNumber = 6;
 private pbc::PopsicleList<SpiritBeastUniteInfo> sbUnite_ = new pbc::PopsicleList<SpiritBeastUniteInfo>();
 public scg::IList<SpiritBeastUniteInfo> sbUniteList {
 get { return pbc::Lists.AsReadOnly(sbUnite_); }
 }
 
 public int sbUniteCount {
 get { return sbUnite_.Count; }
 }
 
public SpiritBeastUniteInfo GetSbUnite(int index) {
 return sbUnite_[index];
 }
 public void AddSbUnite(SpiritBeastUniteInfo value) {
 sbUnite_.Add(value);
 }

public const int receiveTimeFieldNumber = 7;
 private bool hasReceiveTime;
 private Int64 receiveTime_ = 0;
 public bool HasReceiveTime {
 get { return hasReceiveTime; }
 }
 public Int64 ReceiveTime {
 get { return receiveTime_; }
 set { SetReceiveTime(value); }
 }
 public void SetReceiveTime(Int64 value) { 
 hasReceiveTime = true;
 receiveTime_ = value;
 }

public const int remainNumFieldNumber = 8;
 private bool hasRemainNum;
 private Int32 remainNum_ = 0;
 public bool HasRemainNum {
 get { return hasRemainNum; }
 }
 public Int32 RemainNum {
 get { return remainNum_; }
 set { SetRemainNum(value); }
 }
 public void SetRemainNum(Int32 value) { 
 hasRemainNum = true;
 remainNum_ = value;
 }

public const int luckyFieldNumber = 9;
 private bool hasLucky;
 private Int32 lucky_ = 0;
 public bool HasLucky {
 get { return hasLucky; }
 }
 public Int32 Lucky {
 get { return lucky_; }
 set { SetLucky(value); }
 }
 public void SetLucky(Int32 value) { 
 hasLucky = true;
 lucky_ = value;
 }

public const int breedResultFieldNumber = 10;
 private bool hasBreedResult;
 private string breedResult_ = "";
 public bool HasBreedResult {
 get { return hasBreedResult; }
 }
 public string BreedResult {
 get { return breedResult_; }
 set { SetBreedResult(value); }
 }
 public void SetBreedResult(string value) { 
 hasBreedResult = true;
 breedResult_ = value;
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
foreach (SpiritBeastInfo element in sbInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasPetFight) {
size += pb::CodedOutputStream.ComputeInt64Size(4, PetFight);
}
{
int dataSize = 0;
foreach (Int64 element in battleArrayList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * battleArray_.Count;
}
{
foreach (SpiritBeastUniteInfo element in sbUniteList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasReceiveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, ReceiveTime);
}
 if (HasRemainNum) {
size += pb::CodedOutputStream.ComputeInt32Size(8, RemainNum);
}
 if (HasLucky) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Lucky);
}
 if (HasBreedResult) {
size += pb::CodedOutputStream.ComputeStringSize(10, BreedResult);
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
 
if (HasResult) {
output.WriteInt32(2, Result);
}

do{
foreach (SpiritBeastInfo element in sbInfoList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasPetFight) {
output.WriteInt64(4, PetFight);
}
{
if (battleArray_.Count > 0) {
foreach (Int64 element in battleArrayList) {
output.WriteInt64(5,element);
}
}

}

do{
foreach (SpiritBeastUniteInfo element in sbUniteList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasReceiveTime) {
output.WriteInt64(7, ReceiveTime);
}
 
if (HasRemainNum) {
output.WriteInt32(8, RemainNum);
}
 
if (HasLucky) {
output.WriteInt32(9, Lucky);
}
 
if (HasBreedResult) {
output.WriteString(10, BreedResult);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastOperateResult _inst = (GCSpiritBeastOperateResult) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
input.ReadMessage(subBuilder);
_inst.AddSbInfo(subBuilder);
break;
}
   case  32: {
 _inst.PetFight = input.ReadInt64();
break;
}
   case  40: {
 _inst.AddBattleArray(input.ReadInt64());
break;
}
    case  50: {
SpiritBeastUniteInfo subBuilder =  new SpiritBeastUniteInfo();
input.ReadMessage(subBuilder);
_inst.AddSbUnite(subBuilder);
break;
}
   case  56: {
 _inst.ReceiveTime = input.ReadInt64();
break;
}
   case  64: {
 _inst.RemainNum = input.ReadInt32();
break;
}
   case  72: {
 _inst.Lucky = input.ReadInt32();
break;
}
   case  82: {
 _inst.BreedResult = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SpiritBeastInfo element in sbInfoList) {
if (!element.IsInitialized()) return false;
}
foreach (SpiritBeastUniteInfo element in sbUniteList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastOperateSkillResult : PacketDistributed
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

public const int resultFieldNumber = 2;
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

public const int sbInfoFieldNumber = 3;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
int subsize = SbInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasResult) {
output.WriteInt32(2, Result);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastOperateSkillResult _inst = (GCSpiritBeastOperateSkillResult) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSpiritBeastRelive : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int reliveTimeFieldNumber = 2;
 private bool hasReliveTime;
 private Int64 reliveTime_ = 0;
 public bool HasReliveTime {
 get { return hasReliveTime; }
 }
 public Int64 ReliveTime {
 get { return reliveTime_; }
 set { SetReliveTime(value); }
 }
 public void SetReliveTime(Int64 value) { 
 hasReliveTime = true;
 reliveTime_ = value;
 }

public const int fightPidFieldNumber = 3;
 private bool hasFightPid;
 private Int64 fightPid_ = 0;
 public bool HasFightPid {
 get { return hasFightPid; }
 }
 public Int64 FightPid {
 get { return fightPid_; }
 set { SetFightPid(value); }
 }
 public void SetFightPid(Int64 value) { 
 hasFightPid = true;
 fightPid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasReliveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ReliveTime);
}
 if (HasFightPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, FightPid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasReliveTime) {
output.WriteInt64(2, ReliveTime);
}
 
if (HasFightPid) {
output.WriteInt64(3, FightPid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastRelive _inst = (GCSpiritBeastRelive) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.ReliveTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.FightPid = input.ReadInt64();
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
public class GCSpiritBeastUniteOperateResult : PacketDistributed
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

public const int targetFieldNumber = 3;
 private bool hasTarget;
 private Int32 target_ = 0;
 public bool HasTarget {
 get { return hasTarget; }
 }
 public Int32 Target {
 get { return target_; }
 set { SetTarget(value); }
 }
 public void SetTarget(Int32 value) { 
 hasTarget = true;
 target_ = value;
 }

public const int sbUniteFieldNumber = 4;
 private bool hasSbUnite;
 private SpiritBeastUniteInfo sbUnite_ =  new SpiritBeastUniteInfo();
 public bool HasSbUnite {
 get { return hasSbUnite; }
 }
 public SpiritBeastUniteInfo SbUnite {
 get { return sbUnite_; }
 set { SetSbUnite(value); }
 }
 public void SetSbUnite(SpiritBeastUniteInfo value) { 
 hasSbUnite = true;
 sbUnite_ = value;
 }

public const int sbInfoFieldNumber = 5;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
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
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
 if (HasTarget) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Target);
}
{
int subsize = SbUnite.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = SbInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}
 
if (HasTarget) {
output.WriteInt32(3, Target);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SbUnite.SerializedSize());
SbUnite.WriteTo(output);

}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSpiritBeastUniteOperateResult _inst = (GCSpiritBeastUniteOperateResult) _base;
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
 _inst.Operate = input.ReadInt32();
break;
}
   case  24: {
 _inst.Target = input.ReadInt32();
break;
}
    case  34: {
SpiritBeastUniteInfo subBuilder =  new SpiritBeastUniteInfo();
 input.ReadMessage(subBuilder);
_inst.SbUnite = subBuilder;
break;
}
    case  42: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbUnite) {
if (!SbUnite.IsInitialized()) return false;
}
  if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SpiritBeastAttr : PacketDistributed
{

public const int attrkeyFieldNumber = 1;
 private bool hasAttrkey;
 private Int32 attrkey_ = 0;
 public bool HasAttrkey {
 get { return hasAttrkey; }
 }
 public Int32 Attrkey {
 get { return attrkey_; }
 set { SetAttrkey(value); }
 }
 public void SetAttrkey(Int32 value) { 
 hasAttrkey = true;
 attrkey_ = value;
 }

public const int growupvalueFieldNumber = 2;
 private bool hasGrowupvalue;
 private Int32 growupvalue_ = 0;
 public bool HasGrowupvalue {
 get { return hasGrowupvalue; }
 }
 public Int32 Growupvalue {
 get { return growupvalue_; }
 set { SetGrowupvalue(value); }
 }
 public void SetGrowupvalue(Int32 value) { 
 hasGrowupvalue = true;
 growupvalue_ = value;
 }

public const int viewflagFieldNumber = 3;
 private bool hasViewflag;
 private Int32 viewflag_ = 0;
 public bool HasViewflag {
 get { return hasViewflag; }
 }
 public Int32 Viewflag {
 get { return viewflag_; }
 set { SetViewflag(value); }
 }
 public void SetViewflag(Int32 value) { 
 hasViewflag = true;
 viewflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAttrkey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Attrkey);
}
 if (HasGrowupvalue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Growupvalue);
}
 if (HasViewflag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Viewflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAttrkey) {
output.WriteInt32(1, Attrkey);
}
 
if (HasGrowupvalue) {
output.WriteInt32(2, Growupvalue);
}
 
if (HasViewflag) {
output.WriteInt32(3, Viewflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SpiritBeastAttr _inst = (SpiritBeastAttr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Attrkey = input.ReadInt32();
break;
}
   case  16: {
 _inst.Growupvalue = input.ReadInt32();
break;
}
   case  24: {
 _inst.Viewflag = input.ReadInt32();
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
public class SpiritBeastInUnite : PacketDistributed
{

public const int posFieldNumber = 1;
 private bool hasPos;
 private Int32 pos_ = 0;
 public bool HasPos {
 get { return hasPos; }
 }
 public Int32 Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Int32 value) { 
 hasPos = true;
 pos_ = value;
 }

public const int sbInfoFieldNumber = 2;
 private bool hasSbInfo;
 private SpiritBeastInfo sbInfo_ =  new SpiritBeastInfo();
 public bool HasSbInfo {
 get { return hasSbInfo; }
 }
 public SpiritBeastInfo SbInfo {
 get { return sbInfo_; }
 set { SetSbInfo(value); }
 }
 public void SetSbInfo(SpiritBeastInfo value) { 
 hasSbInfo = true;
 sbInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPos) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Pos);
}
{
int subsize = SbInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPos) {
output.WriteInt32(1, Pos);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SbInfo.SerializedSize());
SbInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SpiritBeastInUnite _inst = (SpiritBeastInUnite) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pos = input.ReadInt32();
break;
}
    case  18: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
 input.ReadMessage(subBuilder);
_inst.SbInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSbInfo) {
if (!SbInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SpiritBeastInfo : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int sidFieldNumber = 2;
 private bool hasSid;
 private Int32 sid_ = 0;
 public bool HasSid {
 get { return hasSid; }
 }
 public Int32 Sid {
 get { return sid_; }
 set { SetSid(value); }
 }
 public void SetSid(Int32 value) { 
 hasSid = true;
 sid_ = value;
 }

public const int growthLvFieldNumber = 3;
 private bool hasGrowthLv;
 private Int32 growthLv_ = 0;
 public bool HasGrowthLv {
 get { return hasGrowthLv; }
 }
 public Int32 GrowthLv {
 get { return growthLv_; }
 set { SetGrowthLv(value); }
 }
 public void SetGrowthLv(Int32 value) { 
 hasGrowthLv = true;
 growthLv_ = value;
 }

public const int starLvFieldNumber = 4;
 private bool hasStarLv;
 private Int32 starLv_ = 0;
 public bool HasStarLv {
 get { return hasStarLv; }
 }
 public Int32 StarLv {
 get { return starLv_; }
 set { SetStarLv(value); }
 }
 public void SetStarLv(Int32 value) { 
 hasStarLv = true;
 starLv_ = value;
 }

public const int levelFieldNumber = 5;
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

public const int generationsFieldNumber = 6;
 private bool hasGenerations;
 private Int32 generations_ = 0;
 public bool HasGenerations {
 get { return hasGenerations; }
 }
 public Int32 Generations {
 get { return generations_; }
 set { SetGenerations(value); }
 }
 public void SetGenerations(Int32 value) { 
 hasGenerations = true;
 generations_ = value;
 }

public const int nowexpFieldNumber = 7;
 private bool hasNowexp;
 private Int64 nowexp_ = 0;
 public bool HasNowexp {
 get { return hasNowexp; }
 }
 public Int64 Nowexp {
 get { return nowexp_; }
 set { SetNowexp(value); }
 }
 public void SetNowexp(Int64 value) { 
 hasNowexp = true;
 nowexp_ = value;
 }

public const int savvyLvFieldNumber = 8;
 private bool hasSavvyLv;
 private Int32 savvyLv_ = 0;
 public bool HasSavvyLv {
 get { return hasSavvyLv; }
 }
 public Int32 SavvyLv {
 get { return savvyLv_; }
 set { SetSavvyLv(value); }
 }
 public void SetSavvyLv(Int32 value) { 
 hasSavvyLv = true;
 savvyLv_ = value;
 }

public const int attlistFieldNumber = 9;
 private pbc::PopsicleList<SpiritBeastAttr> attlist_ = new pbc::PopsicleList<SpiritBeastAttr>();
 public scg::IList<SpiritBeastAttr> attlistList {
 get { return pbc::Lists.AsReadOnly(attlist_); }
 }
 
 public int attlistCount {
 get { return attlist_.Count; }
 }
 
public SpiritBeastAttr GetAttlist(int index) {
 return attlist_[index];
 }
 public void AddAttlist(SpiritBeastAttr value) {
 attlist_.Add(value);
 }

public const int skilllistFieldNumber = 10;
 private pbc::PopsicleList<SpiritBeastSkillInfo> skilllist_ = new pbc::PopsicleList<SpiritBeastSkillInfo>();
 public scg::IList<SpiritBeastSkillInfo> skilllistList {
 get { return pbc::Lists.AsReadOnly(skilllist_); }
 }
 
 public int skilllistCount {
 get { return skilllist_.Count; }
 }
 
public SpiritBeastSkillInfo GetSkilllist(int index) {
 return skilllist_[index];
 }
 public void AddSkilllist(SpiritBeastSkillInfo value) {
 skilllist_.Add(value);
 }

public const int reliveTimeFieldNumber = 11;
 private bool hasReliveTime;
 private Int64 reliveTime_ = 0;
 public bool HasReliveTime {
 get { return hasReliveTime; }
 }
 public Int64 ReliveTime {
 get { return reliveTime_; }
 set { SetReliveTime(value); }
 }
 public void SetReliveTime(Int64 value) { 
 hasReliveTime = true;
 reliveTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
 if (HasGrowthLv) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GrowthLv);
}
 if (HasStarLv) {
size += pb::CodedOutputStream.ComputeInt32Size(4, StarLv);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Level);
}
 if (HasGenerations) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Generations);
}
 if (HasNowexp) {
size += pb::CodedOutputStream.ComputeInt64Size(7, Nowexp);
}
 if (HasSavvyLv) {
size += pb::CodedOutputStream.ComputeInt32Size(8, SavvyLv);
}
{
foreach (SpiritBeastAttr element in attlistList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (SpiritBeastSkillInfo element in skilllistList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)10) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasReliveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(11, ReliveTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
 
if (HasGrowthLv) {
output.WriteInt32(3, GrowthLv);
}
 
if (HasStarLv) {
output.WriteInt32(4, StarLv);
}
 
if (HasLevel) {
output.WriteInt32(5, Level);
}
 
if (HasGenerations) {
output.WriteInt32(6, Generations);
}
 
if (HasNowexp) {
output.WriteInt64(7, Nowexp);
}
 
if (HasSavvyLv) {
output.WriteInt32(8, SavvyLv);
}

do{
foreach (SpiritBeastAttr element in attlistList) {
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (SpiritBeastSkillInfo element in skilllistList) {
output.WriteTag((int)10, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasReliveTime) {
output.WriteInt64(11, ReliveTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SpiritBeastInfo _inst = (SpiritBeastInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  24: {
 _inst.GrowthLv = input.ReadInt32();
break;
}
   case  32: {
 _inst.StarLv = input.ReadInt32();
break;
}
   case  40: {
 _inst.Level = input.ReadInt32();
break;
}
   case  48: {
 _inst.Generations = input.ReadInt32();
break;
}
   case  56: {
 _inst.Nowexp = input.ReadInt64();
break;
}
   case  64: {
 _inst.SavvyLv = input.ReadInt32();
break;
}
    case  74: {
SpiritBeastAttr subBuilder =  new SpiritBeastAttr();
input.ReadMessage(subBuilder);
_inst.AddAttlist(subBuilder);
break;
}
    case  82: {
SpiritBeastSkillInfo subBuilder =  new SpiritBeastSkillInfo();
input.ReadMessage(subBuilder);
_inst.AddSkilllist(subBuilder);
break;
}
   case  88: {
 _inst.ReliveTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SpiritBeastAttr element in attlistList) {
if (!element.IsInitialized()) return false;
}
foreach (SpiritBeastSkillInfo element in skilllistList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SpiritBeastShouLingInfo : PacketDistributed
{

public const int posFieldNumber = 1;
 private bool hasPos;
 private Int32 pos_ = 0;
 public bool HasPos {
 get { return hasPos; }
 }
 public Int32 Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Int32 value) { 
 hasPos = true;
 pos_ = value;
 }

public const int sidFieldNumber = 2;
 private bool hasSid;
 private Int32 sid_ = 0;
 public bool HasSid {
 get { return hasSid; }
 }
 public Int32 Sid {
 get { return sid_; }
 set { SetSid(value); }
 }
 public void SetSid(Int32 value) { 
 hasSid = true;
 sid_ = value;
 }

public const int levelFieldNumber = 3;
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
  if (HasPos) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Pos);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPos) {
output.WriteInt32(1, Pos);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
 
if (HasLevel) {
output.WriteInt32(3, Level);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SpiritBeastShouLingInfo _inst = (SpiritBeastShouLingInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pos = input.ReadInt32();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  24: {
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
public class SpiritBeastSkillInfo : PacketDistributed
{

public const int skillIDFieldNumber = 1;
 private bool hasSkillID;
 private Int32 skillID_ = 0;
 public bool HasSkillID {
 get { return hasSkillID; }
 }
 public Int32 SkillID {
 get { return skillID_; }
 set { SetSkillID(value); }
 }
 public void SetSkillID(Int32 value) { 
 hasSkillID = true;
 skillID_ = value;
 }

public const int skillLevelFieldNumber = 2;
 private bool hasSkillLevel;
 private Int32 skillLevel_ = 0;
 public bool HasSkillLevel {
 get { return hasSkillLevel; }
 }
 public Int32 SkillLevel {
 get { return skillLevel_; }
 set { SetSkillLevel(value); }
 }
 public void SetSkillLevel(Int32 value) { 
 hasSkillLevel = true;
 skillLevel_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSkillID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SkillID);
}
 if (HasSkillLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SkillLevel);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSkillID) {
output.WriteInt32(1, SkillID);
}
 
if (HasSkillLevel) {
output.WriteInt32(2, SkillLevel);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SpiritBeastSkillInfo _inst = (SpiritBeastSkillInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SkillID = input.ReadInt32();
break;
}
   case  16: {
 _inst.SkillLevel = input.ReadInt32();
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
public class SpiritBeastUniteInfo : PacketDistributed
{

public const int zhenIDFieldNumber = 1;
 private bool hasZhenID;
 private Int32 zhenID_ = 0;
 public bool HasZhenID {
 get { return hasZhenID; }
 }
 public Int32 ZhenID {
 get { return zhenID_; }
 set { SetZhenID(value); }
 }
 public void SetZhenID(Int32 value) { 
 hasZhenID = true;
 zhenID_ = value;
 }

public const int sbInUniteFieldNumber = 2;
 private pbc::PopsicleList<SpiritBeastInUnite> sbInUnite_ = new pbc::PopsicleList<SpiritBeastInUnite>();
 public scg::IList<SpiritBeastInUnite> sbInUniteList {
 get { return pbc::Lists.AsReadOnly(sbInUnite_); }
 }
 
 public int sbInUniteCount {
 get { return sbInUnite_.Count; }
 }
 
public SpiritBeastInUnite GetSbInUnite(int index) {
 return sbInUnite_[index];
 }
 public void AddSbInUnite(SpiritBeastInUnite value) {
 sbInUnite_.Add(value);
 }

public const int sbShoulingFieldNumber = 3;
 private pbc::PopsicleList<SpiritBeastShouLingInfo> sbShouling_ = new pbc::PopsicleList<SpiritBeastShouLingInfo>();
 public scg::IList<SpiritBeastShouLingInfo> sbShoulingList {
 get { return pbc::Lists.AsReadOnly(sbShouling_); }
 }
 
 public int sbShoulingCount {
 get { return sbShouling_.Count; }
 }
 
public SpiritBeastShouLingInfo GetSbShouling(int index) {
 return sbShouling_[index];
 }
 public void AddSbShouling(SpiritBeastShouLingInfo value) {
 sbShouling_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasZhenID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ZhenID);
}
{
foreach (SpiritBeastInUnite element in sbInUniteList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (SpiritBeastShouLingInfo element in sbShoulingList) {
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
  
if (HasZhenID) {
output.WriteInt32(1, ZhenID);
}

do{
foreach (SpiritBeastInUnite element in sbInUniteList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (SpiritBeastShouLingInfo element in sbShoulingList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SpiritBeastUniteInfo _inst = (SpiritBeastUniteInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ZhenID = input.ReadInt32();
break;
}
    case  18: {
SpiritBeastInUnite subBuilder =  new SpiritBeastInUnite();
input.ReadMessage(subBuilder);
_inst.AddSbInUnite(subBuilder);
break;
}
    case  26: {
SpiritBeastShouLingInfo subBuilder =  new SpiritBeastShouLingInfo();
input.ReadMessage(subBuilder);
_inst.AddSbShouling(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SpiritBeastInUnite element in sbInUniteList) {
if (!element.IsInitialized()) return false;
}
foreach (SpiritBeastShouLingInfo element in sbShoulingList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
