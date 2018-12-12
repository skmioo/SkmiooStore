//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBuyPet : PacketDistributed
{

public const int shopidFieldNumber = 1;
 private bool hasShopid;
 private Int32 shopid_ = 0;
 public bool HasShopid {
 get { return hasShopid; }
 }
 public Int32 Shopid {
 get { return shopid_; }
 set { SetShopid(value); }
 }
 public void SetShopid(Int32 value) { 
 hasShopid = true;
 shopid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasShopid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Shopid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasShopid) {
output.WriteInt32(1, Shopid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuyPet _inst = (CGBuyPet) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Shopid = input.ReadInt32();
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
public class CGGetPetList : PacketDistributed
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
 CGGetPetList _inst = (CGGetPetList) _base;
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
public class CGLookPet : PacketDistributed
{

public const int playerUidFieldNumber = 1;
 private bool hasPlayerUid;
 private Int64 playerUid_ = 0;
 public bool HasPlayerUid {
 get { return hasPlayerUid; }
 }
 public Int64 PlayerUid {
 get { return playerUid_; }
 set { SetPlayerUid(value); }
 }
 public void SetPlayerUid(Int64 value) { 
 hasPlayerUid = true;
 playerUid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerUid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerUid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerUid) {
output.WriteInt64(1, PlayerUid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLookPet _inst = (CGLookPet) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerUid = input.ReadInt64();
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
public class CGPetChangeCharacter : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetChangeCharacter _inst = (CGPetChangeCharacter) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
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
public class CGPetChangeName : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

public const int petNameFieldNumber = 2;
 private bool hasPetName;
 private string petName_ = "";
 public bool HasPetName {
 get { return hasPetName; }
 }
 public string PetName {
 get { return petName_; }
 set { SetPetName(value); }
 }
 public void SetPetName(string value) { 
 hasPetName = true;
 petName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 if (HasPetName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PetName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 
if (HasPetName) {
output.WriteString(2, PetName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetChangeName _inst = (CGPetChangeName) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
break;
}
   case  18: {
 _inst.PetName = input.ReadString();
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
public class CGPetChangeStatus : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

public const int battleflagFieldNumber = 2;
 private bool hasBattleflag;
 private Int32 battleflag_ = 0;
 public bool HasBattleflag {
 get { return hasBattleflag; }
 }
 public Int32 Battleflag {
 get { return battleflag_; }
 set { SetBattleflag(value); }
 }
 public void SetBattleflag(Int32 value) { 
 hasBattleflag = true;
 battleflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 if (HasBattleflag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Battleflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 
if (HasBattleflag) {
output.WriteInt32(2, Battleflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetChangeStatus _inst = (CGPetChangeStatus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Battleflag = input.ReadInt32();
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
public class CGPetCulture : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

public const int cultypeFieldNumber = 2;
 private bool hasCultype;
 private Int32 cultype_ = 0;
 public bool HasCultype {
 get { return hasCultype; }
 }
 public Int32 Cultype {
 get { return cultype_; }
 set { SetCultype(value); }
 }
 public void SetCultype(Int32 value) { 
 hasCultype = true;
 cultype_ = value;
 }

public const int istenFieldNumber = 3;
 private bool hasIsten;
 private Int32 isten_ = 0;
 public bool HasIsten {
 get { return hasIsten; }
 }
 public Int32 Isten {
 get { return isten_; }
 set { SetIsten(value); }
 }
 public void SetIsten(Int32 value) { 
 hasIsten = true;
 isten_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 if (HasCultype) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Cultype);
}
 if (HasIsten) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Isten);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 
if (HasCultype) {
output.WriteInt32(2, Cultype);
}
 
if (HasIsten) {
output.WriteInt32(3, Isten);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetCulture _inst = (CGPetCulture) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Cultype = input.ReadInt32();
break;
}
   case  24: {
 _inst.Isten = input.ReadInt32();
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
public class CGPetDeposit : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

public const int dptypeFieldNumber = 2;
 private bool hasDptype;
 private Int32 dptype_ = 0;
 public bool HasDptype {
 get { return hasDptype; }
 }
 public Int32 Dptype {
 get { return dptype_; }
 set { SetDptype(value); }
 }
 public void SetDptype(Int32 value) { 
 hasDptype = true;
 dptype_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 if (HasDptype) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Dptype);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 
if (HasDptype) {
output.WriteInt32(2, Dptype);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetDeposit _inst = (CGPetDeposit) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Dptype = input.ReadInt32();
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
public class CGPetEmbattle : PacketDistributed
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
 CGPetEmbattle _inst = (CGPetEmbattle) _base;
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
public class CGPetEmbattleAddPower : PacketDistributed
{

public const int autoPowerFieldNumber = 1;
 private bool hasAutoPower;
 private Int32 autoPower_ = 0;
 public bool HasAutoPower {
 get { return hasAutoPower; }
 }
 public Int32 AutoPower {
 get { return autoPower_; }
 set { SetAutoPower(value); }
 }
 public void SetAutoPower(Int32 value) { 
 hasAutoPower = true;
 autoPower_ = value;
 }

public const int notUseBakMoneyFieldNumber = 2;
 private bool hasNotUseBakMoney;
 private Int32 notUseBakMoney_ = 0;
 public bool HasNotUseBakMoney {
 get { return hasNotUseBakMoney; }
 }
 public Int32 NotUseBakMoney {
 get { return notUseBakMoney_; }
 set { SetNotUseBakMoney(value); }
 }
 public void SetNotUseBakMoney(Int32 value) { 
 hasNotUseBakMoney = true;
 notUseBakMoney_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoPower) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoPower);
}
 if (HasNotUseBakMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(2, NotUseBakMoney);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoPower) {
output.WriteInt32(1, AutoPower);
}
 
if (HasNotUseBakMoney) {
output.WriteInt32(2, NotUseBakMoney);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetEmbattleAddPower _inst = (CGPetEmbattleAddPower) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoPower = input.ReadInt32();
break;
}
   case  16: {
 _inst.NotUseBakMoney = input.ReadInt32();
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
public class CGPetGoupEmbattle : PacketDistributed
{

public const int lineFieldNumber = 1;
 private bool hasLine;
 private Int32 line_ = 0;
 public bool HasLine {
 get { return hasLine; }
 }
 public Int32 Line {
 get { return line_; }
 set { SetLine(value); }
 }
 public void SetLine(Int32 value) { 
 hasLine = true;
 line_ = value;
 }

public const int petidFieldNumber = 2;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLine) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Line);
}
 if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLine) {
output.WriteInt32(1, Line);
}
 
if (HasPetid) {
output.WriteInt64(2, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetGoupEmbattle _inst = (CGPetGoupEmbattle) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Line = input.ReadInt32();
break;
}
   case  16: {
 _inst.Petid = input.ReadInt64();
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
public class CGPetReFreshAttr : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetReFreshAttr _inst = (CGPetReFreshAttr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
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
public class CGPetRelease : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetRelease _inst = (CGPetRelease) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
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
public class CGPetSaveNewCharacter : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetSaveNewCharacter _inst = (CGPetSaveNewCharacter) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
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
public class CGPetStudySkill : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

public const int bookidFieldNumber = 2;
 private bool hasBookid;
 private Int32 bookid_ = 0;
 public bool HasBookid {
 get { return hasBookid; }
 }
 public Int32 Bookid {
 get { return bookid_; }
 set { SetBookid(value); }
 }
 public void SetBookid(Int32 value) { 
 hasBookid = true;
 bookid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 if (HasBookid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Bookid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 
if (HasBookid) {
output.WriteInt32(2, Bookid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetStudySkill _inst = (CGPetStudySkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Bookid = input.ReadInt32();
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
public class CGPetUpStar : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPetUpStar _inst = (CGPetUpStar) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
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
public class CGUnlockPetBag : PacketDistributed
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
 CGUnlockPetBag _inst = (CGUnlockPetBag) _base;
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
public class GCBuyPetBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int petinfoFieldNumber = 2;
 private bool hasPetinfo;
 private PetInfo petinfo_ =  new PetInfo();
 public bool HasPetinfo {
 get { return hasPetinfo; }
 }
 public PetInfo Petinfo {
 get { return petinfo_; }
 set { SetPetinfo(value); }
 }
 public void SetPetinfo(PetInfo value) { 
 hasPetinfo = true;
 petinfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
int subsize = Petinfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Petinfo.SerializedSize());
Petinfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBuyPetBack _inst = (GCBuyPetBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.Petinfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPetinfo) {
if (!Petinfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLookPetBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int petinfoFieldNumber = 2;
 private bool hasPetinfo;
 private PetInfo petinfo_ =  new PetInfo();
 public bool HasPetinfo {
 get { return hasPetinfo; }
 }
 public PetInfo Petinfo {
 get { return petinfo_; }
 set { SetPetinfo(value); }
 }
 public void SetPetinfo(PetInfo value) { 
 hasPetinfo = true;
 petinfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
int subsize = Petinfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Petinfo.SerializedSize());
Petinfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLookPetBack _inst = (GCLookPetBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.Petinfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPetinfo) {
if (!Petinfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetChangeCharacterBack : PacketDistributed
{

public const int petidFieldNumber = 1;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
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

public const int newCharacterFieldNumber = 3;
 private bool hasNewCharacter;
 private Int32 newCharacter_ = 0;
 public bool HasNewCharacter {
 get { return hasNewCharacter; }
 }
 public Int32 NewCharacter {
 get { return newCharacter_; }
 set { SetNewCharacter(value); }
 }
 public void SetNewCharacter(Int32 value) { 
 hasNewCharacter = true;
 newCharacter_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Petid);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
}
 if (HasNewCharacter) {
size += pb::CodedOutputStream.ComputeInt32Size(3, NewCharacter);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetid) {
output.WriteInt64(1, Petid);
}
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 
if (HasNewCharacter) {
output.WriteInt32(3, NewCharacter);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetChangeCharacterBack _inst = (GCPetChangeCharacterBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  24: {
 _inst.NewCharacter = input.ReadInt32();
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
public class GCPetChangeNameBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetChangeNameBack _inst = (GCPetChangeNameBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class GCPetChangeStatusBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int objIdFieldNumber = 2;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ObjId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 
if (HasObjId) {
output.WriteInt64(2, ObjId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetChangeStatusBack _inst = (GCPetChangeStatusBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  16: {
 _inst.ObjId = input.ReadInt64();
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
public class GCPetCultureBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int petAttrFieldNumber = 2;
 private pbc::PopsicleList<PetAttr> petAttr_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrList {
 get { return pbc::Lists.AsReadOnly(petAttr_); }
 }
 
 public int petAttrCount {
 get { return petAttr_.Count; }
 }
 
public PetAttr GetPetAttr(int index) {
 return petAttr_[index];
 }
 public void AddPetAttr(PetAttr value) {
 petAttr_.Add(value);
 }

public const int petAttrDownFieldNumber = 3;
 private pbc::PopsicleList<PetAttr> petAttrDown_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrDownList {
 get { return pbc::Lists.AsReadOnly(petAttrDown_); }
 }
 
 public int petAttrDownCount {
 get { return petAttrDown_.Count; }
 }
 
public PetAttr GetPetAttrDown(int index) {
 return petAttrDown_[index];
 }
 public void AddPetAttrDown(PetAttr value) {
 petAttrDown_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
foreach (PetAttr element in petAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (PetAttr element in petAttrDownList) {
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
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}

do{
foreach (PetAttr element in petAttrList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (PetAttr element in petAttrDownList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetCultureBack _inst = (GCPetCultureBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttr(subBuilder);
break;
}
    case  26: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttrDown(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetAttr element in petAttrList) {
if (!element.IsInitialized()) return false;
}
foreach (PetAttr element in petAttrDownList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetDepositBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetDepositBack _inst = (GCPetDepositBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class GCPetEmbattleAddPowerBack : PacketDistributed
{

public const int autoPowerFieldNumber = 1;
 private bool hasAutoPower;
 private Int32 autoPower_ = 0;
 public bool HasAutoPower {
 get { return hasAutoPower; }
 }
 public Int32 AutoPower {
 get { return autoPower_; }
 set { SetAutoPower(value); }
 }
 public void SetAutoPower(Int32 value) { 
 hasAutoPower = true;
 autoPower_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoPower) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoPower);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoPower) {
output.WriteInt32(1, AutoPower);
}
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetEmbattleAddPowerBack _inst = (GCPetEmbattleAddPowerBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoPower = input.ReadInt32();
break;
}
   case  16: {
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
public class GCPetEmbattleBack : PacketDistributed
{

public const int embattleInfoFieldNumber = 1;
 private pbc::PopsicleList<PetEmbattleInfo> embattleInfo_ = new pbc::PopsicleList<PetEmbattleInfo>();
 public scg::IList<PetEmbattleInfo> embattleInfoList {
 get { return pbc::Lists.AsReadOnly(embattleInfo_); }
 }
 
 public int embattleInfoCount {
 get { return embattleInfo_.Count; }
 }
 
public PetEmbattleInfo GetEmbattleInfo(int index) {
 return embattleInfo_[index];
 }
 public void AddEmbattleInfo(PetEmbattleInfo value) {
 embattleInfo_.Add(value);
 }

public const int powerFieldNumber = 2;
 private bool hasPower;
 private Int32 power_ = 0;
 public bool HasPower {
 get { return hasPower; }
 }
 public Int32 Power {
 get { return power_; }
 set { SetPower(value); }
 }
 public void SetPower(Int32 value) { 
 hasPower = true;
 power_ = value;
 }

public const int maxPowerFieldNumber = 3;
 private bool hasMaxPower;
 private Int32 maxPower_ = 0;
 public bool HasMaxPower {
 get { return hasMaxPower; }
 }
 public Int32 MaxPower {
 get { return maxPower_; }
 set { SetMaxPower(value); }
 }
 public void SetMaxPower(Int32 value) { 
 hasMaxPower = true;
 maxPower_ = value;
 }

public const int skillGroupFieldNumber = 4;
 private bool hasSkillGroup;
 private Int32 skillGroup_ = 0;
 public bool HasSkillGroup {
 get { return hasSkillGroup; }
 }
 public Int32 SkillGroup {
 get { return skillGroup_; }
 set { SetSkillGroup(value); }
 }
 public void SetSkillGroup(Int32 value) { 
 hasSkillGroup = true;
 skillGroup_ = value;
 }

public const int charAttrFieldNumber = 5;
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

public const int petAttrFieldNumber = 6;
 private pbc::PopsicleList<PetAttr> petAttr_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrList {
 get { return pbc::Lists.AsReadOnly(petAttr_); }
 }
 
 public int petAttrCount {
 get { return petAttr_.Count; }
 }
 
public PetAttr GetPetAttr(int index) {
 return petAttr_[index];
 }
 public void AddPetAttr(PetAttr value) {
 petAttr_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (PetEmbattleInfo element in embattleInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasPower) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Power);
}
 if (HasMaxPower) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MaxPower);
}
 if (HasSkillGroup) {
size += pb::CodedOutputStream.ComputeInt32Size(4, SkillGroup);
}
{
foreach (CharacterAttr element in charAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (PetAttr element in petAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (PetEmbattleInfo element in embattleInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasPower) {
output.WriteInt32(2, Power);
}
 
if (HasMaxPower) {
output.WriteInt32(3, MaxPower);
}
 
if (HasSkillGroup) {
output.WriteInt32(4, SkillGroup);
}

do{
foreach (CharacterAttr element in charAttrList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (PetAttr element in petAttrList) {
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetEmbattleBack _inst = (GCPetEmbattleBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
PetEmbattleInfo subBuilder =  new PetEmbattleInfo();
input.ReadMessage(subBuilder);
_inst.AddEmbattleInfo(subBuilder);
break;
}
   case  16: {
 _inst.Power = input.ReadInt32();
break;
}
   case  24: {
 _inst.MaxPower = input.ReadInt32();
break;
}
   case  32: {
 _inst.SkillGroup = input.ReadInt32();
break;
}
    case  42: {
CharacterAttr subBuilder =  new CharacterAttr();
input.ReadMessage(subBuilder);
_inst.AddCharAttr(subBuilder);
break;
}
    case  50: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttr(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetEmbattleInfo element in embattleInfoList) {
if (!element.IsInitialized()) return false;
}
foreach (CharacterAttr element in charAttrList) {
if (!element.IsInitialized()) return false;
}
foreach (PetAttr element in petAttrList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetEmbattleSkill : PacketDistributed
{

public const int skilldataFieldNumber = 1;
 private pbc::PopsicleList<SkillItemData> skilldata_ = new pbc::PopsicleList<SkillItemData>();
 public scg::IList<SkillItemData> skilldataList {
 get { return pbc::Lists.AsReadOnly(skilldata_); }
 }
 
 public int skilldataCount {
 get { return skilldata_.Count; }
 }
 
public SkillItemData GetSkilldata(int index) {
 return skilldata_[index];
 }
 public void AddSkilldata(SkillItemData value) {
 skilldata_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (SkillItemData element in skilldataList) {
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
foreach (SkillItemData element in skilldataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetEmbattleSkill _inst = (GCPetEmbattleSkill) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
SkillItemData subBuilder =  new SkillItemData();
input.ReadMessage(subBuilder);
_inst.AddSkilldata(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SkillItemData element in skilldataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetList : PacketDistributed
{

public const int petbagnumFieldNumber = 1;
 private bool hasPetbagnum;
 private Int32 petbagnum_ = 0;
 public bool HasPetbagnum {
 get { return hasPetbagnum; }
 }
 public Int32 Petbagnum {
 get { return petbagnum_; }
 set { SetPetbagnum(value); }
 }
 public void SetPetbagnum(Int32 value) { 
 hasPetbagnum = true;
 petbagnum_ = value;
 }

public const int petinfoFieldNumber = 2;
 private pbc::PopsicleList<PetInfo> petinfo_ = new pbc::PopsicleList<PetInfo>();
 public scg::IList<PetInfo> petinfoList {
 get { return pbc::Lists.AsReadOnly(petinfo_); }
 }
 
 public int petinfoCount {
 get { return petinfo_.Count; }
 }
 
public PetInfo GetPetinfo(int index) {
 return petinfo_[index];
 }
 public void AddPetinfo(PetInfo value) {
 petinfo_.Add(value);
 }

public const int petidFieldNumber = 3;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPetbagnum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Petbagnum);
}
{
foreach (PetInfo element in petinfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPetbagnum) {
output.WriteInt32(1, Petbagnum);
}

do{
foreach (PetInfo element in petinfoList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasPetid) {
output.WriteInt64(3, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetList _inst = (GCPetList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Petbagnum = input.ReadInt32();
break;
}
    case  18: {
PetInfo subBuilder =  new PetInfo();
input.ReadMessage(subBuilder);
_inst.AddPetinfo(subBuilder);
break;
}
   case  24: {
 _inst.Petid = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetInfo element in petinfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetReFreshAttrBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int petinfoFieldNumber = 2;
 private bool hasPetinfo;
 private PetInfo petinfo_ =  new PetInfo();
 public bool HasPetinfo {
 get { return hasPetinfo; }
 }
 public PetInfo Petinfo {
 get { return petinfo_; }
 set { SetPetinfo(value); }
 }
 public void SetPetinfo(PetInfo value) { 
 hasPetinfo = true;
 petinfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
int subsize = Petinfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Petinfo.SerializedSize());
Petinfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetReFreshAttrBack _inst = (GCPetReFreshAttrBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.Petinfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPetinfo) {
if (!Petinfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetReleaseBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetReleaseBack _inst = (GCPetReleaseBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class GCPetSaveNewCharacterBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int petinfoFieldNumber = 2;
 private bool hasPetinfo;
 private PetInfo petinfo_ =  new PetInfo();
 public bool HasPetinfo {
 get { return hasPetinfo; }
 }
 public PetInfo Petinfo {
 get { return petinfo_; }
 set { SetPetinfo(value); }
 }
 public void SetPetinfo(PetInfo value) { 
 hasPetinfo = true;
 petinfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
int subsize = Petinfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Petinfo.SerializedSize());
Petinfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetSaveNewCharacterBack _inst = (GCPetSaveNewCharacterBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.Petinfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPetinfo) {
if (!Petinfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetStudySkillBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int skilldataFieldNumber = 2;
 private pbc::PopsicleList<SkillItemData> skilldata_ = new pbc::PopsicleList<SkillItemData>();
 public scg::IList<SkillItemData> skilldataList {
 get { return pbc::Lists.AsReadOnly(skilldata_); }
 }
 
 public int skilldataCount {
 get { return skilldata_.Count; }
 }
 
public SkillItemData GetSkilldata(int index) {
 return skilldata_[index];
 }
 public void AddSkilldata(SkillItemData value) {
 skilldata_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
foreach (SkillItemData element in skilldataList) {
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
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}

do{
foreach (SkillItemData element in skilldataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetStudySkillBack _inst = (GCPetStudySkillBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
SkillItemData subBuilder =  new SkillItemData();
input.ReadMessage(subBuilder);
_inst.AddSkilldata(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (SkillItemData element in skilldataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPetUpStarBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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

public const int petAttrFieldNumber = 2;
 private pbc::PopsicleList<PetAttr> petAttr_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrList {
 get { return pbc::Lists.AsReadOnly(petAttr_); }
 }
 
 public int petAttrCount {
 get { return petAttr_.Count; }
 }
 
public PetAttr GetPetAttr(int index) {
 return petAttr_[index];
 }
 public void AddPetAttr(PetAttr value) {
 petAttr_.Add(value);
 }

public const int petAttrDownFieldNumber = 3;
 private pbc::PopsicleList<PetAttr> petAttrDown_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrDownList {
 get { return pbc::Lists.AsReadOnly(petAttrDown_); }
 }
 
 public int petAttrDownCount {
 get { return petAttrDown_.Count; }
 }
 
public PetAttr GetPetAttrDown(int index) {
 return petAttrDown_[index];
 }
 public void AddPetAttrDown(PetAttr value) {
 petAttrDown_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
{
foreach (PetAttr element in petAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (PetAttr element in petAttrDownList) {
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
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}

do{
foreach (PetAttr element in petAttrList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (PetAttr element in petAttrDownList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPetUpStarBack _inst = (GCPetUpStarBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flag = input.ReadInt32();
break;
}
    case  18: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttr(subBuilder);
break;
}
    case  26: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttrDown(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetAttr element in petAttrList) {
if (!element.IsInitialized()) return false;
}
foreach (PetAttr element in petAttrDownList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshPetData : PacketDistributed
{

public const int petinfoFieldNumber = 1;
 private pbc::PopsicleList<PetInfo> petinfo_ = new pbc::PopsicleList<PetInfo>();
 public scg::IList<PetInfo> petinfoList {
 get { return pbc::Lists.AsReadOnly(petinfo_); }
 }
 
 public int petinfoCount {
 get { return petinfo_.Count; }
 }
 
public PetInfo GetPetinfo(int index) {
 return petinfo_[index];
 }
 public void AddPetinfo(PetInfo value) {
 petinfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (PetInfo element in petinfoList) {
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
foreach (PetInfo element in petinfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshPetData _inst = (GCRefreshPetData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
PetInfo subBuilder =  new PetInfo();
input.ReadMessage(subBuilder);
_inst.AddPetinfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetInfo element in petinfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCUnlockPetBagBack : PacketDistributed
{

public const int flagFieldNumber = 1;
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
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlag) {
output.WriteInt32(1, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUnlockPetBagBack _inst = (GCUnlockPetBagBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class GCUpdatePetInfo : PacketDistributed
{

public const int petinfoFieldNumber = 1;
 private pbc::PopsicleList<PetInfo> petinfo_ = new pbc::PopsicleList<PetInfo>();
 public scg::IList<PetInfo> petinfoList {
 get { return pbc::Lists.AsReadOnly(petinfo_); }
 }
 
 public int petinfoCount {
 get { return petinfo_.Count; }
 }
 
public PetInfo GetPetinfo(int index) {
 return petinfo_[index];
 }
 public void AddPetinfo(PetInfo value) {
 petinfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (PetInfo element in petinfoList) {
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
foreach (PetInfo element in petinfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdatePetInfo _inst = (GCUpdatePetInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
PetInfo subBuilder =  new PetInfo();
input.ReadMessage(subBuilder);
_inst.AddPetinfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetInfo element in petinfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class PetEmbattleInfo : PacketDistributed
{

public const int lineFieldNumber = 1;
 private bool hasLine;
 private Int32 line_ = 0;
 public bool HasLine {
 get { return hasLine; }
 }
 public Int32 Line {
 get { return line_; }
 set { SetLine(value); }
 }
 public void SetLine(Int32 value) { 
 hasLine = true;
 line_ = value;
 }

public const int petidFieldNumber = 2;
 private bool hasPetid;
 private Int64 petid_ = 0;
 public bool HasPetid {
 get { return hasPetid; }
 }
 public Int64 Petid {
 get { return petid_; }
 set { SetPetid(value); }
 }
 public void SetPetid(Int64 value) { 
 hasPetid = true;
 petid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLine) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Line);
}
 if (HasPetid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Petid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLine) {
output.WriteInt32(1, Line);
}
 
if (HasPetid) {
output.WriteInt64(2, Petid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PetEmbattleInfo _inst = (PetEmbattleInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Line = input.ReadInt32();
break;
}
   case  16: {
 _inst.Petid = input.ReadInt64();
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
