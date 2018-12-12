//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class GCWildBossInfo : PacketDistributed
{

public const int stateFieldNumber = 1;
 private bool hasState;
 private Int32 state_ = 0;
 public bool HasState {
 get { return hasState; }
 }
 public Int32 State {
 get { return state_; }
 set { SetState(value); }
 }
 public void SetState(Int32 value) { 
 hasState = true;
 state_ = value;
 }

public const int WildBossKillInfoFieldNumber = 2;
 private pbc::PopsicleList<WildBossInfo> WildBossKillInfo_ = new pbc::PopsicleList<WildBossInfo>();
 public scg::IList<WildBossInfo> WildBossKillInfoList {
 get { return pbc::Lists.AsReadOnly(WildBossKillInfo_); }
 }
 
 public int WildBossKillInfoCount {
 get { return WildBossKillInfo_.Count; }
 }
 
public WildBossInfo GetWildBossKillInfo(int index) {
 return WildBossKillInfo_[index];
 }
 public void AddWildBossKillInfo(WildBossInfo value) {
 WildBossKillInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(1, State);
}
{
foreach (WildBossInfo element in WildBossKillInfoList) {
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
  
if (HasState) {
output.WriteInt32(1, State);
}

do{
foreach (WildBossInfo element in WildBossKillInfoList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCWildBossInfo _inst = (GCWildBossInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.State = input.ReadInt32();
break;
}
    case  18: {
WildBossInfo subBuilder =  new WildBossInfo();
input.ReadMessage(subBuilder);
_inst.AddWildBossKillInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WildBossInfo element in WildBossKillInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class WildBossInfo : PacketDistributed
{

public const int idFieldNumber = 1;
 private bool hasId;
 private Int32 id_ = 0;
 public bool HasId {
 get { return hasId; }
 }
 public Int32 Id {
 get { return id_; }
 set { SetId(value); }
 }
 public void SetId(Int32 value) { 
 hasId = true;
 id_ = value;
 }

public const int gangNameFieldNumber = 2;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

public const int statusFieldNumber = 3;
 private bool hasStatus;
 private Int32 status_ = 0;
 public bool HasStatus {
 get { return hasStatus; }
 }
 public Int32 Status {
 get { return status_; }
 set { SetStatus(value); }
 }
 public void SetStatus(Int32 value) { 
 hasStatus = true;
 status_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(2, GangName);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Status);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasGangName) {
output.WriteString(2, GangName);
}
 
if (HasStatus) {
output.WriteInt32(3, Status);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 WildBossInfo _inst = (WildBossInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Id = input.ReadInt32();
break;
}
   case  18: {
 _inst.GangName = input.ReadString();
break;
}
   case  24: {
 _inst.Status = input.ReadInt32();
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
