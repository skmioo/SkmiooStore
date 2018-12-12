//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class AuctionBackData : PacketDistributed
{

public const int ahIDFieldNumber = 1;
 private bool hasAhID;
 private Int64 ahID_ = 0;
 public bool HasAhID {
 get { return hasAhID; }
 }
 public Int64 AhID {
 get { return ahID_; }
 set { SetAhID(value); }
 }
 public void SetAhID(Int64 value) { 
 hasAhID = true;
 ahID_ = value;
 }

public const int bidFieldNumber = 2;
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

public const int sidFieldNumber = 3;
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

public const int priceTypeFieldNumber = 5;
 private bool hasPriceType;
 private Int32 priceType_ = 0;
 public bool HasPriceType {
 get { return hasPriceType; }
 }
 public Int32 PriceType {
 get { return priceType_; }
 set { SetPriceType(value); }
 }
 public void SetPriceType(Int32 value) { 
 hasPriceType = true;
 priceType_ = value;
 }

public const int priceFieldNumber = 6;
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

public const int isShowFieldNumber = 7;
 private bool hasIsShow;
 private Int32 isShow_ = 0;
 public bool HasIsShow {
 get { return hasIsShow; }
 }
 public Int32 IsShow {
 get { return isShow_; }
 set { SetIsShow(value); }
 }
 public void SetIsShow(Int32 value) { 
 hasIsShow = true;
 isShow_ = value;
 }

public const int equipInfoFieldNumber = 8;
 private bool hasEquipInfo;
 private EquipInfo equipInfo_ =  new EquipInfo();
 public bool HasEquipInfo {
 get { return hasEquipInfo; }
 }
 public EquipInfo EquipInfo {
 get { return equipInfo_; }
 set { SetEquipInfo(value); }
 }
 public void SetEquipInfo(EquipInfo value) { 
 hasEquipInfo = true;
 equipInfo_ = value;
 }

public const int petInfoFieldNumber = 9;
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

public const int exTimeFieldNumber = 10;
 private bool hasExTime;
 private Int64 exTime_ = 0;
 public bool HasExTime {
 get { return hasExTime; }
 }
 public Int64 ExTime {
 get { return exTime_; }
 set { SetExTime(value); }
 }
 public void SetExTime(Int64 value) { 
 hasExTime = true;
 exTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAhID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, AhID);
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sid);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Num);
}
 if (HasPriceType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, PriceType);
}
 if (HasPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Price);
}
 if (HasIsShow) {
size += pb::CodedOutputStream.ComputeInt32Size(7, IsShow);
}
{
int subsize = EquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = PetInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasExTime) {
size += pb::CodedOutputStream.ComputeInt64Size(10, ExTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAhID) {
output.WriteInt64(1, AhID);
}
 
if (HasBid) {
output.WriteInt32(2, Bid);
}
 
if (HasSid) {
output.WriteInt32(3, Sid);
}
 
if (HasNum) {
output.WriteInt32(4, Num);
}
 
if (HasPriceType) {
output.WriteInt32(5, PriceType);
}
 
if (HasPrice) {
output.WriteInt32(6, Price);
}
 
if (HasIsShow) {
output.WriteInt32(7, IsShow);
}
{
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)EquipInfo.SerializedSize());
EquipInfo.WriteTo(output);

}
{
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)PetInfo.SerializedSize());
PetInfo.WriteTo(output);

}
 
if (HasExTime) {
output.WriteInt64(10, ExTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 AuctionBackData _inst = (AuctionBackData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AhID = input.ReadInt64();
break;
}
   case  16: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  24: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  32: {
 _inst.Num = input.ReadInt32();
break;
}
   case  40: {
 _inst.PriceType = input.ReadInt32();
break;
}
   case  48: {
 _inst.Price = input.ReadInt32();
break;
}
   case  56: {
 _inst.IsShow = input.ReadInt32();
break;
}
    case  66: {
EquipInfo subBuilder =  new EquipInfo();
 input.ReadMessage(subBuilder);
_inst.EquipInfo = subBuilder;
break;
}
    case  74: {
PetInfo subBuilder =  new PetInfo();
 input.ReadMessage(subBuilder);
_inst.PetInfo = subBuilder;
break;
}
   case  80: {
 _inst.ExTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasEquipInfo) {
if (!EquipInfo.IsInitialized()) return false;
}
  if (HasPetInfo) {
if (!PetInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class AuctionRecordData : PacketDistributed
{

public const int hidFieldNumber = 1;
 private bool hasHid;
 private Int64 hid_ = 0;
 public bool HasHid {
 get { return hasHid; }
 }
 public Int64 Hid {
 get { return hid_; }
 set { SetHid(value); }
 }
 public void SetHid(Int64 value) { 
 hasHid = true;
 hid_ = value;
 }

public const int bidFieldNumber = 2;
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

public const int sidFieldNumber = 3;
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

public const int priceTypeFieldNumber = 5;
 private bool hasPriceType;
 private Int32 priceType_ = 0;
 public bool HasPriceType {
 get { return hasPriceType; }
 }
 public Int32 PriceType {
 get { return priceType_; }
 set { SetPriceType(value); }
 }
 public void SetPriceType(Int32 value) { 
 hasPriceType = true;
 priceType_ = value;
 }

public const int priceFieldNumber = 6;
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

public const int buyTimeFieldNumber = 7;
 private bool hasBuyTime;
 private Int64 buyTime_ = 0;
 public bool HasBuyTime {
 get { return hasBuyTime; }
 }
 public Int64 BuyTime {
 get { return buyTime_; }
 set { SetBuyTime(value); }
 }
 public void SetBuyTime(Int64 value) { 
 hasBuyTime = true;
 buyTime_ = value;
 }

public const int playerNameFieldNumber = 8;
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

public const int playerIDFieldNumber = 9;
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

public const int petNameFieldNumber = 10;
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

public const int petQualityFieldNumber = 11;
 private bool hasPetQuality;
 private Int32 petQuality_ = 0;
 public bool HasPetQuality {
 get { return hasPetQuality; }
 }
 public Int32 PetQuality {
 get { return petQuality_; }
 set { SetPetQuality(value); }
 }
 public void SetPetQuality(Int32 value) { 
 hasPetQuality = true;
 petQuality_ = value;
 }

public const int petLevelFieldNumber = 12;
 private bool hasPetLevel;
 private Int32 petLevel_ = 0;
 public bool HasPetLevel {
 get { return hasPetLevel; }
 }
 public Int32 PetLevel {
 get { return petLevel_; }
 set { SetPetLevel(value); }
 }
 public void SetPetLevel(Int32 value) { 
 hasPetLevel = true;
 petLevel_ = value;
 }

public const int saleVipFieldNumber = 13;
 private bool hasSaleVip;
 private Int32 saleVip_ = 0;
 public bool HasSaleVip {
 get { return hasSaleVip; }
 }
 public Int32 SaleVip {
 get { return saleVip_; }
 set { SetSaleVip(value); }
 }
 public void SetSaleVip(Int32 value) { 
 hasSaleVip = true;
 saleVip_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Hid);
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sid);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Num);
}
 if (HasPriceType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, PriceType);
}
 if (HasPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Price);
}
 if (HasBuyTime) {
size += pb::CodedOutputStream.ComputeInt64Size(7, BuyTime);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(8, PlayerName);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(9, PlayerID);
}
 if (HasPetName) {
size += pb::CodedOutputStream.ComputeStringSize(10, PetName);
}
 if (HasPetQuality) {
size += pb::CodedOutputStream.ComputeInt32Size(11, PetQuality);
}
 if (HasPetLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(12, PetLevel);
}
 if (HasSaleVip) {
size += pb::CodedOutputStream.ComputeInt32Size(13, SaleVip);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHid) {
output.WriteInt64(1, Hid);
}
 
if (HasBid) {
output.WriteInt32(2, Bid);
}
 
if (HasSid) {
output.WriteInt32(3, Sid);
}
 
if (HasNum) {
output.WriteInt32(4, Num);
}
 
if (HasPriceType) {
output.WriteInt32(5, PriceType);
}
 
if (HasPrice) {
output.WriteInt32(6, Price);
}
 
if (HasBuyTime) {
output.WriteInt64(7, BuyTime);
}
 
if (HasPlayerName) {
output.WriteString(8, PlayerName);
}
 
if (HasPlayerID) {
output.WriteInt64(9, PlayerID);
}
 
if (HasPetName) {
output.WriteString(10, PetName);
}
 
if (HasPetQuality) {
output.WriteInt32(11, PetQuality);
}
 
if (HasPetLevel) {
output.WriteInt32(12, PetLevel);
}
 
if (HasSaleVip) {
output.WriteInt32(13, SaleVip);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 AuctionRecordData _inst = (AuctionRecordData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Hid = input.ReadInt64();
break;
}
   case  16: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  24: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  32: {
 _inst.Num = input.ReadInt32();
break;
}
   case  40: {
 _inst.PriceType = input.ReadInt32();
break;
}
   case  48: {
 _inst.Price = input.ReadInt32();
break;
}
   case  56: {
 _inst.BuyTime = input.ReadInt64();
break;
}
   case  66: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  72: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  82: {
 _inst.PetName = input.ReadString();
break;
}
   case  88: {
 _inst.PetQuality = input.ReadInt32();
break;
}
   case  96: {
 _inst.PetLevel = input.ReadInt32();
break;
}
   case  104: {
 _inst.SaleVip = input.ReadInt32();
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
public class CGAuctionBuyShelve : PacketDistributed
{

public const int ahIDFieldNumber = 1;
 private bool hasAhID;
 private Int64 ahID_ = 0;
 public bool HasAhID {
 get { return hasAhID; }
 }
 public Int64 AhID {
 get { return ahID_; }
 set { SetAhID(value); }
 }
 public void SetAhID(Int64 value) { 
 hasAhID = true;
 ahID_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAhID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, AhID);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
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
  
if (HasAhID) {
output.WriteInt64(1, AhID);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGAuctionBuyShelve _inst = (CGAuctionBuyShelve) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AhID = input.ReadInt64();
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
public class CGAuctionSale : PacketDistributed
{

public const int itemIDFieldNumber = 1;
 private bool hasItemID;
 private Int64 itemID_ = 0;
 public bool HasItemID {
 get { return hasItemID; }
 }
 public Int64 ItemID {
 get { return itemID_; }
 set { SetItemID(value); }
 }
 public void SetItemID(Int64 value) { 
 hasItemID = true;
 itemID_ = value;
 }

public const int auctionTypeFieldNumber = 2;
 private bool hasAuctionType;
 private Int32 auctionType_ = 0;
 public bool HasAuctionType {
 get { return hasAuctionType; }
 }
 public Int32 AuctionType {
 get { return auctionType_; }
 set { SetAuctionType(value); }
 }
 public void SetAuctionType(Int32 value) { 
 hasAuctionType = true;
 auctionType_ = value;
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

public const int sellTypeFieldNumber = 4;
 private bool hasSellType;
 private Int32 sellType_ = 0;
 public bool HasSellType {
 get { return hasSellType; }
 }
 public Int32 SellType {
 get { return sellType_; }
 set { SetSellType(value); }
 }
 public void SetSellType(Int32 value) { 
 hasSellType = true;
 sellType_ = value;
 }

public const int unitPriceFieldNumber = 5;
 private bool hasUnitPrice;
 private Int32 unitPrice_ = 0;
 public bool HasUnitPrice {
 get { return hasUnitPrice; }
 }
 public Int32 UnitPrice {
 get { return unitPrice_; }
 set { SetUnitPrice(value); }
 }
 public void SetUnitPrice(Int32 value) { 
 hasUnitPrice = true;
 unitPrice_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasItemID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ItemID);
}
 if (HasAuctionType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, AuctionType);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
}
 if (HasSellType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, SellType);
}
 if (HasUnitPrice) {
size += pb::CodedOutputStream.ComputeInt32Size(5, UnitPrice);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasItemID) {
output.WriteInt64(1, ItemID);
}
 
if (HasAuctionType) {
output.WriteInt32(2, AuctionType);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 
if (HasSellType) {
output.WriteInt32(4, SellType);
}
 
if (HasUnitPrice) {
output.WriteInt32(5, UnitPrice);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGAuctionSale _inst = (CGAuctionSale) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ItemID = input.ReadInt64();
break;
}
   case  16: {
 _inst.AuctionType = input.ReadInt32();
break;
}
   case  24: {
 _inst.Num = input.ReadInt32();
break;
}
   case  32: {
 _inst.SellType = input.ReadInt32();
break;
}
   case  40: {
 _inst.UnitPrice = input.ReadInt32();
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
public class CGGetAucitonList : PacketDistributed
{

public const int getTypeFieldNumber = 1;
 private bool hasGetType;
 private Int32 getType_ = 0;
 public bool HasGetType {
 get { return hasGetType; }
 }
 public Int32 GetType {
 get { return getType_; }
 set { SetGetType(value); }
 }
 public void SetGetType(Int32 value) { 
 hasGetType = true;
 getType_ = value;
 }

public const int bidFieldNumber = 2;
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

public const int sidFieldNumber = 3;
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

public const int jobidFieldNumber = 4;
 private bool hasJobid;
 private Int32 jobid_ = 0;
 public bool HasJobid {
 get { return hasJobid; }
 }
 public Int32 Jobid {
 get { return jobid_; }
 set { SetJobid(value); }
 }
 public void SetJobid(Int32 value) { 
 hasJobid = true;
 jobid_ = value;
 }

public const int sortTypeFieldNumber = 5;
 private bool hasSortType;
 private Int32 sortType_ = 0;
 public bool HasSortType {
 get { return hasSortType; }
 }
 public Int32 SortType {
 get { return sortType_; }
 set { SetSortType(value); }
 }
 public void SetSortType(Int32 value) { 
 hasSortType = true;
 sortType_ = value;
 }

public const int bodyTypeFieldNumber = 6;
 private pbc::PopsicleList<Int32> bodyType_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> bodyTypeList {
 get { return pbc::Lists.AsReadOnly(bodyType_); }
 }
 
 public int bodyTypeCount {
 get { return bodyType_.Count; }
 }
 
public Int32 GetBodyType(int index) {
 return bodyType_[index];
 }
 public void AddBodyType(Int32 value) {
 bodyType_.Add(value);
 }

public const int pageNumFieldNumber = 7;
 private bool hasPageNum;
 private Int32 pageNum_ = 0;
 public bool HasPageNum {
 get { return hasPageNum; }
 }
 public Int32 PageNum {
 get { return pageNum_; }
 set { SetPageNum(value); }
 }
 public void SetPageNum(Int32 value) { 
 hasPageNum = true;
 pageNum_ = value;
 }

public const int searchKeyFieldNumber = 8;
 private bool hasSearchKey;
 private string searchKey_ = "";
 public bool HasSearchKey {
 get { return hasSearchKey; }
 }
 public string SearchKey {
 get { return searchKey_; }
 set { SetSearchKey(value); }
 }
 public void SetSearchKey(string value) { 
 hasSearchKey = true;
 searchKey_ = value;
 }

public const int priceTypeFieldNumber = 9;
 private pbc::PopsicleList<Int32> priceType_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> priceTypeList {
 get { return pbc::Lists.AsReadOnly(priceType_); }
 }
 
 public int priceTypeCount {
 get { return priceType_.Count; }
 }
 
public Int32 GetPriceType(int index) {
 return priceType_[index];
 }
 public void AddPriceType(Int32 value) {
 priceType_.Add(value);
 }

public const int qualityFieldNumber = 10;
 private pbc::PopsicleList<Int32> quality_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> qualityList {
 get { return pbc::Lists.AsReadOnly(quality_); }
 }
 
 public int qualityCount {
 get { return quality_.Count; }
 }
 
public Int32 GetQuality(int index) {
 return quality_[index];
 }
 public void AddQuality(Int32 value) {
 quality_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGetType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GetType);
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sid);
}
 if (HasJobid) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Jobid);
}
 if (HasSortType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, SortType);
}
{
int dataSize = 0;
foreach (Int32 element in bodyTypeList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * bodyType_.Count;
}
 if (HasPageNum) {
size += pb::CodedOutputStream.ComputeInt32Size(7, PageNum);
}
 if (HasSearchKey) {
size += pb::CodedOutputStream.ComputeStringSize(8, SearchKey);
}
{
int dataSize = 0;
foreach (Int32 element in priceTypeList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * priceType_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in qualityList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * quality_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGetType) {
output.WriteInt32(1, GetType);
}
 
if (HasBid) {
output.WriteInt32(2, Bid);
}
 
if (HasSid) {
output.WriteInt32(3, Sid);
}
 
if (HasJobid) {
output.WriteInt32(4, Jobid);
}
 
if (HasSortType) {
output.WriteInt32(5, SortType);
}
{
if (bodyType_.Count > 0) {
foreach (Int32 element in bodyTypeList) {
output.WriteInt32(6,element);
}
}

}
 
if (HasPageNum) {
output.WriteInt32(7, PageNum);
}
 
if (HasSearchKey) {
output.WriteString(8, SearchKey);
}
{
if (priceType_.Count > 0) {
foreach (Int32 element in priceTypeList) {
output.WriteInt32(9,element);
}
}

}
{
if (quality_.Count > 0) {
foreach (Int32 element in qualityList) {
output.WriteInt32(10,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetAucitonList _inst = (CGGetAucitonList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GetType = input.ReadInt32();
break;
}
   case  16: {
 _inst.Bid = input.ReadInt32();
break;
}
   case  24: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  32: {
 _inst.Jobid = input.ReadInt32();
break;
}
   case  40: {
 _inst.SortType = input.ReadInt32();
break;
}
   case  48: {
 _inst.AddBodyType(input.ReadInt32());
break;
}
   case  56: {
 _inst.PageNum = input.ReadInt32();
break;
}
   case  66: {
 _inst.SearchKey = input.ReadString();
break;
}
   case  72: {
 _inst.AddPriceType(input.ReadInt32());
break;
}
   case  80: {
 _inst.AddQuality(input.ReadInt32());
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
public class CGGetAuctionRecordList : PacketDistributed
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
 CGGetAuctionRecordList _inst = (CGGetAuctionRecordList) _base;
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
public class GCAuctionHouseBack : PacketDistributed
{

public const int actionTypeFieldNumber = 1;
 private bool hasActionType;
 private Int32 actionType_ = 0;
 public bool HasActionType {
 get { return hasActionType; }
 }
 public Int32 ActionType {
 get { return actionType_; }
 set { SetActionType(value); }
 }
 public void SetActionType(Int32 value) { 
 hasActionType = true;
 actionType_ = value;
 }

public const int resultCodeFieldNumber = 2;
 private bool hasResultCode;
 private Int32 resultCode_ = 0;
 public bool HasResultCode {
 get { return hasResultCode; }
 }
 public Int32 ResultCode {
 get { return resultCode_; }
 set { SetResultCode(value); }
 }
 public void SetResultCode(Int32 value) { 
 hasResultCode = true;
 resultCode_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasActionType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ActionType);
}
 if (HasResultCode) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ResultCode);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasActionType) {
output.WriteInt32(1, ActionType);
}
 
if (HasResultCode) {
output.WriteInt32(2, ResultCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAuctionHouseBack _inst = (GCAuctionHouseBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ActionType = input.ReadInt32();
break;
}
   case  16: {
 _inst.ResultCode = input.ReadInt32();
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
public class GCGetAucitonListBack : PacketDistributed
{

public const int getTypeFieldNumber = 1;
 private bool hasGetType;
 private Int32 getType_ = 0;
 public bool HasGetType {
 get { return hasGetType; }
 }
 public Int32 GetType {
 get { return getType_; }
 set { SetGetType(value); }
 }
 public void SetGetType(Int32 value) { 
 hasGetType = true;
 getType_ = value;
 }

public const int currentPageFieldNumber = 2;
 private bool hasCurrentPage;
 private Int32 currentPage_ = 0;
 public bool HasCurrentPage {
 get { return hasCurrentPage; }
 }
 public Int32 CurrentPage {
 get { return currentPage_; }
 set { SetCurrentPage(value); }
 }
 public void SetCurrentPage(Int32 value) { 
 hasCurrentPage = true;
 currentPage_ = value;
 }

public const int AllPagesFieldNumber = 3;
 private bool hasAllPages;
 private Int32 AllPages_ = 0;
 public bool HasAllPages {
 get { return hasAllPages; }
 }
 public Int32 AllPages {
 get { return AllPages_; }
 set { SetAllPages(value); }
 }
 public void SetAllPages(Int32 value) { 
 hasAllPages = true;
 AllPages_ = value;
 }

public const int abackDatalistFieldNumber = 4;
 private pbc::PopsicleList<AuctionBackData> abackDatalist_ = new pbc::PopsicleList<AuctionBackData>();
 public scg::IList<AuctionBackData> abackDatalistList {
 get { return pbc::Lists.AsReadOnly(abackDatalist_); }
 }
 
 public int abackDatalistCount {
 get { return abackDatalist_.Count; }
 }
 
public AuctionBackData GetAbackDatalist(int index) {
 return abackDatalist_[index];
 }
 public void AddAbackDatalist(AuctionBackData value) {
 abackDatalist_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGetType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GetType);
}
 if (HasCurrentPage) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CurrentPage);
}
 if (HasAllPages) {
size += pb::CodedOutputStream.ComputeInt32Size(3, AllPages);
}
{
foreach (AuctionBackData element in abackDatalistList) {
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
  
if (HasGetType) {
output.WriteInt32(1, GetType);
}
 
if (HasCurrentPage) {
output.WriteInt32(2, CurrentPage);
}
 
if (HasAllPages) {
output.WriteInt32(3, AllPages);
}

do{
foreach (AuctionBackData element in abackDatalistList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetAucitonListBack _inst = (GCGetAucitonListBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GetType = input.ReadInt32();
break;
}
   case  16: {
 _inst.CurrentPage = input.ReadInt32();
break;
}
   case  24: {
 _inst.AllPages = input.ReadInt32();
break;
}
    case  34: {
AuctionBackData subBuilder =  new AuctionBackData();
input.ReadMessage(subBuilder);
_inst.AddAbackDatalist(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (AuctionBackData element in abackDatalistList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetAuctionRecordListBack : PacketDistributed
{

public const int auctionRecordDataListFieldNumber = 1;
 private pbc::PopsicleList<AuctionRecordData> auctionRecordDataList_ = new pbc::PopsicleList<AuctionRecordData>();
 public scg::IList<AuctionRecordData> auctionRecordDataListList {
 get { return pbc::Lists.AsReadOnly(auctionRecordDataList_); }
 }
 
 public int auctionRecordDataListCount {
 get { return auctionRecordDataList_.Count; }
 }
 
public AuctionRecordData GetAuctionRecordDataList(int index) {
 return auctionRecordDataList_[index];
 }
 public void AddAuctionRecordDataList(AuctionRecordData value) {
 auctionRecordDataList_.Add(value);
 }

public const int resultCodeFieldNumber = 2;
 private bool hasResultCode;
 private Int32 resultCode_ = 0;
 public bool HasResultCode {
 get { return hasResultCode; }
 }
 public Int32 ResultCode {
 get { return resultCode_; }
 set { SetResultCode(value); }
 }
 public void SetResultCode(Int32 value) { 
 hasResultCode = true;
 resultCode_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (AuctionRecordData element in auctionRecordDataListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasResultCode) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ResultCode);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (AuctionRecordData element in auctionRecordDataListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasResultCode) {
output.WriteInt32(2, ResultCode);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetAuctionRecordListBack _inst = (GCGetAuctionRecordListBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
AuctionRecordData subBuilder =  new AuctionRecordData();
input.ReadMessage(subBuilder);
_inst.AddAuctionRecordDataList(subBuilder);
break;
}
   case  16: {
 _inst.ResultCode = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (AuctionRecordData element in auctionRecordDataListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
