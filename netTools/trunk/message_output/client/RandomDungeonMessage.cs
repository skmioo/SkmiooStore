//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGRandomDungeon : PacketDistributed
{

public const int guidFieldNumber = 1;
 private bool hasGuid;
 private Int64 guid_ = 0;
 public bool HasGuid {
 get { return hasGuid; }
 }
 public Int64 Guid {
 get { return guid_; }
 set { SetGuid(value); }
 }
 public void SetGuid(Int64 value) { 
 hasGuid = true;
 guid_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Guid);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGuid) {
output.WriteInt64(1, Guid);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGRandomDungeon _inst = (CGRandomDungeon) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Guid = input.ReadInt64();
break;
}
   case  16: {
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
public class GCRandomDungeon : PacketDistributed
{

public const int resultCodeFieldNumber = 1;
 private bool hasResultCode;
 private Int32 resultCode_ = 0;
 public bool HasResultCode {
 get { return hasResultCode; }
 }
 public Int32 ResultCode {
 get { return resultCode_; }
 set { SetResultCode(value); }
 }
 public void SetResultCode(Int32 value) { 
 hasResultCode = true;
 resultCode_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResultCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ResultCode);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResultCode) {
output.WriteInt32(1, ResultCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRandomDungeon _inst = (GCRandomDungeon) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ResultCode = input.ReadInt32();
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
