//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGMuseumOperate : PacketDistributed
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
 CGMuseumOperate _inst = (CGMuseumOperate) _base;
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
public class GCMuseumResult : PacketDistributed
{

public const int errorCodeFieldNumber = 1;
 private bool hasErrorCode;
 private Int32 errorCode_ = 0;
 public bool HasErrorCode {
 get { return hasErrorCode; }
 }
 public Int32 ErrorCode {
 get { return errorCode_; }
 set { SetErrorCode(value); }
 }
 public void SetErrorCode(Int32 value) { 
 hasErrorCode = true;
 errorCode_ = value;
 }

public const int currentIDFieldNumber = 2;
 private bool hasCurrentID;
 private Int32 currentID_ = 0;
 public bool HasCurrentID {
 get { return hasCurrentID; }
 }
 public Int32 CurrentID {
 get { return currentID_; }
 set { SetCurrentID(value); }
 }
 public void SetCurrentID(Int32 value) { 
 hasCurrentID = true;
 currentID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ErrorCode);
}
 if (HasCurrentID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CurrentID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasErrorCode) {
output.WriteInt32(1, ErrorCode);
}
 
if (HasCurrentID) {
output.WriteInt32(2, CurrentID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMuseumResult _inst = (GCMuseumResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ErrorCode = input.ReadInt32();
break;
}
   case  16: {
 _inst.CurrentID = input.ReadInt32();
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
