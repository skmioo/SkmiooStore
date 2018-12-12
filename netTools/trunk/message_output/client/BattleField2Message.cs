//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBattleField2 : PacketDistributed
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

public const int stateFieldNumber = 2;
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

public const int itemIdFieldNumber = 3;
 private bool hasItemId;
 private Int32 itemId_ = 0;
 public bool HasItemId {
 get { return hasItemId; }
 }
 public Int32 ItemId {
 get { return itemId_; }
 set { SetItemId(value); }
 }
 public void SetItemId(Int32 value) { 
 hasItemId = true;
 itemId_ = value;
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
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(2, State);
}
 if (HasItemId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ItemId);
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
 
if (HasState) {
output.WriteInt32(2, State);
}
 
if (HasItemId) {
output.WriteInt32(3, ItemId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBattleField2 _inst = (CGBattleField2) _base;
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
 _inst.State = input.ReadInt32();
break;
}
   case  24: {
 _inst.ItemId = input.ReadInt32();
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
public class GCBattleField2 : PacketDistributed
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

public const int timeFieldNumber = 2;
 private bool hasTime;
 private Int32 time_ = 0;
 public bool HasTime {
 get { return hasTime; }
 }
 public Int32 Time {
 get { return time_; }
 set { SetTime(value); }
 }
 public void SetTime(Int32 value) { 
 hasTime = true;
 time_ = value;
 }

public const int stateFieldNumber = 3;
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

public const int paramFieldNumber = 4;
 private bool hasParam;
 private Int32 param_ = 0;
 public bool HasParam {
 get { return hasParam; }
 }
 public Int32 Param {
 get { return param_; }
 set { SetParam(value); }
 }
 public void SetParam(Int32 value) { 
 hasParam = true;
 param_ = value;
 }

public const int killPuidFieldNumber = 5;
 private bool hasKillPuid;
 private Int64 killPuid_ = 0;
 public bool HasKillPuid {
 get { return hasKillPuid; }
 }
 public Int64 KillPuid {
 get { return killPuid_; }
 set { SetKillPuid(value); }
 }
 public void SetKillPuid(Int64 value) { 
 hasKillPuid = true;
 killPuid_ = value;
 }

public const int diePuidFieldNumber = 6;
 private bool hasDiePuid;
 private Int64 diePuid_ = 0;
 public bool HasDiePuid {
 get { return hasDiePuid; }
 }
 public Int64 DiePuid {
 get { return diePuid_; }
 set { SetDiePuid(value); }
 }
 public void SetDiePuid(Int64 value) { 
 hasDiePuid = true;
 diePuid_ = value;
 }

public const int resultFieldNumber = 7;
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

public const int selfRecordFieldNumber = 8;
 private pbc::PopsicleList<Int32> selfRecord_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> selfRecordList {
 get { return pbc::Lists.AsReadOnly(selfRecord_); }
 }
 
 public int selfRecordCount {
 get { return selfRecord_.Count; }
 }
 
public Int32 GetSelfRecord(int index) {
 return selfRecord_[index];
 }
 public void AddSelfRecord(Int32 value) {
 selfRecord_.Add(value);
 }

public const int fightRecordFieldNumber = 9;
 private pbc::PopsicleList<EntryLongAry> fightRecord_ = new pbc::PopsicleList<EntryLongAry>();
 public scg::IList<EntryLongAry> fightRecordList {
 get { return pbc::Lists.AsReadOnly(fightRecord_); }
 }
 
 public int fightRecordCount {
 get { return fightRecord_.Count; }
 }
 
public EntryLongAry GetFightRecord(int index) {
 return fightRecord_[index];
 }
 public void AddFightRecord(EntryLongAry value) {
 fightRecord_.Add(value);
 }

public const int selfIndexFieldNumber = 10;
 private bool hasSelfIndex;
 private Int32 selfIndex_ = 0;
 public bool HasSelfIndex {
 get { return hasSelfIndex; }
 }
 public Int32 SelfIndex {
 get { return selfIndex_; }
 set { SetSelfIndex(value); }
 }
 public void SetSelfIndex(Int32 value) { 
 hasSelfIndex = true;
 selfIndex_ = value;
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
 if (HasTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Time);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(3, State);
}
 if (HasParam) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Param);
}
 if (HasKillPuid) {
size += pb::CodedOutputStream.ComputeInt64Size(5, KillPuid);
}
 if (HasDiePuid) {
size += pb::CodedOutputStream.ComputeInt64Size(6, DiePuid);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Result);
}
{
int dataSize = 0;
foreach (Int32 element in selfRecordList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * selfRecord_.Count;
}
{
foreach (EntryLongAry element in fightRecordList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSelfIndex) {
size += pb::CodedOutputStream.ComputeInt32Size(10, SelfIndex);
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
 
if (HasTime) {
output.WriteInt32(2, Time);
}
 
if (HasState) {
output.WriteInt32(3, State);
}
 
if (HasParam) {
output.WriteInt32(4, Param);
}
 
if (HasKillPuid) {
output.WriteInt64(5, KillPuid);
}
 
if (HasDiePuid) {
output.WriteInt64(6, DiePuid);
}
 
if (HasResult) {
output.WriteInt32(7, Result);
}
{
if (selfRecord_.Count > 0) {
foreach (Int32 element in selfRecordList) {
output.WriteInt32(8,element);
}
}

}

do{
foreach (EntryLongAry element in fightRecordList) {
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSelfIndex) {
output.WriteInt32(10, SelfIndex);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBattleField2 _inst = (GCBattleField2) _base;
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
 _inst.Time = input.ReadInt32();
break;
}
   case  24: {
 _inst.State = input.ReadInt32();
break;
}
   case  32: {
 _inst.Param = input.ReadInt32();
break;
}
   case  40: {
 _inst.KillPuid = input.ReadInt64();
break;
}
   case  48: {
 _inst.DiePuid = input.ReadInt64();
break;
}
   case  56: {
 _inst.Result = input.ReadInt32();
break;
}
   case  64: {
 _inst.AddSelfRecord(input.ReadInt32());
break;
}
    case  74: {
EntryLongAry subBuilder =  new EntryLongAry();
input.ReadMessage(subBuilder);
_inst.AddFightRecord(subBuilder);
break;
}
   case  80: {
 _inst.SelfIndex = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EntryLongAry element in fightRecordList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
