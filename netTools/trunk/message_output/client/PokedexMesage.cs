//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetPokedex : PacketDistributed
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

public const int idFieldNumber = 3;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerId);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Id);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasId) {
output.WriteInt32(3, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetPokedex _inst = (CGGetPokedex) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Id = input.ReadInt32();
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
public class GCGetPokedexList : PacketDistributed
{

public const int lastTimeFieldNumber = 1;
 private bool hasLastTime;
 private Int64 lastTime_ = 0;
 public bool HasLastTime {
 get { return hasLastTime; }
 }
 public Int64 LastTime {
 get { return lastTime_; }
 set { SetLastTime(value); }
 }
 public void SetLastTime(Int64 value) { 
 hasLastTime = true;
 lastTime_ = value;
 }

public const int restNumFieldNumber = 2;
 private bool hasRestNum;
 private Int32 restNum_ = 0;
 public bool HasRestNum {
 get { return hasRestNum; }
 }
 public Int32 RestNum {
 get { return restNum_; }
 set { SetRestNum(value); }
 }
 public void SetRestNum(Int32 value) { 
 hasRestNum = true;
 restNum_ = value;
 }

public const int restNumKimFieldNumber = 3;
 private bool hasRestNumKim;
 private Int32 restNumKim_ = 0;
 public bool HasRestNumKim {
 get { return hasRestNumKim; }
 }
 public Int32 RestNumKim {
 get { return restNumKim_; }
 set { SetRestNumKim(value); }
 }
 public void SetRestNumKim(Int32 value) { 
 hasRestNumKim = true;
 restNumKim_ = value;
 }

public const int typeFieldNumber = 4;
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

public const int pokedexsFieldNumber = 5;
 private pbc::PopsicleList<PokedexSimpleInfo> pokedexs_ = new pbc::PopsicleList<PokedexSimpleInfo>();
 public scg::IList<PokedexSimpleInfo> pokedexsList {
 get { return pbc::Lists.AsReadOnly(pokedexs_); }
 }
 
 public int pokedexsCount {
 get { return pokedexs_.Count; }
 }
 
public PokedexSimpleInfo GetPokedexs(int index) {
 return pokedexs_[index];
 }
 public void AddPokedexs(PokedexSimpleInfo value) {
 pokedexs_.Add(value);
 }

public const int resultFieldNumber = 6;
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

public const int newIdFieldNumber = 7;
 private bool hasNewId;
 private Int32 newId_ = 0;
 public bool HasNewId {
 get { return hasNewId; }
 }
 public Int32 NewId {
 get { return newId_; }
 set { SetNewId(value); }
 }
 public void SetNewId(Int32 value) { 
 hasNewId = true;
 newId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLastTime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, LastTime);
}
 if (HasRestNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RestNum);
}
 if (HasRestNumKim) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RestNumKim);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Type);
}
{
foreach (PokedexSimpleInfo element in pokedexsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Result);
}
 if (HasNewId) {
size += pb::CodedOutputStream.ComputeInt32Size(7, NewId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLastTime) {
output.WriteInt64(1, LastTime);
}
 
if (HasRestNum) {
output.WriteInt32(2, RestNum);
}
 
if (HasRestNumKim) {
output.WriteInt32(3, RestNumKim);
}
 
if (HasType) {
output.WriteInt32(4, Type);
}

do{
foreach (PokedexSimpleInfo element in pokedexsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasResult) {
output.WriteInt32(6, Result);
}
 
if (HasNewId) {
output.WriteInt32(7, NewId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetPokedexList _inst = (GCGetPokedexList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.LastTime = input.ReadInt64();
break;
}
   case  16: {
 _inst.RestNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.RestNumKim = input.ReadInt32();
break;
}
   case  32: {
 _inst.Type = input.ReadInt32();
break;
}
    case  42: {
PokedexSimpleInfo subBuilder =  new PokedexSimpleInfo();
input.ReadMessage(subBuilder);
_inst.AddPokedexs(subBuilder);
break;
}
   case  48: {
 _inst.Result = input.ReadInt32();
break;
}
   case  56: {
 _inst.NewId = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PokedexSimpleInfo element in pokedexsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class PokedexSimpleInfo : PacketDistributed
{

public const int pokedexSimpleInfoIdFieldNumber = 1;
 private bool hasPokedexSimpleInfoId;
 private Int32 pokedexSimpleInfoId_ = 0;
 public bool HasPokedexSimpleInfoId {
 get { return hasPokedexSimpleInfoId; }
 }
 public Int32 PokedexSimpleInfoId {
 get { return pokedexSimpleInfoId_; }
 set { SetPokedexSimpleInfoId(value); }
 }
 public void SetPokedexSimpleInfoId(Int32 value) { 
 hasPokedexSimpleInfoId = true;
 pokedexSimpleInfoId_ = value;
 }

public const int pokedexSimpleInfoLevelFieldNumber = 2;
 private bool hasPokedexSimpleInfoLevel;
 private Int32 pokedexSimpleInfoLevel_ = 0;
 public bool HasPokedexSimpleInfoLevel {
 get { return hasPokedexSimpleInfoLevel; }
 }
 public Int32 PokedexSimpleInfoLevel {
 get { return pokedexSimpleInfoLevel_; }
 set { SetPokedexSimpleInfoLevel(value); }
 }
 public void SetPokedexSimpleInfoLevel(Int32 value) { 
 hasPokedexSimpleInfoLevel = true;
 pokedexSimpleInfoLevel_ = value;
 }

public const int pokedexSimpleInfoValueFieldNumber = 3;
 private bool hasPokedexSimpleInfoValue;
 private Int32 pokedexSimpleInfoValue_ = 0;
 public bool HasPokedexSimpleInfoValue {
 get { return hasPokedexSimpleInfoValue; }
 }
 public Int32 PokedexSimpleInfoValue {
 get { return pokedexSimpleInfoValue_; }
 set { SetPokedexSimpleInfoValue(value); }
 }
 public void SetPokedexSimpleInfoValue(Int32 value) { 
 hasPokedexSimpleInfoValue = true;
 pokedexSimpleInfoValue_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPokedexSimpleInfoId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, PokedexSimpleInfoId);
}
 if (HasPokedexSimpleInfoLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PokedexSimpleInfoLevel);
}
 if (HasPokedexSimpleInfoValue) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PokedexSimpleInfoValue);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPokedexSimpleInfoId) {
output.WriteInt32(1, PokedexSimpleInfoId);
}
 
if (HasPokedexSimpleInfoLevel) {
output.WriteInt32(2, PokedexSimpleInfoLevel);
}
 
if (HasPokedexSimpleInfoValue) {
output.WriteInt32(3, PokedexSimpleInfoValue);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PokedexSimpleInfo _inst = (PokedexSimpleInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PokedexSimpleInfoId = input.ReadInt32();
break;
}
   case  16: {
 _inst.PokedexSimpleInfoLevel = input.ReadInt32();
break;
}
   case  24: {
 _inst.PokedexSimpleInfoValue = input.ReadInt32();
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
