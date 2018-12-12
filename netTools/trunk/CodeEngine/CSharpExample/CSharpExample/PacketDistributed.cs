using System.IO;
using System;
using System.Net.Sockets;
using Google.ProtocolBuffers;
using com.mile.qmqj.common.message;

    public abstract class PacketDistributed
    {
        public static PacketDistributed CreatePacket(MessageID packetID)
        {
            PacketDistributed packet = null;
            switch (packetID)
            {
                case MessageID.CS10002: { packet = new CS10002(); } break;
            }
            if (null != packet)
            {
                packet.packetID = packetID;
            }

            return packet;
        }
        public void SendPacket(Socket clientSocket)
        {

            using (MemoryStream stream = new MemoryStream())
            {
                byte[] sizes = ToByteArray();

                Int32 nlen = sizeof(int) + sizes.Length;
                BinaryWriter sw = new BinaryWriter(stream);

                Int32 netnlen = System.Net.IPAddress.HostToNetworkOrder(nlen);
                Int32 messageid = System.Net.IPAddress.HostToNetworkOrder((Int32)packetID);

                sw.Write(netnlen);
                sw.Write(messageid);
                sw.Write(sizes);
                sw.Flush();
                clientSocket.Send(stream.GetBuffer(), nlen + 4, SocketFlags.None);
                stream.Close();
            }

        }
        public byte[] ToByteArray()
        {
            //Check must init
            if (!IsInitialized())
            {
                throw InvalidProtocolBufferException.ErrorMsg("Request data have not set");
            }
            byte[] data = new byte[SerializedSize()];
            CodedOutputStream output = CodedOutputStream.CreateInstance(data);
            WriteTo(output);
            output.CheckNoSpaceLeft();
            return data;
        }
        public PacketDistributed ParseFrom(byte[] data)
        {
            CodedInputStream input = CodedInputStream.CreateInstance(data);
            PacketDistributed inst = MergeFrom(input,this);
            input.CheckLastTagWas(0);
            return inst;
        }

        public abstract int SerializedSize();
        public abstract void WriteTo(CodedOutputStream data);
        public abstract PacketDistributed MergeFrom(CodedInputStream input,PacketDistributed _Inst);
        public abstract bool IsInitialized();

        protected MessageID packetID;
    }

