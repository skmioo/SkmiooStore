//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCommonExchange : PacketDistributed
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
 CGCommonExchange _inst = (CGCommonExchange) _base;
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
public class CGRefreshCommonExchange : PacketDistributed
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
 CGRefreshCommonExchange _inst = (CGRefreshCommonExchange) _base;
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
public class CommonExchangeInfo : PacketDistributed
{

public const int bidFieldNumber = 1;
 private bool hasBid;
 private Int32 bid_ = 0;
 public bool HasBid {
 get { return hasBid; }
 }
 public Int32 Bid {
 get { return bid_; }
 set { SetBid(value); }
 }
 public void SetBid(Int32 value) { 
 hasBid = true;
 bid_ = value;
 }

public const int sidFieldNumber = 2;
 private bool hasSid;
 private Int32 sid_ = 0;
 public bool HasSid {
 get { return hasSid; }
 }
 public Int32 Sid {
 get { return sid_; }
 set { SetSid(value); }
 }
 public void SetSid(Int32 value) { 
 hasSid = true;
 sid_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasBid) {
output.WriteInt32(1, Bid);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CommonExchangeInfo _inst = (CommonExchangeInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  24: {
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
public class CommonExchangeListInfo : PacketDistributed
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

public const int exFieldNumber = 2;
 private pbc::PopsicleList<CommonExchangeInfo> ex_ = new pbc::PopsicleList<CommonExchangeInfo>();
 public scg::IList<CommonExchangeInfo> exList {
 get { return pbc::Lists.AsReadOnly(ex_); }
 }
 
 public int exCount {
 get { return ex_.Count; }
 }
 
public CommonExchangeInfo GetEx(int index) {
 return ex_[index];
 }
 public void AddEx(CommonExchangeInfo value) {
 ex_.Add(value);
 }

public const int beExFieldNumber = 3;
 private bool hasBeEx;
 private CommonExchangeInfo beEx_ =  new CommonExchangeInfo();
 public bool HasBeEx {
 get { return hasBeEx; }
 }
 public CommonExchangeInfo BeEx {
 get { return beEx_; }
 set { SetBeEx(value); }
 }
 public void SetBeEx(CommonExchangeInfo value) { 
 hasBeEx = true;
 beEx_ = value;
 }

public const int totalNumFieldNumber = 4;
 private bool hasTotalNum;
 private Int32 totalNum_ = 0;
 public bool HasTotalNum {
 get { return hasTotalNum; }
 }
 public Int32 TotalNum {
 get { return totalNum_; }
 set { SetTotalNum(value); }
 }
 public void SetTotalNum(Int32 value) { 
 hasTotalNum = true;
 totalNum_ = value;
 }

public const int hasNumFieldNumber = 5;
 private bool hasHasNum;
 private Int32 hasNum_ = 0;
 public bool HasHasNum {
 get { return hasHasNum; }
 }
 public Int32 HasNum {
 get { return hasNum_; }
 set { SetHasNum(value); }
 }
 public void SetHasNum(Int32 value) { 
 hasHasNum = true;
 hasNum_ = value;
 }

public const int shopTypeFieldNumber = 6;
 private bool hasShopType;
 private Int32 shopType_ = 0;
 public bool HasShopType {
 get { return hasShopType; }
 }
 public Int32 ShopType {
 get { return shopType_; }
 set { SetShopType(value); }
 }
 public void SetShopType(Int32 value) { 
 hasShopType = true;
 shopType_ = value;
 }

public const int shopTypeNameFieldNumber = 7;
 private bool hasShopTypeName;
 private string shopTypeName_ = "";
 public bool HasShopTypeName {
 get { return hasShopTypeName; }
 }
 public string ShopTypeName {
 get { return shopTypeName_; }
 set { SetShopTypeName(value); }
 }
 public void SetShopTypeName(string value) { 
 hasShopTypeName = true;
 shopTypeName_ = value;
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
{
foreach (CommonExchangeInfo element in exList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = BeEx.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasTotalNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TotalNum);
}
 if (HasHasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, HasNum);
}
 if (HasShopType) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ShopType);
}
 if (HasShopTypeName) {
size += pb::CodedOutputStream.ComputeStringSize(7, ShopTypeName);
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

do{
foreach (CommonExchangeInfo element in exList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)BeEx.SerializedSize());
BeEx.WriteTo(output);

}
 
if (HasTotalNum) {
output.WriteInt32(4, TotalNum);
}
 
if (HasHasNum) {
output.WriteInt32(5, HasNum);
}
 
if (HasShopType) {
output.WriteInt32(6, ShopType);
}
 
if (HasShopTypeName) {
output.WriteString(7, ShopTypeName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CommonExchangeListInfo _inst = (CommonExchangeListInfo) _base;
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
CommonExchangeInfo subBuilder =  new CommonExchangeInfo();
input.ReadMessage(subBuilder);
_inst.AddEx(subBuilder);
break;
}
    case  26: {
CommonExchangeInfo subBuilder =  new CommonExchangeInfo();
 input.ReadMessage(subBuilder);
_inst.BeEx = subBuilder;
break;
}
   case  32: {
 _inst.TotalNum = input.ReadInt32();
break;
}
   case  40: {
 _inst.HasNum = input.ReadInt32();
break;
}
   case  48: {
 _inst.ShopType = input.ReadInt32();
break;
}
   case  58: {
 _inst.ShopTypeName = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CommonExchangeInfo element in exList) {
if (!element.IsInitialized()) return false;
}
  if (HasBeEx) {
if (!BeEx.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCommonExchange : PacketDistributed
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

public const int templateIdFieldNumber = 2;
 private bool hasTemplateId;
 private Int32 templateId_ = 0;
 public bool HasTemplateId {
 get { return hasTemplateId; }
 }
 public Int32 TemplateId {
 get { return templateId_; }
 set { SetTemplateId(value); }
 }
 public void SetTemplateId(Int32 value) { 
 hasTemplateId = true;
 templateId_ = value;
 }

public const int totalNumFieldNumber = 3;
 private bool hasTotalNum;
 private Int32 totalNum_ = 0;
 public bool HasTotalNum {
 get { return hasTotalNum; }
 }
 public Int32 TotalNum {
 get { return totalNum_; }
 set { SetTotalNum(value); }
 }
 public void SetTotalNum(Int32 value) { 
 hasTotalNum = true;
 totalNum_ = value;
 }

public const int hasNumFieldNumber = 4;
 private bool hasHasNum;
 private Int32 hasNum_ = 0;
 public bool HasHasNum {
 get { return hasHasNum; }
 }
 public Int32 HasNum {
 get { return hasNum_; }
 set { SetHasNum(value); }
 }
 public void SetHasNum(Int32 value) { 
 hasHasNum = true;
 hasNum_ = value;
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
 if (HasTemplateId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TemplateId);
}
 if (HasTotalNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TotalNum);
}
 if (HasHasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, HasNum);
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
 
if (HasTemplateId) {
output.WriteInt32(2, TemplateId);
}
 
if (HasTotalNum) {
output.WriteInt32(3, TotalNum);
}
 
if (HasHasNum) {
output.WriteInt32(4, HasNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCommonExchange _inst = (GCCommonExchange) _base;
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
 _inst.TemplateId = input.ReadInt32();
break;
}
   case  24: {
 _inst.TotalNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.HasNum = input.ReadInt32();
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
public class GCRefreshCommonExchange : PacketDistributed
{

public const int exsFieldNumber = 1;
 private pbc::PopsicleList<CommonExchangeListInfo> exs_ = new pbc::PopsicleList<CommonExchangeListInfo>();
 public scg::IList<CommonExchangeListInfo> exsList {
 get { return pbc::Lists.AsReadOnly(exs_); }
 }
 
 public int exsCount {
 get { return exs_.Count; }
 }
 
public CommonExchangeListInfo GetExs(int index) {
 return exs_[index];
 }
 public void AddExs(CommonExchangeListInfo value) {
 exs_.Add(value);
 }

public const int historyFieldNumber = 2;
 private pbc::PopsicleList<string> history_ = new pbc::PopsicleList<string>();
 public scg::IList<string> historyList {
 get { return pbc::Lists.AsReadOnly(history_); }
 }
 
 public int historyCount {
 get { return history_.Count; }
 }
 
public string GetHistory(int index) {
 return history_[index];
 }
 public void AddHistory(string value) {
 history_.Add(value);
 }

public const int informationFieldNumber = 3;
 private bool hasInformation;
 private string information_ = "";
 public bool HasInformation {
 get { return hasInformation; }
 }
 public string Information {
 get { return information_; }
 set { SetInformation(value); }
 }
 public void SetInformation(string value) { 
 hasInformation = true;
 information_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (CommonExchangeListInfo element in exsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int dataSize = 0;
foreach (string element in historyList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * history_.Count;
}
 if (HasInformation) {
size += pb::CodedOutputStream.ComputeStringSize(3, Information);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (CommonExchangeListInfo element in exsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
if (history_.Count > 0) {
foreach (string element in historyList) {
output.WriteString(2,element);
}
}

}
 
if (HasInformation) {
output.WriteString(3, Information);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshCommonExchange _inst = (GCRefreshCommonExchange) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CommonExchangeListInfo subBuilder =  new CommonExchangeListInfo();
input.ReadMessage(subBuilder);
_inst.AddExs(subBuilder);
break;
}
   case  18: {
 _inst.AddHistory(input.ReadString());
break;
}
   case  26: {
 _inst.Information = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (CommonExchangeListInfo element in exsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRefreshHistory : PacketDistributed
{

public const int historyFieldNumber = 1;
 private pbc::PopsicleList<string> history_ = new pbc::PopsicleList<string>();
 public scg::IList<string> historyList {
 get { return pbc::Lists.AsReadOnly(history_); }
 }
 
 public int historyCount {
 get { return history_.Count; }
 }
 
public string GetHistory(int index) {
 return history_[index];
 }
 public void AddHistory(string value) {
 history_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (string element in historyList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * history_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (history_.Count > 0) {
foreach (string element in historyList) {
output.WriteString(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreshHistory _inst = (GCRefreshHistory) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.AddHistory(input.ReadString());
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
