//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGFateOperate : PacketDistributed
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

public const int idFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Id);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
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
 
if (HasId) {
output.WriteInt32(2, Id);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGFateOperate _inst = (CGFateOperate) _base;
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
 _inst.Id = input.ReadInt32();
break;
}
   case  24: {
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
public class FateInfo : PacketDistributed
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

public const int levelFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Level);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
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
 
if (HasLevel) {
output.WriteInt32(2, Level);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FateInfo _inst = (FateInfo) _base;
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
 _inst.Level = input.ReadInt32();
break;
}
   case  24: {
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
public class GCFateResult : PacketDistributed
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

public const int symInfosFieldNumber = 2;
 private pbc::PopsicleList<SymInfo> symInfos_ = new pbc::PopsicleList<SymInfo>();
 public scg::IList<SymInfo> symInfosList {
 get { return pbc::Lists.AsReadOnly(symInfos_); }
 }
 
 public int symInfosCount {
 get { return symInfos_.Count; }
 }
 
public SymInfo GetSymInfos(int index) {
 return symInfos_[index];
 }
 public void AddSymInfos(SymInfo value) {
 symInfos_.Add(value);
 }

public const int fateInfosFieldNumber = 3;
 private pbc::PopsicleList<FateInfo> fateInfos_ = new pbc::PopsicleList<FateInfo>();
 public scg::IList<FateInfo> fateInfosList {
 get { return pbc::Lists.AsReadOnly(fateInfos_); }
 }
 
 public int fateInfosCount {
 get { return fateInfos_.Count; }
 }
 
public FateInfo GetFateInfos(int index) {
 return fateInfos_[index];
 }
 public void AddFateInfos(FateInfo value) {
 fateInfos_.Add(value);
 }

public const int markItemsFieldNumber = 4;
 private pbc::PopsicleList<BackpackItem> markItems_ = new pbc::PopsicleList<BackpackItem>();
 public scg::IList<BackpackItem> markItemsList {
 get { return pbc::Lists.AsReadOnly(markItems_); }
 }
 
 public int markItemsCount {
 get { return markItems_.Count; }
 }
 
public BackpackItem GetMarkItems(int index) {
 return markItems_[index];
 }
 public void AddMarkItems(BackpackItem value) {
 markItems_.Add(value);
 }

public const int transtTypeFieldNumber = 5;
 private bool hasTranstType;
 private Int32 transtType_ = 0;
 public bool HasTranstType {
 get { return hasTranstType; }
 }
 public Int32 TranstType {
 get { return transtType_; }
 set { SetTranstType(value); }
 }
 public void SetTranstType(Int32 value) { 
 hasTranstType = true;
 transtType_ = value;
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
foreach (SymInfo element in symInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (FateInfo element in fateInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (BackpackItem element in markItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasTranstType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TranstType);
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
foreach (SymInfo element in symInfosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (FateInfo element in fateInfosList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (BackpackItem element in markItemsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasTranstType) {
output.WriteInt32(5, TranstType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFateResult _inst = (GCFateResult) _base;
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
SymInfo subBuilder =  new SymInfo();
input.ReadMessage(subBuilder);
_inst.AddSymInfos(subBuilder);
break;
}
    case  26: {
FateInfo subBuilder =  new FateInfo();
input.ReadMessage(subBuilder);
_inst.AddFateInfos(subBuilder);
break;
}
    case  34: {
BackpackItem subBuilder =  new BackpackItem();
input.ReadMessage(subBuilder);
_inst.AddMarkItems(subBuilder);
break;
}
   case  40: {
 _inst.TranstType = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SymInfo element in symInfosList) {
if (!element.IsInitialized()) return false;
}
foreach (FateInfo element in fateInfosList) {
if (!element.IsInitialized()) return false;
}
foreach (BackpackItem element in markItemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SymInfo : PacketDistributed
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

public const int symIdFieldNumber = 2;
 private bool hasSymId;
 private Int32 symId_ = 0;
 public bool HasSymId {
 get { return hasSymId; }
 }
 public Int32 SymId {
 get { return symId_; }
 set { SetSymId(value); }
 }
 public void SetSymId(Int32 value) { 
 hasSymId = true;
 symId_ = value;
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
 if (HasSymId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SymId);
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
 
if (HasSymId) {
output.WriteInt32(2, SymId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SymInfo _inst = (SymInfo) _base;
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
 _inst.SymId = input.ReadInt32();
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
