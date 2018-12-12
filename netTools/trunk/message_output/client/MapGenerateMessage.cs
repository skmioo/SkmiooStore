//This code create by CodeEngine mile.com ,don't modify

using System;
 using scg = global::System.Collections.Generic;
 using pb = global::Google.ProtocolBuffers;
 using pbc = global::Google.ProtocolBuffers.Collections;
 #pragma warning disable

namespace com.mile.common.message
{

[Serializable]
public class GCRandomIslandInfo : PacketDistributed
{

public const int randomIslandFieldNumber = 1;
 private pbc::PopsicleList<RandomIsland> randomIsland_ = new pbc::PopsicleList<RandomIsland>();
 public scg::IList<RandomIsland> randomIslandList {
 get { return pbc::Lists.AsReadOnly(randomIsland_); }
 }
 
 public int randomIslandCount {
 get { return randomIsland_.Count; }
 }
 
public RandomIsland GetRandomIsland(int index) {
 return randomIsland_[index];
 }
 public void AddRandomIsland(RandomIsland value) {
 randomIsland_.Add(value);
 }

 private int memoizedSerializedSize = -1;
 public override int SerializedSize()
 {
 int size = memoizedSerializedSize;
 if (size != -1) return size;
 size = 0;
 {
foreach (RandomIsland element in randomIslandList) {
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
foreach (RandomIsland element in randomIslandList) {
output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
output.WriteRawVarint32((uint)element.SerializedSize());
element.WriteTo(output);

}
}while(false);
 }
public override PacketDistributed MergeFrom(pb::CodedInputStream input,PacketDistributed _base) {
 GCRandomIslandInfo _inst = (GCRandomIslandInfo) _base;
 while (true) {
 uint tag = input.ReadTag();
 switch (tag) {
 case 0:
 {
 return _inst;
 }
     case  10: {
RandomIsland subBuilder =  new RandomIsland();
input.ReadMessage(subBuilder);
_inst.AddRandomIsland(subBuilder);
break;
}

 }
 }
 return _inst;
 }
//end merged
public override bool IsInitialized() {
 foreach (RandomIsland element in randomIslandList) {
if (!element.IsInitialized()) return false;
}
 return true;
 }

	}


}
