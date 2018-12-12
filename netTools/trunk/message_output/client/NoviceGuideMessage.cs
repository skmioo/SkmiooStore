//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGNoviceGuideFinish : PacketDistributed
{

public const int fragmentIdFieldNumber = 1;
 private bool hasFragmentId;
 private Int32 fragmentId_ = 0;
 public bool HasFragmentId {
 get { return hasFragmentId; }
 }
 public Int32 FragmentId {
 get { return fragmentId_; }
 set { SetFragmentId(value); }
 }
 public void SetFragmentId(Int32 value) { 
 hasFragmentId = true;
 fragmentId_ = value;
 }

public const int shortIdFieldNumber = 2;
 private bool hasShortId;
 private Int32 shortId_ = 0;
 public bool HasShortId {
 get { return hasShortId; }
 }
 public Int32 ShortId {
 get { return shortId_; }
 set { SetShortId(value); }
 }
 public void SetShortId(Int32 value) { 
 hasShortId = true;
 shortId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFragmentId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FragmentId);
}
 if (HasShortId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ShortId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFragmentId) {
output.WriteInt32(1, FragmentId);
}
 
if (HasShortId) {
output.WriteInt32(2, ShortId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGNoviceGuideFinish _inst = (CGNoviceGuideFinish) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FragmentId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ShortId = input.ReadInt32();
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
public class CGViewMovieFinish : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGViewMovieFinish _inst = (CGViewMovieFinish) _base;
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
public class GCNoviceGuideBack : PacketDistributed
{

public const int fragmentIdFieldNumber = 1;
 private bool hasFragmentId;
 private Int32 fragmentId_ = 0;
 public bool HasFragmentId {
 get { return hasFragmentId; }
 }
 public Int32 FragmentId {
 get { return fragmentId_; }
 set { SetFragmentId(value); }
 }
 public void SetFragmentId(Int32 value) { 
 hasFragmentId = true;
 fragmentId_ = value;
 }

public const int shortIdFieldNumber = 2;
 private bool hasShortId;
 private Int32 shortId_ = 0;
 public bool HasShortId {
 get { return hasShortId; }
 }
 public Int32 ShortId {
 get { return shortId_; }
 set { SetShortId(value); }
 }
 public void SetShortId(Int32 value) { 
 hasShortId = true;
 shortId_ = value;
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

public const int resultFieldNumber = 4;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFragmentId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, FragmentId);
}
 if (HasShortId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ShortId);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasFragmentId) {
output.WriteInt32(1, FragmentId);
}
 
if (HasShortId) {
output.WriteInt32(2, ShortId);
}
 
if (HasType) {
output.WriteInt32(3, Type);
}
 
if (HasResult) {
output.WriteInt32(4, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCNoviceGuideBack _inst = (GCNoviceGuideBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.FragmentId = input.ReadInt32();
break;
}
   case  16: {
 _inst.ShortId = input.ReadInt32();
break;
}
   case  24: {
 _inst.Type = input.ReadInt32();
break;
}
   case  32: {
 _inst.Result = input.ReadInt32();
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
public class GCViewMovie : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasFlag) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Flag);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCViewMovie _inst = (GCViewMovie) _base;
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
