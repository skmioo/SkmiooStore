//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGDelMail : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private pbc::PopsicleList<Int64> mailID_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> mailIDList {
 get { return pbc::Lists.AsReadOnly(mailID_); }
 }
 
 public int mailIDCount {
 get { return mailID_.Count; }
 }
 
public Int64 GetMailID(int index) {
 return mailID_[index];
 }
 public void AddMailID(Int64 value) {
 mailID_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in mailIDList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * mailID_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (mailID_.Count > 0) {
foreach (Int64 element in mailIDList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGDelMail _inst = (CGDelMail) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddMailID(input.ReadInt64());
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
public class CGGetItemInMail : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private pbc::PopsicleList<Int64> mailID_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> mailIDList {
 get { return pbc::Lists.AsReadOnly(mailID_); }
 }
 
 public int mailIDCount {
 get { return mailID_.Count; }
 }
 
public Int64 GetMailID(int index) {
 return mailID_[index];
 }
 public void AddMailID(Int64 value) {
 mailID_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in mailIDList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * mailID_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (mailID_.Count > 0) {
foreach (Int64 element in mailIDList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetItemInMail _inst = (CGGetItemInMail) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddMailID(input.ReadInt64());
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
public class CGGetMailList : PacketDistributed
{

public const int playerIDFieldNumber = 1;
 private bool hasPlayerID;
 private Int64 playerID_ = 0;
 public bool HasPlayerID {
 get { return hasPlayerID; }
 }
 public Int64 PlayerID {
 get { return playerID_; }
 set { SetPlayerID(value); }
 }
 public void SetPlayerID(Int64 value) { 
 hasPlayerID = true;
 playerID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, PlayerID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerID) {
output.WriteInt64(1, PlayerID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGGetMailList _inst = (CGGetMailList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.PlayerID = input.ReadInt64();
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
public class CGReadMail : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private bool hasMailID;
 private Int64 mailID_ = 0;
 public bool HasMailID {
 get { return hasMailID; }
 }
 public Int64 MailID {
 get { return mailID_; }
 set { SetMailID(value); }
 }
 public void SetMailID(Int64 value) { 
 hasMailID = true;
 mailID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMailID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, MailID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMailID) {
output.WriteInt64(1, MailID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGReadMail _inst = (CGReadMail) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MailID = input.ReadInt64();
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
public class CGSendMail2Player : PacketDistributed
{

public const int mailFieldNumber = 1;
 private bool hasMail;
 private MailInfo mail_ =  new MailInfo();
 public bool HasMail {
 get { return hasMail; }
 }
 public MailInfo Mail {
 get { return mail_; }
 set { SetMail(value); }
 }
 public void SetMail(MailInfo value) { 
 hasMail = true;
 mail_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Mail.SerializedSize();	
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
output.WriteRawVarint32((uint)Mail.SerializedSize());
Mail.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSendMail2Player _inst = (CGSendMail2Player) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
MailInfo subBuilder =  new MailInfo();
 input.ReadMessage(subBuilder);
_inst.Mail = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasMail) {
if (!Mail.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCDelMail : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private pbc::PopsicleList<Int64> mailID_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> mailIDList {
 get { return pbc::Lists.AsReadOnly(mailID_); }
 }
 
 public int mailIDCount {
 get { return mailID_.Count; }
 }
 
public Int64 GetMailID(int index) {
 return mailID_[index];
 }
 public void AddMailID(Int64 value) {
 mailID_.Add(value);
 }

public const int resultFieldNumber = 2;
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
 {
int dataSize = 0;
foreach (Int64 element in mailIDList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * mailID_.Count;
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (mailID_.Count > 0) {
foreach (Int64 element in mailIDList) {
output.WriteInt64(1,element);
}
}

}
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCDelMail _inst = (GCDelMail) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddMailID(input.ReadInt64());
break;
}
   case  16: {
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
public class GCGetItemInMail : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private pbc::PopsicleList<Int64> mailID_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> mailIDList {
 get { return pbc::Lists.AsReadOnly(mailID_); }
 }
 
 public int mailIDCount {
 get { return mailID_.Count; }
 }
 
public Int64 GetMailID(int index) {
 return mailID_[index];
 }
 public void AddMailID(Int64 value) {
 mailID_.Add(value);
 }

public const int resultFieldNumber = 2;
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
 {
int dataSize = 0;
foreach (Int64 element in mailIDList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * mailID_.Count;
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (mailID_.Count > 0) {
foreach (Int64 element in mailIDList) {
output.WriteInt64(1,element);
}
}

}
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetItemInMail _inst = (GCGetItemInMail) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddMailID(input.ReadInt64());
break;
}
   case  16: {
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
public class GCGetMailList : PacketDistributed
{

public const int mailsFieldNumber = 1;
 private pbc::PopsicleList<MailInfo> mails_ = new pbc::PopsicleList<MailInfo>();
 public scg::IList<MailInfo> mailsList {
 get { return pbc::Lists.AsReadOnly(mails_); }
 }
 
 public int mailsCount {
 get { return mails_.Count; }
 }
 
public MailInfo GetMails(int index) {
 return mails_[index];
 }
 public void AddMails(MailInfo value) {
 mails_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (MailInfo element in mailsList) {
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
foreach (MailInfo element in mailsList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCGetMailList _inst = (GCGetMailList) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
MailInfo subBuilder =  new MailInfo();
input.ReadMessage(subBuilder);
_inst.AddMails(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (MailInfo element in mailsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCReadMail : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private bool hasMailID;
 private Int64 mailID_ = 0;
 public bool HasMailID {
 get { return hasMailID; }
 }
 public Int64 MailID {
 get { return mailID_; }
 set { SetMailID(value); }
 }
 public void SetMailID(Int64 value) { 
 hasMailID = true;
 mailID_ = value;
 }

public const int resultFieldNumber = 2;
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
  if (HasMailID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, MailID);
}
 if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Result);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMailID) {
output.WriteInt64(1, MailID);
}
 
if (HasResult) {
output.WriteInt32(2, Result);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCReadMail _inst = (GCReadMail) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MailID = input.ReadInt64();
break;
}
   case  16: {
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
public class GCSendMail2Player : PacketDistributed
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasResult) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Result);
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
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendMail2Player _inst = (GCSendMail2Player) _base;
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
public class GCSendMailStatus : PacketDistributed
{

public const int offReadFieldNumber = 1;
 private bool hasOffRead;
 private Int32 offRead_ = 0;
 public bool HasOffRead {
 get { return hasOffRead; }
 }
 public Int32 OffRead {
 get { return offRead_; }
 set { SetOffRead(value); }
 }
 public void SetOffRead(Int32 value) { 
 hasOffRead = true;
 offRead_ = value;
 }

public const int totalFieldNumber = 2;
 private bool hasTotal;
 private Int32 total_ = 0;
 public bool HasTotal {
 get { return hasTotal; }
 }
 public Int32 Total {
 get { return total_; }
 set { SetTotal(value); }
 }
 public void SetTotal(Int32 value) { 
 hasTotal = true;
 total_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOffRead) {
size += pb::CodedOutputStream.ComputeInt32Size(1, OffRead);
}
 if (HasTotal) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Total);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOffRead) {
output.WriteInt32(1, OffRead);
}
 
if (HasTotal) {
output.WriteInt32(2, Total);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendMailStatus _inst = (GCSendMailStatus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OffRead = input.ReadInt32();
break;
}
   case  16: {
 _inst.Total = input.ReadInt32();
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
public class GCSysSendMail2Player : PacketDistributed
{

public const int mailFieldNumber = 1;
 private bool hasMail;
 private MailInfo mail_ =  new MailInfo();
 public bool HasMail {
 get { return hasMail; }
 }
 public MailInfo Mail {
 get { return mail_; }
 set { SetMail(value); }
 }
 public void SetMail(MailInfo value) { 
 hasMail = true;
 mail_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Mail.SerializedSize();	
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
output.WriteRawVarint32((uint)Mail.SerializedSize());
Mail.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSysSendMail2Player _inst = (GCSysSendMail2Player) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
MailInfo subBuilder =  new MailInfo();
 input.ReadMessage(subBuilder);
_inst.Mail = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasMail) {
if (!Mail.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class MailInfo : PacketDistributed
{

public const int mailIDFieldNumber = 1;
 private bool hasMailID;
 private Int64 mailID_ = 0;
 public bool HasMailID {
 get { return hasMailID; }
 }
 public Int64 MailID {
 get { return mailID_; }
 set { SetMailID(value); }
 }
 public void SetMailID(Int64 value) { 
 hasMailID = true;
 mailID_ = value;
 }

public const int receivePlayerIDFieldNumber = 2;
 private bool hasReceivePlayerID;
 private Int64 receivePlayerID_ = 0;
 public bool HasReceivePlayerID {
 get { return hasReceivePlayerID; }
 }
 public Int64 ReceivePlayerID {
 get { return receivePlayerID_; }
 set { SetReceivePlayerID(value); }
 }
 public void SetReceivePlayerID(Int64 value) { 
 hasReceivePlayerID = true;
 receivePlayerID_ = value;
 }

public const int sendTypeFieldNumber = 3;
 private bool hasSendType;
 private Int32 sendType_ = 0;
 public bool HasSendType {
 get { return hasSendType; }
 }
 public Int32 SendType {
 get { return sendType_; }
 set { SetSendType(value); }
 }
 public void SetSendType(Int32 value) { 
 hasSendType = true;
 sendType_ = value;
 }

public const int playerIDFieldNumber = 4;
 private bool hasPlayerID;
 private Int64 playerID_ = 0;
 public bool HasPlayerID {
 get { return hasPlayerID; }
 }
 public Int64 PlayerID {
 get { return playerID_; }
 set { SetPlayerID(value); }
 }
 public void SetPlayerID(Int64 value) { 
 hasPlayerID = true;
 playerID_ = value;
 }

public const int sendNameFieldNumber = 5;
 private bool hasSendName;
 private string sendName_ = "";
 public bool HasSendName {
 get { return hasSendName; }
 }
 public string SendName {
 get { return sendName_; }
 set { SetSendName(value); }
 }
 public void SetSendName(string value) { 
 hasSendName = true;
 sendName_ = value;
 }

public const int contentFieldNumber = 6;
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

public const int itemsFieldNumber = 7;
 private pbc::PopsicleList<BackpackItem> items_ = new pbc::PopsicleList<BackpackItem>();
 public scg::IList<BackpackItem> itemsList {
 get { return pbc::Lists.AsReadOnly(items_); }
 }
 
 public int itemsCount {
 get { return items_.Count; }
 }
 
public BackpackItem GetItems(int index) {
 return items_[index];
 }
 public void AddItems(BackpackItem value) {
 items_.Add(value);
 }

public const int sendTimeFieldNumber = 8;
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

public const int stateFieldNumber = 9;
 private bool hasState;
 private Int32 state_ = 0;
 public bool HasState {
 get { return hasState; }
 }
 public Int32 State {
 get { return state_; }
 set { SetState(value); }
 }
 public void SetState(Int32 value) { 
 hasState = true;
 state_ = value;
 }

public const int titleFieldNumber = 10;
 private bool hasTitle;
 private string title_ = "";
 public bool HasTitle {
 get { return hasTitle; }
 }
 public string Title {
 get { return title_; }
 set { SetTitle(value); }
 }
 public void SetTitle(string value) { 
 hasTitle = true;
 title_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMailID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, MailID);
}
 if (HasReceivePlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(2, ReceivePlayerID);
}
 if (HasSendType) {
size += pb::CodedOutputStream.ComputeInt32Size(3, SendType);
}
 if (HasPlayerID) {
size += pb::CodedOutputStream.ComputeInt64Size(4, PlayerID);
}
 if (HasSendName) {
size += pb::CodedOutputStream.ComputeStringSize(5, SendName);
}
 if (HasContent) {
size += pb::CodedOutputStream.ComputeStringSize(6, Content);
}
{
foreach (BackpackItem element in itemsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)7) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasSendTime) {
size += pb::CodedOutputStream.ComputeInt64Size(8, SendTime);
}
 if (HasState) {
size += pb::CodedOutputStream.ComputeInt32Size(9, State);
}
 if (HasTitle) {
size += pb::CodedOutputStream.ComputeStringSize(10, Title);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMailID) {
output.WriteInt64(1, MailID);
}
 
if (HasReceivePlayerID) {
output.WriteInt64(2, ReceivePlayerID);
}
 
if (HasSendType) {
output.WriteInt32(3, SendType);
}
 
if (HasPlayerID) {
output.WriteInt64(4, PlayerID);
}
 
if (HasSendName) {
output.WriteString(5, SendName);
}
 
if (HasContent) {
output.WriteString(6, Content);
}

do{
foreach (BackpackItem element in itemsList) {
output.WriteTag((int)7, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasSendTime) {
output.WriteInt64(8, SendTime);
}
 
if (HasState) {
output.WriteInt32(9, State);
}
 
if (HasTitle) {
output.WriteString(10, Title);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 MailInfo _inst = (MailInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MailID = input.ReadInt64();
break;
}
   case  16: {
 _inst.ReceivePlayerID = input.ReadInt64();
break;
}
   case  24: {
 _inst.SendType = input.ReadInt32();
break;
}
   case  32: {
 _inst.PlayerID = input.ReadInt64();
break;
}
   case  42: {
 _inst.SendName = input.ReadString();
break;
}
   case  50: {
 _inst.Content = input.ReadString();
break;
}
    case  58: {
BackpackItem subBuilder =  new BackpackItem();
input.ReadMessage(subBuilder);
_inst.AddItems(subBuilder);
break;
}
   case  64: {
 _inst.SendTime = input.ReadInt64();
break;
}
   case  72: {
 _inst.State = input.ReadInt32();
break;
}
   case  82: {
 _inst.Title = input.ReadString();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (BackpackItem element in itemsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
