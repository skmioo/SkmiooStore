//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBackLastScene : PacketDistributed
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
 CGBackLastScene _inst = (CGBackLastScene) _base;
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
public class CGGalaxyHomeOperate : PacketDistributed
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

public const int homeIDFieldNumber = 2;
 private bool hasHomeID;
 private Int32 homeID_ = 0;
 public bool HasHomeID {
 get { return hasHomeID; }
 }
 public Int32 HomeID {
 get { return homeID_; }
 set { SetHomeID(value); }
 }
 public void SetHomeID(Int32 value) { 
 hasHomeID = true;
 homeID_ = value;
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
 if (HasHomeID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, HomeID);
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
 
if (HasHomeID) {
output.WriteInt32(2, HomeID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGalaxyHomeOperate _inst = (CGGalaxyHomeOperate) _base;
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
 _inst.HomeID = input.ReadInt32();
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
public class CGGetTeamLeaderSceneID : PacketDistributed
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
 CGGetTeamLeaderSceneID _inst = (CGGetTeamLeaderSceneID) _base;
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
public class CGSingleGalaxyOperate : PacketDistributed
{

public const int dungeonIDFieldNumber = 1;
 private bool hasDungeonID;
 private Int32 dungeonID_ = 0;
 public bool HasDungeonID {
 get { return hasDungeonID; }
 }
 public Int32 DungeonID {
 get { return dungeonID_; }
 set { SetDungeonID(value); }
 }
 public void SetDungeonID(Int32 value) { 
 hasDungeonID = true;
 dungeonID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDungeonID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, DungeonID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDungeonID) {
output.WriteInt32(1, DungeonID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSingleGalaxyOperate _inst = (CGSingleGalaxyOperate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.DungeonID = input.ReadInt32();
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
public class CGWorldGalaxyOperate : PacketDistributed
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

public const int worldIDFieldNumber = 2;
 private bool hasWorldID;
 private Int32 worldID_ = 0;
 public bool HasWorldID {
 get { return hasWorldID; }
 }
 public Int32 WorldID {
 get { return worldID_; }
 set { SetWorldID(value); }
 }
 public void SetWorldID(Int32 value) { 
 hasWorldID = true;
 worldID_ = value;
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
 if (HasWorldID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, WorldID);
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
 
if (HasWorldID) {
output.WriteInt32(2, WorldID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGWorldGalaxyOperate _inst = (CGWorldGalaxyOperate) _base;
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
 _inst.WorldID = input.ReadInt32();
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
public class GCGalaxyHomeOperate : PacketDistributed
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

public const int homeIDFieldNumber = 2;
 private bool hasHomeID;
 private Int32 homeID_ = 0;
 public bool HasHomeID {
 get { return hasHomeID; }
 }
 public Int32 HomeID {
 get { return homeID_; }
 set { SetHomeID(value); }
 }
 public void SetHomeID(Int32 value) { 
 hasHomeID = true;
 homeID_ = value;
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
 if (HasHomeID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, HomeID);
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
 
if (HasHomeID) {
output.WriteInt32(2, HomeID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGalaxyHomeOperate _inst = (GCGalaxyHomeOperate) _base;
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
 _inst.HomeID = input.ReadInt32();
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
public class GCGalaxyInviteGoHome : PacketDistributed
{

public const int homeIDFieldNumber = 1;
 private bool hasHomeID;
 private Int32 homeID_ = 0;
 public bool HasHomeID {
 get { return hasHomeID; }
 }
 public Int32 HomeID {
 get { return homeID_; }
 set { SetHomeID(value); }
 }
 public void SetHomeID(Int32 value) { 
 hasHomeID = true;
 homeID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHomeID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, HomeID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHomeID) {
output.WriteInt32(1, HomeID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGalaxyInviteGoHome _inst = (GCGalaxyInviteGoHome) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.HomeID = input.ReadInt32();
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
public class GCGalaxyOperateResult : PacketDistributed
{

public const int tiredFieldNumber = 1;
 private bool hasTired;
 private Int32 tired_ = 0;
 public bool HasTired {
 get { return hasTired; }
 }
 public Int32 Tired {
 get { return tired_; }
 set { SetTired(value); }
 }
 public void SetTired(Int32 value) { 
 hasTired = true;
 tired_ = value;
 }

public const int worldIDFieldNumber = 2;
 private bool hasWorldID;
 private Int32 worldID_ = 0;
 public bool HasWorldID {
 get { return hasWorldID; }
 }
 public Int32 WorldID {
 get { return worldID_; }
 set { SetWorldID(value); }
 }
 public void SetWorldID(Int32 value) { 
 hasWorldID = true;
 worldID_ = value;
 }

public const int homeIDFieldNumber = 3;
 private bool hasHomeID;
 private Int32 homeID_ = 0;
 public bool HasHomeID {
 get { return hasHomeID; }
 }
 public Int32 HomeID {
 get { return homeID_; }
 set { SetHomeID(value); }
 }
 public void SetHomeID(Int32 value) { 
 hasHomeID = true;
 homeID_ = value;
 }

public const int remainCntFieldNumber = 4;
 private bool hasRemainCnt;
 private Int32 remainCnt_ = 0;
 public bool HasRemainCnt {
 get { return hasRemainCnt; }
 }
 public Int32 RemainCnt {
 get { return remainCnt_; }
 set { SetRemainCnt(value); }
 }
 public void SetRemainCnt(Int32 value) { 
 hasRemainCnt = true;
 remainCnt_ = value;
 }

public const int bossFieldNumber = 5;
 private pbc::PopsicleList<bossInfo> boss_ = new pbc::PopsicleList<bossInfo>();
 public scg::IList<bossInfo> bossList {
 get { return pbc::Lists.AsReadOnly(boss_); }
 }
 
 public int bossCount {
 get { return boss_.Count; }
 }
 
public bossInfo GetBoss(int index) {
 return boss_[index];
 }
 public void AddBoss(bossInfo value) {
 boss_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTired) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Tired);
}
 if (HasWorldID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, WorldID);
}
 if (HasHomeID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, HomeID);
}
 if (HasRemainCnt) {
size += pb::CodedOutputStream.ComputeInt32Size(4, RemainCnt);
}
{
foreach (bossInfo element in bossList) {
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
  
if (HasTired) {
output.WriteInt32(1, Tired);
}
 
if (HasWorldID) {
output.WriteInt32(2, WorldID);
}
 
if (HasHomeID) {
output.WriteInt32(3, HomeID);
}
 
if (HasRemainCnt) {
output.WriteInt32(4, RemainCnt);
}

do{
foreach (bossInfo element in bossList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGalaxyOperateResult _inst = (GCGalaxyOperateResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Tired = input.ReadInt32();
break;
}
   case  16: {
 _inst.WorldID = input.ReadInt32();
break;
}
   case  24: {
 _inst.HomeID = input.ReadInt32();
break;
}
   case  32: {
 _inst.RemainCnt = input.ReadInt32();
break;
}
    case  42: {
bossInfo subBuilder =  new bossInfo();
input.ReadMessage(subBuilder);
_inst.AddBoss(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (bossInfo element in bossList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetTeamLeaderSceneID : PacketDistributed
{

public const int sceneIDFieldNumber = 1;
 private bool hasSceneID;
 private Int32 sceneID_ = 0;
 public bool HasSceneID {
 get { return hasSceneID; }
 }
 public Int32 SceneID {
 get { return sceneID_; }
 set { SetSceneID(value); }
 }
 public void SetSceneID(Int32 value) { 
 hasSceneID = true;
 sceneID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSceneID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SceneID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSceneID) {
output.WriteInt32(1, SceneID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetTeamLeaderSceneID _inst = (GCGetTeamLeaderSceneID) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SceneID = input.ReadInt32();
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
public class GCSingleGalaxyOperate : PacketDistributed
{

public const int dungeonIDFieldNumber = 1;
 private bool hasDungeonID;
 private Int32 dungeonID_ = 0;
 public bool HasDungeonID {
 get { return hasDungeonID; }
 }
 public Int32 DungeonID {
 get { return dungeonID_; }
 set { SetDungeonID(value); }
 }
 public void SetDungeonID(Int32 value) { 
 hasDungeonID = true;
 dungeonID_ = value;
 }

public const int remainCntFieldNumber = 2;
 private bool hasRemainCnt;
 private Int32 remainCnt_ = 0;
 public bool HasRemainCnt {
 get { return hasRemainCnt; }
 }
 public Int32 RemainCnt {
 get { return remainCnt_; }
 set { SetRemainCnt(value); }
 }
 public void SetRemainCnt(Int32 value) { 
 hasRemainCnt = true;
 remainCnt_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDungeonID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, DungeonID);
}
 if (HasRemainCnt) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RemainCnt);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDungeonID) {
output.WriteInt32(1, DungeonID);
}
 
if (HasRemainCnt) {
output.WriteInt32(2, RemainCnt);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSingleGalaxyOperate _inst = (GCSingleGalaxyOperate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.DungeonID = input.ReadInt32();
break;
}
   case  16: {
 _inst.RemainCnt = input.ReadInt32();
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
public class GCWorldGalaxyOperate : PacketDistributed
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

public const int worldIDFieldNumber = 2;
 private bool hasWorldID;
 private Int32 worldID_ = 0;
 public bool HasWorldID {
 get { return hasWorldID; }
 }
 public Int32 WorldID {
 get { return worldID_; }
 set { SetWorldID(value); }
 }
 public void SetWorldID(Int32 value) { 
 hasWorldID = true;
 worldID_ = value;
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
 if (HasWorldID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, WorldID);
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
 
if (HasWorldID) {
output.WriteInt32(2, WorldID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCWorldGalaxyOperate _inst = (GCWorldGalaxyOperate) _base;
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
 _inst.WorldID = input.ReadInt32();
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
public class bossInfo : PacketDistributed
{

public const int bossIDFieldNumber = 1;
 private bool hasBossID;
 private Int32 bossID_ = 0;
 public bool HasBossID {
 get { return hasBossID; }
 }
 public Int32 BossID {
 get { return bossID_; }
 set { SetBossID(value); }
 }
 public void SetBossID(Int32 value) { 
 hasBossID = true;
 bossID_ = value;
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

public const int killInfoFieldNumber = 3;
 private pbc::PopsicleList<killBossInfo> killInfo_ = new pbc::PopsicleList<killBossInfo>();
 public scg::IList<killBossInfo> killInfoList {
 get { return pbc::Lists.AsReadOnly(killInfo_); }
 }
 
 public int killInfoCount {
 get { return killInfo_.Count; }
 }
 
public killBossInfo GetKillInfo(int index) {
 return killInfo_[index];
 }
 public void AddKillInfo(killBossInfo value) {
 killInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBossID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, BossID);
}
 if (HasReliveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ReliveTime);
}
{
foreach (killBossInfo element in killInfoList) {
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
  
if (HasBossID) {
output.WriteInt32(1, BossID);
}
 
if (HasReliveTime) {
output.WriteInt64(2, ReliveTime);
}

do{
foreach (killBossInfo element in killInfoList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 bossInfo _inst = (bossInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.BossID = input.ReadInt32();
break;
}
   case  16: {
 _inst.ReliveTime = input.ReadInt64();
break;
}
    case  26: {
killBossInfo subBuilder =  new killBossInfo();
input.ReadMessage(subBuilder);
_inst.AddKillInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (killBossInfo element in killInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class killBossInfo : PacketDistributed
{

public const int nameFieldNumber = 1;
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

public const int timeFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(1, Name);
}
 if (HasTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Time);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasName) {
output.WriteString(1, Name);
}
 
if (HasTime) {
output.WriteInt64(2, Time);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 killBossInfo _inst = (killBossInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Name = input.ReadString();
break;
}
   case  16: {
 _inst.Time = input.ReadInt64();
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
