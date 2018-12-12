// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: PokedexMesage.proto

#ifndef PROTOBUF_PokedexMesage_2eproto__INCLUDED
#define PROTOBUF_PokedexMesage_2eproto__INCLUDED

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
#include "InnerMessage.pb.h"
// @@protoc_insertion_point(includes)

// Internal implementation detail -- do not call these.
void  protobuf_AddDesc_PokedexMesage_2eproto();
void protobuf_AssignDesc_PokedexMesage_2eproto();
void protobuf_ShutdownFile_PokedexMesage_2eproto();

class PokedexSimpleInfo;
class CGGetPokedex;
class GCGetPokedexList;

// ===================================================================

class PokedexSimpleInfo : public ::google::protobuf::Message {
 public:
  PokedexSimpleInfo();
  virtual ~PokedexSimpleInfo();

  PokedexSimpleInfo(const PokedexSimpleInfo& from);

  inline PokedexSimpleInfo& operator=(const PokedexSimpleInfo& from) {
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
  static const PokedexSimpleInfo& default_instance();

  void Swap(PokedexSimpleInfo* other);

  // implements Message ----------------------------------------------

  PokedexSimpleInfo* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const PokedexSimpleInfo& from);
  void MergeFrom(const PokedexSimpleInfo& from);
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

  // optional int32 pokedexSimpleInfoId = 1;
  inline bool has_pokedexsimpleinfoid() const;
  inline void clear_pokedexsimpleinfoid();
  static const int kPokedexSimpleInfoIdFieldNumber = 1;
  inline ::google::protobuf::int32 pokedexsimpleinfoid() const;
  inline void set_pokedexsimpleinfoid(::google::protobuf::int32 value);

  // optional int32 pokedexSimpleInfoLevel = 2;
  inline bool has_pokedexsimpleinfolevel() const;
  inline void clear_pokedexsimpleinfolevel();
  static const int kPokedexSimpleInfoLevelFieldNumber = 2;
  inline ::google::protobuf::int32 pokedexsimpleinfolevel() const;
  inline void set_pokedexsimpleinfolevel(::google::protobuf::int32 value);

  // optional int32 pokedexSimpleInfoValue = 3;
  inline bool has_pokedexsimpleinfovalue() const;
  inline void clear_pokedexsimpleinfovalue();
  static const int kPokedexSimpleInfoValueFieldNumber = 3;
  inline ::google::protobuf::int32 pokedexsimpleinfovalue() const;
  inline void set_pokedexsimpleinfovalue(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:PokedexSimpleInfo)
 private:
  inline void set_has_pokedexsimpleinfoid();
  inline void clear_has_pokedexsimpleinfoid();
  inline void set_has_pokedexsimpleinfolevel();
  inline void clear_has_pokedexsimpleinfolevel();
  inline void set_has_pokedexsimpleinfovalue();
  inline void clear_has_pokedexsimpleinfovalue();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 pokedexsimpleinfoid_;
  ::google::protobuf::int32 pokedexsimpleinfolevel_;
  ::google::protobuf::int32 pokedexsimpleinfovalue_;
  friend void  protobuf_AddDesc_PokedexMesage_2eproto();
  friend void protobuf_AssignDesc_PokedexMesage_2eproto();
  friend void protobuf_ShutdownFile_PokedexMesage_2eproto();

  void InitAsDefaultInstance();
  static PokedexSimpleInfo* default_instance_;
};
// -------------------------------------------------------------------

class CGGetPokedex : public ::google::protobuf::Message {
 public:
  CGGetPokedex();
  virtual ~CGGetPokedex();

  CGGetPokedex(const CGGetPokedex& from);

  inline CGGetPokedex& operator=(const CGGetPokedex& from) {
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
  static const CGGetPokedex& default_instance();

  void Swap(CGGetPokedex* other);

  // implements Message ----------------------------------------------

  CGGetPokedex* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGGetPokedex& from);
  void MergeFrom(const CGGetPokedex& from);
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

  // optional int64 playerId = 1;
  inline bool has_playerid() const;
  inline void clear_playerid();
  static const int kPlayerIdFieldNumber = 1;
  inline ::google::protobuf::int64 playerid() const;
  inline void set_playerid(::google::protobuf::int64 value);

  // optional int32 type = 2;
  inline bool has_type() const;
  inline void clear_type();
  static const int kTypeFieldNumber = 2;
  inline ::google::protobuf::int32 type() const;
  inline void set_type(::google::protobuf::int32 value);

  // optional int32 id = 3;
  inline bool has_id() const;
  inline void clear_id();
  static const int kIdFieldNumber = 3;
  inline ::google::protobuf::int32 id() const;
  inline void set_id(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:CGGetPokedex)
 private:
  inline void set_has_playerid();
  inline void clear_has_playerid();
  inline void set_has_type();
  inline void clear_has_type();
  inline void set_has_id();
  inline void clear_has_id();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int64 playerid_;
  ::google::protobuf::int32 type_;
  ::google::protobuf::int32 id_;
  friend void  protobuf_AddDesc_PokedexMesage_2eproto();
  friend void protobuf_AssignDesc_PokedexMesage_2eproto();
  friend void protobuf_ShutdownFile_PokedexMesage_2eproto();

  void InitAsDefaultInstance();
  static CGGetPokedex* default_instance_;
};
// -------------------------------------------------------------------

class GCGetPokedexList : public ::google::protobuf::Message {
 public:
  GCGetPokedexList();
  virtual ~GCGetPokedexList();

  GCGetPokedexList(const GCGetPokedexList& from);

  inline GCGetPokedexList& operator=(const GCGetPokedexList& from) {
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
  static const GCGetPokedexList& default_instance();

  void Swap(GCGetPokedexList* other);

  // implements Message ----------------------------------------------

  GCGetPokedexList* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCGetPokedexList& from);
  void MergeFrom(const GCGetPokedexList& from);
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

  // optional int64 lastTime = 1;
  inline bool has_lasttime() const;
  inline void clear_lasttime();
  static const int kLastTimeFieldNumber = 1;
  inline ::google::protobuf::int64 lasttime() const;
  inline void set_lasttime(::google::protobuf::int64 value);

  // optional int32 restNum = 2;
  inline bool has_restnum() const;
  inline void clear_restnum();
  static const int kRestNumFieldNumber = 2;
  inline ::google::protobuf::int32 restnum() const;
  inline void set_restnum(::google::protobuf::int32 value);

  // optional int32 restNumKim = 3;
  inline bool has_restnumkim() const;
  inline void clear_restnumkim();
  static const int kRestNumKimFieldNumber = 3;
  inline ::google::protobuf::int32 restnumkim() const;
  inline void set_restnumkim(::google::protobuf::int32 value);

  // optional int32 type = 4;
  inline bool has_type() const;
  inline void clear_type();
  static const int kTypeFieldNumber = 4;
  inline ::google::protobuf::int32 type() const;
  inline void set_type(::google::protobuf::int32 value);

  // repeated .PokedexSimpleInfo pokedexs = 5;
  inline int pokedexs_size() const;
  inline void clear_pokedexs();
  static const int kPokedexsFieldNumber = 5;
  inline const ::PokedexSimpleInfo& pokedexs(int index) const;
  inline ::PokedexSimpleInfo* mutable_pokedexs(int index);
  inline ::PokedexSimpleInfo* add_pokedexs();
  inline const ::google::protobuf::RepeatedPtrField< ::PokedexSimpleInfo >&
      pokedexs() const;
  inline ::google::protobuf::RepeatedPtrField< ::PokedexSimpleInfo >*
      mutable_pokedexs();

  // optional int32 result = 6;
  inline bool has_result() const;
  inline void clear_result();
  static const int kResultFieldNumber = 6;
  inline ::google::protobuf::int32 result() const;
  inline void set_result(::google::protobuf::int32 value);

  // optional int32 newId = 7;
  inline bool has_newid() const;
  inline void clear_newid();
  static const int kNewIdFieldNumber = 7;
  inline ::google::protobuf::int32 newid() const;
  inline void set_newid(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:GCGetPokedexList)
 private:
  inline void set_has_lasttime();
  inline void clear_has_lasttime();
  inline void set_has_restnum();
  inline void clear_has_restnum();
  inline void set_has_restnumkim();
  inline void clear_has_restnumkim();
  inline void set_has_type();
  inline void clear_has_type();
  inline void set_has_result();
  inline void clear_has_result();
  inline void set_has_newid();
  inline void clear_has_newid();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int64 lasttime_;
  ::google::protobuf::int32 restnum_;
  ::google::protobuf::int32 restnumkim_;
  ::google::protobuf::RepeatedPtrField< ::PokedexSimpleInfo > pokedexs_;
  ::google::protobuf::int32 type_;
  ::google::protobuf::int32 result_;
  ::google::protobuf::int32 newid_;
  friend void  protobuf_AddDesc_PokedexMesage_2eproto();
  friend void protobuf_AssignDesc_PokedexMesage_2eproto();
  friend void protobuf_ShutdownFile_PokedexMesage_2eproto();

  void InitAsDefaultInstance();
  static GCGetPokedexList* default_instance_;
};
// ===================================================================


// ===================================================================

// PokedexSimpleInfo

// optional int32 pokedexSimpleInfoId = 1;
inline bool PokedexSimpleInfo::has_pokedexsimpleinfoid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void PokedexSimpleInfo::set_has_pokedexsimpleinfoid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void PokedexSimpleInfo::clear_has_pokedexsimpleinfoid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void PokedexSimpleInfo::clear_pokedexsimpleinfoid() {
  pokedexsimpleinfoid_ = 0;
  clear_has_pokedexsimpleinfoid();
}
inline ::google::protobuf::int32 PokedexSimpleInfo::pokedexsimpleinfoid() const {
  // @@protoc_insertion_point(field_get:PokedexSimpleInfo.pokedexSimpleInfoId)
  return pokedexsimpleinfoid_;
}
inline void PokedexSimpleInfo::set_pokedexsimpleinfoid(::google::protobuf::int32 value) {
  set_has_pokedexsimpleinfoid();
  pokedexsimpleinfoid_ = value;
  // @@protoc_insertion_point(field_set:PokedexSimpleInfo.pokedexSimpleInfoId)
}

// optional int32 pokedexSimpleInfoLevel = 2;
inline bool PokedexSimpleInfo::has_pokedexsimpleinfolevel() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void PokedexSimpleInfo::set_has_pokedexsimpleinfolevel() {
  _has_bits_[0] |= 0x00000002u;
}
inline void PokedexSimpleInfo::clear_has_pokedexsimpleinfolevel() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void PokedexSimpleInfo::clear_pokedexsimpleinfolevel() {
  pokedexsimpleinfolevel_ = 0;
  clear_has_pokedexsimpleinfolevel();
}
inline ::google::protobuf::int32 PokedexSimpleInfo::pokedexsimpleinfolevel() const {
  // @@protoc_insertion_point(field_get:PokedexSimpleInfo.pokedexSimpleInfoLevel)
  return pokedexsimpleinfolevel_;
}
inline void PokedexSimpleInfo::set_pokedexsimpleinfolevel(::google::protobuf::int32 value) {
  set_has_pokedexsimpleinfolevel();
  pokedexsimpleinfolevel_ = value;
  // @@protoc_insertion_point(field_set:PokedexSimpleInfo.pokedexSimpleInfoLevel)
}

// optional int32 pokedexSimpleInfoValue = 3;
inline bool PokedexSimpleInfo::has_pokedexsimpleinfovalue() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void PokedexSimpleInfo::set_has_pokedexsimpleinfovalue() {
  _has_bits_[0] |= 0x00000004u;
}
inline void PokedexSimpleInfo::clear_has_pokedexsimpleinfovalue() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void PokedexSimpleInfo::clear_pokedexsimpleinfovalue() {
  pokedexsimpleinfovalue_ = 0;
  clear_has_pokedexsimpleinfovalue();
}
inline ::google::protobuf::int32 PokedexSimpleInfo::pokedexsimpleinfovalue() const {
  // @@protoc_insertion_point(field_get:PokedexSimpleInfo.pokedexSimpleInfoValue)
  return pokedexsimpleinfovalue_;
}
inline void PokedexSimpleInfo::set_pokedexsimpleinfovalue(::google::protobuf::int32 value) {
  set_has_pokedexsimpleinfovalue();
  pokedexsimpleinfovalue_ = value;
  // @@protoc_insertion_point(field_set:PokedexSimpleInfo.pokedexSimpleInfoValue)
}

// -------------------------------------------------------------------

// CGGetPokedex

// optional int64 playerId = 1;
inline bool CGGetPokedex::has_playerid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGGetPokedex::set_has_playerid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGGetPokedex::clear_has_playerid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGGetPokedex::clear_playerid() {
  playerid_ = GOOGLE_LONGLONG(0);
  clear_has_playerid();
}
inline ::google::protobuf::int64 CGGetPokedex::playerid() const {
  // @@protoc_insertion_point(field_get:CGGetPokedex.playerId)
  return playerid_;
}
inline void CGGetPokedex::set_playerid(::google::protobuf::int64 value) {
  set_has_playerid();
  playerid_ = value;
  // @@protoc_insertion_point(field_set:CGGetPokedex.playerId)
}

// optional int32 type = 2;
inline bool CGGetPokedex::has_type() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void CGGetPokedex::set_has_type() {
  _has_bits_[0] |= 0x00000002u;
}
inline void CGGetPokedex::clear_has_type() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void CGGetPokedex::clear_type() {
  type_ = 0;
  clear_has_type();
}
inline ::google::protobuf::int32 CGGetPokedex::type() const {
  // @@protoc_insertion_point(field_get:CGGetPokedex.type)
  return type_;
}
inline void CGGetPokedex::set_type(::google::protobuf::int32 value) {
  set_has_type();
  type_ = value;
  // @@protoc_insertion_point(field_set:CGGetPokedex.type)
}

// optional int32 id = 3;
inline bool CGGetPokedex::has_id() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void CGGetPokedex::set_has_id() {
  _has_bits_[0] |= 0x00000004u;
}
inline void CGGetPokedex::clear_has_id() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void CGGetPokedex::clear_id() {
  id_ = 0;
  clear_has_id();
}
inline ::google::protobuf::int32 CGGetPokedex::id() const {
  // @@protoc_insertion_point(field_get:CGGetPokedex.id)
  return id_;
}
inline void CGGetPokedex::set_id(::google::protobuf::int32 value) {
  set_has_id();
  id_ = value;
  // @@protoc_insertion_point(field_set:CGGetPokedex.id)
}

// -------------------------------------------------------------------

// GCGetPokedexList

// optional int64 lastTime = 1;
inline bool GCGetPokedexList::has_lasttime() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCGetPokedexList::set_has_lasttime() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCGetPokedexList::clear_has_lasttime() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCGetPokedexList::clear_lasttime() {
  lasttime_ = GOOGLE_LONGLONG(0);
  clear_has_lasttime();
}
inline ::google::protobuf::int64 GCGetPokedexList::lasttime() const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.lastTime)
  return lasttime_;
}
inline void GCGetPokedexList::set_lasttime(::google::protobuf::int64 value) {
  set_has_lasttime();
  lasttime_ = value;
  // @@protoc_insertion_point(field_set:GCGetPokedexList.lastTime)
}

// optional int32 restNum = 2;
inline bool GCGetPokedexList::has_restnum() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void GCGetPokedexList::set_has_restnum() {
  _has_bits_[0] |= 0x00000002u;
}
inline void GCGetPokedexList::clear_has_restnum() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void GCGetPokedexList::clear_restnum() {
  restnum_ = 0;
  clear_has_restnum();
}
inline ::google::protobuf::int32 GCGetPokedexList::restnum() const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.restNum)
  return restnum_;
}
inline void GCGetPokedexList::set_restnum(::google::protobuf::int32 value) {
  set_has_restnum();
  restnum_ = value;
  // @@protoc_insertion_point(field_set:GCGetPokedexList.restNum)
}

// optional int32 restNumKim = 3;
inline bool GCGetPokedexList::has_restnumkim() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void GCGetPokedexList::set_has_restnumkim() {
  _has_bits_[0] |= 0x00000004u;
}
inline void GCGetPokedexList::clear_has_restnumkim() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void GCGetPokedexList::clear_restnumkim() {
  restnumkim_ = 0;
  clear_has_restnumkim();
}
inline ::google::protobuf::int32 GCGetPokedexList::restnumkim() const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.restNumKim)
  return restnumkim_;
}
inline void GCGetPokedexList::set_restnumkim(::google::protobuf::int32 value) {
  set_has_restnumkim();
  restnumkim_ = value;
  // @@protoc_insertion_point(field_set:GCGetPokedexList.restNumKim)
}

// optional int32 type = 4;
inline bool GCGetPokedexList::has_type() const {
  return (_has_bits_[0] & 0x00000008u) != 0;
}
inline void GCGetPokedexList::set_has_type() {
  _has_bits_[0] |= 0x00000008u;
}
inline void GCGetPokedexList::clear_has_type() {
  _has_bits_[0] &= ~0x00000008u;
}
inline void GCGetPokedexList::clear_type() {
  type_ = 0;
  clear_has_type();
}
inline ::google::protobuf::int32 GCGetPokedexList::type() const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.type)
  return type_;
}
inline void GCGetPokedexList::set_type(::google::protobuf::int32 value) {
  set_has_type();
  type_ = value;
  // @@protoc_insertion_point(field_set:GCGetPokedexList.type)
}

// repeated .PokedexSimpleInfo pokedexs = 5;
inline int GCGetPokedexList::pokedexs_size() const {
  return pokedexs_.size();
}
inline void GCGetPokedexList::clear_pokedexs() {
  pokedexs_.Clear();
}
inline const ::PokedexSimpleInfo& GCGetPokedexList::pokedexs(int index) const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.pokedexs)
  return pokedexs_.Get(index);
}
inline ::PokedexSimpleInfo* GCGetPokedexList::mutable_pokedexs(int index) {
  // @@protoc_insertion_point(field_mutable:GCGetPokedexList.pokedexs)
  return pokedexs_.Mutable(index);
}
inline ::PokedexSimpleInfo* GCGetPokedexList::add_pokedexs() {
  // @@protoc_insertion_point(field_add:GCGetPokedexList.pokedexs)
  return pokedexs_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::PokedexSimpleInfo >&
GCGetPokedexList::pokedexs() const {
  // @@protoc_insertion_point(field_list:GCGetPokedexList.pokedexs)
  return pokedexs_;
}
inline ::google::protobuf::RepeatedPtrField< ::PokedexSimpleInfo >*
GCGetPokedexList::mutable_pokedexs() {
  // @@protoc_insertion_point(field_mutable_list:GCGetPokedexList.pokedexs)
  return &pokedexs_;
}

// optional int32 result = 6;
inline bool GCGetPokedexList::has_result() const {
  return (_has_bits_[0] & 0x00000020u) != 0;
}
inline void GCGetPokedexList::set_has_result() {
  _has_bits_[0] |= 0x00000020u;
}
inline void GCGetPokedexList::clear_has_result() {
  _has_bits_[0] &= ~0x00000020u;
}
inline void GCGetPokedexList::clear_result() {
  result_ = 0;
  clear_has_result();
}
inline ::google::protobuf::int32 GCGetPokedexList::result() const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.result)
  return result_;
}
inline void GCGetPokedexList::set_result(::google::protobuf::int32 value) {
  set_has_result();
  result_ = value;
  // @@protoc_insertion_point(field_set:GCGetPokedexList.result)
}

// optional int32 newId = 7;
inline bool GCGetPokedexList::has_newid() const {
  return (_has_bits_[0] & 0x00000040u) != 0;
}
inline void GCGetPokedexList::set_has_newid() {
  _has_bits_[0] |= 0x00000040u;
}
inline void GCGetPokedexList::clear_has_newid() {
  _has_bits_[0] &= ~0x00000040u;
}
inline void GCGetPokedexList::clear_newid() {
  newid_ = 0;
  clear_has_newid();
}
inline ::google::protobuf::int32 GCGetPokedexList::newid() const {
  // @@protoc_insertion_point(field_get:GCGetPokedexList.newId)
  return newid_;
}
inline void GCGetPokedexList::set_newid(::google::protobuf::int32 value) {
  set_has_newid();
  newid_ = value;
  // @@protoc_insertion_point(field_set:GCGetPokedexList.newId)
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_PokedexMesage_2eproto__INCLUDED
