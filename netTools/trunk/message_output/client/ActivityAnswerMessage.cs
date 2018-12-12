//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGAnswer : PacketDistributed
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

public const int answerFieldNumber = 2;
 private bool hasAnswer;
 private Int32 answer_ = 0;
 public bool HasAnswer {
 get { return hasAnswer; }
 }
 public Int32 Answer {
 get { return answer_; }
 set { SetAnswer(value); }
 }
 public void SetAnswer(Int32 value) { 
 hasAnswer = true;
 answer_ = value;
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
 if (HasAnswer) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Answer);
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
 
if (HasAnswer) {
output.WriteInt32(2, Answer);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGAnswer _inst = (CGAnswer) _base;
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
 _inst.Answer = input.ReadInt32();
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
public class CGAnswrQus : PacketDistributed
{

public const int tikuIdFieldNumber = 1;
 private bool hasTikuId;
 private Int32 tikuId_ = 0;
 public bool HasTikuId {
 get { return hasTikuId; }
 }
 public Int32 TikuId {
 get { return tikuId_; }
 set { SetTikuId(value); }
 }
 public void SetTikuId(Int32 value) { 
 hasTikuId = true;
 tikuId_ = value;
 }

public const int questIdFieldNumber = 2;
 private bool hasQuestId;
 private Int32 questId_ = 0;
 public bool HasQuestId {
 get { return hasQuestId; }
 }
 public Int32 QuestId {
 get { return questId_; }
 set { SetQuestId(value); }
 }
 public void SetQuestId(Int32 value) { 
 hasQuestId = true;
 questId_ = value;
 }

public const int answerFieldNumber = 3;
 private bool hasAnswer;
 private string answer_ = "";
 public bool HasAnswer {
 get { return hasAnswer; }
 }
 public string Answer {
 get { return answer_; }
 set { SetAnswer(value); }
 }
 public void SetAnswer(string value) { 
 hasAnswer = true;
 answer_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTikuId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TikuId);
}
 if (HasQuestId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, QuestId);
}
 if (HasAnswer) {
size += pb::CodedOutputStream.ComputeStringSize(3, Answer);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTikuId) {
output.WriteInt32(1, TikuId);
}
 
if (HasQuestId) {
output.WriteInt32(2, QuestId);
}
 
if (HasAnswer) {
output.WriteString(3, Answer);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGAnswrQus _inst = (CGAnswrQus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TikuId = input.ReadInt32();
break;
}
   case  16: {
 _inst.QuestId = input.ReadInt32();
break;
}
   case  26: {
 _inst.Answer = input.ReadString();
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
public class CGGetQuestions : PacketDistributed
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
 CGGetQuestions _inst = (CGGetQuestions) _base;
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
public class CGRwdAnswrQus : PacketDistributed
{

public const int tikuIdFieldNumber = 5;
 private bool hasTikuId;
 private Int32 tikuId_ = 0;
 public bool HasTikuId {
 get { return hasTikuId; }
 }
 public Int32 TikuId {
 get { return tikuId_; }
 set { SetTikuId(value); }
 }
 public void SetTikuId(Int32 value) { 
 hasTikuId = true;
 tikuId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTikuId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TikuId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTikuId) {
output.WriteInt32(5, TikuId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGRwdAnswrQus _inst = (CGRwdAnswrQus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  40: {
 _inst.TikuId = input.ReadInt32();
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
public class CGSurvey : PacketDistributed
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

public const int answerFieldNumber = 2;
 private bool hasAnswer;
 private string answer_ = "";
 public bool HasAnswer {
 get { return hasAnswer; }
 }
 public string Answer {
 get { return answer_; }
 set { SetAnswer(value); }
 }
 public void SetAnswer(string value) { 
 hasAnswer = true;
 answer_ = value;
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
 if (HasAnswer) {
size += pb::CodedOutputStream.ComputeStringSize(2, Answer);
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
 
if (HasAnswer) {
output.WriteString(2, Answer);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSurvey _inst = (CGSurvey) _base;
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
   case  18: {
 _inst.Answer = input.ReadString();
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
public class GCAnswerResult : PacketDistributed
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

public const int rightFieldNumber = 2;
 private bool hasRight;
 private Int32 right_ = 0;
 public bool HasRight {
 get { return hasRight; }
 }
 public Int32 Right {
 get { return right_; }
 set { SetRight(value); }
 }
 public void SetRight(Int32 value) { 
 hasRight = true;
 right_ = value;
 }

public const int totalFieldNumber = 3;
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

public const int errorCodeFieldNumber = 4;
 private bool hasErrorCode;
 private Int32 errorCode_ = 0;
 public bool HasErrorCode {
 get { return hasErrorCode; }
 }
 public Int32 ErrorCode {
 get { return errorCode_; }
 set { SetErrorCode(value); }
 }
 public void SetErrorCode(Int32 value) { 
 hasErrorCode = true;
 errorCode_ = value;
 }

public const int totalExpFieldNumber = 5;
 private bool hasTotalExp;
 private Int32 totalExp_ = 0;
 public bool HasTotalExp {
 get { return hasTotalExp; }
 }
 public Int32 TotalExp {
 get { return totalExp_; }
 set { SetTotalExp(value); }
 }
 public void SetTotalExp(Int32 value) { 
 hasTotalExp = true;
 totalExp_ = value;
 }

public const int totalMoneyFieldNumber = 6;
 private bool hasTotalMoney;
 private Int32 totalMoney_ = 0;
 public bool HasTotalMoney {
 get { return hasTotalMoney; }
 }
 public Int32 TotalMoney {
 get { return totalMoney_; }
 set { SetTotalMoney(value); }
 }
 public void SetTotalMoney(Int32 value) { 
 hasTotalMoney = true;
 totalMoney_ = value;
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
 if (HasRight) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Right);
}
 if (HasTotal) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Total);
}
 if (HasErrorCode) {
size += pb::CodedOutputStream.ComputeInt32Size(4, ErrorCode);
}
 if (HasTotalExp) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TotalExp);
}
 if (HasTotalMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(6, TotalMoney);
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
 
if (HasRight) {
output.WriteInt32(2, Right);
}
 
if (HasTotal) {
output.WriteInt32(3, Total);
}
 
if (HasErrorCode) {
output.WriteInt32(4, ErrorCode);
}
 
if (HasTotalExp) {
output.WriteInt32(5, TotalExp);
}
 
if (HasTotalMoney) {
output.WriteInt32(6, TotalMoney);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAnswerResult _inst = (GCAnswerResult) _base;
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
   case  16: {
 _inst.Right = input.ReadInt32();
break;
}
   case  24: {
 _inst.Total = input.ReadInt32();
break;
}
   case  32: {
 _inst.ErrorCode = input.ReadInt32();
break;
}
   case  40: {
 _inst.TotalExp = input.ReadInt32();
break;
}
   case  48: {
 _inst.TotalMoney = input.ReadInt32();
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
public class GCAnswrQus : PacketDistributed
{

public const int tikuIdFieldNumber = 1;
 private bool hasTikuId;
 private Int32 tikuId_ = 0;
 public bool HasTikuId {
 get { return hasTikuId; }
 }
 public Int32 TikuId {
 get { return tikuId_; }
 set { SetTikuId(value); }
 }
 public void SetTikuId(Int32 value) { 
 hasTikuId = true;
 tikuId_ = value;
 }

public const int questIdFieldNumber = 2;
 private bool hasQuestId;
 private Int32 questId_ = 0;
 public bool HasQuestId {
 get { return hasQuestId; }
 }
 public Int32 QuestId {
 get { return questId_; }
 set { SetQuestId(value); }
 }
 public void SetQuestId(Int32 value) { 
 hasQuestId = true;
 questId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTikuId) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TikuId);
}
 if (HasQuestId) {
size += pb::CodedOutputStream.ComputeInt32Size(2, QuestId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTikuId) {
output.WriteInt32(1, TikuId);
}
 
if (HasQuestId) {
output.WriteInt32(2, QuestId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAnswrQus _inst = (GCAnswrQus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TikuId = input.ReadInt32();
break;
}
   case  16: {
 _inst.QuestId = input.ReadInt32();
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
public class GCInitAnswer : PacketDistributed
{

public const int idsFieldNumber = 1;
 private pbc::PopsicleList<Int32> ids_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> idsList {
 get { return pbc::Lists.AsReadOnly(ids_); }
 }
 
 public int idsCount {
 get { return ids_.Count; }
 }
 
public Int32 GetIds(int index) {
 return ids_[index];
 }
 public void AddIds(Int32 value) {
 ids_.Add(value);
 }

public const int beginTimeFieldNumber = 2;
 private bool hasBeginTime;
 private Int64 beginTime_ = 0;
 public bool HasBeginTime {
 get { return hasBeginTime; }
 }
 public Int64 BeginTime {
 get { return beginTime_; }
 set { SetBeginTime(value); }
 }
 public void SetBeginTime(Int64 value) { 
 hasBeginTime = true;
 beginTime_ = value;
 }

public const int rightFieldNumber = 3;
 private bool hasRight;
 private Int32 right_ = 0;
 public bool HasRight {
 get { return hasRight; }
 }
 public Int32 Right {
 get { return right_; }
 set { SetRight(value); }
 }
 public void SetRight(Int32 value) { 
 hasRight = true;
 right_ = value;
 }

public const int totalFieldNumber = 4;
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

public const int totalExpFieldNumber = 5;
 private bool hasTotalExp;
 private Int32 totalExp_ = 0;
 public bool HasTotalExp {
 get { return hasTotalExp; }
 }
 public Int32 TotalExp {
 get { return totalExp_; }
 set { SetTotalExp(value); }
 }
 public void SetTotalExp(Int32 value) { 
 hasTotalExp = true;
 totalExp_ = value;
 }

public const int totalMoneyFieldNumber = 6;
 private bool hasTotalMoney;
 private Int32 totalMoney_ = 0;
 public bool HasTotalMoney {
 get { return hasTotalMoney; }
 }
 public Int32 TotalMoney {
 get { return totalMoney_; }
 set { SetTotalMoney(value); }
 }
 public void SetTotalMoney(Int32 value) { 
 hasTotalMoney = true;
 totalMoney_ = value;
 }

public const int isOpenSurveyFieldNumber = 7;
 private bool hasIsOpenSurvey;
 private Int32 isOpenSurvey_ = 0;
 public bool HasIsOpenSurvey {
 get { return hasIsOpenSurvey; }
 }
 public Int32 IsOpenSurvey {
 get { return isOpenSurvey_; }
 set { SetIsOpenSurvey(value); }
 }
 public void SetIsOpenSurvey(Int32 value) { 
 hasIsOpenSurvey = true;
 isOpenSurvey_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in idsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * ids_.Count;
}
 if (HasBeginTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, BeginTime);
}
 if (HasRight) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Right);
}
 if (HasTotal) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Total);
}
 if (HasTotalExp) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TotalExp);
}
 if (HasTotalMoney) {
size += pb::CodedOutputStream.ComputeInt32Size(6, TotalMoney);
}
 if (HasIsOpenSurvey) {
size += pb::CodedOutputStream.ComputeInt32Size(7, IsOpenSurvey);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (ids_.Count > 0) {
foreach (Int32 element in idsList) {
output.WriteInt32(1,element);
}
}

}
 
if (HasBeginTime) {
output.WriteInt64(2, BeginTime);
}
 
if (HasRight) {
output.WriteInt32(3, Right);
}
 
if (HasTotal) {
output.WriteInt32(4, Total);
}
 
if (HasTotalExp) {
output.WriteInt32(5, TotalExp);
}
 
if (HasTotalMoney) {
output.WriteInt32(6, TotalMoney);
}
 
if (HasIsOpenSurvey) {
output.WriteInt32(7, IsOpenSurvey);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInitAnswer _inst = (GCInitAnswer) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddIds(input.ReadInt32());
break;
}
   case  16: {
 _inst.BeginTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.Right = input.ReadInt32();
break;
}
   case  32: {
 _inst.Total = input.ReadInt32();
break;
}
   case  40: {
 _inst.TotalExp = input.ReadInt32();
break;
}
   case  48: {
 _inst.TotalMoney = input.ReadInt32();
break;
}
   case  56: {
 _inst.IsOpenSurvey = input.ReadInt32();
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
public class GCPushAnswerOpen : PacketDistributed
{

public const int isOpenSurveyFieldNumber = 1;
 private bool hasIsOpenSurvey;
 private Int32 isOpenSurvey_ = 0;
 public bool HasIsOpenSurvey {
 get { return hasIsOpenSurvey; }
 }
 public Int32 IsOpenSurvey {
 get { return isOpenSurvey_; }
 set { SetIsOpenSurvey(value); }
 }
 public void SetIsOpenSurvey(Int32 value) { 
 hasIsOpenSurvey = true;
 isOpenSurvey_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasIsOpenSurvey) {
size += pb::CodedOutputStream.ComputeInt32Size(1, IsOpenSurvey);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasIsOpenSurvey) {
output.WriteInt32(1, IsOpenSurvey);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCPushAnswerOpen _inst = (GCPushAnswerOpen) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.IsOpenSurvey = input.ReadInt32();
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
public class GCRwdAnswrQus : PacketDistributed
{

public const int tikuIdFieldNumber = 5;
 private bool hasTikuId;
 private Int32 tikuId_ = 0;
 public bool HasTikuId {
 get { return hasTikuId; }
 }
 public Int32 TikuId {
 get { return tikuId_; }
 set { SetTikuId(value); }
 }
 public void SetTikuId(Int32 value) { 
 hasTikuId = true;
 tikuId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTikuId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TikuId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTikuId) {
output.WriteInt32(5, TikuId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRwdAnswrQus _inst = (GCRwdAnswrQus) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  40: {
 _inst.TikuId = input.ReadInt32();
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
public class GCSendQuestions : PacketDistributed
{

public const int idsFieldNumber = 1;
 private pbc::PopsicleList<Int32> ids_ = new pbc::PopsicleList<Int32>();
 public scg::IList<Int32> idsList {
 get { return pbc::Lists.AsReadOnly(ids_); }
 }
 
 public int idsCount {
 get { return ids_.Count; }
 }
 
public Int32 GetIds(int index) {
 return ids_[index];
 }
 public void AddIds(Int32 value) {
 ids_.Add(value);
 }

public const int beginTimeFieldNumber = 2;
 private bool hasBeginTime;
 private Int64 beginTime_ = 0;
 public bool HasBeginTime {
 get { return hasBeginTime; }
 }
 public Int64 BeginTime {
 get { return beginTime_; }
 set { SetBeginTime(value); }
 }
 public void SetBeginTime(Int64 value) { 
 hasBeginTime = true;
 beginTime_ = value;
 }

public const int isOpenSurveyFieldNumber = 3;
 private bool hasIsOpenSurvey;
 private Int32 isOpenSurvey_ = 0;
 public bool HasIsOpenSurvey {
 get { return hasIsOpenSurvey; }
 }
 public Int32 IsOpenSurvey {
 get { return isOpenSurvey_; }
 set { SetIsOpenSurvey(value); }
 }
 public void SetIsOpenSurvey(Int32 value) { 
 hasIsOpenSurvey = true;
 isOpenSurvey_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int32 element in idsList) {
dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
}
size += dataSize;
size += 1 * ids_.Count;
}
 if (HasBeginTime) {
size += pb::CodedOutputStream.ComputeInt64Size(2, BeginTime);
}
 if (HasIsOpenSurvey) {
size += pb::CodedOutputStream.ComputeInt32Size(3, IsOpenSurvey);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (ids_.Count > 0) {
foreach (Int32 element in idsList) {
output.WriteInt32(1,element);
}
}

}
 
if (HasBeginTime) {
output.WriteInt64(2, BeginTime);
}
 
if (HasIsOpenSurvey) {
output.WriteInt32(3, IsOpenSurvey);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSendQuestions _inst = (GCSendQuestions) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddIds(input.ReadInt32());
break;
}
   case  16: {
 _inst.BeginTime = input.ReadInt64();
break;
}
   case  24: {
 _inst.IsOpenSurvey = input.ReadInt32();
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
public class GCSurvey : PacketDistributed
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
 GCSurvey _inst = (GCSurvey) _base;
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
public class GCWenJuanListData : PacketDistributed
{

public const int dataListFieldNumber = 1;
 private pbc::PopsicleList<TiKuData> dataList_ = new pbc::PopsicleList<TiKuData>();
 public scg::IList<TiKuData> dataListList {
 get { return pbc::Lists.AsReadOnly(dataList_); }
 }
 
 public int dataListCount {
 get { return dataList_.Count; }
 }
 
public TiKuData GetDataList(int index) {
 return dataList_[index];
 }
 public void AddDataList(TiKuData value) {
 dataList_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (TiKuData element in dataListList) {
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
foreach (TiKuData element in dataListList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCWenJuanListData _inst = (GCWenJuanListData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TiKuData subBuilder =  new TiKuData();
input.ReadMessage(subBuilder);
_inst.AddDataList(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TiKuData element in dataListList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class QuestionData : PacketDistributed
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

public const int categoryFieldNumber = 2;
 private bool hasCategory;
 private Int32 category_ = 0;
 public bool HasCategory {
 get { return hasCategory; }
 }
 public Int32 Category {
 get { return category_; }
 set { SetCategory(value); }
 }
 public void SetCategory(Int32 value) { 
 hasCategory = true;
 category_ = value;
 }

public const int questionFieldNumber = 3;
 private bool hasQuestion;
 private string question_ = "";
 public bool HasQuestion {
 get { return hasQuestion; }
 }
 public string Question {
 get { return question_; }
 set { SetQuestion(value); }
 }
 public void SetQuestion(string value) { 
 hasQuestion = true;
 question_ = value;
 }

public const int answerFieldNumber = 4;
 private bool hasAnswer;
 private string answer_ = "";
 public bool HasAnswer {
 get { return hasAnswer; }
 }
 public string Answer {
 get { return answer_; }
 set { SetAnswer(value); }
 }
 public void SetAnswer(string value) { 
 hasAnswer = true;
 answer_ = value;
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
 if (HasCategory) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Category);
}
 if (HasQuestion) {
size += pb::CodedOutputStream.ComputeStringSize(3, Question);
}
 if (HasAnswer) {
size += pb::CodedOutputStream.ComputeStringSize(4, Answer);
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
 
if (HasCategory) {
output.WriteInt32(2, Category);
}
 
if (HasQuestion) {
output.WriteString(3, Question);
}
 
if (HasAnswer) {
output.WriteString(4, Answer);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 QuestionData _inst = (QuestionData) _base;
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
 _inst.Category = input.ReadInt32();
break;
}
   case  26: {
 _inst.Question = input.ReadString();
break;
}
   case  34: {
 _inst.Answer = input.ReadString();
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
public class TiKuData : PacketDistributed
{

public const int datasFieldNumber = 1;
 private pbc::PopsicleList<QuestionData> datas_ = new pbc::PopsicleList<QuestionData>();
 public scg::IList<QuestionData> datasList {
 get { return pbc::Lists.AsReadOnly(datas_); }
 }
 
 public int datasCount {
 get { return datas_.Count; }
 }
 
public QuestionData GetDatas(int index) {
 return datas_[index];
 }
 public void AddDatas(QuestionData value) {
 datas_.Add(value);
 }

public const int propsRewardFieldNumber = 3;
 private bool hasPropsReward;
 private string propsReward_ = "";
 public bool HasPropsReward {
 get { return hasPropsReward; }
 }
 public string PropsReward {
 get { return propsReward_; }
 set { SetPropsReward(value); }
 }
 public void SetPropsReward(string value) { 
 hasPropsReward = true;
 propsReward_ = value;
 }

public const int currencyRewardFieldNumber = 4;
 private bool hasCurrencyReward;
 private string currencyReward_ = "";
 public bool HasCurrencyReward {
 get { return hasCurrencyReward; }
 }
 public string CurrencyReward {
 get { return currencyReward_; }
 set { SetCurrencyReward(value); }
 }
 public void SetCurrencyReward(string value) { 
 hasCurrencyReward = true;
 currencyReward_ = value;
 }

public const int tikuIdFieldNumber = 5;
 private bool hasTikuId;
 private Int32 tikuId_ = 0;
 public bool HasTikuId {
 get { return hasTikuId; }
 }
 public Int32 TikuId {
 get { return tikuId_; }
 set { SetTikuId(value); }
 }
 public void SetTikuId(Int32 value) { 
 hasTikuId = true;
 tikuId_ = value;
 }

public const int nameFieldNumber = 6;
 private bool hasName;
 private string name_ = "";
 public bool HasName {
 get { return hasName; }
 }
 public string Name {
 get { return name_; }
 set { SetName(value); }
 }
 public void SetName(string value) { 
 hasName = true;
 name_ = value;
 }

public const int rwdStsFieldNumber = 7;
 private bool hasRwdSts;
 private Int32 rwdSts_ = 0;
 public bool HasRwdSts {
 get { return hasRwdSts; }
 }
 public Int32 RwdSts {
 get { return rwdSts_; }
 set { SetRwdSts(value); }
 }
 public void SetRwdSts(Int32 value) { 
 hasRwdSts = true;
 rwdSts_ = value;
 }

public const int totalNumFieldNumber = 8;
 private bool hasTotalNum;
 private Int32 totalNum_ = 0;
 public bool HasTotalNum {
 get { return hasTotalNum; }
 }
 public Int32 TotalNum {
 get { return totalNum_; }
 set { SetTotalNum(value); }
 }
 public void SetTotalNum(Int32 value) { 
 hasTotalNum = true;
 totalNum_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (QuestionData element in datasList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasPropsReward) {
size += pb::CodedOutputStream.ComputeStringSize(3, PropsReward);
}
 if (HasCurrencyReward) {
size += pb::CodedOutputStream.ComputeStringSize(4, CurrencyReward);
}
 if (HasTikuId) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TikuId);
}
 if (HasName) {
size += pb::CodedOutputStream.ComputeStringSize(6, Name);
}
 if (HasRwdSts) {
size += pb::CodedOutputStream.ComputeInt32Size(7, RwdSts);
}
 if (HasTotalNum) {
size += pb::CodedOutputStream.ComputeInt32Size(8, TotalNum);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (QuestionData element in datasList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasPropsReward) {
output.WriteString(3, PropsReward);
}
 
if (HasCurrencyReward) {
output.WriteString(4, CurrencyReward);
}
 
if (HasTikuId) {
output.WriteInt32(5, TikuId);
}
 
if (HasName) {
output.WriteString(6, Name);
}
 
if (HasRwdSts) {
output.WriteInt32(7, RwdSts);
}
 
if (HasTotalNum) {
output.WriteInt32(8, TotalNum);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TiKuData _inst = (TiKuData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
QuestionData subBuilder =  new QuestionData();
input.ReadMessage(subBuilder);
_inst.AddDatas(subBuilder);
break;
}
   case  26: {
 _inst.PropsReward = input.ReadString();
break;
}
   case  34: {
 _inst.CurrencyReward = input.ReadString();
break;
}
   case  40: {
 _inst.TikuId = input.ReadInt32();
break;
}
   case  50: {
 _inst.Name = input.ReadString();
break;
}
   case  56: {
 _inst.RwdSts = input.ReadInt32();
break;
}
   case  64: {
 _inst.TotalNum = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (QuestionData element in datasList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
