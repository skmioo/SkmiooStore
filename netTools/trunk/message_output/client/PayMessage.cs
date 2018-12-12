//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCreateOrder : PacketDistributed
{

public const int sidFieldNumber = 1;
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

public const int apppOrderIDFieldNumber = 2;
 private bool hasApppOrderID;
 private string apppOrderID_ = "";
 public bool HasApppOrderID {
 get { return hasApppOrderID; }
 }
 public string ApppOrderID {
 get { return apppOrderID_; }
 set { SetApppOrderID(value); }
 }
 public void SetApppOrderID(string value) { 
 hasApppOrderID = true;
 apppOrderID_ = value;
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

public const int parseFieldNumber = 4;
 private bool hasParse;
 private string parse_ = "";
 public bool HasParse {
 get { return hasParse; }
 }
 public string Parse {
 get { return parse_; }
 set { SetParse(value); }
 }
 public void SetParse(string value) { 
 hasParse = true;
 parse_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sid);
}
 if (HasApppOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(2, ApppOrderID);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlatForm);
}
 if (HasParse) {
size += pb::CodedOutputStream.ComputeStringSize(4, Parse);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSid) {
output.WriteInt32(1, Sid);
}
 
if (HasApppOrderID) {
output.WriteString(2, ApppOrderID);
}
 
if (HasPlatForm) {
output.WriteString(3, PlatForm);
}
 
if (HasParse) {
output.WriteString(4, Parse);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCreateOrder _inst = (CGCreateOrder) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  18: {
 _inst.ApppOrderID = input.ReadString();
break;
}
   case  26: {
 _inst.PlatForm = input.ReadString();
break;
}
   case  34: {
 _inst.Parse = input.ReadString();
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
public class CGGetOrderState : PacketDistributed
{

public const int orderIDFieldNumber = 1;
 private bool hasOrderID;
 private string orderID_ = "";
 public bool HasOrderID {
 get { return hasOrderID; }
 }
 public string OrderID {
 get { return orderID_; }
 set { SetOrderID(value); }
 }
 public void SetOrderID(string value) { 
 hasOrderID = true;
 orderID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(1, OrderID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOrderID) {
output.WriteString(1, OrderID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetOrderState _inst = (CGGetOrderState) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.OrderID = input.ReadString();
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
public class CGVerifyIOSPay : PacketDistributed
{

public const int orderIDFieldNumber = 1;
 private bool hasOrderID;
 private string orderID_ = "";
 public bool HasOrderID {
 get { return hasOrderID; }
 }
 public string OrderID {
 get { return orderID_; }
 set { SetOrderID(value); }
 }
 public void SetOrderID(string value) { 
 hasOrderID = true;
 orderID_ = value;
 }

public const int receiptFieldNumber = 2;
 private bool hasReceipt;
 private string receipt_ = "";
 public bool HasReceipt {
 get { return hasReceipt; }
 }
 public string Receipt {
 get { return receipt_; }
 set { SetReceipt(value); }
 }
 public void SetReceipt(string value) { 
 hasReceipt = true;
 receipt_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(1, OrderID);
}
 if (HasReceipt) {
size += pb::CodedOutputStream.ComputeStringSize(2, Receipt);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOrderID) {
output.WriteString(1, OrderID);
}
 
if (HasReceipt) {
output.WriteString(2, Receipt);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGVerifyIOSPay _inst = (CGVerifyIOSPay) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.OrderID = input.ReadString();
break;
}
   case  18: {
 _inst.Receipt = input.ReadString();
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
public class GCCreateOrderBack : PacketDistributed
{

public const int orderInfoFieldNumber = 1;
 private bool hasOrderInfo;
 private OrderInfo orderInfo_ =  new OrderInfo();
 public bool HasOrderInfo {
 get { return hasOrderInfo; }
 }
 public OrderInfo OrderInfo {
 get { return orderInfo_; }
 set { SetOrderInfo(value); }
 }
 public void SetOrderInfo(OrderInfo value) { 
 hasOrderInfo = true;
 orderInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = OrderInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)OrderInfo.SerializedSize());
OrderInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreateOrderBack _inst = (GCCreateOrderBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
OrderInfo subBuilder =  new OrderInfo();
 input.ReadMessage(subBuilder);
_inst.OrderInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasOrderInfo) {
if (!OrderInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCOrderStateBack : PacketDistributed
{

public const int orderIDFieldNumber = 1;
 private bool hasOrderID;
 private string orderID_ = "";
 public bool HasOrderID {
 get { return hasOrderID; }
 }
 public string OrderID {
 get { return orderID_; }
 set { SetOrderID(value); }
 }
 public void SetOrderID(string value) { 
 hasOrderID = true;
 orderID_ = value;
 }

public const int stateFieldNumber = 2;
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
  if (HasOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(1, OrderID);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(2, State);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOrderID) {
output.WriteString(1, OrderID);
}
 
if (HasState) {
output.WriteInt32(2, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOrderStateBack _inst = (GCOrderStateBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.OrderID = input.ReadString();
break;
}
   case  16: {
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
public class GCRechargeItemInfo : PacketDistributed
{

public const int rechargeItemListFieldNumber = 1;
 private pbc::PopsicleList<RechargeItem> rechargeItemList_ = new pbc::PopsicleList<RechargeItem>();
 public scg::IList<RechargeItem> rechargeItemListList {
 get { return pbc::Lists.AsReadOnly(rechargeItemList_); }
 }
 
 public int rechargeItemListCount {
 get { return rechargeItemList_.Count; }
 }
 
public RechargeItem GetRechargeItemList(int index) {
 return rechargeItemList_[index];
 }
 public void AddRechargeItemList(RechargeItem value) {
 rechargeItemList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RechargeItem element in rechargeItemListList) {
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
foreach (RechargeItem element in rechargeItemListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRechargeItemInfo _inst = (GCRechargeItemInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RechargeItem subBuilder =  new RechargeItem();
input.ReadMessage(subBuilder);
_inst.AddRechargeItemList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RechargeItem element in rechargeItemListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCVerifyIOSPayBack : PacketDistributed
{

public const int orderIDFieldNumber = 1;
 private bool hasOrderID;
 private string orderID_ = "";
 public bool HasOrderID {
 get { return hasOrderID; }
 }
 public string OrderID {
 get { return orderID_; }
 set { SetOrderID(value); }
 }
 public void SetOrderID(string value) { 
 hasOrderID = true;
 orderID_ = value;
 }

public const int transaction_idFieldNumber = 2;
 private bool hasTransaction_id;
 private string transaction_id_ = "";
 public bool HasTransaction_id {
 get { return hasTransaction_id; }
 }
 public string Transaction_id {
 get { return transaction_id_; }
 set { SetTransaction_id(value); }
 }
 public void SetTransaction_id(string value) { 
 hasTransaction_id = true;
 transaction_id_ = value;
 }

public const int stateFieldNumber = 3;
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
  if (HasOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(1, OrderID);
}
 if (HasTransaction_id) {
size += pb::CodedOutputStream.ComputeStringSize(2, Transaction_id);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(3, State);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOrderID) {
output.WriteString(1, OrderID);
}
 
if (HasTransaction_id) {
output.WriteString(2, Transaction_id);
}
 
if (HasState) {
output.WriteInt32(3, State);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCVerifyIOSPayBack _inst = (GCVerifyIOSPayBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.OrderID = input.ReadString();
break;
}
   case  18: {
 _inst.Transaction_id = input.ReadString();
break;
}
   case  24: {
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
public class OrderInfo : PacketDistributed
{

public const int orderIDFieldNumber = 1;
 private bool hasOrderID;
 private string orderID_ = "";
 public bool HasOrderID {
 get { return hasOrderID; }
 }
 public string OrderID {
 get { return orderID_; }
 set { SetOrderID(value); }
 }
 public void SetOrderID(string value) { 
 hasOrderID = true;
 orderID_ = value;
 }

public const int playerIDFieldNumber = 2;
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

public const int stateFieldNumber = 4;
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

public const int createTimeFieldNumber = 5;
 private bool hasCreateTime;
 private string createTime_ = "";
 public bool HasCreateTime {
 get { return hasCreateTime; }
 }
 public string CreateTime {
 get { return createTime_; }
 set { SetCreateTime(value); }
 }
 public void SetCreateTime(string value) { 
 hasCreateTime = true;
 createTime_ = value;
 }

public const int moneyFieldNumber = 6;
 private bool hasMoney;
 private Int32 money_ = 0;
 public bool HasMoney {
 get { return hasMoney; }
 }
 public Int32 Money {
 get { return money_; }
 set { SetMoney(value); }
 }
 public void SetMoney(Int32 value) { 
 hasMoney = true;
 money_ = value;
 }

public const int platFormFieldNumber = 7;
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

public const int apppOrderIDFieldNumber = 8;
 private bool hasApppOrderID;
 private string apppOrderID_ = "";
 public bool HasApppOrderID {
 get { return hasApppOrderID; }
 }
 public string ApppOrderID {
 get { return apppOrderID_; }
 set { SetApppOrderID(value); }
 }
 public void SetApppOrderID(string value) { 
 hasApppOrderID = true;
 apppOrderID_ = value;
 }

public const int serverIDFieldNumber = 9;
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

public const int sidFieldNumber = 10;
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

public const int accountIDFieldNumber = 11;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(1, OrderID);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PlayerID);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(4, State);
}
 if (HasCreateTime) {
size += pb::CodedOutputStream.ComputeStringSize(5, CreateTime);
}
 if (HasMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Money);
}
 if (HasPlatForm) {
size += pb::CodedOutputStream.ComputeStringSize(7, PlatForm);
}
 if (HasApppOrderID) {
size += pb::CodedOutputStream.ComputeStringSize(8, ApppOrderID);
}
 if (HasServerID) {
size += pb::CodedOutputStream.ComputeInt32Size(9, ServerID);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(10, Sid);
}
 if (HasAccountID) {
size += pb::CodedOutputStream.ComputeInt64Size(11, AccountID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOrderID) {
output.WriteString(1, OrderID);
}
 
if (HasPlayerID) {
output.WriteInt64(2, PlayerID);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 
if (HasState) {
output.WriteInt32(4, State);
}
 
if (HasCreateTime) {
output.WriteString(5, CreateTime);
}
 
if (HasMoney) {
output.WriteInt32(6, Money);
}
 
if (HasPlatForm) {
output.WriteString(7, PlatForm);
}
 
if (HasApppOrderID) {
output.WriteString(8, ApppOrderID);
}
 
if (HasServerID) {
output.WriteInt32(9, ServerID);
}
 
if (HasSid) {
output.WriteInt32(10, Sid);
}
 
if (HasAccountID) {
output.WriteInt64(11, AccountID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 OrderInfo _inst = (OrderInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.OrderID = input.ReadString();
break;
}
   case  16: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  24: {
 _inst.Type = input.ReadInt32();
break;
}
   case  32: {
 _inst.State = input.ReadInt32();
break;
}
   case  42: {
 _inst.CreateTime = input.ReadString();
break;
}
   case  48: {
 _inst.Money = input.ReadInt32();
break;
}
   case  58: {
 _inst.PlatForm = input.ReadString();
break;
}
   case  66: {
 _inst.ApppOrderID = input.ReadString();
break;
}
   case  72: {
 _inst.ServerID = input.ReadInt32();
break;
}
   case  80: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  88: {
 _inst.AccountID = input.ReadInt64();
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
public class RechargeItem : PacketDistributed
{

public const int sidFieldNumber = 1;
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

public const int curTimesFieldNumber = 2;
 private bool hasCurTimes;
 private Int32 curTimes_ = 0;
 public bool HasCurTimes {
 get { return hasCurTimes; }
 }
 public Int32 CurTimes {
 get { return curTimes_; }
 set { SetCurTimes(value); }
 }
 public void SetCurTimes(Int32 value) { 
 hasCurTimes = true;
 curTimes_ = value;
 }

public const int maxTimesFieldNumber = 3;
 private bool hasMaxTimes;
 private Int32 maxTimes_ = 0;
 public bool HasMaxTimes {
 get { return hasMaxTimes; }
 }
 public Int32 MaxTimes {
 get { return maxTimes_; }
 set { SetMaxTimes(value); }
 }
 public void SetMaxTimes(Int32 value) { 
 hasMaxTimes = true;
 maxTimes_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Sid);
}
 if (HasCurTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CurTimes);
}
 if (HasMaxTimes) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MaxTimes);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSid) {
output.WriteInt32(1, Sid);
}
 
if (HasCurTimes) {
output.WriteInt32(2, CurTimes);
}
 
if (HasMaxTimes) {
output.WriteInt32(3, MaxTimes);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RechargeItem _inst = (RechargeItem) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  16: {
 _inst.CurTimes = input.ReadInt32();
break;
}
   case  24: {
 _inst.MaxTimes = input.ReadInt32();
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
