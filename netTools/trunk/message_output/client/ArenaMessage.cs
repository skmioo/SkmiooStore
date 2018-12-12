//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class ArenaInfo : PacketDistributed
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

public const int nameFieldNumber = 2;
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

public const int fightValueFieldNumber = 3;
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

public const int divisionFieldNumber = 4;
 private bool hasDivision;
 private Int32 division_ = 0;
 public bool HasDivision {
 get { return hasDivision; }
 }
 public Int32 Division {
 get { return division_; }
 set { SetDivision(value); }
 }
 public void SetDivision(Int32 value) { 
 hasDivision = true;
 division_ = value;
 }

public const int isDivisionUpFieldNumber = 5;
 private bool hasIsDivisionUp;
 private Int32 isDivisionUp_ = 0;
 public bool HasIsDivisionUp {
 get { return hasIsDivisionUp; }
 }
 public Int32 IsDivisionUp {
 get { return isDivisionUp_; }
 set { SetIsDivisionUp(value); }
 }
 public void SetIsDivisionUp(Int32 value) { 
 hasIsDivisionUp = true;
 isDivisionUp_ = value;
 }

public const int rankFieldNumber = 6;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int pointsFieldNumber = 7;
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

public const int arenaCoinFieldNumber = 8;
 private bool hasArenaCoin;
 private Int32 arenaCoin_ = 0;
 public bool HasArenaCoin {
 get { return hasArenaCoin; }
 }
 public Int32 ArenaCoin {
 get { return arenaCoin_; }
 set { SetArenaCoin(value); }
 }
 public void SetArenaCoin(Int32 value) { 
 hasArenaCoin = true;
 arenaCoin_ = value;
 }

public const int remainTimeFieldNumber = 9;
 private bool hasRemainTime;
 private Int32 remainTime_ = 0;
 public bool HasRemainTime {
 get { return hasRemainTime; }
 }
 public Int32 RemainTime {
 get { return remainTime_; }
 set { SetRemainTime(value); }
 }
 public void SetRemainTime(Int32 value) { 
 hasRemainTime = true;
 remainTime_ = value;
 }

public const int cdTimeFieldNumber = 10;
 private bool hasCdTime;
 private Int32 cdTime_ = 0;
 public bool HasCdTime {
 get { return hasCdTime; }
 }
 public Int32 CdTime {
 get { return cdTime_; }
 set { SetCdTime(value); }
 }
 public void SetCdTime(Int32 value) { 
 hasCdTime = true;
 cdTime_ = value;
 }

public const int isCanFightFieldNumber = 12;
 private bool hasIsCanFight;
 private Int32 isCanFight_ = 0;
 public bool HasIsCanFight {
 get { return hasIsCanFight; }
 }
 public Int32 IsCanFight {
 get { return isCanFight_; }
 set { SetIsCanFight(value); }
 }
 public void SetIsCanFight(Int32 value) { 
 hasIsCanFight = true;
 isCanFight_ = value;
 }

public const int characterInfoFieldNumber = 13;
 private bool hasCharacterInfo;
 private CharacterInfo characterInfo_ =  new CharacterInfo();
 public bool HasCharacterInfo {
 get { return hasCharacterInfo; }
 }
 public CharacterInfo CharacterInfo {
 get { return characterInfo_; }
 set { SetCharacterInfo(value); }
 }
 public void SetCharacterInfo(CharacterInfo value) { 
 hasCharacterInfo = true;
 characterInfo_ = value;
 }

public const int rankOffsetFieldNumber = 14;
 private bool hasRankOffset;
 private Int32 rankOffset_ = 0;
 public bool HasRankOffset {
 get { return hasRankOffset; }
 }
 public Int32 RankOffset {
 get { return rankOffset_; }
 set { SetRankOffset(value); }
 }
 public void SetRankOffset(Int32 value) { 
 hasRankOffset = true;
 rankOffset_ = value;
 }

public const int headIconFieldNumber = 15;
 private bool hasHeadIcon;
 private Int32 headIcon_ = 0;
 public bool HasHeadIcon {
 get { return hasHeadIcon; }
 }
 public Int32 HeadIcon {
 get { return headIcon_; }
 set { SetHeadIcon(value); }
 }
 public void SetHeadIcon(Int32 value) { 
 hasHeadIcon = true;
 headIcon_ = value;
 }

public const int divisionRankFieldNumber = 16;
 private bool hasDivisionRank;
 private Int32 divisionRank_ = 0;
 public bool HasDivisionRank {
 get { return hasDivisionRank; }
 }
 public Int32 DivisionRank {
 get { return divisionRank_; }
 set { SetDivisionRank(value); }
 }
 public void SetDivisionRank(Int32 value) { 
 hasDivisionRank = true;
 divisionRank_ = value;
 }

public const int petConfigIdFieldNumber = 17;
 private bool hasPetConfigId;
 private Int32 petConfigId_ = 0;
 public bool HasPetConfigId {
 get { return hasPetConfigId; }
 }
 public Int32 PetConfigId {
 get { return petConfigId_; }
 set { SetPetConfigId(value); }
 }
 public void SetPetConfigId(Int32 value) { 
 hasPetConfigId = true;
 petConfigId_ = value;
 }

public const int remainVipBuyTimeFieldNumber = 18;
 private bool hasRemainVipBuyTime;
 private Int32 remainVipBuyTime_ = 0;
 public bool HasRemainVipBuyTime {
 get { return hasRemainVipBuyTime; }
 }
 public Int32 RemainVipBuyTime {
 get { return remainVipBuyTime_; }
 set { SetRemainVipBuyTime(value); }
 }
 public void SetRemainVipBuyTime(Int32 value) { 
 hasRemainVipBuyTime = true;
 remainVipBuyTime_ = value;
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
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasFightValue) {
size += pb::CodedOutputStream.ComputeInt32Size(3, FightValue);
}
 if (HasDivision) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Division);
}
 if (HasIsDivisionUp) {
size += pb::CodedOutputStream.ComputeInt32Size(5, IsDivisionUp);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Rank);
}
 if (HasPoints) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Points);
}
 if (HasArenaCoin) {
size += pb::CodedOutputStream.ComputeInt32Size(8, ArenaCoin);
}
 if (HasRemainTime) {
size += pb::CodedOutputStream.ComputeInt32Size(9, RemainTime);
}
 if (HasCdTime) {
size += pb::CodedOutputStream.ComputeInt32Size(10, CdTime);
}
 if (HasIsCanFight) {
size += pb::CodedOutputStream.ComputeInt32Size(12, IsCanFight);
}
{
int subsize = CharacterInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)13) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasRankOffset) {
size += pb::CodedOutputStream.ComputeInt32Size(14, RankOffset);
}
 if (HasHeadIcon) {
size += pb::CodedOutputStream.ComputeInt32Size(15, HeadIcon);
}
 if (HasDivisionRank) {
size += pb::CodedOutputStream.ComputeInt32Size(16, DivisionRank);
}
 if (HasPetConfigId) {
size += pb::CodedOutputStream.ComputeInt32Size(17, PetConfigId);
}
 if (HasRemainVipBuyTime) {
size += pb::CodedOutputStream.ComputeInt32Size(18, RemainVipBuyTime);
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
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasFightValue) {
output.WriteInt32(3, FightValue);
}
 
if (HasDivision) {
output.WriteInt32(4, Division);
}
 
if (HasIsDivisionUp) {
output.WriteInt32(5, IsDivisionUp);
}
 
if (HasRank) {
output.WriteInt32(6, Rank);
}
 
if (HasPoints) {
output.WriteInt32(7, Points);
}
 
if (HasArenaCoin) {
output.WriteInt32(8, ArenaCoin);
}
 
if (HasRemainTime) {
output.WriteInt32(9, RemainTime);
}
 
if (HasCdTime) {
output.WriteInt32(10, CdTime);
}
 
if (HasIsCanFight) {
output.WriteInt32(12, IsCanFight);
}
{
output.WriteTag((int)13, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)CharacterInfo.SerializedSize());
CharacterInfo.WriteTo(output);

}
 
if (HasRankOffset) {
output.WriteInt32(14, RankOffset);
}
 
if (HasHeadIcon) {
output.WriteInt32(15, HeadIcon);
}
 
if (HasDivisionRank) {
output.WriteInt32(16, DivisionRank);
}
 
if (HasPetConfigId) {
output.WriteInt32(17, PetConfigId);
}
 
if (HasRemainVipBuyTime) {
output.WriteInt32(18, RemainVipBuyTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ArenaInfo _inst = (ArenaInfo) _base;
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
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.FightValue = input.ReadInt32();
break;
}
   case  32: {
 _inst.Division = input.ReadInt32();
break;
}
   case  40: {
 _inst.IsDivisionUp = input.ReadInt32();
break;
}
   case  48: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  56: {
 _inst.Points = input.ReadInt32();
break;
}
   case  64: {
 _inst.ArenaCoin = input.ReadInt32();
break;
}
   case  72: {
 _inst.RemainTime = input.ReadInt32();
break;
}
   case  80: {
 _inst.CdTime = input.ReadInt32();
break;
}
   case  96: {
 _inst.IsCanFight = input.ReadInt32();
break;
}
    case  106: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.CharacterInfo = subBuilder;
break;
}
   case  112: {
 _inst.RankOffset = input.ReadInt32();
break;
}
   case  120: {
 _inst.HeadIcon = input.ReadInt32();
break;
}
   case  128: {
 _inst.DivisionRank = input.ReadInt32();
break;
}
   case  136: {
 _inst.PetConfigId = input.ReadInt32();
break;
}
   case  144: {
 _inst.RemainVipBuyTime = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasCharacterInfo) {
if (!CharacterInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGArenaBuyChance : PacketDistributed
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
 CGArenaBuyChance _inst = (CGArenaBuyChance) _base;
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
public class CGArenaClrCDTime : PacketDistributed
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
 CGArenaClrCDTime _inst = (CGArenaClrCDTime) _base;
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
public class CGArenaDivisionUp : PacketDistributed
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
 CGArenaDivisionUp _inst = (CGArenaDivisionUp) _base;
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
public class CGArenaFight : PacketDistributed
{

public const int pkIDFieldNumber = 1;
 private bool hasPkID;
 private Int64 pkID_ = 0;
 public bool HasPkID {
 get { return hasPkID; }
 }
 public Int64 PkID {
 get { return pkID_; }
 set { SetPkID(value); }
 }
 public void SetPkID(Int64 value) { 
 hasPkID = true;
 pkID_ = value;
 }

public const int rankFieldNumber = 2;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int devisionFieldNumber = 3;
 private bool hasDevision;
 private Int32 devision_ = 0;
 public bool HasDevision {
 get { return hasDevision; }
 }
 public Int32 Devision {
 get { return devision_; }
 set { SetDevision(value); }
 }
 public void SetDevision(Int32 value) { 
 hasDevision = true;
 devision_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPkID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PkID);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Rank);
}
 if (HasDevision) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Devision);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPkID) {
output.WriteInt64(1, PkID);
}
 
if (HasRank) {
output.WriteInt32(2, Rank);
}
 
if (HasDevision) {
output.WriteInt32(3, Devision);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGArenaFight _inst = (CGArenaFight) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PkID = input.ReadInt64();
break;
}
   case  16: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  24: {
 _inst.Devision = input.ReadInt32();
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
public class CGArenaFightRecord : PacketDistributed
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
 CGArenaFightRecord _inst = (CGArenaFightRecord) _base;
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
public class CGArenaOpen : PacketDistributed
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
 CGArenaOpen _inst = (CGArenaOpen) _base;
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
public class CGArenaQuit : PacketDistributed
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
 CGArenaQuit _inst = (CGArenaQuit) _base;
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
public class CGExchangeArenaShopItem : PacketDistributed
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
 CGExchangeArenaShopItem _inst = (CGExchangeArenaShopItem) _base;
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
public class CGGetArenaShopItems : PacketDistributed
{

public const int stateFieldNumber = 1;
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
  if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(1, State);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasState) {
output.WriteInt32(1, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetArenaShopItems _inst = (CGGetArenaShopItems) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class FightHistroyInfo : PacketDistributed
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

public const int isChangeFieldNumber = 2;
 private bool hasIsChange;
 private Int32 isChange_ = 0;
 public bool HasIsChange {
 get { return hasIsChange; }
 }
 public Int32 IsChange {
 get { return isChange_; }
 set { SetIsChange(value); }
 }
 public void SetIsChange(Int32 value) { 
 hasIsChange = true;
 isChange_ = value;
 }

public const int rankFieldNumber = 3;
 private bool hasRank;
 private Int32 rank_ = 0;
 public bool HasRank {
 get { return hasRank; }
 }
 public Int32 Rank {
 get { return rank_; }
 set { SetRank(value); }
 }
 public void SetRank(Int32 value) { 
 hasRank = true;
 rank_ = value;
 }

public const int rankOffsetFieldNumber = 4;
 private bool hasRankOffset;
 private Int32 rankOffset_ = 0;
 public bool HasRankOffset {
 get { return hasRankOffset; }
 }
 public Int32 RankOffset {
 get { return rankOffset_; }
 set { SetRankOffset(value); }
 }
 public void SetRankOffset(Int32 value) { 
 hasRankOffset = true;
 rankOffset_ = value;
 }

public const int enemyIDFieldNumber = 5;
 private bool hasEnemyID;
 private Int64 enemyID_ = 0;
 public bool HasEnemyID {
 get { return hasEnemyID; }
 }
 public Int64 EnemyID {
 get { return enemyID_; }
 set { SetEnemyID(value); }
 }
 public void SetEnemyID(Int64 value) { 
 hasEnemyID = true;
 enemyID_ = value;
 }

public const int enemyNameFieldNumber = 6;
 private bool hasEnemyName;
 private string enemyName_ = "";
 public bool HasEnemyName {
 get { return hasEnemyName; }
 }
 public string EnemyName {
 get { return enemyName_; }
 set { SetEnemyName(value); }
 }
 public void SetEnemyName(string value) { 
 hasEnemyName = true;
 enemyName_ = value;
 }

public const int fightTimeFieldNumber = 7;
 private bool hasFightTime;
 private Int64 fightTime_ = 0;
 public bool HasFightTime {
 get { return hasFightTime; }
 }
 public Int64 FightTime {
 get { return fightTime_; }
 set { SetFightTime(value); }
 }
 public void SetFightTime(Int64 value) { 
 hasFightTime = true;
 fightTime_ = value;
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
 if (HasIsChange) {
size += pb::CodedOutputStream.ComputeInt32Size(2, IsChange);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Rank);
}
 if (HasRankOffset) {
size += pb::CodedOutputStream.ComputeInt32Size(4, RankOffset);
}
 if (HasEnemyID) {
size += pb::CodedOutputStream.ComputeInt64Size(5, EnemyID);
}
 if (HasEnemyName) {
size += pb::CodedOutputStream.ComputeStringSize(6, EnemyName);
}
 if (HasFightTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, FightTime);
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
 
if (HasIsChange) {
output.WriteInt32(2, IsChange);
}
 
if (HasRank) {
output.WriteInt32(3, Rank);
}
 
if (HasRankOffset) {
output.WriteInt32(4, RankOffset);
}
 
if (HasEnemyID) {
output.WriteInt64(5, EnemyID);
}
 
if (HasEnemyName) {
output.WriteString(6, EnemyName);
}
 
if (HasFightTime) {
output.WriteInt64(7, FightTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FightHistroyInfo _inst = (FightHistroyInfo) _base;
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
 _inst.IsChange = input.ReadInt32();
break;
}
   case  24: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  32: {
 _inst.RankOffset = input.ReadInt32();
break;
}
   case  40: {
 _inst.EnemyID = input.ReadInt64();
break;
}
   case  50: {
 _inst.EnemyName = input.ReadString();
break;
}
   case  56: {
 _inst.FightTime = input.ReadInt64();
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
public class GCArenaBuyChance : PacketDistributed
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

public const int remainTimeFieldNumber = 2;
 private bool hasRemainTime;
 private Int32 remainTime_ = 0;
 public bool HasRemainTime {
 get { return hasRemainTime; }
 }
 public Int32 RemainTime {
 get { return remainTime_; }
 set { SetRemainTime(value); }
 }
 public void SetRemainTime(Int32 value) { 
 hasRemainTime = true;
 remainTime_ = value;
 }

public const int remainVipBuyTimeFieldNumber = 3;
 private bool hasRemainVipBuyTime;
 private Int32 remainVipBuyTime_ = 0;
 public bool HasRemainVipBuyTime {
 get { return hasRemainVipBuyTime; }
 }
 public Int32 RemainVipBuyTime {
 get { return remainVipBuyTime_; }
 set { SetRemainVipBuyTime(value); }
 }
 public void SetRemainVipBuyTime(Int32 value) { 
 hasRemainVipBuyTime = true;
 remainVipBuyTime_ = value;
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
 if (HasRemainTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RemainTime);
}
 if (HasRemainVipBuyTime) {
size += pb::CodedOutputStream.ComputeInt32Size(3, RemainVipBuyTime);
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
 
if (HasRemainTime) {
output.WriteInt32(2, RemainTime);
}
 
if (HasRemainVipBuyTime) {
output.WriteInt32(3, RemainVipBuyTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCArenaBuyChance _inst = (GCArenaBuyChance) _base;
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
 _inst.RemainTime = input.ReadInt32();
break;
}
   case  24: {
 _inst.RemainVipBuyTime = input.ReadInt32();
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
public class GCArenaClrCDTime : PacketDistributed
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
 GCArenaClrCDTime _inst = (GCArenaClrCDTime) _base;
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
public class GCArenaFight : PacketDistributed
{

public const int flgFieldNumber = 1;
 private bool hasFlg;
 private Int32 flg_ = 0;
 public bool HasFlg {
 get { return hasFlg; }
 }
 public Int32 Flg {
 get { return flg_; }
 set { SetFlg(value); }
 }
 public void SetFlg(Int32 value) { 
 hasFlg = true;
 flg_ = value;
 }

public const int senceIdFieldNumber = 2;
 private bool hasSenceId;
 private Int32 senceId_ = 0;
 public bool HasSenceId {
 get { return hasSenceId; }
 }
 public Int32 SenceId {
 get { return senceId_; }
 set { SetSenceId(value); }
 }
 public void SetSenceId(Int32 value) { 
 hasSenceId = true;
 senceId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlg) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flg);
}
 if (HasSenceId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, SenceId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFlg) {
output.WriteInt32(1, Flg);
}
 
if (HasSenceId) {
output.WriteInt32(2, SenceId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCArenaFight _inst = (GCArenaFight) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Flg = input.ReadInt32();
break;
}
   case  16: {
 _inst.SenceId = input.ReadInt32();
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
public class GCArenaFightRecord : PacketDistributed
{

public const int fightHistroyInfoFieldNumber = 1;
 private pbc::PopsicleList<FightHistroyInfo> fightHistroyInfo_ = new pbc::PopsicleList<FightHistroyInfo>();
 public scg::IList<FightHistroyInfo> fightHistroyInfoList {
 get { return pbc::Lists.AsReadOnly(fightHistroyInfo_); }
 }
 
 public int fightHistroyInfoCount {
 get { return fightHistroyInfo_.Count; }
 }
 
public FightHistroyInfo GetFightHistroyInfo(int index) {
 return fightHistroyInfo_[index];
 }
 public void AddFightHistroyInfo(FightHistroyInfo value) {
 fightHistroyInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (FightHistroyInfo element in fightHistroyInfoList) {
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
foreach (FightHistroyInfo element in fightHistroyInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCArenaFightRecord _inst = (GCArenaFightRecord) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
FightHistroyInfo subBuilder =  new FightHistroyInfo();
input.ReadMessage(subBuilder);
_inst.AddFightHistroyInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FightHistroyInfo element in fightHistroyInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCArenaFightResult : PacketDistributed
{

public const int isDivisionUpFieldNumber = 1;
 private bool hasIsDivisionUp;
 private Int32 isDivisionUp_ = 0;
 public bool HasIsDivisionUp {
 get { return hasIsDivisionUp; }
 }
 public Int32 IsDivisionUp {
 get { return isDivisionUp_; }
 set { SetIsDivisionUp(value); }
 }
 public void SetIsDivisionUp(Int32 value) { 
 hasIsDivisionUp = true;
 isDivisionUp_ = value;
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

public const int isExchangeFieldNumber = 3;
 private bool hasIsExchange;
 private Int32 isExchange_ = 0;
 public bool HasIsExchange {
 get { return hasIsExchange; }
 }
 public Int32 IsExchange {
 get { return isExchange_; }
 set { SetIsExchange(value); }
 }
 public void SetIsExchange(Int32 value) { 
 hasIsExchange = true;
 isExchange_ = value;
 }

public const int selfInfoFieldNumber = 4;
 private bool hasSelfInfo;
 private ArenaInfo selfInfo_ =  new ArenaInfo();
 public bool HasSelfInfo {
 get { return hasSelfInfo; }
 }
 public ArenaInfo SelfInfo {
 get { return selfInfo_; }
 set { SetSelfInfo(value); }
 }
 public void SetSelfInfo(ArenaInfo value) { 
 hasSelfInfo = true;
 selfInfo_ = value;
 }

public const int enemyInfoFieldNumber = 5;
 private bool hasEnemyInfo;
 private ArenaInfo enemyInfo_ =  new ArenaInfo();
 public bool HasEnemyInfo {
 get { return hasEnemyInfo; }
 }
 public ArenaInfo EnemyInfo {
 get { return enemyInfo_; }
 set { SetEnemyInfo(value); }
 }
 public void SetEnemyInfo(ArenaInfo value) { 
 hasEnemyInfo = true;
 enemyInfo_ = value;
 }

public const int expFieldNumber = 6;
 private bool hasExp;
 private Int32 exp_ = 0;
 public bool HasExp {
 get { return hasExp; }
 }
 public Int32 Exp {
 get { return exp_; }
 set { SetExp(value); }
 }
 public void SetExp(Int32 value) { 
 hasExp = true;
 exp_ = value;
 }

public const int arenaCoinFieldNumber = 7;
 private bool hasArenaCoin;
 private Int32 arenaCoin_ = 0;
 public bool HasArenaCoin {
 get { return hasArenaCoin; }
 }
 public Int32 ArenaCoin {
 get { return arenaCoin_; }
 set { SetArenaCoin(value); }
 }
 public void SetArenaCoin(Int32 value) { 
 hasArenaCoin = true;
 arenaCoin_ = value;
 }

public const int fightRewardFieldNumber = 8;
 private pbc::PopsicleList<ItemInfo> fightReward_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> fightRewardList {
 get { return pbc::Lists.AsReadOnly(fightReward_); }
 }
 
 public int fightRewardCount {
 get { return fightReward_.Count; }
 }
 
public ItemInfo GetFightReward(int index) {
 return fightReward_[index];
 }
 public void AddFightReward(ItemInfo value) {
 fightReward_.Add(value);
 }

public const int divisionUpRewardsFieldNumber = 9;
 private pbc::PopsicleList<ItemInfo> divisionUpRewards_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> divisionUpRewardsList {
 get { return pbc::Lists.AsReadOnly(divisionUpRewards_); }
 }
 
 public int divisionUpRewardsCount {
 get { return divisionUpRewards_.Count; }
 }
 
public ItemInfo GetDivisionUpRewards(int index) {
 return divisionUpRewards_[index];
 }
 public void AddDivisionUpRewards(ItemInfo value) {
 divisionUpRewards_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasIsDivisionUp) {
size += pb::CodedOutputStream.ComputeInt32Size(1, IsDivisionUp);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 if (HasIsExchange) {
size += pb::CodedOutputStream.ComputeInt32Size(3, IsExchange);
}
{
int subsize = SelfInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = EnemyInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasExp) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Exp);
}
 if (HasArenaCoin) {
size += pb::CodedOutputStream.ComputeInt32Size(7, ArenaCoin);
}
{
foreach (ItemInfo element in fightRewardList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ItemInfo element in divisionUpRewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasIsDivisionUp) {
output.WriteInt32(1, IsDivisionUp);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 
if (HasIsExchange) {
output.WriteInt32(3, IsExchange);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SelfInfo.SerializedSize());
SelfInfo.WriteTo(output);

}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)EnemyInfo.SerializedSize());
EnemyInfo.WriteTo(output);

}
 
if (HasExp) {
output.WriteInt32(6, Exp);
}
 
if (HasArenaCoin) {
output.WriteInt32(7, ArenaCoin);
}

do{
foreach (ItemInfo element in fightRewardList) {
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ItemInfo element in divisionUpRewardsList) {
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCArenaFightResult _inst = (GCArenaFightResult) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.IsDivisionUp = input.ReadInt32();
break;
}
   case  16: {
 _inst.Result = input.ReadInt32();
break;
}
   case  24: {
 _inst.IsExchange = input.ReadInt32();
break;
}
    case  34: {
ArenaInfo subBuilder =  new ArenaInfo();
 input.ReadMessage(subBuilder);
_inst.SelfInfo = subBuilder;
break;
}
    case  42: {
ArenaInfo subBuilder =  new ArenaInfo();
 input.ReadMessage(subBuilder);
_inst.EnemyInfo = subBuilder;
break;
}
   case  48: {
 _inst.Exp = input.ReadInt32();
break;
}
   case  56: {
 _inst.ArenaCoin = input.ReadInt32();
break;
}
    case  66: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddFightReward(subBuilder);
break;
}
    case  74: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddDivisionUpRewards(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasSelfInfo) {
if (!SelfInfo.IsInitialized()) return false;
}
  if (HasEnemyInfo) {
if (!EnemyInfo.IsInitialized()) return false;
}
foreach (ItemInfo element in fightRewardList) {
if (!element.IsInitialized()) return false;
}
foreach (ItemInfo element in divisionUpRewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCArenaOpen : PacketDistributed
{

public const int arenaInfoFieldNumber = 1;
 private bool hasArenaInfo;
 private ArenaInfo arenaInfo_ =  new ArenaInfo();
 public bool HasArenaInfo {
 get { return hasArenaInfo; }
 }
 public ArenaInfo ArenaInfo {
 get { return arenaInfo_; }
 set { SetArenaInfo(value); }
 }
 public void SetArenaInfo(ArenaInfo value) { 
 hasArenaInfo = true;
 arenaInfo_ = value;
 }

public const int arenaInfoListFieldNumber = 2;
 private pbc::PopsicleList<ArenaInfo> arenaInfoList_ = new pbc::PopsicleList<ArenaInfo>();
 public scg::IList<ArenaInfo> arenaInfoListList {
 get { return pbc::Lists.AsReadOnly(arenaInfoList_); }
 }
 
 public int arenaInfoListCount {
 get { return arenaInfoList_.Count; }
 }
 
public ArenaInfo GetArenaInfoList(int index) {
 return arenaInfoList_[index];
 }
 public void AddArenaInfoList(ArenaInfo value) {
 arenaInfoList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = ArenaInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (ArenaInfo element in arenaInfoListList) {
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
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ArenaInfo.SerializedSize());
ArenaInfo.WriteTo(output);

}

do{
foreach (ArenaInfo element in arenaInfoListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCArenaOpen _inst = (GCArenaOpen) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ArenaInfo subBuilder =  new ArenaInfo();
 input.ReadMessage(subBuilder);
_inst.ArenaInfo = subBuilder;
break;
}
    case  18: {
ArenaInfo subBuilder =  new ArenaInfo();
input.ReadMessage(subBuilder);
_inst.AddArenaInfoList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasArenaInfo) {
if (!ArenaInfo.IsInitialized()) return false;
}
foreach (ArenaInfo element in arenaInfoListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCExchangeArenaShopItem : PacketDistributed
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

public const int creditFieldNumber = 2;
 private bool hasCredit;
 private Int32 credit_ = 0;
 public bool HasCredit {
 get { return hasCredit; }
 }
 public Int32 Credit {
 get { return credit_; }
 set { SetCredit(value); }
 }
 public void SetCredit(Int32 value) { 
 hasCredit = true;
 credit_ = value;
 }

public const int arenaCoinFieldNumber = 3;
 private bool hasArenaCoin;
 private Int32 arenaCoin_ = 0;
 public bool HasArenaCoin {
 get { return hasArenaCoin; }
 }
 public Int32 ArenaCoin {
 get { return arenaCoin_; }
 set { SetArenaCoin(value); }
 }
 public void SetArenaCoin(Int32 value) { 
 hasArenaCoin = true;
 arenaCoin_ = value;
 }

public const int itemInfoFieldNumber = 4;
 private bool hasItemInfo;
 private EntryIntInt itemInfo_ =  new EntryIntInt();
 public bool HasItemInfo {
 get { return hasItemInfo; }
 }
 public EntryIntInt ItemInfo {
 get { return itemInfo_; }
 set { SetItemInfo(value); }
 }
 public void SetItemInfo(EntryIntInt value) { 
 hasItemInfo = true;
 itemInfo_ = value;
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
 if (HasCredit) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Credit);
}
 if (HasArenaCoin) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ArenaCoin);
}
{
int subsize = ItemInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 
if (HasCredit) {
output.WriteInt32(2, Credit);
}
 
if (HasArenaCoin) {
output.WriteInt32(3, ArenaCoin);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
ItemInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCExchangeArenaShopItem _inst = (GCExchangeArenaShopItem) _base;
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
 _inst.Credit = input.ReadInt32();
break;
}
   case  24: {
 _inst.ArenaCoin = input.ReadInt32();
break;
}
    case  34: {
EntryIntInt subBuilder =  new EntryIntInt();
 input.ReadMessage(subBuilder);
_inst.ItemInfo = subBuilder;
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
public class GCGetArenaShopItemsBack : PacketDistributed
{

public const int stateFieldNumber = 1;
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

public const int item1ListFieldNumber = 2;
 private pbc::PopsicleList<EntryIntInt> item1List_ = new pbc::PopsicleList<EntryIntInt>();
 public scg::IList<EntryIntInt> item1ListList {
 get { return pbc::Lists.AsReadOnly(item1List_); }
 }
 
 public int item1ListCount {
 get { return item1List_.Count; }
 }
 
public EntryIntInt GetItem1List(int index) {
 return item1List_[index];
 }
 public void AddItem1List(EntryIntInt value) {
 item1List_.Add(value);
 }

public const int item2ListFieldNumber = 3;
 private pbc::PopsicleList<EntryIntInt> item2List_ = new pbc::PopsicleList<EntryIntInt>();
 public scg::IList<EntryIntInt> item2ListList {
 get { return pbc::Lists.AsReadOnly(item2List_); }
 }
 
 public int item2ListCount {
 get { return item2List_.Count; }
 }
 
public EntryIntInt GetItem2List(int index) {
 return item2List_[index];
 }
 public void AddItem2List(EntryIntInt value) {
 item2List_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(1, State);
}
{
foreach (EntryIntInt element in item1ListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (EntryIntInt element in item2ListList) {
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
  
if (HasState) {
output.WriteInt32(1, State);
}

do{
foreach (EntryIntInt element in item1ListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (EntryIntInt element in item2ListList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetArenaShopItemsBack _inst = (GCGetArenaShopItemsBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.State = input.ReadInt32();
break;
}
    case  18: {
EntryIntInt subBuilder =  new EntryIntInt();
input.ReadMessage(subBuilder);
_inst.AddItem1List(subBuilder);
break;
}
    case  26: {
EntryIntInt subBuilder =  new EntryIntInt();
input.ReadMessage(subBuilder);
_inst.AddItem2List(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EntryIntInt element in item1ListList) {
if (!element.IsInitialized()) return false;
}
foreach (EntryIntInt element in item2ListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
