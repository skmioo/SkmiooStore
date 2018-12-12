//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCreatePlayer : PacketDistributed
{

public const int professionIdFieldNumber = 1;
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

public const int sexFieldNumber = 3;
 private bool hasSex;
 private Int32 sex_ = 0;
 public bool HasSex {
 get { return hasSex; }
 }
 public Int32 Sex {
 get { return sex_; }
 set { SetSex(value); }
 }
 public void SetSex(Int32 value) { 
 hasSex = true;
 sex_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasProfessionId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ProfessionId);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PlayerName);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sex);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasProfessionId) {
output.WriteInt32(1, ProfessionId);
}
 
if (HasPlayerName) {
output.WriteString(2, PlayerName);
}
 
if (HasSex) {
output.WriteInt32(3, Sex);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCreatePlayer _inst = (CGCreatePlayer) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ProfessionId = input.ReadInt32();
break;
}
   case  18: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  24: {
 _inst.Sex = input.ReadInt32();
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
public class CGDeletePlayer : PacketDistributed
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
 CGDeletePlayer _inst = (CGDeletePlayer) _base;
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
public class CGGetRandName : PacketDistributed
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
 CGGetRandName _inst = (CGGetRandName) _base;
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
public class CGLogin : PacketDistributed
{

public const int uidFieldNumber = 1;
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

public const int vilidCodeFieldNumber = 2;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
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

public const int authKeyFieldNumber = 5;
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

public const int serverIdFieldNumber = 6;
 private bool hasServerId;
 private Int32 serverId_ = 0;
 public bool HasServerId {
 get { return hasServerId; }
 }
 public Int32 ServerId {
 get { return serverId_; }
 set { SetServerId(value); }
 }
 public void SetServerId(Int32 value) { 
 hasServerId = true;
 serverId_ = value;
 }

public const int loginTypeFieldNumber = 7;
 private bool hasLoginType;
 private Int32 loginType_ = 0;
 public bool HasLoginType {
 get { return hasLoginType; }
 }
 public Int32 LoginType {
 get { return loginType_; }
 set { SetLoginType(value); }
 }
 public void SetLoginType(Int32 value) { 
 hasLoginType = true;
 loginType_ = value;
 }

public const int customParamFieldNumber = 8;
 private bool hasCustomParam;
 private string customParam_ = "";
 public bool HasCustomParam {
 get { return hasCustomParam; }
 }
 public string CustomParam {
 get { return customParam_; }
 set { SetCustomParam(value); }
 }
 public void SetCustomParam(string value) { 
 hasCustomParam = true;
 customParam_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(1, Uid);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(2, VilidCode);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlatForm);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(4, AccountID);
}
 if (HasAuthKey) {
size += pb::CodedOutputStream.ComputeStringSize(5, AuthKey);
}
 if (HasServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ServerId);
}
 if (HasLoginType) {
size += pb::CodedOutputStream.ComputeInt32Size(7, LoginType);
}
 if (HasCustomParam) {
size += pb::CodedOutputStream.ComputeStringSize(8, CustomParam);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasUid) {
output.WriteString(1, Uid);
}
 
if (HasVilidCode) {
output.WriteString(2, VilidCode);
}
 
if (HasPlatForm) {
output.WriteString(3, PlatForm);
}
 
if (HasAccountID) {
output.WriteInt64(4, AccountID);
}
 
if (HasAuthKey) {
output.WriteString(5, AuthKey);
}
 
if (HasServerId) {
output.WriteInt32(6, ServerId);
}
 
if (HasLoginType) {
output.WriteInt32(7, LoginType);
}
 
if (HasCustomParam) {
output.WriteString(8, CustomParam);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGLogin _inst = (CGLogin) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Uid = input.ReadString();
break;
}
   case  18: {
 _inst.VilidCode = input.ReadString();
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
   case  42: {
 _inst.AuthKey = input.ReadString();
break;
}
   case  48: {
 _inst.ServerId = input.ReadInt32();
break;
}
   case  56: {
 _inst.LoginType = input.ReadInt32();
break;
}
   case  66: {
 _inst.CustomParam = input.ReadString();
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
public class CGLoginGameServer : PacketDistributed
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
 CGLoginGameServer _inst = (CGLoginGameServer) _base;
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
public class CLBeforeLogin : PacketDistributed
{

public const int uidFieldNumber = 1;
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

public const int vilidCodeFieldNumber = 2;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int versionFieldNumber = 3;
 private bool hasVersion;
 private string version_ = "";
 public bool HasVersion {
 get { return hasVersion; }
 }
 public string Version {
 get { return version_; }
 set { SetVersion(value); }
 }
 public void SetVersion(string value) { 
 hasVersion = true;
 version_ = value;
 }

public const int deviceInfoFieldNumber = 4;
 private bool hasDeviceInfo;
 private string deviceInfo_ = "";
 public bool HasDeviceInfo {
 get { return hasDeviceInfo; }
 }
 public string DeviceInfo {
 get { return deviceInfo_; }
 set { SetDeviceInfo(value); }
 }
 public void SetDeviceInfo(string value) { 
 hasDeviceInfo = true;
 deviceInfo_ = value;
 }

public const int platFormFieldNumber = 5;
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

public const int accountIDFieldNumber = 6;
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

public const int authKeyFieldNumber = 7;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(1, Uid);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(2, VilidCode);
}
 if (HasVersion) {
size += pb::CodedOutputStream.ComputeStringSize(3, Version);
}
 if (HasDeviceInfo) {
size += pb::CodedOutputStream.ComputeStringSize(4, DeviceInfo);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(5, PlatForm);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(6, AccountID);
}
 if (HasAuthKey) {
size += pb::CodedOutputStream.ComputeStringSize(7, AuthKey);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasUid) {
output.WriteString(1, Uid);
}
 
if (HasVilidCode) {
output.WriteString(2, VilidCode);
}
 
if (HasVersion) {
output.WriteString(3, Version);
}
 
if (HasDeviceInfo) {
output.WriteString(4, DeviceInfo);
}
 
if (HasPlatForm) {
output.WriteString(5, PlatForm);
}
 
if (HasAccountID) {
output.WriteInt64(6, AccountID);
}
 
if (HasAuthKey) {
output.WriteString(7, AuthKey);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CLBeforeLogin _inst = (CLBeforeLogin) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Uid = input.ReadString();
break;
}
   case  18: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  26: {
 _inst.Version = input.ReadString();
break;
}
   case  34: {
 _inst.DeviceInfo = input.ReadString();
break;
}
   case  42: {
 _inst.PlatForm = input.ReadString();
break;
}
   case  48: {
 _inst.AccountID = input.ReadInt64();
break;
}
   case  58: {
 _inst.AuthKey = input.ReadString();
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
public class CLChangePlayerLogin : PacketDistributed
{

public const int unameFieldNumber = 1;
 private bool hasUname;
 private string uname_ = "";
 public bool HasUname {
 get { return hasUname; }
 }
 public string Uname {
 get { return uname_; }
 set { SetUname(value); }
 }
 public void SetUname(string value) { 
 hasUname = true;
 uname_ = value;
 }

public const int pwdFieldNumber = 2;
 private bool hasPwd;
 private string pwd_ = "";
 public bool HasPwd {
 get { return hasPwd; }
 }
 public string Pwd {
 get { return pwd_; }
 set { SetPwd(value); }
 }
 public void SetPwd(string value) { 
 hasPwd = true;
 pwd_ = value;
 }

public const int versionFieldNumber = 3;
 private bool hasVersion;
 private string version_ = "";
 public bool HasVersion {
 get { return hasVersion; }
 }
 public string Version {
 get { return version_; }
 set { SetVersion(value); }
 }
 public void SetVersion(string value) { 
 hasVersion = true;
 version_ = value;
 }

public const int deviceInfoFieldNumber = 4;
 private bool hasDeviceInfo;
 private string deviceInfo_ = "";
 public bool HasDeviceInfo {
 get { return hasDeviceInfo; }
 }
 public string DeviceInfo {
 get { return deviceInfo_; }
 set { SetDeviceInfo(value); }
 }
 public void SetDeviceInfo(string value) { 
 hasDeviceInfo = true;
 deviceInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasUname) {
size += pb::CodedOutputStream.ComputeStringSize(1, Uname);
}
 if (HasPwd) {
size += pb::CodedOutputStream.ComputeStringSize(2, Pwd);
}
 if (HasVersion) {
size += pb::CodedOutputStream.ComputeStringSize(3, Version);
}
 if (HasDeviceInfo) {
size += pb::CodedOutputStream.ComputeStringSize(4, DeviceInfo);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasUname) {
output.WriteString(1, Uname);
}
 
if (HasPwd) {
output.WriteString(2, Pwd);
}
 
if (HasVersion) {
output.WriteString(3, Version);
}
 
if (HasDeviceInfo) {
output.WriteString(4, DeviceInfo);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CLChangePlayerLogin _inst = (CLChangePlayerLogin) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Uname = input.ReadString();
break;
}
   case  18: {
 _inst.Pwd = input.ReadString();
break;
}
   case  26: {
 _inst.Version = input.ReadString();
break;
}
   case  34: {
 _inst.DeviceInfo = input.ReadString();
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
public class CLPlayerCancelLoginQueue : PacketDistributed
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
 CLPlayerCancelLoginQueue _inst = (CLPlayerCancelLoginQueue) _base;
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
public class GCCommonSetting : PacketDistributed
{

public const int debugFlagFieldNumber = 1;
 private bool hasDebugFlag;
 private Int32 debugFlag_ = 0;
 public bool HasDebugFlag {
 get { return hasDebugFlag; }
 }
 public Int32 DebugFlag {
 get { return debugFlag_; }
 set { SetDebugFlag(value); }
 }
 public void SetDebugFlag(Int32 value) { 
 hasDebugFlag = true;
 debugFlag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasDebugFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, DebugFlag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasDebugFlag) {
output.WriteInt32(1, DebugFlag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCommonSetting _inst = (GCCommonSetting) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.DebugFlag = input.ReadInt32();
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
public class GCCreatePlayerOK : PacketDistributed
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

public const int newPlayerFieldNumber = 2;
 private bool hasNewPlayer;
 private PlayInfo newPlayer_ =  new PlayInfo();
 public bool HasNewPlayer {
 get { return hasNewPlayer; }
 }
 public PlayInfo NewPlayer {
 get { return newPlayer_; }
 set { SetNewPlayer(value); }
 }
 public void SetNewPlayer(PlayInfo value) { 
 hasNewPlayer = true;
 newPlayer_ = value;
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
int subsize = NewPlayer.SerializedSize();	
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
output.WriteRawVarint32((uint)NewPlayer.SerializedSize());
NewPlayer.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreatePlayerOK _inst = (GCCreatePlayerOK) _base;
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
PlayInfo subBuilder =  new PlayInfo();
 input.ReadMessage(subBuilder);
_inst.NewPlayer = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasNewPlayer) {
if (!NewPlayer.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDeletePlayer : PacketDistributed
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
 GCDeletePlayer _inst = (GCDeletePlayer) _base;
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
public class GCGetRandNameBack : PacketDistributed
{

public const int mannameFieldNumber = 7;
 private pbc::PopsicleList<string> manname_ = new pbc::PopsicleList<string>();
 public scg::IList<string> mannameList {
 get { return pbc::Lists.AsReadOnly(manname_); }
 }
 
 public int mannameCount {
 get { return manname_.Count; }
 }
 
public string GetManname(int index) {
 return manname_[index];
 }
 public void AddManname(string value) {
 manname_.Add(value);
 }

public const int womannameFieldNumber = 8;
 private pbc::PopsicleList<string> womanname_ = new pbc::PopsicleList<string>();
 public scg::IList<string> womannameList {
 get { return pbc::Lists.AsReadOnly(womanname_); }
 }
 
 public int womannameCount {
 get { return womanname_.Count; }
 }
 
public string GetWomanname(int index) {
 return womanname_[index];
 }
 public void AddWomanname(string value) {
 womanname_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (string element in mannameList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * manname_.Count;
}
{
int dataSize = 0;
foreach (string element in womannameList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * womanname_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (manname_.Count > 0) {
foreach (string element in mannameList) {
output.WriteString(7,element);
}
}

}
{
if (womanname_.Count > 0) {
foreach (string element in womannameList) {
output.WriteString(8,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetRandNameBack _inst = (GCGetRandNameBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  58: {
 _inst.AddManname(input.ReadString());
break;
}
   case  66: {
 _inst.AddWomanname(input.ReadString());
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
public class GCLoginBack : PacketDistributed
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

public const int gameServerIdFieldNumber = 2;
 private bool hasGameServerId;
 private Int32 gameServerId_ = 0;
 public bool HasGameServerId {
 get { return hasGameServerId; }
 }
 public Int32 GameServerId {
 get { return gameServerId_; }
 set { SetGameServerId(value); }
 }
 public void SetGameServerId(Int32 value) { 
 hasGameServerId = true;
 gameServerId_ = value;
 }

public const int currPlayerIdFieldNumber = 3;
 private bool hasCurrPlayerId;
 private Int64 currPlayerId_ = 0;
 public bool HasCurrPlayerId {
 get { return hasCurrPlayerId; }
 }
 public Int64 CurrPlayerId {
 get { return currPlayerId_; }
 set { SetCurrPlayerId(value); }
 }
 public void SetCurrPlayerId(Int64 value) { 
 hasCurrPlayerId = true;
 currPlayerId_ = value;
 }

public const int playerListFieldNumber = 4;
 private pbc::PopsicleList<PlayInfo> playerList_ = new pbc::PopsicleList<PlayInfo>();
 public scg::IList<PlayInfo> playerListList {
 get { return pbc::Lists.AsReadOnly(playerList_); }
 }
 
 public int playerListCount {
 get { return playerList_.Count; }
 }
 
public PlayInfo GetPlayerList(int index) {
 return playerList_[index];
 }
 public void AddPlayerList(PlayInfo value) {
 playerList_.Add(value);
 }

public const int accountIDFieldNumber = 5;
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

public const int eniqueIDFieldNumber = 6;
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

public const int queueSizeFieldNumber = 7;
 private bool hasQueueSize;
 private Int32 queueSize_ = 0;
 public bool HasQueueSize {
 get { return hasQueueSize; }
 }
 public Int32 QueueSize {
 get { return queueSize_; }
 set { SetQueueSize(value); }
 }
 public void SetQueueSize(Int32 value) { 
 hasQueueSize = true;
 queueSize_ = value;
 }

public const int loginTypeFieldNumber = 8;
 private bool hasLoginType;
 private Int32 loginType_ = 0;
 public bool HasLoginType {
 get { return hasLoginType; }
 }
 public Int32 LoginType {
 get { return loginType_; }
 set { SetLoginType(value); }
 }
 public void SetLoginType(Int32 value) { 
 hasLoginType = true;
 loginType_ = value;
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
 if (HasGameServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GameServerId);
}
 if (HasCurrPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, CurrPlayerId);
}
{
foreach (PlayInfo element in playerListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(5, AccountID);
}
 if (HasEniqueID) {
size += pb::CodedOutputStream.ComputeInt64Size(6, EniqueID);
}
 if (HasQueueSize) {
size += pb::CodedOutputStream.ComputeInt32Size(7, QueueSize);
}
 if (HasLoginType) {
size += pb::CodedOutputStream.ComputeInt32Size(8, LoginType);
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
 
if (HasGameServerId) {
output.WriteInt32(2, GameServerId);
}
 
if (HasCurrPlayerId) {
output.WriteInt64(3, CurrPlayerId);
}

do{
foreach (PlayInfo element in playerListList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasAccountID) {
output.WriteInt64(5, AccountID);
}
 
if (HasEniqueID) {
output.WriteInt64(6, EniqueID);
}
 
if (HasQueueSize) {
output.WriteInt32(7, QueueSize);
}
 
if (HasLoginType) {
output.WriteInt32(8, LoginType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLoginBack _inst = (GCLoginBack) _base;
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
 _inst.GameServerId = input.ReadInt32();
break;
}
   case  24: {
 _inst.CurrPlayerId = input.ReadInt64();
break;
}
    case  34: {
PlayInfo subBuilder =  new PlayInfo();
input.ReadMessage(subBuilder);
_inst.AddPlayerList(subBuilder);
break;
}
   case  40: {
 _inst.AccountID = input.ReadInt64();
break;
}
   case  48: {
 _inst.EniqueID = input.ReadInt64();
break;
}
   case  56: {
 _inst.QueueSize = input.ReadInt32();
break;
}
   case  64: {
 _inst.LoginType = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PlayInfo element in playerListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCLoginGameServer : PacketDistributed
{

public const int playerFieldNumber = 1;
 private bool hasPlayer;
 private CharacterInfo player_ =  new CharacterInfo();
 public bool HasPlayer {
 get { return hasPlayer; }
 }
 public CharacterInfo Player {
 get { return player_; }
 set { SetPlayer(value); }
 }
 public void SetPlayer(CharacterInfo value) { 
 hasPlayer = true;
 player_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Player.SerializedSize();	
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
output.WriteRawVarint32((uint)Player.SerializedSize());
Player.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLoginGameServer _inst = (GCLoginGameServer) _base;
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
_inst.Player = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPlayer) {
if (!Player.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GLCheckVilidCode : PacketDistributed
{

public const int uidFieldNumber = 1;
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

public const int vilidCodeFieldNumber = 2;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(1, Uid);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(2, VilidCode);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlatForm);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasUid) {
output.WriteString(1, Uid);
}
 
if (HasVilidCode) {
output.WriteString(2, VilidCode);
}
 
if (HasPlatForm) {
output.WriteString(3, PlatForm);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GLCheckVilidCode _inst = (GLCheckVilidCode) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Uid = input.ReadString();
break;
}
   case  18: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  26: {
 _inst.PlatForm = input.ReadString();
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
public class GLGetPlayerLoginInfo : PacketDistributed
{

public const int vilidCodeFieldNumber = 1;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int accountIDFieldNumber = 2;
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

public const int uidFieldNumber = 4;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(1, VilidCode);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountID);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlatForm);
}
 if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(4, Uid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasVilidCode) {
output.WriteString(1, VilidCode);
}
 
if (HasAccountID) {
output.WriteInt64(2, AccountID);
}
 
if (HasPlatForm) {
output.WriteString(3, PlatForm);
}
 
if (HasUid) {
output.WriteString(4, Uid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GLGetPlayerLoginInfo _inst = (GLGetPlayerLoginInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  16: {
 _inst.AccountID = input.ReadInt64();
break;
}
   case  26: {
 _inst.PlatForm = input.ReadString();
break;
}
   case  34: {
 _inst.Uid = input.ReadString();
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
public class GLLoginSuccess : PacketDistributed
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

public const int accountIDFieldNumber = 2;
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

public const int vilidCodeFieldNumber = 3;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int onlineNumFieldNumber = 4;
 private bool hasOnlineNum;
 private Int32 onlineNum_ = 0;
 public bool HasOnlineNum {
 get { return hasOnlineNum; }
 }
 public Int32 OnlineNum {
 get { return onlineNum_; }
 set { SetOnlineNum(value); }
 }
 public void SetOnlineNum(Int32 value) { 
 hasOnlineNum = true;
 onlineNum_ = value;
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
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountID);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(3, VilidCode);
}
 if (HasOnlineNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, OnlineNum);
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
 
if (HasAccountID) {
output.WriteInt64(2, AccountID);
}
 
if (HasVilidCode) {
output.WriteString(3, VilidCode);
}
 
if (HasOnlineNum) {
output.WriteInt32(4, OnlineNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GLLoginSuccess _inst = (GLLoginSuccess) _base;
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
 _inst.AccountID = input.ReadInt64();
break;
}
   case  26: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  32: {
 _inst.OnlineNum = input.ReadInt32();
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
public class GLPlayerOffLine : PacketDistributed
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

public const int accountIDFieldNumber = 2;
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

public const int onlineNumFieldNumber = 3;
 private bool hasOnlineNum;
 private Int32 onlineNum_ = 0;
 public bool HasOnlineNum {
 get { return hasOnlineNum; }
 }
 public Int32 OnlineNum {
 get { return onlineNum_; }
 set { SetOnlineNum(value); }
 }
 public void SetOnlineNum(Int32 value) { 
 hasOnlineNum = true;
 onlineNum_ = value;
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
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountID);
}
 if (HasOnlineNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, OnlineNum);
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
 
if (HasAccountID) {
output.WriteInt64(2, AccountID);
}
 
if (HasOnlineNum) {
output.WriteInt32(3, OnlineNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GLPlayerOffLine _inst = (GLPlayerOffLine) _base;
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
 _inst.AccountID = input.ReadInt64();
break;
}
   case  24: {
 _inst.OnlineNum = input.ReadInt32();
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
public class LCBeforeLoginBack : PacketDistributed
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

public const int gameServerIdFieldNumber = 2;
 private bool hasGameServerId;
 private Int32 gameServerId_ = 0;
 public bool HasGameServerId {
 get { return hasGameServerId; }
 }
 public Int32 GameServerId {
 get { return gameServerId_; }
 set { SetGameServerId(value); }
 }
 public void SetGameServerId(Int32 value) { 
 hasGameServerId = true;
 gameServerId_ = value;
 }

public const int vilidCodeFieldNumber = 3;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int hostFieldNumber = 4;
 private bool hasHost;
 private string host_ = "";
 public bool HasHost {
 get { return hasHost; }
 }
 public string Host {
 get { return host_; }
 set { SetHost(value); }
 }
 public void SetHost(string value) { 
 hasHost = true;
 host_ = value;
 }

public const int portFieldNumber = 5;
 private bool hasPort;
 private Int32 port_ = 0;
 public bool HasPort {
 get { return hasPort; }
 }
 public Int32 Port {
 get { return port_; }
 set { SetPort(value); }
 }
 public void SetPort(Int32 value) { 
 hasPort = true;
 port_ = value;
 }

public const int accountIDFieldNumber = 6;
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

public const int authKeyFieldNumber = 7;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 if (HasGameServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GameServerId);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(3, VilidCode);
}
 if (HasHost) {
size += pb::CodedOutputStream.ComputeStringSize(4, Host);
}
 if (HasPort) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Port);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(6, AccountID);
}
 if (HasAuthKey) {
size += pb::CodedOutputStream.ComputeStringSize(7, AuthKey);
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
 
if (HasGameServerId) {
output.WriteInt32(2, GameServerId);
}
 
if (HasVilidCode) {
output.WriteString(3, VilidCode);
}
 
if (HasHost) {
output.WriteString(4, Host);
}
 
if (HasPort) {
output.WriteInt32(5, Port);
}
 
if (HasAccountID) {
output.WriteInt64(6, AccountID);
}
 
if (HasAuthKey) {
output.WriteString(7, AuthKey);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LCBeforeLoginBack _inst = (LCBeforeLoginBack) _base;
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
 _inst.GameServerId = input.ReadInt32();
break;
}
   case  26: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  34: {
 _inst.Host = input.ReadString();
break;
}
   case  40: {
 _inst.Port = input.ReadInt32();
break;
}
   case  48: {
 _inst.AccountID = input.ReadInt64();
break;
}
   case  58: {
 _inst.AuthKey = input.ReadString();
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
public class LCChangePlayerBack : PacketDistributed
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

public const int gameServerIdFieldNumber = 2;
 private bool hasGameServerId;
 private Int32 gameServerId_ = 0;
 public bool HasGameServerId {
 get { return hasGameServerId; }
 }
 public Int32 GameServerId {
 get { return gameServerId_; }
 set { SetGameServerId(value); }
 }
 public void SetGameServerId(Int32 value) { 
 hasGameServerId = true;
 gameServerId_ = value;
 }

public const int vilidCodeFieldNumber = 3;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int serverAddressFieldNumber = 4;
 private bool hasServerAddress;
 private string serverAddress_ = "";
 public bool HasServerAddress {
 get { return hasServerAddress; }
 }
 public string ServerAddress {
 get { return serverAddress_; }
 set { SetServerAddress(value); }
 }
 public void SetServerAddress(string value) { 
 hasServerAddress = true;
 serverAddress_ = value;
 }

public const int hostFieldNumber = 5;
 private bool hasHost;
 private string host_ = "";
 public bool HasHost {
 get { return hasHost; }
 }
 public string Host {
 get { return host_; }
 set { SetHost(value); }
 }
 public void SetHost(string value) { 
 hasHost = true;
 host_ = value;
 }

public const int portFieldNumber = 6;
 private bool hasPort;
 private Int32 port_ = 0;
 public bool HasPort {
 get { return hasPort; }
 }
 public Int32 Port {
 get { return port_; }
 set { SetPort(value); }
 }
 public void SetPort(Int32 value) { 
 hasPort = true;
 port_ = value;
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
 if (HasGameServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, GameServerId);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(3, VilidCode);
}
 if (HasServerAddress) {
size += pb::CodedOutputStream.ComputeStringSize(4, ServerAddress);
}
 if (HasHost) {
size += pb::CodedOutputStream.ComputeStringSize(5, Host);
}
 if (HasPort) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Port);
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
 
if (HasGameServerId) {
output.WriteInt32(2, GameServerId);
}
 
if (HasVilidCode) {
output.WriteString(3, VilidCode);
}
 
if (HasServerAddress) {
output.WriteString(4, ServerAddress);
}
 
if (HasHost) {
output.WriteString(5, Host);
}
 
if (HasPort) {
output.WriteInt32(6, Port);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LCChangePlayerBack _inst = (LCChangePlayerBack) _base;
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
 _inst.GameServerId = input.ReadInt32();
break;
}
   case  26: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  34: {
 _inst.ServerAddress = input.ReadString();
break;
}
   case  42: {
 _inst.Host = input.ReadString();
break;
}
   case  48: {
 _inst.Port = input.ReadInt32();
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
public class LCPlayerCancelLoginQueueBack : PacketDistributed
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
 LCPlayerCancelLoginQueueBack _inst = (LCPlayerCancelLoginQueueBack) _base;
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
public class LCPlayerLoginQueue : PacketDistributed
{

public const int queueNumFieldNumber = 1;
 private bool hasQueueNum;
 private Int32 queueNum_ = 0;
 public bool HasQueueNum {
 get { return hasQueueNum; }
 }
 public Int32 QueueNum {
 get { return queueNum_; }
 set { SetQueueNum(value); }
 }
 public void SetQueueNum(Int32 value) { 
 hasQueueNum = true;
 queueNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasQueueNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, QueueNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasQueueNum) {
output.WriteInt32(1, QueueNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LCPlayerLoginQueue _inst = (LCPlayerLoginQueue) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.QueueNum = input.ReadInt32();
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
public class LGCheckVilidCodeBack : PacketDistributed
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

public const int accountIDFieldNumber = 2;
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

public const int playerIDFieldNumber = 3;
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

public const int uidFieldNumber = 4;
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

public const int vilidCodeFieldNumber = 5;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int platFormFieldNumber = 6;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountID);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(3, PlayerID);
}
 if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(4, Uid);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(5, VilidCode);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(6, PlatForm);
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
 
if (HasAccountID) {
output.WriteInt64(2, AccountID);
}
 
if (HasPlayerID) {
output.WriteInt64(3, PlayerID);
}
 
if (HasUid) {
output.WriteString(4, Uid);
}
 
if (HasVilidCode) {
output.WriteString(5, VilidCode);
}
 
if (HasPlatForm) {
output.WriteString(6, PlatForm);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LGCheckVilidCodeBack _inst = (LGCheckVilidCodeBack) _base;
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
 _inst.AccountID = input.ReadInt64();
break;
}
   case  24: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  34: {
 _inst.Uid = input.ReadString();
break;
}
   case  42: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  50: {
 _inst.PlatForm = input.ReadString();
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
public class LGForceOffLine : PacketDistributed
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

public const int messageIDFieldNumber = 2;
 private bool hasMessageID;
 private Int32 messageID_ = 0;
 public bool HasMessageID {
 get { return hasMessageID; }
 }
 public Int32 MessageID {
 get { return messageID_; }
 set { SetMessageID(value); }
 }
 public void SetMessageID(Int32 value) { 
 hasMessageID = true;
 messageID_ = value;
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
 if (HasMessageID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MessageID);
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
 
if (HasMessageID) {
output.WriteInt32(2, MessageID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LGForceOffLine _inst = (LGForceOffLine) _base;
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
 _inst.MessageID = input.ReadInt32();
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
public class LGGetPlayerLoginInfoBack : PacketDistributed
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

public const int accountIDFieldNumber = 2;
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

public const int playerIDFieldNumber = 3;
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

public const int uidFieldNumber = 4;
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

public const int vilidCodeFieldNumber = 5;
 private bool hasVilidCode;
 private string vilidCode_ = "";
 public bool HasVilidCode {
 get { return hasVilidCode; }
 }
 public string VilidCode {
 get { return vilidCode_; }
 set { SetVilidCode(value); }
 }
 public void SetVilidCode(string value) { 
 hasVilidCode = true;
 vilidCode_ = value;
 }

public const int platFormFieldNumber = 6;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountID);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(3, PlayerID);
}
 if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(4, Uid);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(5, VilidCode);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(6, PlatForm);
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
 
if (HasAccountID) {
output.WriteInt64(2, AccountID);
}
 
if (HasPlayerID) {
output.WriteInt64(3, PlayerID);
}
 
if (HasUid) {
output.WriteString(4, Uid);
}
 
if (HasVilidCode) {
output.WriteString(5, VilidCode);
}
 
if (HasPlatForm) {
output.WriteString(6, PlatForm);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LGGetPlayerLoginInfoBack _inst = (LGGetPlayerLoginInfoBack) _base;
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
 _inst.AccountID = input.ReadInt64();
break;
}
   case  24: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  34: {
 _inst.Uid = input.ReadString();
break;
}
   case  42: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  50: {
 _inst.PlatForm = input.ReadString();
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
public class PlayInfo : PacketDistributed
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

public const int professionIdFieldNumber = 3;
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

public const int sexFieldNumber = 4;
 private bool hasSex;
 private Int32 sex_ = 0;
 public bool HasSex {
 get { return hasSex; }
 }
 public Int32 Sex {
 get { return sex_; }
 set { SetSex(value); }
 }
 public void SetSex(Int32 value) { 
 hasSex = true;
 sex_ = value;
 }

public const int headiconFieldNumber = 5;
 private bool hasHeadicon;
 private Int32 headicon_ = 0;
 public bool HasHeadicon {
 get { return hasHeadicon; }
 }
 public Int32 Headicon {
 get { return headicon_; }
 set { SetHeadicon(value); }
 }
 public void SetHeadicon(Int32 value) { 
 hasHeadicon = true;
 headicon_ = value;
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

public const int changeEquipInfoFieldNumber = 8;
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

public const int deleteflagFieldNumber = 9;
 private bool hasDeleteflag;
 private Int32 deleteflag_ = 0;
 public bool HasDeleteflag {
 get { return hasDeleteflag; }
 }
 public Int32 Deleteflag {
 get { return deleteflag_; }
 set { SetDeleteflag(value); }
 }
 public void SetDeleteflag(Int32 value) { 
 hasDeleteflag = true;
 deleteflag_ = value;
 }

public const int currSceneIdFieldNumber = 10;
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

public const int createTimeFieldNumber = 11;
 private bool hasCreateTime;
 private Int64 createTime_ = 0;
 public bool HasCreateTime {
 get { return hasCreateTime; }
 }
 public Int64 CreateTime {
 get { return createTime_; }
 set { SetCreateTime(value); }
 }
 public void SetCreateTime(Int64 value) { 
 hasCreateTime = true;
 createTime_ = value;
 }

public const int powerEffectFieldNumber = 12;
 private bool hasPowerEffect;
 private Int32 powerEffect_ = 0;
 public bool HasPowerEffect {
 get { return hasPowerEffect; }
 }
 public Int32 PowerEffect {
 get { return powerEffect_; }
 set { SetPowerEffect(value); }
 }
 public void SetPowerEffect(Int32 value) { 
 hasPowerEffect = true;
 powerEffect_ = value;
 }

public const int awakeEffectFieldNumber = 13;
 private bool hasAwakeEffect;
 private Int32 awakeEffect_ = 0;
 public bool HasAwakeEffect {
 get { return hasAwakeEffect; }
 }
 public Int32 AwakeEffect {
 get { return awakeEffect_; }
 set { SetAwakeEffect(value); }
 }
 public void SetAwakeEffect(Int32 value) { 
 hasAwakeEffect = true;
 awakeEffect_ = value;
 }

public const int gemEffectFieldNumber = 14;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasProfessionId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ProfessionId);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Sex);
}
 if (HasHeadicon) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Headicon);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Level);
}
{
int subsize = ChangeEquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasDeleteflag) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Deleteflag);
}
 if (HasCurrSceneId) {
size += pb::CodedOutputStream.ComputeInt32Size(10, CurrSceneId);
}
 if (HasCreateTime) {
size += pb::CodedOutputStream.ComputeInt64Size(11, CreateTime);
}
 if (HasPowerEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(12, PowerEffect);
}
 if (HasAwakeEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(13, AwakeEffect);
}
 if (HasGemEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(14, GemEffect);
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
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasProfessionId) {
output.WriteInt32(3, ProfessionId);
}
 
if (HasSex) {
output.WriteInt32(4, Sex);
}
 
if (HasHeadicon) {
output.WriteInt32(5, Headicon);
}
 
if (HasLevel) {
output.WriteInt32(6, Level);
}
{
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ChangeEquipInfo.SerializedSize());
ChangeEquipInfo.WriteTo(output);

}
 
if (HasDeleteflag) {
output.WriteInt32(9, Deleteflag);
}
 
if (HasCurrSceneId) {
output.WriteInt32(10, CurrSceneId);
}
 
if (HasCreateTime) {
output.WriteInt64(11, CreateTime);
}
 
if (HasPowerEffect) {
output.WriteInt32(12, PowerEffect);
}
 
if (HasAwakeEffect) {
output.WriteInt32(13, AwakeEffect);
}
 
if (HasGemEffect) {
output.WriteInt32(14, GemEffect);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PlayInfo _inst = (PlayInfo) _base;
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
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.ProfessionId = input.ReadInt32();
break;
}
   case  32: {
 _inst.Sex = input.ReadInt32();
break;
}
   case  40: {
 _inst.Headicon = input.ReadInt32();
break;
}
   case  48: {
 _inst.Level = input.ReadInt32();
break;
}
    case  66: {
ChangeEquipInfo subBuilder =  new ChangeEquipInfo();
 input.ReadMessage(subBuilder);
_inst.ChangeEquipInfo = subBuilder;
break;
}
   case  72: {
 _inst.Deleteflag = input.ReadInt32();
break;
}
   case  80: {
 _inst.CurrSceneId = input.ReadInt32();
break;
}
   case  88: {
 _inst.CreateTime = input.ReadInt64();
break;
}
   case  96: {
 _inst.PowerEffect = input.ReadInt32();
break;
}
   case  104: {
 _inst.AwakeEffect = input.ReadInt32();
break;
}
   case  112: {
 _inst.GemEffect = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasChangeEquipInfo) {
if (!ChangeEquipInfo.IsInitialized()) return false;
}
 return true;
 }

	}


}
