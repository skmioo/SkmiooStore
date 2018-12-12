//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetTodayPvpPrestige : PacketDistributed
{

public const int requestTypeFieldNumber = 1;
 private bool hasRequestType;
 private Int32 requestType_ = 0;
 public bool HasRequestType {
 get { return hasRequestType; }
 }
 public Int32 RequestType {
 get { return requestType_; }
 set { SetRequestType(value); }
 }
 public void SetRequestType(Int32 value) { 
 hasRequestType = true;
 requestType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRequestType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RequestType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRequestType) {
output.WriteInt32(1, RequestType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetTodayPvpPrestige _inst = (CGGetTodayPvpPrestige) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RequestType = input.ReadInt32();
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
public class GCGetTodayPvpPrestige : PacketDistributed
{

public const int prestigeFieldNumber = 1;
 private bool hasPrestige;
 private Int32 prestige_ = 0;
 public bool HasPrestige {
 get { return hasPrestige; }
 }
 public Int32 Prestige {
 get { return prestige_; }
 set { SetPrestige(value); }
 }
 public void SetPrestige(Int32 value) { 
 hasPrestige = true;
 prestige_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPrestige) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Prestige);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPrestige) {
output.WriteInt32(1, Prestige);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetTodayPvpPrestige _inst = (GCGetTodayPvpPrestige) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Prestige = input.ReadInt32();
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
