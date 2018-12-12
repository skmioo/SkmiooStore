//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGLegacy : PacketDistributed
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

public const int legacyIdFieldNumber = 2;
 private bool hasLegacyId;
 private Int32 legacyId_ = 0;
 public bool HasLegacyId {
 get { return hasLegacyId; }
 }
 public Int32 LegacyId {
 get { return legacyId_; }
 set { SetLegacyId(value); }
 }
 public void SetLegacyId(Int32 value) { 
 hasLegacyId = true;
 legacyId_ = value;
 }

public const int listLegacyIdFieldNumber = 3;
 private pbc::PopsicleList<Int32> listLegacyId_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> listLegacyIdList {
 get { return pbc::Lists.AsReadOnly(listLegacyId_); }
 }
 
 public int listLegacyIdCount {
 get { return listLegacyId_.Count; }
 }
 
public Int32 GetListLegacyId(int index) {
 return listLegacyId_[index];
 }
 public void AddListLegacyId(Int32 value) {
 listLegacyId_.Add(value);
 }

public const int flagFieldNumber = 4;
 private bool hasFlag;
 private Int32 flag_ = 0;
 public bool HasFlag {
 get { return hasFlag; }
 }
 public Int32 Flag {
 get { return flag_; }
 set { SetFlag(value); }
 }
 public void SetFlag(Int32 value) { 
 hasFlag = true;
 flag_ = value;
 }

public const int stateFieldNumber = 5;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasLegacyId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LegacyId);
}
{
int dataSize = 0;
foreach (Int32 element in listLegacyIdList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * listLegacyId_.Count;
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Flag);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(5, State);
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
 
if (HasLegacyId) {
output.WriteInt32(2, LegacyId);
}
{
if (listLegacyId_.Count > 0) {
foreach (Int32 element in listLegacyIdList) {
output.WriteInt32(3,element);
}
}

}
 
if (HasFlag) {
output.WriteInt32(4, Flag);
}
 
if (HasState) {
output.WriteInt32(5, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLegacy _inst = (CGLegacy) _base;
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
 _inst.LegacyId = input.ReadInt32();
break;
}
   case  24: {
 _inst.AddListLegacyId(input.ReadInt32());
break;
}
   case  32: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  40: {
 _inst.State = input.ReadInt32();
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
public class CGLegacyBuyNum : PacketDistributed
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
 CGLegacyBuyNum _inst = (CGLegacyBuyNum) _base;
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
public class GCLegacy : PacketDistributed
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

public const int fightValueFieldNumber = 2;
 private bool hasFightValue;
 private Int32 fightValue_ = 0;
 public bool HasFightValue {
 get { return hasFightValue; }
 }
 public Int32 FightValue {
 get { return fightValue_; }
 set { SetFightValue(value); }
 }
 public void SetFightValue(Int32 value) { 
 hasFightValue = true;
 fightValue_ = value;
 }

public const int listOnBodyFieldNumber = 3;
 private pbc::PopsicleList<LegacyData> listOnBody_ = new pbc::PopsicleList<LegacyData>();
 public scg::IList<LegacyData> listOnBodyList {
 get { return pbc::Lists.AsReadOnly(listOnBody_); }
 }
 
 public int listOnBodyCount {
 get { return listOnBody_.Count; }
 }
 
public LegacyData GetListOnBody(int index) {
 return listOnBody_[index];
 }
 public void AddListOnBody(LegacyData value) {
 listOnBody_.Add(value);
 }

public const int listInBagFieldNumber = 4;
 private pbc::PopsicleList<LegacyData> listInBag_ = new pbc::PopsicleList<LegacyData>();
 public scg::IList<LegacyData> listInBagList {
 get { return pbc::Lists.AsReadOnly(listInBag_); }
 }
 
 public int listInBagCount {
 get { return listInBag_.Count; }
 }
 
public LegacyData GetListInBag(int index) {
 return listInBag_[index];
 }
 public void AddListInBag(LegacyData value) {
 listInBag_.Add(value);
 }

public const int resultFieldNumber = 5;
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

public const int legacyFieldNumber = 6;
 private bool hasLegacy;
 private LegacyData legacy_ =  new LegacyData();
 public bool HasLegacy {
 get { return hasLegacy; }
 }
 public LegacyData Legacy {
 get { return legacy_; }
 set { SetLegacy(value); }
 }
 public void SetLegacy(LegacyData value) { 
 hasLegacy = true;
 legacy_ = value;
 }

public const int listInDepotFieldNumber = 7;
 private pbc::PopsicleList<LegacyData> listInDepot_ = new pbc::PopsicleList<LegacyData>();
 public scg::IList<LegacyData> listInDepotList {
 get { return pbc::Lists.AsReadOnly(listInDepot_); }
 }
 
 public int listInDepotCount {
 get { return listInDepot_.Count; }
 }
 
public LegacyData GetListInDepot(int index) {
 return listInDepot_[index];
 }
 public void AddListInDepot(LegacyData value) {
 listInDepot_.Add(value);
 }

public const int drawIdFieldNumber = 8;
 private bool hasDrawId;
 private Int32 drawId_ = 0;
 public bool HasDrawId {
 get { return hasDrawId; }
 }
 public Int32 DrawId {
 get { return drawId_; }
 set { SetDrawId(value); }
 }
 public void SetDrawId(Int32 value) { 
 hasDrawId = true;
 drawId_ = value;
 }

public const int haveMoneyNumFieldNumber = 9;
 private bool hasHaveMoneyNum;
 private Int32 haveMoneyNum_ = 0;
 public bool HasHaveMoneyNum {
 get { return hasHaveMoneyNum; }
 }
 public Int32 HaveMoneyNum {
 get { return haveMoneyNum_; }
 set { SetHaveMoneyNum(value); }
 }
 public void SetHaveMoneyNum(Int32 value) { 
 hasHaveMoneyNum = true;
 haveMoneyNum_ = value;
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
 if (HasFightValue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, FightValue);
}
{
foreach (LegacyData element in listOnBodyList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (LegacyData element in listInBagList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Result);
}
{
int subsize = Legacy.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (LegacyData element in listInDepotList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasDrawId) {
size += pb::CodedOutputStream.ComputeInt32Size(8, DrawId);
}
 if (HasHaveMoneyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(9, HaveMoneyNum);
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
 
if (HasFightValue) {
output.WriteInt32(2, FightValue);
}

do{
foreach (LegacyData element in listOnBodyList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (LegacyData element in listInBagList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasResult) {
output.WriteInt32(5, Result);
}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Legacy.SerializedSize());
Legacy.WriteTo(output);

}

do{
foreach (LegacyData element in listInDepotList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasDrawId) {
output.WriteInt32(8, DrawId);
}
 
if (HasHaveMoneyNum) {
output.WriteInt32(9, HaveMoneyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLegacy _inst = (GCLegacy) _base;
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
 _inst.FightValue = input.ReadInt32();
break;
}
    case  26: {
LegacyData subBuilder =  new LegacyData();
input.ReadMessage(subBuilder);
_inst.AddListOnBody(subBuilder);
break;
}
    case  34: {
LegacyData subBuilder =  new LegacyData();
input.ReadMessage(subBuilder);
_inst.AddListInBag(subBuilder);
break;
}
   case  40: {
 _inst.Result = input.ReadInt32();
break;
}
    case  50: {
LegacyData subBuilder =  new LegacyData();
 input.ReadMessage(subBuilder);
_inst.Legacy = subBuilder;
break;
}
    case  58: {
LegacyData subBuilder =  new LegacyData();
input.ReadMessage(subBuilder);
_inst.AddListInDepot(subBuilder);
break;
}
   case  64: {
 _inst.DrawId = input.ReadInt32();
break;
}
   case  72: {
 _inst.HaveMoneyNum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (LegacyData element in listOnBodyList) {
if (!element.IsInitialized()) return false;
}
foreach (LegacyData element in listInBagList) {
if (!element.IsInitialized()) return false;
}
  if (HasLegacy) {
if (!Legacy.IsInitialized()) return false;
}
foreach (LegacyData element in listInDepotList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class LegacyData : PacketDistributed
{

public const int legacyIdFieldNumber = 1;
 private bool hasLegacyId;
 private Int32 legacyId_ = 0;
 public bool HasLegacyId {
 get { return hasLegacyId; }
 }
 public Int32 LegacyId {
 get { return legacyId_; }
 set { SetLegacyId(value); }
 }
 public void SetLegacyId(Int32 value) { 
 hasLegacyId = true;
 legacyId_ = value;
 }

public const int tableIdFieldNumber = 2;
 private bool hasTableId;
 private Int32 tableId_ = 0;
 public bool HasTableId {
 get { return hasTableId; }
 }
 public Int32 TableId {
 get { return tableId_; }
 set { SetTableId(value); }
 }
 public void SetTableId(Int32 value) { 
 hasTableId = true;
 tableId_ = value;
 }

public const int currentExpFieldNumber = 3;
 private bool hasCurrentExp;
 private Int32 currentExp_ = 0;
 public bool HasCurrentExp {
 get { return hasCurrentExp; }
 }
 public Int32 CurrentExp {
 get { return currentExp_; }
 set { SetCurrentExp(value); }
 }
 public void SetCurrentExp(Int32 value) { 
 hasCurrentExp = true;
 currentExp_ = value;
 }

public const int isOnBodyFieldNumber = 4;
 private bool hasIsOnBody;
 private Int32 isOnBody_ = 0;
 public bool HasIsOnBody {
 get { return hasIsOnBody; }
 }
 public Int32 IsOnBody {
 get { return isOnBody_; }
 set { SetIsOnBody(value); }
 }
 public void SetIsOnBody(Int32 value) { 
 hasIsOnBody = true;
 isOnBody_ = value;
 }

public const int idxOfBodyFieldNumber = 5;
 private bool hasIdxOfBody;
 private Int32 idxOfBody_ = 0;
 public bool HasIdxOfBody {
 get { return hasIdxOfBody; }
 }
 public Int32 IdxOfBody {
 get { return idxOfBody_; }
 set { SetIdxOfBody(value); }
 }
 public void SetIdxOfBody(Int32 value) { 
 hasIdxOfBody = true;
 idxOfBody_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLegacyId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, LegacyId);
}
 if (HasTableId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TableId);
}
 if (HasCurrentExp) {
size += pb::CodedOutputStream.ComputeInt32Size(3, CurrentExp);
}
 if (HasIsOnBody) {
size += pb::CodedOutputStream.ComputeInt32Size(4, IsOnBody);
}
 if (HasIdxOfBody) {
size += pb::CodedOutputStream.ComputeInt32Size(5, IdxOfBody);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLegacyId) {
output.WriteInt32(1, LegacyId);
}
 
if (HasTableId) {
output.WriteInt32(2, TableId);
}
 
if (HasCurrentExp) {
output.WriteInt32(3, CurrentExp);
}
 
if (HasIsOnBody) {
output.WriteInt32(4, IsOnBody);
}
 
if (HasIdxOfBody) {
output.WriteInt32(5, IdxOfBody);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LegacyData _inst = (LegacyData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.LegacyId = input.ReadInt32();
break;
}
   case  16: {
 _inst.TableId = input.ReadInt32();
break;
}
   case  24: {
 _inst.CurrentExp = input.ReadInt32();
break;
}
   case  32: {
 _inst.IsOnBody = input.ReadInt32();
break;
}
   case  40: {
 _inst.IdxOfBody = input.ReadInt32();
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
