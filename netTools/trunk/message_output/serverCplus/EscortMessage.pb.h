// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: EscortMessage.proto

#ifndef PROTOBUF_EscortMessage_2eproto__INCLUDED
#define PROTOBUF_EscortMessage_2eproto__INCLUDED

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
void  protobuf_AddDesc_EscortMessage_2eproto();
void protobuf_AssignDesc_EscortMessage_2eproto();
void protobuf_ShutdownFile_EscortMessage_2eproto();

class CGEscortOperate;
class GCEscortOperateResult;
class CGFollowDart;
class GCFollowDartResult;

// ===================================================================

class CGEscortOperate : public ::google::protobuf::Message {
 public:
  CGEscortOperate();
  virtual ~CGEscortOperate();

  CGEscortOperate(const CGEscortOperate& from);

  inline CGEscortOperate& operator=(const CGEscortOperate& from) {
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
  static const CGEscortOperate& default_instance();

  void Swap(CGEscortOperate* other);

  // implements Message ----------------------------------------------

  CGEscortOperate* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGEscortOperate& from);
  void MergeFrom(const CGEscortOperate& from);
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

  // optional int32 dartType = 2;
  inline bool has_darttype() const;
  inline void clear_darttype();
  static const int kDartTypeFieldNumber = 2;
  inline ::google::protobuf::int32 darttype() const;
  inline void set_darttype(::google::protobuf::int32 value);

  // optional int32 dartID = 3;
  inline bool has_dartid() const;
  inline void clear_dartid();
  static const int kDartIDFieldNumber = 3;
  inline ::google::protobuf::int32 dartid() const;
  inline void set_dartid(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:CGEscortOperate)
 private:
  inline void set_has_operate();
  inline void clear_has_operate();
  inline void set_has_darttype();
  inline void clear_has_darttype();
  inline void set_has_dartid();
  inline void clear_has_dartid();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 operate_;
  ::google::protobuf::int32 darttype_;
  ::google::protobuf::int32 dartid_;
  friend void  protobuf_AddDesc_EscortMessage_2eproto();
  friend void protobuf_AssignDesc_EscortMessage_2eproto();
  friend void protobuf_ShutdownFile_EscortMessage_2eproto();

  void InitAsDefaultInstance();
  static CGEscortOperate* default_instance_;
};
// -------------------------------------------------------------------

class GCEscortOperateResult : public ::google::protobuf::Message {
 public:
  GCEscortOperateResult();
  virtual ~GCEscortOperateResult();

  GCEscortOperateResult(const GCEscortOperateResult& from);

  inline GCEscortOperateResult& operator=(const GCEscortOperateResult& from) {
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
  static const GCEscortOperateResult& default_instance();

  void Swap(GCEscortOperateResult* other);

  // implements Message ----------------------------------------------

  GCEscortOperateResult* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCEscortOperateResult& from);
  void MergeFrom(const GCEscortOperateResult& from);
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

  // optional int32 escortCnt = 2;
  inline bool has_escortcnt() const;
  inline void clear_escortcnt();
  static const int kEscortCntFieldNumber = 2;
  inline ::google::protobuf::int32 escortcnt() const;
  inline void set_escortcnt(::google::protobuf::int32 value);

  // optional int32 robCnt = 3;
  inline bool has_robcnt() const;
  inline void clear_robcnt();
  static const int kRobCntFieldNumber = 3;
  inline ::google::protobuf::int32 robcnt() const;
  inline void set_robcnt(::google::protobuf::int32 value);

  // optional int32 dartID = 4;
  inline bool has_dartid() const;
  inline void clear_dartid();
  static const int kDartIDFieldNumber = 4;
  inline ::google::protobuf::int32 dartid() const;
  inline void set_dartid(::google::protobuf::int32 value);

  // optional string reward = 5;
  inline bool has_reward() const;
  inline void clear_reward();
  static const int kRewardFieldNumber = 5;
  inline const ::std::string& reward() const;
  inline void set_reward(const ::std::string& value);
  inline void set_reward(const char* value);
  inline void set_reward(const char* value, size_t size);
  inline ::std::string* mutable_reward();
  inline ::std::string* release_reward();
  inline void set_allocated_reward(::std::string* reward);

  // optional string playerName = 6;
  inline bool has_playername() const;
  inline void clear_playername();
  static const int kPlayerNameFieldNumber = 6;
  inline const ::std::string& playername() const;
  inline void set_playername(const ::std::string& value);
  inline void set_playername(const char* value);
  inline void set_playername(const char* value, size_t size);
  inline ::std::string* mutable_playername();
  inline ::std::string* release_playername();
  inline void set_allocated_playername(::std::string* playername);

  // optional int64 dartPid = 7;
  inline bool has_dartpid() const;
  inline void clear_dartpid();
  static const int kDartPidFieldNumber = 7;
  inline ::google::protobuf::int64 dartpid() const;
  inline void set_dartpid(::google::protobuf::int64 value);

  // optional int64 endTime = 8;
  inline bool has_endtime() const;
  inline void clear_endtime();
  static const int kEndTimeFieldNumber = 8;
  inline ::google::protobuf::int64 endtime() const;
  inline void set_endtime(::google::protobuf::int64 value);

  // optional int64 failTime = 9;
  inline bool has_failtime() const;
  inline void clear_failtime();
  static const int kFailTimeFieldNumber = 9;
  inline ::google::protobuf::int64 failtime() const;
  inline void set_failtime(::google::protobuf::int64 value);

  // @@protoc_insertion_point(class_scope:GCEscortOperateResult)
 private:
  inline void set_has_operate();
  inline void clear_has_operate();
  inline void set_has_escortcnt();
  inline void clear_has_escortcnt();
  inline void set_has_robcnt();
  inline void clear_has_robcnt();
  inline void set_has_dartid();
  inline void clear_has_dartid();
  inline void set_has_reward();
  inline void clear_has_reward();
  inline void set_has_playername();
  inline void clear_has_playername();
  inline void set_has_dartpid();
  inline void clear_has_dartpid();
  inline void set_has_endtime();
  inline void clear_has_endtime();
  inline void set_has_failtime();
  inline void clear_has_failtime();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 operate_;
  ::google::protobuf::int32 escortcnt_;
  ::google::protobuf::int32 robcnt_;
  ::google::protobuf::int32 dartid_;
  ::std::string* reward_;
  ::std::string* playername_;
  ::google::protobuf::int64 dartpid_;
  ::google::protobuf::int64 endtime_;
  ::google::protobuf::int64 failtime_;
  friend void  protobuf_AddDesc_EscortMessage_2eproto();
  friend void protobuf_AssignDesc_EscortMessage_2eproto();
  friend void protobuf_ShutdownFile_EscortMessage_2eproto();

  void InitAsDefaultInstance();
  static GCEscortOperateResult* default_instance_;
};
// -------------------------------------------------------------------

class CGFollowDart : public ::google::protobuf::Message {
 public:
  CGFollowDart();
  virtual ~CGFollowDart();

  CGFollowDart(const CGFollowDart& from);

  inline CGFollowDart& operator=(const CGFollowDart& from) {
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
  static const CGFollowDart& default_instance();

  void Swap(CGFollowDart* other);

  // implements Message ----------------------------------------------

  CGFollowDart* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGFollowDart& from);
  void MergeFrom(const CGFollowDart& from);
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

  // @@protoc_insertion_point(class_scope:CGFollowDart)
 private:

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  friend void  protobuf_AddDesc_EscortMessage_2eproto();
  friend void protobuf_AssignDesc_EscortMessage_2eproto();
  friend void protobuf_ShutdownFile_EscortMessage_2eproto();

  void InitAsDefaultInstance();
  static CGFollowDart* default_instance_;
};
// -------------------------------------------------------------------

class GCFollowDartResult : public ::google::protobuf::Message {
 public:
  GCFollowDartResult();
  virtual ~GCFollowDartResult();

  GCFollowDartResult(const GCFollowDartResult& from);

  inline GCFollowDartResult& operator=(const GCFollowDartResult& from) {
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
  static const GCFollowDartResult& default_instance();

  void Swap(GCFollowDartResult* other);

  // implements Message ----------------------------------------------

  GCFollowDartResult* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCFollowDartResult& from);
  void MergeFrom(const GCFollowDartResult& from);
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

  // optional int32 sceneID = 1;
  inline bool has_sceneid() const;
  inline void clear_sceneid();
  static const int kSceneIDFieldNumber = 1;
  inline ::google::protobuf::int32 sceneid() const;
  inline void set_sceneid(::google::protobuf::int32 value);

  // optional int32 posX = 2;
  inline bool has_posx() const;
  inline void clear_posx();
  static const int kPosXFieldNumber = 2;
  inline ::google::protobuf::int32 posx() const;
  inline void set_posx(::google::protobuf::int32 value);

  // optional int32 posZ = 3;
  inline bool has_posz() const;
  inline void clear_posz();
  static const int kPosZFieldNumber = 3;
  inline ::google::protobuf::int32 posz() const;
  inline void set_posz(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:GCFollowDartResult)
 private:
  inline void set_has_sceneid();
  inline void clear_has_sceneid();
  inline void set_has_posx();
  inline void clear_has_posx();
  inline void set_has_posz();
  inline void clear_has_posz();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 sceneid_;
  ::google::protobuf::int32 posx_;
  ::google::protobuf::int32 posz_;
  friend void  protobuf_AddDesc_EscortMessage_2eproto();
  friend void protobuf_AssignDesc_EscortMessage_2eproto();
  friend void protobuf_ShutdownFile_EscortMessage_2eproto();

  void InitAsDefaultInstance();
  static GCFollowDartResult* default_instance_;
};
// ===================================================================


// ===================================================================

// CGEscortOperate

// optional int32 operate = 1;
inline bool CGEscortOperate::has_operate() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGEscortOperate::set_has_operate() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGEscortOperate::clear_has_operate() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGEscortOperate::clear_operate() {
  operate_ = 0;
  clear_has_operate();
}
inline ::google::protobuf::int32 CGEscortOperate::operate() const {
  // @@protoc_insertion_point(field_get:CGEscortOperate.operate)
  return operate_;
}
inline void CGEscortOperate::set_operate(::google::protobuf::int32 value) {
  set_has_operate();
  operate_ = value;
  // @@protoc_insertion_point(field_set:CGEscortOperate.operate)
}

// optional int32 dartType = 2;
inline bool CGEscortOperate::has_darttype() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void CGEscortOperate::set_has_darttype() {
  _has_bits_[0] |= 0x00000002u;
}
inline void CGEscortOperate::clear_has_darttype() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void CGEscortOperate::clear_darttype() {
  darttype_ = 0;
  clear_has_darttype();
}
inline ::google::protobuf::int32 CGEscortOperate::darttype() const {
  // @@protoc_insertion_point(field_get:CGEscortOperate.dartType)
  return darttype_;
}
inline void CGEscortOperate::set_darttype(::google::protobuf::int32 value) {
  set_has_darttype();
  darttype_ = value;
  // @@protoc_insertion_point(field_set:CGEscortOperate.dartType)
}

// optional int32 dartID = 3;
inline bool CGEscortOperate::has_dartid() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void CGEscortOperate::set_has_dartid() {
  _has_bits_[0] |= 0x00000004u;
}
inline void CGEscortOperate::clear_has_dartid() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void CGEscortOperate::clear_dartid() {
  dartid_ = 0;
  clear_has_dartid();
}
inline ::google::protobuf::int32 CGEscortOperate::dartid() const {
  // @@protoc_insertion_point(field_get:CGEscortOperate.dartID)
  return dartid_;
}
inline void CGEscortOperate::set_dartid(::google::protobuf::int32 value) {
  set_has_dartid();
  dartid_ = value;
  // @@protoc_insertion_point(field_set:CGEscortOperate.dartID)
}

// -------------------------------------------------------------------

// GCEscortOperateResult

// optional int32 operate = 1;
inline bool GCEscortOperateResult::has_operate() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCEscortOperateResult::set_has_operate() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCEscortOperateResult::clear_has_operate() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCEscortOperateResult::clear_operate() {
  operate_ = 0;
  clear_has_operate();
}
inline ::google::protobuf::int32 GCEscortOperateResult::operate() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.operate)
  return operate_;
}
inline void GCEscortOperateResult::set_operate(::google::protobuf::int32 value) {
  set_has_operate();
  operate_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.operate)
}

// optional int32 escortCnt = 2;
inline bool GCEscortOperateResult::has_escortcnt() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void GCEscortOperateResult::set_has_escortcnt() {
  _has_bits_[0] |= 0x00000002u;
}
inline void GCEscortOperateResult::clear_has_escortcnt() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void GCEscortOperateResult::clear_escortcnt() {
  escortcnt_ = 0;
  clear_has_escortcnt();
}
inline ::google::protobuf::int32 GCEscortOperateResult::escortcnt() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.escortCnt)
  return escortcnt_;
}
inline void GCEscortOperateResult::set_escortcnt(::google::protobuf::int32 value) {
  set_has_escortcnt();
  escortcnt_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.escortCnt)
}

// optional int32 robCnt = 3;
inline bool GCEscortOperateResult::has_robcnt() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void GCEscortOperateResult::set_has_robcnt() {
  _has_bits_[0] |= 0x00000004u;
}
inline void GCEscortOperateResult::clear_has_robcnt() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void GCEscortOperateResult::clear_robcnt() {
  robcnt_ = 0;
  clear_has_robcnt();
}
inline ::google::protobuf::int32 GCEscortOperateResult::robcnt() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.robCnt)
  return robcnt_;
}
inline void GCEscortOperateResult::set_robcnt(::google::protobuf::int32 value) {
  set_has_robcnt();
  robcnt_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.robCnt)
}

// optional int32 dartID = 4;
inline bool GCEscortOperateResult::has_dartid() const {
  return (_has_bits_[0] & 0x00000008u) != 0;
}
inline void GCEscortOperateResult::set_has_dartid() {
  _has_bits_[0] |= 0x00000008u;
}
inline void GCEscortOperateResult::clear_has_dartid() {
  _has_bits_[0] &= ~0x00000008u;
}
inline void GCEscortOperateResult::clear_dartid() {
  dartid_ = 0;
  clear_has_dartid();
}
inline ::google::protobuf::int32 GCEscortOperateResult::dartid() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.dartID)
  return dartid_;
}
inline void GCEscortOperateResult::set_dartid(::google::protobuf::int32 value) {
  set_has_dartid();
  dartid_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.dartID)
}

// optional string reward = 5;
inline bool GCEscortOperateResult::has_reward() const {
  return (_has_bits_[0] & 0x00000010u) != 0;
}
inline void GCEscortOperateResult::set_has_reward() {
  _has_bits_[0] |= 0x00000010u;
}
inline void GCEscortOperateResult::clear_has_reward() {
  _has_bits_[0] &= ~0x00000010u;
}
inline void GCEscortOperateResult::clear_reward() {
  if (reward_ != &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    reward_->clear();
  }
  clear_has_reward();
}
inline const ::std::string& GCEscortOperateResult::reward() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.reward)
  return *reward_;
}
inline void GCEscortOperateResult::set_reward(const ::std::string& value) {
  set_has_reward();
  if (reward_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    reward_ = new ::std::string;
  }
  reward_->assign(value);
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.reward)
}
inline void GCEscortOperateResult::set_reward(const char* value) {
  set_has_reward();
  if (reward_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    reward_ = new ::std::string;
  }
  reward_->assign(value);
  // @@protoc_insertion_point(field_set_char:GCEscortOperateResult.reward)
}
inline void GCEscortOperateResult::set_reward(const char* value, size_t size) {
  set_has_reward();
  if (reward_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    reward_ = new ::std::string;
  }
  reward_->assign(reinterpret_cast<const char*>(value), size);
  // @@protoc_insertion_point(field_set_pointer:GCEscortOperateResult.reward)
}
inline ::std::string* GCEscortOperateResult::mutable_reward() {
  set_has_reward();
  if (reward_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    reward_ = new ::std::string;
  }
  // @@protoc_insertion_point(field_mutable:GCEscortOperateResult.reward)
  return reward_;
}
inline ::std::string* GCEscortOperateResult::release_reward() {
  clear_has_reward();
  if (reward_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    return NULL;
  } else {
    ::std::string* temp = reward_;
    reward_ = const_cast< ::std::string*>(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
    return temp;
  }
}
inline void GCEscortOperateResult::set_allocated_reward(::std::string* reward) {
  if (reward_ != &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    delete reward_;
  }
  if (reward) {
    set_has_reward();
    reward_ = reward;
  } else {
    clear_has_reward();
    reward_ = const_cast< ::std::string*>(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
  }
  // @@protoc_insertion_point(field_set_allocated:GCEscortOperateResult.reward)
}

// optional string playerName = 6;
inline bool GCEscortOperateResult::has_playername() const {
  return (_has_bits_[0] & 0x00000020u) != 0;
}
inline void GCEscortOperateResult::set_has_playername() {
  _has_bits_[0] |= 0x00000020u;
}
inline void GCEscortOperateResult::clear_has_playername() {
  _has_bits_[0] &= ~0x00000020u;
}
inline void GCEscortOperateResult::clear_playername() {
  if (playername_ != &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    playername_->clear();
  }
  clear_has_playername();
}
inline const ::std::string& GCEscortOperateResult::playername() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.playerName)
  return *playername_;
}
inline void GCEscortOperateResult::set_playername(const ::std::string& value) {
  set_has_playername();
  if (playername_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    playername_ = new ::std::string;
  }
  playername_->assign(value);
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.playerName)
}
inline void GCEscortOperateResult::set_playername(const char* value) {
  set_has_playername();
  if (playername_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    playername_ = new ::std::string;
  }
  playername_->assign(value);
  // @@protoc_insertion_point(field_set_char:GCEscortOperateResult.playerName)
}
inline void GCEscortOperateResult::set_playername(const char* value, size_t size) {
  set_has_playername();
  if (playername_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    playername_ = new ::std::string;
  }
  playername_->assign(reinterpret_cast<const char*>(value), size);
  // @@protoc_insertion_point(field_set_pointer:GCEscortOperateResult.playerName)
}
inline ::std::string* GCEscortOperateResult::mutable_playername() {
  set_has_playername();
  if (playername_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    playername_ = new ::std::string;
  }
  // @@protoc_insertion_point(field_mutable:GCEscortOperateResult.playerName)
  return playername_;
}
inline ::std::string* GCEscortOperateResult::release_playername() {
  clear_has_playername();
  if (playername_ == &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    return NULL;
  } else {
    ::std::string* temp = playername_;
    playername_ = const_cast< ::std::string*>(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
    return temp;
  }
}
inline void GCEscortOperateResult::set_allocated_playername(::std::string* playername) {
  if (playername_ != &::google::protobuf::internal::GetEmptyStringAlreadyInited()) {
    delete playername_;
  }
  if (playername) {
    set_has_playername();
    playername_ = playername;
  } else {
    clear_has_playername();
    playername_ = const_cast< ::std::string*>(&::google::protobuf::internal::GetEmptyStringAlreadyInited());
  }
  // @@protoc_insertion_point(field_set_allocated:GCEscortOperateResult.playerName)
}

// optional int64 dartPid = 7;
inline bool GCEscortOperateResult::has_dartpid() const {
  return (_has_bits_[0] & 0x00000040u) != 0;
}
inline void GCEscortOperateResult::set_has_dartpid() {
  _has_bits_[0] |= 0x00000040u;
}
inline void GCEscortOperateResult::clear_has_dartpid() {
  _has_bits_[0] &= ~0x00000040u;
}
inline void GCEscortOperateResult::clear_dartpid() {
  dartpid_ = GOOGLE_LONGLONG(0);
  clear_has_dartpid();
}
inline ::google::protobuf::int64 GCEscortOperateResult::dartpid() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.dartPid)
  return dartpid_;
}
inline void GCEscortOperateResult::set_dartpid(::google::protobuf::int64 value) {
  set_has_dartpid();
  dartpid_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.dartPid)
}

// optional int64 endTime = 8;
inline bool GCEscortOperateResult::has_endtime() const {
  return (_has_bits_[0] & 0x00000080u) != 0;
}
inline void GCEscortOperateResult::set_has_endtime() {
  _has_bits_[0] |= 0x00000080u;
}
inline void GCEscortOperateResult::clear_has_endtime() {
  _has_bits_[0] &= ~0x00000080u;
}
inline void GCEscortOperateResult::clear_endtime() {
  endtime_ = GOOGLE_LONGLONG(0);
  clear_has_endtime();
}
inline ::google::protobuf::int64 GCEscortOperateResult::endtime() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.endTime)
  return endtime_;
}
inline void GCEscortOperateResult::set_endtime(::google::protobuf::int64 value) {
  set_has_endtime();
  endtime_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.endTime)
}

// optional int64 failTime = 9;
inline bool GCEscortOperateResult::has_failtime() const {
  return (_has_bits_[0] & 0x00000100u) != 0;
}
inline void GCEscortOperateResult::set_has_failtime() {
  _has_bits_[0] |= 0x00000100u;
}
inline void GCEscortOperateResult::clear_has_failtime() {
  _has_bits_[0] &= ~0x00000100u;
}
inline void GCEscortOperateResult::clear_failtime() {
  failtime_ = GOOGLE_LONGLONG(0);
  clear_has_failtime();
}
inline ::google::protobuf::int64 GCEscortOperateResult::failtime() const {
  // @@protoc_insertion_point(field_get:GCEscortOperateResult.failTime)
  return failtime_;
}
inline void GCEscortOperateResult::set_failtime(::google::protobuf::int64 value) {
  set_has_failtime();
  failtime_ = value;
  // @@protoc_insertion_point(field_set:GCEscortOperateResult.failTime)
}

// -------------------------------------------------------------------

// CGFollowDart

// -------------------------------------------------------------------

// GCFollowDartResult

// optional int32 sceneID = 1;
inline bool GCFollowDartResult::has_sceneid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCFollowDartResult::set_has_sceneid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCFollowDartResult::clear_has_sceneid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCFollowDartResult::clear_sceneid() {
  sceneid_ = 0;
  clear_has_sceneid();
}
inline ::google::protobuf::int32 GCFollowDartResult::sceneid() const {
  // @@protoc_insertion_point(field_get:GCFollowDartResult.sceneID)
  return sceneid_;
}
inline void GCFollowDartResult::set_sceneid(::google::protobuf::int32 value) {
  set_has_sceneid();
  sceneid_ = value;
  // @@protoc_insertion_point(field_set:GCFollowDartResult.sceneID)
}

// optional int32 posX = 2;
inline bool GCFollowDartResult::has_posx() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void GCFollowDartResult::set_has_posx() {
  _has_bits_[0] |= 0x00000002u;
}
inline void GCFollowDartResult::clear_has_posx() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void GCFollowDartResult::clear_posx() {
  posx_ = 0;
  clear_has_posx();
}
inline ::google::protobuf::int32 GCFollowDartResult::posx() const {
  // @@protoc_insertion_point(field_get:GCFollowDartResult.posX)
  return posx_;
}
inline void GCFollowDartResult::set_posx(::google::protobuf::int32 value) {
  set_has_posx();
  posx_ = value;
  // @@protoc_insertion_point(field_set:GCFollowDartResult.posX)
}

// optional int32 posZ = 3;
inline bool GCFollowDartResult::has_posz() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void GCFollowDartResult::set_has_posz() {
  _has_bits_[0] |= 0x00000004u;
}
inline void GCFollowDartResult::clear_has_posz() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void GCFollowDartResult::clear_posz() {
  posz_ = 0;
  clear_has_posz();
}
inline ::google::protobuf::int32 GCFollowDartResult::posz() const {
  // @@protoc_insertion_point(field_get:GCFollowDartResult.posZ)
  return posz_;
}
inline void GCFollowDartResult::set_posz(::google::protobuf::int32 value) {
  set_has_posz();
  posz_ = value;
  // @@protoc_insertion_point(field_set:GCFollowDartResult.posZ)
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_EscortMessage_2eproto__INCLUDED
