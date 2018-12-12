//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGetResource : PacketDistributed
{

public const int getTypeFieldNumber = 1;
 private bool hasGetType;
 private Int32 getType_ = 0;
 public bool HasGetType {
 get { return hasGetType; }
 }
 public Int32 GetType {
 get { return getType_; }
 set { SetGetType(value); }
 }
 public void SetGetType(Int32 value) { 
 hasGetType = true;
 getType_ = value;
 }

public const int consumeTypeFieldNumber = 2;
 private bool hasConsumeType;
 private Int32 consumeType_ = 0;
 public bool HasConsumeType {
 get { return hasConsumeType; }
 }
 public Int32 ConsumeType {
 get { return consumeType_; }
 set { SetConsumeType(value); }
 }
 public void SetConsumeType(Int32 value) { 
 hasConsumeType = true;
 consumeType_ = value;
 }

public const int resourceIdFieldNumber = 3;
 private bool hasResourceId;
 private Int32 resourceId_ = 0;
 public bool HasResourceId {
 get { return hasResourceId; }
 }
 public Int32 ResourceId {
 get { return resourceId_; }
 set { SetResourceId(value); }
 }
 public void SetResourceId(Int32 value) { 
 hasResourceId = true;
 resourceId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasGetType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, GetType);
}
 if (HasConsumeType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, ConsumeType);
}
 if (HasResourceId) {
size += pb::CodedOutputStream.ComputeInt32Size(3, ResourceId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasGetType) {
output.WriteInt32(1, GetType);
}
 
if (HasConsumeType) {
output.WriteInt32(2, ConsumeType);
}
 
if (HasResourceId) {
output.WriteInt32(3, ResourceId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetResource _inst = (CGGetResource) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.GetType = input.ReadInt32();
break;
}
   case  16: {
 _inst.ConsumeType = input.ReadInt32();
break;
}
   case  24: {
 _inst.ResourceId = input.ReadInt32();
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
public class GCGetResourceBack : PacketDistributed
{

public const int resourceInfoFieldNumber = 1;
 private pbc::PopsicleList<ResourceInfo> resourceInfo_ = new pbc::PopsicleList<ResourceInfo>();
 public scg::IList<ResourceInfo> resourceInfoList {
 get { return pbc::Lists.AsReadOnly(resourceInfo_); }
 }
 
 public int resourceInfoCount {
 get { return resourceInfo_.Count; }
 }
 
public ResourceInfo GetResourceInfo(int index) {
 return resourceInfo_[index];
 }
 public void AddResourceInfo(ResourceInfo value) {
 resourceInfo_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ResourceInfo element in resourceInfoList) {
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
foreach (ResourceInfo element in resourceInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetResourceBack _inst = (GCGetResourceBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ResourceInfo subBuilder =  new ResourceInfo();
input.ReadMessage(subBuilder);
_inst.AddResourceInfo(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ResourceInfo element in resourceInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCRequestResourceInfoBack : PacketDistributed
{

public const int resourceInfoFieldNumber = 1;
 private pbc::PopsicleList<ResourceInfo> resourceInfo_ = new pbc::PopsicleList<ResourceInfo>();
 public scg::IList<ResourceInfo> resourceInfoList {
 get { return pbc::Lists.AsReadOnly(resourceInfo_); }
 }
 
 public int resourceInfoCount {
 get { return resourceInfo_.Count; }
 }
 
public ResourceInfo GetResourceInfo(int index) {
 return resourceInfo_[index];
 }
 public void AddResourceInfo(ResourceInfo value) {
 resourceInfo_.Add(value);
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

public const int loginLvFieldNumber = 3;
 private bool hasLoginLv;
 private Int32 loginLv_ = 0;
 public bool HasLoginLv {
 get { return hasLoginLv; }
 }
 public Int32 LoginLv {
 get { return loginLv_; }
 set { SetLoginLv(value); }
 }
 public void SetLoginLv(Int32 value) { 
 hasLoginLv = true;
 loginLv_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (ResourceInfo element in resourceInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 if (HasLoginLv) {
size += pb::CodedOutputStream.ComputeInt32Size(3, LoginLv);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (ResourceInfo element in resourceInfoList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasType) {
output.WriteInt32(2, Type);
}
 
if (HasLoginLv) {
output.WriteInt32(3, LoginLv);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRequestResourceInfoBack _inst = (GCRequestResourceInfoBack) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
ResourceInfo subBuilder =  new ResourceInfo();
input.ReadMessage(subBuilder);
_inst.AddResourceInfo(subBuilder);
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
break;
}
   case  24: {
 _inst.LoginLv = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ResourceInfo element in resourceInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class ResourceInfo : PacketDistributed
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

public const int backNumFieldNumber = 2;
 private bool hasBackNum;
 private Int32 backNum_ = 0;
 public bool HasBackNum {
 get { return hasBackNum; }
 }
 public Int32 BackNum {
 get { return backNum_; }
 set { SetBackNum(value); }
 }
 public void SetBackNum(Int32 value) { 
 hasBackNum = true;
 backNum_ = value;
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
 if (HasBackNum) {
size += pb::CodedOutputStream.ComputeInt32Size(2, BackNum);
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
 
if (HasBackNum) {
output.WriteInt32(2, BackNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ResourceInfo _inst = (ResourceInfo) _base;
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
 _inst.BackNum = input.ReadInt32();
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
