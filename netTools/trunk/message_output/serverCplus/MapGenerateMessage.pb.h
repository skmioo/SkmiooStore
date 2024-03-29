// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: MapGenerateMessage.proto

#ifndef PROTOBUF_MapGenerateMessage_2eproto__INCLUDED
#define PROTOBUF_MapGenerateMessage_2eproto__INCLUDED

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
void  protobuf_AddDesc_MapGenerateMessage_2eproto();
void protobuf_AssignDesc_MapGenerateMessage_2eproto();
void protobuf_ShutdownFile_MapGenerateMessage_2eproto();

class GCRandomIslandInfo;

// ===================================================================

class GCRandomIslandInfo : public ::google::protobuf::Message {
 public:
  GCRandomIslandInfo();
  virtual ~GCRandomIslandInfo();

  GCRandomIslandInfo(const GCRandomIslandInfo& from);

  inline GCRandomIslandInfo& operator=(const GCRandomIslandInfo& from) {
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
  static const GCRandomIslandInfo& default_instance();

  void Swap(GCRandomIslandInfo* other);

  // implements Message ----------------------------------------------

  GCRandomIslandInfo* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCRandomIslandInfo& from);
  void MergeFrom(const GCRandomIslandInfo& from);
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

  // repeated .RandomIsland randomIsland = 1;
  inline int randomisland_size() const;
  inline void clear_randomisland();
  static const int kRandomIslandFieldNumber = 1;
  inline const ::RandomIsland& randomisland(int index) const;
  inline ::RandomIsland* mutable_randomisland(int index);
  inline ::RandomIsland* add_randomisland();
  inline const ::google::protobuf::RepeatedPtrField< ::RandomIsland >&
      randomisland() const;
  inline ::google::protobuf::RepeatedPtrField< ::RandomIsland >*
      mutable_randomisland();

  // @@protoc_insertion_point(class_scope:GCRandomIslandInfo)
 private:

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::RepeatedPtrField< ::RandomIsland > randomisland_;
  friend void  protobuf_AddDesc_MapGenerateMessage_2eproto();
  friend void protobuf_AssignDesc_MapGenerateMessage_2eproto();
  friend void protobuf_ShutdownFile_MapGenerateMessage_2eproto();

  void InitAsDefaultInstance();
  static GCRandomIslandInfo* default_instance_;
};
// ===================================================================


// ===================================================================

// GCRandomIslandInfo

// repeated .RandomIsland randomIsland = 1;
inline int GCRandomIslandInfo::randomisland_size() const {
  return randomisland_.size();
}
inline void GCRandomIslandInfo::clear_randomisland() {
  randomisland_.Clear();
}
inline const ::RandomIsland& GCRandomIslandInfo::randomisland(int index) const {
  // @@protoc_insertion_point(field_get:GCRandomIslandInfo.randomIsland)
  return randomisland_.Get(index);
}
inline ::RandomIsland* GCRandomIslandInfo::mutable_randomisland(int index) {
  // @@protoc_insertion_point(field_mutable:GCRandomIslandInfo.randomIsland)
  return randomisland_.Mutable(index);
}
inline ::RandomIsland* GCRandomIslandInfo::add_randomisland() {
  // @@protoc_insertion_point(field_add:GCRandomIslandInfo.randomIsland)
  return randomisland_.Add();
}
inline const ::google::protobuf::RepeatedPtrField< ::RandomIsland >&
GCRandomIslandInfo::randomisland() const {
  // @@protoc_insertion_point(field_list:GCRandomIslandInfo.randomIsland)
  return randomisland_;
}
inline ::google::protobuf::RepeatedPtrField< ::RandomIsland >*
GCRandomIslandInfo::mutable_randomisland() {
  // @@protoc_insertion_point(field_mutable_list:GCRandomIslandInfo.randomIsland)
  return &randomisland_;
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_MapGenerateMessage_2eproto__INCLUDED
