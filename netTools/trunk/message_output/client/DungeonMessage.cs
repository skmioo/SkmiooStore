//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class BossData : PacketDistributed
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

public const int starNumFieldNumber = 2;
 private bool hasStarNum;
 private Int32 starNum_ = 0;
 public bool HasStarNum {
 get { return hasStarNum; }
 }
 public Int32 StarNum {
 get { return starNum_; }
 set { SetStarNum(value); }
 }
 public void SetStarNum(Int32 value) { 
 hasStarNum = true;
 starNum_ = value;
 }

public const int datePkFieldNumber = 3;
 private bool hasDatePk;
 private Int32 datePk_ = 0;
 public bool HasDatePk {
 get { return hasDatePk; }
 }
 public Int32 DatePk {
 get { return datePk_; }
 set { SetDatePk(value); }
 }
 public void SetDatePk(Int32 value) { 
 hasDatePk = true;
 datePk_ = value;
 }

public const int unLockBossStsFieldNumber = 4;
 private bool hasUnLockBossSts;
 private Int32 unLockBossSts_ = 0;
 public bool HasUnLockBossSts {
 get { return hasUnLockBossSts; }
 }
 public Int32 UnLockBossSts {
 get { return unLockBossSts_; }
 set { SetUnLockBossSts(value); }
 }
 public void SetUnLockBossSts(Int32 value) { 
 hasUnLockBossSts = true;
 unLockBossSts_ = value;
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
 if (HasStarNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, StarNum);
}
 if (HasDatePk) {
size += pb::CodedOutputStream.ComputeInt32Size(3, DatePk);
}
 if (HasUnLockBossSts) {
size += pb::CodedOutputStream.ComputeInt32Size(4, UnLockBossSts);
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
 
if (HasStarNum) {
output.WriteInt32(2, StarNum);
}
 
if (HasDatePk) {
output.WriteInt32(3, DatePk);
}
 
if (HasUnLockBossSts) {
output.WriteInt32(4, UnLockBossSts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BossData _inst = (BossData) _base;
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
 _inst.StarNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.DatePk = input.ReadInt32();
break;
}
   case  32: {
 _inst.UnLockBossSts = input.ReadInt32();
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
public class BossOpenSts : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int stsFieldNumber = 2;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 
if (HasSts) {
output.WriteInt32(2, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BossOpenSts _inst = (BossOpenSts) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Sts = input.ReadInt32();
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
public class BossRank : PacketDistributed
{

public const int rankIdFieldNumber = 1;
 private bool hasRankId;
 private Int32 rankId_ = 0;
 public bool HasRankId {
 get { return hasRankId; }
 }
 public Int32 RankId {
 get { return rankId_; }
 set { SetRankId(value); }
 }
 public void SetRankId(Int32 value) { 
 hasRankId = true;
 rankId_ = value;
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

public const int playerNameFieldNumber = 3;
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

public const int useSecondsFieldNumber = 4;
 private bool hasUseSeconds;
 private Int32 useSeconds_ = 0;
 public bool HasUseSeconds {
 get { return hasUseSeconds; }
 }
 public Int32 UseSeconds {
 get { return useSeconds_; }
 set { SetUseSeconds(value); }
 }
 public void SetUseSeconds(Int32 value) { 
 hasUseSeconds = true;
 useSeconds_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRankId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, RankId);
}
 if (HasSid) {
size += pb::CodedOutputStream.ComputeInt64Size(2, Sid);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(3, PlayerName);
}
 if (HasUseSeconds) {
size += pb::CodedOutputStream.ComputeInt32Size(4, UseSeconds);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRankId) {
output.WriteInt32(1, RankId);
}
 
if (HasSid) {
output.WriteInt64(2, Sid);
}
 
if (HasPlayerName) {
output.WriteString(3, PlayerName);
}
 
if (HasUseSeconds) {
output.WriteInt32(4, UseSeconds);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 BossRank _inst = (BossRank) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.RankId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Sid = input.ReadInt64();
break;
}
   case  26: {
 _inst.PlayerName = input.ReadString();
break;
}
   case  32: {
 _inst.UseSeconds = input.ReadInt32();
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
public class CGBuyDungeonNum : PacketDistributed
{

public const int menusFieldNumber = 1;
 private bool hasMenus;
 private Int32 menus_ = 0;
 public bool HasMenus {
 get { return hasMenus; }
 }
 public Int32 Menus {
 get { return menus_; }
 set { SetMenus(value); }
 }
 public void SetMenus(Int32 value) { 
 hasMenus = true;
 menus_ = value;
 }

public const int buyNumFieldNumber = 2;
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
  if (HasMenus) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Menus);
}
 if (HasBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BuyNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMenus) {
output.WriteInt32(1, Menus);
}
 
if (HasBuyNum) {
output.WriteInt32(2, BuyNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuyDungeonNum _inst = (CGBuyDungeonNum) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Menus = input.ReadInt32();
break;
}
   case  16: {
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
public class CGChangeGuideId : PacketDistributed
{

public const int guideIdFieldNumber = 1;
 private bool hasGuideId;
 private Int32 guideId_ = 0;
 public bool HasGuideId {
 get { return hasGuideId; }
 }
 public Int32 GuideId {
 get { return guideId_; }
 set { SetGuideId(value); }
 }
 public void SetGuideId(Int32 value) { 
 hasGuideId = true;
 guideId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGuideId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GuideId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGuideId) {
output.WriteInt32(1, GuideId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGChangeGuideId _inst = (CGChangeGuideId) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GuideId = input.ReadInt32();
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
public class CGChangeSchedule : PacketDistributed
{

public const int scheduleFieldNumber = 1;
 private bool hasSchedule;
 private Int32 schedule_ = 0;
 public bool HasSchedule {
 get { return hasSchedule; }
 }
 public Int32 Schedule {
 get { return schedule_; }
 set { SetSchedule(value); }
 }
 public void SetSchedule(Int32 value) { 
 hasSchedule = true;
 schedule_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSchedule) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Schedule);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSchedule) {
output.WriteInt32(1, Schedule);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGChangeSchedule _inst = (CGChangeSchedule) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Schedule = input.ReadInt32();
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
public class CGEnterInstancing : PacketDistributed
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
 CGEnterInstancing _inst = (CGEnterInstancing) _base;
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
public class CGExitDungeon : PacketDistributed
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
 CGExitDungeon _inst = (CGExitDungeon) _base;
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
public class CGExitPersonBoss : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 2;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int bossIdFieldNumber = 3;
 private bool hasBossId;
 private Int32 bossId_ = 0;
 public bool HasBossId {
 get { return hasBossId; }
 }
 public Int32 BossId {
 get { return bossId_; }
 set { SetBossId(value); }
 }
 public void SetBossId(Int32 value) { 
 hasBossId = true;
 bossId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChildChapterId);
}
 if (HasBossId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BossId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(2, ChildChapterId);
}
 
if (HasBossId) {
output.WriteInt32(3, BossId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGExitPersonBoss _inst = (CGExitPersonBoss) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  24: {
 _inst.BossId = input.ReadInt32();
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
public class CGGetBossRanks : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 2;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int bossIdFieldNumber = 3;
 private bool hasBossId;
 private Int32 bossId_ = 0;
 public bool HasBossId {
 get { return hasBossId; }
 }
 public Int32 BossId {
 get { return bossId_; }
 set { SetBossId(value); }
 }
 public void SetBossId(Int32 value) { 
 hasBossId = true;
 bossId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChildChapterId);
}
 if (HasBossId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BossId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(2, ChildChapterId);
}
 
if (HasBossId) {
output.WriteInt32(3, BossId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetBossRanks _inst = (CGGetBossRanks) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  24: {
 _inst.BossId = input.ReadInt32();
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
public class CGGetBossView : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetBossView _inst = (CGGetBossView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
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
public class CGGetPackRwd : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 2;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int bossIdFieldNumber = 3;
 private bool hasBossId;
 private Int32 bossId_ = 0;
 public bool HasBossId {
 get { return hasBossId; }
 }
 public Int32 BossId {
 get { return bossId_; }
 set { SetBossId(value); }
 }
 public void SetBossId(Int32 value) { 
 hasBossId = true;
 bossId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChildChapterId);
}
 if (HasBossId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BossId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(2, ChildChapterId);
}
 
if (HasBossId) {
output.WriteInt32(3, BossId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetPackRwd _inst = (CGGetPackRwd) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  24: {
 _inst.BossId = input.ReadInt32();
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
public class CGPkBoss : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 2;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int bossIdFieldNumber = 3;
 private bool hasBossId;
 private Int32 bossId_ = 0;
 public bool HasBossId {
 get { return hasBossId; }
 }
 public Int32 BossId {
 get { return bossId_; }
 set { SetBossId(value); }
 }
 public void SetBossId(Int32 value) { 
 hasBossId = true;
 bossId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChildChapterId);
}
 if (HasBossId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BossId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(2, ChildChapterId);
}
 
if (HasBossId) {
output.WriteInt32(3, BossId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGPkBoss _inst = (CGPkBoss) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  24: {
 _inst.BossId = input.ReadInt32();
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
public class CGResponseEnterDungeon : PacketDistributed
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

public const int stsFieldNumber = 2;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
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
 if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sts);
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
 
if (HasSts) {
output.WriteInt32(2, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGResponseEnterDungeon _inst = (CGResponseEnterDungeon) _base;
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
 _inst.Sts = input.ReadInt32();
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
public class CGSweepDungeon : PacketDistributed
{

public const int sweepTypeFieldNumber = 1;
 private bool hasSweepType;
 private Int32 sweepType_ = 0;
 public bool HasSweepType {
 get { return hasSweepType; }
 }
 public Int32 SweepType {
 get { return sweepType_; }
 set { SetSweepType(value); }
 }
 public void SetSweepType(Int32 value) { 
 hasSweepType = true;
 sweepType_ = value;
 }

public const int idFieldNumber = 2;
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
  if (HasSweepType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, SweepType);
}
 if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Id);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSweepType) {
output.WriteInt32(1, SweepType);
}
 
if (HasId) {
output.WriteInt32(2, Id);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSweepDungeon _inst = (CGSweepDungeon) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SweepType = input.ReadInt32();
break;
}
   case  16: {
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
public class ChapterBossData : PacketDistributed
{

public const int bossListFieldNumber = 1;
 private pbc::PopsicleList<BossData> bossList_ = new pbc::PopsicleList<BossData>();
 public scg::IList<BossData> bossListList {
 get { return pbc::Lists.AsReadOnly(bossList_); }
 }
 
 public int bossListCount {
 get { return bossList_.Count; }
 }
 
public BossData GetBossList(int index) {
 return bossList_[index];
 }
 public void AddBossList(BossData value) {
 bossList_.Add(value);
 }

public const int packStarNumFieldNumber = 2;
 private bool hasPackStarNum;
 private Int32 packStarNum_ = 0;
 public bool HasPackStarNum {
 get { return hasPackStarNum; }
 }
 public Int32 PackStarNum {
 get { return packStarNum_; }
 set { SetPackStarNum(value); }
 }
 public void SetPackStarNum(Int32 value) { 
 hasPackStarNum = true;
 packStarNum_ = value;
 }

public const int childChapterIdFieldNumber = 3;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int packRwdStatusFieldNumber = 4;
 private bool hasPackRwdStatus;
 private Int32 packRwdStatus_ = 0;
 public bool HasPackRwdStatus {
 get { return hasPackRwdStatus; }
 }
 public Int32 PackRwdStatus {
 get { return packRwdStatus_; }
 set { SetPackRwdStatus(value); }
 }
 public void SetPackRwdStatus(Int32 value) { 
 hasPackRwdStatus = true;
 packRwdStatus_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (BossData element in bossListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasPackStarNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PackStarNum);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ChildChapterId);
}
 if (HasPackRwdStatus) {
size += pb::CodedOutputStream.ComputeInt32Size(4, PackRwdStatus);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (BossData element in bossListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasPackStarNum) {
output.WriteInt32(2, PackStarNum);
}
 
if (HasChildChapterId) {
output.WriteInt32(3, ChildChapterId);
}
 
if (HasPackRwdStatus) {
output.WriteInt32(4, PackRwdStatus);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ChapterBossData _inst = (ChapterBossData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BossData subBuilder =  new BossData();
input.ReadMessage(subBuilder);
_inst.AddBossList(subBuilder);
break;
}
   case  16: {
 _inst.PackStarNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  32: {
 _inst.PackRwdStatus = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BossData element in bossListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class DungeonItemsRwd : PacketDistributed
{

public const int itemIdFieldNumber = 1;
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

public const int numFieldNumber = 2;
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

public const int bindFieldNumber = 3;
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
  if (HasItemId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ItemId);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Num);
}
 if (HasBind) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Bind);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasItemId) {
output.WriteInt32(1, ItemId);
}
 
if (HasNum) {
output.WriteInt32(2, Num);
}
 
if (HasBind) {
output.WriteInt32(3, Bind);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 DungeonItemsRwd _inst = (DungeonItemsRwd) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ItemId = input.ReadInt32();
break;
}
   case  16: {
 _inst.Num = input.ReadInt32();
break;
}
   case  24: {
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
public class GCAllMenusDatas : PacketDistributed
{

public const int menusFieldNumber = 1;
 private pbc::PopsicleList<GCMenusData> menus_ = new pbc::PopsicleList<GCMenusData>();
 public scg::IList<GCMenusData> menusList {
 get { return pbc::Lists.AsReadOnly(menus_); }
 }
 
 public int menusCount {
 get { return menus_.Count; }
 }
 
public GCMenusData GetMenus(int index) {
 return menus_[index];
 }
 public void AddMenus(GCMenusData value) {
 menus_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GCMenusData element in menusList) {
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
foreach (GCMenusData element in menusList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAllMenusDatas _inst = (GCAllMenusDatas) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GCMenusData subBuilder =  new GCMenusData();
input.ReadMessage(subBuilder);
_inst.AddMenus(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCMenusData element in menusList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCAskEnterDungeon : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(2, PlayerName);
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
 
if (HasPlayerName) {
output.WriteString(2, PlayerName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAskEnterDungeon _inst = (GCAskEnterDungeon) _base;
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
 _inst.PlayerName = input.ReadString();
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
public class GCChangeBossStar : PacketDistributed
{

public const int bossListFieldNumber = 1;
 private pbc::PopsicleList<BossData> bossList_ = new pbc::PopsicleList<BossData>();
 public scg::IList<BossData> bossListList {
 get { return pbc::Lists.AsReadOnly(bossList_); }
 }
 
 public int bossListCount {
 get { return bossList_.Count; }
 }
 
public BossData GetBossList(int index) {
 return bossList_[index];
 }
 public void AddBossList(BossData value) {
 bossList_.Add(value);
 }

public const int chapterIdFieldNumber = 2;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 3;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int packStartNumFieldNumber = 4;
 private bool hasPackStartNum;
 private Int32 packStartNum_ = 0;
 public bool HasPackStartNum {
 get { return hasPackStartNum; }
 }
 public Int32 PackStartNum {
 get { return packStartNum_; }
 set { SetPackStartNum(value); }
 }
 public void SetPackStartNum(Int32 value) { 
 hasPackStartNum = true;
 packStartNum_ = value;
 }

public const int rewardStsFieldNumber = 5;
 private bool hasRewardSts;
 private Int32 rewardSts_ = 0;
 public bool HasRewardSts {
 get { return hasRewardSts; }
 }
 public Int32 RewardSts {
 get { return rewardSts_; }
 set { SetRewardSts(value); }
 }
 public void SetRewardSts(Int32 value) { 
 hasRewardSts = true;
 rewardSts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (BossData element in bossListList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ChildChapterId);
}
 if (HasPackStartNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, PackStartNum);
}
 if (HasRewardSts) {
size += pb::CodedOutputStream.ComputeInt32Size(5, RewardSts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (BossData element in bossListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasChapterId) {
output.WriteInt32(2, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(3, ChildChapterId);
}
 
if (HasPackStartNum) {
output.WriteInt32(4, PackStartNum);
}
 
if (HasRewardSts) {
output.WriteInt32(5, RewardSts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChangeBossStar _inst = (GCChangeBossStar) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BossData subBuilder =  new BossData();
input.ReadMessage(subBuilder);
_inst.AddBossList(subBuilder);
break;
}
   case  16: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  24: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  32: {
 _inst.PackStartNum = input.ReadInt32();
break;
}
   case  40: {
 _inst.RewardSts = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BossData element in bossListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCChangeSchedule : PacketDistributed
{

public const int scheduleFieldNumber = 1;
 private bool hasSchedule;
 private Int32 schedule_ = 0;
 public bool HasSchedule {
 get { return hasSchedule; }
 }
 public Int32 Schedule {
 get { return schedule_; }
 set { SetSchedule(value); }
 }
 public void SetSchedule(Int32 value) { 
 hasSchedule = true;
 schedule_ = value;
 }

public const int changeTimeFieldNumber = 2;
 private bool hasChangeTime;
 private Int64 changeTime_ = 0;
 public bool HasChangeTime {
 get { return hasChangeTime; }
 }
 public Int64 ChangeTime {
 get { return changeTime_; }
 set { SetChangeTime(value); }
 }
 public void SetChangeTime(Int64 value) { 
 hasChangeTime = true;
 changeTime_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSchedule) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Schedule);
}
 if (HasChangeTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ChangeTime);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSchedule) {
output.WriteInt32(1, Schedule);
}
 
if (HasChangeTime) {
output.WriteInt64(2, ChangeTime);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChangeSchedule _inst = (GCChangeSchedule) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Schedule = input.ReadInt32();
break;
}
   case  16: {
 _inst.ChangeTime = input.ReadInt64();
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
public class GCClearBossData : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCClearBossData _inst = (GCClearBossData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
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
public class GCDungeonEnd : PacketDistributed
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

public const int stsFieldNumber = 2;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

public const int rwdsFieldNumber = 3;
 private pbc::PopsicleList<DungeonItemsRwd> rwds_ = new pbc::PopsicleList<DungeonItemsRwd>();
 public scg::IList<DungeonItemsRwd> rwdsList {
 get { return pbc::Lists.AsReadOnly(rwds_); }
 }
 
 public int rwdsCount {
 get { return rwds_.Count; }
 }
 
public DungeonItemsRwd GetRwds(int index) {
 return rwds_[index];
 }
 public void AddRwds(DungeonItemsRwd value) {
 rwds_.Add(value);
 }

public const int menusFieldNumber = 4;
 private bool hasMenus;
 private Int32 menus_ = 0;
 public bool HasMenus {
 get { return hasMenus; }
 }
 public Int32 Menus {
 get { return menus_; }
 set { SetMenus(value); }
 }
 public void SetMenus(Int32 value) { 
 hasMenus = true;
 menus_ = value;
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
 if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sts);
}
{
foreach (DungeonItemsRwd element in rwdsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasMenus) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Menus);
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
 
if (HasSts) {
output.WriteInt32(2, Sts);
}

do{
foreach (DungeonItemsRwd element in rwdsList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasMenus) {
output.WriteInt32(4, Menus);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDungeonEnd _inst = (GCDungeonEnd) _base;
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
 _inst.Sts = input.ReadInt32();
break;
}
    case  26: {
DungeonItemsRwd subBuilder =  new DungeonItemsRwd();
input.ReadMessage(subBuilder);
_inst.AddRwds(subBuilder);
break;
}
   case  32: {
 _inst.Menus = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (DungeonItemsRwd element in rwdsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCEnterInstancing : PacketDistributed
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

public const int endTimeFieldNumber = 2;
 private bool hasEndTime;
 private Int64 endTime_ = 0;
 public bool HasEndTime {
 get { return hasEndTime; }
 }
 public Int64 EndTime {
 get { return endTime_; }
 set { SetEndTime(value); }
 }
 public void SetEndTime(Int64 value) { 
 hasEndTime = true;
 endTime_ = value;
 }

public const int guideIdsFieldNumber = 3;
 private pbc::PopsicleList<Int32> guideIds_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> guideIdsList {
 get { return pbc::Lists.AsReadOnly(guideIds_); }
 }
 
 public int guideIdsCount {
 get { return guideIds_.Count; }
 }
 
public Int32 GetGuideIds(int index) {
 return guideIds_[index];
 }
 public void AddGuideIds(Int32 value) {
 guideIds_.Add(value);
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
 if (HasEndTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, EndTime);
}
{
int dataSize = 0;
foreach (Int32 element in guideIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * guideIds_.Count;
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
 
if (HasEndTime) {
output.WriteInt64(2, EndTime);
}
{
if (guideIds_.Count > 0) {
foreach (Int32 element in guideIdsList) {
output.WriteInt32(3,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCEnterInstancing _inst = (GCEnterInstancing) _base;
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
 _inst.EndTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.AddGuideIds(input.ReadInt32());
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
public class GCFastestPlayer : PacketDistributed
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

public const int passTimeFieldNumber = 2;
 private bool hasPassTime;
 private Int32 passTime_ = 0;
 public bool HasPassTime {
 get { return hasPassTime; }
 }
 public Int32 PassTime {
 get { return passTime_; }
 set { SetPassTime(value); }
 }
 public void SetPassTime(Int32 value) { 
 hasPassTime = true;
 passTime_ = value;
 }

public const int passTimeNameFieldNumber = 3;
 private bool hasPassTimeName;
 private string passTimeName_ = "";
 public bool HasPassTimeName {
 get { return hasPassTimeName; }
 }
 public string PassTimeName {
 get { return passTimeName_; }
 set { SetPassTimeName(value); }
 }
 public void SetPassTimeName(string value) { 
 hasPassTimeName = true;
 passTimeName_ = value;
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
 if (HasPassTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, PassTime);
}
 if (HasPassTimeName) {
size += pb::CodedOutputStream.ComputeStringSize(3, PassTimeName);
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
 
if (HasPassTime) {
output.WriteInt32(2, PassTime);
}
 
if (HasPassTimeName) {
output.WriteString(3, PassTimeName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFastestPlayer _inst = (GCFastestPlayer) _base;
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
 _inst.PassTime = input.ReadInt32();
break;
}
   case  26: {
 _inst.PassTimeName = input.ReadString();
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
public class GCGetBossRanks : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 2;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int bossIdFieldNumber = 3;
 private bool hasBossId;
 private Int32 bossId_ = 0;
 public bool HasBossId {
 get { return hasBossId; }
 }
 public Int32 BossId {
 get { return bossId_; }
 set { SetBossId(value); }
 }
 public void SetBossId(Int32 value) { 
 hasBossId = true;
 bossId_ = value;
 }

public const int ranksFieldNumber = 4;
 private pbc::PopsicleList<BossRank> ranks_ = new pbc::PopsicleList<BossRank>();
 public scg::IList<BossRank> ranksList {
 get { return pbc::Lists.AsReadOnly(ranks_); }
 }
 
 public int ranksCount {
 get { return ranks_.Count; }
 }
 
public BossRank GetRanks(int index) {
 return ranks_[index];
 }
 public void AddRanks(BossRank value) {
 ranks_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ChildChapterId);
}
 if (HasBossId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BossId);
}
{
foreach (BossRank element in ranksList) {
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
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(2, ChildChapterId);
}
 
if (HasBossId) {
output.WriteInt32(3, BossId);
}

do{
foreach (BossRank element in ranksList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetBossRanks _inst = (GCGetBossRanks) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  24: {
 _inst.BossId = input.ReadInt32();
break;
}
    case  34: {
BossRank subBuilder =  new BossRank();
input.ReadMessage(subBuilder);
_inst.AddRanks(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BossRank element in ranksList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCGetBossView : PacketDistributed
{

public const int chapterIdFieldNumber = 1;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int chapterListFieldNumber = 2;
 private pbc::PopsicleList<ChapterBossData> chapterList_ = new pbc::PopsicleList<ChapterBossData>();
 public scg::IList<ChapterBossData> chapterListList {
 get { return pbc::Lists.AsReadOnly(chapterList_); }
 }
 
 public int chapterListCount {
 get { return chapterList_.Count; }
 }
 
public ChapterBossData GetChapterList(int index) {
 return chapterList_[index];
 }
 public void AddChapterList(ChapterBossData value) {
 chapterList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, ChapterId);
}
{
foreach (ChapterBossData element in chapterListList) {
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
  
if (HasChapterId) {
output.WriteInt32(1, ChapterId);
}

do{
foreach (ChapterBossData element in chapterListList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetBossView _inst = (GCGetBossView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ChapterId = input.ReadInt32();
break;
}
    case  18: {
ChapterBossData subBuilder =  new ChapterBossData();
input.ReadMessage(subBuilder);
_inst.AddChapterList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ChapterBossData element in chapterListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCInstancingData : PacketDistributed
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

public const int selfPassTimeFieldNumber = 3;
 private bool hasSelfPassTime;
 private Int32 selfPassTime_ = 0;
 public bool HasSelfPassTime {
 get { return hasSelfPassTime; }
 }
 public Int32 SelfPassTime {
 get { return selfPassTime_; }
 set { SetSelfPassTime(value); }
 }
 public void SetSelfPassTime(Int32 value) { 
 hasSelfPassTime = true;
 selfPassTime_ = value;
 }

public const int canEnterFieldNumber = 4;
 private bool hasCanEnter;
 private Int32 canEnter_ = 0;
 public bool HasCanEnter {
 get { return hasCanEnter; }
 }
 public Int32 CanEnter {
 get { return canEnter_; }
 set { SetCanEnter(value); }
 }
 public void SetCanEnter(Int32 value) { 
 hasCanEnter = true;
 canEnter_ = value;
 }

public const int canSweepFieldNumber = 5;
 private bool hasCanSweep;
 private Int32 canSweep_ = 0;
 public bool HasCanSweep {
 get { return hasCanSweep; }
 }
 public Int32 CanSweep {
 get { return canSweep_; }
 set { SetCanSweep(value); }
 }
 public void SetCanSweep(Int32 value) { 
 hasCanSweep = true;
 canSweep_ = value;
 }

public const int isPassFieldNumber = 6;
 private bool hasIsPass;
 private Int32 isPass_ = 0;
 public bool HasIsPass {
 get { return hasIsPass; }
 }
 public Int32 IsPass {
 get { return isPass_; }
 set { SetIsPass(value); }
 }
 public void SetIsPass(Int32 value) { 
 hasIsPass = true;
 isPass_ = value;
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
 if (HasCurrNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, CurrNum);
}
 if (HasSelfPassTime) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SelfPassTime);
}
 if (HasCanEnter) {
size += pb::CodedOutputStream.ComputeInt32Size(4, CanEnter);
}
 if (HasCanSweep) {
size += pb::CodedOutputStream.ComputeInt32Size(5, CanSweep);
}
 if (HasIsPass) {
size += pb::CodedOutputStream.ComputeInt32Size(6, IsPass);
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
 
if (HasCurrNum) {
output.WriteInt32(2, CurrNum);
}
 
if (HasSelfPassTime) {
output.WriteInt32(3, SelfPassTime);
}
 
if (HasCanEnter) {
output.WriteInt32(4, CanEnter);
}
 
if (HasCanSweep) {
output.WriteInt32(5, CanSweep);
}
 
if (HasIsPass) {
output.WriteInt32(6, IsPass);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInstancingData _inst = (GCInstancingData) _base;
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
 _inst.CurrNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.SelfPassTime = input.ReadInt32();
break;
}
   case  32: {
 _inst.CanEnter = input.ReadInt32();
break;
}
   case  40: {
 _inst.CanSweep = input.ReadInt32();
break;
}
   case  48: {
 _inst.IsPass = input.ReadInt32();
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
public class GCInstancingErrorMessage : PacketDistributed
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

public const int codeFieldNumber = 2;
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

public const int paramFieldNumber = 4;
 private bool hasParam;
 private Int32 param_ = 0;
 public bool HasParam {
 get { return hasParam; }
 }
 public Int32 Param {
 get { return param_; }
 set { SetParam(value); }
 }
 public void SetParam(Int32 value) { 
 hasParam = true;
 param_ = value;
 }

public const int paramTypeFieldNumber = 5;
 private bool hasParamType;
 private Int32 paramType_ = 0;
 public bool HasParamType {
 get { return hasParamType; }
 }
 public Int32 ParamType {
 get { return paramType_; }
 set { SetParamType(value); }
 }
 public void SetParamType(Int32 value) { 
 hasParamType = true;
 paramType_ = value;
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
 if (HasCode) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Code);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(3, Name);
}
 if (HasParam) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Param);
}
 if (HasParamType) {
size += pb::CodedOutputStream.ComputeInt32Size(5, ParamType);
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
 
if (HasCode) {
output.WriteInt32(2, Code);
}
 
if (HasName) {
output.WriteString(3, Name);
}
 
if (HasParam) {
output.WriteInt32(4, Param);
}
 
if (HasParamType) {
output.WriteInt32(5, ParamType);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInstancingErrorMessage _inst = (GCInstancingErrorMessage) _base;
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
 _inst.Code = input.ReadInt32();
break;
}
   case  26: {
 _inst.Name = input.ReadString();
break;
}
   case  32: {
 _inst.Param = input.ReadInt32();
break;
}
   case  40: {
 _inst.ParamType = input.ReadInt32();
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
public class GCInstancingRwdSchedule : PacketDistributed
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

public const int killNumFieldNumber = 2;
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

public const int expFieldNumber = 3;
 private bool hasExp;
 private Int32 exp_ = 0;
 public bool HasExp {
 get { return hasExp; }
 }
 public Int32 Exp {
 get { return exp_; }
 set { SetExp(value); }
 }
 public void SetExp(Int32 value) { 
 hasExp = true;
 exp_ = value;
 }

public const int boNumFieldNumber = 4;
 private bool hasBoNum;
 private Int32 boNum_ = 0;
 public bool HasBoNum {
 get { return hasBoNum; }
 }
 public Int32 BoNum {
 get { return boNum_; }
 set { SetBoNum(value); }
 }
 public void SetBoNum(Int32 value) { 
 hasBoNum = true;
 boNum_ = value;
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
 if (HasKillNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, KillNum);
}
 if (HasExp) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Exp);
}
 if (HasBoNum) {
size += pb::CodedOutputStream.ComputeInt32Size(4, BoNum);
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
 
if (HasKillNum) {
output.WriteInt32(2, KillNum);
}
 
if (HasExp) {
output.WriteInt32(3, Exp);
}
 
if (HasBoNum) {
output.WriteInt32(4, BoNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInstancingRwdSchedule _inst = (GCInstancingRwdSchedule) _base;
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
 _inst.KillNum = input.ReadInt32();
break;
}
   case  24: {
 _inst.Exp = input.ReadInt32();
break;
}
   case  32: {
 _inst.BoNum = input.ReadInt32();
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
public class GCInstancingStart : PacketDistributed
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

public const int timeFieldNumber = 2;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Id);
}
 if (HasTime) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Time);
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
 
if (HasTime) {
output.WriteInt32(2, Time);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInstancingStart _inst = (GCInstancingStart) _base;
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
 _inst.Time = input.ReadInt32();
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
public class GCMenusData : PacketDistributed
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

public const int currentFieldNumber = 2;
 private bool hasCurrent;
 private Int32 current_ = 0;
 public bool HasCurrent {
 get { return hasCurrent; }
 }
 public Int32 Current {
 get { return current_; }
 set { SetCurrent(value); }
 }
 public void SetCurrent(Int32 value) { 
 hasCurrent = true;
 current_ = value;
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

public const int instancingDatasFieldNumber = 4;
 private pbc::PopsicleList<GCInstancingData> instancingDatas_ = new pbc::PopsicleList<GCInstancingData>();
 public scg::IList<GCInstancingData> instancingDatasList {
 get { return pbc::Lists.AsReadOnly(instancingDatas_); }
 }
 
 public int instancingDatasCount {
 get { return instancingDatas_.Count; }
 }
 
public GCInstancingData GetInstancingDatas(int index) {
 return instancingDatas_[index];
 }
 public void AddInstancingDatas(GCInstancingData value) {
 instancingDatas_.Add(value);
 }

public const int playersFieldNumber = 5;
 private pbc::PopsicleList<GCFastestPlayer> players_ = new pbc::PopsicleList<GCFastestPlayer>();
 public scg::IList<GCFastestPlayer> playersList {
 get { return pbc::Lists.AsReadOnly(players_); }
 }
 
 public int playersCount {
 get { return players_.Count; }
 }
 
public GCFastestPlayer GetPlayers(int index) {
 return players_[index];
 }
 public void AddPlayers(GCFastestPlayer value) {
 players_.Add(value);
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
 if (HasCurrent) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Current);
}
 if (HasBuyNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, BuyNum);
}
{
foreach (GCInstancingData element in instancingDatasList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)4) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (GCFastestPlayer element in playersList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)5) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
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
 
if (HasCurrent) {
output.WriteInt32(2, Current);
}
 
if (HasBuyNum) {
output.WriteInt32(3, BuyNum);
}

do{
foreach (GCInstancingData element in instancingDatasList) {
output.WriteTag((int)4, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (GCFastestPlayer element in playersList) {
output.WriteTag((int)5, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMenusData _inst = (GCMenusData) _base;
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
 _inst.Current = input.ReadInt32();
break;
}
   case  24: {
 _inst.BuyNum = input.ReadInt32();
break;
}
    case  34: {
GCInstancingData subBuilder =  new GCInstancingData();
input.ReadMessage(subBuilder);
_inst.AddInstancingDatas(subBuilder);
break;
}
    case  42: {
GCFastestPlayer subBuilder =  new GCFastestPlayer();
input.ReadMessage(subBuilder);
_inst.AddPlayers(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCInstancingData element in instancingDatasList) {
if (!element.IsInitialized()) return false;
}
foreach (GCFastestPlayer element in playersList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCPKBossResult : PacketDistributed
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

public const int starNumFieldNumber = 2;
 private bool hasStarNum;
 private Int32 starNum_ = 0;
 public bool HasStarNum {
 get { return hasStarNum; }
 }
 public Int32 StarNum {
 get { return starNum_; }
 set { SetStarNum(value); }
 }
 public void SetStarNum(Int32 value) { 
 hasStarNum = true;
 starNum_ = value;
 }

public const int useSecondsFieldNumber = 4;
 private bool hasUseSeconds;
 private Int32 useSeconds_ = 0;
 public bool HasUseSeconds {
 get { return hasUseSeconds; }
 }
 public Int32 UseSeconds {
 get { return useSeconds_; }
 set { SetUseSeconds(value); }
 }
 public void SetUseSeconds(Int32 value) { 
 hasUseSeconds = true;
 useSeconds_ = value;
 }

public const int chapterIdFieldNumber = 5;
 private bool hasChapterId;
 private Int32 chapterId_ = 0;
 public bool HasChapterId {
 get { return hasChapterId; }
 }
 public Int32 ChapterId {
 get { return chapterId_; }
 set { SetChapterId(value); }
 }
 public void SetChapterId(Int32 value) { 
 hasChapterId = true;
 chapterId_ = value;
 }

public const int childChapterIdFieldNumber = 6;
 private bool hasChildChapterId;
 private Int32 childChapterId_ = 0;
 public bool HasChildChapterId {
 get { return hasChildChapterId; }
 }
 public Int32 ChildChapterId {
 get { return childChapterId_; }
 set { SetChildChapterId(value); }
 }
 public void SetChildChapterId(Int32 value) { 
 hasChildChapterId = true;
 childChapterId_ = value;
 }

public const int bossIdFieldNumber = 7;
 private bool hasBossId;
 private Int32 bossId_ = 0;
 public bool HasBossId {
 get { return hasBossId; }
 }
 public Int32 BossId {
 get { return bossId_; }
 set { SetBossId(value); }
 }
 public void SetBossId(Int32 value) { 
 hasBossId = true;
 bossId_ = value;
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
 if (HasStarNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, StarNum);
}
 if (HasUseSeconds) {
size += pb::CodedOutputStream.ComputeInt32Size(4, UseSeconds);
}
 if (HasChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, ChapterId);
}
 if (HasChildChapterId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ChildChapterId);
}
 if (HasBossId) {
size += pb::CodedOutputStream.ComputeInt32Size(7, BossId);
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
 
if (HasStarNum) {
output.WriteInt32(2, StarNum);
}
 
if (HasUseSeconds) {
output.WriteInt32(4, UseSeconds);
}
 
if (HasChapterId) {
output.WriteInt32(5, ChapterId);
}
 
if (HasChildChapterId) {
output.WriteInt32(6, ChildChapterId);
}
 
if (HasBossId) {
output.WriteInt32(7, BossId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPKBossResult _inst = (GCPKBossResult) _base;
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
 _inst.StarNum = input.ReadInt32();
break;
}
   case  32: {
 _inst.UseSeconds = input.ReadInt32();
break;
}
   case  40: {
 _inst.ChapterId = input.ReadInt32();
break;
}
   case  48: {
 _inst.ChildChapterId = input.ReadInt32();
break;
}
   case  56: {
 _inst.BossId = input.ReadInt32();
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
public class GCPersonBossOpenSts : PacketDistributed
{

public const int stsListFieldNumber = 1;
 private pbc::PopsicleList<BossOpenSts> stsList_ = new pbc::PopsicleList<BossOpenSts>();
 public scg::IList<BossOpenSts> stsListList {
 get { return pbc::Lists.AsReadOnly(stsList_); }
 }
 
 public int stsListCount {
 get { return stsList_.Count; }
 }
 
public BossOpenSts GetStsList(int index) {
 return stsList_[index];
 }
 public void AddStsList(BossOpenSts value) {
 stsList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (BossOpenSts element in stsListList) {
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
foreach (BossOpenSts element in stsListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPersonBossOpenSts _inst = (GCPersonBossOpenSts) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
BossOpenSts subBuilder =  new BossOpenSts();
input.ReadMessage(subBuilder);
_inst.AddStsList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BossOpenSts element in stsListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSweepDungeon : PacketDistributed
{

public const int rwdsFieldNumber = 1;
 private pbc::PopsicleList<DungeonItemsRwd> rwds_ = new pbc::PopsicleList<DungeonItemsRwd>();
 public scg::IList<DungeonItemsRwd> rwdsList {
 get { return pbc::Lists.AsReadOnly(rwds_); }
 }
 
 public int rwdsCount {
 get { return rwds_.Count; }
 }
 
public DungeonItemsRwd GetRwds(int index) {
 return rwds_[index];
 }
 public void AddRwds(DungeonItemsRwd value) {
 rwds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (DungeonItemsRwd element in rwdsList) {
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
foreach (DungeonItemsRwd element in rwdsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSweepDungeon _inst = (GCSweepDungeon) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
DungeonItemsRwd subBuilder =  new DungeonItemsRwd();
input.ReadMessage(subBuilder);
_inst.AddRwds(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (DungeonItemsRwd element in rwdsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSweepTower : PacketDistributed
{

public const int rwdsFieldNumber = 1;
 private pbc::PopsicleList<GCDungeonEnd> rwds_ = new pbc::PopsicleList<GCDungeonEnd>();
 public scg::IList<GCDungeonEnd> rwdsList {
 get { return pbc::Lists.AsReadOnly(rwds_); }
 }
 
 public int rwdsCount {
 get { return rwds_.Count; }
 }
 
public GCDungeonEnd GetRwds(int index) {
 return rwds_[index];
 }
 public void AddRwds(GCDungeonEnd value) {
 rwds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (GCDungeonEnd element in rwdsList) {
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
foreach (GCDungeonEnd element in rwdsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSweepTower _inst = (GCSweepTower) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
GCDungeonEnd subBuilder =  new GCDungeonEnd();
input.ReadMessage(subBuilder);
_inst.AddRwds(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (GCDungeonEnd element in rwdsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
