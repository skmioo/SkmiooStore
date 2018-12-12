// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: NoviceGuideMessage.proto

#ifndef PROTOBUF_NoviceGuideMessage_2eproto__INCLUDED
#define PROTOBUF_NoviceGuideMessage_2eproto__INCLUDED

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
void  protobuf_AddDesc_NoviceGuideMessage_2eproto();
void protobuf_AssignDesc_NoviceGuideMessage_2eproto();
void protobuf_ShutdownFile_NoviceGuideMessage_2eproto();

class GCNoviceGuideBack;
class CGNoviceGuideFinish;
class GCViewMovie;
class CGViewMovieFinish;

// ===================================================================

class GCNoviceGuideBack : public ::google::protobuf::Message {
 public:
  GCNoviceGuideBack();
  virtual ~GCNoviceGuideBack();

  GCNoviceGuideBack(const GCNoviceGuideBack& from);

  inline GCNoviceGuideBack& operator=(const GCNoviceGuideBack& from) {
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
  static const GCNoviceGuideBack& default_instance();

  void Swap(GCNoviceGuideBack* other);

  // implements Message ----------------------------------------------

  GCNoviceGuideBack* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCNoviceGuideBack& from);
  void MergeFrom(const GCNoviceGuideBack& from);
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

  // optional int32 fragmentId = 1;
  inline bool has_fragmentid() const;
  inline void clear_fragmentid();
  static const int kFragmentIdFieldNumber = 1;
  inline ::google::protobuf::int32 fragmentid() const;
  inline void set_fragmentid(::google::protobuf::int32 value);

  // optional int32 shortId = 2;
  inline bool has_shortid() const;
  inline void clear_shortid();
  static const int kShortIdFieldNumber = 2;
  inline ::google::protobuf::int32 shortid() const;
  inline void set_shortid(::google::protobuf::int32 value);

  // optional int32 type = 3;
  inline bool has_type() const;
  inline void clear_type();
  static const int kTypeFieldNumber = 3;
  inline ::google::protobuf::int32 type() const;
  inline void set_type(::google::protobuf::int32 value);

  // optional int32 result = 4;
  inline bool has_result() const;
  inline void clear_result();
  static const int kResultFieldNumber = 4;
  inline ::google::protobuf::int32 result() const;
  inline void set_result(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:GCNoviceGuideBack)
 private:
  inline void set_has_fragmentid();
  inline void clear_has_fragmentid();
  inline void set_has_shortid();
  inline void clear_has_shortid();
  inline void set_has_type();
  inline void clear_has_type();
  inline void set_has_result();
  inline void clear_has_result();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 fragmentid_;
  ::google::protobuf::int32 shortid_;
  ::google::protobuf::int32 type_;
  ::google::protobuf::int32 result_;
  friend void  protobuf_AddDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_AssignDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_ShutdownFile_NoviceGuideMessage_2eproto();

  void InitAsDefaultInstance();
  static GCNoviceGuideBack* default_instance_;
};
// -------------------------------------------------------------------

class CGNoviceGuideFinish : public ::google::protobuf::Message {
 public:
  CGNoviceGuideFinish();
  virtual ~CGNoviceGuideFinish();

  CGNoviceGuideFinish(const CGNoviceGuideFinish& from);

  inline CGNoviceGuideFinish& operator=(const CGNoviceGuideFinish& from) {
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
  static const CGNoviceGuideFinish& default_instance();

  void Swap(CGNoviceGuideFinish* other);

  // implements Message ----------------------------------------------

  CGNoviceGuideFinish* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGNoviceGuideFinish& from);
  void MergeFrom(const CGNoviceGuideFinish& from);
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

  // optional int32 fragmentId = 1;
  inline bool has_fragmentid() const;
  inline void clear_fragmentid();
  static const int kFragmentIdFieldNumber = 1;
  inline ::google::protobuf::int32 fragmentid() const;
  inline void set_fragmentid(::google::protobuf::int32 value);

  // optional int32 shortId = 2;
  inline bool has_shortid() const;
  inline void clear_shortid();
  static const int kShortIdFieldNumber = 2;
  inline ::google::protobuf::int32 shortid() const;
  inline void set_shortid(::google::protobuf::int32 value);

  // @@protoc_insertion_point(class_scope:CGNoviceGuideFinish)
 private:
  inline void set_has_fragmentid();
  inline void clear_has_fragmentid();
  inline void set_has_shortid();
  inline void clear_has_shortid();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 fragmentid_;
  ::google::protobuf::int32 shortid_;
  friend void  protobuf_AddDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_AssignDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_ShutdownFile_NoviceGuideMessage_2eproto();

  void InitAsDefaultInstance();
  static CGNoviceGuideFinish* default_instance_;
};
// -------------------------------------------------------------------

class GCViewMovie : public ::google::protobuf::Message {
 public:
  GCViewMovie();
  virtual ~GCViewMovie();

  GCViewMovie(const GCViewMovie& from);

  inline GCViewMovie& operator=(const GCViewMovie& from) {
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
  static const GCViewMovie& default_instance();

  void Swap(GCViewMovie* other);

  // implements Message ----------------------------------------------

  GCViewMovie* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const GCViewMovie& from);
  void MergeFrom(const GCViewMovie& from);
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

  // @@protoc_insertion_point(class_scope:GCViewMovie)
 private:
  inline void set_has_flag();
  inline void clear_has_flag();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 flag_;
  friend void  protobuf_AddDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_AssignDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_ShutdownFile_NoviceGuideMessage_2eproto();

  void InitAsDefaultInstance();
  static GCViewMovie* default_instance_;
};
// -------------------------------------------------------------------

class CGViewMovieFinish : public ::google::protobuf::Message {
 public:
  CGViewMovieFinish();
  virtual ~CGViewMovieFinish();

  CGViewMovieFinish(const CGViewMovieFinish& from);

  inline CGViewMovieFinish& operator=(const CGViewMovieFinish& from) {
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
  static const CGViewMovieFinish& default_instance();

  void Swap(CGViewMovieFinish* other);

  // implements Message ----------------------------------------------

  CGViewMovieFinish* New() const;
  void CopyFrom(const ::google::protobuf::Message& from);
  void MergeFrom(const ::google::protobuf::Message& from);
  void CopyFrom(const CGViewMovieFinish& from);
  void MergeFrom(const CGViewMovieFinish& from);
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

  // @@protoc_insertion_point(class_scope:CGViewMovieFinish)
 private:
  inline void set_has_flag();
  inline void clear_has_flag();

  ::google::protobuf::UnknownFieldSet _unknown_fields_;

  ::google::protobuf::uint32 _has_bits_[1];
  mutable int _cached_size_;
  ::google::protobuf::int32 flag_;
  friend void  protobuf_AddDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_AssignDesc_NoviceGuideMessage_2eproto();
  friend void protobuf_ShutdownFile_NoviceGuideMessage_2eproto();

  void InitAsDefaultInstance();
  static CGViewMovieFinish* default_instance_;
};
// ===================================================================


// ===================================================================

// GCNoviceGuideBack

// optional int32 fragmentId = 1;
inline bool GCNoviceGuideBack::has_fragmentid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCNoviceGuideBack::set_has_fragmentid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCNoviceGuideBack::clear_has_fragmentid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCNoviceGuideBack::clear_fragmentid() {
  fragmentid_ = 0;
  clear_has_fragmentid();
}
inline ::google::protobuf::int32 GCNoviceGuideBack::fragmentid() const {
  // @@protoc_insertion_point(field_get:GCNoviceGuideBack.fragmentId)
  return fragmentid_;
}
inline void GCNoviceGuideBack::set_fragmentid(::google::protobuf::int32 value) {
  set_has_fragmentid();
  fragmentid_ = value;
  // @@protoc_insertion_point(field_set:GCNoviceGuideBack.fragmentId)
}

// optional int32 shortId = 2;
inline bool GCNoviceGuideBack::has_shortid() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void GCNoviceGuideBack::set_has_shortid() {
  _has_bits_[0] |= 0x00000002u;
}
inline void GCNoviceGuideBack::clear_has_shortid() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void GCNoviceGuideBack::clear_shortid() {
  shortid_ = 0;
  clear_has_shortid();
}
inline ::google::protobuf::int32 GCNoviceGuideBack::shortid() const {
  // @@protoc_insertion_point(field_get:GCNoviceGuideBack.shortId)
  return shortid_;
}
inline void GCNoviceGuideBack::set_shortid(::google::protobuf::int32 value) {
  set_has_shortid();
  shortid_ = value;
  // @@protoc_insertion_point(field_set:GCNoviceGuideBack.shortId)
}

// optional int32 type = 3;
inline bool GCNoviceGuideBack::has_type() const {
  return (_has_bits_[0] & 0x00000004u) != 0;
}
inline void GCNoviceGuideBack::set_has_type() {
  _has_bits_[0] |= 0x00000004u;
}
inline void GCNoviceGuideBack::clear_has_type() {
  _has_bits_[0] &= ~0x00000004u;
}
inline void GCNoviceGuideBack::clear_type() {
  type_ = 0;
  clear_has_type();
}
inline ::google::protobuf::int32 GCNoviceGuideBack::type() const {
  // @@protoc_insertion_point(field_get:GCNoviceGuideBack.type)
  return type_;
}
inline void GCNoviceGuideBack::set_type(::google::protobuf::int32 value) {
  set_has_type();
  type_ = value;
  // @@protoc_insertion_point(field_set:GCNoviceGuideBack.type)
}

// optional int32 result = 4;
inline bool GCNoviceGuideBack::has_result() const {
  return (_has_bits_[0] & 0x00000008u) != 0;
}
inline void GCNoviceGuideBack::set_has_result() {
  _has_bits_[0] |= 0x00000008u;
}
inline void GCNoviceGuideBack::clear_has_result() {
  _has_bits_[0] &= ~0x00000008u;
}
inline void GCNoviceGuideBack::clear_result() {
  result_ = 0;
  clear_has_result();
}
inline ::google::protobuf::int32 GCNoviceGuideBack::result() const {
  // @@protoc_insertion_point(field_get:GCNoviceGuideBack.result)
  return result_;
}
inline void GCNoviceGuideBack::set_result(::google::protobuf::int32 value) {
  set_has_result();
  result_ = value;
  // @@protoc_insertion_point(field_set:GCNoviceGuideBack.result)
}

// -------------------------------------------------------------------

// CGNoviceGuideFinish

// optional int32 fragmentId = 1;
inline bool CGNoviceGuideFinish::has_fragmentid() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGNoviceGuideFinish::set_has_fragmentid() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGNoviceGuideFinish::clear_has_fragmentid() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGNoviceGuideFinish::clear_fragmentid() {
  fragmentid_ = 0;
  clear_has_fragmentid();
}
inline ::google::protobuf::int32 CGNoviceGuideFinish::fragmentid() const {
  // @@protoc_insertion_point(field_get:CGNoviceGuideFinish.fragmentId)
  return fragmentid_;
}
inline void CGNoviceGuideFinish::set_fragmentid(::google::protobuf::int32 value) {
  set_has_fragmentid();
  fragmentid_ = value;
  // @@protoc_insertion_point(field_set:CGNoviceGuideFinish.fragmentId)
}

// optional int32 shortId = 2;
inline bool CGNoviceGuideFinish::has_shortid() const {
  return (_has_bits_[0] & 0x00000002u) != 0;
}
inline void CGNoviceGuideFinish::set_has_shortid() {
  _has_bits_[0] |= 0x00000002u;
}
inline void CGNoviceGuideFinish::clear_has_shortid() {
  _has_bits_[0] &= ~0x00000002u;
}
inline void CGNoviceGuideFinish::clear_shortid() {
  shortid_ = 0;
  clear_has_shortid();
}
inline ::google::protobuf::int32 CGNoviceGuideFinish::shortid() const {
  // @@protoc_insertion_point(field_get:CGNoviceGuideFinish.shortId)
  return shortid_;
}
inline void CGNoviceGuideFinish::set_shortid(::google::protobuf::int32 value) {
  set_has_shortid();
  shortid_ = value;
  // @@protoc_insertion_point(field_set:CGNoviceGuideFinish.shortId)
}

// -------------------------------------------------------------------

// GCViewMovie

// optional int32 flag = 1;
inline bool GCViewMovie::has_flag() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void GCViewMovie::set_has_flag() {
  _has_bits_[0] |= 0x00000001u;
}
inline void GCViewMovie::clear_has_flag() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void GCViewMovie::clear_flag() {
  flag_ = 0;
  clear_has_flag();
}
inline ::google::protobuf::int32 GCViewMovie::flag() const {
  // @@protoc_insertion_point(field_get:GCViewMovie.flag)
  return flag_;
}
inline void GCViewMovie::set_flag(::google::protobuf::int32 value) {
  set_has_flag();
  flag_ = value;
  // @@protoc_insertion_point(field_set:GCViewMovie.flag)
}

// -------------------------------------------------------------------

// CGViewMovieFinish

// optional int32 flag = 1;
inline bool CGViewMovieFinish::has_flag() const {
  return (_has_bits_[0] & 0x00000001u) != 0;
}
inline void CGViewMovieFinish::set_has_flag() {
  _has_bits_[0] |= 0x00000001u;
}
inline void CGViewMovieFinish::clear_has_flag() {
  _has_bits_[0] &= ~0x00000001u;
}
inline void CGViewMovieFinish::clear_flag() {
  flag_ = 0;
  clear_has_flag();
}
inline ::google::protobuf::int32 CGViewMovieFinish::flag() const {
  // @@protoc_insertion_point(field_get:CGViewMovieFinish.flag)
  return flag_;
}
inline void CGViewMovieFinish::set_flag(::google::protobuf::int32 value) {
  set_has_flag();
  flag_ = value;
  // @@protoc_insertion_point(field_set:CGViewMovieFinish.flag)
}


// @@protoc_insertion_point(namespace_scope)

#ifndef SWIG
namespace google {
namespace protobuf {


}  // namespace google
}  // namespace protobuf
#endif  // SWIG

// @@protoc_insertion_point(global_scope)

#endif  // PROTOBUF_NoviceGuideMessage_2eproto__INCLUDED
