//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class EnterGame : PacketDistributed
{

public const int isStartGameFieldNumber = 1;
 private bool hasIsStartGame;
 private Int32 isStartGame_ = 0;
 public bool HasIsStartGame {
 get { return hasIsStartGame; }
 }
 public Int32 IsStartGame {
 get { return isStartGame_; }
 set { SetIsStartGame(value); }
 }
 public void SetIsStartGame(Int32 value) { 
 hasIsStartGame = true;
 isStartGame_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasIsStartGame) {
size += pb::CodedOutputStream.ComputeInt32Size(1, IsStartGame);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasIsStartGame) {
output.WriteInt32(1, IsStartGame);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EnterGame _inst = (EnterGame) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.IsStartGame = input.ReadInt32();
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
public class FrameOpts : PacketDistributed
{

public const int frameIdFieldNumber = 1;
 private bool hasFrameId;
 private Int32 frameId_ = 0;
 public bool HasFrameId {
 get { return hasFrameId; }
 }
 public Int32 FrameId {
 get { return frameId_; }
 set { SetFrameId(value); }
 }
 public void SetFrameId(Int32 value) { 
 hasFrameId = true;
 frameId_ = value;
 }

public const int optsFieldNumber = 2;
 private pbc::PopsicleList<OptionEvent> opts_ = new pbc::PopsicleList<OptionEvent>();
 public scg::IList<OptionEvent> optsList {
 get { return pbc::Lists.AsReadOnly(opts_); }
 }
 
 public int optsCount {
 get { return opts_.Count; }
 }
 
public OptionEvent GetOpts(int index) {
 return opts_[index];
 }
 public void AddOpts(OptionEvent value) {
 opts_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFrameId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FrameId);
}
{
foreach (OptionEvent element in optsList) {
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
  
if (HasFrameId) {
output.WriteInt32(1, FrameId);
}

do{
foreach (OptionEvent element in optsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FrameOpts _inst = (FrameOpts) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FrameId = input.ReadInt32();
break;
}
    case  18: {
OptionEvent subBuilder =  new OptionEvent();
input.ReadMessage(subBuilder);
_inst.AddOpts(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (OptionEvent element in optsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GamePlayerInfo : PacketDistributed
{

public const int syncFrameIdFieldNumber = 1;
 private bool hasSyncFrameId;
 private Int32 syncFrameId_ = 0;
 public bool HasSyncFrameId {
 get { return hasSyncFrameId; }
 }
 public Int32 SyncFrameId {
 get { return syncFrameId_; }
 set { SetSyncFrameId(value); }
 }
 public void SetSyncFrameId(Int32 value) { 
 hasSyncFrameId = true;
 syncFrameId_ = value;
 }

public const int seatIdFieldNumber = 2;
 private bool hasSeatId;
 private Int32 seatId_ = 0;
 public bool HasSeatId {
 get { return hasSeatId; }
 }
 public Int32 SeatId {
 get { return seatId_; }
 set { SetSeatId(value); }
 }
 public void SetSeatId(Int32 value) { 
 hasSeatId = true;
 seatId_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSyncFrameId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SyncFrameId);
}
 if (HasSeatId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SeatId);
}
 if (HasPort) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Port);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSyncFrameId) {
output.WriteInt32(1, SyncFrameId);
}
 
if (HasSeatId) {
output.WriteInt32(2, SeatId);
}
 
if (HasPort) {
output.WriteInt32(3, Port);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GamePlayerInfo _inst = (GamePlayerInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SyncFrameId = input.ReadInt32();
break;
}
   case  16: {
 _inst.SeatId = input.ReadInt32();
break;
}
   case  24: {
 _inst.Port = input.ReadInt32();
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
public class LogicFrame : PacketDistributed
{

public const int frameIdFieldNumber = 1;
 private bool hasFrameId;
 private Int32 frameId_ = 0;
 public bool HasFrameId {
 get { return hasFrameId; }
 }
 public Int32 FrameId {
 get { return frameId_; }
 set { SetFrameId(value); }
 }
 public void SetFrameId(Int32 value) { 
 hasFrameId = true;
 frameId_ = value;
 }

public const int unSyncFramesFieldNumber = 2;
 private pbc::PopsicleList<FrameOpts> unSyncFrames_ = new pbc::PopsicleList<FrameOpts>();
 public scg::IList<FrameOpts> unSyncFramesList {
 get { return pbc::Lists.AsReadOnly(unSyncFrames_); }
 }
 
 public int unSyncFramesCount {
 get { return unSyncFrames_.Count; }
 }
 
public FrameOpts GetUnSyncFrames(int index) {
 return unSyncFrames_[index];
 }
 public void AddUnSyncFrames(FrameOpts value) {
 unSyncFrames_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFrameId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FrameId);
}
{
foreach (FrameOpts element in unSyncFramesList) {
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
  
if (HasFrameId) {
output.WriteInt32(1, FrameId);
}

do{
foreach (FrameOpts element in unSyncFramesList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LogicFrame _inst = (LogicFrame) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FrameId = input.ReadInt32();
break;
}
    case  18: {
FrameOpts subBuilder =  new FrameOpts();
input.ReadMessage(subBuilder);
_inst.AddUnSyncFrames(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FrameOpts element in unSyncFramesList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class NextFrameOpts : PacketDistributed
{

public const int frameIdFieldNumber = 1;
 private bool hasFrameId;
 private Int32 frameId_ = 0;
 public bool HasFrameId {
 get { return hasFrameId; }
 }
 public Int32 FrameId {
 get { return frameId_; }
 set { SetFrameId(value); }
 }
 public void SetFrameId(Int32 value) { 
 hasFrameId = true;
 frameId_ = value;
 }

public const int matchIdFieldNumber = 2;
 private bool hasMatchId;
 private Int32 matchId_ = 0;
 public bool HasMatchId {
 get { return hasMatchId; }
 }
 public Int32 MatchId {
 get { return matchId_; }
 set { SetMatchId(value); }
 }
 public void SetMatchId(Int32 value) { 
 hasMatchId = true;
 matchId_ = value;
 }

public const int seatIdFieldNumber = 3;
 private bool hasSeatId;
 private Int32 seatId_ = 0;
 public bool HasSeatId {
 get { return hasSeatId; }
 }
 public Int32 SeatId {
 get { return seatId_; }
 set { SetSeatId(value); }
 }
 public void SetSeatId(Int32 value) { 
 hasSeatId = true;
 seatId_ = value;
 }

public const int optsFieldNumber = 4;
 private pbc::PopsicleList<OptionEvent> opts_ = new pbc::PopsicleList<OptionEvent>();
 public scg::IList<OptionEvent> optsList {
 get { return pbc::Lists.AsReadOnly(opts_); }
 }
 
 public int optsCount {
 get { return opts_.Count; }
 }
 
public OptionEvent GetOpts(int index) {
 return opts_[index];
 }
 public void AddOpts(OptionEvent value) {
 opts_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFrameId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FrameId);
}
 if (HasMatchId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MatchId);
}
 if (HasSeatId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SeatId);
}
{
foreach (OptionEvent element in optsList) {
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
  
if (HasFrameId) {
output.WriteInt32(1, FrameId);
}
 
if (HasMatchId) {
output.WriteInt32(2, MatchId);
}
 
if (HasSeatId) {
output.WriteInt32(3, SeatId);
}

do{
foreach (OptionEvent element in optsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NextFrameOpts _inst = (NextFrameOpts) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FrameId = input.ReadInt32();
break;
}
   case  16: {
 _inst.MatchId = input.ReadInt32();
break;
}
   case  24: {
 _inst.SeatId = input.ReadInt32();
break;
}
    case  34: {
OptionEvent subBuilder =  new OptionEvent();
input.ReadMessage(subBuilder);
_inst.AddOpts(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (OptionEvent element in optsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class OptionEvent : PacketDistributed
{

public const int seatIdFieldNumber = 1;
 private bool hasSeatId;
 private Int32 seatId_ = 0;
 public bool HasSeatId {
 get { return hasSeatId; }
 }
 public Int32 SeatId {
 get { return seatId_; }
 set { SetSeatId(value); }
 }
 public void SetSeatId(Int32 value) { 
 hasSeatId = true;
 seatId_ = value;
 }

public const int optTypeFieldNumber = 2;
 private bool hasOptType;
 private Int32 optType_ = 0;
 public bool HasOptType {
 get { return hasOptType; }
 }
 public Int32 OptType {
 get { return optType_; }
 set { SetOptType(value); }
 }
 public void SetOptType(Int32 value) { 
 hasOptType = true;
 optType_ = value;
 }

public const int posXFieldNumber = 3;
 private bool hasPosX;
 private Int32 posX_ = 0;
 public bool HasPosX {
 get { return hasPosX; }
 }
 public Int32 PosX {
 get { return posX_; }
 set { SetPosX(value); }
 }
 public void SetPosX(Int32 value) { 
 hasPosX = true;
 posX_ = value;
 }

public const int posYFieldNumber = 4;
 private bool hasPosY;
 private Int32 posY_ = 0;
 public bool HasPosY {
 get { return hasPosY; }
 }
 public Int32 PosY {
 get { return posY_; }
 set { SetPosY(value); }
 }
 public void SetPosY(Int32 value) { 
 hasPosY = true;
 posY_ = value;
 }

public const int posZFieldNumber = 5;
 private bool hasPosZ;
 private Int32 posZ_ = 0;
 public bool HasPosZ {
 get { return hasPosZ; }
 }
 public Int32 PosZ {
 get { return posZ_; }
 set { SetPosZ(value); }
 }
 public void SetPosZ(Int32 value) { 
 hasPosZ = true;
 posZ_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSeatId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SeatId);
}
 if (HasOptType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, OptType);
}
 if (HasPosX) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PosX);
}
 if (HasPosY) {
size += pb::CodedOutputStream.ComputeInt32Size(4, PosY);
}
 if (HasPosZ) {
size += pb::CodedOutputStream.ComputeInt32Size(5, PosZ);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSeatId) {
output.WriteInt32(1, SeatId);
}
 
if (HasOptType) {
output.WriteInt32(2, OptType);
}
 
if (HasPosX) {
output.WriteInt32(3, PosX);
}
 
if (HasPosY) {
output.WriteInt32(4, PosY);
}
 
if (HasPosZ) {
output.WriteInt32(5, PosZ);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 OptionEvent _inst = (OptionEvent) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SeatId = input.ReadInt32();
break;
}
   case  16: {
 _inst.OptType = input.ReadInt32();
break;
}
   case  24: {
 _inst.PosX = input.ReadInt32();
break;
}
   case  32: {
 _inst.PosY = input.ReadInt32();
break;
}
   case  40: {
 _inst.PosZ = input.ReadInt32();
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
