//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGStone : PacketDistributed
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

public const int slotIdFieldNumber = 2;
 private bool hasSlotId;
 private Int32 slotId_ = 0;
 public bool HasSlotId {
 get { return hasSlotId; }
 }
 public Int32 SlotId {
 get { return slotId_; }
 set { SetSlotId(value); }
 }
 public void SetSlotId(Int32 value) { 
 hasSlotId = true;
 slotId_ = value;
 }

public const int holeIdFieldNumber = 3;
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

public const int templateIdFieldNumber = 4;
 private bool hasTemplateId;
 private Int32 templateId_ = 0;
 public bool HasTemplateId {
 get { return hasTemplateId; }
 }
 public Int32 TemplateId {
 get { return templateId_; }
 set { SetTemplateId(value); }
 }
 public void SetTemplateId(Int32 value) { 
 hasTemplateId = true;
 templateId_ = value;
 }

public const int addBindFieldNumber = 5;
 private bool hasAddBind;
 private Int32 addBind_ = 0;
 public bool HasAddBind {
 get { return hasAddBind; }
 }
 public Int32 AddBind {
 get { return addBind_; }
 set { SetAddBind(value); }
 }
 public void SetAddBind(Int32 value) { 
 hasAddBind = true;
 addBind_ = value;
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
 if (HasSlotId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SlotId);
}
 if (HasHoleId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, HoleId);
}
 if (HasTemplateId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TemplateId);
}
 if (HasAddBind) {
size += pb::CodedOutputStream.ComputeInt32Size(5, AddBind);
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
 
if (HasSlotId) {
output.WriteInt32(2, SlotId);
}
 
if (HasHoleId) {
output.WriteInt32(3, HoleId);
}
 
if (HasTemplateId) {
output.WriteInt32(4, TemplateId);
}
 
if (HasAddBind) {
output.WriteInt32(5, AddBind);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGStone _inst = (CGStone) _base;
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
 _inst.SlotId = input.ReadInt32();
break;
}
   case  24: {
 _inst.HoleId = input.ReadInt32();
break;
}
   case  32: {
 _inst.TemplateId = input.ReadInt32();
break;
}
   case  40: {
 _inst.AddBind = input.ReadInt32();
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
public class GCStone : PacketDistributed
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

public const int stoneSlotListFieldNumber = 2;
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

public const int gemSymsFieldNumber = 4;
 private pbc::PopsicleList<Int32> gemSyms_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> gemSymsList {
 get { return pbc::Lists.AsReadOnly(gemSyms_); }
 }
 
 public int gemSymsCount {
 get { return gemSyms_.Count; }
 }
 
public Int32 GetGemSyms(int index) {
 return gemSyms_[index];
 }
 public void AddGemSyms(Int32 value) {
 gemSyms_.Add(value);
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
foreach (StoneSlotInfo element in stoneSlotListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ErrorCode);
}
{
int dataSize = 0;
foreach (Int32 element in gemSymsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * gemSyms_.Count;
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

do{
foreach (StoneSlotInfo element in stoneSlotListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasErrorCode) {
output.WriteInt32(3, ErrorCode);
}
{
if (gemSyms_.Count > 0) {
foreach (Int32 element in gemSymsList) {
output.WriteInt32(4,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCStone _inst = (GCStone) _base;
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
StoneSlotInfo subBuilder =  new StoneSlotInfo();
input.ReadMessage(subBuilder);
_inst.AddStoneSlotList(subBuilder);
break;
}
   case  24: {
 _inst.ErrorCode = input.ReadInt32();
break;
}
   case  32: {
 _inst.AddGemSyms(input.ReadInt32());
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (StoneSlotInfo element in stoneSlotListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class StoneInfo : PacketDistributed
{

public const int holeIdFieldNumber = 1;
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

public const int templateIdFieldNumber = 2;
 private bool hasTemplateId;
 private Int32 templateId_ = 0;
 public bool HasTemplateId {
 get { return hasTemplateId; }
 }
 public Int32 TemplateId {
 get { return templateId_; }
 set { SetTemplateId(value); }
 }
 public void SetTemplateId(Int32 value) { 
 hasTemplateId = true;
 templateId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHoleId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, HoleId);
}
 if (HasTemplateId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TemplateId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHoleId) {
output.WriteInt32(1, HoleId);
}
 
if (HasTemplateId) {
output.WriteInt32(2, TemplateId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 StoneInfo _inst = (StoneInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.HoleId = input.ReadInt32();
break;
}
   case  16: {
 _inst.TemplateId = input.ReadInt32();
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
public class StoneSlotInfo : PacketDistributed
{

public const int slotIdFieldNumber = 1;
 private bool hasSlotId;
 private Int32 slotId_ = 0;
 public bool HasSlotId {
 get { return hasSlotId; }
 }
 public Int32 SlotId {
 get { return slotId_; }
 set { SetSlotId(value); }
 }
 public void SetSlotId(Int32 value) { 
 hasSlotId = true;
 slotId_ = value;
 }

public const int stoneInfoFieldNumber = 2;
 private pbc::PopsicleList<StoneInfo> stoneInfo_ = new pbc::PopsicleList<StoneInfo>();
 public scg::IList<StoneInfo> stoneInfoList {
 get { return pbc::Lists.AsReadOnly(stoneInfo_); }
 }
 
 public int stoneInfoCount {
 get { return stoneInfo_.Count; }
 }
 
public StoneInfo GetStoneInfo(int index) {
 return stoneInfo_[index];
 }
 public void AddStoneInfo(StoneInfo value) {
 stoneInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSlotId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SlotId);
}
{
foreach (StoneInfo element in stoneInfoList) {
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
  
if (HasSlotId) {
output.WriteInt32(1, SlotId);
}

do{
foreach (StoneInfo element in stoneInfoList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 StoneSlotInfo _inst = (StoneSlotInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SlotId = input.ReadInt32();
break;
}
    case  18: {
StoneInfo subBuilder =  new StoneInfo();
input.ReadMessage(subBuilder);
_inst.AddStoneInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (StoneInfo element in stoneInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
