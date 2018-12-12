//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBuyFreeBack : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuyFreeBack _inst = (CGBuyFreeBack) _base;
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
public class CGBuyLevelQuota : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuyLevelQuota _inst = (CGBuyLevelQuota) _base;
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
public class CGBuyPoints : PacketDistributed
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
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasNum) {
output.WriteInt32(2, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuyPoints _inst = (CGBuyPoints) _base;
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
public class CGCanBuy : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCanBuy _inst = (CGCanBuy) _base;
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
public class CGDoublePay : PacketDistributed
{

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGDoublePay _inst = (CGDoublePay) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
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
public class CGFeelGold : PacketDistributed
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

public const int keyFieldNumber = 3;
 private bool hasKey;
 private Int32 key_ = 0;
 public bool HasKey {
 get { return hasKey; }
 }
 public Int32 Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(Int32 value) { 
 hasKey = true;
 key_ = value;
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
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasKey) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Key);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasKey) {
output.WriteInt32(3, Key);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGFeelGold _inst = (CGFeelGold) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Key = input.ReadInt32();
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
public class CGFirstCharge : PacketDistributed
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
 CGFirstCharge _inst = (CGFirstCharge) _base;
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
public class CGGetCardReward : PacketDistributed
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
 CGGetCardReward _inst = (CGGetCardReward) _base;
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
public class CGGetRechargeDailyGiftReward : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetRechargeDailyGiftReward _inst = (CGGetRechargeDailyGiftReward) _base;
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
public class CGGetSuperRebateReward : PacketDistributed
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

public const int indexFieldNumber = 2;
 private bool hasIndex;
 private Int32 index_ = 0;
 public bool HasIndex {
 get { return hasIndex; }
 }
 public Int32 Index {
 get { return index_; }
 set { SetIndex(value); }
 }
 public void SetIndex(Int32 value) { 
 hasIndex = true;
 index_ = value;
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
 if (HasIndex) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Index);
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
 
if (HasIndex) {
output.WriteInt32(2, Index);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetSuperRebateReward _inst = (CGGetSuperRebateReward) _base;
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
 _inst.Index = input.ReadInt32();
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
public class CGGrowFund : PacketDistributed
{

public const int opTypeFieldNumber = 1;
 private bool hasOpType;
 private Int32 opType_ = 0;
 public bool HasOpType {
 get { return hasOpType; }
 }
 public Int32 OpType {
 get { return opType_; }
 set { SetOpType(value); }
 }
 public void SetOpType(Int32 value) { 
 hasOpType = true;
 opType_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOpType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OpType);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Id);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOpType) {
output.WriteInt32(1, OpType);
}
 
if (HasId) {
output.WriteInt32(2, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGrowFund _inst = (CGGrowFund) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OpType = input.ReadInt32();
break;
}
   case  16: {
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
public class CGHoliday : PacketDistributed
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

public const int keyFieldNumber = 3;
 private bool hasKey;
 private Int32 key_ = 0;
 public bool HasKey {
 get { return hasKey; }
 }
 public Int32 Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(Int32 value) { 
 hasKey = true;
 key_ = value;
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
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasKey) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Key);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasKey) {
output.WriteInt32(3, Key);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGHoliday _inst = (CGHoliday) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Key = input.ReadInt32();
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
public class CGRechargeReward : PacketDistributed
{

public const int opTypeFieldNumber = 1;
 private bool hasOpType;
 private Int32 opType_ = 0;
 public bool HasOpType {
 get { return hasOpType; }
 }
 public Int32 OpType {
 get { return opType_; }
 set { SetOpType(value); }
 }
 public void SetOpType(Int32 value) { 
 hasOpType = true;
 opType_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOpType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OpType);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Id);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOpType) {
output.WriteInt32(1, OpType);
}
 
if (HasId) {
output.WriteInt32(2, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGRechargeReward _inst = (CGRechargeReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OpType = input.ReadInt32();
break;
}
   case  16: {
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
public class CGSevenDaysHappy : PacketDistributed
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

public const int dayFieldNumber = 2;
 private bool hasDay;
 private Int32 day_ = 0;
 public bool HasDay {
 get { return hasDay; }
 }
 public Int32 Day {
 get { return day_; }
 set { SetDay(value); }
 }
 public void SetDay(Int32 value) { 
 hasDay = true;
 day_ = value;
 }

public const int tblIdFieldNumber = 3;
 private bool hasTblId;
 private Int32 tblId_ = 0;
 public bool HasTblId {
 get { return hasTblId; }
 }
 public Int32 TblId {
 get { return tblId_; }
 set { SetTblId(value); }
 }
 public void SetTblId(Int32 value) { 
 hasTblId = true;
 tblId_ = value;
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
 if (HasDay) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Day);
}
 if (HasTblId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TblId);
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
 
if (HasDay) {
output.WriteInt32(2, Day);
}
 
if (HasTblId) {
output.WriteInt32(3, TblId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSevenDaysHappy _inst = (CGSevenDaysHappy) _base;
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
 _inst.Day = input.ReadInt32();
break;
}
   case  24: {
 _inst.TblId = input.ReadInt32();
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
public class CGSignin : PacketDistributed
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

public const int temIdFieldNumber = 2;
 private bool hasTemId;
 private Int32 temId_ = 0;
 public bool HasTemId {
 get { return hasTemId; }
 }
 public Int32 TemId {
 get { return temId_; }
 set { SetTemId(value); }
 }
 public void SetTemId(Int32 value) { 
 hasTemId = true;
 temId_ = value;
 }

public const int indexIdFieldNumber = 3;
 private bool hasIndexId;
 private Int32 indexId_ = 0;
 public bool HasIndexId {
 get { return hasIndexId; }
 }
 public Int32 IndexId {
 get { return indexId_; }
 set { SetIndexId(value); }
 }
 public void SetIndexId(Int32 value) { 
 hasIndexId = true;
 indexId_ = value;
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
 if (HasTemId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TemId);
}
 if (HasIndexId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, IndexId);
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
 
if (HasTemId) {
output.WriteInt32(2, TemId);
}
 
if (HasIndexId) {
output.WriteInt32(3, IndexId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSignin _inst = (CGSignin) _base;
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
 _inst.TemId = input.ReadInt32();
break;
}
   case  24: {
 _inst.IndexId = input.ReadInt32();
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
public class CardRewardData : PacketDistributed
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

public const int statusFieldNumber = 2;
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

public const int dayFieldNumber = 3;
 private bool hasDay;
 private Int32 day_ = 0;
 public bool HasDay {
 get { return hasDay; }
 }
 public Int32 Day {
 get { return day_; }
 set { SetDay(value); }
 }
 public void SetDay(Int32 value) { 
 hasDay = true;
 day_ = value;
 }

public const int chargeIdFieldNumber = 4;
 private bool hasChargeId;
 private Int32 chargeId_ = 0;
 public bool HasChargeId {
 get { return hasChargeId; }
 }
 public Int32 ChargeId {
 get { return chargeId_; }
 set { SetChargeId(value); }
 }
 public void SetChargeId(Int32 value) { 
 hasChargeId = true;
 chargeId_ = value;
 }

public const int getStatusFieldNumber = 5;
 private bool hasGetStatus;
 private Int32 getStatus_ = 0;
 public bool HasGetStatus {
 get { return hasGetStatus; }
 }
 public Int32 GetStatus {
 get { return getStatus_; }
 set { SetGetStatus(value); }
 }
 public void SetGetStatus(Int32 value) { 
 hasGetStatus = true;
 getStatus_ = value;
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 if (HasDay) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Day);
}
 if (HasChargeId) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ChargeId);
}
 if (HasGetStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(5, GetStatus);
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 
if (HasDay) {
output.WriteInt32(3, Day);
}
 
if (HasChargeId) {
output.WriteInt32(4, ChargeId);
}
 
if (HasGetStatus) {
output.WriteInt32(5, GetStatus);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CardRewardData _inst = (CardRewardData) _base;
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
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.Day = input.ReadInt32();
break;
}
   case  32: {
 _inst.ChargeId = input.ReadInt32();
break;
}
   case  40: {
 _inst.GetStatus = input.ReadInt32();
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
public class FreeBackInfo : PacketDistributed
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

public const int itemShopFieldNumber = 2;
 private bool hasItemShop;
 private string itemShop_ = "";
 public bool HasItemShop {
 get { return hasItemShop; }
 }
 public string ItemShop {
 get { return itemShop_; }
 set { SetItemShop(value); }
 }
 public void SetItemShop(string value) { 
 hasItemShop = true;
 itemShop_ = value;
 }

public const int showPriceFieldNumber = 3;
 private bool hasShowPrice;
 private string showPrice_ = "";
 public bool HasShowPrice {
 get { return hasShowPrice; }
 }
 public string ShowPrice {
 get { return showPrice_; }
 set { SetShowPrice(value); }
 }
 public void SetShowPrice(string value) { 
 hasShowPrice = true;
 showPrice_ = value;
 }

public const int sellPriceFieldNumber = 4;
 private bool hasSellPrice;
 private string sellPrice_ = "";
 public bool HasSellPrice {
 get { return hasSellPrice; }
 }
 public string SellPrice {
 get { return sellPrice_; }
 set { SetSellPrice(value); }
 }
 public void SetSellPrice(string value) { 
 hasSellPrice = true;
 sellPrice_ = value;
 }

public const int chargeIDFieldNumber = 5;
 private bool hasChargeID;
 private string chargeID_ = "";
 public bool HasChargeID {
 get { return hasChargeID; }
 }
 public string ChargeID {
 get { return chargeID_; }
 set { SetChargeID(value); }
 }
 public void SetChargeID(string value) { 
 hasChargeID = true;
 chargeID_ = value;
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
 if (HasItemShop) {
size += pb::CodedOutputStream.ComputeStringSize(2, ItemShop);
}
 if (HasShowPrice) {
size += pb::CodedOutputStream.ComputeStringSize(3, ShowPrice);
}
 if (HasSellPrice) {
size += pb::CodedOutputStream.ComputeStringSize(4, SellPrice);
}
 if (HasChargeID) {
size += pb::CodedOutputStream.ComputeStringSize(5, ChargeID);
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
 
if (HasItemShop) {
output.WriteString(2, ItemShop);
}
 
if (HasShowPrice) {
output.WriteString(3, ShowPrice);
}
 
if (HasSellPrice) {
output.WriteString(4, SellPrice);
}
 
if (HasChargeID) {
output.WriteString(5, ChargeID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FreeBackInfo _inst = (FreeBackInfo) _base;
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
 _inst.ItemShop = input.ReadString();
break;
}
   case  26: {
 _inst.ShowPrice = input.ReadString();
break;
}
   case  34: {
 _inst.SellPrice = input.ReadString();
break;
}
   case  42: {
 _inst.ChargeID = input.ReadString();
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
public class GCCanBuyBack : PacketDistributed
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
 GCCanBuyBack _inst = (GCCanBuyBack) _base;
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
public class GCDailyGiftInfo : PacketDistributed
{

public const int dailyGiftListFieldNumber = 1;
 private pbc::PopsicleList<Int32> dailyGiftList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> dailyGiftListList {
 get { return pbc::Lists.AsReadOnly(dailyGiftList_); }
 }
 
 public int dailyGiftListCount {
 get { return dailyGiftList_.Count; }
 }
 
public Int32 GetDailyGiftList(int index) {
 return dailyGiftList_[index];
 }
 public void AddDailyGiftList(Int32 value) {
 dailyGiftList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in dailyGiftListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * dailyGiftList_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (dailyGiftList_.Count > 0) {
foreach (Int32 element in dailyGiftListList) {
output.WriteInt32(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDailyGiftInfo _inst = (GCDailyGiftInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddDailyGiftList(input.ReadInt32());
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
public class GCDoublePay : PacketDistributed
{

public const int payIdListFieldNumber = 1;
 private pbc::PopsicleList<Int32> payIdList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> payIdListList {
 get { return pbc::Lists.AsReadOnly(payIdList_); }
 }
 
 public int payIdListCount {
 get { return payIdList_.Count; }
 }
 
public Int32 GetPayIdList(int index) {
 return payIdList_[index];
 }
 public void AddPayIdList(Int32 value) {
 payIdList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in payIdListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * payIdList_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (payIdList_.Count > 0) {
foreach (Int32 element in payIdListList) {
output.WriteInt32(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDoublePay _inst = (GCDoublePay) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddPayIdList(input.ReadInt32());
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
public class GCFeelGold : PacketDistributed
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

public const int resultFieldNumber = 3;
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

public const int lastCountFieldNumber = 4;
 private bool hasLastCount;
 private Int32 lastCount_ = 0;
 public bool HasLastCount {
 get { return hasLastCount; }
 }
 public Int32 LastCount {
 get { return lastCount_; }
 set { SetLastCount(value); }
 }
 public void SetLastCount(Int32 value) { 
 hasLastCount = true;
 lastCount_ = value;
 }

public const int item1FieldNumber = 5;
 private pbc::PopsicleList<ItemInfo> item1_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> item1List {
 get { return pbc::Lists.AsReadOnly(item1_); }
 }
 
 public int item1Count {
 get { return item1_.Count; }
 }
 
public ItemInfo GetItem1(int index) {
 return item1_[index];
 }
 public void AddItem1(ItemInfo value) {
 item1_.Add(value);
 }

public const int item2FieldNumber = 6;
 private pbc::PopsicleList<ItemInfo> item2_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> item2List {
 get { return pbc::Lists.AsReadOnly(item2_); }
 }
 
 public int item2Count {
 get { return item2_.Count; }
 }
 
public ItemInfo GetItem2(int index) {
 return item2_[index];
 }
 public void AddItem2(ItemInfo value) {
 item2_.Add(value);
 }

public const int item3FieldNumber = 7;
 private pbc::PopsicleList<ItemInfo> item3_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> item3List {
 get { return pbc::Lists.AsReadOnly(item3_); }
 }
 
 public int item3Count {
 get { return item3_.Count; }
 }
 
public ItemInfo GetItem3(int index) {
 return item3_[index];
 }
 public void AddItem3(ItemInfo value) {
 item3_.Add(value);
 }

public const int startDateFieldNumber = 8;
 private bool hasStartDate;
 private string startDate_ = "";
 public bool HasStartDate {
 get { return hasStartDate; }
 }
 public string StartDate {
 get { return startDate_; }
 set { SetStartDate(value); }
 }
 public void SetStartDate(string value) { 
 hasStartDate = true;
 startDate_ = value;
 }

public const int endDateFieldNumber = 9;
 private bool hasEndDate;
 private string endDate_ = "";
 public bool HasEndDate {
 get { return hasEndDate; }
 }
 public string EndDate {
 get { return endDate_; }
 set { SetEndDate(value); }
 }
 public void SetEndDate(string value) { 
 hasEndDate = true;
 endDate_ = value;
 }

public const int nextNeedGoldFieldNumber = 10;
 private bool hasNextNeedGold;
 private Int32 nextNeedGold_ = 0;
 public bool HasNextNeedGold {
 get { return hasNextNeedGold; }
 }
 public Int32 NextNeedGold {
 get { return nextNeedGold_; }
 set { SetNextNeedGold(value); }
 }
 public void SetNextNeedGold(Int32 value) { 
 hasNextNeedGold = true;
 nextNeedGold_ = value;
 }

public const int buyTypeFieldNumber = 11;
 private bool hasBuyType;
 private Int32 buyType_ = 0;
 public bool HasBuyType {
 get { return hasBuyType; }
 }
 public Int32 BuyType {
 get { return buyType_; }
 set { SetBuyType(value); }
 }
 public void SetBuyType(Int32 value) { 
 hasBuyType = true;
 buyType_ = value;
 }

public const int singleMoneyFieldNumber = 12;
 private bool hasSingleMoney;
 private Int32 singleMoney_ = 0;
 public bool HasSingleMoney {
 get { return hasSingleMoney; }
 }
 public Int32 SingleMoney {
 get { return singleMoney_; }
 set { SetSingleMoney(value); }
 }
 public void SetSingleMoney(Int32 value) { 
 hasSingleMoney = true;
 singleMoney_ = value;
 }

public const int itemShowFieldNumber = 13;
 private bool hasItemShow;
 private string itemShow_ = "";
 public bool HasItemShow {
 get { return hasItemShow; }
 }
 public string ItemShow {
 get { return itemShow_; }
 set { SetItemShow(value); }
 }
 public void SetItemShow(string value) { 
 hasItemShow = true;
 itemShow_ = value;
 }

public const int buyOneMoneyFieldNumber = 14;
 private bool hasBuyOneMoney;
 private string buyOneMoney_ = "";
 public bool HasBuyOneMoney {
 get { return hasBuyOneMoney; }
 }
 public string BuyOneMoney {
 get { return buyOneMoney_; }
 set { SetBuyOneMoney(value); }
 }
 public void SetBuyOneMoney(string value) { 
 hasBuyOneMoney = true;
 buyOneMoney_ = value;
 }

public const int buyTenMoneyFieldNumber = 15;
 private bool hasBuyTenMoney;
 private string buyTenMoney_ = "";
 public bool HasBuyTenMoney {
 get { return hasBuyTenMoney; }
 }
 public string BuyTenMoney {
 get { return buyTenMoney_; }
 set { SetBuyTenMoney(value); }
 }
 public void SetBuyTenMoney(string value) { 
 hasBuyTenMoney = true;
 buyTenMoney_ = value;
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
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Result);
}
 if (HasLastCount) {
size += pb::CodedOutputStream.ComputeInt32Size(4, LastCount);
}
{
foreach (ItemInfo element in item1List) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ItemInfo element in item2List) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ItemInfo element in item3List) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasStartDate) {
size += pb::CodedOutputStream.ComputeStringSize(8, StartDate);
}
 if (HasEndDate) {
size += pb::CodedOutputStream.ComputeStringSize(9, EndDate);
}
 if (HasNextNeedGold) {
size += pb::CodedOutputStream.ComputeInt32Size(10, NextNeedGold);
}
 if (HasBuyType) {
size += pb::CodedOutputStream.ComputeInt32Size(11, BuyType);
}
 if (HasSingleMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(12, SingleMoney);
}
 if (HasItemShow) {
size += pb::CodedOutputStream.ComputeStringSize(13, ItemShow);
}
 if (HasBuyOneMoney) {
size += pb::CodedOutputStream.ComputeStringSize(14, BuyOneMoney);
}
 if (HasBuyTenMoney) {
size += pb::CodedOutputStream.ComputeStringSize(15, BuyTenMoney);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasResult) {
output.WriteInt32(3, Result);
}
 
if (HasLastCount) {
output.WriteInt32(4, LastCount);
}

do{
foreach (ItemInfo element in item1List) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ItemInfo element in item2List) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ItemInfo element in item3List) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasStartDate) {
output.WriteString(8, StartDate);
}
 
if (HasEndDate) {
output.WriteString(9, EndDate);
}
 
if (HasNextNeedGold) {
output.WriteInt32(10, NextNeedGold);
}
 
if (HasBuyType) {
output.WriteInt32(11, BuyType);
}
 
if (HasSingleMoney) {
output.WriteInt32(12, SingleMoney);
}
 
if (HasItemShow) {
output.WriteString(13, ItemShow);
}
 
if (HasBuyOneMoney) {
output.WriteString(14, BuyOneMoney);
}
 
if (HasBuyTenMoney) {
output.WriteString(15, BuyTenMoney);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFeelGold _inst = (GCFeelGold) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Result = input.ReadInt32();
break;
}
   case  32: {
 _inst.LastCount = input.ReadInt32();
break;
}
    case  42: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddItem1(subBuilder);
break;
}
    case  50: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddItem2(subBuilder);
break;
}
    case  58: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddItem3(subBuilder);
break;
}
   case  66: {
 _inst.StartDate = input.ReadString();
break;
}
   case  74: {
 _inst.EndDate = input.ReadString();
break;
}
   case  80: {
 _inst.NextNeedGold = input.ReadInt32();
break;
}
   case  88: {
 _inst.BuyType = input.ReadInt32();
break;
}
   case  96: {
 _inst.SingleMoney = input.ReadInt32();
break;
}
   case  106: {
 _inst.ItemShow = input.ReadString();
break;
}
   case  114: {
 _inst.BuyOneMoney = input.ReadString();
break;
}
   case  122: {
 _inst.BuyTenMoney = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ItemInfo element in item1List) {
if (!element.IsInitialized()) return false;
}
foreach (ItemInfo element in item2List) {
if (!element.IsInitialized()) return false;
}
foreach (ItemInfo element in item3List) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCFirstCharge : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(2, State);
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
 
if (HasState) {
output.WriteInt32(2, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFirstCharge _inst = (GCFirstCharge) _base;
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
public class GCFreeBack : PacketDistributed
{

public const int operateTypeFieldNumber = 1;
 private bool hasOperateType;
 private Int32 operateType_ = 0;
 public bool HasOperateType {
 get { return hasOperateType; }
 }
 public Int32 OperateType {
 get { return operateType_; }
 set { SetOperateType(value); }
 }
 public void SetOperateType(Int32 value) { 
 hasOperateType = true;
 operateType_ = value;
 }

public const int freeBackInfoFieldNumber = 2;
 private bool hasFreeBackInfo;
 private FreeBackInfo freeBackInfo_ =  new FreeBackInfo();
 public bool HasFreeBackInfo {
 get { return hasFreeBackInfo; }
 }
 public FreeBackInfo FreeBackInfo {
 get { return freeBackInfo_; }
 set { SetFreeBackInfo(value); }
 }
 public void SetFreeBackInfo(FreeBackInfo value) { 
 hasFreeBackInfo = true;
 freeBackInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperateType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OperateType);
}
{
int subsize = FreeBackInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOperateType) {
output.WriteInt32(1, OperateType);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)FreeBackInfo.SerializedSize());
FreeBackInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFreeBack _inst = (GCFreeBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OperateType = input.ReadInt32();
break;
}
    case  18: {
FreeBackInfo subBuilder =  new FreeBackInfo();
 input.ReadMessage(subBuilder);
_inst.FreeBackInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasFreeBackInfo) {
if (!FreeBackInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetRechargeDailyGiftRewardBack : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetRechargeDailyGiftRewardBack _inst = (GCGetRechargeDailyGiftRewardBack) _base;
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
public class GCGrowFund : PacketDistributed
{

public const int opTypeFieldNumber = 1;
 private bool hasOpType;
 private Int32 opType_ = 0;
 public bool HasOpType {
 get { return hasOpType; }
 }
 public Int32 OpType {
 get { return opType_; }
 set { SetOpType(value); }
 }
 public void SetOpType(Int32 value) { 
 hasOpType = true;
 opType_ = value;
 }

public const int flagFieldNumber = 2;
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

public const int buyStatusFieldNumber = 3;
 private bool hasBuyStatus;
 private Int32 buyStatus_ = 0;
 public bool HasBuyStatus {
 get { return hasBuyStatus; }
 }
 public Int32 BuyStatus {
 get { return buyStatus_; }
 set { SetBuyStatus(value); }
 }
 public void SetBuyStatus(Int32 value) { 
 hasBuyStatus = true;
 buyStatus_ = value;
 }

public const int buyNumFieldNumber = 4;
 private bool hasBuyNum;
 private Int32 buyNum_ = 0;
 public bool HasBuyNum {
 get { return hasBuyNum; }
 }
 public Int32 BuyNum {
 get { return buyNum_; }
 set { SetBuyNum(value); }
 }
 public void SetBuyNum(Int32 value) { 
 hasBuyNum = true;
 buyNum_ = value;
 }

public const int growFundListFieldNumber = 5;
 private pbc::PopsicleList<Int32> growFundList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> growFundListList {
 get { return pbc::Lists.AsReadOnly(growFundList_); }
 }
 
 public int growFundListCount {
 get { return growFundList_.Count; }
 }
 
public Int32 GetGrowFundList(int index) {
 return growFundList_[index];
 }
 public void AddGrowFundList(Int32 value) {
 growFundList_.Add(value);
 }

public const int generalWelfareListFieldNumber = 6;
 private pbc::PopsicleList<Int32> generalWelfareList_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> generalWelfareListList {
 get { return pbc::Lists.AsReadOnly(generalWelfareList_); }
 }
 
 public int generalWelfareListCount {
 get { return generalWelfareList_.Count; }
 }
 
public Int32 GetGeneralWelfareList(int index) {
 return generalWelfareList_[index];
 }
 public void AddGeneralWelfareList(Int32 value) {
 generalWelfareList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOpType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OpType);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
}
 if (HasBuyStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BuyStatus);
}
 if (HasBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, BuyNum);
}
{
int dataSize = 0;
foreach (Int32 element in growFundListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * growFundList_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in generalWelfareListList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * generalWelfareList_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOpType) {
output.WriteInt32(1, OpType);
}
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 
if (HasBuyStatus) {
output.WriteInt32(3, BuyStatus);
}
 
if (HasBuyNum) {
output.WriteInt32(4, BuyNum);
}
{
if (growFundList_.Count > 0) {
foreach (Int32 element in growFundListList) {
output.WriteInt32(5,element);
}
}

}
{
if (generalWelfareList_.Count > 0) {
foreach (Int32 element in generalWelfareListList) {
output.WriteInt32(6,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGrowFund _inst = (GCGrowFund) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OpType = input.ReadInt32();
break;
}
   case  16: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  24: {
 _inst.BuyStatus = input.ReadInt32();
break;
}
   case  32: {
 _inst.BuyNum = input.ReadInt32();
break;
}
   case  40: {
 _inst.AddGrowFundList(input.ReadInt32());
break;
}
   case  48: {
 _inst.AddGeneralWelfareList(input.ReadInt32());
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
public class GCGrowFundBuyNum : PacketDistributed
{

public const int buyNumFieldNumber = 1;
 private bool hasBuyNum;
 private Int32 buyNum_ = 0;
 public bool HasBuyNum {
 get { return hasBuyNum; }
 }
 public Int32 BuyNum {
 get { return buyNum_; }
 set { SetBuyNum(value); }
 }
 public void SetBuyNum(Int32 value) { 
 hasBuyNum = true;
 buyNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, BuyNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBuyNum) {
output.WriteInt32(1, BuyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGrowFundBuyNum _inst = (GCGrowFundBuyNum) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.BuyNum = input.ReadInt32();
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
public class GCHoliday : PacketDistributed
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

public const int paraMapFieldNumber = 3;
 private pbc::PopsicleList<EntryIntInt> paraMap_ = new pbc::PopsicleList<EntryIntInt>();
 public scg::IList<EntryIntInt> paraMapList {
 get { return pbc::Lists.AsReadOnly(paraMap_); }
 }
 
 public int paraMapCount {
 get { return paraMap_.Count; }
 }
 
public EntryIntInt GetParaMap(int index) {
 return paraMap_[index];
 }
 public void AddParaMap(EntryIntInt value) {
 paraMap_.Add(value);
 }

public const int itemLstFieldNumber = 4;
 private pbc::PopsicleList<ItemInfo> itemLst_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> itemLstList {
 get { return pbc::Lists.AsReadOnly(itemLst_); }
 }
 
 public int itemLstCount {
 get { return itemLst_.Count; }
 }
 
public ItemInfo GetItemLst(int index) {
 return itemLst_[index];
 }
 public void AddItemLst(ItemInfo value) {
 itemLst_.Add(value);
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
foreach (EntryIntInt element in paraMapList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ItemInfo element in itemLstList) {
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
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}

do{
foreach (EntryIntInt element in paraMapList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ItemInfo element in itemLstList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCHoliday _inst = (GCHoliday) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
EntryIntInt subBuilder =  new EntryIntInt();
input.ReadMessage(subBuilder);
_inst.AddParaMap(subBuilder);
break;
}
    case  34: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddItemLst(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EntryIntInt element in paraMapList) {
if (!element.IsInitialized()) return false;
}
foreach (ItemInfo element in itemLstList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLevelQuota : PacketDistributed
{

public const int infoListFieldNumber = 1;
 private pbc::PopsicleList<LevelQuotaInfo> infoList_ = new pbc::PopsicleList<LevelQuotaInfo>();
 public scg::IList<LevelQuotaInfo> infoListList {
 get { return pbc::Lists.AsReadOnly(infoList_); }
 }
 
 public int infoListCount {
 get { return infoList_.Count; }
 }
 
public LevelQuotaInfo GetInfoList(int index) {
 return infoList_[index];
 }
 public void AddInfoList(LevelQuotaInfo value) {
 infoList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (LevelQuotaInfo element in infoListList) {
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
foreach (LevelQuotaInfo element in infoListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLevelQuota _inst = (GCLevelQuota) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
LevelQuotaInfo subBuilder =  new LevelQuotaInfo();
input.ReadMessage(subBuilder);
_inst.AddInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (LevelQuotaInfo element in infoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLevelQuotaUpdate : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
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
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLevelQuotaUpdate _inst = (GCLevelQuotaUpdate) _base;
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
 _inst.Result = input.ReadInt32();
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
public class GCPointsBuyHisInfo : PacketDistributed
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

public const int winnersInfoListFieldNumber = 2;
 private pbc::PopsicleList<WinnersInfo> winnersInfoList_ = new pbc::PopsicleList<WinnersInfo>();
 public scg::IList<WinnersInfo> winnersInfoListList {
 get { return pbc::Lists.AsReadOnly(winnersInfoList_); }
 }
 
 public int winnersInfoListCount {
 get { return winnersInfoList_.Count; }
 }
 
public WinnersInfo GetWinnersInfoList(int index) {
 return winnersInfoList_[index];
 }
 public void AddWinnersInfoList(WinnersInfo value) {
 winnersInfoList_.Add(value);
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
foreach (WinnersInfo element in winnersInfoListList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}

do{
foreach (WinnersInfo element in winnersInfoListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPointsBuyHisInfo _inst = (GCPointsBuyHisInfo) _base;
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
WinnersInfo subBuilder =  new WinnersInfo();
input.ReadMessage(subBuilder);
_inst.AddWinnersInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WinnersInfo element in winnersInfoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPointsBuyList : PacketDistributed
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

public const int pointsFieldNumber = 2;
 private bool hasPoints;
 private Int32 points_ = 0;
 public bool HasPoints {
 get { return hasPoints; }
 }
 public Int32 Points {
 get { return points_; }
 set { SetPoints(value); }
 }
 public void SetPoints(Int32 value) { 
 hasPoints = true;
 points_ = value;
 }

public const int buyInfoListFieldNumber = 3;
 private pbc::PopsicleList<oneBuyInfo> buyInfoList_ = new pbc::PopsicleList<oneBuyInfo>();
 public scg::IList<oneBuyInfo> buyInfoListList {
 get { return pbc::Lists.AsReadOnly(buyInfoList_); }
 }
 
 public int buyInfoListCount {
 get { return buyInfoList_.Count; }
 }
 
public oneBuyInfo GetBuyInfoList(int index) {
 return buyInfoList_[index];
 }
 public void AddBuyInfoList(oneBuyInfo value) {
 buyInfoList_.Add(value);
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
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Points);
}
{
foreach (oneBuyInfo element in buyInfoListList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}
 
if (HasPoints) {
output.WriteInt32(2, Points);
}

do{
foreach (oneBuyInfo element in buyInfoListList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPointsBuyList _inst = (GCPointsBuyList) _base;
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
 _inst.Points = input.ReadInt32();
break;
}
    case  26: {
oneBuyInfo subBuilder =  new oneBuyInfo();
input.ReadMessage(subBuilder);
_inst.AddBuyInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (oneBuyInfo element in buyInfoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRechargeDailyGiftInfo : PacketDistributed
{

public const int dailyGiftListFieldNumber = 1;
 private pbc::PopsicleList<RechargeDailyGiftItem> dailyGiftList_ = new pbc::PopsicleList<RechargeDailyGiftItem>();
 public scg::IList<RechargeDailyGiftItem> dailyGiftListList {
 get { return pbc::Lists.AsReadOnly(dailyGiftList_); }
 }
 
 public int dailyGiftListCount {
 get { return dailyGiftList_.Count; }
 }
 
public RechargeDailyGiftItem GetDailyGiftList(int index) {
 return dailyGiftList_[index];
 }
 public void AddDailyGiftList(RechargeDailyGiftItem value) {
 dailyGiftList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RechargeDailyGiftItem element in dailyGiftListList) {
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
foreach (RechargeDailyGiftItem element in dailyGiftListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRechargeDailyGiftInfo _inst = (GCRechargeDailyGiftInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RechargeDailyGiftItem subBuilder =  new RechargeDailyGiftItem();
input.ReadMessage(subBuilder);
_inst.AddDailyGiftList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RechargeDailyGiftItem element in dailyGiftListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRechargeReward : PacketDistributed
{

public const int opTypeFieldNumber = 1;
 private bool hasOpType;
 private Int32 opType_ = 0;
 public bool HasOpType {
 get { return hasOpType; }
 }
 public Int32 OpType {
 get { return opType_; }
 set { SetOpType(value); }
 }
 public void SetOpType(Int32 value) { 
 hasOpType = true;
 opType_ = value;
 }

public const int typeDataFieldNumber = 2;
 private pbc::PopsicleList<RechargeTypeData> typeData_ = new pbc::PopsicleList<RechargeTypeData>();
 public scg::IList<RechargeTypeData> typeDataList {
 get { return pbc::Lists.AsReadOnly(typeData_); }
 }
 
 public int typeDataCount {
 get { return typeData_.Count; }
 }
 
public RechargeTypeData GetTypeData(int index) {
 return typeData_[index];
 }
 public void AddTypeData(RechargeTypeData value) {
 typeData_.Add(value);
 }

public const int flagFieldNumber = 3;
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
  if (HasOpType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OpType);
}
{
foreach (RechargeTypeData element in typeDataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOpType) {
output.WriteInt32(1, OpType);
}

do{
foreach (RechargeTypeData element in typeDataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasFlag) {
output.WriteInt32(3, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRechargeReward _inst = (GCRechargeReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OpType = input.ReadInt32();
break;
}
    case  18: {
RechargeTypeData subBuilder =  new RechargeTypeData();
input.ReadMessage(subBuilder);
_inst.AddTypeData(subBuilder);
break;
}
   case  24: {
 _inst.Flag = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RechargeTypeData element in typeDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRechargeTypeUpdate : PacketDistributed
{

public const int typeDataFieldNumber = 1;
 private bool hasTypeData;
 private RechargeTypeData typeData_ =  new RechargeTypeData();
 public bool HasTypeData {
 get { return hasTypeData; }
 }
 public RechargeTypeData TypeData {
 get { return typeData_; }
 set { SetTypeData(value); }
 }
 public void SetTypeData(RechargeTypeData value) { 
 hasTypeData = true;
 typeData_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = TypeData.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)TypeData.SerializedSize());
TypeData.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRechargeTypeUpdate _inst = (GCRechargeTypeUpdate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RechargeTypeData subBuilder =  new RechargeTypeData();
 input.ReadMessage(subBuilder);
_inst.TypeData = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTypeData) {
if (!TypeData.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSevenDaysHappy : PacketDistributed
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

public const int targetLstFieldNumber = 2;
 private pbc::PopsicleList<OneInDay> targetLst_ = new pbc::PopsicleList<OneInDay>();
 public scg::IList<OneInDay> targetLstList {
 get { return pbc::Lists.AsReadOnly(targetLst_); }
 }
 
 public int targetLstCount {
 get { return targetLst_.Count; }
 }
 
public OneInDay GetTargetLst(int index) {
 return targetLst_[index];
 }
 public void AddTargetLst(OneInDay value) {
 targetLst_.Add(value);
 }

public const int upgradeLstFieldNumber = 3;
 private pbc::PopsicleList<OneInDay> upgradeLst_ = new pbc::PopsicleList<OneInDay>();
 public scg::IList<OneInDay> upgradeLstList {
 get { return pbc::Lists.AsReadOnly(upgradeLst_); }
 }
 
 public int upgradeLstCount {
 get { return upgradeLst_.Count; }
 }
 
public OneInDay GetUpgradeLst(int index) {
 return upgradeLst_[index];
 }
 public void AddUpgradeLst(OneInDay value) {
 upgradeLst_.Add(value);
 }

public const int fightPowerLstFieldNumber = 4;
 private pbc::PopsicleList<OneInDay> fightPowerLst_ = new pbc::PopsicleList<OneInDay>();
 public scg::IList<OneInDay> fightPowerLstList {
 get { return pbc::Lists.AsReadOnly(fightPowerLst_); }
 }
 
 public int fightPowerLstCount {
 get { return fightPowerLst_.Count; }
 }
 
public OneInDay GetFightPowerLst(int index) {
 return fightPowerLst_[index];
 }
 public void AddFightPowerLst(OneInDay value) {
 fightPowerLst_.Add(value);
 }

public const int halfPriceFieldNumber = 5;
 private pbc::PopsicleList<OneInDay> halfPrice_ = new pbc::PopsicleList<OneInDay>();
 public scg::IList<OneInDay> halfPriceList {
 get { return pbc::Lists.AsReadOnly(halfPrice_); }
 }
 
 public int halfPriceCount {
 get { return halfPrice_.Count; }
 }
 
public OneInDay GetHalfPrice(int index) {
 return halfPrice_[index];
 }
 public void AddHalfPrice(OneInDay value) {
 halfPrice_.Add(value);
 }

public const int dayFieldNumber = 6;
 private bool hasDay;
 private Int32 day_ = 0;
 public bool HasDay {
 get { return hasDay; }
 }
 public Int32 Day {
 get { return day_; }
 set { SetDay(value); }
 }
 public void SetDay(Int32 value) { 
 hasDay = true;
 day_ = value;
 }

public const int scoreFieldNumber = 7;
 private bool hasScore;
 private Int32 score_ = 0;
 public bool HasScore {
 get { return hasScore; }
 }
 public Int32 Score {
 get { return score_; }
 set { SetScore(value); }
 }
 public void SetScore(Int32 value) { 
 hasScore = true;
 score_ = value;
 }

public const int curIdFieldNumber = 8;
 private bool hasCurId;
 private Int32 curId_ = 0;
 public bool HasCurId {
 get { return hasCurId; }
 }
 public Int32 CurId {
 get { return curId_; }
 set { SetCurId(value); }
 }
 public void SetCurId(Int32 value) { 
 hasCurId = true;
 curId_ = value;
 }

public const int endTimeFieldNumber = 9;
 private bool hasEndTime;
 private Int64 endTime_ = 0;
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public Int64 EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(Int64 value) { 
 hasEndTime = true;
 endTime_ = value;
 }

public const int resultFieldNumber = 10;
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
foreach (OneInDay element in targetLstList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (OneInDay element in upgradeLstList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (OneInDay element in fightPowerLstList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (OneInDay element in halfPriceList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasDay) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Day);
}
 if (HasScore) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Score);
}
 if (HasCurId) {
size += pb::CodedOutputStream.ComputeInt32Size(8, CurId);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(9, EndTime);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(10, Result);
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
foreach (OneInDay element in targetLstList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (OneInDay element in upgradeLstList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (OneInDay element in fightPowerLstList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (OneInDay element in halfPriceList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasDay) {
output.WriteInt32(6, Day);
}
 
if (HasScore) {
output.WriteInt32(7, Score);
}
 
if (HasCurId) {
output.WriteInt32(8, CurId);
}
 
if (HasEndTime) {
output.WriteInt64(9, EndTime);
}
 
if (HasResult) {
output.WriteInt32(10, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSevenDaysHappy _inst = (GCSevenDaysHappy) _base;
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
OneInDay subBuilder =  new OneInDay();
input.ReadMessage(subBuilder);
_inst.AddTargetLst(subBuilder);
break;
}
    case  26: {
OneInDay subBuilder =  new OneInDay();
input.ReadMessage(subBuilder);
_inst.AddUpgradeLst(subBuilder);
break;
}
    case  34: {
OneInDay subBuilder =  new OneInDay();
input.ReadMessage(subBuilder);
_inst.AddFightPowerLst(subBuilder);
break;
}
    case  42: {
OneInDay subBuilder =  new OneInDay();
input.ReadMessage(subBuilder);
_inst.AddHalfPrice(subBuilder);
break;
}
   case  48: {
 _inst.Day = input.ReadInt32();
break;
}
   case  56: {
 _inst.Score = input.ReadInt32();
break;
}
   case  64: {
 _inst.CurId = input.ReadInt32();
break;
}
   case  72: {
 _inst.EndTime = input.ReadInt64();
break;
}
   case  80: {
 _inst.Result = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (OneInDay element in targetLstList) {
if (!element.IsInitialized()) return false;
}
foreach (OneInDay element in upgradeLstList) {
if (!element.IsInitialized()) return false;
}
foreach (OneInDay element in fightPowerLstList) {
if (!element.IsInitialized()) return false;
}
foreach (OneInDay element in halfPriceList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSignin : PacketDistributed
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

public const int signStatusFieldNumber = 2;
 private bool hasSignStatus;
 private Int32 signStatus_ = 0;
 public bool HasSignStatus {
 get { return hasSignStatus; }
 }
 public Int32 SignStatus {
 get { return signStatus_; }
 set { SetSignStatus(value); }
 }
 public void SetSignStatus(Int32 value) { 
 hasSignStatus = true;
 signStatus_ = value;
 }

public const int signIdFieldNumber = 3;
 private bool hasSignId;
 private Int32 signId_ = 0;
 public bool HasSignId {
 get { return hasSignId; }
 }
 public Int32 SignId {
 get { return signId_; }
 set { SetSignId(value); }
 }
 public void SetSignId(Int32 value) { 
 hasSignId = true;
 signId_ = value;
 }

public const int signCountFieldNumber = 4;
 private bool hasSignCount;
 private Int32 signCount_ = 0;
 public bool HasSignCount {
 get { return hasSignCount; }
 }
 public Int32 SignCount {
 get { return signCount_; }
 set { SetSignCount(value); }
 }
 public void SetSignCount(Int32 value) { 
 hasSignCount = true;
 signCount_ = value;
 }

public const int totalSignNumFieldNumber = 5;
 private bool hasTotalSignNum;
 private Int32 totalSignNum_ = 0;
 public bool HasTotalSignNum {
 get { return hasTotalSignNum; }
 }
 public Int32 TotalSignNum {
 get { return totalSignNum_; }
 set { SetTotalSignNum(value); }
 }
 public void SetTotalSignNum(Int32 value) { 
 hasTotalSignNum = true;
 totalSignNum_ = value;
 }

public const int changeRewFieldNumber = 6;
 private bool hasChangeRew;
 private SunSignInRew changeRew_ =  new SunSignInRew();
 public bool HasChangeRew {
 get { return hasChangeRew; }
 }
 public SunSignInRew ChangeRew {
 get { return changeRew_; }
 set { SetChangeRew(value); }
 }
 public void SetChangeRew(SunSignInRew value) { 
 hasChangeRew = true;
 changeRew_ = value;
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
 if (HasSignStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SignStatus);
}
 if (HasSignId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SignId);
}
 if (HasSignCount) {
size += pb::CodedOutputStream.ComputeInt32Size(4, SignCount);
}
 if (HasTotalSignNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TotalSignNum);
}
{
int subsize = ChangeRew.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasSignStatus) {
output.WriteInt32(2, SignStatus);
}
 
if (HasSignId) {
output.WriteInt32(3, SignId);
}
 
if (HasSignCount) {
output.WriteInt32(4, SignCount);
}
 
if (HasTotalSignNum) {
output.WriteInt32(5, TotalSignNum);
}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ChangeRew.SerializedSize());
ChangeRew.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSignin _inst = (GCSignin) _base;
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
 _inst.SignStatus = input.ReadInt32();
break;
}
   case  24: {
 _inst.SignId = input.ReadInt32();
break;
}
   case  32: {
 _inst.SignCount = input.ReadInt32();
break;
}
   case  40: {
 _inst.TotalSignNum = input.ReadInt32();
break;
}
    case  50: {
SunSignInRew subBuilder =  new SunSignInRew();
 input.ReadMessage(subBuilder);
_inst.ChangeRew = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasChangeRew) {
if (!ChangeRew.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSigninStatusList : PacketDistributed
{

public const int todayFieldNumber = 1;
 private bool hasToday;
 private Int32 today_ = 0;
 public bool HasToday {
 get { return hasToday; }
 }
 public Int32 Today {
 get { return today_; }
 set { SetToday(value); }
 }
 public void SetToday(Int32 value) { 
 hasToday = true;
 today_ = value;
 }

public const int rewardMapFieldNumber = 2;
 private pbc::PopsicleList<SunSignInRew> rewardMap_ = new pbc::PopsicleList<SunSignInRew>();
 public scg::IList<SunSignInRew> rewardMapList {
 get { return pbc::Lists.AsReadOnly(rewardMap_); }
 }
 
 public int rewardMapCount {
 get { return rewardMap_.Count; }
 }
 
public SunSignInRew GetRewardMap(int index) {
 return rewardMap_[index];
 }
 public void AddRewardMap(SunSignInRew value) {
 rewardMap_.Add(value);
 }

public const int signCountFieldNumber = 3;
 private bool hasSignCount;
 private Int32 signCount_ = 0;
 public bool HasSignCount {
 get { return hasSignCount; }
 }
 public Int32 SignCount {
 get { return signCount_; }
 set { SetSignCount(value); }
 }
 public void SetSignCount(Int32 value) { 
 hasSignCount = true;
 signCount_ = value;
 }

public const int signInTemFieldNumber = 4;
 private pbc::PopsicleList<SignInTem> signInTem_ = new pbc::PopsicleList<SignInTem>();
 public scg::IList<SignInTem> signInTemList {
 get { return pbc::Lists.AsReadOnly(signInTem_); }
 }
 
 public int signInTemCount {
 get { return signInTem_.Count; }
 }
 
public SignInTem GetSignInTem(int index) {
 return signInTem_[index];
 }
 public void AddSignInTem(SignInTem value) {
 signInTem_.Add(value);
 }

public const int totalSignNumFieldNumber = 5;
 private bool hasTotalSignNum;
 private Int32 totalSignNum_ = 0;
 public bool HasTotalSignNum {
 get { return hasTotalSignNum; }
 }
 public Int32 TotalSignNum {
 get { return totalSignNum_; }
 set { SetTotalSignNum(value); }
 }
 public void SetTotalSignNum(Int32 value) { 
 hasTotalSignNum = true;
 totalSignNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasToday) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Today);
}
{
foreach (SunSignInRew element in rewardMapList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSignCount) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SignCount);
}
{
foreach (SignInTem element in signInTemList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasTotalSignNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TotalSignNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasToday) {
output.WriteInt32(1, Today);
}

do{
foreach (SunSignInRew element in rewardMapList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSignCount) {
output.WriteInt32(3, SignCount);
}

do{
foreach (SignInTem element in signInTemList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasTotalSignNum) {
output.WriteInt32(5, TotalSignNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSigninStatusList _inst = (GCSigninStatusList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Today = input.ReadInt32();
break;
}
    case  18: {
SunSignInRew subBuilder =  new SunSignInRew();
input.ReadMessage(subBuilder);
_inst.AddRewardMap(subBuilder);
break;
}
   case  24: {
 _inst.SignCount = input.ReadInt32();
break;
}
    case  34: {
SignInTem subBuilder =  new SignInTem();
input.ReadMessage(subBuilder);
_inst.AddSignInTem(subBuilder);
break;
}
   case  40: {
 _inst.TotalSignNum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SunSignInRew element in rewardMapList) {
if (!element.IsInitialized()) return false;
}
foreach (SignInTem element in signInTemList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSuperRebateBack : PacketDistributed
{

public const int operateTypeFieldNumber = 1;
 private bool hasOperateType;
 private Int32 operateType_ = 0;
 public bool HasOperateType {
 get { return hasOperateType; }
 }
 public Int32 OperateType {
 get { return operateType_; }
 set { SetOperateType(value); }
 }
 public void SetOperateType(Int32 value) { 
 hasOperateType = true;
 operateType_ = value;
 }

public const int noteFieldNumber = 2;
 private bool hasNote;
 private string note_ = "";
 public bool HasNote {
 get { return hasNote; }
 }
 public string Note {
 get { return note_; }
 set { SetNote(value); }
 }
 public void SetNote(string value) { 
 hasNote = true;
 note_ = value;
 }

public const int infoListFieldNumber = 3;
 private pbc::PopsicleList<SuperRebateInfo> infoList_ = new pbc::PopsicleList<SuperRebateInfo>();
 public scg::IList<SuperRebateInfo> infoListList {
 get { return pbc::Lists.AsReadOnly(infoList_); }
 }
 
 public int infoListCount {
 get { return infoList_.Count; }
 }
 
public SuperRebateInfo GetInfoList(int index) {
 return infoList_[index];
 }
 public void AddInfoList(SuperRebateInfo value) {
 infoList_.Add(value);
 }

public const int rebateInfoFieldNumber = 4;
 private bool hasRebateInfo;
 private SuperRebateInfo rebateInfo_ =  new SuperRebateInfo();
 public bool HasRebateInfo {
 get { return hasRebateInfo; }
 }
 public SuperRebateInfo RebateInfo {
 get { return rebateInfo_; }
 set { SetRebateInfo(value); }
 }
 public void SetRebateInfo(SuperRebateInfo value) { 
 hasRebateInfo = true;
 rebateInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperateType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OperateType);
}
 if (HasNote) {
size += pb::CodedOutputStream.ComputeStringSize(2, Note);
}
{
foreach (SuperRebateInfo element in infoListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = RebateInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOperateType) {
output.WriteInt32(1, OperateType);
}
 
if (HasNote) {
output.WriteString(2, Note);
}

do{
foreach (SuperRebateInfo element in infoListList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)RebateInfo.SerializedSize());
RebateInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSuperRebateBack _inst = (GCSuperRebateBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OperateType = input.ReadInt32();
break;
}
   case  18: {
 _inst.Note = input.ReadString();
break;
}
    case  26: {
SuperRebateInfo subBuilder =  new SuperRebateInfo();
input.ReadMessage(subBuilder);
_inst.AddInfoList(subBuilder);
break;
}
    case  34: {
SuperRebateInfo subBuilder =  new SuperRebateInfo();
 input.ReadMessage(subBuilder);
_inst.RebateInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SuperRebateInfo element in infoListList) {
if (!element.IsInitialized()) return false;
}
  if (HasRebateInfo) {
if (!RebateInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUpdateCardReward : PacketDistributed
{

public const int cardRewardDataFieldNumber = 1;
 private pbc::PopsicleList<CardRewardData> cardRewardData_ = new pbc::PopsicleList<CardRewardData>();
 public scg::IList<CardRewardData> cardRewardDataList {
 get { return pbc::Lists.AsReadOnly(cardRewardData_); }
 }
 
 public int cardRewardDataCount {
 get { return cardRewardData_.Count; }
 }
 
public CardRewardData GetCardRewardData(int index) {
 return cardRewardData_[index];
 }
 public void AddCardRewardData(CardRewardData value) {
 cardRewardData_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (CardRewardData element in cardRewardDataList) {
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
foreach (CardRewardData element in cardRewardDataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdateCardReward _inst = (GCUpdateCardReward) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CardRewardData subBuilder =  new CardRewardData();
input.ReadMessage(subBuilder);
_inst.AddCardRewardData(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CardRewardData element in cardRewardDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUpdateOneBuyList : PacketDistributed
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

public const int buyInfoListFieldNumber = 2;
 private pbc::PopsicleList<oneBuyInfo> buyInfoList_ = new pbc::PopsicleList<oneBuyInfo>();
 public scg::IList<oneBuyInfo> buyInfoListList {
 get { return pbc::Lists.AsReadOnly(buyInfoList_); }
 }
 
 public int buyInfoListCount {
 get { return buyInfoList_.Count; }
 }
 
public oneBuyInfo GetBuyInfoList(int index) {
 return buyInfoList_[index];
 }
 public void AddBuyInfoList(oneBuyInfo value) {
 buyInfoList_.Add(value);
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
foreach (oneBuyInfo element in buyInfoListList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}

do{
foreach (oneBuyInfo element in buyInfoListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdateOneBuyList _inst = (GCUpdateOneBuyList) _base;
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
oneBuyInfo subBuilder =  new oneBuyInfo();
input.ReadMessage(subBuilder);
_inst.AddBuyInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (oneBuyInfo element in buyInfoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUpdateRewardList : PacketDistributed
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

public const int winnersInfoListFieldNumber = 2;
 private pbc::PopsicleList<WinnersInfo> winnersInfoList_ = new pbc::PopsicleList<WinnersInfo>();
 public scg::IList<WinnersInfo> winnersInfoListList {
 get { return pbc::Lists.AsReadOnly(winnersInfoList_); }
 }
 
 public int winnersInfoListCount {
 get { return winnersInfoList_.Count; }
 }
 
public WinnersInfo GetWinnersInfoList(int index) {
 return winnersInfoList_[index];
 }
 public void AddWinnersInfoList(WinnersInfo value) {
 winnersInfoList_.Add(value);
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
foreach (WinnersInfo element in winnersInfoListList) {
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
  
if (HasType) {
output.WriteInt32(1, Type);
}

do{
foreach (WinnersInfo element in winnersInfoListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdateRewardList _inst = (GCUpdateRewardList) _base;
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
WinnersInfo subBuilder =  new WinnersInfo();
input.ReadMessage(subBuilder);
_inst.AddWinnersInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (WinnersInfo element in winnersInfoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class LevelQuotaInfo : PacketDistributed
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

public const int levelLimitFieldNumber = 2;
 private bool hasLevelLimit;
 private Int32 levelLimit_ = 0;
 public bool HasLevelLimit {
 get { return hasLevelLimit; }
 }
 public Int32 LevelLimit {
 get { return levelLimit_; }
 set { SetLevelLimit(value); }
 }
 public void SetLevelLimit(Int32 value) { 
 hasLevelLimit = true;
 levelLimit_ = value;
 }

public const int goodsGroupFieldNumber = 3;
 private bool hasGoodsGroup;
 private string goodsGroup_ = "";
 public bool HasGoodsGroup {
 get { return hasGoodsGroup; }
 }
 public string GoodsGroup {
 get { return goodsGroup_; }
 set { SetGoodsGroup(value); }
 }
 public void SetGoodsGroup(string value) { 
 hasGoodsGroup = true;
 goodsGroup_ = value;
 }

public const int ChargeIdFieldNumber = 4;
 private bool hasChargeId;
 private string ChargeId_ = "";
 public bool HasChargeId {
 get { return hasChargeId; }
 }
 public string ChargeId {
 get { return ChargeId_; }
 set { SetChargeId(value); }
 }
 public void SetChargeId(string value) { 
 hasChargeId = true;
 ChargeId_ = value;
 }

public const int originalPriceFieldNumber = 5;
 private bool hasOriginalPrice;
 private Int32 originalPrice_ = 0;
 public bool HasOriginalPrice {
 get { return hasOriginalPrice; }
 }
 public Int32 OriginalPrice {
 get { return originalPrice_; }
 set { SetOriginalPrice(value); }
 }
 public void SetOriginalPrice(Int32 value) { 
 hasOriginalPrice = true;
 originalPrice_ = value;
 }

public const int currentPriceFieldNumber = 6;
 private bool hasCurrentPrice;
 private Int32 currentPrice_ = 0;
 public bool HasCurrentPrice {
 get { return hasCurrentPrice; }
 }
 public Int32 CurrentPrice {
 get { return currentPrice_; }
 set { SetCurrentPrice(value); }
 }
 public void SetCurrentPrice(Int32 value) { 
 hasCurrentPrice = true;
 currentPrice_ = value;
 }

public const int noSeeLevelFieldNumber = 7;
 private bool hasNoSeeLevel;
 private Int32 noSeeLevel_ = 0;
 public bool HasNoSeeLevel {
 get { return hasNoSeeLevel; }
 }
 public Int32 NoSeeLevel {
 get { return noSeeLevel_; }
 set { SetNoSeeLevel(value); }
 }
 public void SetNoSeeLevel(Int32 value) { 
 hasNoSeeLevel = true;
 noSeeLevel_ = value;
 }

public const int moneyTypeFieldNumber = 8;
 private bool hasMoneyType;
 private Int32 moneyType_ = 0;
 public bool HasMoneyType {
 get { return hasMoneyType; }
 }
 public Int32 MoneyType {
 get { return moneyType_; }
 set { SetMoneyType(value); }
 }
 public void SetMoneyType(Int32 value) { 
 hasMoneyType = true;
 moneyType_ = value;
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
 if (HasLevelLimit) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LevelLimit);
}
 if (HasGoodsGroup) {
size += pb::CodedOutputStream.ComputeStringSize(3, GoodsGroup);
}
 if (HasChargeId) {
size += pb::CodedOutputStream.ComputeStringSize(4, ChargeId);
}
 if (HasOriginalPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(5, OriginalPrice);
}
 if (HasCurrentPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(6, CurrentPrice);
}
 if (HasNoSeeLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(7, NoSeeLevel);
}
 if (HasMoneyType) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MoneyType);
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
 
if (HasLevelLimit) {
output.WriteInt32(2, LevelLimit);
}
 
if (HasGoodsGroup) {
output.WriteString(3, GoodsGroup);
}
 
if (HasChargeId) {
output.WriteString(4, ChargeId);
}
 
if (HasOriginalPrice) {
output.WriteInt32(5, OriginalPrice);
}
 
if (HasCurrentPrice) {
output.WriteInt32(6, CurrentPrice);
}
 
if (HasNoSeeLevel) {
output.WriteInt32(7, NoSeeLevel);
}
 
if (HasMoneyType) {
output.WriteInt32(8, MoneyType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LevelQuotaInfo _inst = (LevelQuotaInfo) _base;
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
 _inst.LevelLimit = input.ReadInt32();
break;
}
   case  26: {
 _inst.GoodsGroup = input.ReadString();
break;
}
   case  34: {
 _inst.ChargeId = input.ReadString();
break;
}
   case  40: {
 _inst.OriginalPrice = input.ReadInt32();
break;
}
   case  48: {
 _inst.CurrentPrice = input.ReadInt32();
break;
}
   case  56: {
 _inst.NoSeeLevel = input.ReadInt32();
break;
}
   case  64: {
 _inst.MoneyType = input.ReadInt32();
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
public class OneInDay : PacketDistributed
{

public const int tblIdFieldNumber = 1;
 private bool hasTblId;
 private Int32 tblId_ = 0;
 public bool HasTblId {
 get { return hasTblId; }
 }
 public Int32 TblId {
 get { return tblId_; }
 set { SetTblId(value); }
 }
 public void SetTblId(Int32 value) { 
 hasTblId = true;
 tblId_ = value;
 }

public const int statusFieldNumber = 2;
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

public const int totalCountFieldNumber = 3;
 private bool hasTotalCount;
 private Int32 totalCount_ = 0;
 public bool HasTotalCount {
 get { return hasTotalCount; }
 }
 public Int32 TotalCount {
 get { return totalCount_; }
 set { SetTotalCount(value); }
 }
 public void SetTotalCount(Int32 value) { 
 hasTotalCount = true;
 totalCount_ = value;
 }

public const int countFieldNumber = 4;
 private bool hasCount;
 private Int32 count_ = 0;
 public bool HasCount {
 get { return hasCount; }
 }
 public Int32 Count {
 get { return count_; }
 set { SetCount(value); }
 }
 public void SetCount(Int32 value) { 
 hasCount = true;
 count_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTblId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TblId);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 if (HasTotalCount) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TotalCount);
}
 if (HasCount) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Count);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTblId) {
output.WriteInt32(1, TblId);
}
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 
if (HasTotalCount) {
output.WriteInt32(3, TotalCount);
}
 
if (HasCount) {
output.WriteInt32(4, Count);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 OneInDay _inst = (OneInDay) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TblId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.TotalCount = input.ReadInt32();
break;
}
   case  32: {
 _inst.Count = input.ReadInt32();
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
public class RechargeDailyGiftItem : PacketDistributed
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

public const int statusFieldNumber = 2;
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RechargeDailyGiftItem _inst = (RechargeDailyGiftItem) _base;
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


[Serializable]
public class RechargeRewardData : PacketDistributed
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

public const int statusFieldNumber = 2;
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

public const int needNumFieldNumber = 3;
 private bool hasNeedNum;
 private Int32 needNum_ = 0;
 public bool HasNeedNum {
 get { return hasNeedNum; }
 }
 public Int32 NeedNum {
 get { return needNum_; }
 set { SetNeedNum(value); }
 }
 public void SetNeedNum(Int32 value) { 
 hasNeedNum = true;
 needNum_ = value;
 }

public const int rewardFieldNumber = 4;
 private bool hasReward;
 private string reward_ = "";
 public bool HasReward {
 get { return hasReward; }
 }
 public string Reward {
 get { return reward_; }
 set { SetReward(value); }
 }
 public void SetReward(string value) { 
 hasReward = true;
 reward_ = value;
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
 if (HasNeedNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, NeedNum);
}
 if (HasReward) {
size += pb::CodedOutputStream.ComputeStringSize(4, Reward);
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}
 
if (HasNeedNum) {
output.WriteInt32(3, NeedNum);
}
 
if (HasReward) {
output.WriteString(4, Reward);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RechargeRewardData _inst = (RechargeRewardData) _base;
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
 _inst.Status = input.ReadInt32();
break;
}
   case  24: {
 _inst.NeedNum = input.ReadInt32();
break;
}
   case  34: {
 _inst.Reward = input.ReadString();
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
public class RechargeTypeData : PacketDistributed
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

public const int startTimeFieldNumber = 2;
 private bool hasStartTime;
 private Int64 startTime_ = 0;
 public bool HasStartTime {
 get { return hasStartTime; }
 }
 public Int64 StartTime {
 get { return startTime_; }
 set { SetStartTime(value); }
 }
 public void SetStartTime(Int64 value) { 
 hasStartTime = true;
 startTime_ = value;
 }

public const int endTimeFieldNumber = 3;
 private bool hasEndTime;
 private Int64 endTime_ = 0;
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public Int64 EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(Int64 value) { 
 hasEndTime = true;
 endTime_ = value;
 }

public const int rewardDataFieldNumber = 4;
 private pbc::PopsicleList<RechargeRewardData> rewardData_ = new pbc::PopsicleList<RechargeRewardData>();
 public scg::IList<RechargeRewardData> rewardDataList {
 get { return pbc::Lists.AsReadOnly(rewardData_); }
 }
 
 public int rewardDataCount {
 get { return rewardData_.Count; }
 }
 
public RechargeRewardData GetRewardData(int index) {
 return rewardData_[index];
 }
 public void AddRewardData(RechargeRewardData value) {
 rewardData_.Add(value);
 }

public const int valueFieldNumber = 5;
 private bool hasValue;
 private Int32 value_ = 0;
 public bool HasValue {
 get { return hasValue; }
 }
 public Int32 Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(Int32 value) { 
 hasValue = true;
 value_ = value;
 }

public const int refreshTimeFieldNumber = 6;
 private bool hasRefreshTime;
 private Int64 refreshTime_ = 0;
 public bool HasRefreshTime {
 get { return hasRefreshTime; }
 }
 public Int64 RefreshTime {
 get { return refreshTime_; }
 set { SetRefreshTime(value); }
 }
 public void SetRefreshTime(Int64 value) { 
 hasRefreshTime = true;
 refreshTime_ = value;
 }

public const int statusFieldNumber = 7;
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
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, StartTime);
}
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, EndTime);
}
{
foreach (RechargeRewardData element in rewardDataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Value);
}
 if (HasRefreshTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, RefreshTime);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Status);
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
 
if (HasStartTime) {
output.WriteInt64(2, StartTime);
}
 
if (HasEndTime) {
output.WriteInt64(3, EndTime);
}

do{
foreach (RechargeRewardData element in rewardDataList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasValue) {
output.WriteInt32(5, Value);
}
 
if (HasRefreshTime) {
output.WriteInt64(6, RefreshTime);
}
 
if (HasStatus) {
output.WriteInt32(7, Status);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RechargeTypeData _inst = (RechargeTypeData) _base;
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
 _inst.StartTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.EndTime = input.ReadInt64();
break;
}
    case  34: {
RechargeRewardData subBuilder =  new RechargeRewardData();
input.ReadMessage(subBuilder);
_inst.AddRewardData(subBuilder);
break;
}
   case  40: {
 _inst.Value = input.ReadInt32();
break;
}
   case  48: {
 _inst.RefreshTime = input.ReadInt64();
break;
}
   case  56: {
 _inst.Status = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RechargeRewardData element in rewardDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SignInTem : PacketDistributed
{

public const int temIdFieldNumber = 1;
 private bool hasTemId;
 private Int32 temId_ = 0;
 public bool HasTemId {
 get { return hasTemId; }
 }
 public Int32 TemId {
 get { return temId_; }
 set { SetTemId(value); }
 }
 public void SetTemId(Int32 value) { 
 hasTemId = true;
 temId_ = value;
 }

public const int monthFieldNumber = 2;
 private bool hasMonth;
 private Int32 month_ = 0;
 public bool HasMonth {
 get { return hasMonth; }
 }
 public Int32 Month {
 get { return month_; }
 set { SetMonth(value); }
 }
 public void SetMonth(Int32 value) { 
 hasMonth = true;
 month_ = value;
 }

public const int dayFieldNumber = 3;
 private bool hasDay;
 private Int32 day_ = 0;
 public bool HasDay {
 get { return hasDay; }
 }
 public Int32 Day {
 get { return day_; }
 set { SetDay(value); }
 }
 public void SetDay(Int32 value) { 
 hasDay = true;
 day_ = value;
 }

public const int itemInfoFieldNumber = 4;
 private bool hasItemInfo;
 private ItemInfo itemInfo_ =  new ItemInfo();
 public bool HasItemInfo {
 get { return hasItemInfo; }
 }
 public ItemInfo ItemInfo {
 get { return itemInfo_; }
 set { SetItemInfo(value); }
 }
 public void SetItemInfo(ItemInfo value) { 
 hasItemInfo = true;
 itemInfo_ = value;
 }

public const int vipFieldNumber = 5;
 private bool hasVip;
 private Int32 vip_ = 0;
 public bool HasVip {
 get { return hasVip; }
 }
 public Int32 Vip {
 get { return vip_; }
 set { SetVip(value); }
 }
 public void SetVip(Int32 value) { 
 hasVip = true;
 vip_ = value;
 }

public const int ratioFieldNumber = 6;
 private bool hasRatio;
 private Int32 ratio_ = 0;
 public bool HasRatio {
 get { return hasRatio; }
 }
 public Int32 Ratio {
 get { return ratio_; }
 set { SetRatio(value); }
 }
 public void SetRatio(Int32 value) { 
 hasRatio = true;
 ratio_ = value;
 }

public const int signStatusFieldNumber = 7;
 private bool hasSignStatus;
 private Int32 signStatus_ = 0;
 public bool HasSignStatus {
 get { return hasSignStatus; }
 }
 public Int32 SignStatus {
 get { return signStatus_; }
 set { SetSignStatus(value); }
 }
 public void SetSignStatus(Int32 value) { 
 hasSignStatus = true;
 signStatus_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTemId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TemId);
}
 if (HasMonth) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Month);
}
 if (HasDay) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Day);
}
{
int subsize = ItemInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Vip);
}
 if (HasRatio) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Ratio);
}
 if (HasSignStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(7, SignStatus);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTemId) {
output.WriteInt32(1, TemId);
}
 
if (HasMonth) {
output.WriteInt32(2, Month);
}
 
if (HasDay) {
output.WriteInt32(3, Day);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
ItemInfo.WriteTo(output);

}
 
if (HasVip) {
output.WriteInt32(5, Vip);
}
 
if (HasRatio) {
output.WriteInt32(6, Ratio);
}
 
if (HasSignStatus) {
output.WriteInt32(7, SignStatus);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SignInTem _inst = (SignInTem) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TemId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Month = input.ReadInt32();
break;
}
   case  24: {
 _inst.Day = input.ReadInt32();
break;
}
    case  34: {
ItemInfo subBuilder =  new ItemInfo();
 input.ReadMessage(subBuilder);
_inst.ItemInfo = subBuilder;
break;
}
   case  40: {
 _inst.Vip = input.ReadInt32();
break;
}
   case  48: {
 _inst.Ratio = input.ReadInt32();
break;
}
   case  56: {
 _inst.SignStatus = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasItemInfo) {
if (!ItemInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SunSignInRew : PacketDistributed
{

public const int temIdFieldNumber = 1;
 private bool hasTemId;
 private Int32 temId_ = 0;
 public bool HasTemId {
 get { return hasTemId; }
 }
 public Int32 TemId {
 get { return temId_; }
 set { SetTemId(value); }
 }
 public void SetTemId(Int32 value) { 
 hasTemId = true;
 temId_ = value;
 }

public const int signNumFieldNumber = 2;
 private bool hasSignNum;
 private Int32 signNum_ = 0;
 public bool HasSignNum {
 get { return hasSignNum; }
 }
 public Int32 SignNum {
 get { return signNum_; }
 set { SetSignNum(value); }
 }
 public void SetSignNum(Int32 value) { 
 hasSignNum = true;
 signNum_ = value;
 }

public const int itemInfoFieldNumber = 3;
 private bool hasItemInfo;
 private ItemInfo itemInfo_ =  new ItemInfo();
 public bool HasItemInfo {
 get { return hasItemInfo; }
 }
 public ItemInfo ItemInfo {
 get { return itemInfo_; }
 set { SetItemInfo(value); }
 }
 public void SetItemInfo(ItemInfo value) { 
 hasItemInfo = true;
 itemInfo_ = value;
 }

public const int valueFieldNumber = 4;
 private bool hasValue;
 private Int32 value_ = 0;
 public bool HasValue {
 get { return hasValue; }
 }
 public Int32 Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(Int32 value) { 
 hasValue = true;
 value_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTemId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TemId);
}
 if (HasSignNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SignNum);
}
{
int subsize = ItemInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Value);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTemId) {
output.WriteInt32(1, TemId);
}
 
if (HasSignNum) {
output.WriteInt32(2, SignNum);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
ItemInfo.WriteTo(output);

}
 
if (HasValue) {
output.WriteInt32(4, Value);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SunSignInRew _inst = (SunSignInRew) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TemId = input.ReadInt32();
break;
}
   case  16: {
 _inst.SignNum = input.ReadInt32();
break;
}
    case  26: {
ItemInfo subBuilder =  new ItemInfo();
 input.ReadMessage(subBuilder);
_inst.ItemInfo = subBuilder;
break;
}
   case  32: {
 _inst.Value = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasItemInfo) {
if (!ItemInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SuperRebateInfo : PacketDistributed
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

public const int priceFieldNumber = 2;
 private bool hasPrice;
 private Int32 price_ = 0;
 public bool HasPrice {
 get { return hasPrice; }
 }
 public Int32 Price {
 get { return price_; }
 set { SetPrice(value); }
 }
 public void SetPrice(Int32 value) { 
 hasPrice = true;
 price_ = value;
 }

public const int noteFieldNumber = 3;
 private bool hasNote;
 private string note_ = "";
 public bool HasNote {
 get { return hasNote; }
 }
 public string Note {
 get { return note_; }
 set { SetNote(value); }
 }
 public void SetNote(string value) { 
 hasNote = true;
 note_ = value;
 }

public const int itemListFieldNumber = 4;
 private pbc::PopsicleList<SuperRebateItem> itemList_ = new pbc::PopsicleList<SuperRebateItem>();
 public scg::IList<SuperRebateItem> itemListList {
 get { return pbc::Lists.AsReadOnly(itemList_); }
 }
 
 public int itemListCount {
 get { return itemList_.Count; }
 }
 
public SuperRebateItem GetItemList(int index) {
 return itemList_[index];
 }
 public void AddItemList(SuperRebateItem value) {
 itemList_.Add(value);
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
 if (HasPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Price);
}
 if (HasNote) {
size += pb::CodedOutputStream.ComputeStringSize(3, Note);
}
{
foreach (SuperRebateItem element in itemListList) {
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
  
if (HasId) {
output.WriteInt32(1, Id);
}
 
if (HasPrice) {
output.WriteInt32(2, Price);
}
 
if (HasNote) {
output.WriteString(3, Note);
}

do{
foreach (SuperRebateItem element in itemListList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SuperRebateInfo _inst = (SuperRebateInfo) _base;
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
 _inst.Price = input.ReadInt32();
break;
}
   case  26: {
 _inst.Note = input.ReadString();
break;
}
    case  34: {
SuperRebateItem subBuilder =  new SuperRebateItem();
input.ReadMessage(subBuilder);
_inst.AddItemList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SuperRebateItem element in itemListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class SuperRebateItem : PacketDistributed
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

public const int itemInfoFieldNumber = 2;
 private bool hasItemInfo;
 private string itemInfo_ = "";
 public bool HasItemInfo {
 get { return hasItemInfo; }
 }
 public string ItemInfo {
 get { return itemInfo_; }
 set { SetItemInfo(value); }
 }
 public void SetItemInfo(string value) { 
 hasItemInfo = true;
 itemInfo_ = value;
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
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasItemInfo) {
size += pb::CodedOutputStream.ComputeStringSize(2, ItemInfo);
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
  
if (HasType) {
output.WriteInt32(1, Type);
}
 
if (HasItemInfo) {
output.WriteString(2, ItemInfo);
}
 
if (HasStatus) {
output.WriteInt32(3, Status);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SuperRebateItem _inst = (SuperRebateItem) _base;
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
 _inst.ItemInfo = input.ReadString();
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


[Serializable]
public class WinnersInfo : PacketDistributed
{

public const int playerNameFieldNumber = 1;
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

public const int priceFieldNumber = 2;
 private bool hasPrice;
 private Int32 price_ = 0;
 public bool HasPrice {
 get { return hasPrice; }
 }
 public Int32 Price {
 get { return price_; }
 set { SetPrice(value); }
 }
 public void SetPrice(Int32 value) { 
 hasPrice = true;
 price_ = value;
 }

public const int nameFieldNumber = 3;
 private bool hasName;
 private string name_ = "";
 public bool HasName {
 get { return hasName; }
 }
 public string Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(string value) { 
 hasName = true;
 name_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(1, PlayerName);
}
 if (HasPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Price);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(3, Name);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerName) {
output.WriteString(1, PlayerName);
}
 
if (HasPrice) {
output.WriteInt32(2, Price);
}
 
if (HasName) {
output.WriteString(3, Name);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 WinnersInfo _inst = (WinnersInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  16: {
 _inst.Price = input.ReadInt32();
break;
}
   case  26: {
 _inst.Name = input.ReadString();
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
public class oneBuyInfo : PacketDistributed
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

public const int curTotalBuyNumFieldNumber = 3;
 private bool hasCurTotalBuyNum;
 private Int32 curTotalBuyNum_ = 0;
 public bool HasCurTotalBuyNum {
 get { return hasCurTotalBuyNum; }
 }
 public Int32 CurTotalBuyNum {
 get { return curTotalBuyNum_; }
 set { SetCurTotalBuyNum(value); }
 }
 public void SetCurTotalBuyNum(Int32 value) { 
 hasCurTotalBuyNum = true;
 curTotalBuyNum_ = value;
 }

public const int curMyBuyNumFieldNumber = 4;
 private bool hasCurMyBuyNum;
 private Int32 curMyBuyNum_ = 0;
 public bool HasCurMyBuyNum {
 get { return hasCurMyBuyNum; }
 }
 public Int32 CurMyBuyNum {
 get { return curMyBuyNum_; }
 set { SetCurMyBuyNum(value); }
 }
 public void SetCurMyBuyNum(Int32 value) { 
 hasCurMyBuyNum = true;
 curMyBuyNum_ = value;
 }

public const int overTimeFieldNumber = 5;
 private bool hasOverTime;
 private Int64 overTime_ = 0;
 public bool HasOverTime {
 get { return hasOverTime; }
 }
 public Int64 OverTime {
 get { return overTime_; }
 set { SetOverTime(value); }
 }
 public void SetOverTime(Int64 value) { 
 hasOverTime = true;
 overTime_ = value;
 }

public const int groupFieldNumber = 6;
 private bool hasGroup;
 private Int32 group_ = 0;
 public bool HasGroup {
 get { return hasGroup; }
 }
 public Int32 Group {
 get { return group_; }
 set { SetGroup(value); }
 }
 public void SetGroup(Int32 value) { 
 hasGroup = true;
 group_ = value;
 }

public const int priceFieldNumber = 7;
 private bool hasPrice;
 private Int32 price_ = 0;
 public bool HasPrice {
 get { return hasPrice; }
 }
 public Int32 Price {
 get { return price_; }
 set { SetPrice(value); }
 }
 public void SetPrice(Int32 value) { 
 hasPrice = true;
 price_ = value;
 }

public const int nameFieldNumber = 8;
 private bool hasName;
 private string name_ = "";
 public bool HasName {
 get { return hasName; }
 }
 public string Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(string value) { 
 hasName = true;
 name_ = value;
 }

public const int itemFieldNumber = 9;
 private bool hasItem;
 private string item_ = "";
 public bool HasItem {
 get { return hasItem; }
 }
 public string Item {
 get { return item_; }
 set { SetItem(value); }
 }
 public void SetItem(string value) { 
 hasItem = true;
 item_ = value;
 }

public const int nextIDFieldNumber = 10;
 private bool hasNextID;
 private Int32 nextID_ = 0;
 public bool HasNextID {
 get { return hasNextID; }
 }
 public Int32 NextID {
 get { return nextID_; }
 set { SetNextID(value); }
 }
 public void SetNextID(Int32 value) { 
 hasNextID = true;
 nextID_ = value;
 }

public const int chargeFieldNumber = 11;
 private bool hasCharge;
 private string charge_ = "";
 public bool HasCharge {
 get { return hasCharge; }
 }
 public string Charge {
 get { return charge_; }
 set { SetCharge(value); }
 }
 public void SetCharge(string value) { 
 hasCharge = true;
 charge_ = value;
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
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasCurTotalBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, CurTotalBuyNum);
}
 if (HasCurMyBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, CurMyBuyNum);
}
 if (HasOverTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, OverTime);
}
 if (HasGroup) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Group);
}
 if (HasPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Price);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(8, Name);
}
 if (HasItem) {
size += pb::CodedOutputStream.ComputeStringSize(9, Item);
}
 if (HasNextID) {
size += pb::CodedOutputStream.ComputeInt32Size(10, NextID);
}
 if (HasCharge) {
size += pb::CodedOutputStream.ComputeStringSize(11, Charge);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasCurTotalBuyNum) {
output.WriteInt32(3, CurTotalBuyNum);
}
 
if (HasCurMyBuyNum) {
output.WriteInt32(4, CurMyBuyNum);
}
 
if (HasOverTime) {
output.WriteInt64(5, OverTime);
}
 
if (HasGroup) {
output.WriteInt32(6, Group);
}
 
if (HasPrice) {
output.WriteInt32(7, Price);
}
 
if (HasName) {
output.WriteString(8, Name);
}
 
if (HasItem) {
output.WriteString(9, Item);
}
 
if (HasNextID) {
output.WriteInt32(10, NextID);
}
 
if (HasCharge) {
output.WriteString(11, Charge);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 oneBuyInfo _inst = (oneBuyInfo) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.CurTotalBuyNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.CurMyBuyNum = input.ReadInt32();
break;
}
   case  40: {
 _inst.OverTime = input.ReadInt64();
break;
}
   case  48: {
 _inst.Group = input.ReadInt32();
break;
}
   case  56: {
 _inst.Price = input.ReadInt32();
break;
}
   case  66: {
 _inst.Name = input.ReadString();
break;
}
   case  74: {
 _inst.Item = input.ReadString();
break;
}
   case  80: {
 _inst.NextID = input.ReadInt32();
break;
}
   case  90: {
 _inst.Charge = input.ReadString();
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
