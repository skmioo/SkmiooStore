//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetPetOrHorseInfo : PacketDistributed
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

public const int petIDFieldNumber = 2;
 private bool hasPetID;
 private Int64 petID_ = 0;
 public bool HasPetID {
 get { return hasPetID; }
 }
 public Int64 PetID {
 get { return petID_; }
 set { SetPetID(value); }
 }
 public void SetPetID(Int64 value) { 
 hasPetID = true;
 petID_ = value;
 }

public const int horseIDFieldNumber = 3;
 private bool hasHorseID;
 private Int64 horseID_ = 0;
 public bool HasHorseID {
 get { return hasHorseID; }
 }
 public Int64 HorseID {
 get { return horseID_; }
 set { SetHorseID(value); }
 }
 public void SetHorseID(Int64 value) { 
 hasHorseID = true;
 horseID_ = value;
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
 if (HasPetID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PetID);
}
 if (HasHorseID) {
size += pb::CodedOutputStream.ComputeInt64Size(3, HorseID);
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
 
if (HasPetID) {
output.WriteInt64(2, PetID);
}
 
if (HasHorseID) {
output.WriteInt64(3, HorseID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetPetOrHorseInfo _inst = (CGGetPetOrHorseInfo) _base;
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
 _inst.PetID = input.ReadInt64();
break;
}
   case  24: {
 _inst.HorseID = input.ReadInt64();
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
public class CGGetRankByType : PacketDistributed
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
 CGGetRankByType _inst = (CGGetRankByType) _base;
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
public class CGRankWorship : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGRankWorship _inst = (CGRankWorship) _base;
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
public class FightInfo : PacketDistributed
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

public const int fightingFieldNumber = 2;
 private bool hasFighting;
 private string fighting_ = "";
 public bool HasFighting {
 get { return hasFighting; }
 }
 public string Fighting {
 get { return fighting_; }
 set { SetFighting(value); }
 }
 public void SetFighting(string value) { 
 hasFighting = true;
 fighting_ = value;
 }

public const int horseFieldNumber = 3;
 private bool hasHorse;
 private string horse_ = "";
 public bool HasHorse {
 get { return hasHorse; }
 }
 public string Horse {
 get { return horse_; }
 set { SetHorse(value); }
 }
 public void SetHorse(string value) { 
 hasHorse = true;
 horse_ = value;
 }

public const int modelFieldNumber = 4;
 private bool hasModel;
 private Int32 model_ = 0;
 public bool HasModel {
 get { return hasModel; }
 }
 public Int32 Model {
 get { return model_; }
 set { SetModel(value); }
 }
 public void SetModel(Int32 value) { 
 hasModel = true;
 model_ = value;
 }

public const int positionFieldNumber = 5;
 private bool hasPosition;
 private string position_ = "";
 public bool HasPosition {
 get { return hasPosition; }
 }
 public string Position {
 get { return position_; }
 set { SetPosition(value); }
 }
 public void SetPosition(string value) { 
 hasPosition = true;
 position_ = value;
 }

public const int scaleFieldNumber = 6;
 private bool hasScale;
 private string scale_ = "";
 public bool HasScale {
 get { return hasScale; }
 }
 public string Scale {
 get { return scale_; }
 set { SetScale(value); }
 }
 public void SetScale(string value) { 
 hasScale = true;
 scale_ = value;
 }

public const int rotateFieldNumber = 7;
 private bool hasRotate;
 private string rotate_ = "";
 public bool HasRotate {
 get { return hasRotate; }
 }
 public string Rotate {
 get { return rotate_; }
 set { SetRotate(value); }
 }
 public void SetRotate(string value) { 
 hasRotate = true;
 rotate_ = value;
 }

public const int rewardsFieldNumber = 8;
 private bool hasRewards;
 private string rewards_ = "";
 public bool HasRewards {
 get { return hasRewards; }
 }
 public string Rewards {
 get { return rewards_; }
 set { SetRewards(value); }
 }
 public void SetRewards(string value) { 
 hasRewards = true;
 rewards_ = value;
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
 if (HasFighting) {
size += pb::CodedOutputStream.ComputeStringSize(2, Fighting);
}
 if (HasHorse) {
size += pb::CodedOutputStream.ComputeStringSize(3, Horse);
}
 if (HasModel) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Model);
}
 if (HasPosition) {
size += pb::CodedOutputStream.ComputeStringSize(5, Position);
}
 if (HasScale) {
size += pb::CodedOutputStream.ComputeStringSize(6, Scale);
}
 if (HasRotate) {
size += pb::CodedOutputStream.ComputeStringSize(7, Rotate);
}
 if (HasRewards) {
size += pb::CodedOutputStream.ComputeStringSize(8, Rewards);
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
 
if (HasFighting) {
output.WriteString(2, Fighting);
}
 
if (HasHorse) {
output.WriteString(3, Horse);
}
 
if (HasModel) {
output.WriteInt32(4, Model);
}
 
if (HasPosition) {
output.WriteString(5, Position);
}
 
if (HasScale) {
output.WriteString(6, Scale);
}
 
if (HasRotate) {
output.WriteString(7, Rotate);
}
 
if (HasRewards) {
output.WriteString(8, Rewards);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FightInfo _inst = (FightInfo) _base;
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
 _inst.Fighting = input.ReadString();
break;
}
   case  26: {
 _inst.Horse = input.ReadString();
break;
}
   case  32: {
 _inst.Model = input.ReadInt32();
break;
}
   case  42: {
 _inst.Position = input.ReadString();
break;
}
   case  50: {
 _inst.Scale = input.ReadString();
break;
}
   case  58: {
 _inst.Rotate = input.ReadString();
break;
}
   case  66: {
 _inst.Rewards = input.ReadString();
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
public class GCOpenRankOver : PacketDistributed
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
 GCOpenRankOver _inst = (GCOpenRankOver) _base;
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
public class GCPushOpenInfo : PacketDistributed
{

public const int firstInfosFieldNumber = 1;
 private pbc::PopsicleList<FightInfo> firstInfos_ = new pbc::PopsicleList<FightInfo>();
 public scg::IList<FightInfo> firstInfosList {
 get { return pbc::Lists.AsReadOnly(firstInfos_); }
 }
 
 public int firstInfosCount {
 get { return firstInfos_.Count; }
 }
 
public FightInfo GetFirstInfos(int index) {
 return firstInfos_[index];
 }
 public void AddFirstInfos(FightInfo value) {
 firstInfos_.Add(value);
 }

public const int levelInfosFieldNumber = 2;
 private pbc::PopsicleList<LevelInfo> levelInfos_ = new pbc::PopsicleList<LevelInfo>();
 public scg::IList<LevelInfo> levelInfosList {
 get { return pbc::Lists.AsReadOnly(levelInfos_); }
 }
 
 public int levelInfosCount {
 get { return levelInfos_.Count; }
 }
 
public LevelInfo GetLevelInfos(int index) {
 return levelInfos_[index];
 }
 public void AddLevelInfos(LevelInfo value) {
 levelInfos_.Add(value);
 }

public const int levelStartTimeFieldNumber = 3;
 private bool hasLevelStartTime;
 private Int64 levelStartTime_ = 0;
 public bool HasLevelStartTime {
 get { return hasLevelStartTime; }
 }
 public Int64 LevelStartTime {
 get { return levelStartTime_; }
 set { SetLevelStartTime(value); }
 }
 public void SetLevelStartTime(Int64 value) { 
 hasLevelStartTime = true;
 levelStartTime_ = value;
 }

public const int levelEndTimeFieldNumber = 4;
 private bool hasLevelEndTime;
 private Int64 levelEndTime_ = 0;
 public bool HasLevelEndTime {
 get { return hasLevelEndTime; }
 }
 public Int64 LevelEndTime {
 get { return levelEndTime_; }
 set { SetLevelEndTime(value); }
 }
 public void SetLevelEndTime(Int64 value) { 
 hasLevelEndTime = true;
 levelEndTime_ = value;
 }

public const int fightStartTimeFieldNumber = 5;
 private bool hasFightStartTime;
 private Int64 fightStartTime_ = 0;
 public bool HasFightStartTime {
 get { return hasFightStartTime; }
 }
 public Int64 FightStartTime {
 get { return fightStartTime_; }
 set { SetFightStartTime(value); }
 }
 public void SetFightStartTime(Int64 value) { 
 hasFightStartTime = true;
 fightStartTime_ = value;
 }

public const int fightEndTimeFieldNumber = 6;
 private bool hasFightEndTime;
 private Int64 fightEndTime_ = 0;
 public bool HasFightEndTime {
 get { return hasFightEndTime; }
 }
 public Int64 FightEndTime {
 get { return fightEndTime_; }
 set { SetFightEndTime(value); }
 }
 public void SetFightEndTime(Int64 value) { 
 hasFightEndTime = true;
 fightEndTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (FightInfo element in firstInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (LevelInfo element in levelInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasLevelStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, LevelStartTime);
}
 if (HasLevelEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, LevelEndTime);
}
 if (HasFightStartTime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, FightStartTime);
}
 if (HasFightEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, FightEndTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (FightInfo element in firstInfosList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (LevelInfo element in levelInfosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasLevelStartTime) {
output.WriteInt64(3, LevelStartTime);
}
 
if (HasLevelEndTime) {
output.WriteInt64(4, LevelEndTime);
}
 
if (HasFightStartTime) {
output.WriteInt64(5, FightStartTime);
}
 
if (HasFightEndTime) {
output.WriteInt64(6, FightEndTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushOpenInfo _inst = (GCPushOpenInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
FightInfo subBuilder =  new FightInfo();
input.ReadMessage(subBuilder);
_inst.AddFirstInfos(subBuilder);
break;
}
    case  18: {
LevelInfo subBuilder =  new LevelInfo();
input.ReadMessage(subBuilder);
_inst.AddLevelInfos(subBuilder);
break;
}
   case  24: {
 _inst.LevelStartTime = input.ReadInt64();
break;
}
   case  32: {
 _inst.LevelEndTime = input.ReadInt64();
break;
}
   case  40: {
 _inst.FightStartTime = input.ReadInt64();
break;
}
   case  48: {
 _inst.FightEndTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (FightInfo element in firstInfosList) {
if (!element.IsInitialized()) return false;
}
foreach (LevelInfo element in levelInfosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushRankInfo : PacketDistributed
{

public const int rankInfoFieldNumber = 1;
 private pbc::PopsicleList<RankInfo> rankInfo_ = new pbc::PopsicleList<RankInfo>();
 public scg::IList<RankInfo> rankInfoList {
 get { return pbc::Lists.AsReadOnly(rankInfo_); }
 }
 
 public int rankInfoCount {
 get { return rankInfo_.Count; }
 }
 
public RankInfo GetRankInfo(int index) {
 return rankInfo_[index];
 }
 public void AddRankInfo(RankInfo value) {
 rankInfo_.Add(value);
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

public const int firstInfoFieldNumber = 4;
 private bool hasFirstInfo;
 private CharacterInfo firstInfo_ =  new CharacterInfo();
 public bool HasFirstInfo {
 get { return hasFirstInfo; }
 }
 public CharacterInfo FirstInfo {
 get { return firstInfo_; }
 set { SetFirstInfo(value); }
 }
 public void SetFirstInfo(CharacterInfo value) { 
 hasFirstInfo = true;
 firstInfo_ = value;
 }

public const int petInfoFieldNumber = 5;
 private bool hasPetInfo;
 private PetInfo petInfo_ =  new PetInfo();
 public bool HasPetInfo {
 get { return hasPetInfo; }
 }
 public PetInfo PetInfo {
 get { return petInfo_; }
 set { SetPetInfo(value); }
 }
 public void SetPetInfo(PetInfo value) { 
 hasPetInfo = true;
 petInfo_ = value;
 }

public const int horseInfoFieldNumber = 6;
 private bool hasHorseInfo;
 private HorseInfo horseInfo_ =  new HorseInfo();
 public bool HasHorseInfo {
 get { return hasHorseInfo; }
 }
 public HorseInfo HorseInfo {
 get { return horseInfo_; }
 set { SetHorseInfo(value); }
 }
 public void SetHorseInfo(HorseInfo value) { 
 hasHorseInfo = true;
 horseInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RankInfo element in rankInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
}
{
int subsize = FirstInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = PetInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = HorseInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (RankInfo element in rankInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)FirstInfo.SerializedSize());
FirstInfo.WriteTo(output);

}
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PetInfo.SerializedSize());
PetInfo.WriteTo(output);

}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)HorseInfo.SerializedSize());
HorseInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushRankInfo _inst = (GCPushRankInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RankInfo subBuilder =  new RankInfo();
input.ReadMessage(subBuilder);
_inst.AddRankInfo(subBuilder);
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.Num = input.ReadInt32();
break;
}
    case  34: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.FirstInfo = subBuilder;
break;
}
    case  42: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.PetInfo = subBuilder;
break;
}
    case  50: {
HorseInfo subBuilder =  new HorseInfo();
 input.ReadMessage(subBuilder);
_inst.HorseInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RankInfo element in rankInfoList) {
if (!element.IsInitialized()) return false;
}
  if (HasFirstInfo) {
if (!FirstInfo.IsInitialized()) return false;
}
  if (HasPetInfo) {
if (!PetInfo.IsInitialized()) return false;
}
  if (HasHorseInfo) {
if (!HorseInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushWorship : PacketDistributed
{

public const int numFieldNumber = 1;
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
  if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Num);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasNum) {
output.WriteInt32(1, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushWorship _inst = (GCPushWorship) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
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
public class GCRankWrshipBack : PacketDistributed
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

public const int worshipFieldNumber = 2;
 private bool hasWorship;
 private Int64 worship_ = 0;
 public bool HasWorship {
 get { return hasWorship; }
 }
 public Int64 Worship {
 get { return worship_; }
 set { SetWorship(value); }
 }
 public void SetWorship(Int64 value) { 
 hasWorship = true;
 worship_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
}
 if (HasWorship) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Worship);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Num);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Result);
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
 
if (HasWorship) {
output.WriteInt64(2, Worship);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 
if (HasNum) {
output.WriteInt32(4, Num);
}
 
if (HasResult) {
output.WriteInt32(5, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRankWrshipBack _inst = (GCRankWrshipBack) _base;
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
 _inst.Worship = input.ReadInt64();
break;
}
   case  24: {
 _inst.Type = input.ReadInt32();
break;
}
   case  32: {
 _inst.Num = input.ReadInt32();
break;
}
   case  40: {
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
public class GCRefreshRank : PacketDistributed
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
 GCRefreshRank _inst = (GCRefreshRank) _base;
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
public class GCSendPetOrHorseInfo : PacketDistributed
{

public const int petInfoFieldNumber = 1;
 private bool hasPetInfo;
 private PetInfo petInfo_ =  new PetInfo();
 public bool HasPetInfo {
 get { return hasPetInfo; }
 }
 public PetInfo PetInfo {
 get { return petInfo_; }
 set { SetPetInfo(value); }
 }
 public void SetPetInfo(PetInfo value) { 
 hasPetInfo = true;
 petInfo_ = value;
 }

public const int horseInfoFieldNumber = 2;
 private bool hasHorseInfo;
 private HorseInfo horseInfo_ =  new HorseInfo();
 public bool HasHorseInfo {
 get { return hasHorseInfo; }
 }
 public HorseInfo HorseInfo {
 get { return horseInfo_; }
 set { SetHorseInfo(value); }
 }
 public void SetHorseInfo(HorseInfo value) { 
 hasHorseInfo = true;
 horseInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = PetInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = HorseInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PetInfo.SerializedSize());
PetInfo.WriteTo(output);

}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)HorseInfo.SerializedSize());
HorseInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendPetOrHorseInfo _inst = (GCSendPetOrHorseInfo) _base;
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
_inst.PetInfo = subBuilder;
break;
}
    case  18: {
HorseInfo subBuilder =  new HorseInfo();
 input.ReadMessage(subBuilder);
_inst.HorseInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPetInfo) {
if (!PetInfo.IsInitialized()) return false;
}
  if (HasHorseInfo) {
if (!HorseInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class LevelInfo : PacketDistributed
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

public const int fightingFieldNumber = 2;
 private bool hasFighting;
 private string fighting_ = "";
 public bool HasFighting {
 get { return hasFighting; }
 }
 public string Fighting {
 get { return fighting_; }
 set { SetFighting(value); }
 }
 public void SetFighting(string value) { 
 hasFighting = true;
 fighting_ = value;
 }

public const int titleFieldNumber = 3;
 private bool hasTitle;
 private Int32 title_ = 0;
 public bool HasTitle {
 get { return hasTitle; }
 }
 public Int32 Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(Int32 value) { 
 hasTitle = true;
 title_ = value;
 }

public const int positionFieldNumber = 4;
 private bool hasPosition;
 private string position_ = "";
 public bool HasPosition {
 get { return hasPosition; }
 }
 public string Position {
 get { return position_; }
 set { SetPosition(value); }
 }
 public void SetPosition(string value) { 
 hasPosition = true;
 position_ = value;
 }

public const int scaleFieldNumber = 5;
 private bool hasScale;
 private string scale_ = "";
 public bool HasScale {
 get { return hasScale; }
 }
 public string Scale {
 get { return scale_; }
 set { SetScale(value); }
 }
 public void SetScale(string value) { 
 hasScale = true;
 scale_ = value;
 }

public const int rewardsFieldNumber = 6;
 private bool hasRewards;
 private string rewards_ = "";
 public bool HasRewards {
 get { return hasRewards; }
 }
 public string Rewards {
 get { return rewards_; }
 set { SetRewards(value); }
 }
 public void SetRewards(string value) { 
 hasRewards = true;
 rewards_ = value;
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
 if (HasFighting) {
size += pb::CodedOutputStream.ComputeStringSize(2, Fighting);
}
 if (HasTitle) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Title);
}
 if (HasPosition) {
size += pb::CodedOutputStream.ComputeStringSize(4, Position);
}
 if (HasScale) {
size += pb::CodedOutputStream.ComputeStringSize(5, Scale);
}
 if (HasRewards) {
size += pb::CodedOutputStream.ComputeStringSize(6, Rewards);
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
 
if (HasFighting) {
output.WriteString(2, Fighting);
}
 
if (HasTitle) {
output.WriteInt32(3, Title);
}
 
if (HasPosition) {
output.WriteString(4, Position);
}
 
if (HasScale) {
output.WriteString(5, Scale);
}
 
if (HasRewards) {
output.WriteString(6, Rewards);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LevelInfo _inst = (LevelInfo) _base;
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
 _inst.Fighting = input.ReadString();
break;
}
   case  24: {
 _inst.Title = input.ReadInt32();
break;
}
   case  34: {
 _inst.Position = input.ReadString();
break;
}
   case  42: {
 _inst.Scale = input.ReadString();
break;
}
   case  50: {
 _inst.Rewards = input.ReadString();
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
public class RankInfo : PacketDistributed
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

public const int playerNameFieldNumber = 2;
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

public const int rankFieldNumber = 4;
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

public const int battleFieldNumber = 5;
 private bool hasBattle;
 private Int32 battle_ = 0;
 public bool HasBattle {
 get { return hasBattle; }
 }
 public Int32 Battle {
 get { return battle_; }
 set { SetBattle(value); }
 }
 public void SetBattle(Int32 value) { 
 hasBattle = true;
 battle_ = value;
 }

public const int moneyNumFieldNumber = 6;
 private bool hasMoneyNum;
 private Int64 moneyNum_ = 0;
 public bool HasMoneyNum {
 get { return hasMoneyNum; }
 }
 public Int64 MoneyNum {
 get { return moneyNum_; }
 set { SetMoneyNum(value); }
 }
 public void SetMoneyNum(Int64 value) { 
 hasMoneyNum = true;
 moneyNum_ = value;
 }

public const int petBattleFieldNumber = 7;
 private bool hasPetBattle;
 private Int32 petBattle_ = 0;
 public bool HasPetBattle {
 get { return hasPetBattle; }
 }
 public Int32 PetBattle {
 get { return petBattle_; }
 set { SetPetBattle(value); }
 }
 public void SetPetBattle(Int32 value) { 
 hasPetBattle = true;
 petBattle_ = value;
 }

public const int horseBattleFieldNumber = 8;
 private bool hasHorseBattle;
 private Int32 horseBattle_ = 0;
 public bool HasHorseBattle {
 get { return hasHorseBattle; }
 }
 public Int32 HorseBattle {
 get { return horseBattle_; }
 set { SetHorseBattle(value); }
 }
 public void SetHorseBattle(Int32 value) { 
 hasHorseBattle = true;
 horseBattle_ = value;
 }

public const int arenaRankFieldNumber = 9;
 private bool hasArenaRank;
 private Int32 arenaRank_ = 0;
 public bool HasArenaRank {
 get { return hasArenaRank; }
 }
 public Int32 ArenaRank {
 get { return arenaRank_; }
 set { SetArenaRank(value); }
 }
 public void SetArenaRank(Int32 value) { 
 hasArenaRank = true;
 arenaRank_ = value;
 }

public const int topTowerFieldNumber = 10;
 private bool hasTopTower;
 private Int32 topTower_ = 0;
 public bool HasTopTower {
 get { return hasTopTower; }
 }
 public Int32 TopTower {
 get { return topTower_; }
 set { SetTopTower(value); }
 }
 public void SetTopTower(Int32 value) { 
 hasTopTower = true;
 topTower_ = value;
 }

public const int outPutFieldNumber = 11;
 private bool hasOutPut;
 private string outPut_ = "";
 public bool HasOutPut {
 get { return hasOutPut; }
 }
 public string OutPut {
 get { return outPut_; }
 set { SetOutPut(value); }
 }
 public void SetOutPut(string value) { 
 hasOutPut = true;
 outPut_ = value;
 }

public const int onlineTimeFieldNumber = 12;
 private bool hasOnlineTime;
 private Int64 onlineTime_ = 0;
 public bool HasOnlineTime {
 get { return hasOnlineTime; }
 }
 public Int64 OnlineTime {
 get { return onlineTime_; }
 set { SetOnlineTime(value); }
 }
 public void SetOnlineTime(Int64 value) { 
 hasOnlineTime = true;
 onlineTime_ = value;
 }

public const int gangBattleFieldNumber = 13;
 private bool hasGangBattle;
 private Int32 gangBattle_ = 0;
 public bool HasGangBattle {
 get { return hasGangBattle; }
 }
 public Int32 GangBattle {
 get { return gangBattle_; }
 set { SetGangBattle(value); }
 }
 public void SetGangBattle(Int32 value) { 
 hasGangBattle = true;
 gangBattle_ = value;
 }

public const int petIDFieldNumber = 14;
 private bool hasPetID;
 private Int64 petID_ = 0;
 public bool HasPetID {
 get { return hasPetID; }
 }
 public Int64 PetID {
 get { return petID_; }
 set { SetPetID(value); }
 }
 public void SetPetID(Int64 value) { 
 hasPetID = true;
 petID_ = value;
 }

public const int horseIDFieldNumber = 15;
 private bool hasHorseID;
 private Int64 horseID_ = 0;
 public bool HasHorseID {
 get { return hasHorseID; }
 }
 public Int64 HorseID {
 get { return horseID_; }
 set { SetHorseID(value); }
 }
 public void SetHorseID(Int64 value) { 
 hasHorseID = true;
 horseID_ = value;
 }

public const int worshipFieldNumber = 16;
 private bool hasWorship;
 private Int64 worship_ = 0;
 public bool HasWorship {
 get { return hasWorship; }
 }
 public Int64 Worship {
 get { return worship_; }
 set { SetWorship(value); }
 }
 public void SetWorship(Int64 value) { 
 hasWorship = true;
 worship_ = value;
 }

public const int levelFieldNumber = 17;
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

public const int winNumFieldNumber = 18;
 private bool hasWinNum;
 private Int32 winNum_ = 0;
 public bool HasWinNum {
 get { return hasWinNum; }
 }
 public Int32 WinNum {
 get { return winNum_; }
 set { SetWinNum(value); }
 }
 public void SetWinNum(Int32 value) { 
 hasWinNum = true;
 winNum_ = value;
 }

public const int gangIDFieldNumber = 19;
 private bool hasGangID;
 private Int64 gangID_ = 0;
 public bool HasGangID {
 get { return hasGangID; }
 }
 public Int64 GangID {
 get { return gangID_; }
 set { SetGangID(value); }
 }
 public void SetGangID(Int64 value) { 
 hasGangID = true;
 gangID_ = value;
 }

public const int isWorshipFieldNumber = 20;
 private bool hasIsWorship;
 private Int32 isWorship_ = 0;
 public bool HasIsWorship {
 get { return hasIsWorship; }
 }
 public Int32 IsWorship {
 get { return isWorship_; }
 set { SetIsWorship(value); }
 }
 public void SetIsWorship(Int32 value) { 
 hasIsWorship = true;
 isWorship_ = value;
 }

public const int vipFieldNumber = 21;
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

public const int killPlayersFieldNumber = 22;
 private bool hasKillPlayers;
 private Int32 killPlayers_ = 0;
 public bool HasKillPlayers {
 get { return hasKillPlayers; }
 }
 public Int32 KillPlayers {
 get { return killPlayers_; }
 set { SetKillPlayers(value); }
 }
 public void SetKillPlayers(Int32 value) { 
 hasKillPlayers = true;
 killPlayers_ = value;
 }

public const int killValueFieldNumber = 23;
 private bool hasKillValue;
 private Int32 killValue_ = 0;
 public bool HasKillValue {
 get { return hasKillValue; }
 }
 public Int32 KillValue {
 get { return killValue_; }
 set { SetKillValue(value); }
 }
 public void SetKillValue(Int32 value) { 
 hasKillValue = true;
 killValue_ = value;
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
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PlayerName);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
}
 if (HasRank) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Rank);
}
 if (HasBattle) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Battle);
}
 if (HasMoneyNum) {
size += pb::CodedOutputStream.ComputeInt64Size(6, MoneyNum);
}
 if (HasPetBattle) {
size += pb::CodedOutputStream.ComputeInt32Size(7, PetBattle);
}
 if (HasHorseBattle) {
size += pb::CodedOutputStream.ComputeInt32Size(8, HorseBattle);
}
 if (HasArenaRank) {
size += pb::CodedOutputStream.ComputeInt32Size(9, ArenaRank);
}
 if (HasTopTower) {
size += pb::CodedOutputStream.ComputeInt32Size(10, TopTower);
}
 if (HasOutPut) {
size += pb::CodedOutputStream.ComputeStringSize(11, OutPut);
}
 if (HasOnlineTime) {
size += pb::CodedOutputStream.ComputeInt64Size(12, OnlineTime);
}
 if (HasGangBattle) {
size += pb::CodedOutputStream.ComputeInt32Size(13, GangBattle);
}
 if (HasPetID) {
size += pb::CodedOutputStream.ComputeInt64Size(14, PetID);
}
 if (HasHorseID) {
size += pb::CodedOutputStream.ComputeInt64Size(15, HorseID);
}
 if (HasWorship) {
size += pb::CodedOutputStream.ComputeInt64Size(16, Worship);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(17, Level);
}
 if (HasWinNum) {
size += pb::CodedOutputStream.ComputeInt32Size(18, WinNum);
}
 if (HasGangID) {
size += pb::CodedOutputStream.ComputeInt64Size(19, GangID);
}
 if (HasIsWorship) {
size += pb::CodedOutputStream.ComputeInt32Size(20, IsWorship);
}
 if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(21, Vip);
}
 if (HasKillPlayers) {
size += pb::CodedOutputStream.ComputeInt32Size(22, KillPlayers);
}
 if (HasKillValue) {
size += pb::CodedOutputStream.ComputeInt32Size(23, KillValue);
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
 
if (HasPlayerName) {
output.WriteString(2, PlayerName);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 
if (HasRank) {
output.WriteInt32(4, Rank);
}
 
if (HasBattle) {
output.WriteInt32(5, Battle);
}
 
if (HasMoneyNum) {
output.WriteInt64(6, MoneyNum);
}
 
if (HasPetBattle) {
output.WriteInt32(7, PetBattle);
}
 
if (HasHorseBattle) {
output.WriteInt32(8, HorseBattle);
}
 
if (HasArenaRank) {
output.WriteInt32(9, ArenaRank);
}
 
if (HasTopTower) {
output.WriteInt32(10, TopTower);
}
 
if (HasOutPut) {
output.WriteString(11, OutPut);
}
 
if (HasOnlineTime) {
output.WriteInt64(12, OnlineTime);
}
 
if (HasGangBattle) {
output.WriteInt32(13, GangBattle);
}
 
if (HasPetID) {
output.WriteInt64(14, PetID);
}
 
if (HasHorseID) {
output.WriteInt64(15, HorseID);
}
 
if (HasWorship) {
output.WriteInt64(16, Worship);
}
 
if (HasLevel) {
output.WriteInt32(17, Level);
}
 
if (HasWinNum) {
output.WriteInt32(18, WinNum);
}
 
if (HasGangID) {
output.WriteInt64(19, GangID);
}
 
if (HasIsWorship) {
output.WriteInt32(20, IsWorship);
}
 
if (HasVip) {
output.WriteInt32(21, Vip);
}
 
if (HasKillPlayers) {
output.WriteInt32(22, KillPlayers);
}
 
if (HasKillValue) {
output.WriteInt32(23, KillValue);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RankInfo _inst = (RankInfo) _base;
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
   case  18: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  24: {
 _inst.Type = input.ReadInt32();
break;
}
   case  32: {
 _inst.Rank = input.ReadInt32();
break;
}
   case  40: {
 _inst.Battle = input.ReadInt32();
break;
}
   case  48: {
 _inst.MoneyNum = input.ReadInt64();
break;
}
   case  56: {
 _inst.PetBattle = input.ReadInt32();
break;
}
   case  64: {
 _inst.HorseBattle = input.ReadInt32();
break;
}
   case  72: {
 _inst.ArenaRank = input.ReadInt32();
break;
}
   case  80: {
 _inst.TopTower = input.ReadInt32();
break;
}
   case  90: {
 _inst.OutPut = input.ReadString();
break;
}
   case  96: {
 _inst.OnlineTime = input.ReadInt64();
break;
}
   case  104: {
 _inst.GangBattle = input.ReadInt32();
break;
}
   case  112: {
 _inst.PetID = input.ReadInt64();
break;
}
   case  120: {
 _inst.HorseID = input.ReadInt64();
break;
}
   case  128: {
 _inst.Worship = input.ReadInt64();
break;
}
   case  136: {
 _inst.Level = input.ReadInt32();
break;
}
   case  144: {
 _inst.WinNum = input.ReadInt32();
break;
}
   case  152: {
 _inst.GangID = input.ReadInt64();
break;
}
   case  160: {
 _inst.IsWorship = input.ReadInt32();
break;
}
   case  168: {
 _inst.Vip = input.ReadInt32();
break;
}
   case  176: {
 _inst.KillPlayers = input.ReadInt32();
break;
}
   case  184: {
 _inst.KillValue = input.ReadInt32();
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
