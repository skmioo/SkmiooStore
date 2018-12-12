//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGGM4ClientMsg : PacketDistributed
{

public const int cmdFieldNumber = 1;
 private bool hasCmd;
 private string cmd_ = "";
 public bool HasCmd {
 get { return hasCmd; }
 }
 public string Cmd {
 get { return cmd_; }
 set { SetCmd(value); }
 }
 public void SetCmd(string value) { 
 hasCmd = true;
 cmd_ = value;
 }

public const int paramsFieldNumber = 2;
 private bool hasParams;
 private string params_ = "";
 public bool HasParams {
 get { return hasParams; }
 }
 public string Params {
 get { return params_; }
 set { SetParams(value); }
 }
 public void SetParams(string value) { 
 hasParams = true;
 params_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasCmd) {
size += pb::CodedOutputStream.ComputeStringSize(1, Cmd);
}
 if (HasParams) {
size += pb::CodedOutputStream.ComputeStringSize(2, Params);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasCmd) {
output.WriteString(1, Cmd);
}
 
if (HasParams) {
output.WriteString(2, Params);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGM4ClientMsg _inst = (CGGM4ClientMsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Cmd = input.ReadString();
break;
}
   case  18: {
 _inst.Params = input.ReadString();
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
public class Entry4GM : PacketDistributed
{

public const int keyFieldNumber = 1;
 private bool hasKey;
 private string key_ = "";
 public bool HasKey {
 get { return hasKey; }
 }
 public string Key {
 get { return key_; }
 set { SetKey(value); }
 }
 public void SetKey(string value) { 
 hasKey = true;
 key_ = value;
 }

public const int valueFieldNumber = 2;
 private bool hasValue;
 private string value_ = "";
 public bool HasValue {
 get { return hasValue; }
 }
 public string Value {
 get { return value_; }
 set { SetValue(value); }
 }
 public void SetValue(string value) { 
 hasValue = true;
 value_ = value;
 }

public const int typeFieldNumber = 3;
 private bool hasType;
 private string type_ = "";
 public bool HasType {
 get { return hasType; }
 }
 public string Type {
 get { return type_; }
 set { SetType(value); }
 }
 public void SetType(string value) { 
 hasType = true;
 type_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasKey) {
size += pb::CodedOutputStream.ComputeStringSize(1, Key);
}
 if (HasValue) {
size += pb::CodedOutputStream.ComputeStringSize(2, Value);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeStringSize(3, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasKey) {
output.WriteString(1, Key);
}
 
if (HasValue) {
output.WriteString(2, Value);
}
 
if (HasType) {
output.WriteString(3, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 Entry4GM _inst = (Entry4GM) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.Key = input.ReadString();
break;
}
   case  18: {
 _inst.Value = input.ReadString();
break;
}
   case  26: {
 _inst.Type = input.ReadString();
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
