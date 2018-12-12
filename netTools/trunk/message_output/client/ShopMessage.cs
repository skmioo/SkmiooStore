//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGShop : PacketDistributed
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

public const int idFieldNumber = 2;
 private bool hasId;
 private Int64 id_ = 0;
 public bool HasId {
 get { return hasId; }
 }
 public Int64 Id {
 get { return id_; }
 set { SetId(value); }
 }
 public void SetId(Int64 value) { 
 hasId = true;
 id_ = value;
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
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Id);
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
  
if (HasType) {
output.WriteInt32(1, Type);
}
 
if (HasId) {
output.WriteInt64(2, Id);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGShop _inst = (CGShop) _base;
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
 _inst.Id = input.ReadInt64();
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
public class CGShopLuckDraw : PacketDistributed
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
 CGShopLuckDraw _inst = (CGShopLuckDraw) _base;
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
public class DelItemData : PacketDistributed
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

public const int idFieldNumber = 2;
 private bool hasId;
 private Int64 id_ = 0;
 public bool HasId {
 get { return hasId; }
 }
 public Int64 Id {
 get { return id_; }
 set { SetId(value); }
 }
 public void SetId(Int64 value) { 
 hasId = true;
 id_ = value;
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
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Id);
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
 
if (HasId) {
output.WriteInt64(2, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 DelItemData _inst = (DelItemData) _base;
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
 _inst.Id = input.ReadInt64();
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
public class GCAddShopItemData : PacketDistributed
{

public const int shopDataFieldNumber = 1;
 private pbc::PopsicleList<ShopItemInfo> shopData_ = new pbc::PopsicleList<ShopItemInfo>();
 public scg::IList<ShopItemInfo> shopDataList {
 get { return pbc::Lists.AsReadOnly(shopData_); }
 }
 
 public int shopDataCount {
 get { return shopData_.Count; }
 }
 
public ShopItemInfo GetShopData(int index) {
 return shopData_[index];
 }
 public void AddShopData(ShopItemInfo value) {
 shopData_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ShopItemInfo element in shopDataList) {
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
foreach (ShopItemInfo element in shopDataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAddShopItemData _inst = (GCAddShopItemData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ShopItemInfo subBuilder =  new ShopItemInfo();
input.ReadMessage(subBuilder);
_inst.AddShopData(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ShopItemInfo element in shopDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDelShopItemData : PacketDistributed
{

public const int shopDataFieldNumber = 1;
 private pbc::PopsicleList<DelItemData> shopData_ = new pbc::PopsicleList<DelItemData>();
 public scg::IList<DelItemData> shopDataList {
 get { return pbc::Lists.AsReadOnly(shopData_); }
 }
 
 public int shopDataCount {
 get { return shopData_.Count; }
 }
 
public DelItemData GetShopData(int index) {
 return shopData_[index];
 }
 public void AddShopData(DelItemData value) {
 shopData_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (DelItemData element in shopDataList) {
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
foreach (DelItemData element in shopDataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDelShopItemData _inst = (GCDelShopItemData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
DelItemData subBuilder =  new DelItemData();
input.ReadMessage(subBuilder);
_inst.AddShopData(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (DelItemData element in shopDataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushShop : PacketDistributed
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
 private pbc::PopsicleList<ItemInfo> itemInfo_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> itemInfoList {
 get { return pbc::Lists.AsReadOnly(itemInfo_); }
 }
 
 public int itemInfoCount {
 get { return itemInfo_.Count; }
 }
 
public ItemInfo GetItemInfo(int index) {
 return itemInfo_[index];
 }
 public void AddItemInfo(ItemInfo value) {
 itemInfo_.Add(value);
 }

public const int errorCodeFieldNumber = 3;
 private bool hasErrorCode;
 private Int32 errorCode_ = 0;
 public bool HasErrorCode {
 get { return hasErrorCode; }
 }
 public Int32 ErrorCode {
 get { return errorCode_; }
 set { SetErrorCode(value); }
 }
 public void SetErrorCode(Int32 value) { 
 hasErrorCode = true;
 errorCode_ = value;
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
foreach (ItemInfo element in itemInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ErrorCode);
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
foreach (ItemInfo element in itemInfoList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasErrorCode) {
output.WriteInt32(3, ErrorCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushShop _inst = (GCPushShop) _base;
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
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddItemInfo(subBuilder);
break;
}
   case  24: {
 _inst.ErrorCode = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ItemInfo element in itemInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPushShopData : PacketDistributed
{

public const int shopDataFieldNumber = 1;
 private pbc::PopsicleList<ShopItemInfo> shopData_ = new pbc::PopsicleList<ShopItemInfo>();
 public scg::IList<ShopItemInfo> shopDataList {
 get { return pbc::Lists.AsReadOnly(shopData_); }
 }
 
 public int shopDataCount {
 get { return shopData_.Count; }
 }
 
public ShopItemInfo GetShopData(int index) {
 return shopData_[index];
 }
 public void AddShopData(ShopItemInfo value) {
 shopData_.Add(value);
 }

public const int shopSingFieldNumber = 2;
 private pbc::PopsicleList<ShopSingInfo> shopSing_ = new pbc::PopsicleList<ShopSingInfo>();
 public scg::IList<ShopSingInfo> shopSingList {
 get { return pbc::Lists.AsReadOnly(shopSing_); }
 }
 
 public int shopSingCount {
 get { return shopSing_.Count; }
 }
 
public ShopSingInfo GetShopSing(int index) {
 return shopSing_[index];
 }
 public void AddShopSing(ShopSingInfo value) {
 shopSing_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ShopItemInfo element in shopDataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ShopSingInfo element in shopSingList) {
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
 
do{
foreach (ShopItemInfo element in shopDataList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ShopSingInfo element in shopSingList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushShopData _inst = (GCPushShopData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ShopItemInfo subBuilder =  new ShopItemInfo();
input.ReadMessage(subBuilder);
_inst.AddShopData(subBuilder);
break;
}
    case  18: {
ShopSingInfo subBuilder =  new ShopSingInfo();
input.ReadMessage(subBuilder);
_inst.AddShopSing(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ShopItemInfo element in shopDataList) {
if (!element.IsInitialized()) return false;
}
foreach (ShopSingInfo element in shopSingList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCShop : PacketDistributed
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

public const int errorCodeFieldNumber = 3;
 private bool hasErrorCode;
 private Int32 errorCode_ = 0;
 public bool HasErrorCode {
 get { return hasErrorCode; }
 }
 public Int32 ErrorCode {
 get { return errorCode_; }
 set { SetErrorCode(value); }
 }
 public void SetErrorCode(Int32 value) { 
 hasErrorCode = true;
 errorCode_ = value;
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
int subsize = ItemInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ErrorCode);
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
ItemInfo.WriteTo(output);

}
 
if (HasErrorCode) {
output.WriteInt32(3, ErrorCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCShop _inst = (GCShop) _base;
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
ItemInfo subBuilder =  new ItemInfo();
 input.ReadMessage(subBuilder);
_inst.ItemInfo = subBuilder;
break;
}
   case  24: {
 _inst.ErrorCode = input.ReadInt32();
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
public class ItemInfo : PacketDistributed
{

public const int temIDFieldNumber = 1;
 private bool hasTemID;
 private Int64 temID_ = 0;
 public bool HasTemID {
 get { return hasTemID; }
 }
 public Int64 TemID {
 get { return temID_; }
 set { SetTemID(value); }
 }
 public void SetTemID(Int64 value) { 
 hasTemID = true;
 temID_ = value;
 }

public const int currNumFieldNumber = 2;
 private bool hasCurrNum;
 private Int32 currNum_ = 0;
 public bool HasCurrNum {
 get { return hasCurrNum; }
 }
 public Int32 CurrNum {
 get { return currNum_; }
 set { SetCurrNum(value); }
 }
 public void SetCurrNum(Int32 value) { 
 hasCurrNum = true;
 currNum_ = value;
 }

public const int bidFieldNumber = 3;
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

public const int sidFieldNumber = 4;
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

public const int numFieldNumber = 5;
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

public const int bindFieldNumber = 6;
 private bool hasBind;
 private Int32 bind_ = 0;
 public bool HasBind {
 get { return hasBind; }
 }
 public Int32 Bind {
 get { return bind_; }
 set { SetBind(value); }
 }
 public void SetBind(Int32 value) { 
 hasBind = true;
 bind_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTemID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TemID);
}
 if (HasCurrNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CurrNum);
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Sid);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Num);
}
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Bind);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTemID) {
output.WriteInt64(1, TemID);
}
 
if (HasCurrNum) {
output.WriteInt32(2, CurrNum);
}
 
if (HasBid) {
output.WriteInt32(3, Bid);
}
 
if (HasSid) {
output.WriteInt32(4, Sid);
}
 
if (HasNum) {
output.WriteInt32(5, Num);
}
 
if (HasBind) {
output.WriteInt32(6, Bind);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ItemInfo _inst = (ItemInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TemID = input.ReadInt64();
break;
}
   case  16: {
 _inst.CurrNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  32: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  40: {
 _inst.Num = input.ReadInt32();
break;
}
   case  48: {
 _inst.Bind = input.ReadInt32();
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
public class ShopCardInfo : PacketDistributed
{

public const int cardIdFieldNumber = 1;
 private bool hasCardId;
 private Int32 cardId_ = 0;
 public bool HasCardId {
 get { return hasCardId; }
 }
 public Int32 CardId {
 get { return cardId_; }
 set { SetCardId(value); }
 }
 public void SetCardId(Int32 value) { 
 hasCardId = true;
 cardId_ = value;
 }

public const int CardNameFieldNumber = 2;
 private bool hasCardName;
 private string CardName_ = "";
 public bool HasCardName {
 get { return hasCardName; }
 }
 public string CardName {
 get { return CardName_; }
 set { SetCardName(value); }
 }
 public void SetCardName(string value) { 
 hasCardName = true;
 CardName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCardId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, CardId);
}
 if (HasCardName) {
size += pb::CodedOutputStream.ComputeStringSize(2, CardName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCardId) {
output.WriteInt32(1, CardId);
}
 
if (HasCardName) {
output.WriteString(2, CardName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ShopCardInfo _inst = (ShopCardInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.CardId = input.ReadInt32();
break;
}
   case  18: {
 _inst.CardName = input.ReadString();
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
public class ShopItemInfo : PacketDistributed
{

public const int temIDFieldNumber = 1;
 private bool hasTemID;
 private Int64 temID_ = 0;
 public bool HasTemID {
 get { return hasTemID; }
 }
 public Int64 TemID {
 get { return temID_; }
 set { SetTemID(value); }
 }
 public void SetTemID(Int64 value) { 
 hasTemID = true;
 temID_ = value;
 }

public const int shopTypeFieldNumber = 2;
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

public const int itemIdFieldNumber = 3;
 private bool hasItemId;
 private Int32 itemId_ = 0;
 public bool HasItemId {
 get { return hasItemId; }
 }
 public Int32 ItemId {
 get { return itemId_; }
 set { SetItemId(value); }
 }
 public void SetItemId(Int32 value) { 
 hasItemId = true;
 itemId_ = value;
 }

public const int limitNumberFieldNumber = 4;
 private bool hasLimitNumber;
 private Int32 limitNumber_ = 0;
 public bool HasLimitNumber {
 get { return hasLimitNumber; }
 }
 public Int32 LimitNumber {
 get { return limitNumber_; }
 set { SetLimitNumber(value); }
 }
 public void SetLimitNumber(Int32 value) { 
 hasLimitNumber = true;
 limitNumber_ = value;
 }

public const int oneBuyMaxFieldNumber = 5;
 private bool hasOneBuyMax;
 private Int32 oneBuyMax_ = 0;
 public bool HasOneBuyMax {
 get { return hasOneBuyMax; }
 }
 public Int32 OneBuyMax {
 get { return oneBuyMax_; }
 set { SetOneBuyMax(value); }
 }
 public void SetOneBuyMax(Int32 value) { 
 hasOneBuyMax = true;
 oneBuyMax_ = value;
 }

public const int needMoneyFieldNumber = 6;
 private bool hasNeedMoney;
 private Int32 needMoney_ = 0;
 public bool HasNeedMoney {
 get { return hasNeedMoney; }
 }
 public Int32 NeedMoney {
 get { return needMoney_; }
 set { SetNeedMoney(value); }
 }
 public void SetNeedMoney(Int32 value) { 
 hasNeedMoney = true;
 needMoney_ = value;
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

public const int discountFieldNumber = 8;
 private bool hasDiscount;
 private Int32 discount_ = 0;
 public bool HasDiscount {
 get { return hasDiscount; }
 }
 public Int32 Discount {
 get { return discount_; }
 set { SetDiscount(value); }
 }
 public void SetDiscount(Int32 value) { 
 hasDiscount = true;
 discount_ = value;
 }

public const int limitparamFieldNumber = 9;
 private bool hasLimitparam;
 private string limitparam_ = "";
 public bool HasLimitparam {
 get { return hasLimitparam; }
 }
 public string Limitparam {
 get { return limitparam_; }
 set { SetLimitparam(value); }
 }
 public void SetLimitparam(string value) { 
 hasLimitparam = true;
 limitparam_ = value;
 }

public const int limitTypeFieldNumber = 10;
 private bool hasLimitType;
 private Int32 limitType_ = 0;
 public bool HasLimitType {
 get { return hasLimitType; }
 }
 public Int32 LimitType {
 get { return limitType_; }
 set { SetLimitType(value); }
 }
 public void SetLimitType(Int32 value) { 
 hasLimitType = true;
 limitType_ = value;
 }

public const int cardIdFieldNumber = 11;
 private bool hasCardId;
 private Int32 cardId_ = 0;
 public bool HasCardId {
 get { return hasCardId; }
 }
 public Int32 CardId {
 get { return cardId_; }
 set { SetCardId(value); }
 }
 public void SetCardId(Int32 value) { 
 hasCardId = true;
 cardId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTemID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TemID);
}
 if (HasShopType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ShopType);
}
 if (HasItemId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ItemId);
}
 if (HasLimitNumber) {
size += pb::CodedOutputStream.ComputeInt32Size(4, LimitNumber);
}
 if (HasOneBuyMax) {
size += pb::CodedOutputStream.ComputeInt32Size(5, OneBuyMax);
}
 if (HasNeedMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(6, NeedMoney);
}
 if (HasPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Price);
}
 if (HasDiscount) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Discount);
}
 if (HasLimitparam) {
size += pb::CodedOutputStream.ComputeStringSize(9, Limitparam);
}
 if (HasLimitType) {
size += pb::CodedOutputStream.ComputeInt32Size(10, LimitType);
}
 if (HasCardId) {
size += pb::CodedOutputStream.ComputeInt32Size(11, CardId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTemID) {
output.WriteInt64(1, TemID);
}
 
if (HasShopType) {
output.WriteInt32(2, ShopType);
}
 
if (HasItemId) {
output.WriteInt32(3, ItemId);
}
 
if (HasLimitNumber) {
output.WriteInt32(4, LimitNumber);
}
 
if (HasOneBuyMax) {
output.WriteInt32(5, OneBuyMax);
}
 
if (HasNeedMoney) {
output.WriteInt32(6, NeedMoney);
}
 
if (HasPrice) {
output.WriteInt32(7, Price);
}
 
if (HasDiscount) {
output.WriteInt32(8, Discount);
}
 
if (HasLimitparam) {
output.WriteString(9, Limitparam);
}
 
if (HasLimitType) {
output.WriteInt32(10, LimitType);
}
 
if (HasCardId) {
output.WriteInt32(11, CardId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ShopItemInfo _inst = (ShopItemInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TemID = input.ReadInt64();
break;
}
   case  16: {
 _inst.ShopType = input.ReadInt32();
break;
}
   case  24: {
 _inst.ItemId = input.ReadInt32();
break;
}
   case  32: {
 _inst.LimitNumber = input.ReadInt32();
break;
}
   case  40: {
 _inst.OneBuyMax = input.ReadInt32();
break;
}
   case  48: {
 _inst.NeedMoney = input.ReadInt32();
break;
}
   case  56: {
 _inst.Price = input.ReadInt32();
break;
}
   case  64: {
 _inst.Discount = input.ReadInt32();
break;
}
   case  74: {
 _inst.Limitparam = input.ReadString();
break;
}
   case  80: {
 _inst.LimitType = input.ReadInt32();
break;
}
   case  88: {
 _inst.CardId = input.ReadInt32();
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
public class ShopSingInfo : PacketDistributed
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

public const int nameFieldNumber = 2;
 private bool hasName;
 private Int32 name_ = 0;
 public bool HasName {
 get { return hasName; }
 }
 public Int32 Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(Int32 value) { 
 hasName = true;
 name_ = value;
 }

public const int canSeeFieldNumber = 3;
 private bool hasCanSee;
 private Int32 canSee_ = 0;
 public bool HasCanSee {
 get { return hasCanSee; }
 }
 public Int32 CanSee {
 get { return canSee_; }
 set { SetCanSee(value); }
 }
 public void SetCanSee(Int32 value) { 
 hasCanSee = true;
 canSee_ = value;
 }

public const int orderFieldNumber = 4;
 private bool hasOrder;
 private Int32 order_ = 0;
 public bool HasOrder {
 get { return hasOrder; }
 }
 public Int32 Order {
 get { return order_; }
 set { SetOrder(value); }
 }
 public void SetOrder(Int32 value) { 
 hasOrder = true;
 order_ = value;
 }

public const int cardFieldNumber = 5;
 private bool hasCard;
 private Int32 card_ = 0;
 public bool HasCard {
 get { return hasCard; }
 }
 public Int32 Card {
 get { return card_; }
 set { SetCard(value); }
 }
 public void SetCard(Int32 value) { 
 hasCard = true;
 card_ = value;
 }

public const int resultFieldNumber = 6;
 private bool hasResult;
 private string result_ = "";
 public bool HasResult {
 get { return hasResult; }
 }
 public string Result {
 get { return result_; }
 set { SetResult(value); }
 }
 public void SetResult(string value) { 
 hasResult = true;
 result_ = value;
 }

public const int ShopCardInfoFieldNumber = 7;
 private pbc::PopsicleList<ShopCardInfo> ShopCardInfo_ = new pbc::PopsicleList<ShopCardInfo>();
 public scg::IList<ShopCardInfo> ShopCardInfoList {
 get { return pbc::Lists.AsReadOnly(ShopCardInfo_); }
 }
 
 public int ShopCardInfoCount {
 get { return ShopCardInfo_.Count; }
 }
 
public ShopCardInfo GetShopCardInfo(int index) {
 return ShopCardInfo_[index];
 }
 public void AddShopCardInfo(ShopCardInfo value) {
 ShopCardInfo_.Add(value);
 }

public const int storeTypeFieldNumber = 8;
 private bool hasStoreType;
 private Int32 storeType_ = 0;
 public bool HasStoreType {
 get { return hasStoreType; }
 }
 public Int32 StoreType {
 get { return storeType_; }
 set { SetStoreType(value); }
 }
 public void SetStoreType(Int32 value) { 
 hasStoreType = true;
 storeType_ = value;
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
 if (HasName) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Name);
}
 if (HasCanSee) {
size += pb::CodedOutputStream.ComputeInt32Size(3, CanSee);
}
 if (HasOrder) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Order);
}
 if (HasCard) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Card);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeStringSize(6, Result);
}
{
foreach (ShopCardInfo element in ShopCardInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasStoreType) {
size += pb::CodedOutputStream.ComputeInt32Size(8, StoreType);
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
 
if (HasName) {
output.WriteInt32(2, Name);
}
 
if (HasCanSee) {
output.WriteInt32(3, CanSee);
}
 
if (HasOrder) {
output.WriteInt32(4, Order);
}
 
if (HasCard) {
output.WriteInt32(5, Card);
}
 
if (HasResult) {
output.WriteString(6, Result);
}

do{
foreach (ShopCardInfo element in ShopCardInfoList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasStoreType) {
output.WriteInt32(8, StoreType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ShopSingInfo _inst = (ShopSingInfo) _base;
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
 _inst.Name = input.ReadInt32();
break;
}
   case  24: {
 _inst.CanSee = input.ReadInt32();
break;
}
   case  32: {
 _inst.Order = input.ReadInt32();
break;
}
   case  40: {
 _inst.Card = input.ReadInt32();
break;
}
   case  50: {
 _inst.Result = input.ReadString();
break;
}
    case  58: {
ShopCardInfo subBuilder =  new ShopCardInfo();
input.ReadMessage(subBuilder);
_inst.AddShopCardInfo(subBuilder);
break;
}
   case  64: {
 _inst.StoreType = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ShopCardInfo element in ShopCardInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
