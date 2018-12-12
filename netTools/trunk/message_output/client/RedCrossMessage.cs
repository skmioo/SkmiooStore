//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class GCBackRedCrossData : PacketDistributed
{

public const int redcrossFieldNumber = 1;
 private pbc::PopsicleList<RedCross> redcross_ = new pbc::PopsicleList<RedCross>();
 public scg::IList<RedCross> redcrossList {
 get { return pbc::Lists.AsReadOnly(redcross_); }
 }
 
 public int redcrossCount {
 get { return redcross_.Count; }
 }
 
public RedCross GetRedcross(int index) {
 return redcross_[index];
 }
 public void AddRedcross(RedCross value) {
 redcross_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RedCross element in redcrossList) {
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
foreach (RedCross element in redcrossList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCBackRedCrossData _inst = (GCBackRedCrossData) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RedCross subBuilder =  new RedCross();
input.ReadMessage(subBuilder);
_inst.AddRedcross(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RedCross element in redcrossList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
