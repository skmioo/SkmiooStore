//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGBlackChatSeting : PacketDistributed
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

public const int playerIdFieldNumber = 2;
 private bool hasPlayerId;
 private Int64 playerId_ = 0;
 public bool HasPlayerId {
 get { return hasPlayerId; }
 }
 public Int64 PlayerId {
 get { return playerId_; }
 set { SetPlayerId(value); }
 }
 public void SetPlayerId(Int64 value) { 
 hasPlayerId = true;
 playerId_ = value;
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
 if (HasPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, PlayerId);
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
 
if (HasPlayerId) {
output.WriteInt64(2, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGBlackChatSeting _inst = (CGBlackChatSeting) _base;
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
   case  16: {
 _inst.PlayerId = input.ReadInt64();
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
public class CGChatSeting : PacketDistributed
{

public const int channelsFieldNumber = 1;
 private pbc::PopsicleList<Int32> channels_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> channelsList {
 get { return pbc::Lists.AsReadOnly(channels_); }
 }
 
 public int channelsCount {
 get { return channels_.Count; }
 }
 
public Int32 GetChannels(int index) {
 return channels_[index];
 }
 public void AddChannels(Int32 value) {
 channels_.Add(value);
 }

public const int autoAudioFieldNumber = 2;
 private pbc::PopsicleList<Int32> autoAudio_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> autoAudioList {
 get { return pbc::Lists.AsReadOnly(autoAudio_); }
 }
 
 public int autoAudioCount {
 get { return autoAudio_.Count; }
 }
 
public Int32 GetAutoAudio(int index) {
 return autoAudio_[index];
 }
 public void AddAutoAudio(Int32 value) {
 autoAudio_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in channelsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * channels_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in autoAudioList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * autoAudio_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (channels_.Count > 0) {
foreach (Int32 element in channelsList) {
output.WriteInt32(1,element);
}
}

}
{
if (autoAudio_.Count > 0) {
foreach (Int32 element in autoAudioList) {
output.WriteInt32(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGChatSeting _inst = (CGChatSeting) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddChannels(input.ReadInt32());
break;
}
   case  16: {
 _inst.AddAutoAudio(input.ReadInt32());
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
public class CGSendChatMsg : PacketDistributed
{

public const int channelFieldNumber = 1;
 private bool hasChannel;
 private Int32 channel_ = 0;
 public bool HasChannel {
 get { return hasChannel; }
 }
 public Int32 Channel {
 get { return channel_; }
 set { SetChannel(value); }
 }
 public void SetChannel(Int32 value) { 
 hasChannel = true;
 channel_ = value;
 }

public const int targetIdFieldNumber = 2;
 private bool hasTargetId;
 private Int64 targetId_ = 0;
 public bool HasTargetId {
 get { return hasTargetId; }
 }
 public Int64 TargetId {
 get { return targetId_; }
 set { SetTargetId(value); }
 }
 public void SetTargetId(Int64 value) { 
 hasTargetId = true;
 targetId_ = value;
 }

public const int contentFieldNumber = 3;
 private bool hasContent;
 private string content_ = "";
 public bool HasContent {
 get { return hasContent; }
 }
 public string Content {
 get { return content_; }
 set { SetContent(value); }
 }
 public void SetContent(string value) { 
 hasContent = true;
 content_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChannel) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Channel);
}
 if (HasTargetId) {
size += pb::CodedOutputStream.ComputeInt64Size(2, TargetId);
}
 if (HasContent) {
size += pb::CodedOutputStream.ComputeStringSize(3, Content);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChannel) {
output.WriteInt32(1, Channel);
}
 
if (HasTargetId) {
output.WriteInt64(2, TargetId);
}
 
if (HasContent) {
output.WriteString(3, Content);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSendChatMsg _inst = (CGSendChatMsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Channel = input.ReadInt32();
break;
}
   case  16: {
 _inst.TargetId = input.ReadInt64();
break;
}
   case  26: {
 _inst.Content = input.ReadString();
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
public class ChatInfo : PacketDistributed
{

public const int sendTimeFieldNumber = 1;
 private bool hasSendTime;
 private Int64 sendTime_ = 0;
 public bool HasSendTime {
 get { return hasSendTime; }
 }
 public Int64 SendTime {
 get { return sendTime_; }
 set { SetSendTime(value); }
 }
 public void SetSendTime(Int64 value) { 
 hasSendTime = true;
 sendTime_ = value;
 }

public const int contentFieldNumber = 2;
 private bool hasContent;
 private string content_ = "";
 public bool HasContent {
 get { return hasContent; }
 }
 public string Content {
 get { return content_; }
 set { SetContent(value); }
 }
 public void SetContent(string value) { 
 hasContent = true;
 content_ = value;
 }

public const int hornFieldNumber = 4;
 private bool hasHorn;
 private Int32 horn_ = 0;
 public bool HasHorn {
 get { return hasHorn; }
 }
 public Int32 Horn {
 get { return horn_; }
 set { SetHorn(value); }
 }
 public void SetHorn(Int32 value) { 
 hasHorn = true;
 horn_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasSendTime) {
size += pb::CodedOutputStream.ComputeInt64Size(1, SendTime);
}
 if (HasContent) {
size += pb::CodedOutputStream.ComputeStringSize(2, Content);
}
 if (HasHorn) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Horn);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasSendTime) {
output.WriteInt64(1, SendTime);
}
 
if (HasContent) {
output.WriteString(2, Content);
}
 
if (HasHorn) {
output.WriteInt32(4, Horn);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 ChatInfo _inst = (ChatInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.SendTime = input.ReadInt64();
break;
}
   case  18: {
 _inst.Content = input.ReadString();
break;
}
   case  32: {
 _inst.Horn = input.ReadInt32();
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
public class GCBlackChatSeting : PacketDistributed
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

public const int playerIdsFieldNumber = 2;
 private pbc::PopsicleList<Int64> playerIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> playerIdsList {
 get { return pbc::Lists.AsReadOnly(playerIds_); }
 }
 
 public int playerIdsCount {
 get { return playerIds_.Count; }
 }
 
public Int64 GetPlayerIds(int index) {
 return playerIds_[index];
 }
 public void AddPlayerIds(Int64 value) {
 playerIds_.Add(value);
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
int dataSize = 0;
foreach (Int64 element in playerIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * playerIds_.Count;
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
{
if (playerIds_.Count > 0) {
foreach (Int64 element in playerIdsList) {
output.WriteInt64(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBlackChatSeting _inst = (GCBlackChatSeting) _base;
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
   case  16: {
 _inst.AddPlayerIds(input.ReadInt64());
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
public class GCChatSeting : PacketDistributed
{

public const int channelsFieldNumber = 1;
 private pbc::PopsicleList<Int32> channels_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> channelsList {
 get { return pbc::Lists.AsReadOnly(channels_); }
 }
 
 public int channelsCount {
 get { return channels_.Count; }
 }
 
public Int32 GetChannels(int index) {
 return channels_[index];
 }
 public void AddChannels(Int32 value) {
 channels_.Add(value);
 }

public const int autoAudioFieldNumber = 2;
 private pbc::PopsicleList<Int32> autoAudio_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> autoAudioList {
 get { return pbc::Lists.AsReadOnly(autoAudio_); }
 }
 
 public int autoAudioCount {
 get { return autoAudio_.Count; }
 }
 
public Int32 GetAutoAudio(int index) {
 return autoAudio_[index];
 }
 public void AddAutoAudio(Int32 value) {
 autoAudio_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in channelsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * channels_.Count;
}
{
int dataSize = 0;
foreach (Int32 element in autoAudioList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * autoAudio_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (channels_.Count > 0) {
foreach (Int32 element in channelsList) {
output.WriteInt32(1,element);
}
}

}
{
if (autoAudio_.Count > 0) {
foreach (Int32 element in autoAudioList) {
output.WriteInt32(2,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCChatSeting _inst = (GCChatSeting) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddChannels(input.ReadInt32());
break;
}
   case  16: {
 _inst.AddAutoAudio(input.ReadInt32());
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
public class GCPushChatMsg : PacketDistributed
{

public const int channelFieldNumber = 1;
 private bool hasChannel;
 private Int32 channel_ = 0;
 public bool HasChannel {
 get { return hasChannel; }
 }
 public Int32 Channel {
 get { return channel_; }
 set { SetChannel(value); }
 }
 public void SetChannel(Int32 value) { 
 hasChannel = true;
 channel_ = value;
 }

public const int chatInfosFieldNumber = 2;
 private pbc::PopsicleList<ChatInfo> chatInfos_ = new pbc::PopsicleList<ChatInfo>();
 public scg::IList<ChatInfo> chatInfosList {
 get { return pbc::Lists.AsReadOnly(chatInfos_); }
 }
 
 public int chatInfosCount {
 get { return chatInfos_.Count; }
 }
 
public ChatInfo GetChatInfos(int index) {
 return chatInfos_[index];
 }
 public void AddChatInfos(ChatInfo value) {
 chatInfos_.Add(value);
 }

public const int targetIdFieldNumber = 3;
 private bool hasTargetId;
 private Int64 targetId_ = 0;
 public bool HasTargetId {
 get { return hasTargetId; }
 }
 public Int64 TargetId {
 get { return targetId_; }
 set { SetTargetId(value); }
 }
 public void SetTargetId(Int64 value) { 
 hasTargetId = true;
 targetId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasChannel) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Channel);
}
{
foreach (ChatInfo element in chatInfosList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasTargetId) {
size += pb::CodedOutputStream.ComputeInt64Size(3, TargetId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasChannel) {
output.WriteInt32(1, Channel);
}

do{
foreach (ChatInfo element in chatInfosList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasTargetId) {
output.WriteInt64(3, TargetId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushChatMsg _inst = (GCPushChatMsg) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Channel = input.ReadInt32();
break;
}
    case  18: {
ChatInfo subBuilder =  new ChatInfo();
input.ReadMessage(subBuilder);
_inst.AddChatInfos(subBuilder);
break;
}
   case  24: {
 _inst.TargetId = input.ReadInt64();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (ChatInfo element in chatInfosList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
