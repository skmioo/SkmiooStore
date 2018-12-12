//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGCapeLevelUp : PacketDistributed
{

public const int autoReplaceFieldNumber = 1;
 private bool hasAutoReplace;
 private Int32 autoReplace_ = 0;
 public bool HasAutoReplace {
 get { return hasAutoReplace; }
 }
 public Int32 AutoReplace {
 get { return autoReplace_; }
 set { SetAutoReplace(value); }
 }
 public void SetAutoReplace(Int32 value) { 
 hasAutoReplace = true;
 autoReplace_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoReplace) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoReplace);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoReplace) {
output.WriteInt32(1, AutoReplace);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCapeLevelUp _inst = (CGCapeLevelUp) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoReplace = input.ReadInt32();
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
public class CapeInfo : PacketDistributed
{

public const int capeLevelFieldNumber = 1;
 private bool hasCapeLevel;
 private Int32 capeLevel_ = 0;
 public bool HasCapeLevel {
 get { return hasCapeLevel; }
 }
 public Int32 CapeLevel {
 get { return capeLevel_; }
 set { SetCapeLevel(value); }
 }
 public void SetCapeLevel(Int32 value) { 
 hasCapeLevel = true;
 capeLevel_ = value;
 }

public const int luckValueFieldNumber = 2;
 private bool hasLuckValue;
 private Int32 luckValue_ = 0;
 public bool HasLuckValue {
 get { return hasLuckValue; }
 }
 public Int32 LuckValue {
 get { return luckValue_; }
 set { SetLuckValue(value); }
 }
 public void SetLuckValue(Int32 value) { 
 hasLuckValue = true;
 luckValue_ = value;
 }

public const int maxLuckFieldNumber = 3;
 private bool hasMaxLuck;
 private Int32 maxLuck_ = 0;
 public bool HasMaxLuck {
 get { return hasMaxLuck; }
 }
 public Int32 MaxLuck {
 get { return maxLuck_; }
 set { SetMaxLuck(value); }
 }
 public void SetMaxLuck(Int32 value) { 
 hasMaxLuck = true;
 maxLuck_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCapeLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(1, CapeLevel);
}
 if (HasLuckValue) {
size += pb::CodedOutputStream.ComputeInt32Size(2, LuckValue);
}
 if (HasMaxLuck) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MaxLuck);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCapeLevel) {
output.WriteInt32(1, CapeLevel);
}
 
if (HasLuckValue) {
output.WriteInt32(2, LuckValue);
}
 
if (HasMaxLuck) {
output.WriteInt32(3, MaxLuck);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CapeInfo _inst = (CapeInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.CapeLevel = input.ReadInt32();
break;
}
   case  16: {
 _inst.LuckValue = input.ReadInt32();
break;
}
   case  24: {
 _inst.MaxLuck = input.ReadInt32();
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
public class GCCapeLevelUpResult : PacketDistributed
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

public const int capeInfoFieldNumber = 2;
 private bool hasCapeInfo;
 private CapeInfo capeInfo_ =  new CapeInfo();
 public bool HasCapeInfo {
 get { return hasCapeInfo; }
 }
 public CapeInfo CapeInfo {
 get { return capeInfo_; }
 set { SetCapeInfo(value); }
 }
 public void SetCapeInfo(CapeInfo value) { 
 hasCapeInfo = true;
 capeInfo_ = value;
 }

public const int operateFieldNumber = 3;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
}
{
int subsize = CapeInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasOperate) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Operate);
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
{
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)CapeInfo.SerializedSize());
CapeInfo.WriteTo(output);

}
 
if (HasOperate) {
output.WriteInt32(3, Operate);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCapeLevelUpResult _inst = (GCCapeLevelUpResult) _base;
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
    case  18: {
CapeInfo subBuilder =  new CapeInfo();
 input.ReadMessage(subBuilder);
_inst.CapeInfo = subBuilder;
break;
}
   case  24: {
 _inst.Operate = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasCapeInfo) {
if (!CapeInfo.IsInitialized()) return false;
}
 return true;
 }

	}


}
