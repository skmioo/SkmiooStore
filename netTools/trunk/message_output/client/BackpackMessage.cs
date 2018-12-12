//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class BackpackGrid : PacketDistributed
{

public const int gridIDFieldNumber = 1;
 private bool hasGridID;
 private Int32 gridID_ = 0;
 public bool HasGridID {
 get { return hasGridID; }
 }
 public Int32 GridID {
 get { return gridID_; }
 set { SetGridID(value); }
 }
 public void SetGridID(Int32 value) { 
 hasGridID = true;
 gridID_ = value;
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

public const int numFieldNumber = 4;
 private bool hasNum;
 private Int32 num_ = 0;
 public bool HasNum {
 get { return hasNum; }
 }
 public Int32 Num {
 get { return num_; }
 set { SetNum(value); }
 }
 public void SetNum(Int32 value) { 
 hasNum = true;
 num_ = value;
 }

public const int equipInfoFieldNumber = 5;
 private bool hasEquipInfo;
 private EquipInfo equipInfo_ =  new EquipInfo();
 public bool HasEquipInfo {
 get { return hasEquipInfo; }
 }
 public EquipInfo EquipInfo {
 get { return equipInfo_; }
 set { SetEquipInfo(value); }
 }
 public void SetEquipInfo(EquipInfo value) { 
 hasEquipInfo = true;
 equipInfo_ = value;
 }

public const int pidFieldNumber = 6;
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

public const int bindFieldNumber = 7;
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

public const int treasureEquipFieldNumber = 8;
 private bool hasTreasureEquip;
 private TreasureEquipData treasureEquip_ =  new TreasureEquipData();
 public bool HasTreasureEquip {
 get { return hasTreasureEquip; }
 }
 public TreasureEquipData TreasureEquip {
 get { return treasureEquip_; }
 set { SetTreasureEquip(value); }
 }
 public void SetTreasureEquip(TreasureEquipData value) { 
 hasTreasureEquip = true;
 treasureEquip_ = value;
 }

public const int talismanInfoFieldNumber = 9;
 private bool hasTalismanInfo;
 private TalismanInfo talismanInfo_ =  new TalismanInfo();
 public bool HasTalismanInfo {
 get { return hasTalismanInfo; }
 }
 public TalismanInfo TalismanInfo {
 get { return talismanInfo_; }
 set { SetTalismanInfo(value); }
 }
 public void SetTalismanInfo(TalismanInfo value) { 
 hasTalismanInfo = true;
 talismanInfo_ = value;
 }

public const int treasureMapFieldNumber = 10;
 private bool hasTreasureMap;
 private TreasureMapDataInfo treasureMap_ =  new TreasureMapDataInfo();
 public bool HasTreasureMap {
 get { return hasTreasureMap; }
 }
 public TreasureMapDataInfo TreasureMap {
 get { return treasureMap_; }
 set { SetTreasureMap(value); }
 }
 public void SetTreasureMap(TreasureMapDataInfo value) { 
 hasTreasureMap = true;
 treasureMap_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGridID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GridID);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasItemId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ItemId);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Num);
}
{
int subsize = EquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(6, Pid);
}
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Bind);
}
{
int subsize = TreasureEquip.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TalismanInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = TreasureMap.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)10) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGridID) {
output.WriteInt32(1, GridID);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasItemId) {
output.WriteInt32(3, ItemId);
}
 
if (HasNum) {
output.WriteInt32(4, Num);
}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)EquipInfo.SerializedSize());
EquipInfo.WriteTo(output);

}
 
if (HasPid) {
output.WriteInt64(6, Pid);
}
 
if (HasBind) {
output.WriteInt32(7, Bind);
}
{
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TreasureEquip.SerializedSize());
TreasureEquip.WriteTo(output);

}
{
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TalismanInfo.SerializedSize());
TalismanInfo.WriteTo(output);

}
{
output.WriteTag((int)10, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TreasureMap.SerializedSize());
TreasureMap.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BackpackGrid _inst = (BackpackGrid) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GridID = input.ReadInt32();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.ItemId = input.ReadInt32();
break;
}
   case  32: {
 _inst.Num = input.ReadInt32();
break;
}
    case  42: {
EquipInfo subBuilder =  new EquipInfo();
 input.ReadMessage(subBuilder);
_inst.EquipInfo = subBuilder;
break;
}
   case  48: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  56: {
 _inst.Bind = input.ReadInt32();
break;
}
    case  66: {
TreasureEquipData subBuilder =  new TreasureEquipData();
 input.ReadMessage(subBuilder);
_inst.TreasureEquip = subBuilder;
break;
}
    case  74: {
TalismanInfo subBuilder =  new TalismanInfo();
 input.ReadMessage(subBuilder);
_inst.TalismanInfo = subBuilder;
break;
}
    case  82: {
TreasureMapDataInfo subBuilder =  new TreasureMapDataInfo();
 input.ReadMessage(subBuilder);
_inst.TreasureMap = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasEquipInfo) {
if (!EquipInfo.IsInitialized()) return false;
}
  if (HasTreasureEquip) {
if (!TreasureEquip.IsInitialized()) return false;
}
  if (HasTalismanInfo) {
if (!TalismanInfo.IsInitialized()) return false;
}
  if (HasTreasureMap) {
if (!TreasureMap.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class BackpackItem : PacketDistributed
{

public const int bidFieldNumber = 1;
 private bool hasBid;
 private Int32 bid_ = 0;
 public bool HasBid {
 get { return hasBid; }
 }
 public Int32 Bid {
 get { return bid_; }
 set { SetBid(value); }
 }
 public void SetBid(Int32 value) { 
 hasBid = true;
 bid_ = value;
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

public const int numFieldNumber = 3;
 private bool hasNum;
 private Int32 num_ = 0;
 public bool HasNum {
 get { return hasNum; }
 }
 public Int32 Num {
 get { return num_; }
 set { SetNum(value); }
 }
 public void SetNum(Int32 value) { 
 hasNum = true;
 num_ = value;
 }

public const int bindFieldNumber = 4;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
}
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Bind);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBid) {
output.WriteInt32(1, Bid);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 
if (HasBind) {
output.WriteInt32(4, Bind);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BackpackItem _inst = (BackpackItem) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  24: {
 _inst.Num = input.ReadInt32();
break;
}
   case  32: {
 _inst.Bind = input.ReadInt32();
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
public class CGBackUseMap : PacketDistributed
{

public const int gridIDFieldNumber = 1;
 private bool hasGridID;
 private Int32 gridID_ = 0;
 public bool HasGridID {
 get { return hasGridID; }
 }
 public Int32 GridID {
 get { return gridID_; }
 set { SetGridID(value); }
 }
 public void SetGridID(Int32 value) { 
 hasGridID = true;
 gridID_ = value;
 }

public const int pidFieldNumber = 2;
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
  if (HasGridID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GridID);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Pid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGridID) {
output.WriteInt32(1, GridID);
}
 
if (HasPid) {
output.WriteInt64(2, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBackUseMap _inst = (CGBackUseMap) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GridID = input.ReadInt32();
break;
}
   case  16: {
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
public class CGBackUseNineMystery : PacketDistributed
{

public const int gridIDFieldNumber = 1;
 private bool hasGridID;
 private Int32 gridID_ = 0;
 public bool HasGridID {
 get { return hasGridID; }
 }
 public Int32 GridID {
 get { return gridID_; }
 set { SetGridID(value); }
 }
 public void SetGridID(Int32 value) { 
 hasGridID = true;
 gridID_ = value;
 }

public const int pidFieldNumber = 2;
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
  if (HasGridID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GridID);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Pid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGridID) {
output.WriteInt32(1, GridID);
}
 
if (HasPid) {
output.WriteInt64(2, Pid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBackUseNineMystery _inst = (CGBackUseNineMystery) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GridID = input.ReadInt32();
break;
}
   case  16: {
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
public class CGBackpackOper : PacketDistributed
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

public const int gidFieldNumber = 2;
 private bool hasGid;
 private Int32 gid_ = 0;
 public bool HasGid {
 get { return hasGid; }
 }
 public Int32 Gid {
 get { return gid_; }
 set { SetGid(value); }
 }
 public void SetGid(Int32 value) { 
 hasGid = true;
 gid_ = value;
 }

public const int addNumFieldNumber = 3;
 private bool hasAddNum;
 private Int32 addNum_ = 0;
 public bool HasAddNum {
 get { return hasAddNum; }
 }
 public Int32 AddNum {
 get { return addNum_; }
 set { SetAddNum(value); }
 }
 public void SetAddNum(Int32 value) { 
 hasAddNum = true;
 addNum_ = value;
 }

public const int resolveIdFieldNumber = 4;
 private pbc::PopsicleList<Int32> resolveId_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> resolveIdList {
 get { return pbc::Lists.AsReadOnly(resolveId_); }
 }
 
 public int resolveIdCount {
 get { return resolveId_.Count; }
 }
 
public Int32 GetResolveId(int index) {
 return resolveId_[index];
 }
 public void AddResolveId(Int32 value) {
 resolveId_.Add(value);
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
 if (HasGid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Gid);
}
 if (HasAddNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, AddNum);
}
{
int dataSize = 0;
foreach (Int32 element in resolveIdList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * resolveId_.Count;
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
 
if (HasGid) {
output.WriteInt32(2, Gid);
}
 
if (HasAddNum) {
output.WriteInt32(3, AddNum);
}
{
if (resolveId_.Count > 0) {
foreach (Int32 element in resolveIdList) {
output.WriteInt32(4,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBackpackOper _inst = (CGBackpackOper) _base;
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
 _inst.Gid = input.ReadInt32();
break;
}
   case  24: {
 _inst.AddNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.AddResolveId(input.ReadInt32());
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
public class CGBackpackSpecial : PacketDistributed
{

public const int playerIdFieldNumber = 1;
 private bool hasPlayerId;
 private Int64 playerId_ = 0;
 public bool HasPlayerId {
 get { return hasPlayerId; }
 }
 public Int64 PlayerId {
 get { return playerId_; }
 set { SetPlayerId(value); }
 }
 public void SetPlayerId(Int64 value) { 
 hasPlayerId = true;
 playerId_ = value;
 }

public const int operateFieldNumber = 2;
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

public const int backpackItemFieldNumber = 3;
 private pbc::PopsicleList<BackpackItem> backpackItem_ = new pbc::PopsicleList<BackpackItem>();
 public scg::IList<BackpackItem> backpackItemList {
 get { return pbc::Lists.AsReadOnly(backpackItem_); }
 }
 
 public int backpackItemCount {
 get { return backpackItem_.Count; }
 }
 
public BackpackItem GetBackpackItem(int index) {
 return backpackItem_[index];
 }
 public void AddBackpackItem(BackpackItem value) {
 backpackItem_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerId);
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
{
foreach (BackpackItem element in backpackItemList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerId) {
output.WriteInt64(1, PlayerId);
}
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}

do{
foreach (BackpackItem element in backpackItemList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBackpackSpecial _inst = (CGBackpackSpecial) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Operate = input.ReadInt32();
break;
}
    case  26: {
BackpackItem subBuilder =  new BackpackItem();
input.ReadMessage(subBuilder);
_inst.AddBackpackItem(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BackpackItem element in backpackItemList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGComposeItems : PacketDistributed
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

public const int targetNumFieldNumber = 2;
 private bool hasTargetNum;
 private Int32 targetNum_ = 0;
 public bool HasTargetNum {
 get { return hasTargetNum; }
 }
 public Int32 TargetNum {
 get { return targetNum_; }
 set { SetTargetNum(value); }
 }
 public void SetTargetNum(Int32 value) { 
 hasTargetNum = true;
 targetNum_ = value;
 }

public const int selectBoundFieldNumber = 3;
 private bool hasSelectBound;
 private Int32 selectBound_ = 0;
 public bool HasSelectBound {
 get { return hasSelectBound; }
 }
 public Int32 SelectBound {
 get { return selectBound_; }
 set { SetSelectBound(value); }
 }
 public void SetSelectBound(Int32 value) { 
 hasSelectBound = true;
 selectBound_ = value;
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
 if (HasTargetNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TargetNum);
}
 if (HasSelectBound) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SelectBound);
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
 
if (HasTargetNum) {
output.WriteInt32(2, TargetNum);
}
 
if (HasSelectBound) {
output.WriteInt32(3, SelectBound);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGComposeItems _inst = (CGComposeItems) _base;
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
   case  16: {
 _inst.TargetNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.SelectBound = input.ReadInt32();
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
public class CGSetAutoResolve : PacketDistributed
{

public const int resolveIdFieldNumber = 1;
 private bool hasResolveId;
 private Int32 resolveId_ = 0;
 public bool HasResolveId {
 get { return hasResolveId; }
 }
 public Int32 ResolveId {
 get { return resolveId_; }
 set { SetResolveId(value); }
 }
 public void SetResolveId(Int32 value) { 
 hasResolveId = true;
 resolveId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResolveId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ResolveId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResolveId) {
output.WriteInt32(1, ResolveId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSetAutoResolve _inst = (CGSetAutoResolve) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ResolveId = input.ReadInt32();
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
public class CGTransmitToMember : PacketDistributed
{

public const int playerIDFieldNumber = 1;
 private bool hasPlayerID;
 private Int64 playerID_ = 0;
 public bool HasPlayerID {
 get { return hasPlayerID; }
 }
 public Int64 PlayerID {
 get { return playerID_; }
 set { SetPlayerID(value); }
 }
 public void SetPlayerID(Int64 value) { 
 hasPlayerID = true;
 playerID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerID) {
output.WriteInt64(1, PlayerID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTransmitToMember _inst = (CGTransmitToMember) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerID = input.ReadInt64();
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
public class CGUseNineMysteryIntoDungeon : PacketDistributed
{

public const int dungeonFieldNumber = 1;
 private bool hasDungeon;
 private string dungeon_ = "";
 public bool HasDungeon {
 get { return hasDungeon; }
 }
 public string Dungeon {
 get { return dungeon_; }
 set { SetDungeon(value); }
 }
 public void SetDungeon(string value) { 
 hasDungeon = true;
 dungeon_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDungeon) {
size += pb::CodedOutputStream.ComputeStringSize(1, Dungeon);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDungeon) {
output.WriteString(1, Dungeon);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUseNineMysteryIntoDungeon _inst = (CGUseNineMysteryIntoDungeon) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Dungeon = input.ReadString();
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
public class GCBackNineMystery : PacketDistributed
{

public const int resultFieldNumber = 1;
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

public const int nineMysteryItemFieldNumber = 2;
 private pbc::PopsicleList<NineMysteryItem> nineMysteryItem_ = new pbc::PopsicleList<NineMysteryItem>();
 public scg::IList<NineMysteryItem> nineMysteryItemList {
 get { return pbc::Lists.AsReadOnly(nineMysteryItem_); }
 }
 
 public int nineMysteryItemCount {
 get { return nineMysteryItem_.Count; }
 }
 
public NineMysteryItem GetNineMysteryItem(int index) {
 return nineMysteryItem_[index];
 }
 public void AddNineMysteryItem(NineMysteryItem value) {
 nineMysteryItem_.Add(value);
 }

public const int pidFieldNumber = 3;
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

public const int operateFieldNumber = 4;
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

public const int monsterIDFieldNumber = 5;
 private bool hasMonsterID;
 private Int64 monsterID_ = 0;
 public bool HasMonsterID {
 get { return hasMonsterID; }
 }
 public Int64 MonsterID {
 get { return monsterID_; }
 set { SetMonsterID(value); }
 }
 public void SetMonsterID(Int64 value) { 
 hasMonsterID = true;
 monsterID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
{
foreach (NineMysteryItem element in nineMysteryItemList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Pid);
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Operate);
}
 if (HasMonsterID) {
size += pb::CodedOutputStream.ComputeInt64Size(5, MonsterID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResult) {
output.WriteInt32(1, Result);
}

do{
foreach (NineMysteryItem element in nineMysteryItemList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasPid) {
output.WriteInt64(3, Pid);
}
 
if (HasOperate) {
output.WriteInt32(4, Operate);
}
 
if (HasMonsterID) {
output.WriteInt64(5, MonsterID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackNineMystery _inst = (GCBackNineMystery) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Result = input.ReadInt32();
break;
}
    case  18: {
NineMysteryItem subBuilder =  new NineMysteryItem();
input.ReadMessage(subBuilder);
_inst.AddNineMysteryItem(subBuilder);
break;
}
   case  24: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  32: {
 _inst.Operate = input.ReadInt32();
break;
}
   case  40: {
 _inst.MonsterID = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (NineMysteryItem element in nineMysteryItemList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCBackPuseUseMap : PacketDistributed
{

public const int resultFieldNumber = 1;
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

public const int treasureMapFieldNumber = 2;
 private pbc::PopsicleList<TreasureMap> treasureMap_ = new pbc::PopsicleList<TreasureMap>();
 public scg::IList<TreasureMap> treasureMapList {
 get { return pbc::Lists.AsReadOnly(treasureMap_); }
 }
 
 public int treasureMapCount {
 get { return treasureMap_.Count; }
 }
 
public TreasureMap GetTreasureMap(int index) {
 return treasureMap_[index];
 }
 public void AddTreasureMap(TreasureMap value) {
 treasureMap_.Add(value);
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

public const int monsterIDFieldNumber = 4;
 private bool hasMonsterID;
 private Int64 monsterID_ = 0;
 public bool HasMonsterID {
 get { return hasMonsterID; }
 }
 public Int64 MonsterID {
 get { return monsterID_; }
 set { SetMonsterID(value); }
 }
 public void SetMonsterID(Int64 value) { 
 hasMonsterID = true;
 monsterID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
{
foreach (TreasureMap element in treasureMapList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
}
 if (HasMonsterID) {
size += pb::CodedOutputStream.ComputeInt64Size(4, MonsterID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResult) {
output.WriteInt32(1, Result);
}

do{
foreach (TreasureMap element in treasureMapList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasType) {
output.WriteInt32(3, Type);
}
 
if (HasMonsterID) {
output.WriteInt64(4, MonsterID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackPuseUseMap _inst = (GCBackPuseUseMap) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Result = input.ReadInt32();
break;
}
    case  18: {
TreasureMap subBuilder =  new TreasureMap();
input.ReadMessage(subBuilder);
_inst.AddTreasureMap(subBuilder);
break;
}
   case  24: {
 _inst.Type = input.ReadInt32();
break;
}
   case  32: {
 _inst.MonsterID = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TreasureMap element in treasureMapList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCBackTreasureMap : PacketDistributed
{

public const int resultFieldNumber = 1;
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

public const int operateFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResult) {
output.WriteInt32(1, Result);
}
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackTreasureMap _inst = (GCBackTreasureMap) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Result = input.ReadInt32();
break;
}
   case  16: {
 _inst.Operate = input.ReadInt32();
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
public class GCBackpackOper : PacketDistributed
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

public const int gidFieldNumber = 2;
 private bool hasGid;
 private Int32 gid_ = 0;
 public bool HasGid {
 get { return hasGid; }
 }
 public Int32 Gid {
 get { return gid_; }
 set { SetGid(value); }
 }
 public void SetGid(Int32 value) { 
 hasGid = true;
 gid_ = value;
 }

public const int addNumFieldNumber = 3;
 private bool hasAddNum;
 private Int32 addNum_ = 0;
 public bool HasAddNum {
 get { return hasAddNum; }
 }
 public Int32 AddNum {
 get { return addNum_; }
 set { SetAddNum(value); }
 }
 public void SetAddNum(Int32 value) { 
 hasAddNum = true;
 addNum_ = value;
 }

public const int resolveIdFieldNumber = 4;
 private pbc::PopsicleList<Int32> resolveId_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> resolveIdList {
 get { return pbc::Lists.AsReadOnly(resolveId_); }
 }
 
 public int resolveIdCount {
 get { return resolveId_.Count; }
 }
 
public Int32 GetResolveId(int index) {
 return resolveId_[index];
 }
 public void AddResolveId(Int32 value) {
 resolveId_.Add(value);
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
 if (HasGid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Gid);
}
 if (HasAddNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, AddNum);
}
{
int dataSize = 0;
foreach (Int32 element in resolveIdList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * resolveId_.Count;
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
 
if (HasGid) {
output.WriteInt32(2, Gid);
}
 
if (HasAddNum) {
output.WriteInt32(3, AddNum);
}
{
if (resolveId_.Count > 0) {
foreach (Int32 element in resolveIdList) {
output.WriteInt32(4,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackpackOper _inst = (GCBackpackOper) _base;
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
 _inst.Gid = input.ReadInt32();
break;
}
   case  24: {
 _inst.AddNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.AddResolveId(input.ReadInt32());
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
public class GCComposeItems : PacketDistributed
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

public const int targetNumFieldNumber = 2;
 private bool hasTargetNum;
 private Int32 targetNum_ = 0;
 public bool HasTargetNum {
 get { return hasTargetNum; }
 }
 public Int32 TargetNum {
 get { return targetNum_; }
 set { SetTargetNum(value); }
 }
 public void SetTargetNum(Int32 value) { 
 hasTargetNum = true;
 targetNum_ = value;
 }

public const int selectBoundFieldNumber = 3;
 private bool hasSelectBound;
 private Int32 selectBound_ = 0;
 public bool HasSelectBound {
 get { return hasSelectBound; }
 }
 public Int32 SelectBound {
 get { return selectBound_; }
 set { SetSelectBound(value); }
 }
 public void SetSelectBound(Int32 value) { 
 hasSelectBound = true;
 selectBound_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasTargetNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TargetNum);
}
 if (HasSelectBound) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SelectBound);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Flag);
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
 
if (HasTargetNum) {
output.WriteInt32(2, TargetNum);
}
 
if (HasSelectBound) {
output.WriteInt32(3, SelectBound);
}
 
if (HasFlag) {
output.WriteInt32(4, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCComposeItems _inst = (GCComposeItems) _base;
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
   case  16: {
 _inst.TargetNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.SelectBound = input.ReadInt32();
break;
}
   case  32: {
 _inst.Flag = input.ReadInt32();
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
public class GCItemLimitBack : PacketDistributed
{

public const int itemLimitsFieldNumber = 1;
 private pbc::PopsicleList<ItemLimit> itemLimits_ = new pbc::PopsicleList<ItemLimit>();
 public scg::IList<ItemLimit> itemLimitsList {
 get { return pbc::Lists.AsReadOnly(itemLimits_); }
 }
 
 public int itemLimitsCount {
 get { return itemLimits_.Count; }
 }
 
public ItemLimit GetItemLimits(int index) {
 return itemLimits_[index];
 }
 public void AddItemLimits(ItemLimit value) {
 itemLimits_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ItemLimit element in itemLimitsList) {
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
foreach (ItemLimit element in itemLimitsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCItemLimitBack _inst = (GCItemLimitBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ItemLimit subBuilder =  new ItemLimit();
input.ReadMessage(subBuilder);
_inst.AddItemLimits(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ItemLimit element in itemLimitsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOpenChatHornUI : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ErrorCode);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOpenChatHornUI _inst = (GCOpenChatHornUI) _base;
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
public class GCPutBackpack : PacketDistributed
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

public const int itemsFieldNumber = 2;
 private pbc::PopsicleList<BackpackGrid> items_ = new pbc::PopsicleList<BackpackGrid>();
 public scg::IList<BackpackGrid> itemsList {
 get { return pbc::Lists.AsReadOnly(items_); }
 }
 
 public int itemsCount {
 get { return items_.Count; }
 }
 
public BackpackGrid GetItems(int index) {
 return items_[index];
 }
 public void AddItems(BackpackGrid value) {
 items_.Add(value);
 }

public const int gridNumFieldNumber = 3;
 private bool hasGridNum;
 private Int32 gridNum_ = 0;
 public bool HasGridNum {
 get { return hasGridNum; }
 }
 public Int32 GridNum {
 get { return gridNum_; }
 set { SetGridNum(value); }
 }
 public void SetGridNum(Int32 value) { 
 hasGridNum = true;
 gridNum_ = value;
 }

public const int gridMaxFieldNumber = 4;
 private bool hasGridMax;
 private Int32 gridMax_ = 0;
 public bool HasGridMax {
 get { return hasGridMax; }
 }
 public Int32 GridMax {
 get { return gridMax_; }
 set { SetGridMax(value); }
 }
 public void SetGridMax(Int32 value) { 
 hasGridMax = true;
 gridMax_ = value;
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
{
foreach (BackpackGrid element in itemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasGridNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GridNum);
}
 if (HasGridMax) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GridMax);
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

do{
foreach (BackpackGrid element in itemsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasGridNum) {
output.WriteInt32(3, GridNum);
}
 
if (HasGridMax) {
output.WriteInt32(4, GridMax);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPutBackpack _inst = (GCPutBackpack) _base;
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
    case  18: {
BackpackGrid subBuilder =  new BackpackGrid();
input.ReadMessage(subBuilder);
_inst.AddItems(subBuilder);
break;
}
   case  24: {
 _inst.GridNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.GridMax = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BackpackGrid element in itemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPutStorage : PacketDistributed
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

public const int itemsFieldNumber = 2;
 private pbc::PopsicleList<BackpackGrid> items_ = new pbc::PopsicleList<BackpackGrid>();
 public scg::IList<BackpackGrid> itemsList {
 get { return pbc::Lists.AsReadOnly(items_); }
 }
 
 public int itemsCount {
 get { return items_.Count; }
 }
 
public BackpackGrid GetItems(int index) {
 return items_[index];
 }
 public void AddItems(BackpackGrid value) {
 items_.Add(value);
 }

public const int gridNumFieldNumber = 3;
 private bool hasGridNum;
 private Int32 gridNum_ = 0;
 public bool HasGridNum {
 get { return hasGridNum; }
 }
 public Int32 GridNum {
 get { return gridNum_; }
 set { SetGridNum(value); }
 }
 public void SetGridNum(Int32 value) { 
 hasGridNum = true;
 gridNum_ = value;
 }

public const int gridMaxFieldNumber = 4;
 private bool hasGridMax;
 private Int32 gridMax_ = 0;
 public bool HasGridMax {
 get { return hasGridMax; }
 }
 public Int32 GridMax {
 get { return gridMax_; }
 set { SetGridMax(value); }
 }
 public void SetGridMax(Int32 value) { 
 hasGridMax = true;
 gridMax_ = value;
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
{
foreach (BackpackGrid element in itemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasGridNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GridNum);
}
 if (HasGridMax) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GridMax);
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

do{
foreach (BackpackGrid element in itemsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasGridNum) {
output.WriteInt32(3, GridNum);
}
 
if (HasGridMax) {
output.WriteInt32(4, GridMax);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPutStorage _inst = (GCPutStorage) _base;
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
    case  18: {
BackpackGrid subBuilder =  new BackpackGrid();
input.ReadMessage(subBuilder);
_inst.AddItems(subBuilder);
break;
}
   case  24: {
 _inst.GridNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.GridMax = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BackpackGrid element in itemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendMakeAct : PacketDistributed
{

public const int actIDFieldNumber = 1;
 private bool hasActID;
 private Int32 actID_ = 0;
 public bool HasActID {
 get { return hasActID; }
 }
 public Int32 ActID {
 get { return actID_; }
 set { SetActID(value); }
 }
 public void SetActID(Int32 value) { 
 hasActID = true;
 actID_ = value;
 }

public const int playerIDFieldNumber = 2;
 private bool hasPlayerID;
 private Int64 playerID_ = 0;
 public bool HasPlayerID {
 get { return hasPlayerID; }
 }
 public Int64 PlayerID {
 get { return playerID_; }
 set { SetPlayerID(value); }
 }
 public void SetPlayerID(Int64 value) { 
 hasPlayerID = true;
 playerID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActID);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PlayerID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActID) {
output.WriteInt32(1, ActID);
}
 
if (HasPlayerID) {
output.WriteInt64(2, PlayerID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendMakeAct _inst = (GCSendMakeAct) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActID = input.ReadInt32();
break;
}
   case  16: {
 _inst.PlayerID = input.ReadInt64();
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
public class GCSendOpenBoxEnd : PacketDistributed
{

public const int rewardsFieldNumber = 1;
 private pbc::PopsicleList<BackpackItem> rewards_ = new pbc::PopsicleList<BackpackItem>();
 public scg::IList<BackpackItem> rewardsList {
 get { return pbc::Lists.AsReadOnly(rewards_); }
 }
 
 public int rewardsCount {
 get { return rewards_.Count; }
 }
 
public BackpackItem GetRewards(int index) {
 return rewards_[index];
 }
 public void AddRewards(BackpackItem value) {
 rewards_.Add(value);
 }

public const int errorCodeFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (BackpackItem element in rewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ErrorCode);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (BackpackItem element in rewardsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasErrorCode) {
output.WriteInt32(2, ErrorCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendOpenBoxEnd _inst = (GCSendOpenBoxEnd) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BackpackItem subBuilder =  new BackpackItem();
input.ReadMessage(subBuilder);
_inst.AddRewards(subBuilder);
break;
}
   case  16: {
 _inst.ErrorCode = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BackpackItem element in rewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendTransmitToMe : PacketDistributed
{

public const int playerIDFieldNumber = 1;
 private bool hasPlayerID;
 private Int64 playerID_ = 0;
 public bool HasPlayerID {
 get { return hasPlayerID; }
 }
 public Int64 PlayerID {
 get { return playerID_; }
 set { SetPlayerID(value); }
 }
 public void SetPlayerID(Int64 value) { 
 hasPlayerID = true;
 playerID_ = value;
 }

public const int limitTimeFieldNumber = 2;
 private bool hasLimitTime;
 private Int32 limitTime_ = 0;
 public bool HasLimitTime {
 get { return hasLimitTime; }
 }
 public Int32 LimitTime {
 get { return limitTime_; }
 set { SetLimitTime(value); }
 }
 public void SetLimitTime(Int32 value) { 
 hasLimitTime = true;
 limitTime_ = value;
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
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
}
 if (HasLimitTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LimitTime);
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
  
if (HasPlayerID) {
output.WriteInt64(1, PlayerID);
}
 
if (HasLimitTime) {
output.WriteInt32(2, LimitTime);
}
 
if (HasPlayerName) {
output.WriteString(3, PlayerName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendTransmitToMe _inst = (GCSendTransmitToMe) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  16: {
 _inst.LimitTime = input.ReadInt32();
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
  return true;
 }

	}


[Serializable]
public class GCSetAutoResolve : PacketDistributed
{

public const int resolveIdFieldNumber = 1;
 private bool hasResolveId;
 private Int32 resolveId_ = 0;
 public bool HasResolveId {
 get { return hasResolveId; }
 }
 public Int32 ResolveId {
 get { return resolveId_; }
 set { SetResolveId(value); }
 }
 public void SetResolveId(Int32 value) { 
 hasResolveId = true;
 resolveId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResolveId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ResolveId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResolveId) {
output.WriteInt32(1, ResolveId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSetAutoResolve _inst = (GCSetAutoResolve) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ResolveId = input.ReadInt32();
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
public class ItemLimit : PacketDistributed
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

public const int numFieldNumber = 2;
 private bool hasNum;
 private Int32 num_ = 0;
 public bool HasNum {
 get { return hasNum; }
 }
 public Int32 Num {
 get { return num_; }
 set { SetNum(value); }
 }
 public void SetNum(Int32 value) { 
 hasNum = true;
 num_ = value;
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
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Num);
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
 
if (HasNum) {
output.WriteInt32(2, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ItemLimit _inst = (ItemLimit) _base;
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
 _inst.Num = input.ReadInt32();
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
public class NineMysteryItem : PacketDistributed
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

public const int mapIDFieldNumber = 2;
 private bool hasMapID;
 private Int32 mapID_ = 0;
 public bool HasMapID {
 get { return hasMapID; }
 }
 public Int32 MapID {
 get { return mapID_; }
 set { SetMapID(value); }
 }
 public void SetMapID(Int32 value) { 
 hasMapID = true;
 mapID_ = value;
 }

public const int eventTypeFieldNumber = 3;
 private bool hasEventType;
 private Int32 eventType_ = 0;
 public bool HasEventType {
 get { return hasEventType; }
 }
 public Int32 EventType {
 get { return eventType_; }
 set { SetEventType(value); }
 }
 public void SetEventType(Int32 value) { 
 hasEventType = true;
 eventType_ = value;
 }

public const int paramFieldNumber = 4;
 private bool hasParam;
 private string param_ = "";
 public bool HasParam {
 get { return hasParam; }
 }
 public string Param {
 get { return param_; }
 set { SetParam(value); }
 }
 public void SetParam(string value) { 
 hasParam = true;
 param_ = value;
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
 if (HasMapID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MapID);
}
 if (HasEventType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, EventType);
}
 if (HasParam) {
size += pb::CodedOutputStream.ComputeStringSize(4, Param);
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
 
if (HasMapID) {
output.WriteInt32(2, MapID);
}
 
if (HasEventType) {
output.WriteInt32(3, EventType);
}
 
if (HasParam) {
output.WriteString(4, Param);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 NineMysteryItem _inst = (NineMysteryItem) _base;
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
 _inst.MapID = input.ReadInt32();
break;
}
   case  24: {
 _inst.EventType = input.ReadInt32();
break;
}
   case  34: {
 _inst.Param = input.ReadString();
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
public class TreasureMap : PacketDistributed
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

public const int mapIDFieldNumber = 2;
 private bool hasMapID;
 private Int32 mapID_ = 0;
 public bool HasMapID {
 get { return hasMapID; }
 }
 public Int32 MapID {
 get { return mapID_; }
 set { SetMapID(value); }
 }
 public void SetMapID(Int32 value) { 
 hasMapID = true;
 mapID_ = value;
 }

public const int funcIDFieldNumber = 3;
 private bool hasFuncID;
 private Int32 funcID_ = 0;
 public bool HasFuncID {
 get { return hasFuncID; }
 }
 public Int32 FuncID {
 get { return funcID_; }
 set { SetFuncID(value); }
 }
 public void SetFuncID(Int32 value) { 
 hasFuncID = true;
 funcID_ = value;
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
 if (HasMapID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MapID);
}
 if (HasFuncID) {
size += pb::CodedOutputStream.ComputeInt32Size(3, FuncID);
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
 
if (HasMapID) {
output.WriteInt32(2, MapID);
}
 
if (HasFuncID) {
output.WriteInt32(3, FuncID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TreasureMap _inst = (TreasureMap) _base;
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
 _inst.MapID = input.ReadInt32();
break;
}
   case  24: {
 _inst.FuncID = input.ReadInt32();
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
public class TreasureMapDataInfo : PacketDistributed
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

public const int locationIdFieldNumber = 2;
 private bool hasLocationId;
 private Int32 locationId_ = 0;
 public bool HasLocationId {
 get { return hasLocationId; }
 }
 public Int32 LocationId {
 get { return locationId_; }
 set { SetLocationId(value); }
 }
 public void SetLocationId(Int32 value) { 
 hasLocationId = true;
 locationId_ = value;
 }

public const int eventTypeFieldNumber = 3;
 private bool hasEventType;
 private Int32 eventType_ = 0;
 public bool HasEventType {
 get { return hasEventType; }
 }
 public Int32 EventType {
 get { return eventType_; }
 set { SetEventType(value); }
 }
 public void SetEventType(Int32 value) { 
 hasEventType = true;
 eventType_ = value;
 }

public const int eventParamFieldNumber = 4;
 private bool hasEventParam;
 private Int32 eventParam_ = 0;
 public bool HasEventParam {
 get { return hasEventParam; }
 }
 public Int32 EventParam {
 get { return eventParam_; }
 set { SetEventParam(value); }
 }
 public void SetEventParam(Int32 value) { 
 hasEventParam = true;
 eventParam_ = value;
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
 if (HasLocationId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LocationId);
}
 if (HasEventType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, EventType);
}
 if (HasEventParam) {
size += pb::CodedOutputStream.ComputeInt32Size(4, EventParam);
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
 
if (HasLocationId) {
output.WriteInt32(2, LocationId);
}
 
if (HasEventType) {
output.WriteInt32(3, EventType);
}
 
if (HasEventParam) {
output.WriteInt32(4, EventParam);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TreasureMapDataInfo _inst = (TreasureMapDataInfo) _base;
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
 _inst.LocationId = input.ReadInt32();
break;
}
   case  24: {
 _inst.EventType = input.ReadInt32();
break;
}
   case  32: {
 _inst.EventParam = input.ReadInt32();
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
