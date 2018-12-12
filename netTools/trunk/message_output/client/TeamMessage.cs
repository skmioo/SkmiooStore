//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class CGAgreeApply : PacketDistributed
{

public const int applyIdFieldNumber = 1;
 private bool hasApplyId;
 private Int64 applyId_ = 0;
 public bool HasApplyId {
 get { return hasApplyId; }
 }
 public Int64 ApplyId {
 get { return applyId_; }
 set { SetApplyId(value); }
 }
 public void SetApplyId(Int64 value) { 
 hasApplyId = true;
 applyId_ = value;
 }

public const int stsFieldNumber = 2;
 private bool hasSts;
 private Int32 sts_ = 0;
 public bool HasSts {
 get { return hasSts; }
 }
 public Int32 Sts {
 get { return sts_; }
 set { SetSts(value); }
 }
 public void SetSts(Int32 value) { 
 hasSts = true;
 sts_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasApplyId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ApplyId);
}
 if (HasSts) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Sts);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasApplyId) {
output.WriteInt64(1, ApplyId);
}
 
if (HasSts) {
output.WriteInt32(2, Sts);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGAgreeApply _inst = (CGAgreeApply) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ApplyId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Sts = input.ReadInt32();
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
public class CGAgreeInvite : PacketDistributed
{

public const int leaderPlayerIdFieldNumber = 1;
 private bool hasLeaderPlayerId;
 private Int64 leaderPlayerId_ = 0;
 public bool HasLeaderPlayerId {
 get { return hasLeaderPlayerId; }
 }
 public Int64 LeaderPlayerId {
 get { return leaderPlayerId_; }
 set { SetLeaderPlayerId(value); }
 }
 public void SetLeaderPlayerId(Int64 value) { 
 hasLeaderPlayerId = true;
 leaderPlayerId_ = value;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLeaderPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, LeaderPlayerId);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLeaderPlayerId) {
output.WriteInt64(1, LeaderPlayerId);
}
 
if (HasType) {
output.WriteInt32(2, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGAgreeInvite _inst = (CGAgreeInvite) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.LeaderPlayerId = input.ReadInt64();
break;
}
   case  16: {
 _inst.Type = input.ReadInt32();
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
public class CGApplyTeam : PacketDistributed
{

public const int teamIDFieldNumber = 1;
 private bool hasTeamID;
 private Int64 teamID_ = 0;
 public bool HasTeamID {
 get { return hasTeamID; }
 }
 public Int64 TeamID {
 get { return teamID_; }
 set { SetTeamID(value); }
 }
 public void SetTeamID(Int64 value) { 
 hasTeamID = true;
 teamID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTeamID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TeamID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTeamID) {
output.WriteInt64(1, TeamID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGApplyTeam _inst = (CGApplyTeam) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TeamID = input.ReadInt64();
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
public class CGCallFlow : PacketDistributed
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
 CGCallFlow _inst = (CGCallFlow) _base;
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
public class CGCreateTeam : PacketDistributed
{

public const int targetIDFieldNumber = 1;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(1, TargetID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTargetID) {
output.WriteInt32(1, TargetID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGCreateTeam _inst = (CGCreateTeam) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TargetID = input.ReadInt32();
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
public class CGInviteOther : PacketDistributed
{

public const int invitePlayerIdFieldNumber = 1;
 private bool hasInvitePlayerId;
 private Int64 invitePlayerId_ = 0;
 public bool HasInvitePlayerId {
 get { return hasInvitePlayerId; }
 }
 public Int64 InvitePlayerId {
 get { return invitePlayerId_; }
 set { SetInvitePlayerId(value); }
 }
 public void SetInvitePlayerId(Int64 value) { 
 hasInvitePlayerId = true;
 invitePlayerId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasInvitePlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, InvitePlayerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasInvitePlayerId) {
output.WriteInt64(1, InvitePlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGInviteOther _inst = (CGInviteOther) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.InvitePlayerId = input.ReadInt64();
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
public class CGKickedOut : PacketDistributed
{

public const int otherPlayerIdFieldNumber = 1;
 private bool hasOtherPlayerId;
 private Int64 otherPlayerId_ = 0;
 public bool HasOtherPlayerId {
 get { return hasOtherPlayerId; }
 }
 public Int64 OtherPlayerId {
 get { return otherPlayerId_; }
 set { SetOtherPlayerId(value); }
 }
 public void SetOtherPlayerId(Int64 value) { 
 hasOtherPlayerId = true;
 otherPlayerId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOtherPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, OtherPlayerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOtherPlayerId) {
output.WriteInt64(1, OtherPlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGKickedOut _inst = (CGKickedOut) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OtherPlayerId = input.ReadInt64();
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
public class CGLeaveTeam : PacketDistributed
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
 CGLeaveTeam _inst = (CGLeaveTeam) _base;
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
public class CGMemberFolw : PacketDistributed
{

public const int autoFolwFieldNumber = 1;
 private bool hasAutoFolw;
 private Int32 autoFolw_ = 0;
 public bool HasAutoFolw {
 get { return hasAutoFolw; }
 }
 public Int32 AutoFolw {
 get { return autoFolw_; }
 set { SetAutoFolw(value); }
 }
 public void SetAutoFolw(Int32 value) { 
 hasAutoFolw = true;
 autoFolw_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoFolw) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoFolw);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoFolw) {
output.WriteInt32(1, AutoFolw);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGMemberFolw _inst = (CGMemberFolw) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoFolw = input.ReadInt32();
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
public class CGMemberResponse : PacketDistributed
{

public const int resFieldNumber = 1;
 private bool hasRes;
 private Int32 res_ = 0;
 public bool HasRes {
 get { return hasRes; }
 }
 public Int32 Res {
 get { return res_; }
 set { SetRes(value); }
 }
 public void SetRes(Int32 value) { 
 hasRes = true;
 res_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasRes) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Res);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasRes) {
output.WriteInt32(1, Res);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGMemberResponse _inst = (CGMemberResponse) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Res = input.ReadInt32();
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
public class CGOpenTeamView : PacketDistributed
{

public const int typeFieldNumber = 1;
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

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasType) {
output.WriteInt32(1, Type);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGOpenTeamView _inst = (CGOpenTeamView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.Type = input.ReadInt32();
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
public class CGQuickTeam : PacketDistributed
{

public const int autoQuickFieldNumber = 1;
 private bool hasAutoQuick;
 private Int32 autoQuick_ = 0;
 public bool HasAutoQuick {
 get { return hasAutoQuick; }
 }
 public Int32 AutoQuick {
 get { return autoQuick_; }
 set { SetAutoQuick(value); }
 }
 public void SetAutoQuick(Int32 value) { 
 hasAutoQuick = true;
 autoQuick_ = value;
 }

public const int targetIDFieldNumber = 2;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoQuick) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoQuick);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(2, TargetID);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoQuick) {
output.WriteInt32(1, AutoQuick);
}
 
if (HasTargetID) {
output.WriteInt32(2, TargetID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGQuickTeam _inst = (CGQuickTeam) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoQuick = input.ReadInt32();
break;
}
   case  16: {
 _inst.TargetID = input.ReadInt32();
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
public class CGSetAutoAgree : PacketDistributed
{

public const int autoAgreeFieldNumber = 1;
 private bool hasAutoAgree;
 private Int32 autoAgree_ = 0;
 public bool HasAutoAgree {
 get { return hasAutoAgree; }
 }
 public Int32 AutoAgree {
 get { return autoAgree_; }
 set { SetAutoAgree(value); }
 }
 public void SetAutoAgree(Int32 value) { 
 hasAutoAgree = true;
 autoAgree_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoAgree) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoAgree);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoAgree) {
output.WriteInt32(1, AutoAgree);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSetAutoAgree _inst = (CGSetAutoAgree) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoAgree = input.ReadInt32();
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
public class CGSetTeamAuthority : PacketDistributed
{

public const int minLvFieldNumber = 1;
 private bool hasMinLv;
 private Int32 minLv_ = 0;
 public bool HasMinLv {
 get { return hasMinLv; }
 }
 public Int32 MinLv {
 get { return minLv_; }
 set { SetMinLv(value); }
 }
 public void SetMinLv(Int32 value) { 
 hasMinLv = true;
 minLv_ = value;
 }

public const int maxLvFieldNumber = 2;
 private bool hasMaxLv;
 private Int32 maxLv_ = 0;
 public bool HasMaxLv {
 get { return hasMaxLv; }
 }
 public Int32 MaxLv {
 get { return maxLv_; }
 set { SetMaxLv(value); }
 }
 public void SetMaxLv(Int32 value) { 
 hasMaxLv = true;
 maxLv_ = value;
 }

public const int minBattleNumberFieldNumber = 3;
 private bool hasMinBattleNumber;
 private Int32 minBattleNumber_ = 0;
 public bool HasMinBattleNumber {
 get { return hasMinBattleNumber; }
 }
 public Int32 MinBattleNumber {
 get { return minBattleNumber_; }
 set { SetMinBattleNumber(value); }
 }
 public void SetMinBattleNumber(Int32 value) { 
 hasMinBattleNumber = true;
 minBattleNumber_ = value;
 }

public const int targetIDFieldNumber = 4;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

public const int autoFollwFieldNumber = 5;
 private bool hasAutoFollw;
 private Int32 autoFollw_ = 0;
 public bool HasAutoFollw {
 get { return hasAutoFollw; }
 }
 public Int32 AutoFollw {
 get { return autoFollw_; }
 set { SetAutoFollw(value); }
 }
 public void SetAutoFollw(Int32 value) { 
 hasAutoFollw = true;
 autoFollw_ = value;
 }

public const int autoAgreeFieldNumber = 6;
 private bool hasAutoAgree;
 private Int32 autoAgree_ = 0;
 public bool HasAutoAgree {
 get { return hasAutoAgree; }
 }
 public Int32 AutoAgree {
 get { return autoAgree_; }
 set { SetAutoAgree(value); }
 }
 public void SetAutoAgree(Int32 value) { 
 hasAutoAgree = true;
 autoAgree_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMinLv) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MinLv);
}
 if (HasMaxLv) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MaxLv);
}
 if (HasMinBattleNumber) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MinBattleNumber);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TargetID);
}
 if (HasAutoFollw) {
size += pb::CodedOutputStream.ComputeInt32Size(5, AutoFollw);
}
 if (HasAutoAgree) {
size += pb::CodedOutputStream.ComputeInt32Size(6, AutoAgree);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMinLv) {
output.WriteInt32(1, MinLv);
}
 
if (HasMaxLv) {
output.WriteInt32(2, MaxLv);
}
 
if (HasMinBattleNumber) {
output.WriteInt32(3, MinBattleNumber);
}
 
if (HasTargetID) {
output.WriteInt32(4, TargetID);
}
 
if (HasAutoFollw) {
output.WriteInt32(5, AutoFollw);
}
 
if (HasAutoAgree) {
output.WriteInt32(6, AutoAgree);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGSetTeamAuthority _inst = (CGSetTeamAuthority) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MinLv = input.ReadInt32();
break;
}
   case  16: {
 _inst.MaxLv = input.ReadInt32();
break;
}
   case  24: {
 _inst.MinBattleNumber = input.ReadInt32();
break;
}
   case  32: {
 _inst.TargetID = input.ReadInt32();
break;
}
   case  40: {
 _inst.AutoFollw = input.ReadInt32();
break;
}
   case  48: {
 _inst.AutoAgree = input.ReadInt32();
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
public class CGTransferCaption : PacketDistributed
{

public const int otherPlayerIdFieldNumber = 1;
 private bool hasOtherPlayerId;
 private Int64 otherPlayerId_ = 0;
 public bool HasOtherPlayerId {
 get { return hasOtherPlayerId; }
 }
 public Int64 OtherPlayerId {
 get { return otherPlayerId_; }
 set { SetOtherPlayerId(value); }
 }
 public void SetOtherPlayerId(Int64 value) { 
 hasOtherPlayerId = true;
 otherPlayerId_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasOtherPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, OtherPlayerId);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasOtherPlayerId) {
output.WriteInt64(1, OtherPlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 CGTransferCaption _inst = (CGTransferCaption) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.OtherPlayerId = input.ReadInt64();
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
public class GCAddTeamMember : PacketDistributed
{

public const int memberFieldNumber = 1;
 private bool hasMember;
 private TeamMember member_ =  new TeamMember();
 public bool HasMember {
 get { return hasMember; }
 }
 public TeamMember Member {
 get { return member_; }
 set { SetMember(value); }
 }
 public void SetMember(TeamMember value) { 
 hasMember = true;
 member_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = Member.SerializedSize();	
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
output.WriteRawVarint32((uint)Member.SerializedSize());
Member.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCAddTeamMember _inst = (GCAddTeamMember) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TeamMember subBuilder =  new TeamMember();
 input.ReadMessage(subBuilder);
_inst.Member = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasMember) {
if (!Member.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCApplyTeamLeader : PacketDistributed
{

public const int applyIdFieldNumber = 1;
 private bool hasApplyId;
 private Int64 applyId_ = 0;
 public bool HasApplyId {
 get { return hasApplyId; }
 }
 public Int64 ApplyId {
 get { return applyId_; }
 set { SetApplyId(value); }
 }
 public void SetApplyId(Int64 value) { 
 hasApplyId = true;
 applyId_ = value;
 }

public const int applyNameFieldNumber = 2;
 private bool hasApplyName;
 private string applyName_ = "";
 public bool HasApplyName {
 get { return hasApplyName; }
 }
 public string ApplyName {
 get { return applyName_; }
 set { SetApplyName(value); }
 }
 public void SetApplyName(string value) { 
 hasApplyName = true;
 applyName_ = value;
 }

public const int battleNumberFieldNumber = 3;
 private bool hasBattleNumber;
 private string battleNumber_ = "";
 public bool HasBattleNumber {
 get { return hasBattleNumber; }
 }
 public string BattleNumber {
 get { return battleNumber_; }
 set { SetBattleNumber(value); }
 }
 public void SetBattleNumber(string value) { 
 hasBattleNumber = true;
 battleNumber_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasApplyId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, ApplyId);
}
 if (HasApplyName) {
size += pb::CodedOutputStream.ComputeStringSize(2, ApplyName);
}
 if (HasBattleNumber) {
size += pb::CodedOutputStream.ComputeStringSize(3, BattleNumber);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasApplyId) {
output.WriteInt64(1, ApplyId);
}
 
if (HasApplyName) {
output.WriteString(2, ApplyName);
}
 
if (HasBattleNumber) {
output.WriteString(3, BattleNumber);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCApplyTeamLeader _inst = (GCApplyTeamLeader) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.ApplyId = input.ReadInt64();
break;
}
   case  18: {
 _inst.ApplyName = input.ReadString();
break;
}
   case  26: {
 _inst.BattleNumber = input.ReadString();
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
public class GCCallFlow : PacketDistributed
{

public const int playerNameFieldNumber = 1;
 private bool hasPlayerName;
 private string playerName_ = "";
 public bool HasPlayerName {
 get { return hasPlayerName; }
 }
 public string PlayerName {
 get { return playerName_; }
 set { SetPlayerName(value); }
 }
 public void SetPlayerName(string value) { 
 hasPlayerName = true;
 playerName_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasPlayerName) {
size += pb::CodedOutputStream.ComputeStringSize(1, PlayerName);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasPlayerName) {
output.WriteString(1, PlayerName);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCCallFlow _inst = (GCCallFlow) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  10: {
 _inst.PlayerName = input.ReadString();
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
public class GCDelTeamMember : PacketDistributed
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
 GCDelTeamMember _inst = (GCDelTeamMember) _base;
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
public class GCFllowQueue : PacketDistributed
{

public const int fllowIdsFieldNumber = 1;
 private pbc::PopsicleList<Int64> fllowIds_ = new pbc::PopsicleList<Int64>();
 public scg::IList<Int64> fllowIdsList {
 get { return pbc::Lists.AsReadOnly(fllowIds_); }
 }
 
 public int fllowIdsCount {
 get { return fllowIds_.Count; }
 }
 
public Int64 GetFllowIds(int index) {
 return fllowIds_[index];
 }
 public void AddFllowIds(Int64 value) {
 fllowIds_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int dataSize = 0;
foreach (Int64 element in fllowIdsList) {
dataSize += pb::CodedOutputStream.ComputeInt64SizeNoTag(element);
}
size += dataSize;
size += 1 * fllowIds_.Count;
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 {
if (fllowIds_.Count > 0) {
foreach (Int64 element in fllowIdsList) {
output.WriteInt64(1,element);
}
}

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCFllowQueue _inst = (GCFllowQueue) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AddFllowIds(input.ReadInt64());
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
public class GCInviteOther : PacketDistributed
{

public const int leaderPlayerIdFieldNumber = 1;
 private bool hasLeaderPlayerId;
 private Int64 leaderPlayerId_ = 0;
 public bool HasLeaderPlayerId {
 get { return hasLeaderPlayerId; }
 }
 public Int64 LeaderPlayerId {
 get { return leaderPlayerId_; }
 set { SetLeaderPlayerId(value); }
 }
 public void SetLeaderPlayerId(Int64 value) { 
 hasLeaderPlayerId = true;
 leaderPlayerId_ = value;
 }

public const int leaderNameFieldNumber = 2;
 private bool hasLeaderName;
 private string leaderName_ = "";
 public bool HasLeaderName {
 get { return hasLeaderName; }
 }
 public string LeaderName {
 get { return leaderName_; }
 set { SetLeaderName(value); }
 }
 public void SetLeaderName(string value) { 
 hasLeaderName = true;
 leaderName_ = value;
 }

public const int battleNumberFieldNumber = 3;
 private bool hasBattleNumber;
 private string battleNumber_ = "";
 public bool HasBattleNumber {
 get { return hasBattleNumber; }
 }
 public string BattleNumber {
 get { return battleNumber_; }
 set { SetBattleNumber(value); }
 }
 public void SetBattleNumber(string value) { 
 hasBattleNumber = true;
 battleNumber_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasLeaderPlayerId) {
size += pb::CodedOutputStream.ComputeInt64Size(1, LeaderPlayerId);
}
 if (HasLeaderName) {
size += pb::CodedOutputStream.ComputeStringSize(2, LeaderName);
}
 if (HasBattleNumber) {
size += pb::CodedOutputStream.ComputeStringSize(3, BattleNumber);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasLeaderPlayerId) {
output.WriteInt64(1, LeaderPlayerId);
}
 
if (HasLeaderName) {
output.WriteString(2, LeaderName);
}
 
if (HasBattleNumber) {
output.WriteString(3, BattleNumber);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCInviteOther _inst = (GCInviteOther) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.LeaderPlayerId = input.ReadInt64();
break;
}
   case  18: {
 _inst.LeaderName = input.ReadString();
break;
}
   case  26: {
 _inst.BattleNumber = input.ReadString();
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
public class GCLeaveTeam : PacketDistributed
{

public const int isInitiativeFieldNumber = 1;
 private bool hasIsInitiative;
 private Int32 isInitiative_ = 0;
 public bool HasIsInitiative {
 get { return hasIsInitiative; }
 }
 public Int32 IsInitiative {
 get { return isInitiative_; }
 set { SetIsInitiative(value); }
 }
 public void SetIsInitiative(Int32 value) { 
 hasIsInitiative = true;
 isInitiative_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasIsInitiative) {
size += pb::CodedOutputStream.ComputeInt32Size(1, IsInitiative);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasIsInitiative) {
output.WriteInt32(1, IsInitiative);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCLeaveTeam _inst = (GCLeaveTeam) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.IsInitiative = input.ReadInt32();
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
public class GCMemberFolw : PacketDistributed
{

public const int autoFolwFieldNumber = 1;
 private bool hasAutoFolw;
 private Int32 autoFolw_ = 0;
 public bool HasAutoFolw {
 get { return hasAutoFolw; }
 }
 public Int32 AutoFolw {
 get { return autoFolw_; }
 set { SetAutoFolw(value); }
 }
 public void SetAutoFolw(Int32 value) { 
 hasAutoFolw = true;
 autoFolw_ = value;
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
  if (HasAutoFolw) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoFolw);
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
  
if (HasAutoFolw) {
output.WriteInt32(1, AutoFolw);
}
 
if (HasPlayerId) {
output.WriteInt64(2, PlayerId);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCMemberFolw _inst = (GCMemberFolw) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoFolw = input.ReadInt32();
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
public class GCOPenTeamView : PacketDistributed
{

public const int membersFieldNumber = 1;
 private pbc::PopsicleList<TeamMember> members_ = new pbc::PopsicleList<TeamMember>();
 public scg::IList<TeamMember> membersList {
 get { return pbc::Lists.AsReadOnly(members_); }
 }
 
 public int membersCount {
 get { return members_.Count; }
 }
 
public TeamMember GetMembers(int index) {
 return members_[index];
 }
 public void AddMembers(TeamMember value) {
 members_.Add(value);
 }

public const int teamsFieldNumber = 2;
 private pbc::PopsicleList<TeamSampleInfo> teams_ = new pbc::PopsicleList<TeamSampleInfo>();
 public scg::IList<TeamSampleInfo> teamsList {
 get { return pbc::Lists.AsReadOnly(teams_); }
 }
 
 public int teamsCount {
 get { return teams_.Count; }
 }
 
public TeamSampleInfo GetTeams(int index) {
 return teams_[index];
 }
 public void AddTeams(TeamSampleInfo value) {
 teams_.Add(value);
 }

public const int autoAgreeFieldNumber = 3;
 private bool hasAutoAgree;
 private Int32 autoAgree_ = 0;
 public bool HasAutoAgree {
 get { return hasAutoAgree; }
 }
 public Int32 AutoAgree {
 get { return autoAgree_; }
 set { SetAutoAgree(value); }
 }
 public void SetAutoAgree(Int32 value) { 
 hasAutoAgree = true;
 autoAgree_ = value;
 }

public const int typeFieldNumber = 4;
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

public const int autoMateFieldNumber = 5;
 private bool hasAutoMate;
 private Int32 autoMate_ = 0;
 public bool HasAutoMate {
 get { return hasAutoMate; }
 }
 public Int32 AutoMate {
 get { return autoMate_; }
 set { SetAutoMate(value); }
 }
 public void SetAutoMate(Int32 value) { 
 hasAutoMate = true;
 autoMate_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (TeamMember element in membersList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
{
foreach (TeamSampleInfo element in teamsList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasAutoAgree) {
size += pb::CodedOutputStream.ComputeInt32Size(3, AutoAgree);
}
 if (HasType) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Type);
}
 if (HasAutoMate) {
size += pb::CodedOutputStream.ComputeInt32Size(5, AutoMate);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
 
do{
foreach (TeamMember element in membersList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);

do{
foreach (TeamSampleInfo element in teamsList) {
output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasAutoAgree) {
output.WriteInt32(3, AutoAgree);
}
 
if (HasType) {
output.WriteInt32(4, Type);
}
 
if (HasAutoMate) {
output.WriteInt32(5, AutoMate);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCOPenTeamView _inst = (GCOPenTeamView) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TeamMember subBuilder =  new TeamMember();
input.ReadMessage(subBuilder);
_inst.AddMembers(subBuilder);
break;
}
    case  18: {
TeamSampleInfo subBuilder =  new TeamSampleInfo();
input.ReadMessage(subBuilder);
_inst.AddTeams(subBuilder);
break;
}
   case  24: {
 _inst.AutoAgree = input.ReadInt32();
break;
}
   case  32: {
 _inst.Type = input.ReadInt32();
break;
}
   case  40: {
 _inst.AutoMate = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TeamMember element in membersList) {
if (!element.IsInitialized()) return false;
}
foreach (TeamSampleInfo element in teamsList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCQuickTeam : PacketDistributed
{

public const int autoQuickFieldNumber = 1;
 private bool hasAutoQuick;
 private Int32 autoQuick_ = 0;
 public bool HasAutoQuick {
 get { return hasAutoQuick; }
 }
 public Int32 AutoQuick {
 get { return autoQuick_; }
 set { SetAutoQuick(value); }
 }
 public void SetAutoQuick(Int32 value) { 
 hasAutoQuick = true;
 autoQuick_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoQuick) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoQuick);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoQuick) {
output.WriteInt32(1, AutoQuick);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCQuickTeam _inst = (GCQuickTeam) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoQuick = input.ReadInt32();
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
public class GCRefreashMyTeam : PacketDistributed
{

public const int teamInfoFieldNumber = 1;
 private bool hasTeamInfo;
 private TeamInfo teamInfo_ =  new TeamInfo();
 public bool HasTeamInfo {
 get { return hasTeamInfo; }
 }
 public TeamInfo TeamInfo {
 get { return teamInfo_; }
 set { SetTeamInfo(value); }
 }
 public void SetTeamInfo(TeamInfo value) { 
 hasTeamInfo = true;
 teamInfo_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
int subsize = TeamInfo.SerializedSize();	
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
output.WriteRawVarint32((uint)TeamInfo.SerializedSize());
TeamInfo.WriteTo(output);

}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRefreashMyTeam _inst = (GCRefreashMyTeam) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TeamInfo subBuilder =  new TeamInfo();
 input.ReadMessage(subBuilder);
_inst.TeamInfo = subBuilder;
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasTeamInfo) {
if (!TeamInfo.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class GCSetAutoAgree : PacketDistributed
{

public const int autoAgreeFieldNumber = 1;
 private bool hasAutoAgree;
 private Int32 autoAgree_ = 0;
 public bool HasAutoAgree {
 get { return hasAutoAgree; }
 }
 public Int32 AutoAgree {
 get { return autoAgree_; }
 set { SetAutoAgree(value); }
 }
 public void SetAutoAgree(Int32 value) { 
 hasAutoAgree = true;
 autoAgree_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasAutoAgree) {
size += pb::CodedOutputStream.ComputeInt32Size(1, AutoAgree);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasAutoAgree) {
output.WriteInt32(1, AutoAgree);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSetAutoAgree _inst = (GCSetAutoAgree) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.AutoAgree = input.ReadInt32();
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
public class GCSetTeamAuthority : PacketDistributed
{

public const int minLvFieldNumber = 1;
 private bool hasMinLv;
 private Int32 minLv_ = 0;
 public bool HasMinLv {
 get { return hasMinLv; }
 }
 public Int32 MinLv {
 get { return minLv_; }
 set { SetMinLv(value); }
 }
 public void SetMinLv(Int32 value) { 
 hasMinLv = true;
 minLv_ = value;
 }

public const int maxLvFieldNumber = 2;
 private bool hasMaxLv;
 private Int32 maxLv_ = 0;
 public bool HasMaxLv {
 get { return hasMaxLv; }
 }
 public Int32 MaxLv {
 get { return maxLv_; }
 set { SetMaxLv(value); }
 }
 public void SetMaxLv(Int32 value) { 
 hasMaxLv = true;
 maxLv_ = value;
 }

public const int minBattleNumberFieldNumber = 3;
 private bool hasMinBattleNumber;
 private Int32 minBattleNumber_ = 0;
 public bool HasMinBattleNumber {
 get { return hasMinBattleNumber; }
 }
 public Int32 MinBattleNumber {
 get { return minBattleNumber_; }
 set { SetMinBattleNumber(value); }
 }
 public void SetMinBattleNumber(Int32 value) { 
 hasMinBattleNumber = true;
 minBattleNumber_ = value;
 }

public const int targetIDFieldNumber = 4;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

public const int autoFollwFieldNumber = 5;
 private bool hasAutoFollw;
 private Int32 autoFollw_ = 0;
 public bool HasAutoFollw {
 get { return hasAutoFollw; }
 }
 public Int32 AutoFollw {
 get { return autoFollw_; }
 set { SetAutoFollw(value); }
 }
 public void SetAutoFollw(Int32 value) { 
 hasAutoFollw = true;
 autoFollw_ = value;
 }

public const int autoAgreeFieldNumber = 6;
 private bool hasAutoAgree;
 private Int32 autoAgree_ = 0;
 public bool HasAutoAgree {
 get { return hasAutoAgree; }
 }
 public Int32 AutoAgree {
 get { return autoAgree_; }
 set { SetAutoAgree(value); }
 }
 public void SetAutoAgree(Int32 value) { 
 hasAutoAgree = true;
 autoAgree_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasMinLv) {
size += pb::CodedOutputStream.ComputeInt32Size(1, MinLv);
}
 if (HasMaxLv) {
size += pb::CodedOutputStream.ComputeInt32Size(2, MaxLv);
}
 if (HasMinBattleNumber) {
size += pb::CodedOutputStream.ComputeInt32Size(3, MinBattleNumber);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(4, TargetID);
}
 if (HasAutoFollw) {
size += pb::CodedOutputStream.ComputeInt32Size(5, AutoFollw);
}
 if (HasAutoAgree) {
size += pb::CodedOutputStream.ComputeInt32Size(6, AutoAgree);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasMinLv) {
output.WriteInt32(1, MinLv);
}
 
if (HasMaxLv) {
output.WriteInt32(2, MaxLv);
}
 
if (HasMinBattleNumber) {
output.WriteInt32(3, MinBattleNumber);
}
 
if (HasTargetID) {
output.WriteInt32(4, TargetID);
}
 
if (HasAutoFollw) {
output.WriteInt32(5, AutoFollw);
}
 
if (HasAutoAgree) {
output.WriteInt32(6, AutoAgree);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCSetTeamAuthority _inst = (GCSetTeamAuthority) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.MinLv = input.ReadInt32();
break;
}
   case  16: {
 _inst.MaxLv = input.ReadInt32();
break;
}
   case  24: {
 _inst.MinBattleNumber = input.ReadInt32();
break;
}
   case  32: {
 _inst.TargetID = input.ReadInt32();
break;
}
   case  40: {
 _inst.AutoFollw = input.ReadInt32();
break;
}
   case  48: {
 _inst.AutoAgree = input.ReadInt32();
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
public class GCUpdateTeamMember : PacketDistributed
{

public const int memberFieldNumber = 1;
 private pbc::PopsicleList<TeamMember> member_ = new pbc::PopsicleList<TeamMember>();
 public scg::IList<TeamMember> memberList {
 get { return pbc::Lists.AsReadOnly(member_); }
 }
 
 public int memberCount {
 get { return member_.Count; }
 }
 
public TeamMember GetMember(int index) {
 return member_[index];
 }
 public void AddMember(TeamMember value) {
 member_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (TeamMember element in memberList) {
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
foreach (TeamMember element in memberList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCUpdateTeamMember _inst = (GCUpdateTeamMember) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
TeamMember subBuilder =  new TeamMember();
input.ReadMessage(subBuilder);
_inst.AddMember(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TeamMember element in memberList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TeamInfo : PacketDistributed
{

public const int teamIDFieldNumber = 1;
 private bool hasTeamID;
 private Int64 teamID_ = 0;
 public bool HasTeamID {
 get { return hasTeamID; }
 }
 public Int64 TeamID {
 get { return teamID_; }
 set { SetTeamID(value); }
 }
 public void SetTeamID(Int64 value) { 
 hasTeamID = true;
 teamID_ = value;
 }

public const int teamNameFieldNumber = 2;
 private bool hasTeamName;
 private string teamName_ = "";
 public bool HasTeamName {
 get { return hasTeamName; }
 }
 public string TeamName {
 get { return teamName_; }
 set { SetTeamName(value); }
 }
 public void SetTeamName(string value) { 
 hasTeamName = true;
 teamName_ = value;
 }

public const int memberInfoFieldNumber = 3;
 private pbc::PopsicleList<TeamMember> memberInfo_ = new pbc::PopsicleList<TeamMember>();
 public scg::IList<TeamMember> memberInfoList {
 get { return pbc::Lists.AsReadOnly(memberInfo_); }
 }
 
 public int memberInfoCount {
 get { return memberInfo_.Count; }
 }
 
public TeamMember GetMemberInfo(int index) {
 return memberInfo_[index];
 }
 public void AddMemberInfo(TeamMember value) {
 memberInfo_.Add(value);
 }

public const int captionIDFieldNumber = 4;
 private bool hasCaptionID;
 private Int64 captionID_ = 0;
 public bool HasCaptionID {
 get { return hasCaptionID; }
 }
 public Int64 CaptionID {
 get { return captionID_; }
 set { SetCaptionID(value); }
 }
 public void SetCaptionID(Int64 value) { 
 hasCaptionID = true;
 captionID_ = value;
 }

public const int targetIDFieldNumber = 5;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

public const int fightValueFieldNumber = 6;
 private bool hasFightValue;
 private Int32 fightValue_ = 0;
 public bool HasFightValue {
 get { return hasFightValue; }
 }
 public Int32 FightValue {
 get { return fightValue_; }
 set { SetFightValue(value); }
 }
 public void SetFightValue(Int32 value) { 
 hasFightValue = true;
 fightValue_ = value;
 }

public const int minFightFieldNumber = 7;
 private bool hasMinFight;
 private Int32 minFight_ = 0;
 public bool HasMinFight {
 get { return hasMinFight; }
 }
 public Int32 MinFight {
 get { return minFight_; }
 set { SetMinFight(value); }
 }
 public void SetMinFight(Int32 value) { 
 hasMinFight = true;
 minFight_ = value;
 }

public const int maxLevelFieldNumber = 8;
 private bool hasMaxLevel;
 private Int32 maxLevel_ = 0;
 public bool HasMaxLevel {
 get { return hasMaxLevel; }
 }
 public Int32 MaxLevel {
 get { return maxLevel_; }
 set { SetMaxLevel(value); }
 }
 public void SetMaxLevel(Int32 value) { 
 hasMaxLevel = true;
 maxLevel_ = value;
 }

public const int minLevelFieldNumber = 9;
 private bool hasMinLevel;
 private Int32 minLevel_ = 0;
 public bool HasMinLevel {
 get { return hasMinLevel; }
 }
 public Int32 MinLevel {
 get { return minLevel_; }
 set { SetMinLevel(value); }
 }
 public void SetMinLevel(Int32 value) { 
 hasMinLevel = true;
 minLevel_ = value;
 }

public const int isFollowFieldNumber = 10;
 private bool hasIsFollow;
 private Int32 isFollow_ = 0;
 public bool HasIsFollow {
 get { return hasIsFollow; }
 }
 public Int32 IsFollow {
 get { return isFollow_; }
 set { SetIsFollow(value); }
 }
 public void SetIsFollow(Int32 value) { 
 hasIsFollow = true;
 isFollow_ = value;
 }

public const int autoMateFieldNumber = 11;
 private bool hasAutoMate;
 private Int32 autoMate_ = 0;
 public bool HasAutoMate {
 get { return hasAutoMate; }
 }
 public Int32 AutoMate {
 get { return autoMate_; }
 set { SetAutoMate(value); }
 }
 public void SetAutoMate(Int32 value) { 
 hasAutoMate = true;
 autoMate_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTeamID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TeamID);
}
 if (HasTeamName) {
size += pb::CodedOutputStream.ComputeStringSize(2, TeamName);
}
{
foreach (TeamMember element in memberInfoList) {
int subsize = element.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
}
 if (HasCaptionID) {
size += pb::CodedOutputStream.ComputeInt64Size(4, CaptionID);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(5, TargetID);
}
 if (HasFightValue) {
size += pb::CodedOutputStream.ComputeInt32Size(6, FightValue);
}
 if (HasMinFight) {
size += pb::CodedOutputStream.ComputeInt32Size(7, MinFight);
}
 if (HasMaxLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(8, MaxLevel);
}
 if (HasMinLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(9, MinLevel);
}
 if (HasIsFollow) {
size += pb::CodedOutputStream.ComputeInt32Size(10, IsFollow);
}
 if (HasAutoMate) {
size += pb::CodedOutputStream.ComputeInt32Size(11, AutoMate);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTeamID) {
output.WriteInt64(1, TeamID);
}
 
if (HasTeamName) {
output.WriteString(2, TeamName);
}

do{
foreach (TeamMember element in memberInfoList) {
output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 
if (HasCaptionID) {
output.WriteInt64(4, CaptionID);
}
 
if (HasTargetID) {
output.WriteInt32(5, TargetID);
}
 
if (HasFightValue) {
output.WriteInt32(6, FightValue);
}
 
if (HasMinFight) {
output.WriteInt32(7, MinFight);
}
 
if (HasMaxLevel) {
output.WriteInt32(8, MaxLevel);
}
 
if (HasMinLevel) {
output.WriteInt32(9, MinLevel);
}
 
if (HasIsFollow) {
output.WriteInt32(10, IsFollow);
}
 
if (HasAutoMate) {
output.WriteInt32(11, AutoMate);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TeamInfo _inst = (TeamInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TeamID = input.ReadInt64();
break;
}
   case  18: {
 _inst.TeamName = input.ReadString();
break;
}
    case  26: {
TeamMember subBuilder =  new TeamMember();
input.ReadMessage(subBuilder);
_inst.AddMemberInfo(subBuilder);
break;
}
   case  32: {
 _inst.CaptionID = input.ReadInt64();
break;
}
   case  40: {
 _inst.TargetID = input.ReadInt32();
break;
}
   case  48: {
 _inst.FightValue = input.ReadInt32();
break;
}
   case  56: {
 _inst.MinFight = input.ReadInt32();
break;
}
   case  64: {
 _inst.MaxLevel = input.ReadInt32();
break;
}
   case  72: {
 _inst.MinLevel = input.ReadInt32();
break;
}
   case  80: {
 _inst.IsFollow = input.ReadInt32();
break;
}
   case  88: {
 _inst.AutoMate = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (TeamMember element in memberInfoList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TeamMember : PacketDistributed
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

public const int nickNameFieldNumber = 2;
 private bool hasNickName;
 private string nickName_ = "";
 public bool HasNickName {
 get { return hasNickName; }
 }
 public string NickName {
 get { return nickName_; }
 set { SetNickName(value); }
 }
 public void SetNickName(string value) { 
 hasNickName = true;
 nickName_ = value;
 }

public const int levelFieldNumber = 3;
 private bool hasLevel;
 private Int32 level_ = 0;
 public bool HasLevel {
 get { return hasLevel; }
 }
 public Int32 Level {
 get { return level_; }
 set { SetLevel(value); }
 }
 public void SetLevel(Int32 value) { 
 hasLevel = true;
 level_ = value;
 }

public const int fightValueFieldNumber = 4;
 private bool hasFightValue;
 private Int32 fightValue_ = 0;
 public bool HasFightValue {
 get { return hasFightValue; }
 }
 public Int32 FightValue {
 get { return fightValue_; }
 set { SetFightValue(value); }
 }
 public void SetFightValue(Int32 value) { 
 hasFightValue = true;
 fightValue_ = value;
 }

public const int onLineFieldNumber = 5;
 private bool hasOnLine;
 private Int32 onLine_ = 0;
 public bool HasOnLine {
 get { return hasOnLine; }
 }
 public Int32 OnLine {
 get { return onLine_; }
 set { SetOnLine(value); }
 }
 public void SetOnLine(Int32 value) { 
 hasOnLine = true;
 onLine_ = value;
 }

public const int professionIdFieldNumber = 6;
 private bool hasProfessionId;
 private Int32 professionId_ = 0;
 public bool HasProfessionId {
 get { return hasProfessionId; }
 }
 public Int32 ProfessionId {
 get { return professionId_; }
 set { SetProfessionId(value); }
 }
 public void SetProfessionId(Int32 value) { 
 hasProfessionId = true;
 professionId_ = value;
 }

public const int sexFieldNumber = 7;
 private bool hasSex;
 private Int32 sex_ = 0;
 public bool HasSex {
 get { return hasSex; }
 }
 public Int32 Sex {
 get { return sex_; }
 set { SetSex(value); }
 }
 public void SetSex(Int32 value) { 
 hasSex = true;
 sex_ = value;
 }

public const int isFollowFieldNumber = 8;
 private bool hasIsFollow;
 private Int32 isFollow_ = 0;
 public bool HasIsFollow {
 get { return hasIsFollow; }
 }
 public Int32 IsFollow {
 get { return isFollow_; }
 set { SetIsFollow(value); }
 }
 public void SetIsFollow(Int32 value) { 
 hasIsFollow = true;
 isFollow_ = value;
 }

public const int teamIDFieldNumber = 9;
 private bool hasTeamID;
 private Int64 teamID_ = 0;
 public bool HasTeamID {
 get { return hasTeamID; }
 }
 public Int64 TeamID {
 get { return teamID_; }
 set { SetTeamID(value); }
 }
 public void SetTeamID(Int64 value) { 
 hasTeamID = true;
 teamID_ = value;
 }

public const int hpFieldNumber = 10;
 private bool hasHp;
 private Int32 hp_ = 0;
 public bool HasHp {
 get { return hasHp; }
 }
 public Int32 Hp {
 get { return hp_; }
 set { SetHp(value); }
 }
 public void SetHp(Int32 value) { 
 hasHp = true;
 hp_ = value;
 }

public const int maxHpFieldNumber = 11;
 private bool hasMaxHp;
 private Int32 maxHp_ = 0;
 public bool HasMaxHp {
 get { return hasMaxHp; }
 }
 public Int32 MaxHp {
 get { return maxHp_; }
 set { SetMaxHp(value); }
 }
 public void SetMaxHp(Int32 value) { 
 hasMaxHp = true;
 maxHp_ = value;
 }

public const int iconidFieldNumber = 12;
 private bool hasIconid;
 private Int32 iconid_ = 0;
 public bool HasIconid {
 get { return hasIconid; }
 }
 public Int32 Iconid {
 get { return iconid_; }
 set { SetIconid(value); }
 }
 public void SetIconid(Int32 value) { 
 hasIconid = true;
 iconid_ = value;
 }

public const int changeEquipInfoFieldNumber = 13;
 private bool hasChangeEquipInfo;
 private ChangeEquipInfo changeEquipInfo_ =  new ChangeEquipInfo();
 public bool HasChangeEquipInfo {
 get { return hasChangeEquipInfo; }
 }
 public ChangeEquipInfo ChangeEquipInfo {
 get { return changeEquipInfo_; }
 set { SetChangeEquipInfo(value); }
 }
 public void SetChangeEquipInfo(ChangeEquipInfo value) { 
 hasChangeEquipInfo = true;
 changeEquipInfo_ = value;
 }

public const int posFieldNumber = 14;
 private bool hasPos;
 private Vector3Info pos_ =  new Vector3Info();
 public bool HasPos {
 get { return hasPos; }
 }
 public Vector3Info Pos {
 get { return pos_; }
 set { SetPos(value); }
 }
 public void SetPos(Vector3Info value) { 
 hasPos = true;
 pos_ = value;
 }

public const int sceneIDFieldNumber = 15;
 private bool hasSceneID;
 private Int32 sceneID_ = 0;
 public bool HasSceneID {
 get { return hasSceneID; }
 }
 public Int32 SceneID {
 get { return sceneID_; }
 set { SetSceneID(value); }
 }
 public void SetSceneID(Int32 value) { 
 hasSceneID = true;
 sceneID_ = value;
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
 if (HasNickName) {
size += pb::CodedOutputStream.ComputeStringSize(2, NickName);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
}
 if (HasFightValue) {
size += pb::CodedOutputStream.ComputeInt32Size(4, FightValue);
}
 if (HasOnLine) {
size += pb::CodedOutputStream.ComputeInt32Size(5, OnLine);
}
 if (HasProfessionId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ProfessionId);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(7, Sex);
}
 if (HasIsFollow) {
size += pb::CodedOutputStream.ComputeInt32Size(8, IsFollow);
}
 if (HasTeamID) {
size += pb::CodedOutputStream.ComputeInt64Size(9, TeamID);
}
 if (HasHp) {
size += pb::CodedOutputStream.ComputeInt32Size(10, Hp);
}
 if (HasMaxHp) {
size += pb::CodedOutputStream.ComputeInt32Size(11, MaxHp);
}
 if (HasIconid) {
size += pb::CodedOutputStream.ComputeInt32Size(12, Iconid);
}
{
int subsize = ChangeEquipInfo.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)13) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
{
int subsize = Pos.SerializedSize();	
size += pb::CodedOutputStream.ComputeTagSize((int)14) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
}
 if (HasSceneID) {
size += pb::CodedOutputStream.ComputeInt32Size(15, SceneID);
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
 
if (HasNickName) {
output.WriteString(2, NickName);
}
 
if (HasLevel) {
output.WriteInt32(3, Level);
}
 
if (HasFightValue) {
output.WriteInt32(4, FightValue);
}
 
if (HasOnLine) {
output.WriteInt32(5, OnLine);
}
 
if (HasProfessionId) {
output.WriteInt32(6, ProfessionId);
}
 
if (HasSex) {
output.WriteInt32(7, Sex);
}
 
if (HasIsFollow) {
output.WriteInt32(8, IsFollow);
}
 
if (HasTeamID) {
output.WriteInt64(9, TeamID);
}
 
if (HasHp) {
output.WriteInt32(10, Hp);
}
 
if (HasMaxHp) {
output.WriteInt32(11, MaxHp);
}
 
if (HasIconid) {
output.WriteInt32(12, Iconid);
}
{
output.WriteTag((int)13, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)ChangeEquipInfo.SerializedSize());
ChangeEquipInfo.WriteTo(output);

}
{
output.WriteTag((int)14, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)Pos.SerializedSize());
Pos.WriteTo(output);

}
 
if (HasSceneID) {
output.WriteInt32(15, SceneID);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TeamMember _inst = (TeamMember) _base;
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
   case  18: {
 _inst.NickName = input.ReadString();
break;
}
   case  24: {
 _inst.Level = input.ReadInt32();
break;
}
   case  32: {
 _inst.FightValue = input.ReadInt32();
break;
}
   case  40: {
 _inst.OnLine = input.ReadInt32();
break;
}
   case  48: {
 _inst.ProfessionId = input.ReadInt32();
break;
}
   case  56: {
 _inst.Sex = input.ReadInt32();
break;
}
   case  64: {
 _inst.IsFollow = input.ReadInt32();
break;
}
   case  72: {
 _inst.TeamID = input.ReadInt64();
break;
}
   case  80: {
 _inst.Hp = input.ReadInt32();
break;
}
   case  88: {
 _inst.MaxHp = input.ReadInt32();
break;
}
   case  96: {
 _inst.Iconid = input.ReadInt32();
break;
}
    case  106: {
ChangeEquipInfo subBuilder =  new ChangeEquipInfo();
 input.ReadMessage(subBuilder);
_inst.ChangeEquipInfo = subBuilder;
break;
}
    case  114: {
Vector3Info subBuilder =  new Vector3Info();
 input.ReadMessage(subBuilder);
_inst.Pos = subBuilder;
break;
}
   case  120: {
 _inst.SceneID = input.ReadInt32();
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
   if (HasChangeEquipInfo) {
if (!ChangeEquipInfo.IsInitialized()) return false;
}
  if (HasPos) {
if (!Pos.IsInitialized()) return false;
}
 return true;
 }

	}


[Serializable]
public class TeamSampleInfo : PacketDistributed
{

public const int teamIDFieldNumber = 1;
 private bool hasTeamID;
 private Int64 teamID_ = 0;
 public bool HasTeamID {
 get { return hasTeamID; }
 }
 public Int64 TeamID {
 get { return teamID_; }
 set { SetTeamID(value); }
 }
 public void SetTeamID(Int64 value) { 
 hasTeamID = true;
 teamID_ = value;
 }

public const int teamNameFieldNumber = 2;
 private bool hasTeamName;
 private string teamName_ = "";
 public bool HasTeamName {
 get { return hasTeamName; }
 }
 public string TeamName {
 get { return teamName_; }
 set { SetTeamName(value); }
 }
 public void SetTeamName(string value) { 
 hasTeamName = true;
 teamName_ = value;
 }

public const int numFieldNumber = 3;
 private bool hasNum;
 private Int32 num_ = 0;
 public bool HasNum {
 get { return hasNum; }
 }
 public Int32 Num {
 get { return num_; }
 set { SetNum(value); }
 }
 public void SetNum(Int32 value) { 
 hasNum = true;
 num_ = value;
 }

public const int levelFieldNumber = 4;
 private bool hasLevel;
 private Int32 level_ = 0;
 public bool HasLevel {
 get { return hasLevel; }
 }
 public Int32 Level {
 get { return level_; }
 set { SetLevel(value); }
 }
 public void SetLevel(Int32 value) { 
 hasLevel = true;
 level_ = value;
 }

public const int iconidFieldNumber = 5;
 private bool hasIconid;
 private Int32 iconid_ = 0;
 public bool HasIconid {
 get { return hasIconid; }
 }
 public Int32 Iconid {
 get { return iconid_; }
 set { SetIconid(value); }
 }
 public void SetIconid(Int32 value) { 
 hasIconid = true;
 iconid_ = value;
 }

public const int professionIdFieldNumber = 6;
 private bool hasProfessionId;
 private Int32 professionId_ = 0;
 public bool HasProfessionId {
 get { return hasProfessionId; }
 }
 public Int32 ProfessionId {
 get { return professionId_; }
 set { SetProfessionId(value); }
 }
 public void SetProfessionId(Int32 value) { 
 hasProfessionId = true;
 professionId_ = value;
 }

public const int isNearFieldNumber = 7;
 private bool hasIsNear;
 private Int32 isNear_ = 0;
 public bool HasIsNear {
 get { return hasIsNear; }
 }
 public Int32 IsNear {
 get { return isNear_; }
 set { SetIsNear(value); }
 }
 public void SetIsNear(Int32 value) { 
 hasIsNear = true;
 isNear_ = value;
 }

public const int targetIDFieldNumber = 8;
 private bool hasTargetID;
 private Int32 targetID_ = 0;
 public bool HasTargetID {
 get { return hasTargetID; }
 }
 public Int32 TargetID {
 get { return targetID_; }
 set { SetTargetID(value); }
 }
 public void SetTargetID(Int32 value) { 
 hasTargetID = true;
 targetID_ = value;
 }

public const int maxLevelFieldNumber = 9;
 private bool hasMaxLevel;
 private Int32 maxLevel_ = 0;
 public bool HasMaxLevel {
 get { return hasMaxLevel; }
 }
 public Int32 MaxLevel {
 get { return maxLevel_; }
 set { SetMaxLevel(value); }
 }
 public void SetMaxLevel(Int32 value) { 
 hasMaxLevel = true;
 maxLevel_ = value;
 }

public const int minLevelFieldNumber = 10;
 private bool hasMinLevel;
 private Int32 minLevel_ = 0;
 public bool HasMinLevel {
 get { return hasMinLevel; }
 }
 public Int32 MinLevel {
 get { return minLevel_; }
 set { SetMinLevel(value); }
 }
 public void SetMinLevel(Int32 value) { 
 hasMinLevel = true;
 minLevel_ = value;
 }

public const int sexFieldNumber = 11;
 private bool hasSex;
 private Int32 sex_ = 0;
 public bool HasSex {
 get { return hasSex; }
 }
 public Int32 Sex {
 get { return sex_; }
 set { SetSex(value); }
 }
 public void SetSex(Int32 value) { 
 hasSex = true;
 sex_ = value;
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
  if (HasTeamID) {
size += pb::CodedOutputStream.ComputeInt64Size(1, TeamID);
}
 if (HasTeamName) {
size += pb::CodedOutputStream.ComputeStringSize(2, TeamName);
}
 if (HasNum) {
size += pb::CodedOutputStream.ComputeInt32Size(3, Num);
}
 if (HasLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(4, Level);
}
 if (HasIconid) {
size += pb::CodedOutputStream.ComputeInt32Size(5, Iconid);
}
 if (HasProfessionId) {
size += pb::CodedOutputStream.ComputeInt32Size(6, ProfessionId);
}
 if (HasIsNear) {
size += pb::CodedOutputStream.ComputeInt32Size(7, IsNear);
}
 if (HasTargetID) {
size += pb::CodedOutputStream.ComputeInt32Size(8, TargetID);
}
 if (HasMaxLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(9, MaxLevel);
}
 if (HasMinLevel) {
size += pb::CodedOutputStream.ComputeInt32Size(10, MinLevel);
}
 if (HasSex) {
size += pb::CodedOutputStream.ComputeInt32Size(11, Sex);
}
 memoizedSerializedSize = size;
 return size;
 }

public override void WriteTo(pb::CodedOutputStream output)
 {
 int size = SerializedSize();
  
if (HasTeamID) {
output.WriteInt64(1, TeamID);
}
 
if (HasTeamName) {
output.WriteString(2, TeamName);
}
 
if (HasNum) {
output.WriteInt32(3, Num);
}
 
if (HasLevel) {
output.WriteInt32(4, Level);
}
 
if (HasIconid) {
output.WriteInt32(5, Iconid);
}
 
if (HasProfessionId) {
output.WriteInt32(6, ProfessionId);
}
 
if (HasIsNear) {
output.WriteInt32(7, IsNear);
}
 
if (HasTargetID) {
output.WriteInt32(8, TargetID);
}
 
if (HasMaxLevel) {
output.WriteInt32(9, MaxLevel);
}
 
if (HasMinLevel) {
output.WriteInt32(10, MinLevel);
}
 
if (HasSex) {
output.WriteInt32(11, Sex);
}
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 TeamSampleInfo _inst = (TeamSampleInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
    case  8: {
 _inst.TeamID = input.ReadInt64();
break;
}
   case  18: {
 _inst.TeamName = input.ReadString();
break;
}
   case  24: {
 _inst.Num = input.ReadInt32();
break;
}
   case  32: {
 _inst.Level = input.ReadInt32();
break;
}
   case  40: {
 _inst.Iconid = input.ReadInt32();
break;
}
   case  48: {
 _inst.ProfessionId = input.ReadInt32();
break;
}
   case  56: {
 _inst.IsNear = input.ReadInt32();
break;
}
   case  64: {
 _inst.TargetID = input.ReadInt32();
break;
}
   case  72: {
 _inst.MaxLevel = input.ReadInt32();
break;
}
   case  80: {
 _inst.MinLevel = input.ReadInt32();
break;
}
   case  88: {
 _inst.Sex = input.ReadInt32();
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
