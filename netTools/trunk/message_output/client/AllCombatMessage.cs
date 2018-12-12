//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class ACombatTrans : PacketDistributed
{

public const int transTypeFieldNumber = 1;
 private bool hasTransType;
 private Int32 transType_ = 0;
 public bool HasTransType {
 get { return hasTransType; }
 }
 public Int32 TransType {
 get { return transType_; }
 set { SetTransType(value); }
 }
 public void SetTransType(Int32 value) { 
 hasTransType = true;
 transType_ = value;
 }

public const int innerPacketsFieldNumber = 2;
 private pbc::PopsicleList<MessageList> innerPackets_ = new pbc::PopsicleList<MessageList>();
 public scg::IList<MessageList> innerPacketsList {
 get { return pbc::Lists.AsReadOnly(innerPackets_); }
 }
 
 public int innerPacketsCount {
 get { return innerPackets_.Count; }
 }
 
public MessageList GetInnerPackets(int index) {
 return innerPackets_[index];
 }
 public void AddInnerPackets(MessageList value) {
 innerPackets_.Add(value);
 }

public const int startTFieldNumber = 3;
 private bool hasStartT;
 private Int64 startT_ = 0;
 public bool HasStartT {
 get { return hasStartT; }
 }
 public Int64 StartT {
 get { return startT_; }
 set { SetStartT(value); }
 }
 public void SetStartT(Int64 value) { 
 hasStartT = true;
 startT_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTransType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TransType);
}
{
foreach (MessageList element in innerPacketsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasStartT) {
size += pb::CodedOutputStream.ComputeInt64Size(3, StartT);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTransType) {
output.WriteInt32(1, TransType);
}

do{
foreach (MessageList element in innerPacketsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasStartT) {
output.WriteInt64(3, StartT);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ACombatTrans _inst = (ACombatTrans) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TransType = input.ReadInt32();
break;
}
    case  18: {
MessageList subBuilder =  new MessageList();
input.ReadMessage(subBuilder);
_inst.AddInnerPackets(subBuilder);
break;
}
   case  24: {
 _inst.StartT = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (MessageList element in innerPacketsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class ACombatTransBack : PacketDistributed
{

public const int transTypeFieldNumber = 1;
 private bool hasTransType;
 private Int32 transType_ = 0;
 public bool HasTransType {
 get { return hasTransType; }
 }
 public Int32 TransType {
 get { return transType_; }
 set { SetTransType(value); }
 }
 public void SetTransType(Int32 value) { 
 hasTransType = true;
 transType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTransType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TransType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTransType) {
output.WriteInt32(1, TransType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ACombatTransBack _inst = (ACombatTransBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TransType = input.ReadInt32();
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
public class AllCombatRegist : PacketDistributed
{

public const int serverIdFieldNumber = 1;
 private bool hasServerId;
 private Int32 serverId_ = 0;
 public bool HasServerId {
 get { return hasServerId; }
 }
 public Int32 ServerId {
 get { return serverId_; }
 set { SetServerId(value); }
 }
 public void SetServerId(Int32 value) { 
 hasServerId = true;
 serverId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ServerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasServerId) {
output.WriteInt32(1, ServerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 AllCombatRegist _inst = (AllCombatRegist) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ServerId = input.ReadInt32();
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
public class AllCombatRegistBack : PacketDistributed
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
 AllCombatRegistBack _inst = (AllCombatRegistBack) _base;
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
public class AllRankRwd2 : PacketDistributed
{

public const int stageFieldNumber = 1;
 private bool hasStage;
 private string stage_ = "";
 public bool HasStage {
 get { return hasStage; }
 }
 public string Stage {
 get { return stage_; }
 set { SetStage(value); }
 }
 public void SetStage(string value) { 
 hasStage = true;
 stage_ = value;
 }

public const int itemrwdFieldNumber = 2;
 private bool hasItemrwd;
 private string itemrwd_ = "";
 public bool HasItemrwd {
 get { return hasItemrwd; }
 }
 public string Itemrwd {
 get { return itemrwd_; }
 set { SetItemrwd(value); }
 }
 public void SetItemrwd(string value) { 
 hasItemrwd = true;
 itemrwd_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasStage) {
size += pb::CodedOutputStream.ComputeStringSize(1, Stage);
}
 if (HasItemrwd) {
size += pb::CodedOutputStream.ComputeStringSize(2, Itemrwd);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasStage) {
output.WriteString(1, Stage);
}
 
if (HasItemrwd) {
output.WriteString(2, Itemrwd);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 AllRankRwd2 _inst = (AllRankRwd2) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Stage = input.ReadString();
break;
}
   case  18: {
 _inst.Itemrwd = input.ReadString();
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
public class AllcombatRankData : PacketDistributed
{

public const int gIdFieldNumber = 1;
 private bool hasGId;
 private Int64 gId_ = 0;
 public bool HasGId {
 get { return hasGId; }
 }
 public Int64 GId {
 get { return gId_; }
 set { SetGId(value); }
 }
 public void SetGId(Int64 value) { 
 hasGId = true;
 gId_ = value;
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

public const int serverIdFieldNumber = 3;
 private bool hasServerId;
 private Int32 serverId_ = 0;
 public bool HasServerId {
 get { return hasServerId; }
 }
 public Int32 ServerId {
 get { return serverId_; }
 set { SetServerId(value); }
 }
 public void SetServerId(Int32 value) { 
 hasServerId = true;
 serverId_ = value;
 }

public const int serverNameFieldNumber = 4;
 private bool hasServerName;
 private string serverName_ = "";
 public bool HasServerName {
 get { return hasServerName; }
 }
 public string ServerName {
 get { return serverName_; }
 set { SetServerName(value); }
 }
 public void SetServerName(string value) { 
 hasServerName = true;
 serverName_ = value;
 }

public const int playerLvFieldNumber = 5;
 private bool hasPlayerLv;
 private Int32 playerLv_ = 0;
 public bool HasPlayerLv {
 get { return hasPlayerLv; }
 }
 public Int32 PlayerLv {
 get { return playerLv_; }
 set { SetPlayerLv(value); }
 }
 public void SetPlayerLv(Int32 value) { 
 hasPlayerLv = true;
 playerLv_ = value;
 }

public const int battleNumberFieldNumber = 6;
 private bool hasBattleNumber;
 private Int32 battleNumber_ = 0;
 public bool HasBattleNumber {
 get { return hasBattleNumber; }
 }
 public Int32 BattleNumber {
 get { return battleNumber_; }
 set { SetBattleNumber(value); }
 }
 public void SetBattleNumber(Int32 value) { 
 hasBattleNumber = true;
 battleNumber_ = value;
 }

public const int sorceFieldNumber = 7;
 private bool hasSorce;
 private Int32 sorce_ = 0;
 public bool HasSorce {
 get { return hasSorce; }
 }
 public Int32 Sorce {
 get { return sorce_; }
 set { SetSorce(value); }
 }
 public void SetSorce(Int32 value) { 
 hasSorce = true;
 sorce_ = value;
 }

public const int rankFieldNumber = 8;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, GId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ServerId);
}
 if (HasServerName) {
size += pb::CodedOutputStream.ComputeStringSize(4, ServerName);
}
 if (HasPlayerLv) {
size += pb::CodedOutputStream.ComputeInt32Size(5, PlayerLv);
}
 if (HasBattleNumber) {
size += pb::CodedOutputStream.ComputeInt32Size(6, BattleNumber);
}
 if (HasSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Sorce);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Rank);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGId) {
output.WriteInt64(1, GId);
}
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasServerId) {
output.WriteInt32(3, ServerId);
}
 
if (HasServerName) {
output.WriteString(4, ServerName);
}
 
if (HasPlayerLv) {
output.WriteInt32(5, PlayerLv);
}
 
if (HasBattleNumber) {
output.WriteInt32(6, BattleNumber);
}
 
if (HasSorce) {
output.WriteInt32(7, Sorce);
}
 
if (HasRank) {
output.WriteInt32(8, Rank);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 AllcombatRankData _inst = (AllcombatRankData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GId = input.ReadInt64();
break;
}
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.ServerId = input.ReadInt32();
break;
}
   case  34: {
 _inst.ServerName = input.ReadString();
break;
}
   case  40: {
 _inst.PlayerLv = input.ReadInt32();
break;
}
   case  48: {
 _inst.BattleNumber = input.ReadInt32();
break;
}
   case  56: {
 _inst.Sorce = input.ReadInt32();
break;
}
   case  64: {
 _inst.Rank = input.ReadInt32();
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
public class CGEnterAllCombat : PacketDistributed
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
 CGEnterAllCombat _inst = (CGEnterAllCombat) _base;
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
public class CGExitAllCombat : PacketDistributed
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
 CGExitAllCombat _inst = (CGExitAllCombat) _base;
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
public class CGGetAllCombatRanks : PacketDistributed
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
 CGGetAllCombatRanks _inst = (CGGetAllCombatRanks) _base;
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
public class CGGetAllCombatView : PacketDistributed
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
 CGGetAllCombatView _inst = (CGGetAllCombatView) _base;
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
public class CGGetAllRankDatas : PacketDistributed
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
 CGGetAllRankDatas _inst = (CGGetAllRankDatas) _base;
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
public class CGGetherBloodItem : PacketDistributed
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
 CGGetherBloodItem _inst = (CGGetherBloodItem) _base;
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
public class GCAllCombatEnd : PacketDistributed
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
 GCAllCombatEnd _inst = (GCAllCombatEnd) _base;
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
public class GCAllCombatReport : PacketDistributed
{

public const int gIdFieldNumber = 1;
 private bool hasGId;
 private Int64 gId_ = 0;
 public bool HasGId {
 get { return hasGId; }
 }
 public Int64 GId {
 get { return gId_; }
 set { SetGId(value); }
 }
 public void SetGId(Int64 value) { 
 hasGId = true;
 gId_ = value;
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

public const int serverIdFieldNumber = 3;
 private bool hasServerId;
 private Int32 serverId_ = 0;
 public bool HasServerId {
 get { return hasServerId; }
 }
 public Int32 ServerId {
 get { return serverId_; }
 set { SetServerId(value); }
 }
 public void SetServerId(Int32 value) { 
 hasServerId = true;
 serverId_ = value;
 }

public const int killPersonNumFieldNumber = 4;
 private bool hasKillPersonNum;
 private Int32 killPersonNum_ = 0;
 public bool HasKillPersonNum {
 get { return hasKillPersonNum; }
 }
 public Int32 KillPersonNum {
 get { return killPersonNum_; }
 set { SetKillPersonNum(value); }
 }
 public void SetKillPersonNum(Int32 value) { 
 hasKillPersonNum = true;
 killPersonNum_ = value;
 }

public const int killedNumFieldNumber = 5;
 private bool hasKilledNum;
 private Int32 killedNum_ = 0;
 public bool HasKilledNum {
 get { return hasKilledNum; }
 }
 public Int32 KilledNum {
 get { return killedNum_; }
 set { SetKilledNum(value); }
 }
 public void SetKilledNum(Int32 value) { 
 hasKilledNum = true;
 killedNum_ = value;
 }

public const int sorceFieldNumber = 7;
 private bool hasSorce;
 private Int32 sorce_ = 0;
 public bool HasSorce {
 get { return hasSorce; }
 }
 public Int32 Sorce {
 get { return sorce_; }
 set { SetSorce(value); }
 }
 public void SetSorce(Int32 value) { 
 hasSorce = true;
 sorce_ = value;
 }

public const int rankFieldNumber = 8;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int maxKillNumFieldNumber = 9;
 private bool hasMaxKillNum;
 private Int32 maxKillNum_ = 0;
 public bool HasMaxKillNum {
 get { return hasMaxKillNum; }
 }
 public Int32 MaxKillNum {
 get { return maxKillNum_; }
 set { SetMaxKillNum(value); }
 }
 public void SetMaxKillNum(Int32 value) { 
 hasMaxKillNum = true;
 maxKillNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, GId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ServerId);
}
 if (HasKillPersonNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, KillPersonNum);
}
 if (HasKilledNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, KilledNum);
}
 if (HasSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Sorce);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Rank);
}
 if (HasMaxKillNum) {
size += pb::CodedOutputStream.ComputeInt32Size(9, MaxKillNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGId) {
output.WriteInt64(1, GId);
}
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasServerId) {
output.WriteInt32(3, ServerId);
}
 
if (HasKillPersonNum) {
output.WriteInt32(4, KillPersonNum);
}
 
if (HasKilledNum) {
output.WriteInt32(5, KilledNum);
}
 
if (HasSorce) {
output.WriteInt32(7, Sorce);
}
 
if (HasRank) {
output.WriteInt32(8, Rank);
}
 
if (HasMaxKillNum) {
output.WriteInt32(9, MaxKillNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAllCombatReport _inst = (GCAllCombatReport) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GId = input.ReadInt64();
break;
}
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.ServerId = input.ReadInt32();
break;
}
   case  32: {
 _inst.KillPersonNum = input.ReadInt32();
break;
}
   case  40: {
 _inst.KilledNum = input.ReadInt32();
break;
}
   case  56: {
 _inst.Sorce = input.ReadInt32();
break;
}
   case  64: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  72: {
 _inst.MaxKillNum = input.ReadInt32();
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
public class GCChangeSorce : PacketDistributed
{

public const int sorceFieldNumber = 7;
 private bool hasSorce;
 private Int32 sorce_ = 0;
 public bool HasSorce {
 get { return hasSorce; }
 }
 public Int32 Sorce {
 get { return sorce_; }
 set { SetSorce(value); }
 }
 public void SetSorce(Int32 value) { 
 hasSorce = true;
 sorce_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Sorce);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSorce) {
output.WriteInt32(7, Sorce);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChangeSorce _inst = (GCChangeSorce) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  56: {
 _inst.Sorce = input.ReadInt32();
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
public class GCEnterAllCombat : PacketDistributed
{

public const int actTypeFieldNumber = 1;
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

public const int ipFieldNumber = 2;
 private bool hasIp;
 private string ip_ = "";
 public bool HasIp {
 get { return hasIp; }
 }
 public string Ip {
 get { return ip_; }
 set { SetIp(value); }
 }
 public void SetIp(string value) { 
 hasIp = true;
 ip_ = value;
 }

public const int portFieldNumber = 3;
 private bool hasPort;
 private Int32 port_ = 0;
 public bool HasPort {
 get { return hasPort; }
 }
 public Int32 Port {
 get { return port_; }
 set { SetPort(value); }
 }
 public void SetPort(Int32 value) { 
 hasPort = true;
 port_ = value;
 }

public const int reportsFieldNumber = 4;
 private pbc::PopsicleList<GCAllCombatReport> reports_ = new pbc::PopsicleList<GCAllCombatReport>();
 public scg::IList<GCAllCombatReport> reportsList {
 get { return pbc::Lists.AsReadOnly(reports_); }
 }
 
 public int reportsCount {
 get { return reports_.Count; }
 }
 
public GCAllCombatReport GetReports(int index) {
 return reports_[index];
 }
 public void AddReports(GCAllCombatReport value) {
 reports_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActType);
}
 if (HasIp) {
size += pb::CodedOutputStream.ComputeStringSize(2, Ip);
}
 if (HasPort) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Port);
}
{
foreach (GCAllCombatReport element in reportsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActType) {
output.WriteInt32(1, ActType);
}
 
if (HasIp) {
output.WriteString(2, Ip);
}
 
if (HasPort) {
output.WriteInt32(3, Port);
}

do{
foreach (GCAllCombatReport element in reportsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEnterAllCombat _inst = (GCEnterAllCombat) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActType = input.ReadInt32();
break;
}
   case  18: {
 _inst.Ip = input.ReadString();
break;
}
   case  24: {
 _inst.Port = input.ReadInt32();
break;
}
    case  34: {
GCAllCombatReport subBuilder =  new GCAllCombatReport();
input.ReadMessage(subBuilder);
_inst.AddReports(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCAllCombatReport element in reportsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCEnterCombatEndTime : PacketDistributed
{

public const int remainSFieldNumber = 1;
 private bool hasRemainS;
 private Int64 remainS_ = 0;
 public bool HasRemainS {
 get { return hasRemainS; }
 }
 public Int64 RemainS {
 get { return remainS_; }
 set { SetRemainS(value); }
 }
 public void SetRemainS(Int64 value) { 
 hasRemainS = true;
 remainS_ = value;
 }

public const int rwdsFieldNumber = 2;
 private pbc::PopsicleList<AllRankRwd2> rwds_ = new pbc::PopsicleList<AllRankRwd2>();
 public scg::IList<AllRankRwd2> rwdsList {
 get { return pbc::Lists.AsReadOnly(rwds_); }
 }
 
 public int rwdsCount {
 get { return rwds_.Count; }
 }
 
public AllRankRwd2 GetRwds(int index) {
 return rwds_[index];
 }
 public void AddRwds(AllRankRwd2 value) {
 rwds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRemainS) {
size += pb::CodedOutputStream.ComputeInt64Size(1, RemainS);
}
{
foreach (AllRankRwd2 element in rwdsList) {
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
  
if (HasRemainS) {
output.WriteInt64(1, RemainS);
}

do{
foreach (AllRankRwd2 element in rwdsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEnterCombatEndTime _inst = (GCEnterCombatEndTime) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RemainS = input.ReadInt64();
break;
}
    case  18: {
AllRankRwd2 subBuilder =  new AllRankRwd2();
input.ReadMessage(subBuilder);
_inst.AddRwds(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (AllRankRwd2 element in rwdsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCExitAllCombat : PacketDistributed
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
 GCExitAllCombat _inst = (GCExitAllCombat) _base;
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
public class GCGetAllCombatRanks : PacketDistributed
{

public const int reportsFieldNumber = 1;
 private pbc::PopsicleList<GCAllCombatReport> reports_ = new pbc::PopsicleList<GCAllCombatReport>();
 public scg::IList<GCAllCombatReport> reportsList {
 get { return pbc::Lists.AsReadOnly(reports_); }
 }
 
 public int reportsCount {
 get { return reports_.Count; }
 }
 
public GCAllCombatReport GetReports(int index) {
 return reports_[index];
 }
 public void AddReports(GCAllCombatReport value) {
 reports_.Add(value);
 }

public const int myFieldNumber = 2;
 private bool hasMy;
 private GCAllCombatReport my_ =  new GCAllCombatReport();
 public bool HasMy {
 get { return hasMy; }
 }
 public GCAllCombatReport My {
 get { return my_; }
 set { SetMy(value); }
 }
 public void SetMy(GCAllCombatReport value) { 
 hasMy = true;
 my_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GCAllCombatReport element in reportsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = My.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (GCAllCombatReport element in reportsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)My.SerializedSize());
My.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetAllCombatRanks _inst = (GCGetAllCombatRanks) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GCAllCombatReport subBuilder =  new GCAllCombatReport();
input.ReadMessage(subBuilder);
_inst.AddReports(subBuilder);
break;
}
    case  18: {
GCAllCombatReport subBuilder =  new GCAllCombatReport();
 input.ReadMessage(subBuilder);
_inst.My = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCAllCombatReport element in reportsList) {
if (!element.IsInitialized()) return false;
}
  if (HasMy) {
if (!My.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetAllCombatView : PacketDistributed
{

public const int actStartTimeFieldNumber = 1;
 private bool hasActStartTime;
 private string actStartTime_ = "";
 public bool HasActStartTime {
 get { return hasActStartTime; }
 }
 public string ActStartTime {
 get { return actStartTime_; }
 set { SetActStartTime(value); }
 }
 public void SetActStartTime(string value) { 
 hasActStartTime = true;
 actStartTime_ = value;
 }

public const int combatStartTimeFieldNumber = 2;
 private bool hasCombatStartTime;
 private string combatStartTime_ = "";
 public bool HasCombatStartTime {
 get { return hasCombatStartTime; }
 }
 public string CombatStartTime {
 get { return combatStartTime_; }
 set { SetCombatStartTime(value); }
 }
 public void SetCombatStartTime(string value) { 
 hasCombatStartTime = true;
 combatStartTime_ = value;
 }

public const int titleFieldNumber = 4;
 private bool hasTitle;
 private Int32 title_ = 0;
 public bool HasTitle {
 get { return hasTitle; }
 }
 public Int32 Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(Int32 value) { 
 hasTitle = true;
 title_ = value;
 }

public const int functionFieldNumber = 5;
 private bool hasFunction;
 private string function_ = "";
 public bool HasFunction {
 get { return hasFunction; }
 }
 public string Function {
 get { return function_; }
 set { SetFunction(value); }
 }
 public void SetFunction(string value) { 
 hasFunction = true;
 function_ = value;
 }

public const int itemFieldNumber = 6;
 private bool hasItem;
 private string item_ = "";
 public bool HasItem {
 get { return hasItem; }
 }
 public string Item {
 get { return item_; }
 set { SetItem(value); }
 }
 public void SetItem(string value) { 
 hasItem = true;
 item_ = value;
 }

public const int rewardShowFieldNumber = 7;
 private bool hasRewardShow;
 private string rewardShow_ = "";
 public bool HasRewardShow {
 get { return hasRewardShow; }
 }
 public string RewardShow {
 get { return rewardShow_; }
 set { SetRewardShow(value); }
 }
 public void SetRewardShow(string value) { 
 hasRewardShow = true;
 rewardShow_ = value;
 }

public const int noticeFieldNumber = 8;
 private bool hasNotice;
 private string notice_ = "";
 public bool HasNotice {
 get { return hasNotice; }
 }
 public string Notice {
 get { return notice_; }
 set { SetNotice(value); }
 }
 public void SetNotice(string value) { 
 hasNotice = true;
 notice_ = value;
 }

public const int canEnterFieldNumber = 9;
 private bool hasCanEnter;
 private Int32 canEnter_ = 0;
 public bool HasCanEnter {
 get { return hasCanEnter; }
 }
 public Int32 CanEnter {
 get { return canEnter_; }
 set { SetCanEnter(value); }
 }
 public void SetCanEnter(Int32 value) { 
 hasCanEnter = true;
 canEnter_ = value;
 }

public const int sceneIdFieldNumber = 10;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActStartTime) {
size += pb::CodedOutputStream.ComputeStringSize(1, ActStartTime);
}
 if (HasCombatStartTime) {
size += pb::CodedOutputStream.ComputeStringSize(2, CombatStartTime);
}
 if (HasTitle) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Title);
}
 if (HasFunction) {
size += pb::CodedOutputStream.ComputeStringSize(5, Function);
}
 if (HasItem) {
size += pb::CodedOutputStream.ComputeStringSize(6, Item);
}
 if (HasRewardShow) {
size += pb::CodedOutputStream.ComputeStringSize(7, RewardShow);
}
 if (HasNotice) {
size += pb::CodedOutputStream.ComputeStringSize(8, Notice);
}
 if (HasCanEnter) {
size += pb::CodedOutputStream.ComputeInt32Size(9, CanEnter);
}
 if (HasSceneId) {
size += pb::CodedOutputStream.ComputeInt32Size(10, SceneId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActStartTime) {
output.WriteString(1, ActStartTime);
}
 
if (HasCombatStartTime) {
output.WriteString(2, CombatStartTime);
}
 
if (HasTitle) {
output.WriteInt32(4, Title);
}
 
if (HasFunction) {
output.WriteString(5, Function);
}
 
if (HasItem) {
output.WriteString(6, Item);
}
 
if (HasRewardShow) {
output.WriteString(7, RewardShow);
}
 
if (HasNotice) {
output.WriteString(8, Notice);
}
 
if (HasCanEnter) {
output.WriteInt32(9, CanEnter);
}
 
if (HasSceneId) {
output.WriteInt32(10, SceneId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetAllCombatView _inst = (GCGetAllCombatView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.ActStartTime = input.ReadString();
break;
}
   case  18: {
 _inst.CombatStartTime = input.ReadString();
break;
}
   case  32: {
 _inst.Title = input.ReadInt32();
break;
}
   case  42: {
 _inst.Function = input.ReadString();
break;
}
   case  50: {
 _inst.Item = input.ReadString();
break;
}
   case  58: {
 _inst.RewardShow = input.ReadString();
break;
}
   case  66: {
 _inst.Notice = input.ReadString();
break;
}
   case  72: {
 _inst.CanEnter = input.ReadInt32();
break;
}
   case  80: {
 _inst.SceneId = input.ReadInt32();
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
public class GCGetAllRankDatas : PacketDistributed
{

public const int ranksFieldNumber = 1;
 private pbc::PopsicleList<AllcombatRankData> ranks_ = new pbc::PopsicleList<AllcombatRankData>();
 public scg::IList<AllcombatRankData> ranksList {
 get { return pbc::Lists.AsReadOnly(ranks_); }
 }
 
 public int ranksCount {
 get { return ranks_.Count; }
 }
 
public AllcombatRankData GetRanks(int index) {
 return ranks_[index];
 }
 public void AddRanks(AllcombatRankData value) {
 ranks_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (AllcombatRankData element in ranksList) {
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
foreach (AllcombatRankData element in ranksList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetAllRankDatas _inst = (GCGetAllRankDatas) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
AllcombatRankData subBuilder =  new AllcombatRankData();
input.ReadMessage(subBuilder);
_inst.AddRanks(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (AllcombatRankData element in ranksList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class MessageList : PacketDistributed
{

public const int innerPacketsFieldNumber = 1;
 private bool hasInnerPackets;
 private pb::ByteString innerPackets_ = pb::ByteString.Empty;
 public bool HasInnerPackets {
 get { return hasInnerPackets; }
 }
 public pb::ByteString InnerPackets {
 get { return innerPackets_; }
 set { SetInnerPackets(value); }
 }
 public void SetInnerPackets(pb::ByteString value) { 
 hasInnerPackets = true;
 innerPackets_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasInnerPackets) {
size += pb::CodedOutputStream.ComputeBytesSize(1, InnerPackets);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasInnerPackets) {
output.WriteBytes(1, InnerPackets);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MessageList _inst = (MessageList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.InnerPackets = input.ReadBytes();
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
public class MethodInvoteMsg : PacketDistributed
{

public const int innerPacketFieldNumber = 1;
 private bool hasInnerPacket;
 private pb::ByteString innerPacket_ = pb::ByteString.Empty;
 public bool HasInnerPacket {
 get { return hasInnerPacket; }
 }
 public pb::ByteString InnerPacket {
 get { return innerPacket_; }
 set { SetInnerPacket(value); }
 }
 public void SetInnerPacket(pb::ByteString value) { 
 hasInnerPacket = true;
 innerPacket_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasInnerPacket) {
size += pb::CodedOutputStream.ComputeBytesSize(1, InnerPacket);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasInnerPacket) {
output.WriteBytes(1, InnerPacket);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MethodInvoteMsg _inst = (MethodInvoteMsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.InnerPacket = input.ReadBytes();
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
