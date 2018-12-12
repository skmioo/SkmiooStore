//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCreateEquip : PacketDistributed
{

public const int createListIDFieldNumber = 1;
 private bool hasCreateListID;
 private Int32 createListID_ = 0;
 public bool HasCreateListID {
 get { return hasCreateListID; }
 }
 public Int32 CreateListID {
 get { return createListID_; }
 set { SetCreateListID(value); }
 }
 public void SetCreateListID(Int32 value) { 
 hasCreateListID = true;
 createListID_ = value;
 }

public const int createTypeFieldNumber = 2;
 private bool hasCreateType;
 private Int32 createType_ = 0;
 public bool HasCreateType {
 get { return hasCreateType; }
 }
 public Int32 CreateType {
 get { return createType_; }
 set { SetCreateType(value); }
 }
 public void SetCreateType(Int32 value) { 
 hasCreateType = true;
 createType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCreateListID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, CreateListID);
}
 if (HasCreateType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CreateType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCreateListID) {
output.WriteInt32(1, CreateListID);
}
 
if (HasCreateType) {
output.WriteInt32(2, CreateType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCreateEquip _inst = (CGCreateEquip) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.CreateListID = input.ReadInt32();
break;
}
   case  16: {
 _inst.CreateType = input.ReadInt32();
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
public class CGEquipOperate : PacketDistributed
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

public const int gridIDFieldNumber = 2;
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

public const int powertypeFieldNumber = 4;
 private bool hasPowertype;
 private Int32 powertype_ = 0;
 public bool HasPowertype {
 get { return hasPowertype; }
 }
 public Int32 Powertype {
 get { return powertype_; }
 set { SetPowertype(value); }
 }
 public void SetPowertype(Int32 value) { 
 hasPowertype = true;
 powertype_ = value;
 }

public const int holeIdFieldNumber = 5;
 private bool hasHoleId;
 private Int32 holeId_ = 0;
 public bool HasHoleId {
 get { return hasHoleId; }
 }
 public Int32 HoleId {
 get { return holeId_; }
 set { SetHoleId(value); }
 }
 public void SetHoleId(Int32 value) { 
 hasHoleId = true;
 holeId_ = value;
 }

public const int gemPidFieldNumber = 6;
 private bool hasGemPid;
 private Int64 gemPid_ = 0;
 public bool HasGemPid {
 get { return hasGemPid; }
 }
 public Int64 GemPid {
 get { return gemPid_; }
 set { SetGemPid(value); }
 }
 public void SetGemPid(Int64 value) { 
 hasGemPid = true;
 gemPid_ = value;
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
 if (HasGridID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GridID);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Pid);
}
 if (HasPowertype) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Powertype);
}
 if (HasHoleId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, HoleId);
}
 if (HasGemPid) {
size += pb::CodedOutputStream.ComputeInt64Size(6, GemPid);
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
 
if (HasGridID) {
output.WriteInt32(2, GridID);
}
 
if (HasPid) {
output.WriteInt64(3, Pid);
}
 
if (HasPowertype) {
output.WriteInt32(4, Powertype);
}
 
if (HasHoleId) {
output.WriteInt32(5, HoleId);
}
 
if (HasGemPid) {
output.WriteInt64(6, GemPid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGEquipOperate _inst = (CGEquipOperate) _base;
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
 _inst.GridID = input.ReadInt32();
break;
}
   case  24: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  32: {
 _inst.Powertype = input.ReadInt32();
break;
}
   case  40: {
 _inst.HoleId = input.ReadInt32();
break;
}
   case  48: {
 _inst.GemPid = input.ReadInt64();
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
public class CGHorseEquipOperate : PacketDistributed
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

public const int gridIDFieldNumber = 2;
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

public const int autoCostFieldNumber = 4;
 private bool hasAutoCost;
 private Int32 autoCost_ = 0;
 public bool HasAutoCost {
 get { return hasAutoCost; }
 }
 public Int32 AutoCost {
 get { return autoCost_; }
 set { SetAutoCost(value); }
 }
 public void SetAutoCost(Int32 value) { 
 hasAutoCost = true;
 autoCost_ = value;
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
 if (HasGridID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GridID);
}
 if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Pid);
}
 if (HasAutoCost) {
size += pb::CodedOutputStream.ComputeInt32Size(4, AutoCost);
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
 
if (HasGridID) {
output.WriteInt32(2, GridID);
}
 
if (HasPid) {
output.WriteInt64(3, Pid);
}
 
if (HasAutoCost) {
output.WriteInt32(4, AutoCost);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGHorseEquipOperate _inst = (CGHorseEquipOperate) _base;
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
 _inst.GridID = input.ReadInt32();
break;
}
   case  24: {
 _inst.Pid = input.ReadInt64();
break;
}
   case  32: {
 _inst.AutoCost = input.ReadInt32();
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
public class CGPlayerDetalitedInfo : PacketDistributed
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
 CGPlayerDetalitedInfo _inst = (CGPlayerDetalitedInfo) _base;
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
public class EquipAttr : PacketDistributed
{

public const int attrkeyFieldNumber = 1;
 private bool hasAttrkey;
 private Int32 attrkey_ = 0;
 public bool HasAttrkey {
 get { return hasAttrkey; }
 }
 public Int32 Attrkey {
 get { return attrkey_; }
 set { SetAttrkey(value); }
 }
 public void SetAttrkey(Int32 value) { 
 hasAttrkey = true;
 attrkey_ = value;
 }

public const int attrvalueFieldNumber = 2;
 private bool hasAttrvalue;
 private Int32 attrvalue_ = 0;
 public bool HasAttrvalue {
 get { return hasAttrvalue; }
 }
 public Int32 Attrvalue {
 get { return attrvalue_; }
 set { SetAttrvalue(value); }
 }
 public void SetAttrvalue(Int32 value) { 
 hasAttrvalue = true;
 attrvalue_ = value;
 }

public const int viewflagFieldNumber = 3;
 private bool hasViewflag;
 private Int32 viewflag_ = 0;
 public bool HasViewflag {
 get { return hasViewflag; }
 }
 public Int32 Viewflag {
 get { return viewflag_; }
 set { SetViewflag(value); }
 }
 public void SetViewflag(Int32 value) { 
 hasViewflag = true;
 viewflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAttrkey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Attrkey);
}
 if (HasAttrvalue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Attrvalue);
}
 if (HasViewflag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Viewflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAttrkey) {
output.WriteInt32(1, Attrkey);
}
 
if (HasAttrvalue) {
output.WriteInt32(2, Attrvalue);
}
 
if (HasViewflag) {
output.WriteInt32(3, Viewflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EquipAttr _inst = (EquipAttr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Attrkey = input.ReadInt32();
break;
}
   case  16: {
 _inst.Attrvalue = input.ReadInt32();
break;
}
   case  24: {
 _inst.Viewflag = input.ReadInt32();
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
public class EquipInfo : PacketDistributed
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

public const int bindFieldNumber = 3;
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

public const int isEquipedFieldNumber = 4;
 private bool hasIsEquiped;
 private Int32 isEquiped_ = 0;
 public bool HasIsEquiped {
 get { return hasIsEquiped; }
 }
 public Int32 IsEquiped {
 get { return isEquiped_; }
 set { SetIsEquiped(value); }
 }
 public void SetIsEquiped(Int32 value) { 
 hasIsEquiped = true;
 isEquiped_ = value;
 }

public const int equipAttrsFieldNumber = 5;
 private pbc::PopsicleList<EquipAttr> equipAttrs_ = new pbc::PopsicleList<EquipAttr>();
 public scg::IList<EquipAttr> equipAttrsList {
 get { return pbc::Lists.AsReadOnly(equipAttrs_); }
 }
 
 public int equipAttrsCount {
 get { return equipAttrs_.Count; }
 }
 
public EquipAttr GetEquipAttrs(int index) {
 return equipAttrs_[index];
 }
 public void AddEquipAttrs(EquipAttr value) {
 equipAttrs_.Add(value);
 }

public const int createNameFieldNumber = 6;
 private bool hasCreateName;
 private string createName_ = "";
 public bool HasCreateName {
 get { return hasCreateName; }
 }
 public string CreateName {
 get { return createName_; }
 set { SetCreateName(value); }
 }
 public void SetCreateName(string value) { 
 hasCreateName = true;
 createName_ = value;
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
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bind);
}
 if (HasIsEquiped) {
size += pb::CodedOutputStream.ComputeInt32Size(4, IsEquiped);
}
{
foreach (EquipAttr element in equipAttrsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasCreateName) {
size += pb::CodedOutputStream.ComputeStringSize(6, CreateName);
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
 
if (HasBind) {
output.WriteInt32(3, Bind);
}
 
if (HasIsEquiped) {
output.WriteInt32(4, IsEquiped);
}

do{
foreach (EquipAttr element in equipAttrsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasCreateName) {
output.WriteString(6, CreateName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EquipInfo _inst = (EquipInfo) _base;
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
   case  24: {
 _inst.Bind = input.ReadInt32();
break;
}
   case  32: {
 _inst.IsEquiped = input.ReadInt32();
break;
}
    case  42: {
EquipAttr subBuilder =  new EquipAttr();
input.ReadMessage(subBuilder);
_inst.AddEquipAttrs(subBuilder);
break;
}
   case  50: {
 _inst.CreateName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EquipAttr element in equipAttrsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class EquipSlots : PacketDistributed
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

public const int equipInfoFieldNumber = 2;
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

public const int levelFieldNumber = 3;
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

public const int StoneListFieldNumber = 4;
 private pbc::PopsicleList<StoneInfo> StoneList_ = new pbc::PopsicleList<StoneInfo>();
 public scg::IList<StoneInfo> StoneListList {
 get { return pbc::Lists.AsReadOnly(StoneList_); }
 }
 
 public int StoneListCount {
 get { return StoneList_.Count; }
 }
 
public StoneInfo GetStoneList(int index) {
 return StoneList_[index];
 }
 public void AddStoneList(StoneInfo value) {
 StoneList_.Add(value);
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
int subsize = EquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
}
{
foreach (StoneInfo element in StoneListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
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
output.WriteRawVarint32((uint)EquipInfo.SerializedSize());
EquipInfo.WriteTo(output);

}
 
if (HasLevel) {
output.WriteInt32(3, Level);
}

do{
foreach (StoneInfo element in StoneListList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EquipSlots _inst = (EquipSlots) _base;
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
EquipInfo subBuilder =  new EquipInfo();
 input.ReadMessage(subBuilder);
_inst.EquipInfo = subBuilder;
break;
}
   case  24: {
 _inst.Level = input.ReadInt32();
break;
}
    case  34: {
StoneInfo subBuilder =  new StoneInfo();
input.ReadMessage(subBuilder);
_inst.AddStoneList(subBuilder);
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
foreach (StoneInfo element in StoneListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCreateEquipResult : PacketDistributed
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

public const int equipInfoFieldNumber = 2;
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
int subsize = EquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)EquipInfo.SerializedSize());
EquipInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreateEquipResult _inst = (GCCreateEquipResult) _base;
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
EquipInfo subBuilder =  new EquipInfo();
 input.ReadMessage(subBuilder);
_inst.EquipInfo = subBuilder;
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
 return true;
 }

	}


[Serializable]
public class GCEquipOperateResult : PacketDistributed
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

public const int equipSlotsFieldNumber = 2;
 private pbc::PopsicleList<EquipSlots> equipSlots_ = new pbc::PopsicleList<EquipSlots>();
 public scg::IList<EquipSlots> equipSlotsList {
 get { return pbc::Lists.AsReadOnly(equipSlots_); }
 }
 
 public int equipSlotsCount {
 get { return equipSlots_.Count; }
 }
 
public EquipSlots GetEquipSlots(int index) {
 return equipSlots_[index];
 }
 public void AddEquipSlots(EquipSlots value) {
 equipSlots_.Add(value);
 }

public const int errorCodeFieldNumber = 3;
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
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
{
foreach (EquipSlots element in equipSlotsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ErrorCode);
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
foreach (EquipSlots element in equipSlotsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasErrorCode) {
output.WriteInt32(3, ErrorCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEquipOperateResult _inst = (GCEquipOperateResult) _base;
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
EquipSlots subBuilder =  new EquipSlots();
input.ReadMessage(subBuilder);
_inst.AddEquipSlots(subBuilder);
break;
}
   case  24: {
 _inst.ErrorCode = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EquipSlots element in equipSlotsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCHorseEquipOperateResult : PacketDistributed
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

public const int equipInfosFieldNumber = 2;
 private pbc::PopsicleList<EquipInfo> equipInfos_ = new pbc::PopsicleList<EquipInfo>();
 public scg::IList<EquipInfo> equipInfosList {
 get { return pbc::Lists.AsReadOnly(equipInfos_); }
 }
 
 public int equipInfosCount {
 get { return equipInfos_.Count; }
 }
 
public EquipInfo GetEquipInfos(int index) {
 return equipInfos_[index];
 }
 public void AddEquipInfos(EquipInfo value) {
 equipInfos_.Add(value);
 }

public const int errorCodeFieldNumber = 3;
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

public const int starSymsFieldNumber = 4;
 private pbc::PopsicleList<Int32> starSyms_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> starSymsList {
 get { return pbc::Lists.AsReadOnly(starSyms_); }
 }
 
 public int starSymsCount {
 get { return starSyms_.Count; }
 }
 
public Int32 GetStarSyms(int index) {
 return starSyms_[index];
 }
 public void AddStarSyms(Int32 value) {
 starSyms_.Add(value);
 }

public const int intensiveSymsFieldNumber = 5;
 private pbc::PopsicleList<Int32> intensiveSyms_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> intensiveSymsList {
 get { return pbc::Lists.AsReadOnly(intensiveSyms_); }
 }
 
 public int intensiveSymsCount {
 get { return intensiveSyms_.Count; }
 }
 
public Int32 GetIntensiveSyms(int index) {
 return intensiveSyms_[index];
 }
 public void AddIntensiveSyms(Int32 value) {
 intensiveSyms_.Add(value);
 }

public const int qualitySymsFieldNumber = 6;
 private pbc::PopsicleList<Int32> qualitySyms_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> qualitySymsList {
 get { return pbc::Lists.AsReadOnly(qualitySyms_); }
 }
 
 public int qualitySymsCount {
 get { return qualitySyms_.Count; }
 }
 
public Int32 GetQualitySyms(int index) {
 return qualitySyms_[index];
 }
 public void AddQualitySyms(Int32 value) {
 qualitySyms_.Add(value);
 }

public const int extendStateFieldNumber = 7;
 private bool hasExtendState;
 private Int32 extendState_ = 0;
 public bool HasExtendState {
 get { return hasExtendState; }
 }
 public Int32 ExtendState {
 get { return extendState_; }
 set { SetExtendState(value); }
 }
 public void SetExtendState(Int32 value) { 
 hasExtendState = true;
 extendState_ = value;
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
foreach (EquipInfo element in equipInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ErrorCode);
}
{
int dataSize = 0;
foreach (Int32 element in starSymsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * starSyms_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in intensiveSymsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * intensiveSyms_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in qualitySymsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * qualitySyms_.Count;
}
 if (HasExtendState) {
size += pb::CodedOutputStream.ComputeInt32Size(7, ExtendState);
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
foreach (EquipInfo element in equipInfosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasErrorCode) {
output.WriteInt32(3, ErrorCode);
}
{
if (starSyms_.Count > 0) {
foreach (Int32 element in starSymsList) {
output.WriteInt32(4,element);
}
}

}
{
if (intensiveSyms_.Count > 0) {
foreach (Int32 element in intensiveSymsList) {
output.WriteInt32(5,element);
}
}

}
{
if (qualitySyms_.Count > 0) {
foreach (Int32 element in qualitySymsList) {
output.WriteInt32(6,element);
}
}

}
 
if (HasExtendState) {
output.WriteInt32(7, ExtendState);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHorseEquipOperateResult _inst = (GCHorseEquipOperateResult) _base;
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
EquipInfo subBuilder =  new EquipInfo();
input.ReadMessage(subBuilder);
_inst.AddEquipInfos(subBuilder);
break;
}
   case  24: {
 _inst.ErrorCode = input.ReadInt32();
break;
}
   case  32: {
 _inst.AddStarSyms(input.ReadInt32());
break;
}
   case  40: {
 _inst.AddIntensiveSyms(input.ReadInt32());
break;
}
   case  48: {
 _inst.AddQualitySyms(input.ReadInt32());
break;
}
   case  56: {
 _inst.ExtendState = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EquipInfo element in equipInfosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendPlayerDetalitedInfo : PacketDistributed
{

public const int charAttrFieldNumber = 1;
 private pbc::PopsicleList<CharacterAttr> charAttr_ = new pbc::PopsicleList<CharacterAttr>();
 public scg::IList<CharacterAttr> charAttrList {
 get { return pbc::Lists.AsReadOnly(charAttr_); }
 }
 
 public int charAttrCount {
 get { return charAttr_.Count; }
 }
 
public CharacterAttr GetCharAttr(int index) {
 return charAttr_[index];
 }
 public void AddCharAttr(CharacterAttr value) {
 charAttr_.Add(value);
 }

public const int equipInfosFieldNumber = 2;
 private pbc::PopsicleList<EquipInfo> equipInfos_ = new pbc::PopsicleList<EquipInfo>();
 public scg::IList<EquipInfo> equipInfosList {
 get { return pbc::Lists.AsReadOnly(equipInfos_); }
 }
 
 public int equipInfosCount {
 get { return equipInfos_.Count; }
 }
 
public EquipInfo GetEquipInfos(int index) {
 return equipInfos_[index];
 }
 public void AddEquipInfos(EquipInfo value) {
 equipInfos_.Add(value);
 }

public const int gemEffectFieldNumber = 3;
 private bool hasGemEffect;
 private Int32 gemEffect_ = 0;
 public bool HasGemEffect {
 get { return hasGemEffect; }
 }
 public Int32 GemEffect {
 get { return gemEffect_; }
 set { SetGemEffect(value); }
 }
 public void SetGemEffect(Int32 value) { 
 hasGemEffect = true;
 gemEffect_ = value;
 }

public const int equipSlotsFieldNumber = 4;
 private pbc::PopsicleList<EquipSlots> equipSlots_ = new pbc::PopsicleList<EquipSlots>();
 public scg::IList<EquipSlots> equipSlotsList {
 get { return pbc::Lists.AsReadOnly(equipSlots_); }
 }
 
 public int equipSlotsCount {
 get { return equipSlots_.Count; }
 }
 
public EquipSlots GetEquipSlots(int index) {
 return equipSlots_[index];
 }
 public void AddEquipSlots(EquipSlots value) {
 equipSlots_.Add(value);
 }

public const int slotEffectFieldNumber = 5;
 private bool hasSlotEffect;
 private Int32 slotEffect_ = 0;
 public bool HasSlotEffect {
 get { return hasSlotEffect; }
 }
 public Int32 SlotEffect {
 get { return slotEffect_; }
 set { SetSlotEffect(value); }
 }
 public void SetSlotEffect(Int32 value) { 
 hasSlotEffect = true;
 slotEffect_ = value;
 }

public const int levelFieldNumber = 6;
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

public const int iconidFieldNumber = 7;
 private bool hasIconid;
 private Int32 iconid_ = 0;
 public bool HasIconid {
 get { return hasIconid; }
 }
 public Int32 Iconid {
 get { return iconid_; }
 set { SetIconid(value); }
 }
 public void SetIconid(Int32 value) { 
 hasIconid = true;
 iconid_ = value;
 }

public const int gangNameFieldNumber = 8;
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

public const int professionIdFieldNumber = 9;
 private bool hasProfessionId;
 private Int32 professionId_ = 0;
 public bool HasProfessionId {
 get { return hasProfessionId; }
 }
 public Int32 ProfessionId {
 get { return professionId_; }
 set { SetProfessionId(value); }
 }
 public void SetProfessionId(Int32 value) { 
 hasProfessionId = true;
 professionId_ = value;
 }

public const int vipLevelFieldNumber = 10;
 private bool hasVipLevel;
 private Int32 vipLevel_ = 0;
 public bool HasVipLevel {
 get { return hasVipLevel; }
 }
 public Int32 VipLevel {
 get { return vipLevel_; }
 set { SetVipLevel(value); }
 }
 public void SetVipLevel(Int32 value) { 
 hasVipLevel = true;
 vipLevel_ = value;
 }

public const int playerNameFieldNumber = 11;
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

public const int battleNumFieldNumber = 12;
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

public const int stoneSlotListFieldNumber = 13;
 private pbc::PopsicleList<StoneSlotInfo> stoneSlotList_ = new pbc::PopsicleList<StoneSlotInfo>();
 public scg::IList<StoneSlotInfo> stoneSlotListList {
 get { return pbc::Lists.AsReadOnly(stoneSlotList_); }
 }
 
 public int stoneSlotListCount {
 get { return stoneSlotList_.Count; }
 }
 
public StoneSlotInfo GetStoneSlotList(int index) {
 return stoneSlotList_[index];
 }
 public void AddStoneSlotList(StoneSlotInfo value) {
 stoneSlotList_.Add(value);
 }

public const int changeEquipInfoFieldNumber = 14;
 private bool hasChangeEquipInfo;
 private ChangeEquipInfo changeEquipInfo_ =  new ChangeEquipInfo();
 public bool HasChangeEquipInfo {
 get { return hasChangeEquipInfo; }
 }
 public ChangeEquipInfo ChangeEquipInfo {
 get { return changeEquipInfo_; }
 set { SetChangeEquipInfo(value); }
 }
 public void SetChangeEquipInfo(ChangeEquipInfo value) { 
 hasChangeEquipInfo = true;
 changeEquipInfo_ = value;
 }

public const int playerIDFieldNumber = 15;
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

public const int vipNameFieldNumber = 16;
 private bool hasVipName;
 private string vipName_ = "";
 public bool HasVipName {
 get { return hasVipName; }
 }
 public string VipName {
 get { return vipName_; }
 set { SetVipName(value); }
 }
 public void SetVipName(string value) { 
 hasVipName = true;
 vipName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (CharacterAttr element in charAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (EquipInfo element in equipInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasGemEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GemEffect);
}
{
foreach (EquipSlots element in equipSlotsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSlotEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(5, SlotEffect);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Level);
}
 if (HasIconid) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Iconid);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(8, GangName);
}
 if (HasProfessionId) {
size += pb::CodedOutputStream.ComputeInt32Size(9, ProfessionId);
}
 if (HasVipLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(10, VipLevel);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(11, PlayerName);
}
 if (HasBattleNum) {
size += pb::CodedOutputStream.ComputeInt32Size(12, BattleNum);
}
{
foreach (StoneSlotInfo element in stoneSlotListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)13) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = ChangeEquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)14) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(15, PlayerID);
}
 if (HasVipName) {
size += pb::CodedOutputStream.ComputeStringSize(16, VipName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (CharacterAttr element in charAttrList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (EquipInfo element in equipInfosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasGemEffect) {
output.WriteInt32(3, GemEffect);
}

do{
foreach (EquipSlots element in equipSlotsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSlotEffect) {
output.WriteInt32(5, SlotEffect);
}
 
if (HasLevel) {
output.WriteInt32(6, Level);
}
 
if (HasIconid) {
output.WriteInt32(7, Iconid);
}
 
if (HasGangName) {
output.WriteString(8, GangName);
}
 
if (HasProfessionId) {
output.WriteInt32(9, ProfessionId);
}
 
if (HasVipLevel) {
output.WriteInt32(10, VipLevel);
}
 
if (HasPlayerName) {
output.WriteString(11, PlayerName);
}
 
if (HasBattleNum) {
output.WriteInt32(12, BattleNum);
}

do{
foreach (StoneSlotInfo element in stoneSlotListList) {
output.WriteTag((int)13, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)14, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ChangeEquipInfo.SerializedSize());
ChangeEquipInfo.WriteTo(output);

}
 
if (HasPlayerID) {
output.WriteInt64(15, PlayerID);
}
 
if (HasVipName) {
output.WriteString(16, VipName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendPlayerDetalitedInfo _inst = (GCSendPlayerDetalitedInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterAttr subBuilder =  new CharacterAttr();
input.ReadMessage(subBuilder);
_inst.AddCharAttr(subBuilder);
break;
}
    case  18: {
EquipInfo subBuilder =  new EquipInfo();
input.ReadMessage(subBuilder);
_inst.AddEquipInfos(subBuilder);
break;
}
   case  24: {
 _inst.GemEffect = input.ReadInt32();
break;
}
    case  34: {
EquipSlots subBuilder =  new EquipSlots();
input.ReadMessage(subBuilder);
_inst.AddEquipSlots(subBuilder);
break;
}
   case  40: {
 _inst.SlotEffect = input.ReadInt32();
break;
}
   case  48: {
 _inst.Level = input.ReadInt32();
break;
}
   case  56: {
 _inst.Iconid = input.ReadInt32();
break;
}
   case  66: {
 _inst.GangName = input.ReadString();
break;
}
   case  72: {
 _inst.ProfessionId = input.ReadInt32();
break;
}
   case  80: {
 _inst.VipLevel = input.ReadInt32();
break;
}
   case  90: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  96: {
 _inst.BattleNum = input.ReadInt32();
break;
}
    case  106: {
StoneSlotInfo subBuilder =  new StoneSlotInfo();
input.ReadMessage(subBuilder);
_inst.AddStoneSlotList(subBuilder);
break;
}
    case  114: {
ChangeEquipInfo subBuilder =  new ChangeEquipInfo();
 input.ReadMessage(subBuilder);
_inst.ChangeEquipInfo = subBuilder;
break;
}
   case  120: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  130: {
 _inst.VipName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CharacterAttr element in charAttrList) {
if (!element.IsInitialized()) return false;
}
foreach (EquipInfo element in equipInfosList) {
if (!element.IsInitialized()) return false;
}
foreach (EquipSlots element in equipSlotsList) {
if (!element.IsInitialized()) return false;
}
foreach (StoneSlotInfo element in stoneSlotListList) {
if (!element.IsInitialized()) return false;
}
  if (HasChangeEquipInfo) {
if (!ChangeEquipInfo.IsInitialized()) return false;
}
 return true;
 }

	}


}
