//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGWorldBossInfo : PacketDistributed
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

public const int playerIdFieldNumber = 2;
 private bool hasPlayerId;
 private Int64 playerId_ = 0;
 public bool HasPlayerId {
 get { return hasPlayerId; }
 }
 public Int64 PlayerId {
 get { return playerId_; }
 set { SetPlayerId(value); }
 }
 public void SetPlayerId(Int64 value) { 
 hasPlayerId = true;
 playerId_ = value;
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
 if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PlayerId);
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
 
if (HasPlayerId) {
output.WriteInt64(2, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGWorldBossInfo _inst = (CGWorldBossInfo) _base;
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
 _inst.PlayerId = input.ReadInt64();
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
public class GCWorldBossInfo : PacketDistributed
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

public const int playerInfoFieldNumber = 2;
 private bool hasPlayerInfo;
 private WorldBossPlayerInfo playerInfo_ =  new WorldBossPlayerInfo();
 public bool HasPlayerInfo {
 get { return hasPlayerInfo; }
 }
 public WorldBossPlayerInfo PlayerInfo {
 get { return playerInfo_; }
 set { SetPlayerInfo(value); }
 }
 public void SetPlayerInfo(WorldBossPlayerInfo value) { 
 hasPlayerInfo = true;
 playerInfo_ = value;
 }

public const int bossIDFieldNumber = 3;
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
int subsize = PlayerInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasBossID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BossID);
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
output.WriteRawVarint32((uint)PlayerInfo.SerializedSize());
PlayerInfo.WriteTo(output);

}
 
if (HasBossID) {
output.WriteInt32(3, BossID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCWorldBossInfo _inst = (GCWorldBossInfo) _base;
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
WorldBossPlayerInfo subBuilder =  new WorldBossPlayerInfo();
 input.ReadMessage(subBuilder);
_inst.PlayerInfo = subBuilder;
break;
}
   case  24: {
 _inst.BossID = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPlayerInfo) {
if (!PlayerInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class WorldBossPlayerInfo : PacketDistributed
{

public const int inspireTimeFieldNumber = 1;
 private bool hasInspireTime;
 private Int64 inspireTime_ = 0;
 public bool HasInspireTime {
 get { return hasInspireTime; }
 }
 public Int64 InspireTime {
 get { return inspireTime_; }
 set { SetInspireTime(value); }
 }
 public void SetInspireTime(Int64 value) { 
 hasInspireTime = true;
 inspireTime_ = value;
 }

public const int freeInspireFieldNumber = 2;
 private bool hasFreeInspire;
 private Int32 freeInspire_ = 0;
 public bool HasFreeInspire {
 get { return hasFreeInspire; }
 }
 public Int32 FreeInspire {
 get { return freeInspire_; }
 set { SetFreeInspire(value); }
 }
 public void SetFreeInspire(Int32 value) { 
 hasFreeInspire = true;
 freeInspire_ = value;
 }

public const int payInspireFieldNumber = 3;
 private bool hasPayInspire;
 private Int32 payInspire_ = 0;
 public bool HasPayInspire {
 get { return hasPayInspire; }
 }
 public Int32 PayInspire {
 get { return payInspire_; }
 set { SetPayInspire(value); }
 }
 public void SetPayInspire(Int32 value) { 
 hasPayInspire = true;
 payInspire_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasInspireTime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, InspireTime);
}
 if (HasFreeInspire) {
size += pb::CodedOutputStream.ComputeInt32Size(2, FreeInspire);
}
 if (HasPayInspire) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PayInspire);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasInspireTime) {
output.WriteInt64(1, InspireTime);
}
 
if (HasFreeInspire) {
output.WriteInt32(2, FreeInspire);
}
 
if (HasPayInspire) {
output.WriteInt32(3, PayInspire);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 WorldBossPlayerInfo _inst = (WorldBossPlayerInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.InspireTime = input.ReadInt64();
break;
}
   case  16: {
 _inst.FreeInspire = input.ReadInt32();
break;
}
   case  24: {
 _inst.PayInspire = input.ReadInt32();
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
