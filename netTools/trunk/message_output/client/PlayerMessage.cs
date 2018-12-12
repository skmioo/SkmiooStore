//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGAmbitLevelUp : PacketDistributed
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
 CGAmbitLevelUp _inst = (CGAmbitLevelUp) _base;
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
public class CGChangePlayer : PacketDistributed
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
 CGChangePlayer _inst = (CGChangePlayer) _base;
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
public class CGGetPlaerInfoById : PacketDistributed
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
 CGGetPlaerInfoById _inst = (CGGetPlaerInfoById) _base;
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
public class CGGetPlayerAndPetInfo : PacketDistributed
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
 CGGetPlayerAndPetInfo _inst = (CGGetPlayerAndPetInfo) _base;
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
public class CGLookPlayerInfo : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Pid);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLookPlayerInfo _inst = (CGLookPlayerInfo) _base;
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
public class CGNeedNonage : PacketDistributed
{

public const int stsFieldNumber = 1;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSts) {
output.WriteInt32(1, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGNeedNonage _inst = (CGNeedNonage) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sts = input.ReadInt32();
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
public class CGPlayerHangup : PacketDistributed
{

public const int openFieldNumber = 1;
 private bool hasOpen;
 private Int32 open_ = 0;
 public bool HasOpen {
 get { return hasOpen; }
 }
 public Int32 Open {
 get { return open_; }
 set { SetOpen(value); }
 }
 public void SetOpen(Int32 value) { 
 hasOpen = true;
 open_ = value;
 }

public const int scopeFieldNumber = 2;
 private bool hasScope;
 private Int32 scope_ = 0;
 public bool HasScope {
 get { return hasScope; }
 }
 public Int32 Scope {
 get { return scope_; }
 set { SetScope(value); }
 }
 public void SetScope(Int32 value) { 
 hasScope = true;
 scope_ = value;
 }

public const int autoRenornFieldNumber = 3;
 private bool hasAutoRenorn;
 private Int32 autoRenorn_ = 0;
 public bool HasAutoRenorn {
 get { return hasAutoRenorn; }
 }
 public Int32 AutoRenorn {
 get { return autoRenorn_; }
 set { SetAutoRenorn(value); }
 }
 public void SetAutoRenorn(Int32 value) { 
 hasAutoRenorn = true;
 autoRenorn_ = value;
 }

public const int avoiBossFieldNumber = 4;
 private bool hasAvoiBoss;
 private Int32 avoiBoss_ = 0;
 public bool HasAvoiBoss {
 get { return hasAvoiBoss; }
 }
 public Int32 AvoiBoss {
 get { return avoiBoss_; }
 set { SetAvoiBoss(value); }
 }
 public void SetAvoiBoss(Int32 value) { 
 hasAvoiBoss = true;
 avoiBoss_ = value;
 }

public const int attackBackFieldNumber = 5;
 private bool hasAttackBack;
 private Int32 attackBack_ = 0;
 public bool HasAttackBack {
 get { return hasAttackBack; }
 }
 public Int32 AttackBack {
 get { return attackBack_; }
 set { SetAttackBack(value); }
 }
 public void SetAttackBack(Int32 value) { 
 hasAttackBack = true;
 attackBack_ = value;
 }

public const int pickTypeIndexsFieldNumber = 6;
 private pbc::PopsicleList<Int32> pickTypeIndexs_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> pickTypeIndexsList {
 get { return pbc::Lists.AsReadOnly(pickTypeIndexs_); }
 }
 
 public int pickTypeIndexsCount {
 get { return pickTypeIndexs_.Count; }
 }
 
public Int32 GetPickTypeIndexs(int index) {
 return pickTypeIndexs_[index];
 }
 public void AddPickTypeIndexs(Int32 value) {
 pickTypeIndexs_.Add(value);
 }

public const int pickQualityFieldNumber = 7;
 private pbc::PopsicleList<Int32> pickQuality_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> pickQualityList {
 get { return pbc::Lists.AsReadOnly(pickQuality_); }
 }
 
 public int pickQualityCount {
 get { return pickQuality_.Count; }
 }
 
public Int32 GetPickQuality(int index) {
 return pickQuality_[index];
 }
 public void AddPickQuality(Int32 value) {
 pickQuality_.Add(value);
 }

public const int autoSkillsFieldNumber = 8;
 private pbc::PopsicleList<Int32> autoSkills_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> autoSkillsList {
 get { return pbc::Lists.AsReadOnly(autoSkills_); }
 }
 
 public int autoSkillsCount {
 get { return autoSkills_.Count; }
 }
 
public Int32 GetAutoSkills(int index) {
 return autoSkills_[index];
 }
 public void AddAutoSkills(Int32 value) {
 autoSkills_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOpen) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Open);
}
 if (HasScope) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Scope);
}
 if (HasAutoRenorn) {
size += pb::CodedOutputStream.ComputeInt32Size(3, AutoRenorn);
}
 if (HasAvoiBoss) {
size += pb::CodedOutputStream.ComputeInt32Size(4, AvoiBoss);
}
 if (HasAttackBack) {
size += pb::CodedOutputStream.ComputeInt32Size(5, AttackBack);
}
{
int dataSize = 0;
foreach (Int32 element in pickTypeIndexsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * pickTypeIndexs_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in pickQualityList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * pickQuality_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in autoSkillsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * autoSkills_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOpen) {
output.WriteInt32(1, Open);
}
 
if (HasScope) {
output.WriteInt32(2, Scope);
}
 
if (HasAutoRenorn) {
output.WriteInt32(3, AutoRenorn);
}
 
if (HasAvoiBoss) {
output.WriteInt32(4, AvoiBoss);
}
 
if (HasAttackBack) {
output.WriteInt32(5, AttackBack);
}
{
if (pickTypeIndexs_.Count > 0) {
foreach (Int32 element in pickTypeIndexsList) {
output.WriteInt32(6,element);
}
}

}
{
if (pickQuality_.Count > 0) {
foreach (Int32 element in pickQualityList) {
output.WriteInt32(7,element);
}
}

}
{
if (autoSkills_.Count > 0) {
foreach (Int32 element in autoSkillsList) {
output.WriteInt32(8,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPlayerHangup _inst = (CGPlayerHangup) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Open = input.ReadInt32();
break;
}
   case  16: {
 _inst.Scope = input.ReadInt32();
break;
}
   case  24: {
 _inst.AutoRenorn = input.ReadInt32();
break;
}
   case  32: {
 _inst.AvoiBoss = input.ReadInt32();
break;
}
   case  40: {
 _inst.AttackBack = input.ReadInt32();
break;
}
   case  48: {
 _inst.AddPickTypeIndexs(input.ReadInt32());
break;
}
   case  56: {
 _inst.AddPickQuality(input.ReadInt32());
break;
}
   case  64: {
 _inst.AddAutoSkills(input.ReadInt32());
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
public class CGPlayerViewSetting : PacketDistributed
{

public const int maxNumFieldNumber = 1;
 private bool hasMaxNum;
 private Int32 maxNum_ = 0;
 public bool HasMaxNum {
 get { return hasMaxNum; }
 }
 public Int32 MaxNum {
 get { return maxNum_; }
 set { SetMaxNum(value); }
 }
 public void SetMaxNum(Int32 value) { 
 hasMaxNum = true;
 maxNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMaxNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MaxNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMaxNum) {
output.WriteInt32(1, MaxNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPlayerViewSetting _inst = (CGPlayerViewSetting) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MaxNum = input.ReadInt32();
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
public class CGQuitLogin : PacketDistributed
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
 CGQuitLogin _inst = (CGQuitLogin) _base;
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
public class CGReLoginGameServer : PacketDistributed
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

public const int uidFieldNumber = 2;
 private bool hasUid;
 private string uid_ = "";
 public bool HasUid {
 get { return hasUid; }
 }
 public string Uid {
 get { return uid_; }
 set { SetUid(value); }
 }
 public void SetUid(string value) { 
 hasUid = true;
 uid_ = value;
 }

public const int platFormFieldNumber = 3;
 private bool hasPlatForm;
 private string platForm_ = "";
 public bool HasPlatForm {
 get { return hasPlatForm; }
 }
 public string PlatForm {
 get { return platForm_; }
 set { SetPlatForm(value); }
 }
 public void SetPlatForm(string value) { 
 hasPlatForm = true;
 platForm_ = value;
 }

public const int accountIDFieldNumber = 4;
 private bool hasAccountID;
 private Int64 accountID_ = 0;
 public bool HasAccountID {
 get { return hasAccountID; }
 }
 public Int64 AccountID {
 get { return accountID_; }
 set { SetAccountID(value); }
 }
 public void SetAccountID(Int64 value) { 
 hasAccountID = true;
 accountID_ = value;
 }

public const int currSceneIdFieldNumber = 5;
 private bool hasCurrSceneId;
 private Int32 currSceneId_ = 0;
 public bool HasCurrSceneId {
 get { return hasCurrSceneId; }
 }
 public Int32 CurrSceneId {
 get { return currSceneId_; }
 set { SetCurrSceneId(value); }
 }
 public void SetCurrSceneId(Int32 value) { 
 hasCurrSceneId = true;
 currSceneId_ = value;
 }

public const int authKeyFieldNumber = 6;
 private bool hasAuthKey;
 private string authKey_ = "";
 public bool HasAuthKey {
 get { return hasAuthKey; }
 }
 public string AuthKey {
 get { return authKey_; }
 set { SetAuthKey(value); }
 }
 public void SetAuthKey(string value) { 
 hasAuthKey = true;
 authKey_ = value;
 }

public const int sceneLoadingFieldNumber = 7;
 private bool hasSceneLoading;
 private Int32 sceneLoading_ = 0;
 public bool HasSceneLoading {
 get { return hasSceneLoading; }
 }
 public Int32 SceneLoading {
 get { return sceneLoading_; }
 set { SetSceneLoading(value); }
 }
 public void SetSceneLoading(Int32 value) { 
 hasSceneLoading = true;
 sceneLoading_ = value;
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
 if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(2, Uid);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlatForm);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(4, AccountID);
}
 if (HasCurrSceneId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, CurrSceneId);
}
 if (HasAuthKey) {
size += pb::CodedOutputStream.ComputeStringSize(6, AuthKey);
}
 if (HasSceneLoading) {
size += pb::CodedOutputStream.ComputeInt32Size(7, SceneLoading);
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
 
if (HasUid) {
output.WriteString(2, Uid);
}
 
if (HasPlatForm) {
output.WriteString(3, PlatForm);
}
 
if (HasAccountID) {
output.WriteInt64(4, AccountID);
}
 
if (HasCurrSceneId) {
output.WriteInt32(5, CurrSceneId);
}
 
if (HasAuthKey) {
output.WriteString(6, AuthKey);
}
 
if (HasSceneLoading) {
output.WriteInt32(7, SceneLoading);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGReLoginGameServer _inst = (CGReLoginGameServer) _base;
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
 _inst.Uid = input.ReadString();
break;
}
   case  26: {
 _inst.PlatForm = input.ReadString();
break;
}
   case  32: {
 _inst.AccountID = input.ReadInt64();
break;
}
   case  40: {
 _inst.CurrSceneId = input.ReadInt32();
break;
}
   case  50: {
 _inst.AuthKey = input.ReadString();
break;
}
   case  56: {
 _inst.SceneLoading = input.ReadInt32();
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
public class CGReqPlayerReborn : PacketDistributed
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
 CGReqPlayerReborn _inst = (CGReqPlayerReborn) _base;
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
public class CGSendRotate : PacketDistributed
{

public const int objectIdFieldNumber = 1;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int rotateFieldNumber = 2;
 private bool hasRotate;
 private Vector3Info rotate_ =  new Vector3Info();
 public bool HasRotate {
 get { return hasRotate; }
 }
 public Vector3Info Rotate {
 get { return rotate_; }
 set { SetRotate(value); }
 }
 public void SetRotate(Vector3Info value) { 
 hasRotate = true;
 rotate_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjectId);
}
{
int subsize = Rotate.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjectId) {
output.WriteInt64(1, ObjectId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Rotate.SerializedSize());
Rotate.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSendRotate _inst = (CGSendRotate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjectId = input.ReadInt64();
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Rotate = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasRotate) {
if (!Rotate.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGUnLock : PacketDistributed
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
 CGUnLock _inst = (CGUnLock) _base;
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
public class CGUpdatePlayerHeadIcon : PacketDistributed
{

public const int iconidFieldNumber = 1;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasIconid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Iconid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasIconid) {
output.WriteInt32(1, Iconid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUpdatePlayerHeadIcon _inst = (CGUpdatePlayerHeadIcon) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Iconid = input.ReadInt32();
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
public class CGUpdatePlayerName : PacketDistributed
{

public const int nameFieldNumber = 1;
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
  if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(1, Name);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasName) {
output.WriteString(1, Name);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGUpdatePlayerName _inst = (CGUpdatePlayerName) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
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
public class GCAmbitLevelUp : PacketDistributed
{

public const int ambitLevelFieldNumber = 1;
 private bool hasAmbitLevel;
 private Int32 ambitLevel_ = 0;
 public bool HasAmbitLevel {
 get { return hasAmbitLevel; }
 }
 public Int32 AmbitLevel {
 get { return ambitLevel_; }
 set { SetAmbitLevel(value); }
 }
 public void SetAmbitLevel(Int32 value) { 
 hasAmbitLevel = true;
 ambitLevel_ = value;
 }

public const int ambitStatusFieldNumber = 2;
 private bool hasAmbitStatus;
 private Int32 ambitStatus_ = 0;
 public bool HasAmbitStatus {
 get { return hasAmbitStatus; }
 }
 public Int32 AmbitStatus {
 get { return ambitStatus_; }
 set { SetAmbitStatus(value); }
 }
 public void SetAmbitStatus(Int32 value) { 
 hasAmbitStatus = true;
 ambitStatus_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAmbitLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AmbitLevel);
}
 if (HasAmbitStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, AmbitStatus);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAmbitLevel) {
output.WriteInt32(1, AmbitLevel);
}
 
if (HasAmbitStatus) {
output.WriteInt32(2, AmbitStatus);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAmbitLevelUp _inst = (GCAmbitLevelUp) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AmbitLevel = input.ReadInt32();
break;
}
   case  16: {
 _inst.AmbitStatus = input.ReadInt32();
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
public class GCChangePlayerResult : PacketDistributed
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
 GCChangePlayerResult _inst = (GCChangePlayerResult) _base;
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
public class GCCharacterFaceTo : PacketDistributed
{

public const int objectIdFieldNumber = 1;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int faceToObjectIdFieldNumber = 2;
 private bool hasFaceToObjectId;
 private Int64 faceToObjectId_ = 0;
 public bool HasFaceToObjectId {
 get { return hasFaceToObjectId; }
 }
 public Int64 FaceToObjectId {
 get { return faceToObjectId_; }
 set { SetFaceToObjectId(value); }
 }
 public void SetFaceToObjectId(Int64 value) { 
 hasFaceToObjectId = true;
 faceToObjectId_ = value;
 }

public const int faceToPosFieldNumber = 3;
 private bool hasFaceToPos;
 private Vector3Info faceToPos_ =  new Vector3Info();
 public bool HasFaceToPos {
 get { return hasFaceToPos; }
 }
 public Vector3Info FaceToPos {
 get { return faceToPos_; }
 set { SetFaceToPos(value); }
 }
 public void SetFaceToPos(Vector3Info value) { 
 hasFaceToPos = true;
 faceToPos_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjectId);
}
 if (HasFaceToObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, FaceToObjectId);
}
{
int subsize = FaceToPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjectId) {
output.WriteInt64(1, ObjectId);
}
 
if (HasFaceToObjectId) {
output.WriteInt64(2, FaceToObjectId);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)FaceToPos.SerializedSize());
FaceToPos.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCharacterFaceTo _inst = (GCCharacterFaceTo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjectId = input.ReadInt64();
break;
}
   case  16: {
 _inst.FaceToObjectId = input.ReadInt64();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.FaceToPos = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasFaceToPos) {
if (!FaceToPos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCExpPlus : PacketDistributed
{

public const int displayFieldNumber = 1;
 private bool hasDisplay;
 private Int32 display_ = 0;
 public bool HasDisplay {
 get { return hasDisplay; }
 }
 public Int32 Display {
 get { return display_; }
 set { SetDisplay(value); }
 }
 public void SetDisplay(Int32 value) { 
 hasDisplay = true;
 display_ = value;
 }

public const int worldLevelFieldNumber = 2;
 private bool hasWorldLevel;
 private Int32 worldLevel_ = 0;
 public bool HasWorldLevel {
 get { return hasWorldLevel; }
 }
 public Int32 WorldLevel {
 get { return worldLevel_; }
 set { SetWorldLevel(value); }
 }
 public void SetWorldLevel(Int32 value) { 
 hasWorldLevel = true;
 worldLevel_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDisplay) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Display);
}
 if (HasWorldLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(2, WorldLevel);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDisplay) {
output.WriteInt32(1, Display);
}
 
if (HasWorldLevel) {
output.WriteInt32(2, WorldLevel);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCExpPlus _inst = (GCExpPlus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Display = input.ReadInt32();
break;
}
   case  16: {
 _inst.WorldLevel = input.ReadInt32();
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
public class GCLevelUpGetNewSkill : PacketDistributed
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
 GCLevelUpGetNewSkill _inst = (GCLevelUpGetNewSkill) _base;
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
public class GCLookPlayerInfo : PacketDistributed
{

public const int playerInfoFieldNumber = 1;
 private bool hasPlayerInfo;
 private CharacterInfo playerInfo_ =  new CharacterInfo();
 public bool HasPlayerInfo {
 get { return hasPlayerInfo; }
 }
 public CharacterInfo PlayerInfo {
 get { return playerInfo_; }
 set { SetPlayerInfo(value); }
 }
 public void SetPlayerInfo(CharacterInfo value) { 
 hasPlayerInfo = true;
 playerInfo_ = value;
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

public const int sbInfoFieldNumber = 3;
 private pbc::PopsicleList<SpiritBeastInfo> sbInfo_ = new pbc::PopsicleList<SpiritBeastInfo>();
 public scg::IList<SpiritBeastInfo> sbInfoList {
 get { return pbc::Lists.AsReadOnly(sbInfo_); }
 }
 
 public int sbInfoCount {
 get { return sbInfo_.Count; }
 }
 
public SpiritBeastInfo GetSbInfo(int index) {
 return sbInfo_[index];
 }
 public void AddSbInfo(SpiritBeastInfo value) {
 sbInfo_.Add(value);
 }

public const int talisSlotsFieldNumber = 4;
 private pbc::PopsicleList<TalismanSlotsLook> talisSlots_ = new pbc::PopsicleList<TalismanSlotsLook>();
 public scg::IList<TalismanSlotsLook> talisSlotsList {
 get { return pbc::Lists.AsReadOnly(talisSlots_); }
 }
 
 public int talisSlotsCount {
 get { return talisSlots_.Count; }
 }
 
public TalismanSlotsLook GetTalisSlots(int index) {
 return talisSlots_[index];
 }
 public void AddTalisSlots(TalismanSlotsLook value) {
 talisSlots_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = PlayerInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (EquipSlots element in equipSlotsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (SpiritBeastInfo element in sbInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (TalismanSlotsLook element in talisSlotsList) {
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
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PlayerInfo.SerializedSize());
PlayerInfo.WriteTo(output);

}

do{
foreach (EquipSlots element in equipSlotsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (SpiritBeastInfo element in sbInfoList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (TalismanSlotsLook element in talisSlotsList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLookPlayerInfo _inst = (GCLookPlayerInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.PlayerInfo = subBuilder;
break;
}
    case  18: {
EquipSlots subBuilder =  new EquipSlots();
input.ReadMessage(subBuilder);
_inst.AddEquipSlots(subBuilder);
break;
}
    case  26: {
SpiritBeastInfo subBuilder =  new SpiritBeastInfo();
input.ReadMessage(subBuilder);
_inst.AddSbInfo(subBuilder);
break;
}
    case  34: {
TalismanSlotsLook subBuilder =  new TalismanSlotsLook();
input.ReadMessage(subBuilder);
_inst.AddTalisSlots(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPlayerInfo) {
if (!PlayerInfo.IsInitialized()) return false;
}
foreach (EquipSlots element in equipSlotsList) {
if (!element.IsInitialized()) return false;
}
foreach (SpiritBeastInfo element in sbInfoList) {
if (!element.IsInitialized()) return false;
}
foreach (TalismanSlotsLook element in talisSlotsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCMuteTime : PacketDistributed
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

public const int muteTimeFieldNumber = 2;
 private bool hasMuteTime;
 private Int32 muteTime_ = 0;
 public bool HasMuteTime {
 get { return hasMuteTime; }
 }
 public Int32 MuteTime {
 get { return muteTime_; }
 set { SetMuteTime(value); }
 }
 public void SetMuteTime(Int32 value) { 
 hasMuteTime = true;
 muteTime_ = value;
 }

public const int muteEndTimeFieldNumber = 3;
 private bool hasMuteEndTime;
 private Int64 muteEndTime_ = 0;
 public bool HasMuteEndTime {
 get { return hasMuteEndTime; }
 }
 public Int64 MuteEndTime {
 get { return muteEndTime_; }
 set { SetMuteEndTime(value); }
 }
 public void SetMuteEndTime(Int64 value) { 
 hasMuteEndTime = true;
 muteEndTime_ = value;
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
 if (HasMuteTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MuteTime);
}
 if (HasMuteEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, MuteEndTime);
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
 
if (HasMuteTime) {
output.WriteInt32(2, MuteTime);
}
 
if (HasMuteEndTime) {
output.WriteInt64(3, MuteEndTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMuteTime _inst = (GCMuteTime) _base;
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
 _inst.MuteTime = input.ReadInt32();
break;
}
   case  24: {
 _inst.MuteEndTime = input.ReadInt64();
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
public class GCNonageSts : PacketDistributed
{

public const int stsFieldNumber = 1;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSts) {
output.WriteInt32(1, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCNonageSts _inst = (GCNonageSts) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sts = input.ReadInt32();
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
public class GCOnLineTime : PacketDistributed
{

public const int sencondsFieldNumber = 1;
 private bool hasSenconds;
 private Int32 senconds_ = 0;
 public bool HasSenconds {
 get { return hasSenconds; }
 }
 public Int32 Senconds {
 get { return senconds_; }
 set { SetSenconds(value); }
 }
 public void SetSenconds(Int32 value) { 
 hasSenconds = true;
 senconds_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSenconds) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Senconds);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSenconds) {
output.WriteInt32(1, Senconds);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOnLineTime _inst = (GCOnLineTime) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Senconds = input.ReadInt32();
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
public class GCPlayerDie : PacketDistributed
{

public const int dietimeFieldNumber = 1;
 private bool hasDietime;
 private Int64 dietime_ = 0;
 public bool HasDietime {
 get { return hasDietime; }
 }
 public Int64 Dietime {
 get { return dietime_; }
 set { SetDietime(value); }
 }
 public void SetDietime(Int64 value) { 
 hasDietime = true;
 dietime_ = value;
 }

public const int reborntiemFieldNumber = 2;
 private bool hasReborntiem;
 private Int64 reborntiem_ = 0;
 public bool HasReborntiem {
 get { return hasReborntiem; }
 }
 public Int64 Reborntiem {
 get { return reborntiem_; }
 set { SetReborntiem(value); }
 }
 public void SetReborntiem(Int64 value) { 
 hasReborntiem = true;
 reborntiem_ = value;
 }

public const int killerFieldNumber = 3;
 private bool hasKiller;
 private Int64 killer_ = 0;
 public bool HasKiller {
 get { return hasKiller; }
 }
 public Int64 Killer {
 get { return killer_; }
 set { SetKiller(value); }
 }
 public void SetKiller(Int64 value) { 
 hasKiller = true;
 killer_ = value;
 }

public const int kimbdNumFieldNumber = 4;
 private bool hasKimbdNum;
 private Int32 kimbdNum_ = 0;
 public bool HasKimbdNum {
 get { return hasKimbdNum; }
 }
 public Int32 KimbdNum {
 get { return kimbdNum_; }
 set { SetKimbdNum(value); }
 }
 public void SetKimbdNum(Int32 value) { 
 hasKimbdNum = true;
 kimbdNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDietime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Dietime);
}
 if (HasReborntiem) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Reborntiem);
}
 if (HasKiller) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Killer);
}
 if (HasKimbdNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, KimbdNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDietime) {
output.WriteInt64(1, Dietime);
}
 
if (HasReborntiem) {
output.WriteInt64(2, Reborntiem);
}
 
if (HasKiller) {
output.WriteInt64(3, Killer);
}
 
if (HasKimbdNum) {
output.WriteInt32(4, KimbdNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPlayerDie _inst = (GCPlayerDie) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Dietime = input.ReadInt64();
break;
}
   case  16: {
 _inst.Reborntiem = input.ReadInt64();
break;
}
   case  24: {
 _inst.Killer = input.ReadInt64();
break;
}
   case  32: {
 _inst.KimbdNum = input.ReadInt32();
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
public class GCPlayerHangup : PacketDistributed
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

public const int openFieldNumber = 2;
 private bool hasOpen;
 private Int32 open_ = 0;
 public bool HasOpen {
 get { return hasOpen; }
 }
 public Int32 Open {
 get { return open_; }
 set { SetOpen(value); }
 }
 public void SetOpen(Int32 value) { 
 hasOpen = true;
 open_ = value;
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
 if (HasOpen) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Open);
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
 
if (HasOpen) {
output.WriteInt32(2, Open);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPlayerHangup _inst = (GCPlayerHangup) _base;
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
 _inst.Open = input.ReadInt32();
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
public class GCPlayerReborn : PacketDistributed
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

public const int objectIdFieldNumber = 2;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
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
 if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ObjectId);
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
 
if (HasObjectId) {
output.WriteInt64(2, ObjectId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPlayerReborn _inst = (GCPlayerReborn) _base;
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
 _inst.ObjectId = input.ReadInt64();
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
public class GCPlayerViewSetting : PacketDistributed
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

public const int maxNumFieldNumber = 2;
 private bool hasMaxNum;
 private Int32 maxNum_ = 0;
 public bool HasMaxNum {
 get { return hasMaxNum; }
 }
 public Int32 MaxNum {
 get { return maxNum_; }
 set { SetMaxNum(value); }
 }
 public void SetMaxNum(Int32 value) { 
 hasMaxNum = true;
 maxNum_ = value;
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
 if (HasMaxNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MaxNum);
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
 
if (HasMaxNum) {
output.WriteInt32(2, MaxNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPlayerViewSetting _inst = (GCPlayerViewSetting) _base;
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
 _inst.MaxNum = input.ReadInt32();
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
public class GCPrivatePlayerAttr : PacketDistributed
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPrivatePlayerAttr _inst = (GCPrivatePlayerAttr) _base;
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

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CharacterAttr element in charAttrList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCQuitLoginBack : PacketDistributed
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
 GCQuitLoginBack _inst = (GCQuitLoginBack) _base;
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
public class GCReLoginGameServer : PacketDistributed
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

public const int eniqueIDFieldNumber = 2;
 private bool hasEniqueID;
 private Int64 eniqueID_ = 0;
 public bool HasEniqueID {
 get { return hasEniqueID; }
 }
 public Int64 EniqueID {
 get { return eniqueID_; }
 set { SetEniqueID(value); }
 }
 public void SetEniqueID(Int64 value) { 
 hasEniqueID = true;
 eniqueID_ = value;
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
 if (HasEniqueID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, EniqueID);
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
 
if (HasEniqueID) {
output.WriteInt64(2, EniqueID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCReLoginGameServer _inst = (GCReLoginGameServer) _base;
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
 _inst.EniqueID = input.ReadInt64();
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
public class GCSendHeadIconList : PacketDistributed
{

public const int iconlistFieldNumber = 1;
 private pbc::PopsicleList<Int32> iconlist_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> iconlistList {
 get { return pbc::Lists.AsReadOnly(iconlist_); }
 }
 
 public int iconlistCount {
 get { return iconlist_.Count; }
 }
 
public Int32 GetIconlist(int index) {
 return iconlist_[index];
 }
 public void AddIconlist(Int32 value) {
 iconlist_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in iconlistList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * iconlist_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (iconlist_.Count > 0) {
foreach (Int32 element in iconlistList) {
output.WriteInt32(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendHeadIconList _inst = (GCSendHeadIconList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddIconlist(input.ReadInt32());
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
public class GCSendPlayerAndPetInfo : PacketDistributed
{

public const int characterInfoFieldNumber = 1;
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

public const int petInfoFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = CharacterInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = PetInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)CharacterInfo.SerializedSize());
CharacterInfo.WriteTo(output);

}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PetInfo.SerializedSize());
PetInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendPlayerAndPetInfo _inst = (GCSendPlayerAndPetInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.CharacterInfo = subBuilder;
break;
}
    case  18: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.PetInfo = subBuilder;
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
  if (HasPetInfo) {
if (!PetInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendPlayerInfoById : PacketDistributed
{

public const int characterInfoFieldNumber = 1;
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
 {
int subsize = CharacterInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
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
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)CharacterInfo.SerializedSize());
CharacterInfo.WriteTo(output);

}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendPlayerInfoById _inst = (GCSendPlayerInfoById) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.CharacterInfo = subBuilder;
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
   if (HasCharacterInfo) {
if (!CharacterInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendRotate : PacketDistributed
{

public const int objectIdFieldNumber = 1;
 private bool hasObjectId;
 private Int64 objectId_ = 0;
 public bool HasObjectId {
 get { return hasObjectId; }
 }
 public Int64 ObjectId {
 get { return objectId_; }
 set { SetObjectId(value); }
 }
 public void SetObjectId(Int64 value) { 
 hasObjectId = true;
 objectId_ = value;
 }

public const int rotateFieldNumber = 2;
 private bool hasRotate;
 private Vector3Info rotate_ =  new Vector3Info();
 public bool HasRotate {
 get { return hasRotate; }
 }
 public Vector3Info Rotate {
 get { return rotate_; }
 set { SetRotate(value); }
 }
 public void SetRotate(Vector3Info value) { 
 hasRotate = true;
 rotate_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjectId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjectId);
}
{
int subsize = Rotate.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjectId) {
output.WriteInt64(1, ObjectId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Rotate.SerializedSize());
Rotate.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendRotate _inst = (GCSendRotate) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjectId = input.ReadInt64();
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Rotate = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasRotate) {
if (!Rotate.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSendSkillList : PacketDistributed
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

public const int isfirstloginFieldNumber = 3;
 private bool hasIsfirstlogin;
 private Int32 isfirstlogin_ = 0;
 public bool HasIsfirstlogin {
 get { return hasIsfirstlogin; }
 }
 public Int32 Isfirstlogin {
 get { return isfirstlogin_; }
 set { SetIsfirstlogin(value); }
 }
 public void SetIsfirstlogin(Int32 value) { 
 hasIsfirstlogin = true;
 isfirstlogin_ = value;
 }

public const int shenQiSkilldataFieldNumber = 4;
 private bool hasShenQiSkilldata;
 private SkillItemData shenQiSkilldata_ =  new SkillItemData();
 public bool HasShenQiSkilldata {
 get { return hasShenQiSkilldata; }
 }
 public SkillItemData ShenQiSkilldata {
 get { return shenQiSkilldata_; }
 set { SetShenQiSkilldata(value); }
 }
 public void SetShenQiSkilldata(SkillItemData value) { 
 hasShenQiSkilldata = true;
 shenQiSkilldata_ = value;
 }

public const int skillFlagFieldNumber = 5;
 private bool hasSkillFlag;
 private Int32 skillFlag_ = 0;
 public bool HasSkillFlag {
 get { return hasSkillFlag; }
 }
 public Int32 SkillFlag {
 get { return skillFlag_; }
 set { SetSkillFlag(value); }
 }
 public void SetSkillFlag(Int32 value) { 
 hasSkillFlag = true;
 skillFlag_ = value;
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
{
foreach (SkillItemData element in skilldataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasIsfirstlogin) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Isfirstlogin);
}
{
int subsize = ShenQiSkilldata.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasSkillFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(5, SkillFlag);
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

do{
foreach (SkillItemData element in skilldataList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasIsfirstlogin) {
output.WriteInt32(3, Isfirstlogin);
}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ShenQiSkilldata.SerializedSize());
ShenQiSkilldata.WriteTo(output);

}
 
if (HasSkillFlag) {
output.WriteInt32(5, SkillFlag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendSkillList _inst = (GCSendSkillList) _base;
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
SkillItemData subBuilder =  new SkillItemData();
input.ReadMessage(subBuilder);
_inst.AddSkilldata(subBuilder);
break;
}
   case  24: {
 _inst.Isfirstlogin = input.ReadInt32();
break;
}
    case  34: {
SkillItemData subBuilder =  new SkillItemData();
 input.ReadMessage(subBuilder);
_inst.ShenQiSkilldata = subBuilder;
break;
}
   case  40: {
 _inst.SkillFlag = input.ReadInt32();
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
  if (HasShenQiSkilldata) {
if (!ShenQiSkilldata.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCStressTestBegin : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerId);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCStressTestBegin _inst = (GCStressTestBegin) _base;
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
public class GCUpdateHeadIconOK : PacketDistributed
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

public const int headIconFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 if (HasHeadIcon) {
size += pb::CodedOutputStream.ComputeInt32Size(2, HeadIcon);
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
 
if (HasHeadIcon) {
output.WriteInt32(2, HeadIcon);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdateHeadIconOK _inst = (GCUpdateHeadIconOK) _base;
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
 _inst.HeadIcon = input.ReadInt32();
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
public class GCUpdatePlayerNameOK : PacketDistributed
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

public const int newnameFieldNumber = 2;
 private bool hasNewname;
 private string newname_ = "";
 public bool HasNewname {
 get { return hasNewname; }
 }
 public string Newname {
 get { return newname_; }
 set { SetNewname(value); }
 }
 public void SetNewname(string value) { 
 hasNewname = true;
 newname_ = value;
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
 if (HasNewname) {
size += pb::CodedOutputStream.ComputeStringSize(2, Newname);
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
 
if (HasNewname) {
output.WriteString(2, Newname);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdatePlayerNameOK _inst = (GCUpdatePlayerNameOK) _base;
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
 _inst.Newname = input.ReadString();
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
public class GameForceLoginout : PacketDistributed
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

public const int noticeLoginSvrFieldNumber = 2;
 private bool hasNoticeLoginSvr;
 private Int32 noticeLoginSvr_ = 0;
 public bool HasNoticeLoginSvr {
 get { return hasNoticeLoginSvr; }
 }
 public Int32 NoticeLoginSvr {
 get { return noticeLoginSvr_; }
 set { SetNoticeLoginSvr(value); }
 }
 public void SetNoticeLoginSvr(Int32 value) { 
 hasNoticeLoginSvr = true;
 noticeLoginSvr_ = value;
 }

public const int noticeGateSvrFieldNumber = 3;
 private bool hasNoticeGateSvr;
 private Int32 noticeGateSvr_ = 0;
 public bool HasNoticeGateSvr {
 get { return hasNoticeGateSvr; }
 }
 public Int32 NoticeGateSvr {
 get { return noticeGateSvr_; }
 set { SetNoticeGateSvr(value); }
 }
 public void SetNoticeGateSvr(Int32 value) { 
 hasNoticeGateSvr = true;
 noticeGateSvr_ = value;
 }

public const int reasonFieldNumber = 4;
 private bool hasReason;
 private Int32 reason_ = 0;
 public bool HasReason {
 get { return hasReason; }
 }
 public Int32 Reason {
 get { return reason_; }
 set { SetReason(value); }
 }
 public void SetReason(Int32 value) { 
 hasReason = true;
 reason_ = value;
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
 if (HasNoticeLoginSvr) {
size += pb::CodedOutputStream.ComputeInt32Size(2, NoticeLoginSvr);
}
 if (HasNoticeGateSvr) {
size += pb::CodedOutputStream.ComputeInt32Size(3, NoticeGateSvr);
}
 if (HasReason) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Reason);
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
 
if (HasNoticeLoginSvr) {
output.WriteInt32(2, NoticeLoginSvr);
}
 
if (HasNoticeGateSvr) {
output.WriteInt32(3, NoticeGateSvr);
}
 
if (HasReason) {
output.WriteInt32(4, Reason);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GameForceLoginout _inst = (GameForceLoginout) _base;
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
 _inst.NoticeLoginSvr = input.ReadInt32();
break;
}
   case  24: {
 _inst.NoticeGateSvr = input.ReadInt32();
break;
}
   case  32: {
 _inst.Reason = input.ReadInt32();
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
