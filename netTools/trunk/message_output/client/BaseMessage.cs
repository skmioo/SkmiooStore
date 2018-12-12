//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGheartbeatClientSend : PacketDistributed
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
 CGheartbeatClientSend _inst = (CGheartbeatClientSend) _base;
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
public class GCCloseOldSession : PacketDistributed
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
 GCCloseOldSession _inst = (GCCloseOldSession) _base;
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
public class GCErrorBack : PacketDistributed
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

public const int revMsgIdFieldNumber = 2;
 private bool hasRevMsgId;
 private Int32 revMsgId_ = 0;
 public bool HasRevMsgId {
 get { return hasRevMsgId; }
 }
 public Int32 RevMsgId {
 get { return revMsgId_; }
 set { SetRevMsgId(value); }
 }
 public void SetRevMsgId(Int32 value) { 
 hasRevMsgId = true;
 revMsgId_ = value;
 }

public const int parmFieldNumber = 3;
 private bool hasParm;
 private string parm_ = "";
 public bool HasParm {
 get { return hasParm; }
 }
 public string Parm {
 get { return parm_; }
 set { SetParm(value); }
 }
 public void SetParm(string value) { 
 hasParm = true;
 parm_ = value;
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
 if (HasRevMsgId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RevMsgId);
}
 if (HasParm) {
size += pb::CodedOutputStream.ComputeStringSize(3, Parm);
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
 
if (HasRevMsgId) {
output.WriteInt32(2, RevMsgId);
}
 
if (HasParm) {
output.WriteString(3, Parm);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCErrorBack _inst = (GCErrorBack) _base;
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
 _inst.RevMsgId = input.ReadInt32();
break;
}
   case  26: {
 _inst.Parm = input.ReadString();
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
public class GCLogMsg : PacketDistributed
{

public const int funcFieldNumber = 1;
 private bool hasFunc;
 private string func_ = "";
 public bool HasFunc {
 get { return hasFunc; }
 }
 public string Func {
 get { return func_; }
 set { SetFunc(value); }
 }
 public void SetFunc(string value) { 
 hasFunc = true;
 func_ = value;
 }

public const int contextFieldNumber = 2;
 private bool hasContext;
 private string context_ = "";
 public bool HasContext {
 get { return hasContext; }
 }
 public string Context {
 get { return context_; }
 set { SetContext(value); }
 }
 public void SetContext(string value) { 
 hasContext = true;
 context_ = value;
 }

public const int typeFieldNumber = 3;
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
  if (HasFunc) {
size += pb::CodedOutputStream.ComputeStringSize(1, Func);
}
 if (HasContext) {
size += pb::CodedOutputStream.ComputeStringSize(2, Context);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFunc) {
output.WriteString(1, Func);
}
 
if (HasContext) {
output.WriteString(2, Context);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLogMsg _inst = (GCLogMsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Func = input.ReadString();
break;
}
   case  18: {
 _inst.Context = input.ReadString();
break;
}
   case  24: {
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
public class GCServerMsg : PacketDistributed
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
 GCServerMsg _inst = (GCServerMsg) _base;
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
public class GCheartbeatServerBack : PacketDistributed
{

public const int serverTimeFieldNumber = 1;
 private bool hasServerTime;
 private Int64 serverTime_ = 0;
 public bool HasServerTime {
 get { return hasServerTime; }
 }
 public Int64 ServerTime {
 get { return serverTime_; }
 set { SetServerTime(value); }
 }
 public void SetServerTime(Int64 value) { 
 hasServerTime = true;
 serverTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasServerTime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ServerTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasServerTime) {
output.WriteInt64(1, ServerTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCheartbeatServerBack _inst = (GCheartbeatServerBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ServerTime = input.ReadInt64();
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
