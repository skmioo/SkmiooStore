// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: TowerMessage.proto

#ifndef PROTOBUF_TowerMessage_2eproto__INCLUDED
#define PROTOBUF_TowerMessage_2eproto__INCLUDED

#include <string>

#include <google/protobuf/stubs/common.h>

#if GOOGLE_PROTOBUF_VERSION < 2006000
#error This file was generated by a newer version of protoc which is
#error incompatible with your Protocol Buffer headers.  Please update
#error your headers.
#endif
#if 2006000 < GOOGLE_PROTOBUF_MIN_PROTOC_VERSION
#error This file was generated by an older version of protoc which is
#error incompatible with your Protocol Buffer headers.  Please
#error regenerate this file with a newer version of protoc.
#endif

#include <google/protobuf/generated_message_util.h>
#include <google/protobuf/message.h>
#include <google/protobuf/repeated_field.h>
#include <google/protobuf/extension_set.h>
#include <google/protobuf/unknown_field_set.h>
// @@protoc_insertion_point(includes)

// Internal implementation detail -- do not call these.
void  protobuf_AddDesc_TowerMessage_2eproto();
void protobuf_AssignDesc_TowerMessage_2eproto();
void protobuf_ShutdownFile_TowerMessage_2eproto();

class TowerInfo;
class CGTowerSend;
class RewardItem;
class GCTowerPush;

// ===================================================================

class TowerInfo : public ::google::protobuf::Message {
 public:
  TowerInfo();
  virtual ~TowerInfo();

  TowerInfo(const TowerInfo& from);

  inline TowerInfo& operator=(const TowerInfo& from) {
    CopyFrom(from);
    return *this;
  }

  inline const ::google::protobuf::UnknownFieldSet& unknown_fields() const {
    return _unknown_fields_;
  }

  inline ::google::protobuf::UnknownFieldSet* mutable_unknown_fields() {
    return &_unknown_fields_;
  }

  static const ::google::protobuf::Descriptor* descriptor();
  static const TowerInfo& default_instance();

  void Swap(TowerInfo* other);

  // implements Message ----------------------------------------------

  TowerInfo* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const TowerInfo& from);
  void MergeFrom(const TowerInfo& from);
  void Clear();
  bool IsInitialized() const;

  int ByteSize() const;
  bool MergePartialFromCodedStream(
      ::google::protobuf::io::CodedInputStream* input);
  void SerializeWithCachedSizes(
      ::google::protobuf::io::CodedOutputStream* output) const;
  ::google::protobuf::uint8* SerializeWithCachedSizesToArray(::google::protobuf::uint8* output) const;
  int GetCachedSize() const { return _cached_size_; }
  private:
  void SharedCtor();
  void SharedDtor();
  void SetCachedSize(int size) const;
  public:
  ::google::protobuf::Metadata GetMetadata() const;

  // nested types ----------------------------------------------------

  // accessors -------------------------------------------------------

  // optional int64 playerID = 1;
  inline bool has_playerid() const;
  inline void clear_playerid();
  static const int kPlayerIDFieldNumber = 1;
  inline ::google::protobuf::int64 playerid() const;
  inline void set_playerid(::google::protobuf::int64 value);

  // optional int32 limitNum = 2;
  inline bool has_limitnum() const;
  inline void clear_limitnum();
  static const int kLimitNumFieldNumber = 2;
  inline ::google::protobuf::int32 limitnum() const;
  inline void set_limitnum(::google::protobuf::int32 value);

  // optional int32 clearNum = 3;
  inline bool has_clearnum() const;
  inline void clear_clearnum();
  static const int kClearNumFieldNumber = 3;
  inline ::google::protobuf::int32 clearnum() const;
  inline void set_clearnum(::google::protobuf::int32 value);

  // optional int32 pileNum = 4;
  inline bool has_pilenum() const;
  inline void clear_pilenum();
  static const int kPileNumFieldNumber = 4;
  inline ::google::protobuf::int32 pilenum() const;
  inline void set_pilenum(::google::protobuf::int32 value);

  // optional int32 status = 5;
  inline bool has_status() const;
  inline void clear_status();
  static const int kStatusFieldNumber = 5;
  inline ::google::protobuf::int32 status() const;
  inline void set_status(::google::protobuf::int32 value);

  // optional int64 beginTime = 6;
  inline bool has_begintime() const;
  inline void clear_begintime();
  static const int kBeginTimeFieldNumber = 6;
  inline ::google::protobuf::int64 begintime() const;
  inline void set_begintime(::google::protobuf::int64 value);

  // optional int32 topNum = 7;
  inline bool has_topnum() const;
  inline void clear_topnum();
  static const int kTopNumFieldNumber = 7;
  inline ::google::protobuf::int32 topnum() const;
  inline void set_topnum(::google::protobuf::int32 value);

  // optional int32 clearPileNum = 8;
  inline bool has_clearpilenum() const;
  inline void clear_clearpilenum();
  static const int kClearPileNumFieldNumber = 8;
  inline ::google::protobuf::int32 clearpilenum() const;
  inline void set_clearpilenum(::google::protobuf::int32 value);

  // optional int32 maxVipNum = 9;
  inline bool has_maxvipnum() const;
  inline void clear_maxvipnum();
  static const int kMaxVipNumFieldNumber = 9;
  inline ::google::protobuf::int32 maxvipnum() const;
  inline void set_maxvipnum(::google::protobuf::int32 value);

  // optional int32 alreadyBuy = 10;
  inline bool has_alreadybuy() const;
  inline void clear_alreadybuy();
  static const int kAlreadyBuyFieldNumber = 10;
  inline ::google::protobuf::int32 alreadybuy() const;
  inline void set_alreadybuy(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:TowerInfo)
 private:
  inline void set_has_playerid();
  inline void clear_has_playerid();
  inline void set_has_limitnum();
  inline void clear_has_limitnum();
  inline void set_has_clearnum();
  inline void clear_has_clearnum();
  inline void set_has_pilenum();
  inline void clear_has_pilenum();
  inline void set_has_status();
  inline void clear_has_status();
  inline void set_has_begintime();
  inline void clear_has_begintime();
  inline void set_has_topnum();
  inline void clear_has_topnum();
  inline void set_has_clearpilenum();
  inline void clear_has_clearpilenum();
  inline void set_has_maxvipnum();
  inline void clear_has_maxvipnum();
  inline void set_has_alreadybuy();
  inline void clear_has_alreadybuy();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int64 playerid_;
  ::google::protobuf::int32 limitnum_;
  ::google::protobuf::int32 clearnum_;
  ::google::protobuf::int32 pilenum_;
  ::google::protobuf::int32 status_;
  ::google::protobuf::int64 begintime_;
  ::google::protobuf::int32 topnum_;
  ::google::protobuf::int32 clearpilenum_;
  ::google::protobuf::int32 maxvipnum_;
  ::google::protobuf::int32 alreadybuy_;
  friend void  protobuf_AddDesc_TowerMessage_2eproto();
  friend void protobuf_AssignDesc_TowerMessage_2eproto();
  friend void protobuf_ShutdownFile_TowerMessage_2eproto();

  void InitAsDefaultInstance();
  static TowerInfo* default_instance_;
};
// -------------------------------------------------------------------

class CGTowerSend : public ::google::protobuf::Message {
 public:
  CGTowerSend();
  virtual ~CGTowerSend();

  CGTowerSend(const CGTowerSend& from);

  inline CGTowerSend& operator=(const CGTowerSend& from) {
    CopyFrom(from);
    return *this;
  }

  inline const ::google::protobuf::UnknownFieldSet& unknown_fields() const {
    return _unknown_fields_;
  }

  inline ::google::protobuf::UnknownFieldSet* mutable_unknown_fields() {
    return &_unknown_fields_;
  }

  static const ::google::protobuf::Descriptor* descriptor();
  static const CGTowerSend& default_instance();

  void Swap(CGTowerSend* other);

  // implements Message ----------------------------------------------

  CGTowerSend* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGTowerSend& from);
  void MergeFrom(const CGTowerSend& from);
  void Clear();
  bool IsInitialized() const;

  int ByteSize() const;
  bool MergePartialFromCodedStream(
      ::google::protobuf::io::CodedInputStream* input);
  void SerializeWithCachedSizes(
      ::google::protobuf::io::CodedOutputStream* output) const;
  ::google::protobuf::uint8* SerializeWithCachedSizesToArray(::google::protobuf::uint8* output) const;
  int GetCachedSize() const { return _cached_size_; }
  private:
  void SharedCtor();
  void SharedDtor();
  void SetCachedSize(int size) const;
  public:
  ::google::protobuf::Metadata GetMetadata() const;

  // nested types ----------------------------------------------------

  // accessors -------------------------------------------------------

  // optional int32 operate = 1;
  inline bool has_operate() const;
  inline void clear_operate();
  static const int kOperateFieldNumber = 1;
  inline ::google::protobuf::int32 operate() const;
  inline void set_operate(::google::protobuf::int32 value);

  // optional int32 buyNum = 2;
  inline bool has_buynum() const;
  inline void clear_buynum();
  static const int kBuyNumFieldNumber = 2;
  inline ::google::protobuf::int32 buynum() const;
  inline void set_buynum(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:CGTowerSend)
 private:
  inline void set_has_operate();
  inline void clear_has_operate();
  inline void set_has_buynum();
  inline void clear_has_buynum();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 operate_;
  ::google::protobuf::int32 buynum_;
  friend void  protobuf_AddDesc_TowerMessage_2eproto();
  friend void protobuf_AssignDesc_TowerMessage_2eproto();
  friend void protobuf_ShutdownFile_TowerMessage_2eproto();

  void InitAsDefaultInstance();
  static CGTowerSend* default_instance_;
};
// -------------------------------------------------------------------

class RewardItem : public ::google::protobuf::Message {
 public:
  RewardItem();
  virtual ~RewardItem();

  RewardItem(const RewardItem& from);

  inline RewardItem& operator=(const RewardItem& from) {
    CopyFrom(from);
    return *this;
  }

  inline const ::google::protobuf::UnknownFieldSet& unknown_fields() const {
    return _unknown_fields_;
  }

  inline ::google::protobuf::UnknownFieldSet* mutable_unknown_fields() {
    return &_unknown_fields_;
  }

  static const ::google::protobuf::Descriptor* descriptor();
  static const RewardItem& default_instance();

  void Swap(RewardItem* other);

  // implements Message ----------------------------------------------

  RewardItem* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const RewardItem& from);
  void MergeFrom(const RewardItem& from);
  void Clear();
  bool IsInitialized() const;

  int ByteSize() const;
  bool MergePartialFromCodedStream(
      ::google::protobuf::io::CodedInputStream* input);
  void SerializeWithCachedSizes(
      ::google::protobuf::io::CodedOutputStream* output) const;
  ::google::protobuf::uint8* SerializeWithCachedSizesToArray(::google::protobuf::uint8* output) const;
  int GetCachedSize() const { return _cached_size_; }
  private:
  void SharedCtor();
  void SharedDtor();
  void SetCachedSize(int size) const;
  public:
  ::google::protobuf::Metadata GetMetadata() const;

  // nested types ----------------------------------------------------

  // accessors -------------------------------------------------------

  // optional int32 bid = 1;
  inline bool has_bid() const;
  inline void clear_bid();
  static const int kBidFieldNumber = 1;
  inline ::google::protobuf::int32 bid() const;
  inline void set_bid(::google::protobuf::int32 value);

  // optional int32 sid = 2;
  inline bool has_sid() const;
  inline void clear_sid();
  static const int kSidFieldNumber = 2;
  inline ::google::protobuf::int32 sid() const;
  inline void set_sid(::google::protobuf::int32 value);

  // optional int32 num = 3;
  inline bool has_num() const;
  inline void clear_num();
  static const int kNumFieldNumber = 3;
  inline ::google::protobuf::int32 num() const;
  inline void set_num(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:RewardItem)
 private:
  inline void set_has_bid();
  inline void clear_has_bid();
  inline void set_has_sid();
  inline void clear_has_sid();
  inline void set_has_num();
  inline void clear_has_num();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 bid_;
  ::google::protobuf::int32 sid_;
  ::google::protobuf::int32 num_;
  friend void  protobuf_AddDesc_TowerMessage_2eproto();
  friend void protobuf_AssignDesc_TowerMessage_2eproto();
  friend void protobuf_ShutdownFile_TowerMessage_2eproto();

  void InitAsDefaultInstance();
  static RewardItem* default_instance_;
};
// -------------------------------------------------------------------

class GCTowerPush : public ::google::protobuf::Message {
 public:
  GCTowerPush();
  virtual ~GCTowerPush();

  GCTowerPush(const GCTowerPush& from);

  inline GCTowerPush& operator=(const GCTowerPush& from) {
    CopyFrom(from);
    return *this;
  }

  inline const ::google::protobuf::UnknownFieldSet& unknown_fields() const {
    return _unknown_fields_;
  }

  inline ::google::protobuf::UnknownFieldSet* mutable_unknown_fields() {
    return &_unknown_fields_;
  }

  static const ::google::protobuf::Descriptor* descriptor();
  static const GCTowerPush& default_instance();

  void Swap(GCTowerPush* other);

  // implements Message ----------------------------------------------

  GCTowerPush* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCTowerPush& from);
  void MergeFrom(const GCTowerPush& from);
  void Clear();
  bool IsInitialized() const;

  int ByteSize() const;
  bool MergePartialFromCodedStream(
      ::google::protobuf::io::CodedInputStream* input);
  void SerializeWithCachedSizes(
      ::google::protobuf::io::CodedOutputStream* output) const;
  ::google::protobuf::uint8* SerializeWithCachedSizesToArray(::google::protobuf::uint8* output) const;
  int GetCachedSize() const { return _cached_size_; }
  private:
  void SharedCtor();
  void SharedDtor();
  void SetCachedSize(int size) const;
  public:
  ::google::protobuf::Metadata GetMetadata() const;

  // nested types ----------------------------------------------------

  // accessors -------------------------------------------------------

  // optional int32 operate = 1;
  inline bool has_operate() const;
  inline void clear_operate();
  static const int kOperateFieldNumber = 1;
  inline ::google::protobuf::int32 operate() const;
  inline void set_operate(::google::protobuf::int32 value);

  // optional int64 timeStamp = 2;
  inline bool has_timestamp() const;
  inline void clear_timestamp();
  static const int kTimeStampFieldNumber = 2;
  inline ::google::protobuf::int64 timestamp() const;
  inline void set_timestamp(::google::protobuf::int64 value);

  // optional .TowerInfo towerInfo = 3;
  inline bool has_towerinfo() const;
  inline void clear_towerinfo();
  static const int kTowerInfoFieldNumber = 3;
  inline const ::TowerInfo& towerinfo() const;
  inline ::TowerInfo* mutable_towerinfo();
  inline ::TowerInfo* release_towerinfo();
  inline void set_allocated_towerinfo(::TowerInfo* towerinfo);

  // repeated .RewardItem rewardItems = 4;
  inline int rewarditems_size() const;
  inline void clear_rewarditems();
  static const int kRewardItemsFieldNumber = 4;
  inline const ::RewardItem& rewarditems(int index) const;
  inline ::RewardItem* mutable_rewarditems(int index);
  inline ::RewardItem* add_rewarditems();
  inline const ::google::protobuf::RepeatedPtrField< ::RewardItem >&
      rewarditems() const;
  inline ::google::protobuf::RepeatedPtrField< ::RewardItem >*
      mutable_rewarditems();

  // repeated .RewardItem firstRewards = 5;
  inline int firstrewards_size() const;
  inline void clear_firstrewards();
  static const int kFirstRewardsFieldNumber = 5;
  inline const ::RewardItem& firstrewards(int index) const;
  inline ::RewardItem* mutable_firstrewards(int index);
  inline ::RewardItem* add_firstrewards();
  inline const ::google::protobuf::RepeatedPtrField< ::RewardItem >&
      firstrewards() const;
  inline ::google::protobuf::RepeatedPtrField< ::RewardItem >*
      mutable_firstrewards();

  // optional int32 towerID = 6;
  inline bool has_towerid() const;
  inline void clear_towerid();
  static const int kTowerIDFieldNumber = 6;
  inline ::google::protobuf::int32 towerid() const;
  inline void set_towerid(::google::protobuf::int32 value);

  // optional int64 beginTime = 7;
  inline bool has_begintime() const;
  inline void clear_begintime();
  static const int kBeginTimeFieldNumber = 7;
  inline ::google::protobuf::int64 begintime() const;
  inline void set_begintime(::google::protobuf::int64 value);

  // @@protoc_insertion_point(class_scope:GCTowerPush)
 private:
  inline void set_has_operate();
  inline void clear_has_operate();
  inline void set_has_timestamp();
  inline void clear_has_timestamp();
  inline void set_has_towerinfo();
  inline void clear_has_towerinfo();
  inline void set_has_towerid();
  inline void clear_has_towerid();
  inline void set_has_begintime();
  inline void clear_has_begintime();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int64 timestamp_;
  ::TowerInfo* towerinfo_;
  ::google::protobuf::int32 operate_;
  ::google::protobuf::int32 towerid_;
  ::google::protobuf::RepeatedPtrField< ::RewardItem > rewarditems_;
  ::google::protobuf::RepeatedPtrField< ::RewardItem > firstrewards_;
  ::google::protobuf::int64 begintime_;
  friend void  protobuf_AddDesc_TowerMessage_2eproto();
  friend void protobuf_AssignDesc_TowerMessage_2eproto();
  friend void protobuf_ShutdownFile_TowerMessage_2eproto();

  void InitAsDefaultInstance();
  static GCTowerPush* default_instance_;
};
// ===================================================================


// ===================================================================

// TowerInfo

// optional int64 playerID = 1;
inline bool TowerInfo::has_playerid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void TowerInfo::set_has_playerid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void TowerInfo::clear_has_playerid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void TowerInfo::clear_playerid() {
  playerid_ = GOOGLE_LONGLONG(0);
  clear_has_playerid();
}
inline ::google::protobuf::int64 TowerInfo::playerid() const {
  // @@protoc_insertion_point(field_get:TowerInfo.playerID)
  return playerid_;
}
inline void TowerInfo::set_playerid(::google::protobuf::int64 value) {
  set_has_playerid();
  playerid_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.playerID)
}

// optional int32 limitNum = 2;
inline bool TowerInfo::has_limitnum() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void TowerInfo::set_has_limitnum() {
  _has_bits_[0] |= 0x00000002u;
}
inline void TowerInfo::clear_has_limitnum() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void TowerInfo::clear_limitnum() {
  limitnum_ = 0;
  clear_has_limitnum();
}
inline ::google::protobuf::int32 TowerInfo::limitnum() const {
  // @@protoc_insertion_point(field_get:TowerInfo.limitNum)
  return limitnum_;
}
inline void TowerInfo::set_limitnum(::google::protobuf::int32 value) {
  set_has_limitnum();
  limitnum_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.limitNum)
}

// optional int32 clearNum = 3;
inline bool TowerInfo::has_clearnum() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void TowerInfo::set_has_clearnum() {
  _has_bits_[0] |= 0x00000004u;
}
inline void TowerInfo::clear_has_clearnum() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void TowerInfo::clear_clearnum() {
  clearnum_ = 0;
  clear_has_clearnum();
}
inline ::google::protobuf::int32 TowerInfo::clearnum() const {
  // @@protoc_insertion_point(field_get:TowerInfo.clearNum)
  return clearnum_;
}
inline void TowerInfo::set_clearnum(::google::protobuf::int32 value) {
  set_has_clearnum();
  clearnum_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.clearNum)
}

// optional int32 pileNum = 4;
inline bool TowerInfo::has_pilenum() const {
  return (_has_bits_[0] & 0x00000008u) != 0;
}
inline void TowerInfo::set_has_pilenum() {
  _has_bits_[0] |= 0x00000008u;
}
inline void TowerInfo::clear_has_pilenum() {
  _has_bits_[0] &= ~0x00000008u;
}
inline void TowerInfo::clear_pilenum() {
  pilenum_ = 0;
  clear_has_pilenum();
}
inline ::google::protobuf::int32 TowerInfo::pilenum() const {
  // @@protoc_insertion_point(field_get:TowerInfo.pileNum)
  return pilenum_;
}
inline void TowerInfo::set_pilenum(::google::protobuf::int32 value) {
  set_has_pilenum();
  pilenum_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.pileNum)
}

// optional int32 status = 5;
inline bool TowerInfo::has_status() const {
  return (_has_bits_[0] & 0x00000010u) != 0;
}
inline void TowerInfo::set_has_status() {
  _has_bits_[0] |= 0x00000010u;
}
inline void TowerInfo::clear_has_status() {
  _has_bits_[0] &= ~0x00000010u;
}
inline void TowerInfo::clear_status() {
  status_ = 0;
  clear_has_status();
}
inline ::google::protobuf::int32 TowerInfo::status() const {
  // @@protoc_insertion_point(field_get:TowerInfo.status)
  return status_;
}
inline void TowerInfo::set_status(::google::protobuf::int32 value) {
  set_has_status();
  status_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.status)
}

// optional int64 beginTime = 6;
inline bool TowerInfo::has_begintime() const {
  return (_has_bits_[0] & 0x00000020u) != 0;
}
inline void TowerInfo::set_has_begintime() {
  _has_bits_[0] |= 0x00000020u;
}
inline void TowerInfo::clear_has_begintime() {
  _has_bits_[0] &= ~0x00000020u;
}
inline void TowerInfo::clear_begintime() {
  begintime_ = GOOGLE_LONGLONG(0);
  clear_has_begintime();
}
inline ::google::protobuf::int64 TowerInfo::begintime() const {
  // @@protoc_insertion_point(field_get:TowerInfo.beginTime)
  return begintime_;
}
inline void TowerInfo::set_begintime(::google::protobuf::int64 value) {
  set_has_begintime();
  begintime_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.beginTime)
}

// optional int32 topNum = 7;
inline bool TowerInfo::has_topnum() const {
  return (_has_bits_[0] & 0x00000040u) != 0;
}
inline void TowerInfo::set_has_topnum() {
  _has_bits_[0] |= 0x00000040u;
}
inline void TowerInfo::clear_has_topnum() {
  _has_bits_[0] &= ~0x00000040u;
}
inline void TowerInfo::clear_topnum() {
  topnum_ = 0;
  clear_has_topnum();
}
inline ::google::protobuf::int32 TowerInfo::topnum() const {
  // @@protoc_insertion_point(field_get:TowerInfo.topNum)
  return topnum_;
}
inline void TowerInfo::set_topnum(::google::protobuf::int32 value) {
  set_has_topnum();
  topnum_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.topNum)
}

// optional int32 clearPileNum = 8;
inline bool TowerInfo::has_clearpilenum() const {
  return (_has_bits_[0] & 0x00000080u) != 0;
}
inline void TowerInfo::set_has_clearpilenum() {
  _has_bits_[0] |= 0x00000080u;
}
inline void TowerInfo::clear_has_clearpilenum() {
  _has_bits_[0] &= ~0x00000080u;
}
inline void TowerInfo::clear_clearpilenum() {
  clearpilenum_ = 0;
  clear_has_clearpilenum();
}
inline ::google::protobuf::int32 TowerInfo::clearpilenum() const {
  // @@protoc_insertion_point(field_get:TowerInfo.clearPileNum)
  return clearpilenum_;
}
inline void TowerInfo::set_clearpilenum(::google::protobuf::int32 value) {
  set_has_clearpilenum();
  clearpilenum_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.clearPileNum)
}

// optional int32 maxVipNum = 9;
inline bool TowerInfo::has_maxvipnum() const {
  return (_has_bits_[0] & 0x00000100u) != 0;
}
inline void TowerInfo::set_has_maxvipnum() {
  _has_bits_[0] |= 0x00000100u;
}
inline void TowerInfo::clear_has_maxvipnum() {
  _has_bits_[0] &= ~0x00000100u;
}
inline void TowerInfo::clear_maxvipnum() {
  maxvipnum_ = 0;
  clear_has_maxvipnum();
}
inline ::google::protobuf::int32 TowerInfo::maxvipnum() const {
  // @@protoc_insertion_point(field_get:TowerInfo.maxVipNum)
  return maxvipnum_;
}
inline void TowerInfo::set_maxvipnum(::google::protobuf::int32 value) {
  set_has_maxvipnum();
  maxvipnum_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.maxVipNum)
}

// optional int32 alreadyBuy = 10;
inline bool TowerInfo::has_alreadybuy() const {
  return (_has_bits_[0] & 0x00000200u) != 0;
}
inline void TowerInfo::set_has_alreadybuy() {
  _has_bits_[0] |= 0x00000200u;
}
inline void TowerInfo::clear_has_alreadybuy() {
  _has_bits_[0] &= ~0x00000200u;
}
inline void TowerInfo::clear_alreadybuy() {
  alreadybuy_ = 0;
  clear_has_alreadybuy();
}
inline ::google::protobuf::int32 TowerInfo::alreadybuy() const {
  // @@protoc_insertion_point(field_get:TowerInfo.alreadyBuy)
  return alreadybuy_;
}
inline void TowerInfo::set_alreadybuy(::google::protobuf::int32 value) {
  set_has_alreadybuy();
  alreadybuy_ = value;
  // @@protoc_insertion_point(field_set:TowerInfo.alreadyBuy)
}

// -------------------------------------------------------------------

// CGTowerSend

// optional int32 operate = 1;
inline bool CGTowerSend::has_operate() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGTowerSend::set_has_operate() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGTowerSend::clear_has_operate() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGTowerSend::clear_operate() {
  operate_ = 0;
  clear_has_operate();
}
inline ::google::protobuf::int32 CGTowerSend::operate() const {
  // @@protoc_insertion_point(field_get:CGTowerSend.operate)
  return operate_;
}
inline void CGTowerSend::set_operate(::google::protobuf::int32 value) {
  set_has_operate();
  operate_ = value;
  // @@protoc_insertion_point(field_set:CGTowerSend.operate)
}

// optional int32 buyNum = 2;
inline bool CGTowerSend::has_buynum() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void CGTowerSend::set_has_buynum() {
  _has_bits_[0] |= 0x00000002u;
}
inline void CGTowerSend::clear_has_buynum() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void CGTowerSend::clear_buynum() {
  buynum_ = 0;
  clear_has_buynum();
}
inline ::google::protobuf::int32 CGTowerSend::buynum() const {
  // @@protoc_insertion_point(field_get:CGTowerSend.buyNum)
  return buynum_;
}
inline void CGTowerSend::set_buynum(::google::protobuf::int32 value) {
  set_has_buynum();
  buynum_ = value;
  // @@protoc_insertion_point(field_set:CGTowerSend.buyNum)
}

// -------------------------------------------------------------------

// RewardItem

// optional int32 bid = 1;
inline bool RewardItem::has_bid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void RewardItem::set_has_bid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void RewardItem::clear_has_bid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void RewardItem::clear_bid() {
  bid_ = 0;
  clear_has_bid();
}
inline ::google::protobuf::int32 RewardItem::bid() const {
  // @@protoc_insertion_point(field_get:RewardItem.bid)
  return bid_;
}
inline void RewardItem::set_bid(::google::protobuf::int32 value) {
  set_has_bid();
  bid_ = value;
  // @@protoc_insertion_point(field_set:RewardItem.bid)
}

// optional int32 sid = 2;
inline bool RewardItem::has_sid() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void RewardItem::set_has_sid() {
  _has_bits_[0] |= 0x00000002u;
}
inline void RewardItem::clear_has_sid() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void RewardItem::clear_sid() {
  sid_ = 0;
  clear_has_sid();
}
inline ::google::protobuf::int32 RewardItem::sid() const {
  // @@protoc_insertion_point(field_get:RewardItem.sid)
  return sid_;
}
inline void RewardItem::set_sid(::google::protobuf::int32 value) {
  set_has_sid();
  sid_ = value;
  // @@protoc_insertion_point(field_set:RewardItem.sid)
}

// optional int32 num = 3;
inline bool RewardItem::has_num() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void RewardItem::set_has_num() {
  _has_bits_[0] |= 0x00000004u;
}
inline void RewardItem::clear_has_num() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void RewardItem::clear_num() {
  num_ = 0;
  clear_has_num();
}
inline ::google::protobuf::int32 RewardItem::num() const {
  // @@protoc_insertion_point(field_get:RewardItem.num)
  return num_;
}
inline void RewardItem::set_num(::google::protobuf::int32 value) {
  set_has_num();
  num_ = value;
  // @@protoc_insertion_point(field_set:RewardItem.num)
}

// -------------------------------------------------------------------

// GCTowerPush

// optional int32 operate = 1;
inline bool GCTowerPush::has_operate() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCTowerPush::set_has_operate() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCTowerPush::clear_has_operate() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCTowerPush::clear_operate() {
  operate_ = 0;
  clear_has_operate();
}
inline ::google::protobuf::int32 GCTowerPush::operate() const {
  // @@protoc_insertion_point(field_get:GCTowerPush.operate)
  return operate_;
}
inline void GCTowerPush::set_operate(::google::protobuf::int32 value) {
  set_has_operate();
  operate_ = value;
  // @@protoc_insertion_point(field_set:GCTowerPush.operate)
}

// optional int64 timeStamp = 2;
inline bool GCTowerPush::has_timestamp() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void GCTowerPush::set_has_timestamp() {
  _has_bits_[0] |= 0x00000002u;
}
inline void GCTowerPush::clear_has_timestamp() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void GCTowerPush::clear_timestamp() {
  timestamp_ = GOOGLE_LONGLONG(0);
  clear_has_timestamp();
}
inline ::google::protobuf::int64 GCTowerPush::timestamp() const {
  // @@protoc_insertion_point(field_get:GCTowerPush.timeStamp)
  return timestamp_;
}
inline void GCTowerPush::set_timestamp(::google::protobuf::int64 value) {
  set_has_timestamp();
  timestamp_ = value;
  // @@protoc_insertion_point(field_set:GCTowerPush.timeStamp)
}

// optional .TowerInfo towerInfo = 3;
inline bool GCTowerPush::has_towerinfo() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void GCTowerPush::set_has_towerinfo() {
  _has_bits_[0] |= 0x00000004u;
}
inline void GCTowerPush::clear_has_towerinfo() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void GCTowerPush::clear_towerinfo() {
  if (towerinfo_ != NULL) towerinfo_->::TowerInfo::Clear();
  clear_has_towerinfo();
}
inline const ::TowerInfo& GCTowerPush::towerinfo() const {
  // @@protoc_insertion_point(field_get:GCTowerPush.towerInfo)
  return towerinfo_ != NULL ? *towerinfo_ : *default_instance_->towerinfo_;
}
inline ::TowerInfo* GCTowerPush::mutable_towerinfo() {
  set_has_towerinfo();
  if (towerinfo_ == NULL) towerinfo_ = new ::TowerInfo;
  // @@protoc_insertion_point(field_mutable:GCTowerPush.towerInfo)
  return towerinfo_;
}
inline ::TowerInfo* GCTowerPush::release_towerinfo() {
  clear_has_towerinfo();
  ::TowerInfo* temp = towerinfo_;
  towerinfo_ = NULL;
  return temp;
}
inline void GCTowerPush::set_allocated_towerinfo(::TowerInfo* towerinfo) {
  delete towerinfo_;
  towerinfo_ = towerinfo;
  if (towerinfo) {
    set_has_towerinfo();
  } else {
    clear_has_towerinfo();
  }
  // @@protoc_insertion_point(field_set_allocated:GCTowerPush.towerInfo)
}

// repeated .RewardItem rewardItems = 4;
inline int GCTowerPush::rewarditems_size() const {
  return rewarditems_.size();
}
inline void GCTowerPush::clear_rewarditems() {
  rewarditems_.Clear();
}
inline const ::RewardItem& GCTowerPush::rewarditems(int index) const {
  // @@protoc_insertion_point(field_get:GCTowerPush.rewardItems)
  return rewarditems_.Get(index);
}
inline ::RewardItem* GCTowerPush::mutable_rewarditems(int index) {
  // @@protoc_insertion_point(field_mutable:GCTowerPush.rewardItems)
  return rewarditems_.Mutable(index);
}
inline ::RewardItem* GCTowerPush::add_rewarditems() {
  // @@protoc_insertion_point(field_add:GCTowerPush.rewardItems)
  return rewarditems_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::RewardItem >&
GCTowerPush::rewarditems() const {
  // @@protoc_insertion_point(field_list:GCTowerPush.rewardItems)
  return rewarditems_;
}
inline ::google::protobuf::RepeatedPtrField< ::RewardItem >*
GCTowerPush::mutable_rewarditems() {
  // @@protoc_insertion_point(field_mutable_list:GCTowerPush.rewardItems)
  return &rewarditems_;
}

// repeated .RewardItem firstRewards = 5;
inline int GCTowerPush::firstrewards_size() const {
  return firstrewards_.size();
}
inline void GCTowerPush::clear_firstrewards() {
  firstrewards_.Clear();
}
inline const ::RewardItem& GCTowerPush::firstrewards(int index) const {
  // @@protoc_insertion_point(field_get:GCTowerPush.firstRewards)
  return firstrewards_.Get(index);
}
inline ::RewardItem* GCTowerPush::mutable_firstrewards(int index) {
  // @@protoc_insertion_point(field_mutable:GCTowerPush.firstRewards)
  return firstrewards_.Mutable(index);
}
inline ::RewardItem* GCTowerPush::add_firstrewards() {
  // @@protoc_insertion_point(field_add:GCTowerPush.firstRewards)
  return firstrewards_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::RewardItem >&
GCTowerPush::firstrewards() const {
  // @@protoc_insertion_point(field_list:GCTowerPush.firstRewards)
  return firstrewards_;
}
inline ::google::protobuf::RepeatedPtrField< ::RewardItem >*
GCTowerPush::mutable_firstrewards() {
  // @@protoc_insertion_point(field_mutable_list:GCTowerPush.firstRewards)
  return &firstrewards_;
}

// optional int32 towerID = 6;
inline bool GCTowerPush::has_towerid() const {
  return (_has_bits_[0] & 0x00000020u) != 0;
}
inline void GCTowerPush::set_has_towerid() {
  _has_bits_[0] |= 0x00000020u;
}
inline void GCTowerPush::clear_has_towerid() {
  _has_bits_[0] &= ~0x00000020u;
}
inline void GCTowerPush::clear_towerid() {
  towerid_ = 0;
  clear_has_towerid();
}
inline ::google::protobuf::int32 GCTowerPush::towerid() const {
  // @@protoc_insertion_point(field_get:GCTowerPush.towerID)
  return towerid_;
}
inline void GCTowerPush::set_towerid(::google::protobuf::int32 value) {
  set_has_towerid();
  towerid_ = value;
  // @@protoc_insertion_point(field_set:GCTowerPush.towerID)
}

// optional int64 beginTime = 7;
inline bool GCTowerPush::has_begintime() const {
  return (_has_bits_[0] & 0x00000040u) != 0;
}
inline void GCTowerPush::set_has_begintime() {
  _has_bits_[0] |= 0x00000040u;
}
inline void GCTowerPush::clear_has_begintime() {
  _has_bits_[0] &= ~0x00000040u;
}
inline void GCTowerPush::clear_begintime() {
  begintime_ = GOOGLE_LONGLONG(0);
  clear_has_begintime();
}
inline ::google::protobuf::int64 GCTowerPush::begintime() const {
  // @@protoc_insertion_point(field_get:GCTowerPush.beginTime)
  return begintime_;
}
inline void GCTowerPush::set_begintime(::google::protobuf::int64 value) {
  set_has_begintime();
  begintime_ = value;
  // @@protoc_insertion_point(field_set:GCTowerPush.beginTime)
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_TowerMessage_2eproto__INCLUDED