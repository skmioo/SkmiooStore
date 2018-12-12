//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class Achievement : PacketDistributed
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

public const int isoverFieldNumber = 2;
 private bool hasIsover;
 private Int32 isover_ = 0;
 public bool HasIsover {
 get { return hasIsover; }
 }
 public Int32 Isover {
 get { return isover_; }
 set { SetIsover(value); }
 }
 public void SetIsover(Int32 value) { 
 hasIsover = true;
 isover_ = value;
 }

public const int isgetFieldNumber = 3;
 private bool hasIsget;
 private Int32 isget_ = 0;
 public bool HasIsget {
 get { return hasIsget; }
 }
 public Int32 Isget {
 get { return isget_; }
 set { SetIsget(value); }
 }
 public void SetIsget(Int32 value) { 
 hasIsget = true;
 isget_ = value;
 }

public const int valueFieldNumber = 4;
 private bool hasValue;
 private Int64 value_ = 0;
 public bool HasValue {
 get { return hasValue; }
 }
 public Int64 Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(Int64 value) { 
 hasValue = true;
 value_ = value;
 }

public const int getachievetimeFieldNumber = 5;
 private bool hasGetachievetime;
 private Int64 getachievetime_ = 0;
 public bool HasGetachievetime {
 get { return hasGetachievetime; }
 }
 public Int64 Getachievetime {
 get { return getachievetime_; }
 set { SetGetachievetime(value); }
 }
 public void SetGetachievetime(Int64 value) { 
 hasGetachievetime = true;
 getachievetime_ = value;
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
 if (HasIsover) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Isover);
}
 if (HasIsget) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Isget);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeInt64Size(4, Value);
}
 if (HasGetachievetime) {
size += pb::CodedOutputStream.ComputeInt64Size(5, Getachievetime);
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
 
if (HasIsover) {
output.WriteInt32(2, Isover);
}
 
if (HasIsget) {
output.WriteInt32(3, Isget);
}
 
if (HasValue) {
output.WriteInt64(4, Value);
}
 
if (HasGetachievetime) {
output.WriteInt64(5, Getachievetime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Achievement _inst = (Achievement) _base;
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
 _inst.Isover = input.ReadInt32();
break;
}
   case  24: {
 _inst.Isget = input.ReadInt32();
break;
}
   case  32: {
 _inst.Value = input.ReadInt64();
break;
}
   case  40: {
 _inst.Getachievetime = input.ReadInt64();
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
public class CGVerifyBoxResult : PacketDistributed
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

public const int operateFieldNumber = 2;
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

public const int paramsFieldNumber = 3;
 private pbc::PopsicleList<string> params_ = new pbc::PopsicleList<string>();
 public scg::IList<string> paramsList {
 get { return pbc::Lists.AsReadOnly(params_); }
 }
 
 public int paramsCount {
 get { return params_.Count; }
 }
 
public string GetParams(int index) {
 return params_[index];
 }
 public void AddParams(string value) {
 params_.Add(value);
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
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
{
int dataSize = 0;
foreach (string element in paramsList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * params_.Count;
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
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}
{
if (params_.Count > 0) {
foreach (string element in paramsList) {
output.WriteString(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGVerifyBoxResult _inst = (CGVerifyBoxResult) _base;
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
 _inst.Operate = input.ReadInt32();
break;
}
   case  26: {
 _inst.AddParams(input.ReadString());
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
public class ChangeEquipInfo : PacketDistributed
{

public const int hairFieldNumber = 1;
 private bool hasHair;
 private Int32 hair_ = 0;
 public bool HasHair {
 get { return hasHair; }
 }
 public Int32 Hair {
 get { return hair_; }
 set { SetHair(value); }
 }
 public void SetHair(Int32 value) { 
 hasHair = true;
 hair_ = value;
 }

public const int faceFieldNumber = 2;
 private bool hasFace;
 private Int32 face_ = 0;
 public bool HasFace {
 get { return hasFace; }
 }
 public Int32 Face {
 get { return face_; }
 set { SetFace(value); }
 }
 public void SetFace(Int32 value) { 
 hasFace = true;
 face_ = value;
 }

public const int weaponFieldNumber = 3;
 private bool hasWeapon;
 private Int32 weapon_ = 0;
 public bool HasWeapon {
 get { return hasWeapon; }
 }
 public Int32 Weapon {
 get { return weapon_; }
 set { SetWeapon(value); }
 }
 public void SetWeapon(Int32 value) { 
 hasWeapon = true;
 weapon_ = value;
 }

public const int clothesFieldNumber = 4;
 private bool hasClothes;
 private Int32 clothes_ = 0;
 public bool HasClothes {
 get { return hasClothes; }
 }
 public Int32 Clothes {
 get { return clothes_; }
 set { SetClothes(value); }
 }
 public void SetClothes(Int32 value) { 
 hasClothes = true;
 clothes_ = value;
 }

public const int fashionClothesFieldNumber = 5;
 private bool hasFashionClothes;
 private Int32 fashionClothes_ = 0;
 public bool HasFashionClothes {
 get { return hasFashionClothes; }
 }
 public Int32 FashionClothes {
 get { return fashionClothes_; }
 set { SetFashionClothes(value); }
 }
 public void SetFashionClothes(Int32 value) { 
 hasFashionClothes = true;
 fashionClothes_ = value;
 }

public const int fashionWeaponFieldNumber = 6;
 private bool hasFashionWeapon;
 private Int32 fashionWeapon_ = 0;
 public bool HasFashionWeapon {
 get { return hasFashionWeapon; }
 }
 public Int32 FashionWeapon {
 get { return fashionWeapon_; }
 set { SetFashionWeapon(value); }
 }
 public void SetFashionWeapon(Int32 value) { 
 hasFashionWeapon = true;
 fashionWeapon_ = value;
 }

public const int fashionHairFieldNumber = 7;
 private bool hasFashionHair;
 private Int32 fashionHair_ = 0;
 public bool HasFashionHair {
 get { return hasFashionHair; }
 }
 public Int32 FashionHair {
 get { return fashionHair_; }
 set { SetFashionHair(value); }
 }
 public void SetFashionHair(Int32 value) { 
 hasFashionHair = true;
 fashionHair_ = value;
 }

public const int isviewFieldNumber = 8;
 private bool hasIsview;
 private Int32 isview_ = 0;
 public bool HasIsview {
 get { return hasIsview; }
 }
 public Int32 Isview {
 get { return isview_; }
 set { SetIsview(value); }
 }
 public void SetIsview(Int32 value) { 
 hasIsview = true;
 isview_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasHair) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Hair);
}
 if (HasFace) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Face);
}
 if (HasWeapon) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Weapon);
}
 if (HasClothes) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Clothes);
}
 if (HasFashionClothes) {
size += pb::CodedOutputStream.ComputeInt32Size(5, FashionClothes);
}
 if (HasFashionWeapon) {
size += pb::CodedOutputStream.ComputeInt32Size(6, FashionWeapon);
}
 if (HasFashionHair) {
size += pb::CodedOutputStream.ComputeInt32Size(7, FashionHair);
}
 if (HasIsview) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Isview);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasHair) {
output.WriteInt32(1, Hair);
}
 
if (HasFace) {
output.WriteInt32(2, Face);
}
 
if (HasWeapon) {
output.WriteInt32(3, Weapon);
}
 
if (HasClothes) {
output.WriteInt32(4, Clothes);
}
 
if (HasFashionClothes) {
output.WriteInt32(5, FashionClothes);
}
 
if (HasFashionWeapon) {
output.WriteInt32(6, FashionWeapon);
}
 
if (HasFashionHair) {
output.WriteInt32(7, FashionHair);
}
 
if (HasIsview) {
output.WriteInt32(8, Isview);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ChangeEquipInfo _inst = (ChangeEquipInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Hair = input.ReadInt32();
break;
}
   case  16: {
 _inst.Face = input.ReadInt32();
break;
}
   case  24: {
 _inst.Weapon = input.ReadInt32();
break;
}
   case  32: {
 _inst.Clothes = input.ReadInt32();
break;
}
   case  40: {
 _inst.FashionClothes = input.ReadInt32();
break;
}
   case  48: {
 _inst.FashionWeapon = input.ReadInt32();
break;
}
   case  56: {
 _inst.FashionHair = input.ReadInt32();
break;
}
   case  64: {
 _inst.Isview = input.ReadInt32();
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
public class CharacterAttr : PacketDistributed
{

public const int attrkeyFieldNumber = 1;
 private bool hasAttrkey;
 private Int32 attrkey_ = 0;
 public bool HasAttrkey {
 get { return hasAttrkey; }
 }
 public Int32 Attrkey {
 get { return attrkey_; }
 set { SetAttrkey(value); }
 }
 public void SetAttrkey(Int32 value) { 
 hasAttrkey = true;
 attrkey_ = value;
 }

public const int attrvalueFieldNumber = 2;
 private bool hasAttrvalue;
 private Int64 attrvalue_ = 0;
 public bool HasAttrvalue {
 get { return hasAttrvalue; }
 }
 public Int64 Attrvalue {
 get { return attrvalue_; }
 set { SetAttrvalue(value); }
 }
 public void SetAttrvalue(Int64 value) { 
 hasAttrvalue = true;
 attrvalue_ = value;
 }

public const int viewflagFieldNumber = 3;
 private bool hasViewflag;
 private Int32 viewflag_ = 0;
 public bool HasViewflag {
 get { return hasViewflag; }
 }
 public Int32 Viewflag {
 get { return viewflag_; }
 set { SetViewflag(value); }
 }
 public void SetViewflag(Int32 value) { 
 hasViewflag = true;
 viewflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAttrkey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Attrkey);
}
 if (HasAttrvalue) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Attrvalue);
}
 if (HasViewflag) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Viewflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAttrkey) {
output.WriteInt32(1, Attrkey);
}
 
if (HasAttrvalue) {
output.WriteInt64(2, Attrvalue);
}
 
if (HasViewflag) {
output.WriteInt32(3, Viewflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CharacterAttr _inst = (CharacterAttr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Attrkey = input.ReadInt32();
break;
}
   case  16: {
 _inst.Attrvalue = input.ReadInt64();
break;
}
   case  24: {
 _inst.Viewflag = input.ReadInt32();
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
public class CharacterInfo : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int charNameFieldNumber = 2;
 private bool hasCharName;
 private string charName_ = "";
 public bool HasCharName {
 get { return hasCharName; }
 }
 public string CharName {
 get { return charName_; }
 set { SetCharName(value); }
 }
 public void SetCharName(string value) { 
 hasCharName = true;
 charName_ = value;
 }

public const int posFieldNumber = 3;
 private bool hasPos;
 private Vector3Info pos_ =  new Vector3Info();
 public bool HasPos {
 get { return hasPos; }
 }
 public Vector3Info Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Vector3Info value) { 
 hasPos = true;
 pos_ = value;
 }

public const int directionFieldNumber = 4;
 private bool hasDirection;
 private Vector3Info direction_ =  new Vector3Info();
 public bool HasDirection {
 get { return hasDirection; }
 }
 public Vector3Info Direction {
 get { return direction_; }
 set { SetDirection(value); }
 }
 public void SetDirection(Vector3Info value) { 
 hasDirection = true;
 direction_ = value;
 }

public const int sidFieldNumber = 5;
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

public const int bidFieldNumber = 6;
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

public const int charAttrFieldNumber = 7;
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

public const int interactIdFieldNumber = 9;
 private bool hasInteractId;
 private string interactId_ = "";
 public bool HasInteractId {
 get { return hasInteractId; }
 }
 public string InteractId {
 get { return interactId_; }
 set { SetInteractId(value); }
 }
 public void SetInteractId(string value) { 
 hasInteractId = true;
 interactId_ = value;
 }

public const int liveTimeFieldNumber = 10;
 private bool hasLiveTime;
 private Int32 liveTime_ = 0;
 public bool HasLiveTime {
 get { return hasLiveTime; }
 }
 public Int32 LiveTime {
 get { return liveTime_; }
 set { SetLiveTime(value); }
 }
 public void SetLiveTime(Int32 value) { 
 hasLiveTime = true;
 liveTime_ = value;
 }

public const int redcrossFieldNumber = 12;
 private bool hasRedcross;
 private RedCross redcross_ =  new RedCross();
 public bool HasRedcross {
 get { return hasRedcross; }
 }
 public RedCross Redcross {
 get { return redcross_; }
 set { SetRedcross(value); }
 }
 public void SetRedcross(RedCross value) { 
 hasRedcross = true;
 redcross_ = value;
 }

public const int horseidFieldNumber = 13;
 private bool hasHorseid;
 private Int32 horseid_ = 0;
 public bool HasHorseid {
 get { return hasHorseid; }
 }
 public Int32 Horseid {
 get { return horseid_; }
 set { SetHorseid(value); }
 }
 public void SetHorseid(Int32 value) { 
 hasHorseid = true;
 horseid_ = value;
 }

public const int usehorseflagFieldNumber = 14;
 private bool hasUsehorseflag;
 private Int32 usehorseflag_ = 0;
 public bool HasUsehorseflag {
 get { return hasUsehorseflag; }
 }
 public Int32 Usehorseflag {
 get { return usehorseflag_; }
 set { SetUsehorseflag(value); }
 }
 public void SetUsehorseflag(Int32 value) { 
 hasUsehorseflag = true;
 usehorseflag_ = value;
 }

public const int titleidFieldNumber = 15;
 private bool hasTitleid;
 private Int32 titleid_ = 0;
 public bool HasTitleid {
 get { return hasTitleid; }
 }
 public Int32 Titleid {
 get { return titleid_; }
 set { SetTitleid(value); }
 }
 public void SetTitleid(Int32 value) { 
 hasTitleid = true;
 titleid_ = value;
 }

public const int belongObjIdFieldNumber = 16;
 private pbc::PopsicleList<Int64> belongObjId_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> belongObjIdList {
 get { return pbc::Lists.AsReadOnly(belongObjId_); }
 }
 
 public int belongObjIdCount {
 get { return belongObjId_.Count; }
 }
 
public Int64 GetBelongObjId(int index) {
 return belongObjId_[index];
 }
 public void AddBelongObjId(Int64 value) {
 belongObjId_.Add(value);
 }

public const int gemEffectFieldNumber = 17;
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

public const int gangInfoFieldNumber = 18;
 private bool hasGangInfo;
 private GangInfo gangInfo_ =  new GangInfo();
 public bool HasGangInfo {
 get { return hasGangInfo; }
 }
 public GangInfo GangInfo {
 get { return gangInfo_; }
 set { SetGangInfo(value); }
 }
 public void SetGangInfo(GangInfo value) { 
 hasGangInfo = true;
 gangInfo_ = value;
 }

public const int enterDungeonFieldNumber = 19;
 private bool hasEnterDungeon;
 private Int32 enterDungeon_ = 0;
 public bool HasEnterDungeon {
 get { return hasEnterDungeon; }
 }
 public Int32 EnterDungeon {
 get { return enterDungeon_; }
 set { SetEnterDungeon(value); }
 }
 public void SetEnterDungeon(Int32 value) { 
 hasEnterDungeon = true;
 enterDungeon_ = value;
 }

public const int powerEffectFieldNumber = 20;
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

public const int awakeEffectFieldNumber = 21;
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

public const int vipNameFieldNumber = 22;
 private bool hasVipName;
 private string vipName_ = "";
 public bool HasVipName {
 get { return hasVipName; }
 }
 public string VipName {
 get { return vipName_; }
 set { SetVipName(value); }
 }
 public void SetVipName(string value) { 
 hasVipName = true;
 vipName_ = value;
 }

public const int randomIndexInfoFieldNumber = 23;
 private bool hasRandomIndexInfo;
 private RandomIndexInfo randomIndexInfo_ =  new RandomIndexInfo();
 public bool HasRandomIndexInfo {
 get { return hasRandomIndexInfo; }
 }
 public RandomIndexInfo RandomIndexInfo {
 get { return randomIndexInfo_; }
 set { SetRandomIndexInfo(value); }
 }
 public void SetRandomIndexInfo(RandomIndexInfo value) { 
 hasRandomIndexInfo = true;
 randomIndexInfo_ = value;
 }

public const int horseEquipEffectFieldNumber = 24;
 private bool hasHorseEquipEffect;
 private Int32 horseEquipEffect_ = 0;
 public bool HasHorseEquipEffect {
 get { return hasHorseEquipEffect; }
 }
 public Int32 HorseEquipEffect {
 get { return horseEquipEffect_; }
 set { SetHorseEquipEffect(value); }
 }
 public void SetHorseEquipEffect(Int32 value) { 
 hasHorseEquipEffect = true;
 horseEquipEffect_ = value;
 }

public const int flowerValueFieldNumber = 25;
 private bool hasFlowerValue;
 private Int32 flowerValue_ = 0;
 public bool HasFlowerValue {
 get { return hasFlowerValue; }
 }
 public Int32 FlowerValue {
 get { return flowerValue_; }
 set { SetFlowerValue(value); }
 }
 public void SetFlowerValue(Int32 value) { 
 hasFlowerValue = true;
 flowerValue_ = value;
 }

public const int otherNameFieldNumber = 26;
 private bool hasOtherName;
 private string otherName_ = "";
 public bool HasOtherName {
 get { return hasOtherName; }
 }
 public string OtherName {
 get { return otherName_; }
 set { SetOtherName(value); }
 }
 public void SetOtherName(string value) { 
 hasOtherName = true;
 otherName_ = value;
 }

public const int otherSexFieldNumber = 27;
 private bool hasOtherSex;
 private Int32 otherSex_ = 0;
 public bool HasOtherSex {
 get { return hasOtherSex; }
 }
 public Int32 OtherSex {
 get { return otherSex_; }
 set { SetOtherSex(value); }
 }
 public void SetOtherSex(Int32 value) { 
 hasOtherSex = true;
 otherSex_ = value;
 }

public const int roadsFieldNumber = 28;
 private pbc::PopsicleList<Vector3Info> roads_ = new pbc::PopsicleList<Vector3Info>();
 public scg::IList<Vector3Info> roadsList {
 get { return pbc::Lists.AsReadOnly(roads_); }
 }
 
 public int roadsCount {
 get { return roads_.Count; }
 }
 
public Vector3Info GetRoads(int index) {
 return roads_[index];
 }
 public void AddRoads(Vector3Info value) {
 roads_.Add(value);
 }

public const int ownIdFieldNumber = 29;
 private bool hasOwnId;
 private Int64 ownId_ = 0;
 public bool HasOwnId {
 get { return hasOwnId; }
 }
 public Int64 OwnId {
 get { return ownId_; }
 set { SetOwnId(value); }
 }
 public void SetOwnId(Int64 value) { 
 hasOwnId = true;
 ownId_ = value;
 }

public const int viewsFieldNumber = 30;
 private pbc::PopsicleList<CharacterViewMsg> views_ = new pbc::PopsicleList<CharacterViewMsg>();
 public scg::IList<CharacterViewMsg> viewsList {
 get { return pbc::Lists.AsReadOnly(views_); }
 }
 
 public int viewsCount {
 get { return views_.Count; }
 }
 
public CharacterViewMsg GetViews(int index) {
 return views_[index];
 }
 public void AddViews(CharacterViewMsg value) {
 views_.Add(value);
 }

public const int catchStateFieldNumber = 31;
 private bool hasCatchState;
 private Int32 catchState_ = 0;
 public bool HasCatchState {
 get { return hasCatchState; }
 }
 public Int32 CatchState {
 get { return catchState_; }
 set { SetCatchState(value); }
 }
 public void SetCatchState(Int32 value) { 
 hasCatchState = true;
 catchState_ = value;
 }

public const int deleteTimeFieldNumber = 32;
 private bool hasDeleteTime;
 private Int64 deleteTime_ = 0;
 public bool HasDeleteTime {
 get { return hasDeleteTime; }
 }
 public Int64 DeleteTime {
 get { return deleteTime_; }
 set { SetDeleteTime(value); }
 }
 public void SetDeleteTime(Int64 value) { 
 hasDeleteTime = true;
 deleteTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasCharName) {
size += pb::CodedOutputStream.ComputeStringSize(2, CharName);
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Sid);
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Bid);
}
{
foreach (CharacterAttr element in charAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
int subsize = ChangeEquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasInteractId) {
size += pb::CodedOutputStream.ComputeStringSize(9, InteractId);
}
 if (HasLiveTime) {
size += pb::CodedOutputStream.ComputeInt32Size(10, LiveTime);
}
{
int subsize = Redcross.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)12) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasHorseid) {
size += pb::CodedOutputStream.ComputeInt32Size(13, Horseid);
}
 if (HasUsehorseflag) {
size += pb::CodedOutputStream.ComputeInt32Size(14, Usehorseflag);
}
 if (HasTitleid) {
size += pb::CodedOutputStream.ComputeInt32Size(15, Titleid);
}
{
int dataSize = 0;
foreach (Int64 element in belongObjIdList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * belongObjId_.Count;
}
 if (HasGemEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(17, GemEffect);
}
{
int subsize = GangInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)18) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasEnterDungeon) {
size += pb::CodedOutputStream.ComputeInt32Size(19, EnterDungeon);
}
 if (HasPowerEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(20, PowerEffect);
}
 if (HasAwakeEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(21, AwakeEffect);
}
 if (HasVipName) {
size += pb::CodedOutputStream.ComputeStringSize(22, VipName);
}
{
int subsize = RandomIndexInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)23) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasHorseEquipEffect) {
size += pb::CodedOutputStream.ComputeInt32Size(24, HorseEquipEffect);
}
 if (HasFlowerValue) {
size += pb::CodedOutputStream.ComputeInt32Size(25, FlowerValue);
}
 if (HasOtherName) {
size += pb::CodedOutputStream.ComputeStringSize(26, OtherName);
}
 if (HasOtherSex) {
size += pb::CodedOutputStream.ComputeInt32Size(27, OtherSex);
}
{
foreach (Vector3Info element in roadsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)28) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasOwnId) {
size += pb::CodedOutputStream.ComputeInt64Size(29, OwnId);
}
{
foreach (CharacterViewMsg element in viewsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)30) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasCatchState) {
size += pb::CodedOutputStream.ComputeInt32Size(31, CatchState);
}
 if (HasDeleteTime) {
size += pb::CodedOutputStream.ComputeInt64Size(32, DeleteTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasCharName) {
output.WriteString(2, CharName);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
 
if (HasSid) {
output.WriteInt32(5, Sid);
}
 
if (HasBid) {
output.WriteInt32(6, Bid);
}

do{
foreach (CharacterAttr element in charAttrList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
{
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ChangeEquipInfo.SerializedSize());
ChangeEquipInfo.WriteTo(output);

}
 
if (HasInteractId) {
output.WriteString(9, InteractId);
}
 
if (HasLiveTime) {
output.WriteInt32(10, LiveTime);
}
{
output.WriteTag((int)12, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Redcross.SerializedSize());
Redcross.WriteTo(output);

}
 
if (HasHorseid) {
output.WriteInt32(13, Horseid);
}
 
if (HasUsehorseflag) {
output.WriteInt32(14, Usehorseflag);
}
 
if (HasTitleid) {
output.WriteInt32(15, Titleid);
}
{
if (belongObjId_.Count > 0) {
foreach (Int64 element in belongObjIdList) {
output.WriteInt64(16,element);
}
}

}
 
if (HasGemEffect) {
output.WriteInt32(17, GemEffect);
}
{
output.WriteTag((int)18, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)GangInfo.SerializedSize());
GangInfo.WriteTo(output);

}
 
if (HasEnterDungeon) {
output.WriteInt32(19, EnterDungeon);
}
 
if (HasPowerEffect) {
output.WriteInt32(20, PowerEffect);
}
 
if (HasAwakeEffect) {
output.WriteInt32(21, AwakeEffect);
}
 
if (HasVipName) {
output.WriteString(22, VipName);
}
{
output.WriteTag((int)23, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)RandomIndexInfo.SerializedSize());
RandomIndexInfo.WriteTo(output);

}
 
if (HasHorseEquipEffect) {
output.WriteInt32(24, HorseEquipEffect);
}
 
if (HasFlowerValue) {
output.WriteInt32(25, FlowerValue);
}
 
if (HasOtherName) {
output.WriteString(26, OtherName);
}
 
if (HasOtherSex) {
output.WriteInt32(27, OtherSex);
}

do{
foreach (Vector3Info element in roadsList) {
output.WriteTag((int)28, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasOwnId) {
output.WriteInt64(29, OwnId);
}

do{
foreach (CharacterViewMsg element in viewsList) {
output.WriteTag((int)30, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasCatchState) {
output.WriteInt32(31, CatchState);
}
 
if (HasDeleteTime) {
output.WriteInt64(32, DeleteTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CharacterInfo _inst = (CharacterInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  18: {
 _inst.CharName = input.ReadString();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}
   case  40: {
 _inst.Sid = input.ReadInt32();
break;
}
   case  48: {
 _inst.Bid = input.ReadInt32();
break;
}
    case  58: {
CharacterAttr subBuilder =  new CharacterAttr();
input.ReadMessage(subBuilder);
_inst.AddCharAttr(subBuilder);
break;
}
    case  66: {
ChangeEquipInfo subBuilder =  new ChangeEquipInfo();
 input.ReadMessage(subBuilder);
_inst.ChangeEquipInfo = subBuilder;
break;
}
   case  74: {
 _inst.InteractId = input.ReadString();
break;
}
   case  80: {
 _inst.LiveTime = input.ReadInt32();
break;
}
    case  98: {
RedCross subBuilder =  new RedCross();
 input.ReadMessage(subBuilder);
_inst.Redcross = subBuilder;
break;
}
   case  104: {
 _inst.Horseid = input.ReadInt32();
break;
}
   case  112: {
 _inst.Usehorseflag = input.ReadInt32();
break;
}
   case  120: {
 _inst.Titleid = input.ReadInt32();
break;
}
   case  128: {
 _inst.AddBelongObjId(input.ReadInt64());
break;
}
   case  136: {
 _inst.GemEffect = input.ReadInt32();
break;
}
    case  146: {
GangInfo subBuilder =  new GangInfo();
 input.ReadMessage(subBuilder);
_inst.GangInfo = subBuilder;
break;
}
   case  152: {
 _inst.EnterDungeon = input.ReadInt32();
break;
}
   case  160: {
 _inst.PowerEffect = input.ReadInt32();
break;
}
   case  168: {
 _inst.AwakeEffect = input.ReadInt32();
break;
}
   case  178: {
 _inst.VipName = input.ReadString();
break;
}
    case  186: {
RandomIndexInfo subBuilder =  new RandomIndexInfo();
 input.ReadMessage(subBuilder);
_inst.RandomIndexInfo = subBuilder;
break;
}
   case  192: {
 _inst.HorseEquipEffect = input.ReadInt32();
break;
}
   case  200: {
 _inst.FlowerValue = input.ReadInt32();
break;
}
   case  210: {
 _inst.OtherName = input.ReadString();
break;
}
   case  216: {
 _inst.OtherSex = input.ReadInt32();
break;
}
    case  226: {
Vector3Info subBuilder =  new Vector3Info();
input.ReadMessage(subBuilder);
_inst.AddRoads(subBuilder);
break;
}
   case  232: {
 _inst.OwnId = input.ReadInt64();
break;
}
    case  242: {
CharacterViewMsg subBuilder =  new CharacterViewMsg();
input.ReadMessage(subBuilder);
_inst.AddViews(subBuilder);
break;
}
   case  248: {
 _inst.CatchState = input.ReadInt32();
break;
}
   case  256: {
 _inst.DeleteTime = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPos) {
if (!Pos.IsInitialized()) return false;
}
  if (HasDirection) {
if (!Direction.IsInitialized()) return false;
}
foreach (CharacterAttr element in charAttrList) {
if (!element.IsInitialized()) return false;
}
  if (HasChangeEquipInfo) {
if (!ChangeEquipInfo.IsInitialized()) return false;
}
  if (HasRedcross) {
if (!Redcross.IsInitialized()) return false;
}
  if (HasGangInfo) {
if (!GangInfo.IsInitialized()) return false;
}
  if (HasRandomIndexInfo) {
if (!RandomIndexInfo.IsInitialized()) return false;
}
foreach (Vector3Info element in roadsList) {
if (!element.IsInitialized()) return false;
}
foreach (CharacterViewMsg element in viewsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class CharacterViewMsg : PacketDistributed
{

public const int viewTypeFieldNumber = 1;
 private bool hasViewType;
 private Int32 viewType_ = 0;
 public bool HasViewType {
 get { return hasViewType; }
 }
 public Int32 ViewType {
 get { return viewType_; }
 set { SetViewType(value); }
 }
 public void SetViewType(Int32 value) { 
 hasViewType = true;
 viewType_ = value;
 }

public const int viewValueFieldNumber = 2;
 private bool hasViewValue;
 private string viewValue_ = "";
 public bool HasViewValue {
 get { return hasViewValue; }
 }
 public string ViewValue {
 get { return viewValue_; }
 set { SetViewValue(value); }
 }
 public void SetViewValue(string value) { 
 hasViewValue = true;
 viewValue_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasViewType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ViewType);
}
 if (HasViewValue) {
size += pb::CodedOutputStream.ComputeStringSize(2, ViewValue);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasViewType) {
output.WriteInt32(1, ViewType);
}
 
if (HasViewValue) {
output.WriteString(2, ViewValue);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CharacterViewMsg _inst = (CharacterViewMsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ViewType = input.ReadInt32();
break;
}
   case  18: {
 _inst.ViewValue = input.ReadString();
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
public class DeviceInfo : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int posFieldNumber = 2;
 private bool hasPos;
 private Vector3Info pos_ =  new Vector3Info();
 public bool HasPos {
 get { return hasPos; }
 }
 public Vector3Info Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Vector3Info value) { 
 hasPos = true;
 pos_ = value;
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

public const int deviceTypeFieldNumber = 5;
 private bool hasDeviceType;
 private Int32 deviceType_ = 0;
 public bool HasDeviceType {
 get { return hasDeviceType; }
 }
 public Int32 DeviceType {
 get { return deviceType_; }
 set { SetDeviceType(value); }
 }
 public void SetDeviceType(Int32 value) { 
 hasDeviceType = true;
 deviceType_ = value;
 }

public const int numFieldNumber = 6;
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

public const int statusFieldNumber = 7;
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

public const int srcPosFieldNumber = 8;
 private bool hasSrcPos;
 private Vector3Info srcPos_ =  new Vector3Info();
 public bool HasSrcPos {
 get { return hasSrcPos; }
 }
 public Vector3Info SrcPos {
 get { return srcPos_; }
 set { SetSrcPos(value); }
 }
 public void SetSrcPos(Vector3Info value) { 
 hasSrcPos = true;
 srcPos_ = value;
 }

public const int campFieldNumber = 9;
 private bool hasCamp;
 private Int32 camp_ = 0;
 public bool HasCamp {
 get { return hasCamp; }
 }
 public Int32 Camp {
 get { return camp_; }
 set { SetCamp(value); }
 }
 public void SetCamp(Int32 value) { 
 hasCamp = true;
 camp_ = value;
 }

public const int isCurrencyFieldNumber = 10;
 private bool hasIsCurrency;
 private Int32 isCurrency_ = 0;
 public bool HasIsCurrency {
 get { return hasIsCurrency; }
 }
 public Int32 IsCurrency {
 get { return isCurrency_; }
 set { SetIsCurrency(value); }
 }
 public void SetIsCurrency(Int32 value) { 
 hasIsCurrency = true;
 isCurrency_ = value;
 }

public const int strFieldNumber = 11;
 private bool hasStr;
 private string str_ = "";
 public bool HasStr {
 get { return hasStr; }
 }
 public string Str {
 get { return str_; }
 set { SetStr(value); }
 }
 public void SetStr(string value) { 
 hasStr = true;
 str_ = value;
 }

public const int directionFieldNumber = 12;
 private bool hasDirection;
 private Vector3Info direction_ =  new Vector3Info();
 public bool HasDirection {
 get { return hasDirection; }
 }
 public Vector3Info Direction {
 get { return direction_; }
 set { SetDirection(value); }
 }
 public void SetDirection(Vector3Info value) { 
 hasDirection = true;
 direction_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Sid);
}
 if (HasDeviceType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, DeviceType);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Num);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Status);
}
{
int subsize = SrcPos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)8) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasCamp) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Camp);
}
 if (HasIsCurrency) {
size += pb::CodedOutputStream.ComputeInt32Size(10, IsCurrency);
}
 if (HasStr) {
size += pb::CodedOutputStream.ComputeStringSize(11, Str);
}
{
int subsize = Direction.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)12) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
 
if (HasBid) {
output.WriteInt32(3, Bid);
}
 
if (HasSid) {
output.WriteInt32(4, Sid);
}
 
if (HasDeviceType) {
output.WriteInt32(5, DeviceType);
}
 
if (HasNum) {
output.WriteInt32(6, Num);
}
 
if (HasStatus) {
output.WriteInt32(7, Status);
}
{
output.WriteTag((int)8, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)SrcPos.SerializedSize());
SrcPos.WriteTo(output);

}
 
if (HasCamp) {
output.WriteInt32(9, Camp);
}
 
if (HasIsCurrency) {
output.WriteInt32(10, IsCurrency);
}
 
if (HasStr) {
output.WriteString(11, Str);
}
{
output.WriteTag((int)12, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Direction.SerializedSize());
Direction.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 DeviceInfo _inst = (DeviceInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
    case  18: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
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
 _inst.DeviceType = input.ReadInt32();
break;
}
   case  48: {
 _inst.Num = input.ReadInt32();
break;
}
   case  56: {
 _inst.Status = input.ReadInt32();
break;
}
    case  66: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.SrcPos = subBuilder;
break;
}
   case  72: {
 _inst.Camp = input.ReadInt32();
break;
}
   case  80: {
 _inst.IsCurrency = input.ReadInt32();
break;
}
   case  90: {
 _inst.Str = input.ReadString();
break;
}
    case  98: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Direction = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPos) {
if (!Pos.IsInitialized()) return false;
}
  if (HasSrcPos) {
if (!SrcPos.IsInitialized()) return false;
}
  if (HasDirection) {
if (!Direction.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class FriendData : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int addressFieldNumber = 2;
 private bool hasAddress;
 private string address_ = "";
 public bool HasAddress {
 get { return hasAddress; }
 }
 public string Address {
 get { return address_; }
 set { SetAddress(value); }
 }
 public void SetAddress(string value) { 
 hasAddress = true;
 address_ = value;
 }

public const int onlineFieldNumber = 3;
 private bool hasOnline;
 private Int32 online_ = 0;
 public bool HasOnline {
 get { return hasOnline; }
 }
 public Int32 Online {
 get { return online_; }
 set { SetOnline(value); }
 }
 public void SetOnline(Int32 value) { 
 hasOnline = true;
 online_ = value;
 }

public const int typeFieldNumber = 4;
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

public const int careerFieldNumber = 5;
 private bool hasCareer;
 private Int32 career_ = 0;
 public bool HasCareer {
 get { return hasCareer; }
 }
 public Int32 Career {
 get { return career_; }
 set { SetCareer(value); }
 }
 public void SetCareer(Int32 value) { 
 hasCareer = true;
 career_ = value;
 }

public const int nameFieldNumber = 6;
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

public const int levelFieldNumber = 7;
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

public const int sexFieldNumber = 8;
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

public const int vipFieldNumber = 9;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasAddress) {
size += pb::CodedOutputStream.ComputeStringSize(2, Address);
}
 if (HasOnline) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Online);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Type);
}
 if (HasCareer) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Career);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(6, Name);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Level);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Sex);
}
 if (HasVip) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Vip);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasAddress) {
output.WriteString(2, Address);
}
 
if (HasOnline) {
output.WriteInt32(3, Online);
}
 
if (HasType) {
output.WriteInt32(4, Type);
}
 
if (HasCareer) {
output.WriteInt32(5, Career);
}
 
if (HasName) {
output.WriteString(6, Name);
}
 
if (HasLevel) {
output.WriteInt32(7, Level);
}
 
if (HasSex) {
output.WriteInt32(8, Sex);
}
 
if (HasVip) {
output.WriteInt32(9, Vip);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 FriendData _inst = (FriendData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  18: {
 _inst.Address = input.ReadString();
break;
}
   case  24: {
 _inst.Online = input.ReadInt32();
break;
}
   case  32: {
 _inst.Type = input.ReadInt32();
break;
}
   case  40: {
 _inst.Career = input.ReadInt32();
break;
}
   case  50: {
 _inst.Name = input.ReadString();
break;
}
   case  56: {
 _inst.Level = input.ReadInt32();
break;
}
   case  64: {
 _inst.Sex = input.ReadInt32();
break;
}
   case  72: {
 _inst.Vip = input.ReadInt32();
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
public class GCAddVerifyBox : PacketDistributed
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

public const int operateFieldNumber = 2;
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

public const int timeFieldNumber = 3;
 private bool hasTime;
 private Int32 time_ = 0;
 public bool HasTime {
 get { return hasTime; }
 }
 public Int32 Time {
 get { return time_; }
 set { SetTime(value); }
 }
 public void SetTime(Int32 value) { 
 hasTime = true;
 time_ = value;
 }

public const int paramsFieldNumber = 4;
 private pbc::PopsicleList<string> params_ = new pbc::PopsicleList<string>();
 public scg::IList<string> paramsList {
 get { return pbc::Lists.AsReadOnly(params_); }
 }
 
 public int paramsCount {
 get { return params_.Count; }
 }
 
public string GetParams(int index) {
 return params_[index];
 }
 public void AddParams(string value) {
 params_.Add(value);
 }

public const int messageIDFieldNumber = 5;
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
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Operate);
}
 if (HasTime) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Time);
}
{
int dataSize = 0;
foreach (string element in paramsList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * params_.Count;
}
 if (HasMessageID) {
size += pb::CodedOutputStream.ComputeInt32Size(5, MessageID);
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
 
if (HasOperate) {
output.WriteInt32(2, Operate);
}
 
if (HasTime) {
output.WriteInt32(3, Time);
}
{
if (params_.Count > 0) {
foreach (string element in paramsList) {
output.WriteString(4,element);
}
}

}
 
if (HasMessageID) {
output.WriteInt32(5, MessageID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAddVerifyBox _inst = (GCAddVerifyBox) _base;
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
 _inst.Operate = input.ReadInt32();
break;
}
   case  24: {
 _inst.Time = input.ReadInt32();
break;
}
   case  34: {
 _inst.AddParams(input.ReadString());
break;
}
   case  40: {
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
public class GCChangeAttribute : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
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

public const int interactIdFieldNumber = 5;
 private bool hasInteractId;
 private string interactId_ = "";
 public bool HasInteractId {
 get { return hasInteractId; }
 }
 public string InteractId {
 get { return interactId_; }
 set { SetInteractId(value); }
 }
 public void SetInteractId(string value) { 
 hasInteractId = true;
 interactId_ = value;
 }

public const int infoFieldNumber = 6;
 private bool hasInfo;
 private CharacterInfo info_ =  new CharacterInfo();
 public bool HasInfo {
 get { return hasInfo; }
 }
 public CharacterInfo Info {
 get { return info_; }
 set { SetInfo(value); }
 }
 public void SetInfo(CharacterInfo value) { 
 hasInfo = true;
 info_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasBid) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bid);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Sid);
}
 if (HasInteractId) {
size += pb::CodedOutputStream.ComputeStringSize(5, InteractId);
}
{
int subsize = Info.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)6) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasBid) {
output.WriteInt32(3, Bid);
}
 
if (HasSid) {
output.WriteInt32(4, Sid);
}
 
if (HasInteractId) {
output.WriteString(5, InteractId);
}
{
output.WriteTag((int)6, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Info.SerializedSize());
Info.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChangeAttribute _inst = (GCChangeAttribute) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
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
   case  42: {
 _inst.InteractId = input.ReadString();
break;
}
    case  50: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.Info = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasInfo) {
if (!Info.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCharacterTalk : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int talkWordFieldNumber = 2;
 private bool hasTalkWord;
 private Int32 talkWord_ = 0;
 public bool HasTalkWord {
 get { return hasTalkWord; }
 }
 public Int32 TalkWord {
 get { return talkWord_; }
 set { SetTalkWord(value); }
 }
 public void SetTalkWord(Int32 value) { 
 hasTalkWord = true;
 talkWord_ = value;
 }

public const int talkVoiceFieldNumber = 3;
 private bool hasTalkVoice;
 private Int32 talkVoice_ = 0;
 public bool HasTalkVoice {
 get { return hasTalkVoice; }
 }
 public Int32 TalkVoice {
 get { return talkVoice_; }
 set { SetTalkVoice(value); }
 }
 public void SetTalkVoice(Int32 value) { 
 hasTalkVoice = true;
 talkVoice_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasTalkWord) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TalkWord);
}
 if (HasTalkVoice) {
size += pb::CodedOutputStream.ComputeInt32Size(3, TalkVoice);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasTalkWord) {
output.WriteInt32(2, TalkWord);
}
 
if (HasTalkVoice) {
output.WriteInt32(3, TalkVoice);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCharacterTalk _inst = (GCCharacterTalk) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  16: {
 _inst.TalkWord = input.ReadInt32();
break;
}
   case  24: {
 _inst.TalkVoice = input.ReadInt32();
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
public class GCCmmonDialog : PacketDistributed
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

public const int contentsFieldNumber = 2;
 private pbc::PopsicleList<string> contents_ = new pbc::PopsicleList<string>();
 public scg::IList<string> contentsList {
 get { return pbc::Lists.AsReadOnly(contents_); }
 }
 
 public int contentsCount {
 get { return contents_.Count; }
 }
 
public string GetContents(int index) {
 return contents_[index];
 }
 public void AddContents(string value) {
 contents_.Add(value);
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
int dataSize = 0;
foreach (string element in contentsList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * contents_.Count;
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
if (contents_.Count > 0) {
foreach (string element in contentsList) {
output.WriteString(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCmmonDialog _inst = (GCCmmonDialog) _base;
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
 _inst.AddContents(input.ReadString());
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
public class GCErroeHintBack : PacketDistributed
{

public const int errorCodeFieldNumber = 1;
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

public const int errorDescFieldNumber = 2;
 private bool hasErrorDesc;
 private string errorDesc_ = "";
 public bool HasErrorDesc {
 get { return hasErrorDesc; }
 }
 public string ErrorDesc {
 get { return errorDesc_; }
 set { SetErrorDesc(value); }
 }
 public void SetErrorDesc(string value) { 
 hasErrorDesc = true;
 errorDesc_ = value;
 }

public const int parmFieldNumber = 3;
 private pbc::PopsicleList<string> parm_ = new pbc::PopsicleList<string>();
 public scg::IList<string> parmList {
 get { return pbc::Lists.AsReadOnly(parm_); }
 }
 
 public int parmCount {
 get { return parm_.Count; }
 }
 
public string GetParm(int index) {
 return parm_[index];
 }
 public void AddParm(string value) {
 parm_.Add(value);
 }

public const int boxTypeFieldNumber = 4;
 private bool hasBoxType;
 private Int32 boxType_ = 0;
 public bool HasBoxType {
 get { return hasBoxType; }
 }
 public Int32 BoxType {
 get { return boxType_; }
 set { SetBoxType(value); }
 }
 public void SetBoxType(Int32 value) { 
 hasBoxType = true;
 boxType_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ErrorCode);
}
 if (HasErrorDesc) {
size += pb::CodedOutputStream.ComputeStringSize(2, ErrorDesc);
}
{
int dataSize = 0;
foreach (string element in parmList) {
dataSize += pb::CodedOutputStream.ComputeStringSize(element);
}
size += dataSize;
size += 1 * parm_.Count;
}
 if (HasBoxType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, BoxType);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasErrorCode) {
output.WriteInt32(1, ErrorCode);
}
 
if (HasErrorDesc) {
output.WriteString(2, ErrorDesc);
}
{
if (parm_.Count > 0) {
foreach (string element in parmList) {
output.WriteString(3,element);
}
}

}
 
if (HasBoxType) {
output.WriteInt32(4, BoxType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCErroeHintBack _inst = (GCErroeHintBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ErrorCode = input.ReadInt32();
break;
}
   case  18: {
 _inst.ErrorDesc = input.ReadString();
break;
}
   case  26: {
 _inst.AddParm(input.ReadString());
break;
}
   case  32: {
 _inst.BoxType = input.ReadInt32();
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
public class GCPlayEffect : PacketDistributed
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
 GCPlayEffect _inst = (GCPlayEffect) _base;
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
public class GCSendAddExp : PacketDistributed
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
 private Int64 sid_ = 0;
 public bool HasSid {
 get { return hasSid; }
 }
 public Int64 Sid {
 get { return sid_; }
 set { SetSid(value); }
 }
 public void SetSid(Int64 value) { 
 hasSid = true;
 sid_ = value;
 }

public const int addExpFieldNumber = 3;
 private bool hasAddExp;
 private Int32 addExp_ = 0;
 public bool HasAddExp {
 get { return hasAddExp; }
 }
 public Int32 AddExp {
 get { return addExp_; }
 set { SetAddExp(value); }
 }
 public void SetAddExp(Int32 value) { 
 hasAddExp = true;
 addExp_ = value;
 }

public const int sourceFieldNumber = 4;
 private bool hasSource;
 private Int32 source_ = 0;
 public bool HasSource {
 get { return hasSource; }
 }
 public Int32 Source {
 get { return source_; }
 set { SetSource(value); }
 }
 public void SetSource(Int32 value) { 
 hasSource = true;
 source_ = value;
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
size += pb::CodedOutputStream.ComputeInt64Size(2, Sid);
}
 if (HasAddExp) {
size += pb::CodedOutputStream.ComputeInt32Size(3, AddExp);
}
 if (HasSource) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Source);
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
output.WriteInt64(2, Sid);
}
 
if (HasAddExp) {
output.WriteInt32(3, AddExp);
}
 
if (HasSource) {
output.WriteInt32(4, Source);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendAddExp _inst = (GCSendAddExp) _base;
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
 _inst.Sid = input.ReadInt64();
break;
}
   case  24: {
 _inst.AddExp = input.ReadInt32();
break;
}
   case  32: {
 _inst.Source = input.ReadInt32();
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
public class GGDungeonChangeScene : PacketDistributed
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

public const int instanceIdFieldNumber = 3;
 private bool hasInstanceId;
 private Int32 instanceId_ = 0;
 public bool HasInstanceId {
 get { return hasInstanceId; }
 }
 public Int32 InstanceId {
 get { return instanceId_; }
 set { SetInstanceId(value); }
 }
 public void SetInstanceId(Int32 value) { 
 hasInstanceId = true;
 instanceId_ = value;
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
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasInstanceId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, InstanceId);
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
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasInstanceId) {
output.WriteInt32(3, InstanceId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GGDungeonChangeScene _inst = (GGDungeonChangeScene) _base;
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
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.InstanceId = input.ReadInt32();
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
public class GangInfo : PacketDistributed
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

public const int totemNameFieldNumber = 3;
 private bool hasTotemName;
 private string totemName_ = "";
 public bool HasTotemName {
 get { return hasTotemName; }
 }
 public string TotemName {
 get { return totemName_; }
 set { SetTotemName(value); }
 }
 public void SetTotemName(string value) { 
 hasTotemName = true;
 totemName_ = value;
 }

public const int gangJobFieldNumber = 4;
 private bool hasGangJob;
 private Int32 gangJob_ = 0;
 public bool HasGangJob {
 get { return hasGangJob; }
 }
 public Int32 GangJob {
 get { return gangJob_; }
 set { SetGangJob(value); }
 }
 public void SetGangJob(Int32 value) { 
 hasGangJob = true;
 gangJob_ = value;
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
 if (HasTotemName) {
size += pb::CodedOutputStream.ComputeStringSize(3, TotemName);
}
 if (HasGangJob) {
size += pb::CodedOutputStream.ComputeInt32Size(4, GangJob);
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
 
if (HasTotemName) {
output.WriteString(3, TotemName);
}
 
if (HasGangJob) {
output.WriteInt32(4, GangJob);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GangInfo _inst = (GangInfo) _base;
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
 _inst.TotemName = input.ReadString();
break;
}
   case  32: {
 _inst.GangJob = input.ReadInt32();
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
public class HorseInfo : PacketDistributed
{

public const int tableidFieldNumber = 1;
 private bool hasTableid;
 private Int32 tableid_ = 0;
 public bool HasTableid {
 get { return hasTableid; }
 }
 public Int32 Tableid {
 get { return tableid_; }
 set { SetTableid(value); }
 }
 public void SetTableid(Int32 value) { 
 hasTableid = true;
 tableid_ = value;
 }

public const int serveridFieldNumber = 2;
 private bool hasServerid;
 private Int64 serverid_ = 0;
 public bool HasServerid {
 get { return hasServerid; }
 }
 public Int64 Serverid {
 get { return serverid_; }
 set { SetServerid(value); }
 }
 public void SetServerid(Int64 value) { 
 hasServerid = true;
 serverid_ = value;
 }

public const int isuseFieldNumber = 3;
 private bool hasIsuse;
 private Int32 isuse_ = 0;
 public bool HasIsuse {
 get { return hasIsuse; }
 }
 public Int32 Isuse {
 get { return isuse_; }
 set { SetIsuse(value); }
 }
 public void SetIsuse(Int32 value) { 
 hasIsuse = true;
 isuse_ = value;
 }

public const int upstarrateFieldNumber = 4;
 private bool hasUpstarrate;
 private Int32 upstarrate_ = 0;
 public bool HasUpstarrate {
 get { return hasUpstarrate; }
 }
 public Int32 Upstarrate {
 get { return upstarrate_; }
 set { SetUpstarrate(value); }
 }
 public void SetUpstarrate(Int32 value) { 
 hasUpstarrate = true;
 upstarrate_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTableid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Tableid);
}
 if (HasServerid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Serverid);
}
 if (HasIsuse) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Isuse);
}
 if (HasUpstarrate) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Upstarrate);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTableid) {
output.WriteInt32(1, Tableid);
}
 
if (HasServerid) {
output.WriteInt64(2, Serverid);
}
 
if (HasIsuse) {
output.WriteInt32(3, Isuse);
}
 
if (HasUpstarrate) {
output.WriteInt32(4, Upstarrate);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 HorseInfo _inst = (HorseInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Tableid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Serverid = input.ReadInt64();
break;
}
   case  24: {
 _inst.Isuse = input.ReadInt32();
break;
}
   case  32: {
 _inst.Upstarrate = input.ReadInt32();
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
public class Iteminfo : PacketDistributed
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
 Iteminfo _inst = (Iteminfo) _base;
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
public class PersonalMessagees : PacketDistributed
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

public const int objIdFieldNumber = 2;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int nameFieldNumber = 3;
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
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ObjId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(3, Name);
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
 
if (HasObjId) {
output.WriteInt64(2, ObjId);
}
 
if (HasName) {
output.WriteString(3, Name);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PersonalMessagees _inst = (PersonalMessagees) _base;
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
 _inst.ObjId = input.ReadInt64();
break;
}
   case  26: {
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
public class PetAttr : PacketDistributed
{

public const int attrkeyFieldNumber = 1;
 private bool hasAttrkey;
 private Int32 attrkey_ = 0;
 public bool HasAttrkey {
 get { return hasAttrkey; }
 }
 public Int32 Attrkey {
 get { return attrkey_; }
 set { SetAttrkey(value); }
 }
 public void SetAttrkey(Int32 value) { 
 hasAttrkey = true;
 attrkey_ = value;
 }

public const int attrvalueFieldNumber = 2;
 private bool hasAttrvalue;
 private Int32 attrvalue_ = 0;
 public bool HasAttrvalue {
 get { return hasAttrvalue; }
 }
 public Int32 Attrvalue {
 get { return attrvalue_; }
 set { SetAttrvalue(value); }
 }
 public void SetAttrvalue(Int32 value) { 
 hasAttrvalue = true;
 attrvalue_ = value;
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
  if (HasAttrkey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Attrkey);
}
 if (HasAttrvalue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Attrvalue);
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
  
if (HasAttrkey) {
output.WriteInt32(1, Attrkey);
}
 
if (HasAttrvalue) {
output.WriteInt32(2, Attrvalue);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PetAttr _inst = (PetAttr) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Attrkey = input.ReadInt32();
break;
}
   case  16: {
 _inst.Attrvalue = input.ReadInt32();
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
public class PetInfo : PacketDistributed
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

public const int qualityFieldNumber = 4;
 private bool hasQuality;
 private Int32 quality_ = 0;
 public bool HasQuality {
 get { return hasQuality; }
 }
 public Int32 Quality {
 get { return quality_; }
 set { SetQuality(value); }
 }
 public void SetQuality(Int32 value) { 
 hasQuality = true;
 quality_ = value;
 }

public const int characterFieldNumber = 5;
 private bool hasCharacter;
 private Int32 character_ = 0;
 public bool HasCharacter {
 get { return hasCharacter; }
 }
 public Int32 Character {
 get { return character_; }
 set { SetCharacter(value); }
 }
 public void SetCharacter(Int32 value) { 
 hasCharacter = true;
 character_ = value;
 }

public const int battleflagFieldNumber = 6;
 private bool hasBattleflag;
 private Int32 battleflag_ = 0;
 public bool HasBattleflag {
 get { return hasBattleflag; }
 }
 public Int32 Battleflag {
 get { return battleflag_; }
 set { SetBattleflag(value); }
 }
 public void SetBattleflag(Int32 value) { 
 hasBattleflag = true;
 battleflag_ = value;
 }

public const int petGrowFieldNumber = 7;
 private bool hasPetGrow;
 private Int32 petGrow_ = 0;
 public bool HasPetGrow {
 get { return hasPetGrow; }
 }
 public Int32 PetGrow {
 get { return petGrow_; }
 set { SetPetGrow(value); }
 }
 public void SetPetGrow(Int32 value) { 
 hasPetGrow = true;
 petGrow_ = value;
 }

public const int starlevelFieldNumber = 8;
 private bool hasStarlevel;
 private Int32 starlevel_ = 0;
 public bool HasStarlevel {
 get { return hasStarlevel; }
 }
 public Int32 Starlevel {
 get { return starlevel_; }
 set { SetStarlevel(value); }
 }
 public void SetStarlevel(Int32 value) { 
 hasStarlevel = true;
 starlevel_ = value;
 }

public const int levelFieldNumber = 9;
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

public const int petIdFieldNumber = 10;
 private bool hasPetId;
 private Int64 petId_ = 0;
 public bool HasPetId {
 get { return hasPetId; }
 }
 public Int64 PetId {
 get { return petId_; }
 set { SetPetId(value); }
 }
 public void SetPetId(Int64 value) { 
 hasPetId = true;
 petId_ = value;
 }

public const int petAttrFieldNumber = 11;
 private pbc::PopsicleList<PetAttr> petAttr_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrList {
 get { return pbc::Lists.AsReadOnly(petAttr_); }
 }
 
 public int petAttrCount {
 get { return petAttr_.Count; }
 }
 
public PetAttr GetPetAttr(int index) {
 return petAttr_[index];
 }
 public void AddPetAttr(PetAttr value) {
 petAttr_.Add(value);
 }

public const int petAttrDownFieldNumber = 12;
 private pbc::PopsicleList<PetAttr> petAttrDown_ = new pbc::PopsicleList<PetAttr>();
 public scg::IList<PetAttr> petAttrDownList {
 get { return pbc::Lists.AsReadOnly(petAttrDown_); }
 }
 
 public int petAttrDownCount {
 get { return petAttrDown_.Count; }
 }
 
public PetAttr GetPetAttrDown(int index) {
 return petAttrDown_[index];
 }
 public void AddPetAttrDown(PetAttr value) {
 petAttrDown_.Add(value);
 }

public const int skilldataFieldNumber = 13;
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

public const int objidFieldNumber = 14;
 private bool hasObjid;
 private Int64 objid_ = 0;
 public bool HasObjid {
 get { return hasObjid; }
 }
 public Int64 Objid {
 get { return objid_; }
 set { SetObjid(value); }
 }
 public void SetObjid(Int64 value) { 
 hasObjid = true;
 objid_ = value;
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
size += pb::CodedOutputStream.ComputeStringSize(2, Name);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Sex);
}
 if (HasQuality) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Quality);
}
 if (HasCharacter) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Character);
}
 if (HasBattleflag) {
size += pb::CodedOutputStream.ComputeInt32Size(6, Battleflag);
}
 if (HasPetGrow) {
size += pb::CodedOutputStream.ComputeInt32Size(7, PetGrow);
}
 if (HasStarlevel) {
size += pb::CodedOutputStream.ComputeInt32Size(8, Starlevel);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(9, Level);
}
 if (HasPetId) {
size += pb::CodedOutputStream.ComputeInt64Size(10, PetId);
}
{
foreach (PetAttr element in petAttrList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)11) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (PetAttr element in petAttrDownList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)12) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (SkillItemData element in skilldataList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)13) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasObjid) {
size += pb::CodedOutputStream.ComputeInt64Size(14, Objid);
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
output.WriteString(2, Name);
}
 
if (HasSex) {
output.WriteInt32(3, Sex);
}
 
if (HasQuality) {
output.WriteInt32(4, Quality);
}
 
if (HasCharacter) {
output.WriteInt32(5, Character);
}
 
if (HasBattleflag) {
output.WriteInt32(6, Battleflag);
}
 
if (HasPetGrow) {
output.WriteInt32(7, PetGrow);
}
 
if (HasStarlevel) {
output.WriteInt32(8, Starlevel);
}
 
if (HasLevel) {
output.WriteInt32(9, Level);
}
 
if (HasPetId) {
output.WriteInt64(10, PetId);
}

do{
foreach (PetAttr element in petAttrList) {
output.WriteTag((int)11, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (PetAttr element in petAttrDownList) {
output.WriteTag((int)12, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (SkillItemData element in skilldataList) {
output.WriteTag((int)13, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasObjid) {
output.WriteInt64(14, Objid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PetInfo _inst = (PetInfo) _base;
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
 _inst.Name = input.ReadString();
break;
}
   case  24: {
 _inst.Sex = input.ReadInt32();
break;
}
   case  32: {
 _inst.Quality = input.ReadInt32();
break;
}
   case  40: {
 _inst.Character = input.ReadInt32();
break;
}
   case  48: {
 _inst.Battleflag = input.ReadInt32();
break;
}
   case  56: {
 _inst.PetGrow = input.ReadInt32();
break;
}
   case  64: {
 _inst.Starlevel = input.ReadInt32();
break;
}
   case  72: {
 _inst.Level = input.ReadInt32();
break;
}
   case  80: {
 _inst.PetId = input.ReadInt64();
break;
}
    case  90: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttr(subBuilder);
break;
}
    case  98: {
PetAttr subBuilder =  new PetAttr();
input.ReadMessage(subBuilder);
_inst.AddPetAttrDown(subBuilder);
break;
}
    case  106: {
SkillItemData subBuilder =  new SkillItemData();
input.ReadMessage(subBuilder);
_inst.AddSkilldata(subBuilder);
break;
}
   case  112: {
 _inst.Objid = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PetAttr element in petAttrList) {
if (!element.IsInitialized()) return false;
}
foreach (PetAttr element in petAttrDownList) {
if (!element.IsInitialized()) return false;
}
foreach (SkillItemData element in skilldataList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class PlayerFashion : PacketDistributed
{

public const int tableidFieldNumber = 1;
 private bool hasTableid;
 private Int32 tableid_ = 0;
 public bool HasTableid {
 get { return hasTableid; }
 }
 public Int32 Tableid {
 get { return tableid_; }
 set { SetTableid(value); }
 }
 public void SetTableid(Int32 value) { 
 hasTableid = true;
 tableid_ = value;
 }

public const int serveridFieldNumber = 2;
 private bool hasServerid;
 private Int64 serverid_ = 0;
 public bool HasServerid {
 get { return hasServerid; }
 }
 public Int64 Serverid {
 get { return serverid_; }
 set { SetServerid(value); }
 }
 public void SetServerid(Int64 value) { 
 hasServerid = true;
 serverid_ = value;
 }

public const int invalidtimeFieldNumber = 3;
 private bool hasInvalidtime;
 private Int64 invalidtime_ = 0;
 public bool HasInvalidtime {
 get { return hasInvalidtime; }
 }
 public Int64 Invalidtime {
 get { return invalidtime_; }
 set { SetInvalidtime(value); }
 }
 public void SetInvalidtime(Int64 value) { 
 hasInvalidtime = true;
 invalidtime_ = value;
 }

public const int timetypeFieldNumber = 4;
 private bool hasTimetype;
 private Int32 timetype_ = 0;
 public bool HasTimetype {
 get { return hasTimetype; }
 }
 public Int32 Timetype {
 get { return timetype_; }
 set { SetTimetype(value); }
 }
 public void SetTimetype(Int32 value) { 
 hasTimetype = true;
 timetype_ = value;
 }

public const int isuserFieldNumber = 5;
 private bool hasIsuser;
 private Int32 isuser_ = 0;
 public bool HasIsuser {
 get { return hasIsuser; }
 }
 public Int32 Isuser {
 get { return isuser_; }
 set { SetIsuser(value); }
 }
 public void SetIsuser(Int32 value) { 
 hasIsuser = true;
 isuser_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTableid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Tableid);
}
 if (HasServerid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Serverid);
}
 if (HasInvalidtime) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Invalidtime);
}
 if (HasTimetype) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Timetype);
}
 if (HasIsuser) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Isuser);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTableid) {
output.WriteInt32(1, Tableid);
}
 
if (HasServerid) {
output.WriteInt64(2, Serverid);
}
 
if (HasInvalidtime) {
output.WriteInt64(3, Invalidtime);
}
 
if (HasTimetype) {
output.WriteInt32(4, Timetype);
}
 
if (HasIsuser) {
output.WriteInt32(5, Isuser);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 PlayerFashion _inst = (PlayerFashion) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Tableid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Serverid = input.ReadInt64();
break;
}
   case  24: {
 _inst.Invalidtime = input.ReadInt64();
break;
}
   case  32: {
 _inst.Timetype = input.ReadInt32();
break;
}
   case  40: {
 _inst.Isuser = input.ReadInt32();
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
public class RandomIndexInfo : PacketDistributed
{

public const int randomIndexHitChancesFieldNumber = 1;
 private bool hasRandomIndexHitChances;
 private Int32 randomIndexHitChances_ = 0;
 public bool HasRandomIndexHitChances {
 get { return hasRandomIndexHitChances; }
 }
 public Int32 RandomIndexHitChances {
 get { return randomIndexHitChances_; }
 set { SetRandomIndexHitChances(value); }
 }
 public void SetRandomIndexHitChances(Int32 value) { 
 hasRandomIndexHitChances = true;
 randomIndexHitChances_ = value;
 }

public const int randomIndexCritFieldNumber = 2;
 private bool hasRandomIndexCrit;
 private Int32 randomIndexCrit_ = 0;
 public bool HasRandomIndexCrit {
 get { return hasRandomIndexCrit; }
 }
 public Int32 RandomIndexCrit {
 get { return randomIndexCrit_; }
 set { SetRandomIndexCrit(value); }
 }
 public void SetRandomIndexCrit(Int32 value) { 
 hasRandomIndexCrit = true;
 randomIndexCrit_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRandomIndexHitChances) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RandomIndexHitChances);
}
 if (HasRandomIndexCrit) {
size += pb::CodedOutputStream.ComputeInt32Size(2, RandomIndexCrit);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRandomIndexHitChances) {
output.WriteInt32(1, RandomIndexHitChances);
}
 
if (HasRandomIndexCrit) {
output.WriteInt32(2, RandomIndexCrit);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RandomIndexInfo _inst = (RandomIndexInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RandomIndexHitChances = input.ReadInt32();
break;
}
   case  16: {
 _inst.RandomIndexCrit = input.ReadInt32();
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
public class RandomIsland : PacketDistributed
{

public const int islandNameFieldNumber = 1;
 private bool hasIslandName;
 private string islandName_ = "";
 public bool HasIslandName {
 get { return hasIslandName; }
 }
 public string IslandName {
 get { return islandName_; }
 set { SetIslandName(value); }
 }
 public void SetIslandName(string value) { 
 hasIslandName = true;
 islandName_ = value;
 }

public const int PosXFieldNumber = 2;
 private bool hasPosX;
 private Int32 PosX_ = 0;
 public bool HasPosX {
 get { return hasPosX; }
 }
 public Int32 PosX {
 get { return PosX_; }
 set { SetPosX(value); }
 }
 public void SetPosX(Int32 value) { 
 hasPosX = true;
 PosX_ = value;
 }

public const int PosYFieldNumber = 3;
 private bool hasPosY;
 private Int32 PosY_ = 0;
 public bool HasPosY {
 get { return hasPosY; }
 }
 public Int32 PosY {
 get { return PosY_; }
 set { SetPosY(value); }
 }
 public void SetPosY(Int32 value) { 
 hasPosY = true;
 PosY_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasIslandName) {
size += pb::CodedOutputStream.ComputeStringSize(1, IslandName);
}
 if (HasPosX) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PosX);
}
 if (HasPosY) {
size += pb::CodedOutputStream.ComputeInt32Size(3, PosY);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasIslandName) {
output.WriteString(1, IslandName);
}
 
if (HasPosX) {
output.WriteInt32(2, PosX);
}
 
if (HasPosY) {
output.WriteInt32(3, PosY);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RandomIsland _inst = (RandomIsland) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.IslandName = input.ReadString();
break;
}
   case  16: {
 _inst.PosX = input.ReadInt32();
break;
}
   case  24: {
 _inst.PosY = input.ReadInt32();
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
public class RedCross : PacketDistributed
{

public const int redcrossmaxhpFieldNumber = 1;
 private bool hasRedcrossmaxhp;
 private Int64 redcrossmaxhp_ = 0;
 public bool HasRedcrossmaxhp {
 get { return hasRedcrossmaxhp; }
 }
 public Int64 Redcrossmaxhp {
 get { return redcrossmaxhp_; }
 set { SetRedcrossmaxhp(value); }
 }
 public void SetRedcrossmaxhp(Int64 value) { 
 hasRedcrossmaxhp = true;
 redcrossmaxhp_ = value;
 }

public const int redcrosshpFieldNumber = 2;
 private bool hasRedcrosshp;
 private Int64 redcrosshp_ = 0;
 public bool HasRedcrosshp {
 get { return hasRedcrosshp; }
 }
 public Int64 Redcrosshp {
 get { return redcrosshp_; }
 set { SetRedcrosshp(value); }
 }
 public void SetRedcrosshp(Int64 value) { 
 hasRedcrosshp = true;
 redcrosshp_ = value;
 }

public const int redcrossmaxmpFieldNumber = 3;
 private bool hasRedcrossmaxmp;
 private Int64 redcrossmaxmp_ = 0;
 public bool HasRedcrossmaxmp {
 get { return hasRedcrossmaxmp; }
 }
 public Int64 Redcrossmaxmp {
 get { return redcrossmaxmp_; }
 set { SetRedcrossmaxmp(value); }
 }
 public void SetRedcrossmaxmp(Int64 value) { 
 hasRedcrossmaxmp = true;
 redcrossmaxmp_ = value;
 }

public const int redcrossmpFieldNumber = 4;
 private bool hasRedcrossmp;
 private Int64 redcrossmp_ = 0;
 public bool HasRedcrossmp {
 get { return hasRedcrossmp; }
 }
 public Int64 Redcrossmp {
 get { return redcrossmp_; }
 set { SetRedcrossmp(value); }
 }
 public void SetRedcrossmp(Int64 value) { 
 hasRedcrossmp = true;
 redcrossmp_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRedcrossmaxhp) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Redcrossmaxhp);
}
 if (HasRedcrosshp) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Redcrosshp);
}
 if (HasRedcrossmaxmp) {
size += pb::CodedOutputStream.ComputeInt64Size(3, Redcrossmaxmp);
}
 if (HasRedcrossmp) {
size += pb::CodedOutputStream.ComputeInt64Size(4, Redcrossmp);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRedcrossmaxhp) {
output.WriteInt64(1, Redcrossmaxhp);
}
 
if (HasRedcrosshp) {
output.WriteInt64(2, Redcrosshp);
}
 
if (HasRedcrossmaxmp) {
output.WriteInt64(3, Redcrossmaxmp);
}
 
if (HasRedcrossmp) {
output.WriteInt64(4, Redcrossmp);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 RedCross _inst = (RedCross) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Redcrossmaxhp = input.ReadInt64();
break;
}
   case  16: {
 _inst.Redcrosshp = input.ReadInt64();
break;
}
   case  24: {
 _inst.Redcrossmaxmp = input.ReadInt64();
break;
}
   case  32: {
 _inst.Redcrossmp = input.ReadInt64();
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
public class SkillAttackRelation : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
 }

public const int relationFieldNumber = 2;
 private bool hasRelation;
 private Int32 relation_ = 0;
 public bool HasRelation {
 get { return hasRelation; }
 }
 public Int32 Relation {
 get { return relation_; }
 set { SetRelation(value); }
 }
 public void SetRelation(Int32 value) { 
 hasRelation = true;
 relation_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasRelation) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Relation);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasRelation) {
output.WriteInt32(2, Relation);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SkillAttackRelation _inst = (SkillAttackRelation) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Relation = input.ReadInt32();
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
public class SkillItemData : PacketDistributed
{

public const int skillidFieldNumber = 1;
 private bool hasSkillid;
 private Int32 skillid_ = 0;
 public bool HasSkillid {
 get { return hasSkillid; }
 }
 public Int32 Skillid {
 get { return skillid_; }
 set { SetSkillid(value); }
 }
 public void SetSkillid(Int32 value) { 
 hasSkillid = true;
 skillid_ = value;
 }

public const int skilllevelFieldNumber = 2;
 private bool hasSkilllevel;
 private Int32 skilllevel_ = 0;
 public bool HasSkilllevel {
 get { return hasSkilllevel; }
 }
 public Int32 Skilllevel {
 get { return skilllevel_; }
 set { SetSkilllevel(value); }
 }
 public void SetSkilllevel(Int32 value) { 
 hasSkilllevel = true;
 skilllevel_ = value;
 }

public const int skillpositionFieldNumber = 3;
 private bool hasSkillposition;
 private Int32 skillposition_ = 0;
 public bool HasSkillposition {
 get { return hasSkillposition; }
 }
 public Int32 Skillposition {
 get { return skillposition_; }
 set { SetSkillposition(value); }
 }
 public void SetSkillposition(Int32 value) { 
 hasSkillposition = true;
 skillposition_ = value;
 }

public const int flagnormalFieldNumber = 4;
 private bool hasFlagnormal;
 private Int32 flagnormal_ = 0;
 public bool HasFlagnormal {
 get { return hasFlagnormal; }
 }
 public Int32 Flagnormal {
 get { return flagnormal_; }
 set { SetFlagnormal(value); }
 }
 public void SetFlagnormal(Int32 value) { 
 hasFlagnormal = true;
 flagnormal_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSkillid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Skillid);
}
 if (HasSkilllevel) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Skilllevel);
}
 if (HasSkillposition) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Skillposition);
}
 if (HasFlagnormal) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Flagnormal);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSkillid) {
output.WriteInt32(1, Skillid);
}
 
if (HasSkilllevel) {
output.WriteInt32(2, Skilllevel);
}
 
if (HasSkillposition) {
output.WriteInt32(3, Skillposition);
}
 
if (HasFlagnormal) {
output.WriteInt32(4, Flagnormal);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 SkillItemData _inst = (SkillItemData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Skillid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Skilllevel = input.ReadInt32();
break;
}
   case  24: {
 _inst.Skillposition = input.ReadInt32();
break;
}
   case  32: {
 _inst.Flagnormal = input.ReadInt32();
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
public class Titlel : PacketDistributed
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

public const int statusFieldNumber = 3;
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

public const int endtimeFieldNumber = 4;
 private bool hasEndtime;
 private Int64 endtime_ = 0;
 public bool HasEndtime {
 get { return hasEndtime; }
 }
 public Int64 Endtime {
 get { return endtime_; }
 set { SetEndtime(value); }
 }
 public void SetEndtime(Int64 value) { 
 hasEndtime = true;
 endtime_ = value;
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
 if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Flag);
}
 if (HasStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Status);
}
 if (HasEndtime) {
size += pb::CodedOutputStream.ComputeInt64Size(4, Endtime);
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
 
if (HasFlag) {
output.WriteInt32(2, Flag);
}
 
if (HasStatus) {
output.WriteInt32(3, Status);
}
 
if (HasEndtime) {
output.WriteInt64(4, Endtime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Titlel _inst = (Titlel) _base;
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
 _inst.Flag = input.ReadInt32();
break;
}
   case  24: {
 _inst.Status = input.ReadInt32();
break;
}
   case  32: {
 _inst.Endtime = input.ReadInt64();
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
public class TrapData : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
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

public const int itemsFieldNumber = 3;
 private pbc::PopsicleList<TrapItemData> items_ = new pbc::PopsicleList<TrapItemData>();
 public scg::IList<TrapItemData> itemsList {
 get { return pbc::Lists.AsReadOnly(items_); }
 }
 
 public int itemsCount {
 get { return items_.Count; }
 }
 
public TrapItemData GetItems(int index) {
 return items_[index];
 }
 public void AddItems(TrapItemData value) {
 items_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
{
foreach (TrapItemData element in itemsList) {
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
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}

do{
foreach (TrapItemData element in itemsList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TrapData _inst = (TrapData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
    case  26: {
TrapItemData subBuilder =  new TrapItemData();
input.ReadMessage(subBuilder);
_inst.AddItems(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TrapItemData element in itemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TrapItemData : PacketDistributed
{

public const int objIdFieldNumber = 1;
 private bool hasObjId;
 private Int64 objId_ = 0;
 public bool HasObjId {
 get { return hasObjId; }
 }
 public Int64 ObjId {
 get { return objId_; }
 set { SetObjId(value); }
 }
 public void SetObjId(Int64 value) { 
 hasObjId = true;
 objId_ = value;
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

public const int posFieldNumber = 3;
 private bool hasPos;
 private Vector3Info pos_ =  new Vector3Info();
 public bool HasPos {
 get { return hasPos; }
 }
 public Vector3Info Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Vector3Info value) { 
 hasPos = true;
 pos_ = value;
 }

public const int dirFieldNumber = 4;
 private bool hasDir;
 private Vector3Info dir_ =  new Vector3Info();
 public bool HasDir {
 get { return hasDir; }
 }
 public Vector3Info Dir {
 get { return dir_; }
 set { SetDir(value); }
 }
 public void SetDir(Vector3Info value) { 
 hasDir = true;
 dir_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasObjId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ObjId);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sid);
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Dir.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasObjId) {
output.WriteInt64(1, ObjId);
}
 
if (HasSid) {
output.WriteInt32(2, Sid);
}
{
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
{
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Dir.SerializedSize());
Dir.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TrapItemData _inst = (TrapItemData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ObjId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt32();
break;
}
    case  26: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
    case  34: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Dir = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasPos) {
if (!Pos.IsInitialized()) return false;
}
  if (HasDir) {
if (!Dir.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class Vector3Info : PacketDistributed
{

public const int xFieldNumber = 1;
 private bool hasX;
 private Int32 x_ = 0;
 public bool HasX {
 get { return hasX; }
 }
 public Int32 X {
 get { return x_; }
 set { SetX(value); }
 }
 public void SetX(Int32 value) { 
 hasX = true;
 x_ = value;
 }

public const int yFieldNumber = 2;
 private bool hasY;
 private Int32 y_ = 0;
 public bool HasY {
 get { return hasY; }
 }
 public Int32 Y {
 get { return y_; }
 set { SetY(value); }
 }
 public void SetY(Int32 value) { 
 hasY = true;
 y_ = value;
 }

public const int zFieldNumber = 3;
 private bool hasZ;
 private Int32 z_ = 0;
 public bool HasZ {
 get { return hasZ; }
 }
 public Int32 Z {
 get { return z_; }
 set { SetZ(value); }
 }
 public void SetZ(Int32 value) { 
 hasZ = true;
 z_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasX) {
size += pb::CodedOutputStream.ComputeInt32Size(1, X);
}
 if (HasY) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Y);
}
 if (HasZ) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Z);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasX) {
output.WriteInt32(1, X);
}
 
if (HasY) {
output.WriteInt32(2, Y);
}
 
if (HasZ) {
output.WriteInt32(3, Z);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Vector3Info _inst = (Vector3Info) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.X = input.ReadInt32();
break;
}
   case  16: {
 _inst.Y = input.ReadInt32();
break;
}
   case  24: {
 _inst.Z = input.ReadInt32();
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
public class VipData : PacketDistributed
{

public const int viplevelFieldNumber = 1;
 private bool hasViplevel;
 private Int32 viplevel_ = 0;
 public bool HasViplevel {
 get { return hasViplevel; }
 }
 public Int32 Viplevel {
 get { return viplevel_; }
 set { SetViplevel(value); }
 }
 public void SetViplevel(Int32 value) { 
 hasViplevel = true;
 viplevel_ = value;
 }

public const int getflagFieldNumber = 2;
 private bool hasGetflag;
 private Int32 getflag_ = 0;
 public bool HasGetflag {
 get { return hasGetflag; }
 }
 public Int32 Getflag {
 get { return getflag_; }
 set { SetGetflag(value); }
 }
 public void SetGetflag(Int32 value) { 
 hasGetflag = true;
 getflag_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasViplevel) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Viplevel);
}
 if (HasGetflag) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Getflag);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasViplevel) {
output.WriteInt32(1, Viplevel);
}
 
if (HasGetflag) {
output.WriteInt32(2, Getflag);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 VipData _inst = (VipData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Viplevel = input.ReadInt32();
break;
}
   case  16: {
 _inst.Getflag = input.ReadInt32();
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
