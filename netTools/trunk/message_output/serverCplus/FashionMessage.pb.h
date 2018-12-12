// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: FashionMessage.proto

#ifndef PROTOBUF_FashionMessage_2eproto__INCLUDED
#define PROTOBUF_FashionMessage_2eproto__INCLUDED

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
void  protobuf_AddDesc_FashionMessage_2eproto();
void protobuf_AssignDesc_FashionMessage_2eproto();
void protobuf_ShutdownFile_FashionMessage_2eproto();

class GCBackFashionData;
class CGSwitchFashionData;
class GCSwitchFashionDataBack;
class CGBuyFashionData;
class GCBuyFashionDataBack;
class CGMakeFashionData;
class GCMakeFashionDataBack;
class GCCreateCharacterInfo;

// ===================================================================

class GCBackFashionData : public ::google::protobuf::Message {
 public:
  GCBackFashionData();
  virtual ~GCBackFashionData();

  GCBackFashionData(const GCBackFashionData& from);

  inline GCBackFashionData& operator=(const GCBackFashionData& from) {
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
  static const GCBackFashionData& default_instance();

  void Swap(GCBackFashionData* other);

  // implements Message ----------------------------------------------

  GCBackFashionData* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCBackFashionData& from);
  void MergeFrom(const GCBackFashionData& from);
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

  // repeated .PlayerFashion playerfashion = 1;
  inline int playerfashion_size() const;
  inline void clear_playerfashion();
  static const int kPlayerfashionFieldNumber = 1;
  inline const ::PlayerFashion& playerfashion(int index) const;
  inline ::PlayerFashion* mutable_playerfashion(int index);
  inline ::PlayerFashion* add_playerfashion();
  inline const ::google::protobuf::RepeatedPtrField< ::PlayerFashion >&
      playerfashion() const;
  inline ::google::protobuf::RepeatedPtrField< ::PlayerFashion >*
      mutable_playerfashion();

  // @@protoc_insertion_point(class_scope:GCBackFashionData)
 private:

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::RepeatedPtrField< ::PlayerFashion > playerfashion_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static GCBackFashionData* default_instance_;
};
// -------------------------------------------------------------------

class CGSwitchFashionData : public ::google::protobuf::Message {
 public:
  CGSwitchFashionData();
  virtual ~CGSwitchFashionData();

  CGSwitchFashionData(const CGSwitchFashionData& from);

  inline CGSwitchFashionData& operator=(const CGSwitchFashionData& from) {
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
  static const CGSwitchFashionData& default_instance();

  void Swap(CGSwitchFashionData* other);

  // implements Message ----------------------------------------------

  CGSwitchFashionData* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGSwitchFashionData& from);
  void MergeFrom(const CGSwitchFashionData& from);
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

  // @@protoc_insertion_point(class_scope:CGSwitchFashionData)
 private:

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static CGSwitchFashionData* default_instance_;
};
// -------------------------------------------------------------------

class GCSwitchFashionDataBack : public ::google::protobuf::Message {
 public:
  GCSwitchFashionDataBack();
  virtual ~GCSwitchFashionDataBack();

  GCSwitchFashionDataBack(const GCSwitchFashionDataBack& from);

  inline GCSwitchFashionDataBack& operator=(const GCSwitchFashionDataBack& from) {
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
  static const GCSwitchFashionDataBack& default_instance();

  void Swap(GCSwitchFashionDataBack* other);

  // implements Message ----------------------------------------------

  GCSwitchFashionDataBack* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCSwitchFashionDataBack& from);
  void MergeFrom(const GCSwitchFashionDataBack& from);
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

  // optional int32 flag = 1;
  inline bool has_flag() const;
  inline void clear_flag();
  static const int kFlagFieldNumber = 1;
  inline ::google::protobuf::int32 flag() const;
  inline void set_flag(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:GCSwitchFashionDataBack)
 private:
  inline void set_has_flag();
  inline void clear_has_flag();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 flag_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static GCSwitchFashionDataBack* default_instance_;
};
// -------------------------------------------------------------------

class CGBuyFashionData : public ::google::protobuf::Message {
 public:
  CGBuyFashionData();
  virtual ~CGBuyFashionData();

  CGBuyFashionData(const CGBuyFashionData& from);

  inline CGBuyFashionData& operator=(const CGBuyFashionData& from) {
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
  static const CGBuyFashionData& default_instance();

  void Swap(CGBuyFashionData* other);

  // implements Message ----------------------------------------------

  CGBuyFashionData* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGBuyFashionData& from);
  void MergeFrom(const CGBuyFashionData& from);
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

  // optional int32 tableid = 1;
  inline bool has_tableid() const;
  inline void clear_tableid();
  static const int kTableidFieldNumber = 1;
  inline ::google::protobuf::int32 tableid() const;
  inline void set_tableid(::google::protobuf::int32 value);

  // optional int32 timetype = 2;
  inline bool has_timetype() const;
  inline void clear_timetype();
  static const int kTimetypeFieldNumber = 2;
  inline ::google::protobuf::int32 timetype() const;
  inline void set_timetype(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:CGBuyFashionData)
 private:
  inline void set_has_tableid();
  inline void clear_has_tableid();
  inline void set_has_timetype();
  inline void clear_has_timetype();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 tableid_;
  ::google::protobuf::int32 timetype_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static CGBuyFashionData* default_instance_;
};
// -------------------------------------------------------------------

class GCBuyFashionDataBack : public ::google::protobuf::Message {
 public:
  GCBuyFashionDataBack();
  virtual ~GCBuyFashionDataBack();

  GCBuyFashionDataBack(const GCBuyFashionDataBack& from);

  inline GCBuyFashionDataBack& operator=(const GCBuyFashionDataBack& from) {
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
  static const GCBuyFashionDataBack& default_instance();

  void Swap(GCBuyFashionDataBack* other);

  // implements Message ----------------------------------------------

  GCBuyFashionDataBack* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCBuyFashionDataBack& from);
  void MergeFrom(const GCBuyFashionDataBack& from);
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

  // optional int32 flag = 1;
  inline bool has_flag() const;
  inline void clear_flag();
  static const int kFlagFieldNumber = 1;
  inline ::google::protobuf::int32 flag() const;
  inline void set_flag(::google::protobuf::int32 value);

  // repeated .PlayerFashion playerfashion = 2;
  inline int playerfashion_size() const;
  inline void clear_playerfashion();
  static const int kPlayerfashionFieldNumber = 2;
  inline const ::PlayerFashion& playerfashion(int index) const;
  inline ::PlayerFashion* mutable_playerfashion(int index);
  inline ::PlayerFashion* add_playerfashion();
  inline const ::google::protobuf::RepeatedPtrField< ::PlayerFashion >&
      playerfashion() const;
  inline ::google::protobuf::RepeatedPtrField< ::PlayerFashion >*
      mutable_playerfashion();

  // @@protoc_insertion_point(class_scope:GCBuyFashionDataBack)
 private:
  inline void set_has_flag();
  inline void clear_has_flag();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::RepeatedPtrField< ::PlayerFashion > playerfashion_;
  ::google::protobuf::int32 flag_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static GCBuyFashionDataBack* default_instance_;
};
// -------------------------------------------------------------------

class CGMakeFashionData : public ::google::protobuf::Message {
 public:
  CGMakeFashionData();
  virtual ~CGMakeFashionData();

  CGMakeFashionData(const CGMakeFashionData& from);

  inline CGMakeFashionData& operator=(const CGMakeFashionData& from) {
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
  static const CGMakeFashionData& default_instance();

  void Swap(CGMakeFashionData* other);

  // implements Message ----------------------------------------------

  CGMakeFashionData* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGMakeFashionData& from);
  void MergeFrom(const CGMakeFashionData& from);
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

  // optional int64 serverid = 1;
  inline bool has_serverid() const;
  inline void clear_serverid();
  static const int kServeridFieldNumber = 1;
  inline ::google::protobuf::int64 serverid() const;
  inline void set_serverid(::google::protobuf::int64 value);

  // @@protoc_insertion_point(class_scope:CGMakeFashionData)
 private:
  inline void set_has_serverid();
  inline void clear_has_serverid();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int64 serverid_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static CGMakeFashionData* default_instance_;
};
// -------------------------------------------------------------------

class GCMakeFashionDataBack : public ::google::protobuf::Message {
 public:
  GCMakeFashionDataBack();
  virtual ~GCMakeFashionDataBack();

  GCMakeFashionDataBack(const GCMakeFashionDataBack& from);

  inline GCMakeFashionDataBack& operator=(const GCMakeFashionDataBack& from) {
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
  static const GCMakeFashionDataBack& default_instance();

  void Swap(GCMakeFashionDataBack* other);

  // implements Message ----------------------------------------------

  GCMakeFashionDataBack* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCMakeFashionDataBack& from);
  void MergeFrom(const GCMakeFashionDataBack& from);
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

  // optional int32 flag = 1;
  inline bool has_flag() const;
  inline void clear_flag();
  static const int kFlagFieldNumber = 1;
  inline ::google::protobuf::int32 flag() const;
  inline void set_flag(::google::protobuf::int32 value);

  // repeated .PlayerFashion playerfashion = 2;
  inline int playerfashion_size() const;
  inline void clear_playerfashion();
  static const int kPlayerfashionFieldNumber = 2;
  inline const ::PlayerFashion& playerfashion(int index) const;
  inline ::PlayerFashion* mutable_playerfashion(int index);
  inline ::PlayerFashion* add_playerfashion();
  inline const ::google::protobuf::RepeatedPtrField< ::PlayerFashion >&
      playerfashion() const;
  inline ::google::protobuf::RepeatedPtrField< ::PlayerFashion >*
      mutable_playerfashion();

  // @@protoc_insertion_point(class_scope:GCMakeFashionDataBack)
 private:
  inline void set_has_flag();
  inline void clear_has_flag();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::RepeatedPtrField< ::PlayerFashion > playerfashion_;
  ::google::protobuf::int32 flag_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static GCMakeFashionDataBack* default_instance_;
};
// -------------------------------------------------------------------

class GCCreateCharacterInfo : public ::google::protobuf::Message {
 public:
  GCCreateCharacterInfo();
  virtual ~GCCreateCharacterInfo();

  GCCreateCharacterInfo(const GCCreateCharacterInfo& from);

  inline GCCreateCharacterInfo& operator=(const GCCreateCharacterInfo& from) {
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
  static const GCCreateCharacterInfo& default_instance();

  void Swap(GCCreateCharacterInfo* other);

  // implements Message ----------------------------------------------

  GCCreateCharacterInfo* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCCreateCharacterInfo& from);
  void MergeFrom(const GCCreateCharacterInfo& from);
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

  // optional .CharacterInfo characterInfo = 1;
  inline bool has_characterinfo() const;
  inline void clear_characterinfo();
  static const int kCharacterInfoFieldNumber = 1;
  inline const ::CharacterInfo& characterinfo() const;
  inline ::CharacterInfo* mutable_characterinfo();
  inline ::CharacterInfo* release_characterinfo();
  inline void set_allocated_characterinfo(::CharacterInfo* characterinfo);

  // @@protoc_insertion_point(class_scope:GCCreateCharacterInfo)
 private:
  inline void set_has_characterinfo();
  inline void clear_has_characterinfo();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::CharacterInfo* characterinfo_;
  friend void  protobuf_AddDesc_FashionMessage_2eproto();
  friend void protobuf_AssignDesc_FashionMessage_2eproto();
  friend void protobuf_ShutdownFile_FashionMessage_2eproto();

  void InitAsDefaultInstance();
  static GCCreateCharacterInfo* default_instance_;
};
// ===================================================================


// ===================================================================

// GCBackFashionData

// repeated .PlayerFashion playerfashion = 1;
inline int GCBackFashionData::playerfashion_size() const {
  return playerfashion_.size();
}
inline void GCBackFashionData::clear_playerfashion() {
  playerfashion_.Clear();
}
inline const ::PlayerFashion& GCBackFashionData::playerfashion(int index) const {
  // @@protoc_insertion_point(field_get:GCBackFashionData.playerfashion)
  return playerfashion_.Get(index);
}
inline ::PlayerFashion* GCBackFashionData::mutable_playerfashion(int index) {
  // @@protoc_insertion_point(field_mutable:GCBackFashionData.playerfashion)
  return playerfashion_.Mutable(index);
}
inline ::PlayerFashion* GCBackFashionData::add_playerfashion() {
  // @@protoc_insertion_point(field_add:GCBackFashionData.playerfashion)
  return playerfashion_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::PlayerFashion >&
GCBackFashionData::playerfashion() const {
  // @@protoc_insertion_point(field_list:GCBackFashionData.playerfashion)
  return playerfashion_;
}
inline ::google::protobuf::RepeatedPtrField< ::PlayerFashion >*
GCBackFashionData::mutable_playerfashion() {
  // @@protoc_insertion_point(field_mutable_list:GCBackFashionData.playerfashion)
  return &playerfashion_;
}

// -------------------------------------------------------------------

// CGSwitchFashionData

// -------------------------------------------------------------------

// GCSwitchFashionDataBack

// optional int32 flag = 1;
inline bool GCSwitchFashionDataBack::has_flag() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCSwitchFashionDataBack::set_has_flag() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCSwitchFashionDataBack::clear_has_flag() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCSwitchFashionDataBack::clear_flag() {
  flag_ = 0;
  clear_has_flag();
}
inline ::google::protobuf::int32 GCSwitchFashionDataBack::flag() const {
  // @@protoc_insertion_point(field_get:GCSwitchFashionDataBack.flag)
  return flag_;
}
inline void GCSwitchFashionDataBack::set_flag(::google::protobuf::int32 value) {
  set_has_flag();
  flag_ = value;
  // @@protoc_insertion_point(field_set:GCSwitchFashionDataBack.flag)
}

// -------------------------------------------------------------------

// CGBuyFashionData

// optional int32 tableid = 1;
inline bool CGBuyFashionData::has_tableid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGBuyFashionData::set_has_tableid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGBuyFashionData::clear_has_tableid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGBuyFashionData::clear_tableid() {
  tableid_ = 0;
  clear_has_tableid();
}
inline ::google::protobuf::int32 CGBuyFashionData::tableid() const {
  // @@protoc_insertion_point(field_get:CGBuyFashionData.tableid)
  return tableid_;
}
inline void CGBuyFashionData::set_tableid(::google::protobuf::int32 value) {
  set_has_tableid();
  tableid_ = value;
  // @@protoc_insertion_point(field_set:CGBuyFashionData.tableid)
}

// optional int32 timetype = 2;
inline bool CGBuyFashionData::has_timetype() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void CGBuyFashionData::set_has_timetype() {
  _has_bits_[0] |= 0x00000002u;
}
inline void CGBuyFashionData::clear_has_timetype() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void CGBuyFashionData::clear_timetype() {
  timetype_ = 0;
  clear_has_timetype();
}
inline ::google::protobuf::int32 CGBuyFashionData::timetype() const {
  // @@protoc_insertion_point(field_get:CGBuyFashionData.timetype)
  return timetype_;
}
inline void CGBuyFashionData::set_timetype(::google::protobuf::int32 value) {
  set_has_timetype();
  timetype_ = value;
  // @@protoc_insertion_point(field_set:CGBuyFashionData.timetype)
}

// -------------------------------------------------------------------

// GCBuyFashionDataBack

// optional int32 flag = 1;
inline bool GCBuyFashionDataBack::has_flag() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCBuyFashionDataBack::set_has_flag() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCBuyFashionDataBack::clear_has_flag() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCBuyFashionDataBack::clear_flag() {
  flag_ = 0;
  clear_has_flag();
}
inline ::google::protobuf::int32 GCBuyFashionDataBack::flag() const {
  // @@protoc_insertion_point(field_get:GCBuyFashionDataBack.flag)
  return flag_;
}
inline void GCBuyFashionDataBack::set_flag(::google::protobuf::int32 value) {
  set_has_flag();
  flag_ = value;
  // @@protoc_insertion_point(field_set:GCBuyFashionDataBack.flag)
}

// repeated .PlayerFashion playerfashion = 2;
inline int GCBuyFashionDataBack::playerfashion_size() const {
  return playerfashion_.size();
}
inline void GCBuyFashionDataBack::clear_playerfashion() {
  playerfashion_.Clear();
}
inline const ::PlayerFashion& GCBuyFashionDataBack::playerfashion(int index) const {
  // @@protoc_insertion_point(field_get:GCBuyFashionDataBack.playerfashion)
  return playerfashion_.Get(index);
}
inline ::PlayerFashion* GCBuyFashionDataBack::mutable_playerfashion(int index) {
  // @@protoc_insertion_point(field_mutable:GCBuyFashionDataBack.playerfashion)
  return playerfashion_.Mutable(index);
}
inline ::PlayerFashion* GCBuyFashionDataBack::add_playerfashion() {
  // @@protoc_insertion_point(field_add:GCBuyFashionDataBack.playerfashion)
  return playerfashion_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::PlayerFashion >&
GCBuyFashionDataBack::playerfashion() const {
  // @@protoc_insertion_point(field_list:GCBuyFashionDataBack.playerfashion)
  return playerfashion_;
}
inline ::google::protobuf::RepeatedPtrField< ::PlayerFashion >*
GCBuyFashionDataBack::mutable_playerfashion() {
  // @@protoc_insertion_point(field_mutable_list:GCBuyFashionDataBack.playerfashion)
  return &playerfashion_;
}

// -------------------------------------------------------------------

// CGMakeFashionData

// optional int64 serverid = 1;
inline bool CGMakeFashionData::has_serverid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGMakeFashionData::set_has_serverid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGMakeFashionData::clear_has_serverid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGMakeFashionData::clear_serverid() {
  serverid_ = GOOGLE_LONGLONG(0);
  clear_has_serverid();
}
inline ::google::protobuf::int64 CGMakeFashionData::serverid() const {
  // @@protoc_insertion_point(field_get:CGMakeFashionData.serverid)
  return serverid_;
}
inline void CGMakeFashionData::set_serverid(::google::protobuf::int64 value) {
  set_has_serverid();
  serverid_ = value;
  // @@protoc_insertion_point(field_set:CGMakeFashionData.serverid)
}

// -------------------------------------------------------------------

// GCMakeFashionDataBack

// optional int32 flag = 1;
inline bool GCMakeFashionDataBack::has_flag() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCMakeFashionDataBack::set_has_flag() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCMakeFashionDataBack::clear_has_flag() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCMakeFashionDataBack::clear_flag() {
  flag_ = 0;
  clear_has_flag();
}
inline ::google::protobuf::int32 GCMakeFashionDataBack::flag() const {
  // @@protoc_insertion_point(field_get:GCMakeFashionDataBack.flag)
  return flag_;
}
inline void GCMakeFashionDataBack::set_flag(::google::protobuf::int32 value) {
  set_has_flag();
  flag_ = value;
  // @@protoc_insertion_point(field_set:GCMakeFashionDataBack.flag)
}

// repeated .PlayerFashion playerfashion = 2;
inline int GCMakeFashionDataBack::playerfashion_size() const {
  return playerfashion_.size();
}
inline void GCMakeFashionDataBack::clear_playerfashion() {
  playerfashion_.Clear();
}
inline const ::PlayerFashion& GCMakeFashionDataBack::playerfashion(int index) const {
  // @@protoc_insertion_point(field_get:GCMakeFashionDataBack.playerfashion)
  return playerfashion_.Get(index);
}
inline ::PlayerFashion* GCMakeFashionDataBack::mutable_playerfashion(int index) {
  // @@protoc_insertion_point(field_mutable:GCMakeFashionDataBack.playerfashion)
  return playerfashion_.Mutable(index);
}
inline ::PlayerFashion* GCMakeFashionDataBack::add_playerfashion() {
  // @@protoc_insertion_point(field_add:GCMakeFashionDataBack.playerfashion)
  return playerfashion_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::PlayerFashion >&
GCMakeFashionDataBack::playerfashion() const {
  // @@protoc_insertion_point(field_list:GCMakeFashionDataBack.playerfashion)
  return playerfashion_;
}
inline ::google::protobuf::RepeatedPtrField< ::PlayerFashion >*
GCMakeFashionDataBack::mutable_playerfashion() {
  // @@protoc_insertion_point(field_mutable_list:GCMakeFashionDataBack.playerfashion)
  return &playerfashion_;
}

// -------------------------------------------------------------------

// GCCreateCharacterInfo

// optional .CharacterInfo characterInfo = 1;
inline bool GCCreateCharacterInfo::has_characterinfo() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCCreateCharacterInfo::set_has_characterinfo() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCCreateCharacterInfo::clear_has_characterinfo() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCCreateCharacterInfo::clear_characterinfo() {
  if (characterinfo_ != NULL) characterinfo_->::CharacterInfo::Clear();
  clear_has_characterinfo();
}
inline const ::CharacterInfo& GCCreateCharacterInfo::characterinfo() const {
  // @@protoc_insertion_point(field_get:GCCreateCharacterInfo.characterInfo)
  return characterinfo_ != NULL ? *characterinfo_ : *default_instance_->characterinfo_;
}
inline ::CharacterInfo* GCCreateCharacterInfo::mutable_characterinfo() {
  set_has_characterinfo();
  if (characterinfo_ == NULL) characterinfo_ = new ::CharacterInfo;
  // @@protoc_insertion_point(field_mutable:GCCreateCharacterInfo.characterInfo)
  return characterinfo_;
}
inline ::CharacterInfo* GCCreateCharacterInfo::release_characterinfo() {
  clear_has_characterinfo();
  ::CharacterInfo* temp = characterinfo_;
  characterinfo_ = NULL;
  return temp;
}
inline void GCCreateCharacterInfo::set_allocated_characterinfo(::CharacterInfo* characterinfo) {
  delete characterinfo_;
  characterinfo_ = characterinfo;
  if (characterinfo) {
    set_has_characterinfo();
  } else {
    clear_has_characterinfo();
  }
  // @@protoc_insertion_point(field_set_allocated:GCCreateCharacterInfo.characterInfo)
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_FashionMessage_2eproto__INCLUDED
