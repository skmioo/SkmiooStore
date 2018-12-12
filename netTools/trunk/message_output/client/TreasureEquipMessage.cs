//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGOnOrOffTreasureEquip : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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

public const int posFieldNumber = 3;
 private bool hasPos;
 private Int32 pos_ = 0;
 public bool HasPos {
 get { return hasPos; }
 }
 public Int32 Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Int32 value) { 
 hasPos = true;
 pos_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasPos) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Pos);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasPos) {
output.WriteInt32(3, Pos);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGOnOrOffTreasureEquip _inst = (CGOnOrOffTreasureEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Pos = input.ReadInt32();
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
public class CGRandomTreasureEquip : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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

public const int costTypeFieldNumber = 3;
 private bool hasCostType;
 private Int32 costType_ = 0;
 public bool HasCostType {
 get { return hasCostType; }
 }
 public Int32 CostType {
 get { return costType_; }
 set { SetCostType(value); }
 }
 public void SetCostType(Int32 value) { 
 hasCostType = true;
 costType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasCostType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, CostType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasCostType) {
output.WriteInt32(3, CostType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGRandomTreasureEquip _inst = (CGRandomTreasureEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.CostType = input.ReadInt32();
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
public class CGSaveTreasureEquip : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSaveTreasureEquip _inst = (CGSaveTreasureEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
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
public class GCAllOnTreasureEquips : PacketDistributed
{

public const int equipsFieldNumber = 1;
 private pbc::PopsicleList<TreasureEquipData> equips_ = new pbc::PopsicleList<TreasureEquipData>();
 public scg::IList<TreasureEquipData> equipsList {
 get { return pbc::Lists.AsReadOnly(equips_); }
 }
 
 public int equipsCount {
 get { return equips_.Count; }
 }
 
public TreasureEquipData GetEquips(int index) {
 return equips_[index];
 }
 public void AddEquips(TreasureEquipData value) {
 equips_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (TreasureEquipData element in equipsList) {
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
foreach (TreasureEquipData element in equipsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAllOnTreasureEquips _inst = (GCAllOnTreasureEquips) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TreasureEquipData subBuilder =  new TreasureEquipData();
input.ReadMessage(subBuilder);
_inst.AddEquips(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TreasureEquipData element in equipsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOnOrOffTreasureEquip : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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

public const int stsFieldNumber = 3;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasSts) {
output.WriteInt32(3, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOnOrOffTreasureEquip _inst = (GCOnOrOffTreasureEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Sts = input.ReadInt32();
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
public class GCRandomTreasureEquip : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
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

public const int dataFieldNumber = 3;
 private bool hasData;
 private TreasureEquipData data_ =  new TreasureEquipData();
 public bool HasData {
 get { return hasData; }
 }
 public TreasureEquipData Data {
 get { return data_; }
 set { SetData(value); }
 }
 public void SetData(TreasureEquipData value) { 
 hasData = true;
 data_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
{
int subsize = Data.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Data.SerializedSize());
Data.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRandomTreasureEquip _inst = (GCRandomTreasureEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
    case  26: {
TreasureEquipData subBuilder =  new TreasureEquipData();
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
public class GCSaveTreasureEquip : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int dataFieldNumber = 2;
 private bool hasData;
 private TreasureEquipData data_ =  new TreasureEquipData();
 public bool HasData {
 get { return hasData; }
 }
 public TreasureEquipData Data {
 get { return data_; }
 set { SetData(value); }
 }
 public void SetData(TreasureEquipData value) { 
 hasData = true;
 data_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
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
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Data.SerializedSize());
Data.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSaveTreasureEquip _inst = (GCSaveTreasureEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
    case  18: {
TreasureEquipData subBuilder =  new TreasureEquipData();
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
public class TreasureEquipData : PacketDistributed
{

public const int pidFieldNumber = 1;
 private bool hasPid;
 private Int64 pid_ = 0;
 public bool HasPid {
 get { return hasPid; }
 }
 public Int64 Pid {
 get { return pid_; }
 set { SetPid(value); }
 }
 public void SetPid(Int64 value) { 
 hasPid = true;
 pid_ = value;
 }

public const int sidFieldNumber = 2;
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

public const int baseValueFieldNumber = 3;
 private bool hasBaseValue;
 private string baseValue_ = "";
 public bool HasBaseValue {
 get { return hasBaseValue; }
 }
 public string BaseValue {
 get { return baseValue_; }
 set { SetBaseValue(value); }
 }
 public void SetBaseValue(string value) { 
 hasBaseValue = true;
 baseValue_ = value;
 }

public const int battleNumFieldNumber = 4;
 private bool hasBattleNum;
 private Int32 battleNum_ = 0;
 public bool HasBattleNum {
 get { return hasBattleNum; }
 }
 public Int32 BattleNum {
 get { return battleNum_; }
 set { SetBattleNum(value); }
 }
 public void SetBattleNum(Int32 value) { 
 hasBattleNum = true;
 battleNum_ = value;
 }

public const int vocalInfosFieldNumber = 5;
 private pbc::PopsicleList<VocabularyInfo> vocalInfos_ = new pbc::PopsicleList<VocabularyInfo>();
 public scg::IList<VocabularyInfo> vocalInfosList {
 get { return pbc::Lists.AsReadOnly(vocalInfos_); }
 }
 
 public int vocalInfosCount {
 get { return vocalInfos_.Count; }
 }
 
public VocabularyInfo GetVocalInfos(int index) {
 return vocalInfos_[index];
 }
 public void AddVocalInfos(VocabularyInfo value) {
 vocalInfos_.Add(value);
 }

public const int tempVocalInfosFieldNumber = 6;
 private pbc::PopsicleList<VocabularyInfo> tempVocalInfos_ = new pbc::PopsicleList<VocabularyInfo>();
 public scg::IList<VocabularyInfo> tempVocalInfosList {
 get { return pbc::Lists.AsReadOnly(tempVocalInfos_); }
 }
 
 public int tempVocalInfosCount {
 get { return tempVocalInfos_.Count; }
 }
 
public VocabularyInfo GetTempVocalInfos(int index) {
 return tempVocalInfos_[index];
 }
 public void AddTempVocalInfos(VocabularyInfo value) {
 tempVocalInfos_.Add(value);
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

public const int posFieldNumber = 8;
 private bool hasPos;
 private Int32 pos_ = 0;
 public bool HasPos {
 get { return hasPos; }
 }
 public Int32 Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Int32 value) { 
 hasPos = true;
 pos_ = value;
 }

public const int bindFieldNumber = 9;
 private bool hasBind;
 private Int32 bind_ = 0;
 public bool HasBind {
 get { return hasBind; }
 }
 public Int32 Bind {
 get { return bind_; }
 set { SetBind(value); }
 }
 public void SetBind(Int32 value) { 
 hasBind = true;
 bind_ = value;
 }

public const int oldVocalBattleNumberFieldNumber = 10;
 private bool hasOldVocalBattleNumber;
 private Int32 oldVocalBattleNumber_ = 0;
 public bool HasOldVocalBattleNumber {
 get { return hasOldVocalBattleNumber; }
 }
 public Int32 OldVocalBattleNumber {
 get { return oldVocalBattleNumber_; }
 set { SetOldVocalBattleNumber(value); }
 }
 public void SetOldVocalBattleNumber(Int32 value) { 
 hasOldVocalBattleNumber = true;
 oldVocalBattleNumber_ = value;
 }

public const int newVocalBattleNumberFieldNumber = 11;
 private bool hasNewVocalBattleNumber;
 private Int32 newVocalBattleNumber_ = 0;
 public bool HasNewVocalBattleNumber {
 get { return hasNewVocalBattleNumber; }
 }
 public Int32 NewVocalBattleNumber {
 get { return newVocalBattleNumber_; }
 set { SetNewVocalBattleNumber(value); }
 }
 public void SetNewVocalBattleNumber(Int32 value) { 
 hasNewVocalBattleNumber = true;
 newVocalBattleNumber_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
 if (HasBaseValue) {
size += pb::CodedOutputStream.ComputeStringSize(3, BaseValue);
}
 if (HasBattleNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, BattleNum);
}
{
foreach (VocabularyInfo element in vocalInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (VocabularyInfo element in tempVocalInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSorce) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Sorce);
}
 if (HasPos) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Pos);
}
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Bind);
}
 if (HasOldVocalBattleNumber) {
size += pb::CodedOutputStream.ComputeInt32Size(10, OldVocalBattleNumber);
}
 if (HasNewVocalBattleNumber) {
size += pb::CodedOutputStream.ComputeInt32Size(11, NewVocalBattleNumber);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPid) {
output.WriteInt64(1, Pid);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
 
if (HasBaseValue) {
output.WriteString(3, BaseValue);
}
 
if (HasBattleNum) {
output.WriteInt32(4, BattleNum);
}

do{
foreach (VocabularyInfo element in vocalInfosList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (VocabularyInfo element in tempVocalInfosList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSorce) {
output.WriteInt32(7, Sorce);
}
 
if (HasPos) {
output.WriteInt32(8, Pos);
}
 
if (HasBind) {
output.WriteInt32(9, Bind);
}
 
if (HasOldVocalBattleNumber) {
output.WriteInt32(10, OldVocalBattleNumber);
}
 
if (HasNewVocalBattleNumber) {
output.WriteInt32(11, NewVocalBattleNumber);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TreasureEquipData _inst = (TreasureEquipData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  26: {
 _inst.BaseValue = input.ReadString();
break;
}
   case  32: {
 _inst.BattleNum = input.ReadInt32();
break;
}
    case  42: {
VocabularyInfo subBuilder =  new VocabularyInfo();
input.ReadMessage(subBuilder);
_inst.AddVocalInfos(subBuilder);
break;
}
    case  50: {
VocabularyInfo subBuilder =  new VocabularyInfo();
input.ReadMessage(subBuilder);
_inst.AddTempVocalInfos(subBuilder);
break;
}
   case  56: {
 _inst.Sorce = input.ReadInt32();
break;
}
   case  64: {
 _inst.Pos = input.ReadInt32();
break;
}
   case  72: {
 _inst.Bind = input.ReadInt32();
break;
}
   case  80: {
 _inst.OldVocalBattleNumber = input.ReadInt32();
break;
}
   case  88: {
 _inst.NewVocalBattleNumber = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (VocabularyInfo element in vocalInfosList) {
if (!element.IsInitialized()) return false;
}
foreach (VocabularyInfo element in tempVocalInfosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class VocabularyInfo : PacketDistributed
{

public const int tidFieldNumber = 1;
 private bool hasTid;
 private Int32 tid_ = 0;
 public bool HasTid {
 get { return hasTid; }
 }
 public Int32 Tid {
 get { return tid_; }
 set { SetTid(value); }
 }
 public void SetTid(Int32 value) { 
 hasTid = true;
 tid_ = value;
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

public const int valueFieldNumber = 3;
 private bool hasValue;
 private string value_ = "";
 public bool HasValue {
 get { return hasValue; }
 }
 public string Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(string value) { 
 hasValue = true;
 value_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Tid);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeStringSize(3, Value);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTid) {
output.WriteInt32(1, Tid);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasValue) {
output.WriteString(3, Value);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 VocabularyInfo _inst = (VocabularyInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Tid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  26: {
 _inst.Value = input.ReadString();
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
