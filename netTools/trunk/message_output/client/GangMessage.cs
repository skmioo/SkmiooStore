//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class BuildingInfo : PacketDistributed
{

public const int gangDonateNumFieldNumber = 1;
 private bool hasGangDonateNum;
 private Int32 gangDonateNum_ = 0;
 public bool HasGangDonateNum {
 get { return hasGangDonateNum; }
 }
 public Int32 GangDonateNum {
 get { return gangDonateNum_; }
 set { SetGangDonateNum(value); }
 }
 public void SetGangDonateNum(Int32 value) { 
 hasGangDonateNum = true;
 gangDonateNum_ = value;
 }

public const int builtAttrFieldNumber = 2;
 private pbc::PopsicleList<GangAttr> builtAttr_ = new pbc::PopsicleList<GangAttr>();
 public scg::IList<GangAttr> builtAttrList {
 get { return pbc::Lists.AsReadOnly(builtAttr_); }
 }
 
 public int builtAttrCount {
 get { return builtAttr_.Count; }
 }
 
public GangAttr GetBuiltAttr(int index) {
 return builtAttr_[index];
 }
 public void AddBuiltAttr(GangAttr value) {
 builtAttr_.Add(value);
 }

public const int practiceFieldNumber = 3;
 private pbc::PopsicleList<GangAttr> practice_ = new pbc::PopsicleList<GangAttr>();
 public scg::IList<GangAttr> practiceList {
 get { return pbc::Lists.AsReadOnly(practice_); }
 }
 
 public int practiceCount {
 get { return practice_.Count; }
 }
 
public GangAttr GetPractice(int index) {
 return practice_[index];
 }
 public void AddPractice(GangAttr value) {
 practice_.Add(value);
 }

public const int buyUniqueInfoFieldNumber = 4;
 private pbc::PopsicleList<GangAttr> buyUniqueInfo_ = new pbc::PopsicleList<GangAttr>();
 public scg::IList<GangAttr> buyUniqueInfoList {
 get { return pbc::Lists.AsReadOnly(buyUniqueInfo_); }
 }
 
 public int buyUniqueInfoCount {
 get { return buyUniqueInfo_.Count; }
 }
 
public GangAttr GetBuyUniqueInfo(int index) {
 return buyUniqueInfo_[index];
 }
 public void AddBuyUniqueInfo(GangAttr value) {
 buyUniqueInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGangDonateNum) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GangDonateNum);
}
{
foreach (GangAttr element in builtAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (GangAttr element in practiceList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (GangAttr element in buyUniqueInfoList) {
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
  
if (HasGangDonateNum) {
output.WriteInt32(1, GangDonateNum);
}

do{
foreach (GangAttr element in builtAttrList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (GangAttr element in practiceList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (GangAttr element in buyUniqueInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BuildingInfo _inst = (BuildingInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GangDonateNum = input.ReadInt32();
break;
}
    case  18: {
GangAttr subBuilder =  new GangAttr();
input.ReadMessage(subBuilder);
_inst.AddBuiltAttr(subBuilder);
break;
}
    case  26: {
GangAttr subBuilder =  new GangAttr();
input.ReadMessage(subBuilder);
_inst.AddPractice(subBuilder);
break;
}
    case  34: {
GangAttr subBuilder =  new GangAttr();
input.ReadMessage(subBuilder);
_inst.AddBuyUniqueInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GangAttr element in builtAttrList) {
if (!element.IsInitialized()) return false;
}
foreach (GangAttr element in practiceList) {
if (!element.IsInitialized()) return false;
}
foreach (GangAttr element in buyUniqueInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CGBeBeInvitedToGang : PacketDistributed
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

public const int gangIdFieldNumber = 2;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
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
 if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, GangId);
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
 
if (HasGangId) {
output.WriteInt64(2, GangId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBeBeInvitedToGang _inst = (CGBeBeInvitedToGang) _base;
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
   case  16: {
 _inst.GangId = input.ReadInt64();
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
public class CGCreateGang : PacketDistributed
{

public const int requestTypeFieldNumber = 1;
 private bool hasRequestType;
 private Int32 requestType_ = 0;
 public bool HasRequestType {
 get { return hasRequestType; }
 }
 public Int32 RequestType {
 get { return requestType_; }
 set { SetRequestType(value); }
 }
 public void SetRequestType(Int32 value) { 
 hasRequestType = true;
 requestType_ = value;
 }

public const int gangNameFieldNumber = 2;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

public const int gangFontFieldNumber = 3;
 private bool hasGangFont;
 private string gangFont_ = "";
 public bool HasGangFont {
 get { return hasGangFont; }
 }
 public string GangFont {
 get { return gangFont_; }
 set { SetGangFont(value); }
 }
 public void SetGangFont(string value) { 
 hasGangFont = true;
 gangFont_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRequestType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RequestType);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(2, GangName);
}
 if (HasGangFont) {
size += pb::CodedOutputStream.ComputeStringSize(3, GangFont);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRequestType) {
output.WriteInt32(1, RequestType);
}
 
if (HasGangName) {
output.WriteString(2, GangName);
}
 
if (HasGangFont) {
output.WriteString(3, GangFont);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCreateGang _inst = (CGCreateGang) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RequestType = input.ReadInt32();
break;
}
   case  18: {
 _inst.GangName = input.ReadString();
break;
}
   case  26: {
 _inst.GangFont = input.ReadString();
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
public class CGEnterGang : PacketDistributed
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
 CGEnterGang _inst = (CGEnterGang) _base;
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
public class CGGangBuy : PacketDistributed
{

public const int requestFieldNumber = 1;
 private bool hasRequest;
 private Int32 request_ = 0;
 public bool HasRequest {
 get { return hasRequest; }
 }
 public Int32 Request {
 get { return request_; }
 set { SetRequest(value); }
 }
 public void SetRequest(Int32 value) { 
 hasRequest = true;
 request_ = value;
 }

public const int buyIdFieldNumber = 2;
 private bool hasBuyId;
 private Int32 buyId_ = 0;
 public bool HasBuyId {
 get { return hasBuyId; }
 }
 public Int32 BuyId {
 get { return buyId_; }
 set { SetBuyId(value); }
 }
 public void SetBuyId(Int32 value) { 
 hasBuyId = true;
 buyId_ = value;
 }

public const int buyNumFieldNumber = 3;
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
  if (HasRequest) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Request);
}
 if (HasBuyId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BuyId);
}
 if (HasBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BuyNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRequest) {
output.WriteInt32(1, Request);
}
 
if (HasBuyId) {
output.WriteInt32(2, BuyId);
}
 
if (HasBuyNum) {
output.WriteInt32(3, BuyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGangBuy _inst = (CGGangBuy) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Request = input.ReadInt32();
break;
}
   case  16: {
 _inst.BuyId = input.ReadInt32();
break;
}
   case  24: {
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
public class CGGangChangeName : PacketDistributed
{

public const int gangIdFieldNumber = 1;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
 }

public const int gangTotemFieldNumber = 2;
 private bool hasGangTotem;
 private string gangTotem_ = "";
 public bool HasGangTotem {
 get { return hasGangTotem; }
 }
 public string GangTotem {
 get { return gangTotem_; }
 set { SetGangTotem(value); }
 }
 public void SetGangTotem(string value) { 
 hasGangTotem = true;
 gangTotem_ = value;
 }

public const int gangNameFieldNumber = 3;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, GangId);
}
 if (HasGangTotem) {
size += pb::CodedOutputStream.ComputeStringSize(2, GangTotem);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(3, GangName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGangId) {
output.WriteInt64(1, GangId);
}
 
if (HasGangTotem) {
output.WriteString(2, GangTotem);
}
 
if (HasGangName) {
output.WriteString(3, GangName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGangChangeName _inst = (CGGangChangeName) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  18: {
 _inst.GangTotem = input.ReadString();
break;
}
   case  26: {
 _inst.GangName = input.ReadString();
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
public class CGGangFight : PacketDistributed
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

public const int mapIdFieldNumber = 2;
 private bool hasMapId;
 private Int32 mapId_ = 0;
 public bool HasMapId {
 get { return hasMapId; }
 }
 public Int32 MapId {
 get { return mapId_; }
 set { SetMapId(value); }
 }
 public void SetMapId(Int32 value) { 
 hasMapId = true;
 mapId_ = value;
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
 if (HasMapId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MapId);
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
 
if (HasMapId) {
output.WriteInt32(2, MapId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGangFight _inst = (CGGangFight) _base;
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
 _inst.MapId = input.ReadInt32();
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
public class CGGangOperate : PacketDistributed
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

public const int gangIdFieldNumber = 2;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
 }

public const int bulletinFieldNumber = 3;
 private bool hasBulletin;
 private string bulletin_ = "";
 public bool HasBulletin {
 get { return hasBulletin; }
 }
 public string Bulletin {
 get { return bulletin_; }
 set { SetBulletin(value); }
 }
 public void SetBulletin(string value) { 
 hasBulletin = true;
 bulletin_ = value;
 }

public const int bePlayerIdFieldNumber = 4;
 private bool hasBePlayerId;
 private Int64 bePlayerId_ = 0;
 public bool HasBePlayerId {
 get { return hasBePlayerId; }
 }
 public Int64 BePlayerId {
 get { return bePlayerId_; }
 set { SetBePlayerId(value); }
 }
 public void SetBePlayerId(Int64 value) { 
 hasBePlayerId = true;
 bePlayerId_ = value;
 }

public const int bePlayerTypeFieldNumber = 5;
 private bool hasBePlayerType;
 private Int32 bePlayerType_ = 0;
 public bool HasBePlayerType {
 get { return hasBePlayerType; }
 }
 public Int32 BePlayerType {
 get { return bePlayerType_; }
 set { SetBePlayerType(value); }
 }
 public void SetBePlayerType(Int32 value) { 
 hasBePlayerType = true;
 bePlayerType_ = value;
 }

public const int gangIdListFieldNumber = 6;
 private pbc::PopsicleList<Int64> gangIdList_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> gangIdListList {
 get { return pbc::Lists.AsReadOnly(gangIdList_); }
 }
 
 public int gangIdListCount {
 get { return gangIdList_.Count; }
 }
 
public Int64 GetGangIdList(int index) {
 return gangIdList_[index];
 }
 public void AddGangIdList(Int64 value) {
 gangIdList_.Add(value);
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
 if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, GangId);
}
 if (HasBulletin) {
size += pb::CodedOutputStream.ComputeStringSize(3, Bulletin);
}
 if (HasBePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(4, BePlayerId);
}
 if (HasBePlayerType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, BePlayerType);
}
{
int dataSize = 0;
foreach (Int64 element in gangIdListList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * gangIdList_.Count;
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
 
if (HasGangId) {
output.WriteInt64(2, GangId);
}
 
if (HasBulletin) {
output.WriteString(3, Bulletin);
}
 
if (HasBePlayerId) {
output.WriteInt64(4, BePlayerId);
}
 
if (HasBePlayerType) {
output.WriteInt32(5, BePlayerType);
}
{
if (gangIdList_.Count > 0) {
foreach (Int64 element in gangIdListList) {
output.WriteInt64(6,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGangOperate _inst = (CGGangOperate) _base;
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
   case  16: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  26: {
 _inst.Bulletin = input.ReadString();
break;
}
   case  32: {
 _inst.BePlayerId = input.ReadInt64();
break;
}
   case  40: {
 _inst.BePlayerType = input.ReadInt32();
break;
}
   case  48: {
 _inst.AddGangIdList(input.ReadInt64());
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
public class CGGetGangList : PacketDistributed
{

public const int listTypeFieldNumber = 1;
 private bool hasListType;
 private Int32 listType_ = 0;
 public bool HasListType {
 get { return hasListType; }
 }
 public Int32 ListType {
 get { return listType_; }
 set { SetListType(value); }
 }
 public void SetListType(Int32 value) { 
 hasListType = true;
 listType_ = value;
 }

public const int gangNameFieldNumber = 3;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasListType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ListType);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(3, GangName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasListType) {
output.WriteInt32(1, ListType);
}
 
if (HasGangName) {
output.WriteString(3, GangName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetGangList _inst = (CGGetGangList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ListType = input.ReadInt32();
break;
}
   case  26: {
 _inst.GangName = input.ReadString();
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
public class CGHasGang : PacketDistributed
{

public const int playerIdFieldNumber = 1;
 private bool hasPlayerId;
 private Int32 playerId_ = 0;
 public bool HasPlayerId {
 get { return hasPlayerId; }
 }
 public Int32 PlayerId {
 get { return playerId_; }
 set { SetPlayerId(value); }
 }
 public void SetPlayerId(Int32 value) { 
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
size += pb::CodedOutputStream.ComputeInt32Size(1, PlayerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerId) {
output.WriteInt32(1, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGHasGang _inst = (CGHasGang) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerId = input.ReadInt32();
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
public class CGInviteToGang : PacketDistributed
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
 CGInviteToGang _inst = (CGInviteToGang) _base;
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
public class CGMuteGangMember : PacketDistributed
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

public const int plyerIdFieldNumber = 2;
 private bool hasPlyerId;
 private Int64 plyerId_ = 0;
 public bool HasPlyerId {
 get { return hasPlyerId; }
 }
 public Int64 PlyerId {
 get { return plyerId_; }
 set { SetPlyerId(value); }
 }
 public void SetPlyerId(Int64 value) { 
 hasPlyerId = true;
 plyerId_ = value;
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
 if (HasPlyerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PlyerId);
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
 
if (HasPlyerId) {
output.WriteInt64(2, PlyerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGMuteGangMember _inst = (CGMuteGangMember) _base;
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
 _inst.PlyerId = input.ReadInt64();
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
public class GCApplyNotice : PacketDistributed
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
 GCApplyNotice _inst = (GCApplyNotice) _base;
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
public class GCBeInvitedToGang : PacketDistributed
{

public const int gangIdFieldNumber = 1;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
 }

public const int gangNameFieldNumber = 2;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, GangId);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(2, GangName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGangId) {
output.WriteInt64(1, GangId);
}
 
if (HasGangName) {
output.WriteString(2, GangName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBeInvitedToGang _inst = (GCBeInvitedToGang) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  18: {
 _inst.GangName = input.ReadString();
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
public class GCCreateGang : PacketDistributed
{

public const int responseTypeFieldNumber = 1;
 private bool hasResponseType;
 private Int32 responseType_ = 0;
 public bool HasResponseType {
 get { return hasResponseType; }
 }
 public Int32 ResponseType {
 get { return responseType_; }
 set { SetResponseType(value); }
 }
 public void SetResponseType(Int32 value) { 
 hasResponseType = true;
 responseType_ = value;
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

public const int gangInfoFieldNumber = 3;
 private bool hasGangInfo;
 private GangMainInfo gangInfo_ =  new GangMainInfo();
 public bool HasGangInfo {
 get { return hasGangInfo; }
 }
 public GangMainInfo GangInfo {
 get { return gangInfo_; }
 set { SetGangInfo(value); }
 }
 public void SetGangInfo(GangMainInfo value) { 
 hasGangInfo = true;
 gangInfo_ = value;
 }

public const int memberInfoFieldNumber = 4;
 private pbc::PopsicleList<GangMemberInfo> memberInfo_ = new pbc::PopsicleList<GangMemberInfo>();
 public scg::IList<GangMemberInfo> memberInfoList {
 get { return pbc::Lists.AsReadOnly(memberInfo_); }
 }
 
 public int memberInfoCount {
 get { return memberInfo_.Count; }
 }
 
public GangMemberInfo GetMemberInfo(int index) {
 return memberInfo_[index];
 }
 public void AddMemberInfo(GangMemberInfo value) {
 memberInfo_.Add(value);
 }

public const int buildInfoFieldNumber = 5;
 private bool hasBuildInfo;
 private BuildingInfo buildInfo_ =  new BuildingInfo();
 public bool HasBuildInfo {
 get { return hasBuildInfo; }
 }
 public BuildingInfo BuildInfo {
 get { return buildInfo_; }
 set { SetBuildInfo(value); }
 }
 public void SetBuildInfo(BuildingInfo value) { 
 hasBuildInfo = true;
 buildInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResponseType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ResponseType);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
int subsize = GangInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (GangMemberInfo element in memberInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = BuildInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasResponseType) {
output.WriteInt32(1, ResponseType);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)GangInfo.SerializedSize());
GangInfo.WriteTo(output);

}

do{
foreach (GangMemberInfo element in memberInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)BuildInfo.SerializedSize());
BuildInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreateGang _inst = (GCCreateGang) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ResponseType = input.ReadInt32();
break;
}
   case  16: {
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
GangMainInfo subBuilder =  new GangMainInfo();
 input.ReadMessage(subBuilder);
_inst.GangInfo = subBuilder;
break;
}
    case  34: {
GangMemberInfo subBuilder =  new GangMemberInfo();
input.ReadMessage(subBuilder);
_inst.AddMemberInfo(subBuilder);
break;
}
    case  42: {
BuildingInfo subBuilder =  new BuildingInfo();
 input.ReadMessage(subBuilder);
_inst.BuildInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasGangInfo) {
if (!GangInfo.IsInitialized()) return false;
}
foreach (GangMemberInfo element in memberInfoList) {
if (!element.IsInitialized()) return false;
}
  if (HasBuildInfo) {
if (!BuildInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCEnterGang : PacketDistributed
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
 GCEnterGang _inst = (GCEnterGang) _base;
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
public class GCGangActiveOpen : PacketDistributed
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

public const int languageIdFieldNumber = 2;
 private bool hasLanguageId;
 private Int32 languageId_ = 0;
 public bool HasLanguageId {
 get { return hasLanguageId; }
 }
 public Int32 LanguageId {
 get { return languageId_; }
 set { SetLanguageId(value); }
 }
 public void SetLanguageId(Int32 value) { 
 hasLanguageId = true;
 languageId_ = value;
 }

public const int paramFieldNumber = 3;
 private pbc::PopsicleList<string> param_ = new pbc::PopsicleList<string>();
 public scg::IList<string> paramList {
 get { return pbc::Lists.AsReadOnly(param_); }
 }
 
 public int paramCount {
 get { return param_.Count; }
 }
 
public string GetParam(int index) {
 return param_[index];
 }
 public void AddParam(string value) {
 param_.Add(value);
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
 if (HasLanguageId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LanguageId);
}
{
int dataSize = 0;
foreach (string element in paramList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * param_.Count;
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
 
if (HasLanguageId) {
output.WriteInt32(2, LanguageId);
}
{
if (param_.Count > 0) {
foreach (string element in paramList) {
output.WriteString(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGangActiveOpen _inst = (GCGangActiveOpen) _base;
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
 _inst.LanguageId = input.ReadInt32();
break;
}
   case  26: {
 _inst.AddParam(input.ReadString());
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
public class GCGangBuy : PacketDistributed
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

public const int responseFieldNumber = 2;
 private bool hasResponse;
 private Int32 response_ = 0;
 public bool HasResponse {
 get { return hasResponse; }
 }
 public Int32 Response {
 get { return response_; }
 set { SetResponse(value); }
 }
 public void SetResponse(Int32 value) { 
 hasResponse = true;
 response_ = value;
 }

public const int gangInfoFieldNumber = 3;
 private bool hasGangInfo;
 private GangMainInfo gangInfo_ =  new GangMainInfo();
 public bool HasGangInfo {
 get { return hasGangInfo; }
 }
 public GangMainInfo GangInfo {
 get { return gangInfo_; }
 set { SetGangInfo(value); }
 }
 public void SetGangInfo(GangMainInfo value) { 
 hasGangInfo = true;
 gangInfo_ = value;
 }

public const int buildInfoFieldNumber = 4;
 private bool hasBuildInfo;
 private BuildingInfo buildInfo_ =  new BuildingInfo();
 public bool HasBuildInfo {
 get { return hasBuildInfo; }
 }
 public BuildingInfo BuildInfo {
 get { return buildInfo_; }
 set { SetBuildInfo(value); }
 }
 public void SetBuildInfo(BuildingInfo value) { 
 hasBuildInfo = true;
 buildInfo_ = value;
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
 if (HasResponse) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Response);
}
{
int subsize = GangInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = BuildInfo.SerializedSize();	
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
 
if (HasResponse) {
output.WriteInt32(2, Response);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)GangInfo.SerializedSize());
GangInfo.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)BuildInfo.SerializedSize());
BuildInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGangBuy _inst = (GCGangBuy) _base;
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
 _inst.Response = input.ReadInt32();
break;
}
    case  26: {
GangMainInfo subBuilder =  new GangMainInfo();
 input.ReadMessage(subBuilder);
_inst.GangInfo = subBuilder;
break;
}
    case  34: {
BuildingInfo subBuilder =  new BuildingInfo();
 input.ReadMessage(subBuilder);
_inst.BuildInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasGangInfo) {
if (!GangInfo.IsInitialized()) return false;
}
  if (HasBuildInfo) {
if (!BuildInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGangChangeName : PacketDistributed
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
 GCGangChangeName _inst = (GCGangChangeName) _base;
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
public class GCGangFight : PacketDistributed
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

public const int lastTimeFieldNumber = 4;
 private bool hasLastTime;
 private Int32 lastTime_ = 0;
 public bool HasLastTime {
 get { return hasLastTime; }
 }
 public Int32 LastTime {
 get { return lastTime_; }
 set { SetLastTime(value); }
 }
 public void SetLastTime(Int32 value) { 
 hasLastTime = true;
 lastTime_ = value;
 }

public const int puidFieldNumber = 5;
 private bool hasPuid;
 private Int64 puid_ = 0;
 public bool HasPuid {
 get { return hasPuid; }
 }
 public Int64 Puid {
 get { return puid_; }
 set { SetPuid(value); }
 }
 public void SetPuid(Int64 value) { 
 hasPuid = true;
 puid_ = value;
 }

public const int flaguIdFieldNumber = 6;
 private bool hasFlaguId;
 private Int64 flaguId_ = 0;
 public bool HasFlaguId {
 get { return hasFlaguId; }
 }
 public Int64 FlaguId {
 get { return flaguId_; }
 set { SetFlaguId(value); }
 }
 public void SetFlaguId(Int64 value) { 
 hasFlaguId = true;
 flaguId_ = value;
 }

public const int gangInfo4MapFieldNumber = 7;
 private pbc::PopsicleList<GangInfo4Map> gangInfo4Map_ = new pbc::PopsicleList<GangInfo4Map>();
 public scg::IList<GangInfo4Map> gangInfo4MapList {
 get { return pbc::Lists.AsReadOnly(gangInfo4Map_); }
 }
 
 public int gangInfo4MapCount {
 get { return gangInfo4Map_.Count; }
 }
 
public GangInfo4Map GetGangInfo4Map(int index) {
 return gangInfo4Map_[index];
 }
 public void AddGangInfo4Map(GangInfo4Map value) {
 gangInfo4Map_.Add(value);
 }

public const int pointMapFieldNumber = 8;
 private pbc::PopsicleList<EntryStringInt> pointMap_ = new pbc::PopsicleList<EntryStringInt>();
 public scg::IList<EntryStringInt> pointMapList {
 get { return pbc::Lists.AsReadOnly(pointMap_); }
 }
 
 public int pointMapCount {
 get { return pointMap_.Count; }
 }
 
public EntryStringInt GetPointMap(int index) {
 return pointMap_[index];
 }
 public void AddPointMap(EntryStringInt value) {
 pointMap_.Add(value);
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Flag);
}
 if (HasLastTime) {
size += pb::CodedOutputStream.ComputeInt32Size(4, LastTime);
}
 if (HasPuid) {
size += pb::CodedOutputStream.ComputeInt64Size(5, Puid);
}
 if (HasFlaguId) {
size += pb::CodedOutputStream.ComputeInt64Size(6, FlaguId);
}
{
foreach (GangInfo4Map element in gangInfo4MapList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (EntryStringInt element in pointMapList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
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
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 
if (HasFlag) {
output.WriteInt32(3, Flag);
}
 
if (HasLastTime) {
output.WriteInt32(4, LastTime);
}
 
if (HasPuid) {
output.WriteInt64(5, Puid);
}
 
if (HasFlaguId) {
output.WriteInt64(6, FlaguId);
}

do{
foreach (GangInfo4Map element in gangInfo4MapList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (EntryStringInt element in pointMapList) {
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGangFight _inst = (GCGangFight) _base;
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
 _inst.Result = input.ReadInt32();
break;
}
   case  24: {
 _inst.Flag = input.ReadInt32();
break;
}
   case  32: {
 _inst.LastTime = input.ReadInt32();
break;
}
   case  40: {
 _inst.Puid = input.ReadInt64();
break;
}
   case  48: {
 _inst.FlaguId = input.ReadInt64();
break;
}
    case  58: {
GangInfo4Map subBuilder =  new GangInfo4Map();
input.ReadMessage(subBuilder);
_inst.AddGangInfo4Map(subBuilder);
break;
}
    case  66: {
EntryStringInt subBuilder =  new EntryStringInt();
input.ReadMessage(subBuilder);
_inst.AddPointMap(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GangInfo4Map element in gangInfo4MapList) {
if (!element.IsInitialized()) return false;
}
foreach (EntryStringInt element in pointMapList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGangOperate : PacketDistributed
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

public const int gangInfoFieldNumber = 3;
 private bool hasGangInfo;
 private GangMainInfo gangInfo_ =  new GangMainInfo();
 public bool HasGangInfo {
 get { return hasGangInfo; }
 }
 public GangMainInfo GangInfo {
 get { return gangInfo_; }
 set { SetGangInfo(value); }
 }
 public void SetGangInfo(GangMainInfo value) { 
 hasGangInfo = true;
 gangInfo_ = value;
 }

public const int memberInfoFieldNumber = 4;
 private pbc::PopsicleList<GangMemberInfo> memberInfo_ = new pbc::PopsicleList<GangMemberInfo>();
 public scg::IList<GangMemberInfo> memberInfoList {
 get { return pbc::Lists.AsReadOnly(memberInfo_); }
 }
 
 public int memberInfoCount {
 get { return memberInfo_.Count; }
 }
 
public GangMemberInfo GetMemberInfo(int index) {
 return memberInfo_[index];
 }
 public void AddMemberInfo(GangMemberInfo value) {
 memberInfo_.Add(value);
 }

public const int quitMemberIdFieldNumber = 5;
 private bool hasQuitMemberId;
 private Int64 quitMemberId_ = 0;
 public bool HasQuitMemberId {
 get { return hasQuitMemberId; }
 }
 public Int64 QuitMemberId {
 get { return quitMemberId_; }
 set { SetQuitMemberId(value); }
 }
 public void SetQuitMemberId(Int64 value) { 
 hasQuitMemberId = true;
 quitMemberId_ = value;
 }

public const int joinGangIdFieldNumber = 6;
 private bool hasJoinGangId;
 private Int64 joinGangId_ = 0;
 public bool HasJoinGangId {
 get { return hasJoinGangId; }
 }
 public Int64 JoinGangId {
 get { return joinGangId_; }
 set { SetJoinGangId(value); }
 }
 public void SetJoinGangId(Int64 value) { 
 hasJoinGangId = true;
 joinGangId_ = value;
 }

public const int joinGangIdListFieldNumber = 7;
 private pbc::PopsicleList<Int64> joinGangIdList_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> joinGangIdListList {
 get { return pbc::Lists.AsReadOnly(joinGangIdList_); }
 }
 
 public int joinGangIdListCount {
 get { return joinGangIdList_.Count; }
 }
 
public Int64 GetJoinGangIdList(int index) {
 return joinGangIdList_[index];
 }
 public void AddJoinGangIdList(Int64 value) {
 joinGangIdList_.Add(value);
 }

public const int kickTimeFieldNumber = 8;
 private bool hasKickTime;
 private Int64 kickTime_ = 0;
 public bool HasKickTime {
 get { return hasKickTime; }
 }
 public Int64 KickTime {
 get { return kickTime_; }
 set { SetKickTime(value); }
 }
 public void SetKickTime(Int64 value) { 
 hasKickTime = true;
 kickTime_ = value;
 }

public const int isKickMasterFieldNumber = 9;
 private bool hasIsKickMaster;
 private Int32 isKickMaster_ = 0;
 public bool HasIsKickMaster {
 get { return hasIsKickMaster; }
 }
 public Int32 IsKickMaster {
 get { return isKickMaster_; }
 set { SetIsKickMaster(value); }
 }
 public void SetIsKickMaster(Int32 value) { 
 hasIsKickMaster = true;
 isKickMaster_ = value;
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
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
{
int subsize = GangInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (GangMemberInfo element in memberInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasQuitMemberId) {
size += pb::CodedOutputStream.ComputeInt64Size(5, QuitMemberId);
}
 if (HasJoinGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(6, JoinGangId);
}
{
int dataSize = 0;
foreach (Int64 element in joinGangIdListList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * joinGangIdList_.Count;
}
 if (HasKickTime) {
size += pb::CodedOutputStream.ComputeInt64Size(8, KickTime);
}
 if (HasIsKickMaster) {
size += pb::CodedOutputStream.ComputeInt32Size(9, IsKickMaster);
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
 
if (HasResult) {
output.WriteInt32(2, Result);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)GangInfo.SerializedSize());
GangInfo.WriteTo(output);

}

do{
foreach (GangMemberInfo element in memberInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasQuitMemberId) {
output.WriteInt64(5, QuitMemberId);
}
 
if (HasJoinGangId) {
output.WriteInt64(6, JoinGangId);
}
{
if (joinGangIdList_.Count > 0) {
foreach (Int64 element in joinGangIdListList) {
output.WriteInt64(7,element);
}
}

}
 
if (HasKickTime) {
output.WriteInt64(8, KickTime);
}
 
if (HasIsKickMaster) {
output.WriteInt32(9, IsKickMaster);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGangOperate _inst = (GCGangOperate) _base;
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
   case  16: {
 _inst.Result = input.ReadInt32();
break;
}
    case  26: {
GangMainInfo subBuilder =  new GangMainInfo();
 input.ReadMessage(subBuilder);
_inst.GangInfo = subBuilder;
break;
}
    case  34: {
GangMemberInfo subBuilder =  new GangMemberInfo();
input.ReadMessage(subBuilder);
_inst.AddMemberInfo(subBuilder);
break;
}
   case  40: {
 _inst.QuitMemberId = input.ReadInt64();
break;
}
   case  48: {
 _inst.JoinGangId = input.ReadInt64();
break;
}
   case  56: {
 _inst.AddJoinGangIdList(input.ReadInt64());
break;
}
   case  64: {
 _inst.KickTime = input.ReadInt64();
break;
}
   case  72: {
 _inst.IsKickMaster = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasGangInfo) {
if (!GangInfo.IsInitialized()) return false;
}
foreach (GangMemberInfo element in memberInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGangRobberNum : PacketDistributed
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

public const int numTotalFieldNumber = 2;
 private bool hasNumTotal;
 private Int32 numTotal_ = 0;
 public bool HasNumTotal {
 get { return hasNumTotal; }
 }
 public Int32 NumTotal {
 get { return numTotal_; }
 set { SetNumTotal(value); }
 }
 public void SetNumTotal(Int32 value) { 
 hasNumTotal = true;
 numTotal_ = value;
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
 if (HasNumTotal) {
size += pb::CodedOutputStream.ComputeInt32Size(2, NumTotal);
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
 
if (HasNumTotal) {
output.WriteInt32(2, NumTotal);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGangRobberNum _inst = (GCGangRobberNum) _base;
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
   case  16: {
 _inst.NumTotal = input.ReadInt32();
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
public class GCGetGangList : PacketDistributed
{

public const int listTypeFieldNumber = 1;
 private bool hasListType;
 private Int32 listType_ = 0;
 public bool HasListType {
 get { return hasListType; }
 }
 public Int32 ListType {
 get { return listType_; }
 set { SetListType(value); }
 }
 public void SetListType(Int32 value) { 
 hasListType = true;
 listType_ = value;
 }

public const int gangInfoFieldNumber = 4;
 private pbc::PopsicleList<GangMainInfo> gangInfo_ = new pbc::PopsicleList<GangMainInfo>();
 public scg::IList<GangMainInfo> gangInfoList {
 get { return pbc::Lists.AsReadOnly(gangInfo_); }
 }
 
 public int gangInfoCount {
 get { return gangInfo_.Count; }
 }
 
public GangMainInfo GetGangInfo(int index) {
 return gangInfo_[index];
 }
 public void AddGangInfo(GangMainInfo value) {
 gangInfo_.Add(value);
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

public const int joinGangIdListFieldNumber = 6;
 private pbc::PopsicleList<Int64> joinGangIdList_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> joinGangIdListList {
 get { return pbc::Lists.AsReadOnly(joinGangIdList_); }
 }
 
 public int joinGangIdListCount {
 get { return joinGangIdList_.Count; }
 }
 
public Int64 GetJoinGangIdList(int index) {
 return joinGangIdList_[index];
 }
 public void AddJoinGangIdList(Int64 value) {
 joinGangIdList_.Add(value);
 }

public const int lastQuitTimeFieldNumber = 7;
 private bool hasLastQuitTime;
 private Int64 lastQuitTime_ = 0;
 public bool HasLastQuitTime {
 get { return hasLastQuitTime; }
 }
 public Int64 LastQuitTime {
 get { return lastQuitTime_; }
 set { SetLastQuitTime(value); }
 }
 public void SetLastQuitTime(Int64 value) { 
 hasLastQuitTime = true;
 lastQuitTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasListType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ListType);
}
{
foreach (GangMainInfo element in gangInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Result);
}
{
int dataSize = 0;
foreach (Int64 element in joinGangIdListList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * joinGangIdList_.Count;
}
 if (HasLastQuitTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, LastQuitTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasListType) {
output.WriteInt32(1, ListType);
}

do{
foreach (GangMainInfo element in gangInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasResult) {
output.WriteInt32(5, Result);
}
{
if (joinGangIdList_.Count > 0) {
foreach (Int64 element in joinGangIdListList) {
output.WriteInt64(6,element);
}
}

}
 
if (HasLastQuitTime) {
output.WriteInt64(7, LastQuitTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetGangList _inst = (GCGetGangList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ListType = input.ReadInt32();
break;
}
    case  34: {
GangMainInfo subBuilder =  new GangMainInfo();
input.ReadMessage(subBuilder);
_inst.AddGangInfo(subBuilder);
break;
}
   case  40: {
 _inst.Result = input.ReadInt32();
break;
}
   case  48: {
 _inst.AddJoinGangIdList(input.ReadInt64());
break;
}
   case  56: {
 _inst.LastQuitTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GangMainInfo element in gangInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCHasGang : PacketDistributed
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
 GCHasGang _inst = (GCHasGang) _base;
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
public class GCMuteGangList : PacketDistributed
{

public const int muteFieldNumber = 1;
 private pbc::PopsicleList<Int64> mute_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> muteList {
 get { return pbc::Lists.AsReadOnly(mute_); }
 }
 
 public int muteCount {
 get { return mute_.Count; }
 }
 
public Int64 GetMute(int index) {
 return mute_[index];
 }
 public void AddMute(Int64 value) {
 mute_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in muteList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * mute_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (mute_.Count > 0) {
foreach (Int64 element in muteList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMuteGangList _inst = (GCMuteGangList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddMute(input.ReadInt64());
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
public class GCMuteGangMember : PacketDistributed
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

public const int playerIdFieldNumber = 3;
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
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, PlayerId);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasPlayerId) {
output.WriteInt64(3, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMuteGangMember _inst = (GCMuteGangMember) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
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
public class GangAttr : PacketDistributed
{

public const int attrKeyFieldNumber = 1;
 private bool hasAttrKey;
 private Int32 attrKey_ = 0;
 public bool HasAttrKey {
 get { return hasAttrKey; }
 }
 public Int32 AttrKey {
 get { return attrKey_; }
 set { SetAttrKey(value); }
 }
 public void SetAttrKey(Int32 value) { 
 hasAttrKey = true;
 attrKey_ = value;
 }

public const int arrtValueFieldNumber = 2;
 private bool hasArrtValue;
 private Int32 arrtValue_ = 0;
 public bool HasArrtValue {
 get { return hasArrtValue; }
 }
 public Int32 ArrtValue {
 get { return arrtValue_; }
 set { SetArrtValue(value); }
 }
 public void SetArrtValue(Int32 value) { 
 hasArrtValue = true;
 arrtValue_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAttrKey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AttrKey);
}
 if (HasArrtValue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ArrtValue);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAttrKey) {
output.WriteInt32(1, AttrKey);
}
 
if (HasArrtValue) {
output.WriteInt32(2, ArrtValue);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GangAttr _inst = (GangAttr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AttrKey = input.ReadInt32();
break;
}
   case  16: {
 _inst.ArrtValue = input.ReadInt32();
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
public class GangInfo4Map : PacketDistributed
{

public const int mapIdFieldNumber = 1;
 private bool hasMapId;
 private Int32 mapId_ = 0;
 public bool HasMapId {
 get { return hasMapId; }
 }
 public Int32 MapId {
 get { return mapId_; }
 set { SetMapId(value); }
 }
 public void SetMapId(Int32 value) { 
 hasMapId = true;
 mapId_ = value;
 }

public const int holdGangInfoFieldNumber = 2;
 private bool hasHoldGangInfo;
 private GangMainInfo holdGangInfo_ =  new GangMainInfo();
 public bool HasHoldGangInfo {
 get { return hasHoldGangInfo; }
 }
 public GangMainInfo HoldGangInfo {
 get { return holdGangInfo_; }
 set { SetHoldGangInfo(value); }
 }
 public void SetHoldGangInfo(GangMainInfo value) { 
 hasHoldGangInfo = true;
 holdGangInfo_ = value;
 }

public const int applyGangInfoFieldNumber = 3;
 private pbc::PopsicleList<GangMainInfo> applyGangInfo_ = new pbc::PopsicleList<GangMainInfo>();
 public scg::IList<GangMainInfo> applyGangInfoList {
 get { return pbc::Lists.AsReadOnly(applyGangInfo_); }
 }
 
 public int applyGangInfoCount {
 get { return applyGangInfo_.Count; }
 }
 
public GangMainInfo GetApplyGangInfo(int index) {
 return applyGangInfo_[index];
 }
 public void AddApplyGangInfo(GangMainInfo value) {
 applyGangInfo_.Add(value);
 }

public const int applyStateFieldNumber = 4;
 private bool hasApplyState;
 private Int32 applyState_ = 0;
 public bool HasApplyState {
 get { return hasApplyState; }
 }
 public Int32 ApplyState {
 get { return applyState_; }
 set { SetApplyState(value); }
 }
 public void SetApplyState(Int32 value) { 
 hasApplyState = true;
 applyState_ = value;
 }

public const int enterFightStateFieldNumber = 5;
 private bool hasEnterFightState;
 private Int32 enterFightState_ = 0;
 public bool HasEnterFightState {
 get { return hasEnterFightState; }
 }
 public Int32 EnterFightState {
 get { return enterFightState_; }
 set { SetEnterFightState(value); }
 }
 public void SetEnterFightState(Int32 value) { 
 hasEnterFightState = true;
 enterFightState_ = value;
 }

public const int countOfMapFieldNumber = 6;
 private bool hasCountOfMap;
 private Int32 countOfMap_ = 0;
 public bool HasCountOfMap {
 get { return hasCountOfMap; }
 }
 public Int32 CountOfMap {
 get { return countOfMap_; }
 set { SetCountOfMap(value); }
 }
 public void SetCountOfMap(Int32 value) { 
 hasCountOfMap = true;
 countOfMap_ = value;
 }

public const int firstOfMapFieldNumber = 7;
 private bool hasFirstOfMap;
 private Int32 firstOfMap_ = 0;
 public bool HasFirstOfMap {
 get { return hasFirstOfMap; }
 }
 public Int32 FirstOfMap {
 get { return firstOfMap_; }
 set { SetFirstOfMap(value); }
 }
 public void SetFirstOfMap(Int32 value) { 
 hasFirstOfMap = true;
 firstOfMap_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMapId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MapId);
}
{
int subsize = HoldGangInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
foreach (GangMainInfo element in applyGangInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasApplyState) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ApplyState);
}
 if (HasEnterFightState) {
size += pb::CodedOutputStream.ComputeInt32Size(5, EnterFightState);
}
 if (HasCountOfMap) {
size += pb::CodedOutputStream.ComputeInt32Size(6, CountOfMap);
}
 if (HasFirstOfMap) {
size += pb::CodedOutputStream.ComputeInt32Size(7, FirstOfMap);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMapId) {
output.WriteInt32(1, MapId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)HoldGangInfo.SerializedSize());
HoldGangInfo.WriteTo(output);

}

do{
foreach (GangMainInfo element in applyGangInfoList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasApplyState) {
output.WriteInt32(4, ApplyState);
}
 
if (HasEnterFightState) {
output.WriteInt32(5, EnterFightState);
}
 
if (HasCountOfMap) {
output.WriteInt32(6, CountOfMap);
}
 
if (HasFirstOfMap) {
output.WriteInt32(7, FirstOfMap);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GangInfo4Map _inst = (GangInfo4Map) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MapId = input.ReadInt32();
break;
}
    case  18: {
GangMainInfo subBuilder =  new GangMainInfo();
 input.ReadMessage(subBuilder);
_inst.HoldGangInfo = subBuilder;
break;
}
    case  26: {
GangMainInfo subBuilder =  new GangMainInfo();
input.ReadMessage(subBuilder);
_inst.AddApplyGangInfo(subBuilder);
break;
}
   case  32: {
 _inst.ApplyState = input.ReadInt32();
break;
}
   case  40: {
 _inst.EnterFightState = input.ReadInt32();
break;
}
   case  48: {
 _inst.CountOfMap = input.ReadInt32();
break;
}
   case  56: {
 _inst.FirstOfMap = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasHoldGangInfo) {
if (!HoldGangInfo.IsInitialized()) return false;
}
foreach (GangMainInfo element in applyGangInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GangMainInfo : PacketDistributed
{

public const int gangIdFieldNumber = 1;
 private bool hasGangId;
 private Int64 gangId_ = 0;
 public bool HasGangId {
 get { return hasGangId; }
 }
 public Int64 GangId {
 get { return gangId_; }
 set { SetGangId(value); }
 }
 public void SetGangId(Int64 value) { 
 hasGangId = true;
 gangId_ = value;
 }

public const int gangNameFieldNumber = 2;
 private bool hasGangName;
 private string gangName_ = "";
 public bool HasGangName {
 get { return hasGangName; }
 }
 public string GangName {
 get { return gangName_; }
 set { SetGangName(value); }
 }
 public void SetGangName(string value) { 
 hasGangName = true;
 gangName_ = value;
 }

public const int gangTotemFieldNumber = 3;
 private bool hasGangTotem;
 private string gangTotem_ = "";
 public bool HasGangTotem {
 get { return hasGangTotem; }
 }
 public string GangTotem {
 get { return gangTotem_; }
 set { SetGangTotem(value); }
 }
 public void SetGangTotem(string value) { 
 hasGangTotem = true;
 gangTotem_ = value;
 }

public const int gangLevelFieldNumber = 4;
 private bool hasGangLevel;
 private Int32 gangLevel_ = 0;
 public bool HasGangLevel {
 get { return hasGangLevel; }
 }
 public Int32 GangLevel {
 get { return gangLevel_; }
 set { SetGangLevel(value); }
 }
 public void SetGangLevel(Int32 value) { 
 hasGangLevel = true;
 gangLevel_ = value;
 }

public const int memberNumFieldNumber = 5;
 private bool hasMemberNum;
 private Int32 memberNum_ = 0;
 public bool HasMemberNum {
 get { return hasMemberNum; }
 }
 public Int32 MemberNum {
 get { return memberNum_; }
 set { SetMemberNum(value); }
 }
 public void SetMemberNum(Int32 value) { 
 hasMemberNum = true;
 memberNum_ = value;
 }

public const int bulletinFieldNumber = 6;
 private bool hasBulletin;
 private string bulletin_ = "";
 public bool HasBulletin {
 get { return hasBulletin; }
 }
 public string Bulletin {
 get { return bulletin_; }
 set { SetBulletin(value); }
 }
 public void SetBulletin(string value) { 
 hasBulletin = true;
 bulletin_ = value;
 }

public const int moneyFieldNumber = 7;
 private bool hasMoney;
 private Int64 money_ = 0;
 public bool HasMoney {
 get { return hasMoney; }
 }
 public Int64 Money {
 get { return money_; }
 set { SetMoney(value); }
 }
 public void SetMoney(Int64 value) { 
 hasMoney = true;
 money_ = value;
 }

public const int powerFieldNumber = 8;
 private bool hasPower;
 private Int64 power_ = 0;
 public bool HasPower {
 get { return hasPower; }
 }
 public Int64 Power {
 get { return power_; }
 set { SetPower(value); }
 }
 public void SetPower(Int64 value) { 
 hasPower = true;
 power_ = value;
 }

public const int masterNameFieldNumber = 9;
 private bool hasMasterName;
 private string masterName_ = "";
 public bool HasMasterName {
 get { return hasMasterName; }
 }
 public string MasterName {
 get { return masterName_; }
 set { SetMasterName(value); }
 }
 public void SetMasterName(string value) { 
 hasMasterName = true;
 masterName_ = value;
 }

public const int isKickMasterFieldNumber = 10;
 private bool hasIsKickMaster;
 private Int32 isKickMaster_ = 0;
 public bool HasIsKickMaster {
 get { return hasIsKickMaster; }
 }
 public Int32 IsKickMaster {
 get { return isKickMaster_; }
 set { SetIsKickMaster(value); }
 }
 public void SetIsKickMaster(Int32 value) { 
 hasIsKickMaster = true;
 isKickMaster_ = value;
 }

public const int kickTimeFieldNumber = 11;
 private bool hasKickTime;
 private Int64 kickTime_ = 0;
 public bool HasKickTime {
 get { return hasKickTime; }
 }
 public Int64 KickTime {
 get { return kickTime_; }
 set { SetKickTime(value); }
 }
 public void SetKickTime(Int64 value) { 
 hasKickTime = true;
 kickTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, GangId);
}
 if (HasGangName) {
size += pb::CodedOutputStream.ComputeStringSize(2, GangName);
}
 if (HasGangTotem) {
size += pb::CodedOutputStream.ComputeStringSize(3, GangTotem);
}
 if (HasGangLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GangLevel);
}
 if (HasMemberNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, MemberNum);
}
 if (HasBulletin) {
size += pb::CodedOutputStream.ComputeStringSize(6, Bulletin);
}
 if (HasMoney) {
size += pb::CodedOutputStream.ComputeInt64Size(7, Money);
}
 if (HasPower) {
size += pb::CodedOutputStream.ComputeInt64Size(8, Power);
}
 if (HasMasterName) {
size += pb::CodedOutputStream.ComputeStringSize(9, MasterName);
}
 if (HasIsKickMaster) {
size += pb::CodedOutputStream.ComputeInt32Size(10, IsKickMaster);
}
 if (HasKickTime) {
size += pb::CodedOutputStream.ComputeInt64Size(11, KickTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGangId) {
output.WriteInt64(1, GangId);
}
 
if (HasGangName) {
output.WriteString(2, GangName);
}
 
if (HasGangTotem) {
output.WriteString(3, GangTotem);
}
 
if (HasGangLevel) {
output.WriteInt32(4, GangLevel);
}
 
if (HasMemberNum) {
output.WriteInt32(5, MemberNum);
}
 
if (HasBulletin) {
output.WriteString(6, Bulletin);
}
 
if (HasMoney) {
output.WriteInt64(7, Money);
}
 
if (HasPower) {
output.WriteInt64(8, Power);
}
 
if (HasMasterName) {
output.WriteString(9, MasterName);
}
 
if (HasIsKickMaster) {
output.WriteInt32(10, IsKickMaster);
}
 
if (HasKickTime) {
output.WriteInt64(11, KickTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GangMainInfo _inst = (GangMainInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  18: {
 _inst.GangName = input.ReadString();
break;
}
   case  26: {
 _inst.GangTotem = input.ReadString();
break;
}
   case  32: {
 _inst.GangLevel = input.ReadInt32();
break;
}
   case  40: {
 _inst.MemberNum = input.ReadInt32();
break;
}
   case  50: {
 _inst.Bulletin = input.ReadString();
break;
}
   case  56: {
 _inst.Money = input.ReadInt64();
break;
}
   case  64: {
 _inst.Power = input.ReadInt64();
break;
}
   case  74: {
 _inst.MasterName = input.ReadString();
break;
}
   case  80: {
 _inst.IsKickMaster = input.ReadInt32();
break;
}
   case  88: {
 _inst.KickTime = input.ReadInt64();
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
public class GangMemberInfo : PacketDistributed
{

public const int memIdFieldNumber = 1;
 private bool hasMemId;
 private Int64 memId_ = 0;
 public bool HasMemId {
 get { return hasMemId; }
 }
 public Int64 MemId {
 get { return memId_; }
 set { SetMemId(value); }
 }
 public void SetMemId(Int64 value) { 
 hasMemId = true;
 memId_ = value;
 }

public const int memNameFieldNumber = 2;
 private bool hasMemName;
 private string memName_ = "";
 public bool HasMemName {
 get { return hasMemName; }
 }
 public string MemName {
 get { return memName_; }
 set { SetMemName(value); }
 }
 public void SetMemName(string value) { 
 hasMemName = true;
 memName_ = value;
 }

public const int memLevelFieldNumber = 3;
 private bool hasMemLevel;
 private Int32 memLevel_ = 0;
 public bool HasMemLevel {
 get { return hasMemLevel; }
 }
 public Int32 MemLevel {
 get { return memLevel_; }
 set { SetMemLevel(value); }
 }
 public void SetMemLevel(Int32 value) { 
 hasMemLevel = true;
 memLevel_ = value;
 }

public const int memFightPowerFieldNumber = 4;
 private bool hasMemFightPower;
 private Int64 memFightPower_ = 0;
 public bool HasMemFightPower {
 get { return hasMemFightPower; }
 }
 public Int64 MemFightPower {
 get { return memFightPower_; }
 set { SetMemFightPower(value); }
 }
 public void SetMemFightPower(Int64 value) { 
 hasMemFightPower = true;
 memFightPower_ = value;
 }

public const int memJobFieldNumber = 5;
 private bool hasMemJob;
 private Int32 memJob_ = 0;
 public bool HasMemJob {
 get { return hasMemJob; }
 }
 public Int32 MemJob {
 get { return memJob_; }
 set { SetMemJob(value); }
 }
 public void SetMemJob(Int32 value) { 
 hasMemJob = true;
 memJob_ = value;
 }

public const int memOnlineFieldNumber = 6;
 private bool hasMemOnline;
 private Int32 memOnline_ = 0;
 public bool HasMemOnline {
 get { return hasMemOnline; }
 }
 public Int32 MemOnline {
 get { return memOnline_; }
 set { SetMemOnline(value); }
 }
 public void SetMemOnline(Int32 value) { 
 hasMemOnline = true;
 memOnline_ = value;
 }

public const int memContributeFieldNumber = 7;
 private bool hasMemContribute;
 private Int64 memContribute_ = 0;
 public bool HasMemContribute {
 get { return hasMemContribute; }
 }
 public Int64 MemContribute {
 get { return memContribute_; }
 set { SetMemContribute(value); }
 }
 public void SetMemContribute(Int64 value) { 
 hasMemContribute = true;
 memContribute_ = value;
 }

public const int gangContributeTotalFieldNumber = 8;
 private bool hasGangContributeTotal;
 private Int64 gangContributeTotal_ = 0;
 public bool HasGangContributeTotal {
 get { return hasGangContributeTotal; }
 }
 public Int64 GangContributeTotal {
 get { return gangContributeTotal_; }
 set { SetGangContributeTotal(value); }
 }
 public void SetGangContributeTotal(Int64 value) { 
 hasGangContributeTotal = true;
 gangContributeTotal_ = value;
 }

public const int professionIdFieldNumber = 9;
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

public const int vipFieldNumber = 10;
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

public const int memLogoutTimeFieldNumber = 11;
 private bool hasMemLogoutTime;
 private Int64 memLogoutTime_ = 0;
 public bool HasMemLogoutTime {
 get { return hasMemLogoutTime; }
 }
 public Int64 MemLogoutTime {
 get { return memLogoutTime_; }
 set { SetMemLogoutTime(value); }
 }
 public void SetMemLogoutTime(Int64 value) { 
 hasMemLogoutTime = true;
 memLogoutTime_ = value;
 }

public const int sexFieldNumber = 12;
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
  if (HasMemId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, MemId);
}
 if (HasMemName) {
size += pb::CodedOutputStream.ComputeStringSize(2, MemName);
}
 if (HasMemLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MemLevel);
}
 if (HasMemFightPower) {
size += pb::CodedOutputStream.ComputeInt64Size(4, MemFightPower);
}
 if (HasMemJob) {
size += pb::CodedOutputStream.ComputeInt32Size(5, MemJob);
}
 if (HasMemOnline) {
size += pb::CodedOutputStream.ComputeInt32Size(6, MemOnline);
}
 if (HasMemContribute) {
size += pb::CodedOutputStream.ComputeInt64Size(7, MemContribute);
}
 if (HasGangContributeTotal) {
size += pb::CodedOutputStream.ComputeInt64Size(8, GangContributeTotal);
}
 if (HasProfessionId) {
size += pb::CodedOutputStream.ComputeInt32Size(9, ProfessionId);
}
 if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(10, Vip);
}
 if (HasMemLogoutTime) {
size += pb::CodedOutputStream.ComputeInt64Size(11, MemLogoutTime);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(12, Sex);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMemId) {
output.WriteInt64(1, MemId);
}
 
if (HasMemName) {
output.WriteString(2, MemName);
}
 
if (HasMemLevel) {
output.WriteInt32(3, MemLevel);
}
 
if (HasMemFightPower) {
output.WriteInt64(4, MemFightPower);
}
 
if (HasMemJob) {
output.WriteInt32(5, MemJob);
}
 
if (HasMemOnline) {
output.WriteInt32(6, MemOnline);
}
 
if (HasMemContribute) {
output.WriteInt64(7, MemContribute);
}
 
if (HasGangContributeTotal) {
output.WriteInt64(8, GangContributeTotal);
}
 
if (HasProfessionId) {
output.WriteInt32(9, ProfessionId);
}
 
if (HasVip) {
output.WriteInt32(10, Vip);
}
 
if (HasMemLogoutTime) {
output.WriteInt64(11, MemLogoutTime);
}
 
if (HasSex) {
output.WriteInt32(12, Sex);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GangMemberInfo _inst = (GangMemberInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MemId = input.ReadInt64();
break;
}
   case  18: {
 _inst.MemName = input.ReadString();
break;
}
   case  24: {
 _inst.MemLevel = input.ReadInt32();
break;
}
   case  32: {
 _inst.MemFightPower = input.ReadInt64();
break;
}
   case  40: {
 _inst.MemJob = input.ReadInt32();
break;
}
   case  48: {
 _inst.MemOnline = input.ReadInt32();
break;
}
   case  56: {
 _inst.MemContribute = input.ReadInt64();
break;
}
   case  64: {
 _inst.GangContributeTotal = input.ReadInt64();
break;
}
   case  72: {
 _inst.ProfessionId = input.ReadInt32();
break;
}
   case  80: {
 _inst.Vip = input.ReadInt32();
break;
}
   case  88: {
 _inst.MemLogoutTime = input.ReadInt64();
break;
}
   case  96: {
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


}
