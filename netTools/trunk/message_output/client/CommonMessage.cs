//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class BackSyncInnerPacket : PacketDistributed
{

public const int exchagerIdFieldNumber = 1;
 private bool hasExchagerId;
 private Int64 exchagerId_ = 0;
 public bool HasExchagerId {
 get { return hasExchagerId; }
 }
 public Int64 ExchagerId {
 get { return exchagerId_; }
 set { SetExchagerId(value); }
 }
 public void SetExchagerId(Int64 value) { 
 hasExchagerId = true;
 exchagerId_ = value;
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

public const int innerPacketIdFieldNumber = 3;
 private bool hasInnerPacketId;
 private Int32 innerPacketId_ = 0;
 public bool HasInnerPacketId {
 get { return hasInnerPacketId; }
 }
 public Int32 InnerPacketId {
 get { return innerPacketId_; }
 set { SetInnerPacketId(value); }
 }
 public void SetInnerPacketId(Int32 value) { 
 hasInnerPacketId = true;
 innerPacketId_ = value;
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
  if (HasExchagerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ExchagerId);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 if (HasInnerPacketId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, InnerPacketId);
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
  
if (HasExchagerId) {
output.WriteInt64(1, ExchagerId);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 
if (HasInnerPacketId) {
output.WriteInt32(3, InnerPacketId);
}
 
if (HasInnerPacket) {
output.WriteBytes(4, InnerPacket);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BackSyncInnerPacket _inst = (BackSyncInnerPacket) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ExchagerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Result = input.ReadInt32();
break;
}
   case  24: {
 _inst.InnerPacketId = input.ReadInt32();
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
public class CGReLogin : PacketDistributed
{

public const int accountIDFieldNumber = 1;
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

public const int authKeyFieldNumber = 4;
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
  if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, AccountID);
}
 if (HasUid) {
size += pb::CodedOutputStream.ComputeStringSize(2, Uid);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlatForm);
}
 if (HasAuthKey) {
size += pb::CodedOutputStream.ComputeStringSize(4, AuthKey);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAccountID) {
output.WriteInt64(1, AccountID);
}
 
if (HasUid) {
output.WriteString(2, Uid);
}
 
if (HasPlatForm) {
output.WriteString(3, PlatForm);
}
 
if (HasAuthKey) {
output.WriteString(4, AuthKey);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGReLogin _inst = (CGReLogin) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AccountID = input.ReadInt64();
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
   case  34: {
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
public class EntryIntInt : PacketDistributed
{

public const int keyFieldNumber = 1;
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

public const int valueFieldNumber = 2;
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
  if (HasKey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Key);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Value);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteInt32(1, Key);
}
 
if (HasValue) {
output.WriteInt32(2, Value);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EntryIntInt _inst = (EntryIntInt) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Key = input.ReadInt32();
break;
}
   case  16: {
 _inst.Value = input.ReadInt32();
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
public class EntryLongAry : PacketDistributed
{

public const int keyFieldNumber = 1;
 private bool hasKey;
 private Int64 key_ = 0;
 public bool HasKey {
 get { return hasKey; }
 }
 public Int64 Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(Int64 value) { 
 hasKey = true;
 key_ = value;
 }

public const int strAryFieldNumber = 2;
 private pbc::PopsicleList<string> strAry_ = new pbc::PopsicleList<string>();
 public scg::IList<string> strAryList {
 get { return pbc::Lists.AsReadOnly(strAry_); }
 }
 
 public int strAryCount {
 get { return strAry_.Count; }
 }
 
public string GetStrAry(int index) {
 return strAry_[index];
 }
 public void AddStrAry(string value) {
 strAry_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasKey) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Key);
}
{
int dataSize = 0;
foreach (string element in strAryList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * strAry_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteInt64(1, Key);
}
{
if (strAry_.Count > 0) {
foreach (string element in strAryList) {
output.WriteString(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EntryLongAry _inst = (EntryLongAry) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Key = input.ReadInt64();
break;
}
   case  18: {
 _inst.AddStrAry(input.ReadString());
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
public class EntryLongInt : PacketDistributed
{

public const int keyFieldNumber = 1;
 private bool hasKey;
 private Int64 key_ = 0;
 public bool HasKey {
 get { return hasKey; }
 }
 public Int64 Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(Int64 value) { 
 hasKey = true;
 key_ = value;
 }

public const int valueFieldNumber = 2;
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
  if (HasKey) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Key);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Value);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteInt64(1, Key);
}
 
if (HasValue) {
output.WriteInt32(2, Value);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EntryLongInt _inst = (EntryLongInt) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Key = input.ReadInt64();
break;
}
   case  16: {
 _inst.Value = input.ReadInt32();
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
public class EntryStrStr : PacketDistributed
{

public const int keyFieldNumber = 1;
 private bool hasKey;
 private string key_ = "";
 public bool HasKey {
 get { return hasKey; }
 }
 public string Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(string value) { 
 hasKey = true;
 key_ = value;
 }

public const int valueFieldNumber = 2;
 private bool hasValue;
 private string value_ = "";
 public bool HasValue {
 get { return hasValue; }
 }
 public string Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(string value) { 
 hasValue = true;
 value_ = value;
 }

public const int typeFieldNumber = 3;
 private bool hasType;
 private string type_ = "";
 public bool HasType {
 get { return hasType; }
 }
 public string Type {
 get { return type_; }
 set { SetType(value); }
 }
 public void SetType(string value) { 
 hasType = true;
 type_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasKey) {
size += pb::CodedOutputStream.ComputeStringSize(1, Key);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeStringSize(2, Value);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeStringSize(3, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteString(1, Key);
}
 
if (HasValue) {
output.WriteString(2, Value);
}
 
if (HasType) {
output.WriteString(3, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EntryStrStr _inst = (EntryStrStr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Key = input.ReadString();
break;
}
   case  18: {
 _inst.Value = input.ReadString();
break;
}
   case  26: {
 _inst.Type = input.ReadString();
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
public class EntryStringInt : PacketDistributed
{

public const int keyFieldNumber = 1;
 private bool hasKey;
 private string key_ = "";
 public bool HasKey {
 get { return hasKey; }
 }
 public string Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(string value) { 
 hasKey = true;
 key_ = value;
 }

public const int valueFieldNumber = 2;
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
  if (HasKey) {
size += pb::CodedOutputStream.ComputeStringSize(1, Key);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Value);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteString(1, Key);
}
 
if (HasValue) {
output.WriteInt32(2, Value);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 EntryStringInt _inst = (EntryStringInt) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Key = input.ReadString();
break;
}
   case  16: {
 _inst.Value = input.ReadInt32();
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
public class GCFunctionOpen : PacketDistributed
{

public const int functionIdFieldNumber = 1;
 private bool hasFunctionId;
 private Int32 functionId_ = 0;
 public bool HasFunctionId {
 get { return hasFunctionId; }
 }
 public Int32 FunctionId {
 get { return functionId_; }
 set { SetFunctionId(value); }
 }
 public void SetFunctionId(Int32 value) { 
 hasFunctionId = true;
 functionId_ = value;
 }

public const int functionValFieldNumber = 2;
 private bool hasFunctionVal;
 private Int32 functionVal_ = 0;
 public bool HasFunctionVal {
 get { return hasFunctionVal; }
 }
 public Int32 FunctionVal {
 get { return functionVal_; }
 set { SetFunctionVal(value); }
 }
 public void SetFunctionVal(Int32 value) { 
 hasFunctionVal = true;
 functionVal_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFunctionId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FunctionId);
}
 if (HasFunctionVal) {
size += pb::CodedOutputStream.ComputeInt32Size(2, FunctionVal);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFunctionId) {
output.WriteInt32(1, FunctionId);
}
 
if (HasFunctionVal) {
output.WriteInt32(2, FunctionVal);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFunctionOpen _inst = (GCFunctionOpen) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FunctionId = input.ReadInt32();
break;
}
   case  16: {
 _inst.FunctionVal = input.ReadInt32();
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
public class GCFunctionOpenList : PacketDistributed
{

public const int functionsFieldNumber = 1;
 private pbc::PopsicleList<GCFunctionOpen> functions_ = new pbc::PopsicleList<GCFunctionOpen>();
 public scg::IList<GCFunctionOpen> functionsList {
 get { return pbc::Lists.AsReadOnly(functions_); }
 }
 
 public int functionsCount {
 get { return functions_.Count; }
 }
 
public GCFunctionOpen GetFunctions(int index) {
 return functions_[index];
 }
 public void AddFunctions(GCFunctionOpen value) {
 functions_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GCFunctionOpen element in functionsList) {
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
foreach (GCFunctionOpen element in functionsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFunctionOpenList _inst = (GCFunctionOpenList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GCFunctionOpen subBuilder =  new GCFunctionOpen();
input.ReadMessage(subBuilder);
_inst.AddFunctions(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCFunctionOpen element in functionsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCReLogin : PacketDistributed
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
 GCReLogin _inst = (GCReLogin) _base;
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
public class LoginRegistBack : PacketDistributed
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

public const int serverIDFieldNumber = 2;
 private bool hasServerID;
 private Int32 serverID_ = 0;
 public bool HasServerID {
 get { return hasServerID; }
 }
 public Int32 ServerID {
 get { return serverID_; }
 set { SetServerID(value); }
 }
 public void SetServerID(Int32 value) { 
 hasServerID = true;
 serverID_ = value;
 }

public const int serverNameFieldNumber = 3;
 private bool hasServerName;
 private string serverName_ = "";
 public bool HasServerName {
 get { return hasServerName; }
 }
 public string ServerName {
 get { return serverName_; }
 set { SetServerName(value); }
 }
 public void SetServerName(string value) { 
 hasServerName = true;
 serverName_ = value;
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
  if (HasCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Code);
}
 if (HasServerID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ServerID);
}
 if (HasServerName) {
size += pb::CodedOutputStream.ComputeStringSize(3, ServerName);
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
  
if (HasCode) {
output.WriteInt32(1, Code);
}
 
if (HasServerID) {
output.WriteInt32(2, ServerID);
}
 
if (HasServerName) {
output.WriteString(3, ServerName);
}
 
if (HasOnlineNum) {
output.WriteInt32(4, OnlineNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LoginRegistBack _inst = (LoginRegistBack) _base;
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
   case  16: {
 _inst.ServerID = input.ReadInt32();
break;
}
   case  26: {
 _inst.ServerName = input.ReadString();
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
public class LoginSendVilicode : PacketDistributed
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

public const int viliCodeFieldNumber = 2;
 private bool hasViliCode;
 private string viliCode_ = "";
 public bool HasViliCode {
 get { return hasViliCode; }
 }
 public string ViliCode {
 get { return viliCode_; }
 set { SetViliCode(value); }
 }
 public void SetViliCode(string value) { 
 hasViliCode = true;
 viliCode_ = value;
 }

public const int invalidTimeFieldNumber = 3;
 private bool hasInvalidTime;
 private Int64 invalidTime_ = 0;
 public bool HasInvalidTime {
 get { return hasInvalidTime; }
 }
 public Int64 InvalidTime {
 get { return invalidTime_; }
 set { SetInvalidTime(value); }
 }
 public void SetInvalidTime(Int64 value) { 
 hasInvalidTime = true;
 invalidTime_ = value;
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
 if (HasViliCode) {
size += pb::CodedOutputStream.ComputeStringSize(2, ViliCode);
}
 if (HasInvalidTime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, InvalidTime);
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
 
if (HasViliCode) {
output.WriteString(2, ViliCode);
}
 
if (HasInvalidTime) {
output.WriteInt64(3, InvalidTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 LoginSendVilicode _inst = (LoginSendVilicode) _base;
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
 _inst.ViliCode = input.ReadString();
break;
}
   case  24: {
 _inst.InvalidTime = input.ReadInt64();
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
public class MapLongAry : PacketDistributed
{

public const int entryFieldNumber = 1;
 private pbc::PopsicleList<EntryLongAry> entry_ = new pbc::PopsicleList<EntryLongAry>();
 public scg::IList<EntryLongAry> entryList {
 get { return pbc::Lists.AsReadOnly(entry_); }
 }
 
 public int entryCount {
 get { return entry_.Count; }
 }
 
public EntryLongAry GetEntry(int index) {
 return entry_[index];
 }
 public void AddEntry(EntryLongAry value) {
 entry_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (EntryLongAry element in entryList) {
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
foreach (EntryLongAry element in entryList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MapLongAry _inst = (MapLongAry) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
EntryLongAry subBuilder =  new EntryLongAry();
input.ReadMessage(subBuilder);
_inst.AddEntry(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EntryLongAry element in entryList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class MapStrStr : PacketDistributed
{

public const int entryFieldNumber = 1;
 private pbc::PopsicleList<EntryStrStr> entry_ = new pbc::PopsicleList<EntryStrStr>();
 public scg::IList<EntryStrStr> entryList {
 get { return pbc::Lists.AsReadOnly(entry_); }
 }
 
 public int entryCount {
 get { return entry_.Count; }
 }
 
public EntryStrStr GetEntry(int index) {
 return entry_[index];
 }
 public void AddEntry(EntryStrStr value) {
 entry_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (EntryStrStr element in entryList) {
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
foreach (EntryStrStr element in entryList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MapStrStr _inst = (MapStrStr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
EntryStrStr subBuilder =  new EntryStrStr();
input.ReadMessage(subBuilder);
_inst.AddEntry(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (EntryStrStr element in entryList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class PropertiesInfo : PacketDistributed
{

public const int keyFieldNumber = 1;
 private bool hasKey;
 private string key_ = "";
 public bool HasKey {
 get { return hasKey; }
 }
 public string Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(string value) { 
 hasKey = true;
 key_ = value;
 }

public const int valueFieldNumber = 2;
 private pbc::PopsicleList<string> value_ = new pbc::PopsicleList<string>();
 public scg::IList<string> valueList {
 get { return pbc::Lists.AsReadOnly(value_); }
 }
 
 public int valueCount {
 get { return value_.Count; }
 }
 
public string GetValue(int index) {
 return value_[index];
 }
 public void AddValue(string value) {
 value_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasKey) {
size += pb::CodedOutputStream.ComputeStringSize(1, Key);
}
{
int dataSize = 0;
foreach (string element in valueList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * value_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteString(1, Key);
}
{
if (value_.Count > 0) {
foreach (string element in valueList) {
output.WriteString(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PropertiesInfo _inst = (PropertiesInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Key = input.ReadString();
break;
}
   case  18: {
 _inst.AddValue(input.ReadString());
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
public class ReqServerProperties : PacketDistributed
{

public const int serverTypeFieldNumber = 1;
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

public const int propFileNameFieldNumber = 2;
 private pbc::PopsicleList<string> propFileName_ = new pbc::PopsicleList<string>();
 public scg::IList<string> propFileNameList {
 get { return pbc::Lists.AsReadOnly(propFileName_); }
 }
 
 public int propFileNameCount {
 get { return propFileName_.Count; }
 }
 
public string GetPropFileName(int index) {
 return propFileName_[index];
 }
 public void AddPropFileName(string value) {
 propFileName_.Add(value);
 }

public const int needMongodbFieldNumber = 3;
 private bool hasNeedMongodb;
 private Int32 needMongodb_ = 0;
 public bool HasNeedMongodb {
 get { return hasNeedMongodb; }
 }
 public Int32 NeedMongodb {
 get { return needMongodb_; }
 set { SetNeedMongodb(value); }
 }
 public void SetNeedMongodb(Int32 value) { 
 hasNeedMongodb = true;
 needMongodb_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasServerType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ServerType);
}
{
int dataSize = 0;
foreach (string element in propFileNameList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * propFileName_.Count;
}
 if (HasNeedMongodb) {
size += pb::CodedOutputStream.ComputeInt32Size(3, NeedMongodb);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasServerType) {
output.WriteInt32(1, ServerType);
}
{
if (propFileName_.Count > 0) {
foreach (string element in propFileNameList) {
output.WriteString(2,element);
}
}

}
 
if (HasNeedMongodb) {
output.WriteInt32(3, NeedMongodb);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ReqServerProperties _inst = (ReqServerProperties) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ServerType = input.ReadInt32();
break;
}
   case  18: {
 _inst.AddPropFileName(input.ReadString());
break;
}
   case  24: {
 _inst.NeedMongodb = input.ReadInt32();
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
public class SendSyncInnerPacket : PacketDistributed
{

public const int exchagerIdFieldNumber = 1;
 private bool hasExchagerId;
 private Int64 exchagerId_ = 0;
 public bool HasExchagerId {
 get { return hasExchagerId; }
 }
 public Int64 ExchagerId {
 get { return exchagerId_; }
 set { SetExchagerId(value); }
 }
 public void SetExchagerId(Int64 value) { 
 hasExchagerId = true;
 exchagerId_ = value;
 }

public const int innerPacketIdFieldNumber = 2;
 private bool hasInnerPacketId;
 private Int32 innerPacketId_ = 0;
 public bool HasInnerPacketId {
 get { return hasInnerPacketId; }
 }
 public Int32 InnerPacketId {
 get { return innerPacketId_; }
 set { SetInnerPacketId(value); }
 }
 public void SetInnerPacketId(Int32 value) { 
 hasInnerPacketId = true;
 innerPacketId_ = value;
 }

public const int innerPacketFieldNumber = 3;
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
  if (HasExchagerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ExchagerId);
}
 if (HasInnerPacketId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, InnerPacketId);
}
 if (HasInnerPacket) {
size += pb::CodedOutputStream.ComputeBytesSize(3, InnerPacket);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasExchagerId) {
output.WriteInt64(1, ExchagerId);
}
 
if (HasInnerPacketId) {
output.WriteInt32(2, InnerPacketId);
}
 
if (HasInnerPacket) {
output.WriteBytes(3, InnerPacket);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SendSyncInnerPacket _inst = (SendSyncInnerPacket) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ExchagerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.InnerPacketId = input.ReadInt32();
break;
}
   case  26: {
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
public class ServerPropertiesBack : PacketDistributed
{

public const int serverTypeFieldNumber = 1;
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

public const int serverGroupIdFieldNumber = 2;
 private bool hasServerGroupId;
 private Int32 serverGroupId_ = 0;
 public bool HasServerGroupId {
 get { return hasServerGroupId; }
 }
 public Int32 ServerGroupId {
 get { return serverGroupId_; }
 set { SetServerGroupId(value); }
 }
 public void SetServerGroupId(Int32 value) { 
 hasServerGroupId = true;
 serverGroupId_ = value;
 }

public const int propInfoArrFieldNumber = 3;
 private pbc::PopsicleList<PropertiesInfo> propInfoArr_ = new pbc::PopsicleList<PropertiesInfo>();
 public scg::IList<PropertiesInfo> propInfoArrList {
 get { return pbc::Lists.AsReadOnly(propInfoArr_); }
 }
 
 public int propInfoArrCount {
 get { return propInfoArr_.Count; }
 }
 
public PropertiesInfo GetPropInfoArr(int index) {
 return propInfoArr_[index];
 }
 public void AddPropInfoArr(PropertiesInfo value) {
 propInfoArr_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasServerType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ServerType);
}
 if (HasServerGroupId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ServerGroupId);
}
{
foreach (PropertiesInfo element in propInfoArrList) {
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
  
if (HasServerType) {
output.WriteInt32(1, ServerType);
}
 
if (HasServerGroupId) {
output.WriteInt32(2, ServerGroupId);
}

do{
foreach (PropertiesInfo element in propInfoArrList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ServerPropertiesBack _inst = (ServerPropertiesBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ServerType = input.ReadInt32();
break;
}
   case  16: {
 _inst.ServerGroupId = input.ReadInt32();
break;
}
    case  26: {
PropertiesInfo subBuilder =  new PropertiesInfo();
input.ReadMessage(subBuilder);
_inst.AddPropInfoArr(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PropertiesInfo element in propInfoArrList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class ServerRegist : PacketDistributed
{

public const int serverIdFieldNumber = 1;
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

public const int serverTypeFieldNumber = 2;
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
  if (HasServerId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ServerId);
}
 if (HasServerType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ServerType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasServerId) {
output.WriteInt32(1, ServerId);
}
 
if (HasServerType) {
output.WriteInt32(2, ServerType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ServerRegist _inst = (ServerRegist) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ServerId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ServerType = input.ReadInt32();
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
