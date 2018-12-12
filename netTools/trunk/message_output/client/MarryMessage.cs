//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGAgreeOrRefuse : PacketDistributed
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
 CGAgreeOrRefuse _inst = (CGAgreeOrRefuse) _base;
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
public class CGDivorce : PacketDistributed
{

public const int divorceTypeFieldNumber = 1;
 private bool hasDivorceType;
 private Int32 divorceType_ = 0;
 public bool HasDivorceType {
 get { return hasDivorceType; }
 }
 public Int32 DivorceType {
 get { return divorceType_; }
 set { SetDivorceType(value); }
 }
 public void SetDivorceType(Int32 value) { 
 hasDivorceType = true;
 divorceType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDivorceType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, DivorceType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDivorceType) {
output.WriteInt32(1, DivorceType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGDivorce _inst = (CGDivorce) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.DivorceType = input.ReadInt32();
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
public class CGDoMarry : PacketDistributed
{

public const int sourcePlayerIdFieldNumber = 1;
 private bool hasSourcePlayerId;
 private Int64 sourcePlayerId_ = 0;
 public bool HasSourcePlayerId {
 get { return hasSourcePlayerId; }
 }
 public Int64 SourcePlayerId {
 get { return sourcePlayerId_; }
 set { SetSourcePlayerId(value); }
 }
 public void SetSourcePlayerId(Int64 value) { 
 hasSourcePlayerId = true;
 sourcePlayerId_ = value;
 }

public const int targetPlayerIdFieldNumber = 2;
 private bool hasTargetPlayerId;
 private Int64 targetPlayerId_ = 0;
 public bool HasTargetPlayerId {
 get { return hasTargetPlayerId; }
 }
 public Int64 TargetPlayerId {
 get { return targetPlayerId_; }
 set { SetTargetPlayerId(value); }
 }
 public void SetTargetPlayerId(Int64 value) { 
 hasTargetPlayerId = true;
 targetPlayerId_ = value;
 }

public const int ringIdFieldNumber = 4;
 private bool hasRingId;
 private Int32 ringId_ = 0;
 public bool HasRingId {
 get { return hasRingId; }
 }
 public Int32 RingId {
 get { return ringId_; }
 set { SetRingId(value); }
 }
 public void SetRingId(Int32 value) { 
 hasRingId = true;
 ringId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSourcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SourcePlayerId);
}
 if (HasTargetPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetPlayerId);
}
 if (HasRingId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, RingId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSourcePlayerId) {
output.WriteInt64(1, SourcePlayerId);
}
 
if (HasTargetPlayerId) {
output.WriteInt64(2, TargetPlayerId);
}
 
if (HasRingId) {
output.WriteInt32(4, RingId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGDoMarry _inst = (CGDoMarry) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SourcePlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TargetPlayerId = input.ReadInt64();
break;
}
   case  32: {
 _inst.RingId = input.ReadInt32();
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
public class CGExpressLove : PacketDistributed
{

public const int sourcePlayerIdFieldNumber = 1;
 private bool hasSourcePlayerId;
 private Int64 sourcePlayerId_ = 0;
 public bool HasSourcePlayerId {
 get { return hasSourcePlayerId; }
 }
 public Int64 SourcePlayerId {
 get { return sourcePlayerId_; }
 set { SetSourcePlayerId(value); }
 }
 public void SetSourcePlayerId(Int64 value) { 
 hasSourcePlayerId = true;
 sourcePlayerId_ = value;
 }

public const int targetPlayerIdFieldNumber = 2;
 private bool hasTargetPlayerId;
 private Int64 targetPlayerId_ = 0;
 public bool HasTargetPlayerId {
 get { return hasTargetPlayerId; }
 }
 public Int64 TargetPlayerId {
 get { return targetPlayerId_; }
 set { SetTargetPlayerId(value); }
 }
 public void SetTargetPlayerId(Int64 value) { 
 hasTargetPlayerId = true;
 targetPlayerId_ = value;
 }

public const int ringIdFieldNumber = 3;
 private bool hasRingId;
 private Int32 ringId_ = 0;
 public bool HasRingId {
 get { return hasRingId; }
 }
 public Int32 RingId {
 get { return ringId_; }
 set { SetRingId(value); }
 }
 public void SetRingId(Int32 value) { 
 hasRingId = true;
 ringId_ = value;
 }

public const int loveLetterFieldNumber = 4;
 private bool hasLoveLetter;
 private string loveLetter_ = "";
 public bool HasLoveLetter {
 get { return hasLoveLetter; }
 }
 public string LoveLetter {
 get { return loveLetter_; }
 set { SetLoveLetter(value); }
 }
 public void SetLoveLetter(string value) { 
 hasLoveLetter = true;
 loveLetter_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSourcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SourcePlayerId);
}
 if (HasTargetPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetPlayerId);
}
 if (HasRingId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RingId);
}
 if (HasLoveLetter) {
size += pb::CodedOutputStream.ComputeStringSize(4, LoveLetter);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSourcePlayerId) {
output.WriteInt64(1, SourcePlayerId);
}
 
if (HasTargetPlayerId) {
output.WriteInt64(2, TargetPlayerId);
}
 
if (HasRingId) {
output.WriteInt32(3, RingId);
}
 
if (HasLoveLetter) {
output.WriteString(4, LoveLetter);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGExpressLove _inst = (CGExpressLove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SourcePlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TargetPlayerId = input.ReadInt64();
break;
}
   case  24: {
 _inst.RingId = input.ReadInt32();
break;
}
   case  34: {
 _inst.LoveLetter = input.ReadString();
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
public class CGExpressLoveBack : PacketDistributed
{

public const int sourcePlayerIdFieldNumber = 1;
 private bool hasSourcePlayerId;
 private Int64 sourcePlayerId_ = 0;
 public bool HasSourcePlayerId {
 get { return hasSourcePlayerId; }
 }
 public Int64 SourcePlayerId {
 get { return sourcePlayerId_; }
 set { SetSourcePlayerId(value); }
 }
 public void SetSourcePlayerId(Int64 value) { 
 hasSourcePlayerId = true;
 sourcePlayerId_ = value;
 }

public const int targetPlayerIdFieldNumber = 2;
 private bool hasTargetPlayerId;
 private Int64 targetPlayerId_ = 0;
 public bool HasTargetPlayerId {
 get { return hasTargetPlayerId; }
 }
 public Int64 TargetPlayerId {
 get { return targetPlayerId_; }
 set { SetTargetPlayerId(value); }
 }
 public void SetTargetPlayerId(Int64 value) { 
 hasTargetPlayerId = true;
 targetPlayerId_ = value;
 }

public const int ringIdFieldNumber = 3;
 private bool hasRingId;
 private Int32 ringId_ = 0;
 public bool HasRingId {
 get { return hasRingId; }
 }
 public Int32 RingId {
 get { return ringId_; }
 set { SetRingId(value); }
 }
 public void SetRingId(Int32 value) { 
 hasRingId = true;
 ringId_ = value;
 }

public const int resultFieldNumber = 4;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSourcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SourcePlayerId);
}
 if (HasTargetPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetPlayerId);
}
 if (HasRingId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RingId);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSourcePlayerId) {
output.WriteInt64(1, SourcePlayerId);
}
 
if (HasTargetPlayerId) {
output.WriteInt64(2, TargetPlayerId);
}
 
if (HasRingId) {
output.WriteInt32(3, RingId);
}
 
if (HasResult) {
output.WriteInt32(4, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGExpressLoveBack _inst = (CGExpressLoveBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SourcePlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TargetPlayerId = input.ReadInt64();
break;
}
   case  24: {
 _inst.RingId = input.ReadInt32();
break;
}
   case  32: {
 _inst.Result = input.ReadInt32();
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
public class CGMarryRingPower : PacketDistributed
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
 CGMarryRingPower _inst = (CGMarryRingPower) _base;
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
public class CGSearchMarryInfo : PacketDistributed
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
 CGSearchMarryInfo _inst = (CGSearchMarryInfo) _base;
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
public class GCAgreeOrRefuse : PacketDistributed
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

public const int dataFieldNumber = 2;
 private bool hasData;
 private GCMarrySts data_ =  new GCMarrySts();
 public bool HasData {
 get { return hasData; }
 }
 public GCMarrySts Data {
 get { return data_; }
 set { SetData(value); }
 }
 public void SetData(GCMarrySts value) { 
 hasData = true;
 data_ = value;
 }

public const int playerNameFieldNumber = 3;
 private bool hasPlayerName;
 private string playerName_ = "";
 public bool HasPlayerName {
 get { return hasPlayerName; }
 }
 public string PlayerName {
 get { return playerName_; }
 set { SetPlayerName(value); }
 }
 public void SetPlayerName(string value) { 
 hasPlayerName = true;
 playerName_ = value;
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
int subsize = Data.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlayerName);
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
output.WriteRawVarint32((uint)Data.SerializedSize());
Data.WriteTo(output);

}
 
if (HasPlayerName) {
output.WriteString(3, PlayerName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAgreeOrRefuse _inst = (GCAgreeOrRefuse) _base;
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
GCMarrySts subBuilder =  new GCMarrySts();
 input.ReadMessage(subBuilder);
_inst.Data = subBuilder;
break;
}
   case  26: {
 _inst.PlayerName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasData) {
if (!Data.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDivorce : PacketDistributed
{

public const int divorceTypeFieldNumber = 1;
 private bool hasDivorceType;
 private Int32 divorceType_ = 0;
 public bool HasDivorceType {
 get { return hasDivorceType; }
 }
 public Int32 DivorceType {
 get { return divorceType_; }
 set { SetDivorceType(value); }
 }
 public void SetDivorceType(Int32 value) { 
 hasDivorceType = true;
 divorceType_ = value;
 }

public const int dataFieldNumber = 2;
 private bool hasData;
 private GCMarrySts data_ =  new GCMarrySts();
 public bool HasData {
 get { return hasData; }
 }
 public GCMarrySts Data {
 get { return data_; }
 set { SetData(value); }
 }
 public void SetData(GCMarrySts value) { 
 hasData = true;
 data_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDivorceType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, DivorceType);
}
{
int subsize = Data.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDivorceType) {
output.WriteInt32(1, DivorceType);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Data.SerializedSize());
Data.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDivorce _inst = (GCDivorce) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.DivorceType = input.ReadInt32();
break;
}
    case  18: {
GCMarrySts subBuilder =  new GCMarrySts();
 input.ReadMessage(subBuilder);
_inst.Data = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasData) {
if (!Data.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDoMarry : PacketDistributed
{

public const int sourcePlayerIdFieldNumber = 1;
 private bool hasSourcePlayerId;
 private Int64 sourcePlayerId_ = 0;
 public bool HasSourcePlayerId {
 get { return hasSourcePlayerId; }
 }
 public Int64 SourcePlayerId {
 get { return sourcePlayerId_; }
 set { SetSourcePlayerId(value); }
 }
 public void SetSourcePlayerId(Int64 value) { 
 hasSourcePlayerId = true;
 sourcePlayerId_ = value;
 }

public const int targetPlayerIdFieldNumber = 2;
 private bool hasTargetPlayerId;
 private Int64 targetPlayerId_ = 0;
 public bool HasTargetPlayerId {
 get { return hasTargetPlayerId; }
 }
 public Int64 TargetPlayerId {
 get { return targetPlayerId_; }
 set { SetTargetPlayerId(value); }
 }
 public void SetTargetPlayerId(Int64 value) { 
 hasTargetPlayerId = true;
 targetPlayerId_ = value;
 }

public const int ringIdFieldNumber = 3;
 private bool hasRingId;
 private Int32 ringId_ = 0;
 public bool HasRingId {
 get { return hasRingId; }
 }
 public Int32 RingId {
 get { return ringId_; }
 set { SetRingId(value); }
 }
 public void SetRingId(Int32 value) { 
 hasRingId = true;
 ringId_ = value;
 }

public const int sourceNameFieldNumber = 4;
 private bool hasSourceName;
 private string sourceName_ = "";
 public bool HasSourceName {
 get { return hasSourceName; }
 }
 public string SourceName {
 get { return sourceName_; }
 set { SetSourceName(value); }
 }
 public void SetSourceName(string value) { 
 hasSourceName = true;
 sourceName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSourcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SourcePlayerId);
}
 if (HasTargetPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetPlayerId);
}
 if (HasRingId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RingId);
}
 if (HasSourceName) {
size += pb::CodedOutputStream.ComputeStringSize(4, SourceName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSourcePlayerId) {
output.WriteInt64(1, SourcePlayerId);
}
 
if (HasTargetPlayerId) {
output.WriteInt64(2, TargetPlayerId);
}
 
if (HasRingId) {
output.WriteInt32(3, RingId);
}
 
if (HasSourceName) {
output.WriteString(4, SourceName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDoMarry _inst = (GCDoMarry) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SourcePlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TargetPlayerId = input.ReadInt64();
break;
}
   case  24: {
 _inst.RingId = input.ReadInt32();
break;
}
   case  34: {
 _inst.SourceName = input.ReadString();
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
public class GCExpressLove : PacketDistributed
{

public const int sourcePlayerIdFieldNumber = 1;
 private bool hasSourcePlayerId;
 private Int64 sourcePlayerId_ = 0;
 public bool HasSourcePlayerId {
 get { return hasSourcePlayerId; }
 }
 public Int64 SourcePlayerId {
 get { return sourcePlayerId_; }
 set { SetSourcePlayerId(value); }
 }
 public void SetSourcePlayerId(Int64 value) { 
 hasSourcePlayerId = true;
 sourcePlayerId_ = value;
 }

public const int targetPlayerIdFieldNumber = 2;
 private bool hasTargetPlayerId;
 private Int64 targetPlayerId_ = 0;
 public bool HasTargetPlayerId {
 get { return hasTargetPlayerId; }
 }
 public Int64 TargetPlayerId {
 get { return targetPlayerId_; }
 set { SetTargetPlayerId(value); }
 }
 public void SetTargetPlayerId(Int64 value) { 
 hasTargetPlayerId = true;
 targetPlayerId_ = value;
 }

public const int ringIdFieldNumber = 3;
 private bool hasRingId;
 private Int32 ringId_ = 0;
 public bool HasRingId {
 get { return hasRingId; }
 }
 public Int32 RingId {
 get { return ringId_; }
 set { SetRingId(value); }
 }
 public void SetRingId(Int32 value) { 
 hasRingId = true;
 ringId_ = value;
 }

public const int loveLetterFieldNumber = 4;
 private bool hasLoveLetter;
 private string loveLetter_ = "";
 public bool HasLoveLetter {
 get { return hasLoveLetter; }
 }
 public string LoveLetter {
 get { return loveLetter_; }
 set { SetLoveLetter(value); }
 }
 public void SetLoveLetter(string value) { 
 hasLoveLetter = true;
 loveLetter_ = value;
 }

public const int sourceNameFieldNumber = 5;
 private bool hasSourceName;
 private string sourceName_ = "";
 public bool HasSourceName {
 get { return hasSourceName; }
 }
 public string SourceName {
 get { return sourceName_; }
 set { SetSourceName(value); }
 }
 public void SetSourceName(string value) { 
 hasSourceName = true;
 sourceName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSourcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SourcePlayerId);
}
 if (HasTargetPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetPlayerId);
}
 if (HasRingId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RingId);
}
 if (HasLoveLetter) {
size += pb::CodedOutputStream.ComputeStringSize(4, LoveLetter);
}
 if (HasSourceName) {
size += pb::CodedOutputStream.ComputeStringSize(5, SourceName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSourcePlayerId) {
output.WriteInt64(1, SourcePlayerId);
}
 
if (HasTargetPlayerId) {
output.WriteInt64(2, TargetPlayerId);
}
 
if (HasRingId) {
output.WriteInt32(3, RingId);
}
 
if (HasLoveLetter) {
output.WriteString(4, LoveLetter);
}
 
if (HasSourceName) {
output.WriteString(5, SourceName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCExpressLove _inst = (GCExpressLove) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SourcePlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TargetPlayerId = input.ReadInt64();
break;
}
   case  24: {
 _inst.RingId = input.ReadInt32();
break;
}
   case  34: {
 _inst.LoveLetter = input.ReadString();
break;
}
   case  42: {
 _inst.SourceName = input.ReadString();
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
public class GCExpressLoveBack : PacketDistributed
{

public const int sourcePlayerIdFieldNumber = 1;
 private bool hasSourcePlayerId;
 private Int64 sourcePlayerId_ = 0;
 public bool HasSourcePlayerId {
 get { return hasSourcePlayerId; }
 }
 public Int64 SourcePlayerId {
 get { return sourcePlayerId_; }
 set { SetSourcePlayerId(value); }
 }
 public void SetSourcePlayerId(Int64 value) { 
 hasSourcePlayerId = true;
 sourcePlayerId_ = value;
 }

public const int targetPlayerIdFieldNumber = 2;
 private bool hasTargetPlayerId;
 private Int64 targetPlayerId_ = 0;
 public bool HasTargetPlayerId {
 get { return hasTargetPlayerId; }
 }
 public Int64 TargetPlayerId {
 get { return targetPlayerId_; }
 set { SetTargetPlayerId(value); }
 }
 public void SetTargetPlayerId(Int64 value) { 
 hasTargetPlayerId = true;
 targetPlayerId_ = value;
 }

public const int ringIdFieldNumber = 3;
 private bool hasRingId;
 private Int32 ringId_ = 0;
 public bool HasRingId {
 get { return hasRingId; }
 }
 public Int32 RingId {
 get { return ringId_; }
 set { SetRingId(value); }
 }
 public void SetRingId(Int32 value) { 
 hasRingId = true;
 ringId_ = value;
 }

public const int resultFieldNumber = 4;
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

public const int targetNameFieldNumber = 5;
 private bool hasTargetName;
 private string targetName_ = "";
 public bool HasTargetName {
 get { return hasTargetName; }
 }
 public string TargetName {
 get { return targetName_; }
 set { SetTargetName(value); }
 }
 public void SetTargetName(string value) { 
 hasTargetName = true;
 targetName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSourcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SourcePlayerId);
}
 if (HasTargetPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetPlayerId);
}
 if (HasRingId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RingId);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Result);
}
 if (HasTargetName) {
size += pb::CodedOutputStream.ComputeStringSize(5, TargetName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSourcePlayerId) {
output.WriteInt64(1, SourcePlayerId);
}
 
if (HasTargetPlayerId) {
output.WriteInt64(2, TargetPlayerId);
}
 
if (HasRingId) {
output.WriteInt32(3, RingId);
}
 
if (HasResult) {
output.WriteInt32(4, Result);
}
 
if (HasTargetName) {
output.WriteString(5, TargetName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCExpressLoveBack _inst = (GCExpressLoveBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SourcePlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TargetPlayerId = input.ReadInt64();
break;
}
   case  24: {
 _inst.RingId = input.ReadInt32();
break;
}
   case  32: {
 _inst.Result = input.ReadInt32();
break;
}
   case  42: {
 _inst.TargetName = input.ReadString();
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
public class GCMarryRingPower : PacketDistributed
{

public const int ringInfoFieldNumber = 1;
 private bool hasRingInfo;
 private RingInfo ringInfo_ =  new RingInfo();
 public bool HasRingInfo {
 get { return hasRingInfo; }
 }
 public RingInfo RingInfo {
 get { return ringInfo_; }
 set { SetRingInfo(value); }
 }
 public void SetRingInfo(RingInfo value) { 
 hasRingInfo = true;
 ringInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = RingInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)RingInfo.SerializedSize());
RingInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMarryRingPower _inst = (GCMarryRingPower) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RingInfo subBuilder =  new RingInfo();
 input.ReadMessage(subBuilder);
_inst.RingInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasRingInfo) {
if (!RingInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCMarrySts : PacketDistributed
{

public const int stsFieldNumber = 1;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

public const int sexFieldNumber = 2;
 private bool hasSex;
 private Int32 sex_ = 0;
 public bool HasSex {
 get { return hasSex; }
 }
 public Int32 Sex {
 get { return sex_; }
 set { SetSex(value); }
 }
 public void SetSex(Int32 value) { 
 hasSex = true;
 sex_ = value;
 }

public const int ringInfoFieldNumber = 3;
 private bool hasRingInfo;
 private RingInfo ringInfo_ =  new RingInfo();
 public bool HasRingInfo {
 get { return hasRingInfo; }
 }
 public RingInfo RingInfo {
 get { return ringInfo_; }
 set { SetRingInfo(value); }
 }
 public void SetRingInfo(RingInfo value) { 
 hasRingInfo = true;
 ringInfo_ = value;
 }

public const int arriveTimeFieldNumber = 4;
 private bool hasArriveTime;
 private Int64 arriveTime_ = 0;
 public bool HasArriveTime {
 get { return hasArriveTime; }
 }
 public Int64 ArriveTime {
 get { return arriveTime_; }
 set { SetArriveTime(value); }
 }
 public void SetArriveTime(Int64 value) { 
 hasArriveTime = true;
 arriveTime_ = value;
 }

public const int divorcePlayerIdFieldNumber = 5;
 private bool hasDivorcePlayerId;
 private Int64 divorcePlayerId_ = 0;
 public bool HasDivorcePlayerId {
 get { return hasDivorcePlayerId; }
 }
 public Int64 DivorcePlayerId {
 get { return divorcePlayerId_; }
 set { SetDivorcePlayerId(value); }
 }
 public void SetDivorcePlayerId(Int64 value) { 
 hasDivorcePlayerId = true;
 divorcePlayerId_ = value;
 }

public const int divorcePlayerNameFieldNumber = 6;
 private bool hasDivorcePlayerName;
 private string divorcePlayerName_ = "";
 public bool HasDivorcePlayerName {
 get { return hasDivorcePlayerName; }
 }
 public string DivorcePlayerName {
 get { return divorcePlayerName_; }
 set { SetDivorcePlayerName(value); }
 }
 public void SetDivorcePlayerName(string value) { 
 hasDivorcePlayerName = true;
 divorcePlayerName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sts);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sex);
}
{
int subsize = RingInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasArriveTime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, ArriveTime);
}
 if (HasDivorcePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(5, DivorcePlayerId);
}
 if (HasDivorcePlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(6, DivorcePlayerName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSts) {
output.WriteInt32(1, Sts);
}
 
if (HasSex) {
output.WriteInt32(2, Sex);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)RingInfo.SerializedSize());
RingInfo.WriteTo(output);

}
 
if (HasArriveTime) {
output.WriteInt64(4, ArriveTime);
}
 
if (HasDivorcePlayerId) {
output.WriteInt64(5, DivorcePlayerId);
}
 
if (HasDivorcePlayerName) {
output.WriteString(6, DivorcePlayerName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMarrySts _inst = (GCMarrySts) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sts = input.ReadInt32();
break;
}
   case  16: {
 _inst.Sex = input.ReadInt32();
break;
}
    case  26: {
RingInfo subBuilder =  new RingInfo();
 input.ReadMessage(subBuilder);
_inst.RingInfo = subBuilder;
break;
}
   case  32: {
 _inst.ArriveTime = input.ReadInt64();
break;
}
   case  40: {
 _inst.DivorcePlayerId = input.ReadInt64();
break;
}
   case  50: {
 _inst.DivorcePlayerName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasRingInfo) {
if (!RingInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSearchMarryInfo : PacketDistributed
{

public const int sidFieldNumber = 1;
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

public const int playerNameFieldNumber = 2;
 private bool hasPlayerName;
 private string playerName_ = "";
 public bool HasPlayerName {
 get { return hasPlayerName; }
 }
 public string PlayerName {
 get { return playerName_; }
 set { SetPlayerName(value); }
 }
 public void SetPlayerName(string value) { 
 hasPlayerName = true;
 playerName_ = value;
 }

public const int ringInfoFieldNumber = 3;
 private bool hasRingInfo;
 private RingInfo ringInfo_ =  new RingInfo();
 public bool HasRingInfo {
 get { return hasRingInfo; }
 }
 public RingInfo RingInfo {
 get { return ringInfo_; }
 set { SetRingInfo(value); }
 }
 public void SetRingInfo(RingInfo value) { 
 hasRingInfo = true;
 ringInfo_ = value;
 }

public const int changInfoFieldNumber = 4;
 private bool hasChangInfo;
 private ChangeEquipInfo changInfo_ =  new ChangeEquipInfo();
 public bool HasChangInfo {
 get { return hasChangInfo; }
 }
 public ChangeEquipInfo ChangInfo {
 get { return changInfo_; }
 set { SetChangInfo(value); }
 }
 public void SetChangInfo(ChangeEquipInfo value) { 
 hasChangInfo = true;
 changInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sid);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PlayerName);
}
{
int subsize = RingInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = ChangInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSid) {
output.WriteInt32(1, Sid);
}
 
if (HasPlayerName) {
output.WriteString(2, PlayerName);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)RingInfo.SerializedSize());
RingInfo.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ChangInfo.SerializedSize());
ChangInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSearchMarryInfo _inst = (GCSearchMarryInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  18: {
 _inst.PlayerName = input.ReadString();
break;
}
    case  26: {
RingInfo subBuilder =  new RingInfo();
 input.ReadMessage(subBuilder);
_inst.RingInfo = subBuilder;
break;
}
    case  34: {
ChangeEquipInfo subBuilder =  new ChangeEquipInfo();
 input.ReadMessage(subBuilder);
_inst.ChangInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasRingInfo) {
if (!RingInfo.IsInitialized()) return false;
}
  if (HasChangInfo) {
if (!ChangInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class MarryRank : PacketDistributed
{

public const int rankIdFieldNumber = 1;
 private bool hasRankId;
 private Int32 rankId_ = 0;
 public bool HasRankId {
 get { return hasRankId; }
 }
 public Int32 RankId {
 get { return rankId_; }
 set { SetRankId(value); }
 }
 public void SetRankId(Int32 value) { 
 hasRankId = true;
 rankId_ = value;
 }

public const int boyPlayerIdFieldNumber = 2;
 private bool hasBoyPlayerId;
 private Int64 boyPlayerId_ = 0;
 public bool HasBoyPlayerId {
 get { return hasBoyPlayerId; }
 }
 public Int64 BoyPlayerId {
 get { return boyPlayerId_; }
 set { SetBoyPlayerId(value); }
 }
 public void SetBoyPlayerId(Int64 value) { 
 hasBoyPlayerId = true;
 boyPlayerId_ = value;
 }

public const int boyNameFieldNumber = 3;
 private bool hasBoyName;
 private string boyName_ = "";
 public bool HasBoyName {
 get { return hasBoyName; }
 }
 public string BoyName {
 get { return boyName_; }
 set { SetBoyName(value); }
 }
 public void SetBoyName(string value) { 
 hasBoyName = true;
 boyName_ = value;
 }

public const int boyVipLvFieldNumber = 4;
 private bool hasBoyVipLv;
 private Int32 boyVipLv_ = 0;
 public bool HasBoyVipLv {
 get { return hasBoyVipLv; }
 }
 public Int32 BoyVipLv {
 get { return boyVipLv_; }
 set { SetBoyVipLv(value); }
 }
 public void SetBoyVipLv(Int32 value) { 
 hasBoyVipLv = true;
 boyVipLv_ = value;
 }

public const int girlPlayerIdFieldNumber = 5;
 private bool hasGirlPlayerId;
 private Int64 girlPlayerId_ = 0;
 public bool HasGirlPlayerId {
 get { return hasGirlPlayerId; }
 }
 public Int64 GirlPlayerId {
 get { return girlPlayerId_; }
 set { SetGirlPlayerId(value); }
 }
 public void SetGirlPlayerId(Int64 value) { 
 hasGirlPlayerId = true;
 girlPlayerId_ = value;
 }

public const int girlNameFieldNumber = 6;
 private bool hasGirlName;
 private string girlName_ = "";
 public bool HasGirlName {
 get { return hasGirlName; }
 }
 public string GirlName {
 get { return girlName_; }
 set { SetGirlName(value); }
 }
 public void SetGirlName(string value) { 
 hasGirlName = true;
 girlName_ = value;
 }

public const int girlVipLvFieldNumber = 7;
 private bool hasGirlVipLv;
 private Int32 girlVipLv_ = 0;
 public bool HasGirlVipLv {
 get { return hasGirlVipLv; }
 }
 public Int32 GirlVipLv {
 get { return girlVipLv_; }
 set { SetGirlVipLv(value); }
 }
 public void SetGirlVipLv(Int32 value) { 
 hasGirlVipLv = true;
 girlVipLv_ = value;
 }

public const int totalLoveNumFieldNumber = 8;
 private bool hasTotalLoveNum;
 private Int32 totalLoveNum_ = 0;
 public bool HasTotalLoveNum {
 get { return hasTotalLoveNum; }
 }
 public Int32 TotalLoveNum {
 get { return totalLoveNum_; }
 set { SetTotalLoveNum(value); }
 }
 public void SetTotalLoveNum(Int32 value) { 
 hasTotalLoveNum = true;
 totalLoveNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRankId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RankId);
}
 if (HasBoyPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, BoyPlayerId);
}
 if (HasBoyName) {
size += pb::CodedOutputStream.ComputeStringSize(3, BoyName);
}
 if (HasBoyVipLv) {
size += pb::CodedOutputStream.ComputeInt32Size(4, BoyVipLv);
}
 if (HasGirlPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(5, GirlPlayerId);
}
 if (HasGirlName) {
size += pb::CodedOutputStream.ComputeStringSize(6, GirlName);
}
 if (HasGirlVipLv) {
size += pb::CodedOutputStream.ComputeInt32Size(7, GirlVipLv);
}
 if (HasTotalLoveNum) {
size += pb::CodedOutputStream.ComputeInt32Size(8, TotalLoveNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRankId) {
output.WriteInt32(1, RankId);
}
 
if (HasBoyPlayerId) {
output.WriteInt64(2, BoyPlayerId);
}
 
if (HasBoyName) {
output.WriteString(3, BoyName);
}
 
if (HasBoyVipLv) {
output.WriteInt32(4, BoyVipLv);
}
 
if (HasGirlPlayerId) {
output.WriteInt64(5, GirlPlayerId);
}
 
if (HasGirlName) {
output.WriteString(6, GirlName);
}
 
if (HasGirlVipLv) {
output.WriteInt32(7, GirlVipLv);
}
 
if (HasTotalLoveNum) {
output.WriteInt32(8, TotalLoveNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MarryRank _inst = (MarryRank) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RankId = input.ReadInt32();
break;
}
   case  16: {
 _inst.BoyPlayerId = input.ReadInt64();
break;
}
   case  26: {
 _inst.BoyName = input.ReadString();
break;
}
   case  32: {
 _inst.BoyVipLv = input.ReadInt32();
break;
}
   case  40: {
 _inst.GirlPlayerId = input.ReadInt64();
break;
}
   case  50: {
 _inst.GirlName = input.ReadString();
break;
}
   case  56: {
 _inst.GirlVipLv = input.ReadInt32();
break;
}
   case  64: {
 _inst.TotalLoveNum = input.ReadInt32();
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
public class RingInfo : PacketDistributed
{

public const int ringIDFieldNumber = 1;
 private bool hasRingID;
 private Int32 ringID_ = 0;
 public bool HasRingID {
 get { return hasRingID; }
 }
 public Int32 RingID {
 get { return ringID_; }
 set { SetRingID(value); }
 }
 public void SetRingID(Int32 value) { 
 hasRingID = true;
 ringID_ = value;
 }

public const int levelFieldNumber = 2;
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

public const int loveNumFieldNumber = 3;
 private bool hasLoveNum;
 private Int32 loveNum_ = 0;
 public bool HasLoveNum {
 get { return hasLoveNum; }
 }
 public Int32 LoveNum {
 get { return loveNum_; }
 set { SetLoveNum(value); }
 }
 public void SetLoveNum(Int32 value) { 
 hasLoveNum = true;
 loveNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRingID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RingID);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Level);
}
 if (HasLoveNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, LoveNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRingID) {
output.WriteInt32(1, RingID);
}
 
if (HasLevel) {
output.WriteInt32(2, Level);
}
 
if (HasLoveNum) {
output.WriteInt32(3, LoveNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RingInfo _inst = (RingInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RingID = input.ReadInt32();
break;
}
   case  16: {
 _inst.Level = input.ReadInt32();
break;
}
   case  24: {
 _inst.LoveNum = input.ReadInt32();
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
