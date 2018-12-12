//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGKingClash : PacketDistributed
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

public const int flagFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Operate);
}
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
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
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGKingClash _inst = (CGKingClash) _base;
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
 _inst.Flag = input.ReadInt32();
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
public class ClashNode : PacketDistributed
{

public const int groupIdFieldNumber = 1;
 private bool hasGroupId;
 private string groupId_ = "";
 public bool HasGroupId {
 get { return hasGroupId; }
 }
 public string GroupId {
 get { return groupId_; }
 set { SetGroupId(value); }
 }
 public void SetGroupId(string value) { 
 hasGroupId = true;
 groupId_ = value;
 }

public const int gang1FieldNumber = 2;
 private bool hasGang1;
 private GangClashInfo gang1_ =  new GangClashInfo();
 public bool HasGang1 {
 get { return hasGang1; }
 }
 public GangClashInfo Gang1 {
 get { return gang1_; }
 set { SetGang1(value); }
 }
 public void SetGang1(GangClashInfo value) { 
 hasGang1 = true;
 gang1_ = value;
 }

public const int gang2FieldNumber = 3;
 private bool hasGang2;
 private GangClashInfo gang2_ =  new GangClashInfo();
 public bool HasGang2 {
 get { return hasGang2; }
 }
 public GangClashInfo Gang2 {
 get { return gang2_; }
 set { SetGang2(value); }
 }
 public void SetGang2(GangClashInfo value) { 
 hasGang2 = true;
 gang2_ = value;
 }

public const int clashStatusFieldNumber = 4;
 private bool hasClashStatus;
 private Int32 clashStatus_ = 0;
 public bool HasClashStatus {
 get { return hasClashStatus; }
 }
 public Int32 ClashStatus {
 get { return clashStatus_; }
 set { SetClashStatus(value); }
 }
 public void SetClashStatus(Int32 value) { 
 hasClashStatus = true;
 clashStatus_ = value;
 }

public const int winGangFieldNumber = 5;
 private bool hasWinGang;
 private Int64 winGang_ = 0;
 public bool HasWinGang {
 get { return hasWinGang; }
 }
 public Int64 WinGang {
 get { return winGang_; }
 set { SetWinGang(value); }
 }
 public void SetWinGang(Int64 value) { 
 hasWinGang = true;
 winGang_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGroupId) {
size += pb::CodedOutputStream.ComputeStringSize(1, GroupId);
}
{
int subsize = Gang1.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Gang2.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasClashStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ClashStatus);
}
 if (HasWinGang) {
size += pb::CodedOutputStream.ComputeInt64Size(5, WinGang);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGroupId) {
output.WriteString(1, GroupId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Gang1.SerializedSize());
Gang1.WriteTo(output);

}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Gang2.SerializedSize());
Gang2.WriteTo(output);

}
 
if (HasClashStatus) {
output.WriteInt32(4, ClashStatus);
}
 
if (HasWinGang) {
output.WriteInt64(5, WinGang);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ClashNode _inst = (ClashNode) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.GroupId = input.ReadString();
break;
}
    case  18: {
GangClashInfo subBuilder =  new GangClashInfo();
 input.ReadMessage(subBuilder);
_inst.Gang1 = subBuilder;
break;
}
    case  26: {
GangClashInfo subBuilder =  new GangClashInfo();
 input.ReadMessage(subBuilder);
_inst.Gang2 = subBuilder;
break;
}
   case  32: {
 _inst.ClashStatus = input.ReadInt32();
break;
}
   case  40: {
 _inst.WinGang = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasGang1) {
if (!Gang1.IsInitialized()) return false;
}
  if (HasGang2) {
if (!Gang2.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCKingClash : PacketDistributed
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

public const int statusFieldNumber = 2;
 private bool hasStatus;
 private Int32 status_ = 0;
 public bool HasStatus {
 get { return hasStatus; }
 }
 public Int32 Status {
 get { return status_; }
 set { SetStatus(value); }
 }
 public void SetStatus(Int32 value) { 
 hasStatus = true;
 status_ = value;
 }

public const int nodeLstFieldNumber = 3;
 private pbc::PopsicleList<ClashNode> nodeLst_ = new pbc::PopsicleList<ClashNode>();
 public scg::IList<ClashNode> nodeLstList {
 get { return pbc::Lists.AsReadOnly(nodeLst_); }
 }
 
 public int nodeLstCount {
 get { return nodeLst_.Count; }
 }
 
public ClashNode GetNodeLst(int index) {
 return nodeLst_[index];
 }
 public void AddNodeLst(ClashNode value) {
 nodeLst_.Add(value);
 }

public const int gangPlayerInfoFieldNumber = 4;
 private pbc::PopsicleList<CharacterInfo> gangPlayerInfo_ = new pbc::PopsicleList<CharacterInfo>();
 public scg::IList<CharacterInfo> gangPlayerInfoList {
 get { return pbc::Lists.AsReadOnly(gangPlayerInfo_); }
 }
 
 public int gangPlayerInfoCount {
 get { return gangPlayerInfo_.Count; }
 }
 
public CharacterInfo GetGangPlayerInfo(int index) {
 return gangPlayerInfo_[index];
 }
 public void AddGangPlayerInfo(CharacterInfo value) {
 gangPlayerInfo_.Add(value);
 }

public const int needItemsFieldNumber = 5;
 private pbc::PopsicleList<ItemInfo> needItems_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> needItemsList {
 get { return pbc::Lists.AsReadOnly(needItems_); }
 }
 
 public int needItemsCount {
 get { return needItems_.Count; }
 }
 
public ItemInfo GetNeedItems(int index) {
 return needItems_[index];
 }
 public void AddNeedItems(ItemInfo value) {
 needItems_.Add(value);
 }

public const int lastTimeFieldNumber = 6;
 private bool hasLastTime;
 private Int64 lastTime_ = 0;
 public bool HasLastTime {
 get { return hasLastTime; }
 }
 public Int64 LastTime {
 get { return lastTime_; }
 set { SetLastTime(value); }
 }
 public void SetLastTime(Int64 value) { 
 hasLastTime = true;
 lastTime_ = value;
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
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
}
{
foreach (ClashNode element in nodeLstList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (CharacterInfo element in gangPlayerInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (ItemInfo element in needItemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasLastTime) {
size += pb::CodedOutputStream.ComputeInt64Size(6, LastTime);
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
 
if (HasStatus) {
output.WriteInt32(2, Status);
}

do{
foreach (ClashNode element in nodeLstList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (CharacterInfo element in gangPlayerInfoList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (ItemInfo element in needItemsList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasLastTime) {
output.WriteInt64(6, LastTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCKingClash _inst = (GCKingClash) _base;
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
 _inst.Status = input.ReadInt32();
break;
}
    case  26: {
ClashNode subBuilder =  new ClashNode();
input.ReadMessage(subBuilder);
_inst.AddNodeLst(subBuilder);
break;
}
    case  34: {
CharacterInfo subBuilder =  new CharacterInfo();
input.ReadMessage(subBuilder);
_inst.AddGangPlayerInfo(subBuilder);
break;
}
    case  42: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddNeedItems(subBuilder);
break;
}
   case  48: {
 _inst.LastTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ClashNode element in nodeLstList) {
if (!element.IsInitialized()) return false;
}
foreach (CharacterInfo element in gangPlayerInfoList) {
if (!element.IsInitialized()) return false;
}
foreach (ItemInfo element in needItemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCKingClashFightInfo : PacketDistributed
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

public const int lastTimeFieldNumber = 2;
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

public const int gangSelfKillFieldNumber = 3;
 private bool hasGangSelfKill;
 private Int32 gangSelfKill_ = 0;
 public bool HasGangSelfKill {
 get { return hasGangSelfKill; }
 }
 public Int32 GangSelfKill {
 get { return gangSelfKill_; }
 set { SetGangSelfKill(value); }
 }
 public void SetGangSelfKill(Int32 value) { 
 hasGangSelfKill = true;
 gangSelfKill_ = value;
 }

public const int gangEnemyKillFieldNumber = 4;
 private bool hasGangEnemyKill;
 private Int32 gangEnemyKill_ = 0;
 public bool HasGangEnemyKill {
 get { return hasGangEnemyKill; }
 }
 public Int32 GangEnemyKill {
 get { return gangEnemyKill_; }
 set { SetGangEnemyKill(value); }
 }
 public void SetGangEnemyKill(Int32 value) { 
 hasGangEnemyKill = true;
 gangEnemyKill_ = value;
 }

public const int gangSelfNumFieldNumber = 5;
 private bool hasGangSelfNum;
 private Int32 gangSelfNum_ = 0;
 public bool HasGangSelfNum {
 get { return hasGangSelfNum; }
 }
 public Int32 GangSelfNum {
 get { return gangSelfNum_; }
 set { SetGangSelfNum(value); }
 }
 public void SetGangSelfNum(Int32 value) { 
 hasGangSelfNum = true;
 gangSelfNum_ = value;
 }

public const int gangEnemyNumFieldNumber = 6;
 private bool hasGangEnemyNum;
 private Int32 gangEnemyNum_ = 0;
 public bool HasGangEnemyNum {
 get { return hasGangEnemyNum; }
 }
 public Int32 GangEnemyNum {
 get { return gangEnemyNum_; }
 set { SetGangEnemyNum(value); }
 }
 public void SetGangEnemyNum(Int32 value) { 
 hasGangEnemyNum = true;
 gangEnemyNum_ = value;
 }

public const int gang1LstFieldNumber = 7;
 private pbc::PopsicleList<KingOneInfo> gang1Lst_ = new pbc::PopsicleList<KingOneInfo>();
 public scg::IList<KingOneInfo> gang1LstList {
 get { return pbc::Lists.AsReadOnly(gang1Lst_); }
 }
 
 public int gang1LstCount {
 get { return gang1Lst_.Count; }
 }
 
public KingOneInfo GetGang1Lst(int index) {
 return gang1Lst_[index];
 }
 public void AddGang1Lst(KingOneInfo value) {
 gang1Lst_.Add(value);
 }

public const int resultFieldNumber = 8;
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

public const int rewardsFieldNumber = 9;
 private pbc::PopsicleList<ItemInfo> rewards_ = new pbc::PopsicleList<ItemInfo>();
 public scg::IList<ItemInfo> rewardsList {
 get { return pbc::Lists.AsReadOnly(rewards_); }
 }
 
 public int rewardsCount {
 get { return rewards_.Count; }
 }
 
public ItemInfo GetRewards(int index) {
 return rewards_[index];
 }
 public void AddRewards(ItemInfo value) {
 rewards_.Add(value);
 }

public const int gangSelfNameFieldNumber = 10;
 private bool hasGangSelfName;
 private string gangSelfName_ = "";
 public bool HasGangSelfName {
 get { return hasGangSelfName; }
 }
 public string GangSelfName {
 get { return gangSelfName_; }
 set { SetGangSelfName(value); }
 }
 public void SetGangSelfName(string value) { 
 hasGangSelfName = true;
 gangSelfName_ = value;
 }

public const int gangEnemyNameFieldNumber = 11;
 private bool hasGangEnemyName;
 private string gangEnemyName_ = "";
 public bool HasGangEnemyName {
 get { return hasGangEnemyName; }
 }
 public string GangEnemyName {
 get { return gangEnemyName_; }
 set { SetGangEnemyName(value); }
 }
 public void SetGangEnemyName(string value) { 
 hasGangEnemyName = true;
 gangEnemyName_ = value;
 }

public const int typeFieldNumber = 12;
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
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
}
 if (HasLastTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LastTime);
}
 if (HasGangSelfKill) {
size += pb::CodedOutputStream.ComputeInt32Size(3, GangSelfKill);
}
 if (HasGangEnemyKill) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GangEnemyKill);
}
 if (HasGangSelfNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, GangSelfNum);
}
 if (HasGangEnemyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(6, GangEnemyNum);
}
{
foreach (KingOneInfo element in gang1LstList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Result);
}
{
foreach (ItemInfo element in rewardsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)9) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasGangSelfName) {
size += pb::CodedOutputStream.ComputeStringSize(10, GangSelfName);
}
 if (HasGangEnemyName) {
size += pb::CodedOutputStream.ComputeStringSize(11, GangEnemyName);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(12, Type);
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
 
if (HasLastTime) {
output.WriteInt32(2, LastTime);
}
 
if (HasGangSelfKill) {
output.WriteInt32(3, GangSelfKill);
}
 
if (HasGangEnemyKill) {
output.WriteInt32(4, GangEnemyKill);
}
 
if (HasGangSelfNum) {
output.WriteInt32(5, GangSelfNum);
}
 
if (HasGangEnemyNum) {
output.WriteInt32(6, GangEnemyNum);
}

do{
foreach (KingOneInfo element in gang1LstList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasResult) {
output.WriteInt32(8, Result);
}

do{
foreach (ItemInfo element in rewardsList) {
output.WriteTag((int)9, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasGangSelfName) {
output.WriteString(10, GangSelfName);
}
 
if (HasGangEnemyName) {
output.WriteString(11, GangEnemyName);
}
 
if (HasType) {
output.WriteInt32(12, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCKingClashFightInfo _inst = (GCKingClashFightInfo) _base;
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
 _inst.LastTime = input.ReadInt32();
break;
}
   case  24: {
 _inst.GangSelfKill = input.ReadInt32();
break;
}
   case  32: {
 _inst.GangEnemyKill = input.ReadInt32();
break;
}
   case  40: {
 _inst.GangSelfNum = input.ReadInt32();
break;
}
   case  48: {
 _inst.GangEnemyNum = input.ReadInt32();
break;
}
    case  58: {
KingOneInfo subBuilder =  new KingOneInfo();
input.ReadMessage(subBuilder);
_inst.AddGang1Lst(subBuilder);
break;
}
   case  64: {
 _inst.Result = input.ReadInt32();
break;
}
    case  74: {
ItemInfo subBuilder =  new ItemInfo();
input.ReadMessage(subBuilder);
_inst.AddRewards(subBuilder);
break;
}
   case  82: {
 _inst.GangSelfName = input.ReadString();
break;
}
   case  90: {
 _inst.GangEnemyName = input.ReadString();
break;
}
   case  96: {
 _inst.Type = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (KingOneInfo element in gang1LstList) {
if (!element.IsInitialized()) return false;
}
foreach (ItemInfo element in rewardsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GangClashInfo : PacketDistributed
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
 GangClashInfo _inst = (GangClashInfo) _base;
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
public class KingOneInfo : PacketDistributed
{

public const int puidFieldNumber = 1;
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

public const int jobFieldNumber = 3;
 private bool hasJob;
 private Int32 job_ = 0;
 public bool HasJob {
 get { return hasJob; }
 }
 public Int32 Job {
 get { return job_; }
 set { SetJob(value); }
 }
 public void SetJob(Int32 value) { 
 hasJob = true;
 job_ = value;
 }

public const int gangIdFieldNumber = 4;
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

public const int killNumFieldNumber = 5;
 private bool hasKillNum;
 private Int32 killNum_ = 0;
 public bool HasKillNum {
 get { return hasKillNum; }
 }
 public Int32 KillNum {
 get { return killNum_; }
 set { SetKillNum(value); }
 }
 public void SetKillNum(Int32 value) { 
 hasKillNum = true;
 killNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPuid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Puid);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasJob) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Job);
}
 if (HasGangId) {
size += pb::CodedOutputStream.ComputeInt64Size(4, GangId);
}
 if (HasKillNum) {
size += pb::CodedOutputStream.ComputeInt32Size(5, KillNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPuid) {
output.WriteInt64(1, Puid);
}
 
if (HasName) {
output.WriteString(2, Name);
}
 
if (HasJob) {
output.WriteInt32(3, Job);
}
 
if (HasGangId) {
output.WriteInt64(4, GangId);
}
 
if (HasKillNum) {
output.WriteInt32(5, KillNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 KingOneInfo _inst = (KingOneInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Puid = input.ReadInt64();
break;
}
   case  18: {
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.Job = input.ReadInt32();
break;
}
   case  32: {
 _inst.GangId = input.ReadInt64();
break;
}
   case  40: {
 _inst.KillNum = input.ReadInt32();
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
