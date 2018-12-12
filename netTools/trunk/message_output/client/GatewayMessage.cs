//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CodeInfo : PacketDistributed
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

public const int vilidityTimeFieldNumber = 3;
 private bool hasVilidityTime;
 private Int64 vilidityTime_ = 0;
 public bool HasVilidityTime {
 get { return hasVilidityTime; }
 }
 public Int64 VilidityTime {
 get { return vilidityTime_; }
 set { SetVilidityTime(value); }
 }
 public void SetVilidityTime(Int64 value) { 
 hasVilidityTime = true;
 vilidityTime_ = value;
 }

public const int platFormFieldNumber = 4;
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

public const int uidFieldNumber = 5;
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

public const int playerIdFieldNumber = 6;
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
  if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(1, VilidCode);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountID);
}
 if (HasVilidityTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, VilidityTime);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(4, PlatForm);
}
 if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(5, Uid);
}
 if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(6, PlayerId);
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
 
if (HasVilidityTime) {
output.WriteInt64(3, VilidityTime);
}
 
if (HasPlatForm) {
output.WriteString(4, PlatForm);
}
 
if (HasUid) {
output.WriteString(5, Uid);
}
 
if (HasPlayerId) {
output.WriteInt64(6, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CodeInfo _inst = (CodeInfo) _base;
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
   case  24: {
 _inst.VilidityTime = input.ReadInt64();
break;
}
   case  34: {
 _inst.PlatForm = input.ReadString();
break;
}
   case  42: {
 _inst.Uid = input.ReadString();
break;
}
   case  48: {
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
public class Game2UserForwardMessage : PacketDistributed
{

public const int allServerFieldNumber = 1;
 private bool hasAllServer;
 private Int32 allServer_ = 0;
 public bool HasAllServer {
 get { return hasAllServer; }
 }
 public Int32 AllServer {
 get { return allServer_; }
 set { SetAllServer(value); }
 }
 public void SetAllServer(Int32 value) { 
 hasAllServer = true;
 allServer_ = value;
 }

public const int accountIdFieldNumber = 2;
 private pbc::PopsicleList<Int64> accountId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> accountIdList {
 get { return pbc::Lists.AsReadOnly(accountId_); }
 }
 
 public int accountIdCount {
 get { return accountId_.Count; }
 }
 
public Int64 GetAccountId(int index) {
 return accountId_[index];
 }
 public void AddAccountId(Int64 value) {
 accountId_.Add(value);
 }

public const int messageIdFieldNumber = 3;
 private bool hasMessageId;
 private Int32 messageId_ = 0;
 public bool HasMessageId {
 get { return hasMessageId; }
 }
 public Int32 MessageId {
 get { return messageId_; }
 set { SetMessageId(value); }
 }
 public void SetMessageId(Int32 value) { 
 hasMessageId = true;
 messageId_ = value;
 }

public const int innerPacketFieldNumber = 4;
 private bool hasInnerPacket;
 private pb::ByteString innerPacket_ = pb::ByteString.Empty;
 public bool HasInnerPacket {
 get { return hasInnerPacket; }
 }
 public pb::ByteString InnerPacket {
 get { return innerPacket_; }
 set { SetInnerPacket(value); }
 }
 public void SetInnerPacket(pb::ByteString value) { 
 hasInnerPacket = true;
 innerPacket_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAllServer) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AllServer);
}
{
int dataSize = 0;
foreach (Int64 element in accountIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * accountId_.Count;
}
 if (HasMessageId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MessageId);
}
 if (HasInnerPacket) {
size += pb::CodedOutputStream.ComputeBytesSize(4, InnerPacket);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAllServer) {
output.WriteInt32(1, AllServer);
}
{
if (accountId_.Count > 0) {
foreach (Int64 element in accountIdList) {
output.WriteInt64(2,element);
}
}

}
 
if (HasMessageId) {
output.WriteInt32(3, MessageId);
}
 
if (HasInnerPacket) {
output.WriteBytes(4, InnerPacket);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Game2UserForwardMessage _inst = (Game2UserForwardMessage) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AllServer = input.ReadInt32();
break;
}
   case  16: {
 _inst.AddAccountId(input.ReadInt64());
break;
}
   case  24: {
 _inst.MessageId = input.ReadInt32();
break;
}
   case  34: {
 _inst.InnerPacket = input.ReadBytes();
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
public class Gate2GameInterruptUserSession : PacketDistributed
{

public const int accountIdFieldNumber = 2;
 private bool hasAccountId;
 private Int64 accountId_ = 0;
 public bool HasAccountId {
 get { return hasAccountId; }
 }
 public Int64 AccountId {
 get { return accountId_; }
 set { SetAccountId(value); }
 }
 public void SetAccountId(Int64 value) { 
 hasAccountId = true;
 accountId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAccountId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAccountId) {
output.WriteInt64(2, AccountId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Gate2GameInterruptUserSession _inst = (Gate2GameInterruptUserSession) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  16: {
 _inst.AccountId = input.ReadInt64();
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
public class Gate2GamePlayerLoginout : PacketDistributed
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

public const int accountIdFieldNumber = 2;
 private bool hasAccountId;
 private Int64 accountId_ = 0;
 public bool HasAccountId {
 get { return hasAccountId; }
 }
 public Int64 AccountId {
 get { return accountId_; }
 set { SetAccountId(value); }
 }
 public void SetAccountId(Int64 value) { 
 hasAccountId = true;
 accountId_ = value;
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
 if (HasAccountId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountId);
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
 
if (HasAccountId) {
output.WriteInt64(2, AccountId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Gate2GamePlayerLoginout _inst = (Gate2GamePlayerLoginout) _base;
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
 _inst.AccountId = input.ReadInt64();
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
public class Gate2LoginLoadPush : PacketDistributed
{

public const int gateIdFieldNumber = 1;
 private bool hasGateId;
 private Int32 gateId_ = 0;
 public bool HasGateId {
 get { return hasGateId; }
 }
 public Int32 GateId {
 get { return gateId_; }
 set { SetGateId(value); }
 }
 public void SetGateId(Int32 value) { 
 hasGateId = true;
 gateId_ = value;
 }

public const int playerNumFieldNumber = 2;
 private bool hasPlayerNum;
 private Int32 playerNum_ = 0;
 public bool HasPlayerNum {
 get { return hasPlayerNum; }
 }
 public Int32 PlayerNum {
 get { return playerNum_; }
 set { SetPlayerNum(value); }
 }
 public void SetPlayerNum(Int32 value) { 
 hasPlayerNum = true;
 playerNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGateId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GateId);
}
 if (HasPlayerNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PlayerNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGateId) {
output.WriteInt32(1, GateId);
}
 
if (HasPlayerNum) {
output.WriteInt32(2, PlayerNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Gate2LoginLoadPush _inst = (Gate2LoginLoadPush) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GateId = input.ReadInt32();
break;
}
   case  16: {
 _inst.PlayerNum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  if (!hasGateId) return false;
 if (!hasPlayerNum) return false;
 return true;
 }

	}


[Serializable]
public class GateRegist : PacketDistributed
{

public const int gateIdFieldNumber = 1;
 private bool hasGateId;
 private Int32 gateId_ = 0;
 public bool HasGateId {
 get { return hasGateId; }
 }
 public Int32 GateId {
 get { return gateId_; }
 set { SetGateId(value); }
 }
 public void SetGateId(Int32 value) { 
 hasGateId = true;
 gateId_ = value;
 }

public const int hostFieldNumber = 2;
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

public const int portFieldNumber = 3;
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
  if (HasGateId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GateId);
}
 if (HasHost) {
size += pb::CodedOutputStream.ComputeStringSize(2, Host);
}
 if (HasPort) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Port);
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
  
if (HasGateId) {
output.WriteInt32(1, GateId);
}
 
if (HasHost) {
output.WriteString(2, Host);
}
 
if (HasPort) {
output.WriteInt32(3, Port);
}
 
if (HasOnlineNum) {
output.WriteInt32(4, OnlineNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GateRegist _inst = (GateRegist) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GateId = input.ReadInt32();
break;
}
   case  18: {
 _inst.Host = input.ReadString();
break;
}
   case  24: {
 _inst.Port = input.ReadInt32();
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
public class GateRegistBack : PacketDistributed
{

public const int codeFieldNumber = 1;
 private bool hasCode;
 private Int32 code_ = 0;
 public bool HasCode {
 get { return hasCode; }
 }
 public Int32 Code {
 get { return code_; }
 set { SetCode(value); }
 }
 public void SetCode(Int32 value) { 
 hasCode = true;
 code_ = value;
 }

public const int infosFieldNumber = 2;
 private pbc::PopsicleList<CodeInfo> infos_ = new pbc::PopsicleList<CodeInfo>();
 public scg::IList<CodeInfo> infosList {
 get { return pbc::Lists.AsReadOnly(infos_); }
 }
 
 public int infosCount {
 get { return infos_.Count; }
 }
 
public CodeInfo GetInfos(int index) {
 return infos_[index];
 }
 public void AddInfos(CodeInfo value) {
 infos_.Add(value);
 }

public const int serverTypeFieldNumber = 3;
 private bool hasServerType;
 private Int32 serverType_ = 0;
 public bool HasServerType {
 get { return hasServerType; }
 }
 public Int32 ServerType {
 get { return serverType_; }
 set { SetServerType(value); }
 }
 public void SetServerType(Int32 value) { 
 hasServerType = true;
 serverType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Code);
}
{
foreach (CodeInfo element in infosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasServerType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ServerType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCode) {
output.WriteInt32(1, Code);
}

do{
foreach (CodeInfo element in infosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasServerType) {
output.WriteInt32(3, ServerType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GateRegistBack _inst = (GateRegistBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Code = input.ReadInt32();
break;
}
    case  18: {
CodeInfo subBuilder =  new CodeInfo();
input.ReadMessage(subBuilder);
_inst.AddInfos(subBuilder);
break;
}
   case  24: {
 _inst.ServerType = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CodeInfo element in infosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GateWReadyPush : PacketDistributed
{

public const int codeFieldNumber = 1;
 private bool hasCode;
 private Int32 code_ = 0;
 public bool HasCode {
 get { return hasCode; }
 }
 public Int32 Code {
 get { return code_; }
 set { SetCode(value); }
 }
 public void SetCode(Int32 value) { 
 hasCode = true;
 code_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Code);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCode) {
output.WriteInt32(1, Code);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GateWReadyPush _inst = (GateWReadyPush) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Code = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
  if (!hasCode) return false;
 return true;
 }

	}


[Serializable]
public class User2GameForwardMessage : PacketDistributed
{

public const int accountIdFieldNumber = 2;
 private bool hasAccountId;
 private Int64 accountId_ = 0;
 public bool HasAccountId {
 get { return hasAccountId; }
 }
 public Int64 AccountId {
 get { return accountId_; }
 set { SetAccountId(value); }
 }
 public void SetAccountId(Int64 value) { 
 hasAccountId = true;
 accountId_ = value;
 }

public const int messageIdFieldNumber = 3;
 private bool hasMessageId;
 private Int32 messageId_ = 0;
 public bool HasMessageId {
 get { return hasMessageId; }
 }
 public Int32 MessageId {
 get { return messageId_; }
 set { SetMessageId(value); }
 }
 public void SetMessageId(Int32 value) { 
 hasMessageId = true;
 messageId_ = value;
 }

public const int innerPacketFieldNumber = 4;
 private bool hasInnerPacket;
 private pb::ByteString innerPacket_ = pb::ByteString.Empty;
 public bool HasInnerPacket {
 get { return hasInnerPacket; }
 }
 public pb::ByteString InnerPacket {
 get { return innerPacket_; }
 set { SetInnerPacket(value); }
 }
 public void SetInnerPacket(pb::ByteString value) { 
 hasInnerPacket = true;
 innerPacket_ = value;
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

public const int ipFieldNumber = 6;
 private bool hasIp;
 private string ip_ = "";
 public bool HasIp {
 get { return hasIp; }
 }
 public string Ip {
 get { return ip_; }
 set { SetIp(value); }
 }
 public void SetIp(string value) { 
 hasIp = true;
 ip_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAccountId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, AccountId);
}
 if (HasMessageId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MessageId);
}
 if (HasInnerPacket) {
size += pb::CodedOutputStream.ComputeBytesSize(4, InnerPacket);
}
 if (HasVilidCode) {
size += pb::CodedOutputStream.ComputeStringSize(5, VilidCode);
}
 if (HasIp) {
size += pb::CodedOutputStream.ComputeStringSize(6, Ip);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAccountId) {
output.WriteInt64(2, AccountId);
}
 
if (HasMessageId) {
output.WriteInt32(3, MessageId);
}
 
if (HasInnerPacket) {
output.WriteBytes(4, InnerPacket);
}
 
if (HasVilidCode) {
output.WriteString(5, VilidCode);
}
 
if (HasIp) {
output.WriteString(6, Ip);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 User2GameForwardMessage _inst = (User2GameForwardMessage) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  16: {
 _inst.AccountId = input.ReadInt64();
break;
}
   case  24: {
 _inst.MessageId = input.ReadInt32();
break;
}
   case  34: {
 _inst.InnerPacket = input.ReadBytes();
break;
}
   case  42: {
 _inst.VilidCode = input.ReadString();
break;
}
   case  50: {
 _inst.Ip = input.ReadString();
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
