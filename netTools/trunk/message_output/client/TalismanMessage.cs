//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCreateTalisman : PacketDistributed
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
 CGCreateTalisman _inst = (CGCreateTalisman) _base;
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
public class CGResolveTalisman : PacketDistributed
{

public const int talismanIDListFieldNumber = 1;
 private pbc::PopsicleList<Int64> talismanIDList_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> talismanIDListList {
 get { return pbc::Lists.AsReadOnly(talismanIDList_); }
 }
 
 public int talismanIDListCount {
 get { return talismanIDList_.Count; }
 }
 
public Int64 GetTalismanIDList(int index) {
 return talismanIDList_[index];
 }
 public void AddTalismanIDList(Int64 value) {
 talismanIDList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in talismanIDListList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * talismanIDList_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (talismanIDList_.Count > 0) {
foreach (Int64 element in talismanIDListList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGResolveTalisman _inst = (CGResolveTalisman) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddTalismanIDList(input.ReadInt64());
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
public class CGTalismanOperate : PacketDistributed
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTalismanOperate _inst = (CGTalismanOperate) _base;
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
public class GCCreateTalismanResult : PacketDistributed
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

public const int talismanInfoFieldNumber = 2;
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
int subsize = TalismanInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)TalismanInfo.SerializedSize());
TalismanInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreateTalismanResult _inst = (GCCreateTalismanResult) _base;
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
TalismanInfo subBuilder =  new TalismanInfo();
 input.ReadMessage(subBuilder);
_inst.TalismanInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTalismanInfo) {
if (!TalismanInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCResolveTalismanResult : PacketDistributed
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

public const int talismanIDListFieldNumber = 2;
 private pbc::PopsicleList<Int64> talismanIDList_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> talismanIDListList {
 get { return pbc::Lists.AsReadOnly(talismanIDList_); }
 }
 
 public int talismanIDListCount {
 get { return talismanIDList_.Count; }
 }
 
public Int64 GetTalismanIDList(int index) {
 return talismanIDList_[index];
 }
 public void AddTalismanIDList(Int64 value) {
 talismanIDList_.Add(value);
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
int dataSize = 0;
foreach (Int64 element in talismanIDListList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * talismanIDList_.Count;
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
if (talismanIDList_.Count > 0) {
foreach (Int64 element in talismanIDListList) {
output.WriteInt64(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCResolveTalismanResult _inst = (GCResolveTalismanResult) _base;
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
 _inst.AddTalismanIDList(input.ReadInt64());
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
public class GCTalismanOperateResult : PacketDistributed
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

public const int resultFieldNumber = 2;
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

public const int talismanSlotsFieldNumber = 3;
 private pbc::PopsicleList<TalismanSlots> talismanSlots_ = new pbc::PopsicleList<TalismanSlots>();
 public scg::IList<TalismanSlots> talismanSlotsList {
 get { return pbc::Lists.AsReadOnly(talismanSlots_); }
 }
 
 public int talismanSlotsCount {
 get { return talismanSlots_.Count; }
 }
 
public TalismanSlots GetTalismanSlots(int index) {
 return talismanSlots_[index];
 }
 public void AddTalismanSlots(TalismanSlots value) {
 talismanSlots_.Add(value);
 }

public const int talismanInfoFieldNumber = 4;
 private pbc::PopsicleList<TalismanInfo> talismanInfo_ = new pbc::PopsicleList<TalismanInfo>();
 public scg::IList<TalismanInfo> talismanInfoList {
 get { return pbc::Lists.AsReadOnly(talismanInfo_); }
 }
 
 public int talismanInfoCount {
 get { return talismanInfo_.Count; }
 }
 
public TalismanInfo GetTalismanInfo(int index) {
 return talismanInfo_[index];
 }
 public void AddTalismanInfo(TalismanInfo value) {
 talismanInfo_.Add(value);
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
foreach (TalismanSlots element in talismanSlotsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (TalismanInfo element in talismanInfoList) {
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
  
if (HasOperate) {
output.WriteInt32(1, Operate);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}

do{
foreach (TalismanSlots element in talismanSlotsList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (TalismanInfo element in talismanInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCTalismanOperateResult _inst = (GCTalismanOperateResult) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
TalismanSlots subBuilder =  new TalismanSlots();
input.ReadMessage(subBuilder);
_inst.AddTalismanSlots(subBuilder);
break;
}
    case  34: {
TalismanInfo subBuilder =  new TalismanInfo();
input.ReadMessage(subBuilder);
_inst.AddTalismanInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TalismanSlots element in talismanSlotsList) {
if (!element.IsInitialized()) return false;
}
foreach (TalismanInfo element in talismanInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TalismanAttr : PacketDistributed
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
 TalismanAttr _inst = (TalismanAttr) _base;
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
public class TalismanInfo : PacketDistributed
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

public const int talismanAttrFieldNumber = 3;
 private pbc::PopsicleList<TalismanAttr> talismanAttr_ = new pbc::PopsicleList<TalismanAttr>();
 public scg::IList<TalismanAttr> talismanAttrList {
 get { return pbc::Lists.AsReadOnly(talismanAttr_); }
 }
 
 public int talismanAttrCount {
 get { return talismanAttr_.Count; }
 }
 
public TalismanAttr GetTalismanAttr(int index) {
 return talismanAttr_[index];
 }
 public void AddTalismanAttr(TalismanAttr value) {
 talismanAttr_.Add(value);
 }

public const int createNameFieldNumber = 4;
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
{
foreach (TalismanAttr element in talismanAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasCreateName) {
size += pb::CodedOutputStream.ComputeStringSize(4, CreateName);
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

do{
foreach (TalismanAttr element in talismanAttrList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasCreateName) {
output.WriteString(4, CreateName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TalismanInfo _inst = (TalismanInfo) _base;
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
TalismanAttr subBuilder =  new TalismanAttr();
input.ReadMessage(subBuilder);
_inst.AddTalismanAttr(subBuilder);
break;
}
   case  34: {
 _inst.CreateName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TalismanAttr element in talismanAttrList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TalismanSlots : PacketDistributed
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
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
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
 
if (HasLevel) {
output.WriteInt32(3, Level);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TalismanSlots _inst = (TalismanSlots) _base;
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
   case  24: {
 _inst.Level = input.ReadInt32();
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
public class TalismanSlotsLook : PacketDistributed
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

public const int talisInfoFieldNumber = 2;
 private bool hasTalisInfo;
 private TalismanInfo talisInfo_ =  new TalismanInfo();
 public bool HasTalisInfo {
 get { return hasTalisInfo; }
 }
 public TalismanInfo TalisInfo {
 get { return talisInfo_; }
 set { SetTalisInfo(value); }
 }
 public void SetTalisInfo(TalismanInfo value) { 
 hasTalisInfo = true;
 talisInfo_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGridID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GridID);
}
{
int subsize = TalisInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TalisInfo.SerializedSize());
TalisInfo.WriteTo(output);

}
 
if (HasLevel) {
output.WriteInt32(3, Level);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TalismanSlotsLook _inst = (TalismanSlotsLook) _base;
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
    case  18: {
TalismanInfo subBuilder =  new TalismanInfo();
 input.ReadMessage(subBuilder);
_inst.TalisInfo = subBuilder;
break;
}
   case  24: {
 _inst.Level = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTalisInfo) {
if (!TalisInfo.IsInitialized()) return false;
}
 return true;
 }

	}


}
