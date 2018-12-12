//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBuyFashionData : PacketDistributed
{

public const int tableidFieldNumber = 1;
 private bool hasTableid;
 private Int32 tableid_ = 0;
 public bool HasTableid {
 get { return hasTableid; }
 }
 public Int32 Tableid {
 get { return tableid_; }
 set { SetTableid(value); }
 }
 public void SetTableid(Int32 value) { 
 hasTableid = true;
 tableid_ = value;
 }

public const int timetypeFieldNumber = 2;
 private bool hasTimetype;
 private Int32 timetype_ = 0;
 public bool HasTimetype {
 get { return hasTimetype; }
 }
 public Int32 Timetype {
 get { return timetype_; }
 set { SetTimetype(value); }
 }
 public void SetTimetype(Int32 value) { 
 hasTimetype = true;
 timetype_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTableid) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Tableid);
}
 if (HasTimetype) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Timetype);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTableid) {
output.WriteInt32(1, Tableid);
}
 
if (HasTimetype) {
output.WriteInt32(2, Timetype);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBuyFashionData _inst = (CGBuyFashionData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Tableid = input.ReadInt32();
break;
}
   case  16: {
 _inst.Timetype = input.ReadInt32();
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
public class CGMakeFashionData : PacketDistributed
{

public const int serveridFieldNumber = 1;
 private bool hasServerid;
 private Int64 serverid_ = 0;
 public bool HasServerid {
 get { return hasServerid; }
 }
 public Int64 Serverid {
 get { return serverid_; }
 set { SetServerid(value); }
 }
 public void SetServerid(Int64 value) { 
 hasServerid = true;
 serverid_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasServerid) {
size += pb::CodedOutputStream.ComputeInt64Size(1, Serverid);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasServerid) {
output.WriteInt64(1, Serverid);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGMakeFashionData _inst = (CGMakeFashionData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Serverid = input.ReadInt64();
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
public class CGSwitchFashionData : PacketDistributed
{

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSwitchFashionData _inst = (CGSwitchFashionData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
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
public class GCBackFashionData : PacketDistributed
{

public const int playerfashionFieldNumber = 1;
 private pbc::PopsicleList<PlayerFashion> playerfashion_ = new pbc::PopsicleList<PlayerFashion>();
 public scg::IList<PlayerFashion> playerfashionList {
 get { return pbc::Lists.AsReadOnly(playerfashion_); }
 }
 
 public int playerfashionCount {
 get { return playerfashion_.Count; }
 }
 
public PlayerFashion GetPlayerfashion(int index) {
 return playerfashion_[index];
 }
 public void AddPlayerfashion(PlayerFashion value) {
 playerfashion_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (PlayerFashion element in playerfashionList) {
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
foreach (PlayerFashion element in playerfashionList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackFashionData _inst = (GCBackFashionData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
PlayerFashion subBuilder =  new PlayerFashion();
input.ReadMessage(subBuilder);
_inst.AddPlayerfashion(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PlayerFashion element in playerfashionList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCBuyFashionDataBack : PacketDistributed
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

public const int playerfashionFieldNumber = 2;
 private pbc::PopsicleList<PlayerFashion> playerfashion_ = new pbc::PopsicleList<PlayerFashion>();
 public scg::IList<PlayerFashion> playerfashionList {
 get { return pbc::Lists.AsReadOnly(playerfashion_); }
 }
 
 public int playerfashionCount {
 get { return playerfashion_.Count; }
 }
 
public PlayerFashion GetPlayerfashion(int index) {
 return playerfashion_[index];
 }
 public void AddPlayerfashion(PlayerFashion value) {
 playerfashion_.Add(value);
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
{
foreach (PlayerFashion element in playerfashionList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
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

do{
foreach (PlayerFashion element in playerfashionList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBuyFashionDataBack _inst = (GCBuyFashionDataBack) _base;
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
    case  18: {
PlayerFashion subBuilder =  new PlayerFashion();
input.ReadMessage(subBuilder);
_inst.AddPlayerfashion(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PlayerFashion element in playerfashionList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCCreateCharacterInfo : PacketDistributed
{

public const int characterInfoFieldNumber = 1;
 private bool hasCharacterInfo;
 private CharacterInfo characterInfo_ =  new CharacterInfo();
 public bool HasCharacterInfo {
 get { return hasCharacterInfo; }
 }
 public CharacterInfo CharacterInfo {
 get { return characterInfo_; }
 set { SetCharacterInfo(value); }
 }
 public void SetCharacterInfo(CharacterInfo value) { 
 hasCharacterInfo = true;
 characterInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = CharacterInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)CharacterInfo.SerializedSize());
CharacterInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCreateCharacterInfo _inst = (GCCreateCharacterInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
CharacterInfo subBuilder =  new CharacterInfo();
 input.ReadMessage(subBuilder);
_inst.CharacterInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasCharacterInfo) {
if (!CharacterInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCMakeFashionDataBack : PacketDistributed
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

public const int playerfashionFieldNumber = 2;
 private pbc::PopsicleList<PlayerFashion> playerfashion_ = new pbc::PopsicleList<PlayerFashion>();
 public scg::IList<PlayerFashion> playerfashionList {
 get { return pbc::Lists.AsReadOnly(playerfashion_); }
 }
 
 public int playerfashionCount {
 get { return playerfashion_.Count; }
 }
 
public PlayerFashion GetPlayerfashion(int index) {
 return playerfashion_[index];
 }
 public void AddPlayerfashion(PlayerFashion value) {
 playerfashion_.Add(value);
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
{
foreach (PlayerFashion element in playerfashionList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
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

do{
foreach (PlayerFashion element in playerfashionList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMakeFashionDataBack _inst = (GCMakeFashionDataBack) _base;
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
    case  18: {
PlayerFashion subBuilder =  new PlayerFashion();
input.ReadMessage(subBuilder);
_inst.AddPlayerfashion(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (PlayerFashion element in playerfashionList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSwitchFashionDataBack : PacketDistributed
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
 GCSwitchFashionDataBack _inst = (GCSwitchFashionDataBack) _base;
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
