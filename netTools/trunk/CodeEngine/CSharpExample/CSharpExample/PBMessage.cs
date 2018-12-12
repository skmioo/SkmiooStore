//This code create by CodeEngine mile.com ,don't modify

using System;
using scg = global::System.Collections.Generic;
using pb = global::Google.ProtocolBuffers;
using pbc = global::Google.ProtocolBuffers.Collections;


namespace com.mile.qmqj.common.message
{

    [Serializable]
    public class CS10000 : PacketDistributed
    {

        public const int commandIdFieldNumber = 1;
        private bool hasCommandId;
        private Int32 commandId_ = 0;
        public bool HasCommandId
        {
            get { return hasCommandId; }
        }
        public Int32 CommandId
        {
            get { return commandId_; }
            set { SetCommandId(value); }
        }
        public void SetCommandId(Int32 value)
        {
            hasCommandId = true;
            commandId_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasCommandId)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, CommandId);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasCommandId)
            {
                output.WriteInt32(1, CommandId);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10000 _inst = (CS10000)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.CommandId = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasCommandId) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10002 : PacketDistributed
    {

        public const int userNameFieldNumber = 1;
        private bool hasUserName;
        private string userName_ = "";
        public bool HasUserName
        {
            get { return hasUserName; }
        }
        public string UserName
        {
            get { return userName_; }
            set { SetUserName(value); }
        }
        public void SetUserName(string value)
        {
            hasUserName = true;
            userName_ = value;
        }

        public const int passwordFieldNumber = 2;
        private bool hasPassword;
        private string password_ = "";
        public bool HasPassword
        {
            get { return hasPassword; }
        }
        public string Password
        {
            get { return password_; }
            set { SetPassword(value); }
        }
        public void SetPassword(string value)
        {
            hasPassword = true;
            password_ = value;
        }

        public const int versionFieldNumber = 3;
        private bool hasVersion;
        private string version_ = "";
        public bool HasVersion
        {
            get { return hasVersion; }
        }
        public string Version
        {
            get { return version_; }
            set { SetVersion(value); }
        }
        public void SetVersion(string value)
        {
            hasVersion = true;
            version_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserName)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, UserName);
            }
            if (HasPassword)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Password);
            }
            if (HasVersion)
            {
                size += pb::CodedOutputStream.ComputeStringSize(3, Version);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserName)
            {
                output.WriteString(1, UserName);
            }

            if (HasPassword)
            {
                output.WriteString(2, Password);
            }

            if (HasVersion)
            {
                output.WriteString(3, Version);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10002 _inst = (CS10002)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.UserName = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Password = input.ReadString();
                            break;
                        }
                    case 26:
                        {
                            _inst.Version = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserName) return false;
            if (!hasPassword) return false;
            if (!hasVersion) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10005 : PacketDistributed
    {

        public const int actionTypeFieldNumber = 1;
        private bool hasActionType;
        private Int32 actionType_ = 0;
        public bool HasActionType
        {
            get { return hasActionType; }
        }
        public Int32 ActionType
        {
            get { return actionType_; }
            set { SetActionType(value); }
        }
        public void SetActionType(Int32 value)
        {
            hasActionType = true;
            actionType_ = value;
        }

        public const int userguidFieldNumber = 2;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int indexFieldNumber = 3;
        private bool hasIndex;
        private Int32 index_ = 0;
        public bool HasIndex
        {
            get { return hasIndex; }
        }
        public Int32 Index
        {
            get { return index_; }
            set { SetIndex(value); }
        }
        public void SetIndex(Int32 value)
        {
            hasIndex = true;
            index_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasActionType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, ActionType);
            }
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Userguid);
            }
            if (HasIndex)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Index);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasActionType)
            {
                output.WriteInt32(1, ActionType);
            }

            if (HasUserguid)
            {
                output.WriteString(2, Userguid);
            }

            if (HasIndex)
            {
                output.WriteInt32(3, Index);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10005 _inst = (CS10005)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.ActionType = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.Index = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasActionType) return false;
            if (!hasUserguid) return false;
            if (!hasIndex) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10006 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int indexFieldNumber = 2;
        private bool hasIndex;
        private string index_ = "";
        public bool HasIndex
        {
            get { return hasIndex; }
        }
        public string Index
        {
            get { return index_; }
            set { SetIndex(value); }
        }
        public void SetIndex(string value)
        {
            hasIndex = true;
            index_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasIndex)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Index);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasIndex)
            {
                output.WriteString(2, Index);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10006 _inst = (CS10006)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Index = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasIndex) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10007 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int indexFieldNumber = 2;
        private bool hasIndex;
        private Int32 index_ = 0;
        public bool HasIndex
        {
            get { return hasIndex; }
        }
        public Int32 Index
        {
            get { return index_; }
            set { SetIndex(value); }
        }
        public void SetIndex(Int32 value)
        {
            hasIndex = true;
            index_ = value;
        }

        public const int typeFieldNumber = 3;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasIndex)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Index);
            }
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasIndex)
            {
                output.WriteInt32(2, Index);
            }

            if (HasType)
            {
                output.WriteInt32(3, Type);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10007 _inst = (CS10007)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Index = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasIndex) return false;
            if (!hasType) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10009 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int indexFieldNumber = 2;
        private pbc::PopsicleList<Int32> index_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> indexList
        {
            get { return pbc::Lists.AsReadOnly(index_); }
        }

        public int indexCount
        {
            get { return index_.Count; }
        }

        public Int32 GetIndex(int index)
        {
            return index_[index];
        }
        public void AddIndex(Int32 value)
        {
            index_.Add(value);
        }

        public const int shipFieldNumber = 3;
        private pbc::PopsicleList<Int32> ship_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> shipList
        {
            get { return pbc::Lists.AsReadOnly(ship_); }
        }

        public int shipCount
        {
            get { return ship_.Count; }
        }

        public Int32 GetShip(int index)
        {
            return ship_[index];
        }
        public void AddShip(Int32 value)
        {
            ship_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            {
                int dataSize = 0;
                foreach (Int32 element in indexList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * index_.Count;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in shipList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * ship_.Count;
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }
            {
                if (index_.Count > 0)
                {
                    foreach (Int32 element in indexList)
                    {
                        output.WriteInt32(2, element);
                    }
                }

            }
            {
                if (ship_.Count > 0)
                {
                    foreach (Int32 element in shipList)
                    {
                        output.WriteInt32(3, element);
                    }
                }

            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10009 _inst = (CS10009)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.AddIndex(input.ReadInt32());
                            break;
                        }
                    case 24:
                        {
                            _inst.AddShip(input.ReadInt32());
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10010 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int shipguidFieldNumber = 2;
        private bool hasShipguid;
        private string shipguid_ = "";
        public bool HasShipguid
        {
            get { return hasShipguid; }
        }
        public string Shipguid
        {
            get { return shipguid_; }
            set { SetShipguid(value); }
        }
        public void SetShipguid(string value)
        {
            hasShipguid = true;
            shipguid_ = value;
        }

        public const int shipIdxFieldNumber = 3;
        private bool hasShipIdx;
        private Int32 shipIdx_ = 0;
        public bool HasShipIdx
        {
            get { return hasShipIdx; }
        }
        public Int32 ShipIdx
        {
            get { return shipIdx_; }
            set { SetShipIdx(value); }
        }
        public void SetShipIdx(Int32 value)
        {
            hasShipIdx = true;
            shipIdx_ = value;
        }

        public const int typeFieldNumber = 4;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasShipguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Shipguid);
            }
            if (HasShipIdx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, ShipIdx);
            }
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Type);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasShipguid)
            {
                output.WriteString(2, Shipguid);
            }

            if (HasShipIdx)
            {
                output.WriteInt32(3, ShipIdx);
            }

            if (HasType)
            {
                output.WriteInt32(4, Type);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10010 _inst = (CS10010)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Shipguid = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.ShipIdx = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasType) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10011 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int typeFieldNumber = 2;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        public const int priceFieldNumber = 3;
        private bool hasPrice;
        private Int32 price_ = 0;
        public bool HasPrice
        {
            get { return hasPrice; }
        }
        public Int32 Price
        {
            get { return price_; }
            set { SetPrice(value); }
        }
        public void SetPrice(Int32 value)
        {
            hasPrice = true;
            price_ = value;
        }

        public const int valueFieldNumber = 4;
        private bool hasValue;
        private Int32 value_ = 0;
        public bool HasValue
        {
            get { return hasValue; }
        }
        public Int32 Value
        {
            get { return value_; }
            set { SetValue(value); }
        }
        public void SetValue(Int32 value)
        {
            hasValue = true;
            value_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
            }
            if (HasPrice)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Price);
            }
            if (HasValue)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Value);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasType)
            {
                output.WriteInt32(2, Type);
            }

            if (HasPrice)
            {
                output.WriteInt32(3, Price);
            }

            if (HasValue)
            {
                output.WriteInt32(4, Value);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10011 _inst = (CS10011)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Price = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Value = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasType) return false;
            if (!hasPrice) return false;
            if (!hasValue) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10012 : PacketDistributed
    {

        public const int usernameFieldNumber = 1;
        private bool hasUsername;
        private string username_ = "";
        public bool HasUsername
        {
            get { return hasUsername; }
        }
        public string Username
        {
            get { return username_; }
            set { SetUsername(value); }
        }
        public void SetUsername(string value)
        {
            hasUsername = true;
            username_ = value;
        }

        public const int passwordFieldNumber = 2;
        private bool hasPassword;
        private string password_ = "";
        public bool HasPassword
        {
            get { return hasPassword; }
        }
        public string Password
        {
            get { return password_; }
            set { SetPassword(value); }
        }
        public void SetPassword(string value)
        {
            hasPassword = true;
            password_ = value;
        }

        public const int emailFieldNumber = 3;
        private bool hasEmail;
        private string email_ = "";
        public bool HasEmail
        {
            get { return hasEmail; }
        }
        public string Email
        {
            get { return email_; }
            set { SetEmail(value); }
        }
        public void SetEmail(string value)
        {
            hasEmail = true;
            email_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUsername)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Username);
            }
            if (HasPassword)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Password);
            }
            if (HasEmail)
            {
                size += pb::CodedOutputStream.ComputeStringSize(3, Email);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUsername)
            {
                output.WriteString(1, Username);
            }

            if (HasPassword)
            {
                output.WriteString(2, Password);
            }

            if (HasEmail)
            {
                output.WriteString(3, Email);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10012 _inst = (CS10012)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Username = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Password = input.ReadString();
                            break;
                        }
                    case 26:
                        {
                            _inst.Email = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUsername) return false;
            if (!hasPassword) return false;
            if (!hasEmail) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10013 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int itemguidFieldNumber = 2;
        private bool hasItemguid;
        private string itemguid_ = "";
        public bool HasItemguid
        {
            get { return hasItemguid; }
        }
        public string Itemguid
        {
            get { return itemguid_; }
            set { SetItemguid(value); }
        }
        public void SetItemguid(string value)
        {
            hasItemguid = true;
            itemguid_ = value;
        }

        public const int typeFieldNumber = 3;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        public const int item_idxFieldNumber = 4;
        private bool hasItem_idx;
        private Int32 item_idx_ = 0;
        public bool HasItem_idx
        {
            get { return hasItem_idx; }
        }
        public Int32 Item_idx
        {
            get { return item_idx_; }
            set { SetItem_idx(value); }
        }
        public void SetItem_idx(Int32 value)
        {
            hasItem_idx = true;
            item_idx_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasItemguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Itemguid);
            }
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Type);
            }
            if (HasItem_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Item_idx);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasItemguid)
            {
                output.WriteString(2, Itemguid);
            }

            if (HasType)
            {
                output.WriteInt32(3, Type);
            }

            if (HasItem_idx)
            {
                output.WriteInt32(4, Item_idx);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10013 _inst = (CS10013)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Itemguid = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Item_idx = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasType) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10101 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int map_idFieldNumber = 2;
        private bool hasMap_id;
        private Int32 map_id_ = 0;
        public bool HasMap_id
        {
            get { return hasMap_id; }
        }
        public Int32 Map_id
        {
            get { return map_id_; }
            set { SetMap_id(value); }
        }
        public void SetMap_id(Int32 value)
        {
            hasMap_id = true;
            map_id_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasMap_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Map_id);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasMap_id)
            {
                output.WriteInt32(2, Map_id);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10101 _inst = (CS10101)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Map_id = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasMap_id) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10102 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int battle_idFieldNumber = 2;
        private bool hasBattle_id;
        private Int32 battle_id_ = 0;
        public bool HasBattle_id
        {
            get { return hasBattle_id; }
        }
        public Int32 Battle_id
        {
            get { return battle_id_; }
            set { SetBattle_id(value); }
        }
        public void SetBattle_id(Int32 value)
        {
            hasBattle_id = true;
            battle_id_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasBattle_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Battle_id);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasBattle_id)
            {
                output.WriteInt32(2, Battle_id);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10102 _inst = (CS10102)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Battle_id = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasBattle_id) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10103 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int report_idFieldNumber = 2;
        private bool hasReport_id;
        private Int32 report_id_ = 0;
        public bool HasReport_id
        {
            get { return hasReport_id; }
        }
        public Int32 Report_id
        {
            get { return report_id_; }
            set { SetReport_id(value); }
        }
        public void SetReport_id(Int32 value)
        {
            hasReport_id = true;
            report_id_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasReport_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Report_id);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasReport_id)
            {
                output.WriteInt32(2, Report_id);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10103 _inst = (CS10103)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Report_id = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasReport_id) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10104 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int battle_idFieldNumber = 2;
        private bool hasBattle_id;
        private Int32 battle_id_ = 0;
        public bool HasBattle_id
        {
            get { return hasBattle_id; }
        }
        public Int32 Battle_id
        {
            get { return battle_id_; }
            set { SetBattle_id(value); }
        }
        public void SetBattle_id(Int32 value)
        {
            hasBattle_id = true;
            battle_id_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasBattle_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Battle_id);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasBattle_id)
            {
                output.WriteInt32(2, Battle_id);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10104 _inst = (CS10104)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Battle_id = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasBattle_id) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10105 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10105 _inst = (CS10105)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10201 : PacketDistributed
    {

        public const int senderFieldNumber = 1;
        private bool hasSender;
        private ChatInfo sender_ = new ChatInfo();
        public bool HasSender
        {
            get { return hasSender; }
        }
        public ChatInfo Sender
        {
            get { return sender_; }
            set { SetSender(value); }
        }
        public void SetSender(ChatInfo value)
        {
            hasSender = true;
            sender_ = value;
        }

        public const int chatstyleFieldNumber = 2;
        private bool hasChatstyle;
        private Int32 chatstyle_ = 0;
        public bool HasChatstyle
        {
            get { return hasChatstyle; }
        }
        public Int32 Chatstyle
        {
            get { return chatstyle_; }
            set { SetChatstyle(value); }
        }
        public void SetChatstyle(Int32 value)
        {
            hasChatstyle = true;
            chatstyle_ = value;
        }

        public const int chatcontentFieldNumber = 3;
        private bool hasChatcontent;
        private string chatcontent_ = "";
        public bool HasChatcontent
        {
            get { return hasChatcontent; }
        }
        public string Chatcontent
        {
            get { return chatcontent_; }
            set { SetChatcontent(value); }
        }
        public void SetChatcontent(string value)
        {
            hasChatcontent = true;
            chatcontent_ = value;
        }

        public const int reciverIDFieldNumber = 4;
        private bool hasReciverID;
        private string reciverID_ = "";
        public bool HasReciverID
        {
            get { return hasReciverID; }
        }
        public string ReciverID
        {
            get { return reciverID_; }
            set { SetReciverID(value); }
        }
        public void SetReciverID(string value)
        {
            hasReciverID = true;
            reciverID_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                int subsize = Sender.SerializedSize();
                size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
            }
            if (HasChatstyle)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Chatstyle);
            }
            if (HasChatcontent)
            {
                size += pb::CodedOutputStream.ComputeStringSize(3, Chatcontent);
            }
            if (HasReciverID)
            {
                size += pb::CodedOutputStream.ComputeStringSize(4, ReciverID);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();
            {
                output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
                output.WriteRawVarint32((uint)Sender.SerializedSize());
                Sender.WriteTo(output);

            }

            if (HasChatstyle)
            {
                output.WriteInt32(2, Chatstyle);
            }

            if (HasChatcontent)
            {
                output.WriteString(3, Chatcontent);
            }

            if (HasReciverID)
            {
                output.WriteString(4, ReciverID);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10201 _inst = (CS10201)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            ChatInfo subBuilder = new ChatInfo();
                            input.ReadMessage(subBuilder);
                            break;
                        }
                    case 16:
                        {
                            _inst.Chatstyle = input.ReadInt32();
                            break;
                        }
                    case 26:
                        {
                            _inst.Chatcontent = input.ReadString();
                            break;
                        }
                    case 34:
                        {
                            _inst.ReciverID = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (HasSender)
            {
                if (!Sender.IsInitialized()) return false;
            }
            if (!hasChatstyle) return false;
            if (!hasChatcontent) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10202 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10202 _inst = (CS10202)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10203 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10203 _inst = (CS10203)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            return true;
        }

    }


    [Serializable]
    public class CS10204 : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int itemguidFieldNumber = 2;
        private bool hasItemguid;
        private string itemguid_ = "";
        public bool HasItemguid
        {
            get { return hasItemguid; }
        }
        public string Itemguid
        {
            get { return itemguid_; }
            set { SetItemguid(value); }
        }
        public void SetItemguid(string value)
        {
            hasItemguid = true;
            itemguid_ = value;
        }

        public const int captainIdxFieldNumber = 3;
        private bool hasCaptainIdx;
        private Int32 captainIdx_ = 0;
        public bool HasCaptainIdx
        {
            get { return hasCaptainIdx; }
        }
        public Int32 CaptainIdx
        {
            get { return captainIdx_; }
            set { SetCaptainIdx(value); }
        }
        public void SetCaptainIdx(Int32 value)
        {
            hasCaptainIdx = true;
            captainIdx_ = value;
        }

        public const int captainPosFieldNumber = 4;
        private bool hasCaptainPos;
        private Int32 captainPos_ = 0;
        public bool HasCaptainPos
        {
            get { return hasCaptainPos; }
        }
        public Int32 CaptainPos
        {
            get { return captainPos_; }
            set { SetCaptainPos(value); }
        }
        public void SetCaptainPos(Int32 value)
        {
            hasCaptainPos = true;
            captainPos_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasItemguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Itemguid);
            }
            if (HasCaptainIdx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, CaptainIdx);
            }
            if (HasCaptainPos)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, CaptainPos);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasItemguid)
            {
                output.WriteString(2, Itemguid);
            }

            if (HasCaptainIdx)
            {
                output.WriteInt32(3, CaptainIdx);
            }

            if (HasCaptainPos)
            {
                output.WriteInt32(4, CaptainPos);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            CS10204 _inst = (CS10204)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Itemguid = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.CaptainIdx = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.CaptainPos = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasItemguid) return false;
            if (!hasCaptainIdx) return false;
            if (!hasCaptainPos) return false;
            return true;
        }

    }


    [Serializable]
    public class ChatInfo : PacketDistributed
    {

        public const int userguidFieldNumber = 1;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int nameFieldNumber = 2;
        private bool hasName;
        private string name_ = "";
        public bool HasName
        {
            get { return hasName; }
        }
        public string Name
        {
            get { return name_; }
            set { SetName(value); }
        }
        public void SetName(string value)
        {
            hasName = true;
            name_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Userguid);
            }
            if (HasName)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Name);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasUserguid)
            {
                output.WriteString(1, Userguid);
            }

            if (HasName)
            {
                output.WriteString(2, Name);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            ChatInfo _inst = (ChatInfo)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Name = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasUserguid) return false;
            if (!hasName) return false;
            return true;
        }

    }


    [Serializable]
    public class DataAction : PacketDistributed
    {

        public const int attacker_actionsFieldNumber = 1;
        private pbc::PopsicleList<DataSingleAction> attacker_actions_ = new pbc::PopsicleList<DataSingleAction>();
        public scg::IList<DataSingleAction> attacker_actionsList
        {
            get { return pbc::Lists.AsReadOnly(attacker_actions_); }
        }

        public int attacker_actionsCount
        {
            get { return attacker_actions_.Count; }
        }

        public DataSingleAction GetAttacker_actions(int index)
        {
            return attacker_actions_[index];
        }
        public void AddAttacker_actions(DataSingleAction value)
        {
            attacker_actions_.Add(value);
        }

        public const int be_attacker_actionsFieldNumber = 2;
        private pbc::PopsicleList<DataSingleAction> be_attacker_actions_ = new pbc::PopsicleList<DataSingleAction>();
        public scg::IList<DataSingleAction> be_attacker_actionsList
        {
            get { return pbc::Lists.AsReadOnly(be_attacker_actions_); }
        }

        public int be_attacker_actionsCount
        {
            get { return be_attacker_actions_.Count; }
        }

        public DataSingleAction GetBe_attacker_actions(int index)
        {
            return be_attacker_actions_[index];
        }
        public void AddBe_attacker_actions(DataSingleAction value)
        {
            be_attacker_actions_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                foreach (DataSingleAction element in attacker_actionsList)
                {
                    int subsize = element.SerializedSize();
                    size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
                }
            }
            {
                foreach (DataSingleAction element in be_attacker_actionsList)
                {
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

            do
            {
                foreach (DataSingleAction element in attacker_actionsList)
                {
                    output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);

            do
            {
                foreach (DataSingleAction element in be_attacker_actionsList)
                {
                    output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataAction _inst = (DataAction)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            DataSingleAction subBuilder = new DataSingleAction();
                            input.ReadMessage(subBuilder);
                            AddAttacker_actions(subBuilder);
                            break;
                        }
                    case 18:
                        {
                            DataSingleAction subBuilder = new DataSingleAction();
                            input.ReadMessage(subBuilder);
                            AddBe_attacker_actions(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            foreach (DataSingleAction element in attacker_actionsList)
            {
                if (!element.IsInitialized()) return false;
            }
            foreach (DataSingleAction element in be_attacker_actionsList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class DataBattle : PacketDistributed
    {

        public const int roundsFieldNumber = 1;
        private pbc::PopsicleList<DataRound> rounds_ = new pbc::PopsicleList<DataRound>();
        public scg::IList<DataRound> roundsList
        {
            get { return pbc::Lists.AsReadOnly(rounds_); }
        }

        public int roundsCount
        {
            get { return rounds_.Count; }
        }

        public DataRound GetRounds(int index)
        {
            return rounds_[index];
        }
        public void AddRounds(DataRound value)
        {
            rounds_.Add(value);
        }

        public const int attacker_nameFieldNumber = 2;
        private bool hasAttacker_name;
        private string attacker_name_ = "";
        public bool HasAttacker_name
        {
            get { return hasAttacker_name; }
        }
        public string Attacker_name
        {
            get { return attacker_name_; }
            set { SetAttacker_name(value); }
        }
        public void SetAttacker_name(string value)
        {
            hasAttacker_name = true;
            attacker_name_ = value;
        }

        public const int be_attacker_nameFieldNumber = 3;
        private bool hasBe_attacker_name;
        private string be_attacker_name_ = "";
        public bool HasBe_attacker_name
        {
            get { return hasBe_attacker_name; }
        }
        public string Be_attacker_name
        {
            get { return be_attacker_name_; }
            set { SetBe_attacker_name(value); }
        }
        public void SetBe_attacker_name(string value)
        {
            hasBe_attacker_name = true;
            be_attacker_name_ = value;
        }

        public const int win_idxFieldNumber = 4;
        private bool hasWin_idx;
        private Int32 win_idx_ = 0;
        public bool HasWin_idx
        {
            get { return hasWin_idx; }
        }
        public Int32 Win_idx
        {
            get { return win_idx_; }
            set { SetWin_idx(value); }
        }
        public void SetWin_idx(Int32 value)
        {
            hasWin_idx = true;
            win_idx_ = value;
        }

        public const int item_idxFieldNumber = 5;
        private bool hasItem_idx;
        private Int32 item_idx_ = 0;
        public bool HasItem_idx
        {
            get { return hasItem_idx; }
        }
        public Int32 Item_idx
        {
            get { return item_idx_; }
            set { SetItem_idx(value); }
        }
        public void SetItem_idx(Int32 value)
        {
            hasItem_idx = true;
            item_idx_ = value;
        }

        public const int attacker_lostFieldNumber = 6;
        private bool hasAttacker_lost;
        private Int32 attacker_lost_ = 0;
        public bool HasAttacker_lost
        {
            get { return hasAttacker_lost; }
        }
        public Int32 Attacker_lost
        {
            get { return attacker_lost_; }
            set { SetAttacker_lost(value); }
        }
        public void SetAttacker_lost(Int32 value)
        {
            hasAttacker_lost = true;
            attacker_lost_ = value;
        }

        public const int be_attacker_lostFieldNumber = 7;
        private bool hasBe_attacker_lost;
        private Int32 be_attacker_lost_ = 0;
        public bool HasBe_attacker_lost
        {
            get { return hasBe_attacker_lost; }
        }
        public Int32 Be_attacker_lost
        {
            get { return be_attacker_lost_; }
            set { SetBe_attacker_lost(value); }
        }
        public void SetBe_attacker_lost(Int32 value)
        {
            hasBe_attacker_lost = true;
            be_attacker_lost_ = value;
        }

        public const int moneyFieldNumber = 8;
        private bool hasMoney;
        private Int32 money_ = 0;
        public bool HasMoney
        {
            get { return hasMoney; }
        }
        public Int32 Money
        {
            get { return money_; }
            set { SetMoney(value); }
        }
        public void SetMoney(Int32 value)
        {
            hasMoney = true;
            money_ = value;
        }

        public const int map_idxFieldNumber = 9;
        private bool hasMap_idx;
        private Int32 map_idx_ = 0;
        public bool HasMap_idx
        {
            get { return hasMap_idx; }
        }
        public Int32 Map_idx
        {
            get { return map_idx_; }
            set { SetMap_idx(value); }
        }
        public void SetMap_idx(Int32 value)
        {
            hasMap_idx = true;
            map_idx_ = value;
        }

        public const int shipsFieldNumber = 10;
        private pbc::PopsicleList<DataShip> ships_ = new pbc::PopsicleList<DataShip>();
        public scg::IList<DataShip> shipsList
        {
            get { return pbc::Lists.AsReadOnly(ships_); }
        }

        public int shipsCount
        {
            get { return ships_.Count; }
        }

        public DataShip GetShips(int index)
        {
            return ships_[index];
        }
        public void AddShips(DataShip value)
        {
            ships_.Add(value);
        }

        public const int honourFieldNumber = 11;
        private bool hasHonour;
        private Int32 honour_ = 0;
        public bool HasHonour
        {
            get { return hasHonour; }
        }
        public Int32 Honour
        {
            get { return honour_; }
            set { SetHonour(value); }
        }
        public void SetHonour(Int32 value)
        {
            hasHonour = true;
            honour_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                foreach (DataRound element in roundsList)
                {
                    int subsize = element.SerializedSize();
                    size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
                }
            }
            if (HasAttacker_name)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Attacker_name);
            }
            if (HasBe_attacker_name)
            {
                size += pb::CodedOutputStream.ComputeStringSize(3, Be_attacker_name);
            }
            if (HasWin_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Win_idx);
            }
            if (HasItem_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Item_idx);
            }
            if (HasAttacker_lost)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, Attacker_lost);
            }
            if (HasBe_attacker_lost)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(7, Be_attacker_lost);
            }
            if (HasMoney)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(8, Money);
            }
            if (HasMap_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(9, Map_idx);
            }
            {
                foreach (DataShip element in shipsList)
                {
                    int subsize = element.SerializedSize();
                    size += pb::CodedOutputStream.ComputeTagSize((int)10) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
                }
            }
            if (HasHonour)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(11, Honour);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            do
            {
                foreach (DataRound element in roundsList)
                {
                    output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);

            if (HasAttacker_name)
            {
                output.WriteString(2, Attacker_name);
            }

            if (HasBe_attacker_name)
            {
                output.WriteString(3, Be_attacker_name);
            }

            if (HasWin_idx)
            {
                output.WriteInt32(4, Win_idx);
            }

            if (HasItem_idx)
            {
                output.WriteInt32(5, Item_idx);
            }

            if (HasAttacker_lost)
            {
                output.WriteInt32(6, Attacker_lost);
            }

            if (HasBe_attacker_lost)
            {
                output.WriteInt32(7, Be_attacker_lost);
            }

            if (HasMoney)
            {
                output.WriteInt32(8, Money);
            }

            if (HasMap_idx)
            {
                output.WriteInt32(9, Map_idx);
            }

            do
            {
                foreach (DataShip element in shipsList)
                {
                    output.WriteTag((int)10, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);

            if (HasHonour)
            {
                output.WriteInt32(11, Honour);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataBattle _inst = (DataBattle)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            DataRound subBuilder = new DataRound();
                            input.ReadMessage(subBuilder);
                            AddRounds(subBuilder);
                            break;
                        }
                    case 18:
                        {
                            _inst.Attacker_name = input.ReadString();
                            break;
                        }
                    case 26:
                        {
                            _inst.Be_attacker_name = input.ReadString();
                            break;
                        }
                    case 32:
                        {
                            _inst.Win_idx = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Item_idx = input.ReadInt32();
                            break;
                        }
                    case 48:
                        {
                            _inst.Attacker_lost = input.ReadInt32();
                            break;
                        }
                    case 56:
                        {
                            _inst.Be_attacker_lost = input.ReadInt32();
                            break;
                        }
                    case 64:
                        {
                            _inst.Money = input.ReadInt32();
                            break;
                        }
                    case 72:
                        {
                            _inst.Map_idx = input.ReadInt32();
                            break;
                        }
                    case 82:
                        {
                            DataShip subBuilder = new DataShip();
                            input.ReadMessage(subBuilder);
                            AddShips(subBuilder);
                            break;
                        }
                    case 88:
                        {
                            _inst.Honour = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            foreach (DataRound element in roundsList)
            {
                if (!element.IsInitialized()) return false;
            }
            if (!hasAttacker_name) return false;
            if (!hasBe_attacker_name) return false;
            if (!hasWin_idx) return false;
            if (!hasItem_idx) return false;
            if (!hasAttacker_lost) return false;
            if (!hasBe_attacker_lost) return false;
            if (!hasMoney) return false;
            if (!hasMap_idx) return false;
            foreach (DataShip element in shipsList)
            {
                if (!element.IsInitialized()) return false;
            }
            if (!hasHonour) return false;
            return true;
        }

    }


    [Serializable]
    public class DataBattleInfo : PacketDistributed
    {

        public const int battle_idFieldNumber = 1;
        private bool hasBattle_id;
        private Int32 battle_id_ = 0;
        public bool HasBattle_id
        {
            get { return hasBattle_id; }
        }
        public Int32 Battle_id
        {
            get { return battle_id_; }
            set { SetBattle_id(value); }
        }
        public void SetBattle_id(Int32 value)
        {
            hasBattle_id = true;
            battle_id_ = value;
        }

        public const int statusFieldNumber = 2;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasBattle_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Battle_id);
            }
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasBattle_id)
            {
                output.WriteInt32(1, Battle_id);
            }

            if (HasStatus)
            {
                output.WriteInt32(2, Status);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataBattleInfo _inst = (DataBattleInfo)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Battle_id = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasBattle_id) return false;
            if (!hasStatus) return false;
            return true;
        }

    }


    [Serializable]
    public class DataCaptain : PacketDistributed
    {

        public const int captainIdFieldNumber = 1;
        private bool hasCaptainId;
        private Int32 captainId_ = 0;
        public bool HasCaptainId
        {
            get { return hasCaptainId; }
        }
        public Int32 CaptainId
        {
            get { return captainId_; }
            set { SetCaptainId(value); }
        }
        public void SetCaptainId(Int32 value)
        {
            hasCaptainId = true;
            captainId_ = value;
        }

        public const int captainLevelFieldNumber = 2;
        private bool hasCaptainLevel;
        private Int32 captainLevel_ = 0;
        public bool HasCaptainLevel
        {
            get { return hasCaptainLevel; }
        }
        public Int32 CaptainLevel
        {
            get { return captainLevel_; }
            set { SetCaptainLevel(value); }
        }
        public void SetCaptainLevel(Int32 value)
        {
            hasCaptainLevel = true;
            captainLevel_ = value;
        }

        public const int captainStatusFieldNumber = 3;
        private bool hasCaptainStatus;
        private Int32 captainStatus_ = 0;
        public bool HasCaptainStatus
        {
            get { return hasCaptainStatus; }
        }
        public Int32 CaptainStatus
        {
            get { return captainStatus_; }
            set { SetCaptainStatus(value); }
        }
        public void SetCaptainStatus(Int32 value)
        {
            hasCaptainStatus = true;
            captainStatus_ = value;
        }

        public const int captainexpFieldNumber = 4;
        private bool hasCaptainexp;
        private Int32 captainexp_ = 0;
        public bool HasCaptainexp
        {
            get { return hasCaptainexp; }
        }
        public Int32 Captainexp
        {
            get { return captainexp_; }
            set { SetCaptainexp(value); }
        }
        public void SetCaptainexp(Int32 value)
        {
            hasCaptainexp = true;
            captainexp_ = value;
        }

        public const int fightFieldNumber = 5;
        private bool hasFight;
        private Int32 fight_ = 0;
        public bool HasFight
        {
            get { return hasFight; }
        }
        public Int32 Fight
        {
            get { return fight_; }
            set { SetFight(value); }
        }
        public void SetFight(Int32 value)
        {
            hasFight = true;
            fight_ = value;
        }

        public const int artilleryFieldNumber = 6;
        private bool hasArtillery;
        private Int32 artillery_ = 0;
        public bool HasArtillery
        {
            get { return hasArtillery; }
        }
        public Int32 Artillery
        {
            get { return artillery_; }
            set { SetArtillery(value); }
        }
        public void SetArtillery(Int32 value)
        {
            hasArtillery = true;
            artillery_ = value;
        }

        public const int strategyFieldNumber = 7;
        private bool hasStrategy;
        private Int32 strategy_ = 0;
        public bool HasStrategy
        {
            get { return hasStrategy; }
        }
        public Int32 Strategy
        {
            get { return strategy_; }
            set { SetStrategy(value); }
        }
        public void SetStrategy(Int32 value)
        {
            hasStrategy = true;
            strategy_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasCaptainId)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, CaptainId);
            }
            if (HasCaptainLevel)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, CaptainLevel);
            }
            if (HasCaptainStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, CaptainStatus);
            }
            if (HasCaptainexp)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Captainexp);
            }
            if (HasFight)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Fight);
            }
            if (HasArtillery)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, Artillery);
            }
            if (HasStrategy)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(7, Strategy);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasCaptainId)
            {
                output.WriteInt32(1, CaptainId);
            }

            if (HasCaptainLevel)
            {
                output.WriteInt32(2, CaptainLevel);
            }

            if (HasCaptainStatus)
            {
                output.WriteInt32(3, CaptainStatus);
            }

            if (HasCaptainexp)
            {
                output.WriteInt32(4, Captainexp);
            }

            if (HasFight)
            {
                output.WriteInt32(5, Fight);
            }

            if (HasArtillery)
            {
                output.WriteInt32(6, Artillery);
            }

            if (HasStrategy)
            {
                output.WriteInt32(7, Strategy);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataCaptain _inst = (DataCaptain)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.CaptainId = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.CaptainLevel = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.CaptainStatus = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Captainexp = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Fight = input.ReadInt32();
                            break;
                        }
                    case 48:
                        {
                            _inst.Artillery = input.ReadInt32();
                            break;
                        }
                    case 56:
                        {
                            _inst.Strategy = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasCaptainId) return false;
            if (!hasCaptainLevel) return false;
            if (!hasCaptainStatus) return false;
            if (!hasCaptainexp) return false;
            if (!hasFight) return false;
            if (!hasArtillery) return false;
            if (!hasStrategy) return false;
            return true;
        }

    }


    [Serializable]
    public class DataItemMessage : PacketDistributed
    {

        public const int itemguidFieldNumber = 1;
        private bool hasItemguid;
        private string itemguid_ = "";
        public bool HasItemguid
        {
            get { return hasItemguid; }
        }
        public string Itemguid
        {
            get { return itemguid_; }
            set { SetItemguid(value); }
        }
        public void SetItemguid(string value)
        {
            hasItemguid = true;
            itemguid_ = value;
        }

        public const int itemidFieldNumber = 2;
        private bool hasItemid;
        private Int32 itemid_ = 0;
        public bool HasItemid
        {
            get { return hasItemid; }
        }
        public Int32 Itemid
        {
            get { return itemid_; }
            set { SetItemid(value); }
        }
        public void SetItemid(Int32 value)
        {
            hasItemid = true;
            itemid_ = value;
        }

        public const int levelFieldNumber = 3;
        private bool hasLevel;
        private Int32 level_ = 0;
        public bool HasLevel
        {
            get { return hasLevel; }
        }
        public Int32 Level
        {
            get { return level_; }
            set { SetLevel(value); }
        }
        public void SetLevel(Int32 value)
        {
            hasLevel = true;
            level_ = value;
        }

        public const int captainIdxFieldNumber = 4;
        private bool hasCaptainIdx;
        private Int32 captainIdx_ = 0;
        public bool HasCaptainIdx
        {
            get { return hasCaptainIdx; }
        }
        public Int32 CaptainIdx
        {
            get { return captainIdx_; }
            set { SetCaptainIdx(value); }
        }
        public void SetCaptainIdx(Int32 value)
        {
            hasCaptainIdx = true;
            captainIdx_ = value;
        }

        public const int basic_attackFieldNumber = 5;
        private bool hasBasic_attack;
        private Int32 basic_attack_ = 0;
        public bool HasBasic_attack
        {
            get { return hasBasic_attack; }
        }
        public Int32 Basic_attack
        {
            get { return basic_attack_; }
            set { SetBasic_attack(value); }
        }
        public void SetBasic_attack(Int32 value)
        {
            hasBasic_attack = true;
            basic_attack_ = value;
        }

        public const int basic_defenceFieldNumber = 6;
        private bool hasBasic_defence;
        private Int32 basic_defence_ = 0;
        public bool HasBasic_defence
        {
            get { return hasBasic_defence; }
        }
        public Int32 Basic_defence
        {
            get { return basic_defence_; }
            set { SetBasic_defence(value); }
        }
        public void SetBasic_defence(Int32 value)
        {
            hasBasic_defence = true;
            basic_defence_ = value;
        }

        public const int melee_attFieldNumber = 7;
        private bool hasMelee_att;
        private Int32 melee_att_ = 0;
        public bool HasMelee_att
        {
            get { return hasMelee_att; }
        }
        public Int32 Melee_att
        {
            get { return melee_att_; }
            set { SetMelee_att(value); }
        }
        public void SetMelee_att(Int32 value)
        {
            hasMelee_att = true;
            melee_att_ = value;
        }

        public const int melee_defFieldNumber = 8;
        private bool hasMelee_def;
        private Int32 melee_def_ = 0;
        public bool HasMelee_def
        {
            get { return hasMelee_def; }
        }
        public Int32 Melee_def
        {
            get { return melee_def_; }
            set { SetMelee_def(value); }
        }
        public void SetMelee_def(Int32 value)
        {
            hasMelee_def = true;
            melee_def_ = value;
        }

        public const int range_attFieldNumber = 9;
        private bool hasRange_att;
        private Int32 range_att_ = 0;
        public bool HasRange_att
        {
            get { return hasRange_att; }
        }
        public Int32 Range_att
        {
            get { return range_att_; }
            set { SetRange_att(value); }
        }
        public void SetRange_att(Int32 value)
        {
            hasRange_att = true;
            range_att_ = value;
        }

        public const int range_defFieldNumber = 10;
        private bool hasRange_def;
        private Int32 range_def_ = 0;
        public bool HasRange_def
        {
            get { return hasRange_def; }
        }
        public Int32 Range_def
        {
            get { return range_def_; }
            set { SetRange_def(value); }
        }
        public void SetRange_def(Int32 value)
        {
            hasRange_def = true;
            range_def_ = value;
        }

        public const int magic_attFieldNumber = 11;
        private bool hasMagic_att;
        private Int32 magic_att_ = 0;
        public bool HasMagic_att
        {
            get { return hasMagic_att; }
        }
        public Int32 Magic_att
        {
            get { return magic_att_; }
            set { SetMagic_att(value); }
        }
        public void SetMagic_att(Int32 value)
        {
            hasMagic_att = true;
            magic_att_ = value;
        }

        public const int magic_defFieldNumber = 12;
        private bool hasMagic_def;
        private Int32 magic_def_ = 0;
        public bool HasMagic_def
        {
            get { return hasMagic_def; }
        }
        public Int32 Magic_def
        {
            get { return magic_def_; }
            set { SetMagic_def(value); }
        }
        public void SetMagic_def(Int32 value)
        {
            hasMagic_def = true;
            magic_def_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasItemguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Itemguid);
            }
            if (HasItemid)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Itemid);
            }
            if (HasLevel)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
            }
            if (HasCaptainIdx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, CaptainIdx);
            }
            if (HasBasic_attack)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Basic_attack);
            }
            if (HasBasic_defence)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, Basic_defence);
            }
            if (HasMelee_att)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(7, Melee_att);
            }
            if (HasMelee_def)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(8, Melee_def);
            }
            if (HasRange_att)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(9, Range_att);
            }
            if (HasRange_def)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(10, Range_def);
            }
            if (HasMagic_att)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(11, Magic_att);
            }
            if (HasMagic_def)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(12, Magic_def);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasItemguid)
            {
                output.WriteString(1, Itemguid);
            }

            if (HasItemid)
            {
                output.WriteInt32(2, Itemid);
            }

            if (HasLevel)
            {
                output.WriteInt32(3, Level);
            }

            if (HasCaptainIdx)
            {
                output.WriteInt32(4, CaptainIdx);
            }

            if (HasBasic_attack)
            {
                output.WriteInt32(5, Basic_attack);
            }

            if (HasBasic_defence)
            {
                output.WriteInt32(6, Basic_defence);
            }

            if (HasMelee_att)
            {
                output.WriteInt32(7, Melee_att);
            }

            if (HasMelee_def)
            {
                output.WriteInt32(8, Melee_def);
            }

            if (HasRange_att)
            {
                output.WriteInt32(9, Range_att);
            }

            if (HasRange_def)
            {
                output.WriteInt32(10, Range_def);
            }

            if (HasMagic_att)
            {
                output.WriteInt32(11, Magic_att);
            }

            if (HasMagic_def)
            {
                output.WriteInt32(12, Magic_def);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataItemMessage _inst = (DataItemMessage)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Itemguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Itemid = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Level = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.CaptainIdx = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Basic_attack = input.ReadInt32();
                            break;
                        }
                    case 48:
                        {
                            _inst.Basic_defence = input.ReadInt32();
                            break;
                        }
                    case 56:
                        {
                            _inst.Melee_att = input.ReadInt32();
                            break;
                        }
                    case 64:
                        {
                            _inst.Melee_def = input.ReadInt32();
                            break;
                        }
                    case 72:
                        {
                            _inst.Range_att = input.ReadInt32();
                            break;
                        }
                    case 80:
                        {
                            _inst.Range_def = input.ReadInt32();
                            break;
                        }
                    case 88:
                        {
                            _inst.Magic_att = input.ReadInt32();
                            break;
                        }
                    case 96:
                        {
                            _inst.Magic_def = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasItemguid) return false;
            if (!hasItemid) return false;
            if (!hasLevel) return false;
            if (!hasCaptainIdx) return false;
            return true;
        }

    }


    [Serializable]
    public class DataReport : PacketDistributed
    {

        public const int report_idFieldNumber = 1;
        private bool hasReport_id;
        private Int32 report_id_ = 0;
        public bool HasReport_id
        {
            get { return hasReport_id; }
        }
        public Int32 Report_id
        {
            get { return report_id_; }
            set { SetReport_id(value); }
        }
        public void SetReport_id(Int32 value)
        {
            hasReport_id = true;
            report_id_ = value;
        }

        public const int nameFieldNumber = 2;
        private bool hasName;
        private string name_ = "";
        public bool HasName
        {
            get { return hasName; }
        }
        public string Name
        {
            get { return name_; }
            set { SetName(value); }
        }
        public void SetName(string value)
        {
            hasName = true;
            name_ = value;
        }

        public const int levelFieldNumber = 3;
        private bool hasLevel;
        private Int32 level_ = 0;
        public bool HasLevel
        {
            get { return hasLevel; }
        }
        public Int32 Level
        {
            get { return level_; }
            set { SetLevel(value); }
        }
        public void SetLevel(Int32 value)
        {
            hasLevel = true;
            level_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasReport_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Report_id);
            }
            if (HasName)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Name);
            }
            if (HasLevel)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasReport_id)
            {
                output.WriteInt32(1, Report_id);
            }

            if (HasName)
            {
                output.WriteString(2, Name);
            }

            if (HasLevel)
            {
                output.WriteInt32(3, Level);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataReport _inst = (DataReport)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Report_id = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            _inst.Name = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.Level = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasReport_id) return false;
            if (!hasName) return false;
            if (!hasLevel) return false;
            return true;
        }

    }


    [Serializable]
    public class DataRound : PacketDistributed
    {

        public const int actionsFieldNumber = 1;
        private pbc::PopsicleList<DataAction> actions_ = new pbc::PopsicleList<DataAction>();
        public scg::IList<DataAction> actionsList
        {
            get { return pbc::Lists.AsReadOnly(actions_); }
        }

        public int actionsCount
        {
            get { return actions_.Count; }
        }

        public DataAction GetActions(int index)
        {
            return actions_[index];
        }
        public void AddActions(DataAction value)
        {
            actions_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                foreach (DataAction element in actionsList)
                {
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

            do
            {
                foreach (DataAction element in actionsList)
                {
                    output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataRound _inst = (DataRound)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            DataAction subBuilder = new DataAction();
                            input.ReadMessage(subBuilder);
                            AddActions(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            foreach (DataAction element in actionsList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class DataShip : PacketDistributed
    {

        public const int typeFieldNumber = 1;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        public const int hpFieldNumber = 2;
        private bool hasHp;
        private Int32 hp_ = 0;
        public bool HasHp
        {
            get { return hasHp; }
        }
        public Int32 Hp
        {
            get { return hp_; }
            set { SetHp(value); }
        }
        public void SetHp(Int32 value)
        {
            hasHp = true;
            hp_ = value;
        }

        public const int place_idxFieldNumber = 3;
        private bool hasPlace_idx;
        private Int32 place_idx_ = 0;
        public bool HasPlace_idx
        {
            get { return hasPlace_idx; }
        }
        public Int32 Place_idx
        {
            get { return place_idx_; }
            set { SetPlace_idx(value); }
        }
        public void SetPlace_idx(Int32 value)
        {
            hasPlace_idx = true;
            place_idx_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Type);
            }
            if (HasHp)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Hp);
            }
            if (HasPlace_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Place_idx);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasType)
            {
                output.WriteInt32(1, Type);
            }

            if (HasHp)
            {
                output.WriteInt32(2, Hp);
            }

            if (HasPlace_idx)
            {
                output.WriteInt32(3, Place_idx);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataShip _inst = (DataShip)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Hp = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Place_idx = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasType) return false;
            if (!hasHp) return false;
            if (!hasPlace_idx) return false;
            return true;
        }

    }


    [Serializable]
    public class DataShipMessage : PacketDistributed
    {

        public const int shipguidFieldNumber = 1;
        private bool hasShipguid;
        private string shipguid_ = "";
        public bool HasShipguid
        {
            get { return hasShipguid; }
        }
        public string Shipguid
        {
            get { return shipguid_; }
            set { SetShipguid(value); }
        }
        public void SetShipguid(string value)
        {
            hasShipguid = true;
            shipguid_ = value;
        }

        public const int shipidFieldNumber = 2;
        private bool hasShipid;
        private Int32 shipid_ = 0;
        public bool HasShipid
        {
            get { return hasShipid; }
        }
        public Int32 Shipid
        {
            get { return shipid_; }
            set { SetShipid(value); }
        }
        public void SetShipid(Int32 value)
        {
            hasShipid = true;
            shipid_ = value;
        }

        public const int levelFieldNumber = 3;
        private bool hasLevel;
        private Int32 level_ = 0;
        public bool HasLevel
        {
            get { return hasLevel; }
        }
        public Int32 Level
        {
            get { return level_; }
            set { SetLevel(value); }
        }
        public void SetLevel(Int32 value)
        {
            hasLevel = true;
            level_ = value;
        }

        public const int captainIdxFieldNumber = 4;
        private bool hasCaptainIdx;
        private Int32 captainIdx_ = 0;
        public bool HasCaptainIdx
        {
            get { return hasCaptainIdx; }
        }
        public Int32 CaptainIdx
        {
            get { return captainIdx_; }
            set { SetCaptainIdx(value); }
        }
        public void SetCaptainIdx(Int32 value)
        {
            hasCaptainIdx = true;
            captainIdx_ = value;
        }

        public const int powerFieldNumber = 5;
        private bool hasPower;
        private Int32 power_ = 0;
        public bool HasPower
        {
            get { return hasPower; }
        }
        public Int32 Power
        {
            get { return power_; }
            set { SetPower(value); }
        }
        public void SetPower(Int32 value)
        {
            hasPower = true;
            power_ = value;
        }

        public const int durableFieldNumber = 6;
        private bool hasDurable;
        private Int32 durable_ = 0;
        public bool HasDurable
        {
            get { return hasDurable; }
        }
        public Int32 Durable
        {
            get { return durable_; }
            set { SetDurable(value); }
        }
        public void SetDurable(Int32 value)
        {
            hasDurable = true;
            durable_ = value;
        }

        public const int armorFieldNumber = 7;
        private bool hasArmor;
        private Int32 armor_ = 0;
        public bool HasArmor
        {
            get { return hasArmor; }
        }
        public Int32 Armor
        {
            get { return armor_; }
            set { SetArmor(value); }
        }
        public void SetArmor(Int32 value)
        {
            hasArmor = true;
            armor_ = value;
        }

        public const int activeFieldNumber = 8;
        private bool hasActive;
        private Int32 active_ = 0;
        public bool HasActive
        {
            get { return hasActive; }
        }
        public Int32 Active
        {
            get { return active_; }
            set { SetActive(value); }
        }
        public void SetActive(Int32 value)
        {
            hasActive = true;
            active_ = value;
        }

        public const int avoidFieldNumber = 9;
        private bool hasAvoid;
        private Int32 avoid_ = 0;
        public bool HasAvoid
        {
            get { return hasAvoid; }
        }
        public Int32 Avoid
        {
            get { return avoid_; }
            set { SetAvoid(value); }
        }
        public void SetAvoid(Int32 value)
        {
            hasAvoid = true;
            avoid_ = value;
        }

        public const int criticalFieldNumber = 10;
        private bool hasCritical;
        private Int32 critical_ = 0;
        public bool HasCritical
        {
            get { return hasCritical; }
        }
        public Int32 Critical
        {
            get { return critical_; }
            set { SetCritical(value); }
        }
        public void SetCritical(Int32 value)
        {
            hasCritical = true;
            critical_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasShipguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Shipguid);
            }
            if (HasShipid)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Shipid);
            }
            if (HasLevel)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
            }
            if (HasCaptainIdx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, CaptainIdx);
            }
            if (HasPower)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Power);
            }
            if (HasDurable)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, Durable);
            }
            if (HasArmor)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(7, Armor);
            }
            if (HasActive)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(8, Active);
            }
            if (HasAvoid)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(9, Avoid);
            }
            if (HasCritical)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(10, Critical);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasShipguid)
            {
                output.WriteString(1, Shipguid);
            }

            if (HasShipid)
            {
                output.WriteInt32(2, Shipid);
            }

            if (HasLevel)
            {
                output.WriteInt32(3, Level);
            }

            if (HasCaptainIdx)
            {
                output.WriteInt32(4, CaptainIdx);
            }

            if (HasPower)
            {
                output.WriteInt32(5, Power);
            }

            if (HasDurable)
            {
                output.WriteInt32(6, Durable);
            }

            if (HasArmor)
            {
                output.WriteInt32(7, Armor);
            }

            if (HasActive)
            {
                output.WriteInt32(8, Active);
            }

            if (HasAvoid)
            {
                output.WriteInt32(9, Avoid);
            }

            if (HasCritical)
            {
                output.WriteInt32(10, Critical);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataShipMessage _inst = (DataShipMessage)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Shipguid = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Shipid = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Level = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.CaptainIdx = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Power = input.ReadInt32();
                            break;
                        }
                    case 48:
                        {
                            _inst.Durable = input.ReadInt32();
                            break;
                        }
                    case 56:
                        {
                            _inst.Armor = input.ReadInt32();
                            break;
                        }
                    case 64:
                        {
                            _inst.Active = input.ReadInt32();
                            break;
                        }
                    case 72:
                        {
                            _inst.Avoid = input.ReadInt32();
                            break;
                        }
                    case 80:
                        {
                            _inst.Critical = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasShipguid) return false;
            if (!hasShipid) return false;
            if (!hasLevel) return false;
            if (!hasCaptainIdx) return false;
            if (!hasPower) return false;
            if (!hasDurable) return false;
            if (!hasArmor) return false;
            if (!hasActive) return false;
            if (!hasAvoid) return false;
            if (!hasCritical) return false;
            return true;
        }

    }


    [Serializable]
    public class DataSingleAction : PacketDistributed
    {

        public const int ship_idxFieldNumber = 1;
        private bool hasShip_idx;
        private Int32 ship_idx_ = 0;
        public bool HasShip_idx
        {
            get { return hasShip_idx; }
        }
        public Int32 Ship_idx
        {
            get { return ship_idx_; }
            set { SetShip_idx(value); }
        }
        public void SetShip_idx(Int32 value)
        {
            hasShip_idx = true;
            ship_idx_ = value;
        }

        public const int ani_idxFieldNumber = 2;
        private bool hasAni_idx;
        private Int32 ani_idx_ = 0;
        public bool HasAni_idx
        {
            get { return hasAni_idx; }
        }
        public Int32 Ani_idx
        {
            get { return ani_idx_; }
            set { SetAni_idx(value); }
        }
        public void SetAni_idx(Int32 value)
        {
            hasAni_idx = true;
            ani_idx_ = value;
        }

        public const int att_valueFieldNumber = 3;
        private bool hasAtt_value;
        private Int32 att_value_ = 0;
        public bool HasAtt_value
        {
            get { return hasAtt_value; }
        }
        public Int32 Att_value
        {
            get { return att_value_; }
            set { SetAtt_value(value); }
        }
        public void SetAtt_value(Int32 value)
        {
            hasAtt_value = true;
            att_value_ = value;
        }

        public const int add_buf_idxFieldNumber = 4;
        private bool hasAdd_buf_idx;
        private Int32 add_buf_idx_ = 0;
        public bool HasAdd_buf_idx
        {
            get { return hasAdd_buf_idx; }
        }
        public Int32 Add_buf_idx
        {
            get { return add_buf_idx_; }
            set { SetAdd_buf_idx(value); }
        }
        public void SetAdd_buf_idx(Int32 value)
        {
            hasAdd_buf_idx = true;
            add_buf_idx_ = value;
        }

        public const int rm_buf_idxFieldNumber = 5;
        private bool hasRm_buf_idx;
        private Int32 rm_buf_idx_ = 0;
        public bool HasRm_buf_idx
        {
            get { return hasRm_buf_idx; }
        }
        public Int32 Rm_buf_idx
        {
            get { return rm_buf_idx_; }
            set { SetRm_buf_idx(value); }
        }
        public void SetRm_buf_idx(Int32 value)
        {
            hasRm_buf_idx = true;
            rm_buf_idx_ = value;
        }

        public const int att_typeFieldNumber = 6;
        private bool hasAtt_type;
        private Int32 att_type_ = 0;
        public bool HasAtt_type
        {
            get { return hasAtt_type; }
        }
        public Int32 Att_type
        {
            get { return att_type_; }
            set { SetAtt_type(value); }
        }
        public void SetAtt_type(Int32 value)
        {
            hasAtt_type = true;
            att_type_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasShip_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Ship_idx);
            }
            if (HasAni_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Ani_idx);
            }
            if (HasAtt_value)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Att_value);
            }
            if (HasAdd_buf_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Add_buf_idx);
            }
            if (HasRm_buf_idx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Rm_buf_idx);
            }
            if (HasAtt_type)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, Att_type);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasShip_idx)
            {
                output.WriteInt32(1, Ship_idx);
            }

            if (HasAni_idx)
            {
                output.WriteInt32(2, Ani_idx);
            }

            if (HasAtt_value)
            {
                output.WriteInt32(3, Att_value);
            }

            if (HasAdd_buf_idx)
            {
                output.WriteInt32(4, Add_buf_idx);
            }

            if (HasRm_buf_idx)
            {
                output.WriteInt32(5, Rm_buf_idx);
            }

            if (HasAtt_type)
            {
                output.WriteInt32(6, Att_type);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            DataSingleAction _inst = (DataSingleAction)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Ship_idx = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Ani_idx = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Att_value = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Add_buf_idx = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Rm_buf_idx = input.ReadInt32();
                            break;
                        }
                    case 48:
                        {
                            _inst.Att_type = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasShip_idx) return false;
            if (!hasAni_idx) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15000 : PacketDistributed
    {

        public const int commandIdFieldNumber = 1;
        private bool hasCommandId;
        private Int32 commandId_ = 0;
        public bool HasCommandId
        {
            get { return hasCommandId; }
        }
        public Int32 CommandId
        {
            get { return commandId_; }
            set { SetCommandId(value); }
        }
        public void SetCommandId(Int32 value)
        {
            hasCommandId = true;
            commandId_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasCommandId)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, CommandId);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasCommandId)
            {
                output.WriteInt32(1, CommandId);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15000 _inst = (SC15000)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.CommandId = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasCommandId) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15002 : PacketDistributed
    {

        public const int longinMessageFieldNumber = 1;
        private bool hasLonginMessage;
        private Int32 longinMessage_ = 0;
        public bool HasLonginMessage
        {
            get { return hasLonginMessage; }
        }
        public Int32 LonginMessage
        {
            get { return longinMessage_; }
            set { SetLonginMessage(value); }
        }
        public void SetLonginMessage(Int32 value)
        {
            hasLonginMessage = true;
            longinMessage_ = value;
        }

        public const int userguidFieldNumber = 2;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        public const int goldFieldNumber = 3;
        private bool hasGold;
        private Int32 gold_ = 0;
        public bool HasGold
        {
            get { return hasGold; }
        }
        public Int32 Gold
        {
            get { return gold_; }
            set { SetGold(value); }
        }
        public void SetGold(Int32 value)
        {
            hasGold = true;
            gold_ = value;
        }

        public const int supplyFieldNumber = 4;
        private bool hasSupply;
        private Int32 supply_ = 0;
        public bool HasSupply
        {
            get { return hasSupply; }
        }
        public Int32 Supply
        {
            get { return supply_; }
            set { SetSupply(value); }
        }
        public void SetSupply(Int32 value)
        {
            hasSupply = true;
            supply_ = value;
        }

        public const int foodFieldNumber = 5;
        private bool hasFood;
        private Int32 food_ = 0;
        public bool HasFood
        {
            get { return hasFood; }
        }
        public Int32 Food
        {
            get { return food_; }
            set { SetFood(value); }
        }
        public void SetFood(Int32 value)
        {
            hasFood = true;
            food_ = value;
        }

        public const int exploitFieldNumber = 6;
        private bool hasExploit;
        private Int32 exploit_ = 0;
        public bool HasExploit
        {
            get { return hasExploit; }
        }
        public Int32 Exploit
        {
            get { return exploit_; }
            set { SetExploit(value); }
        }
        public void SetExploit(Int32 value)
        {
            hasExploit = true;
            exploit_ = value;
        }

        public const int gemFieldNumber = 7;
        private bool hasGem;
        private Int32 gem_ = 0;
        public bool HasGem
        {
            get { return hasGem; }
        }
        public Int32 Gem
        {
            get { return gem_; }
            set { SetGem(value); }
        }
        public void SetGem(Int32 value)
        {
            hasGem = true;
            gem_ = value;
        }

        public const int userLevelFieldNumber = 8;
        private pbc::PopsicleList<Int32> userLevel_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userLevelList
        {
            get { return pbc::Lists.AsReadOnly(userLevel_); }
        }

        public int userLevelCount
        {
            get { return userLevel_.Count; }
        }

        public Int32 GetUserLevel(int index)
        {
            return userLevel_[index];
        }
        public void AddUserLevel(Int32 value)
        {
            userLevel_.Add(value);
        }

        public const int userTimerFieldNumber = 9;
        private pbc::PopsicleList<Int32> userTimer_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userTimerList
        {
            get { return pbc::Lists.AsReadOnly(userTimer_); }
        }

        public int userTimerCount
        {
            get { return userTimer_.Count; }
        }

        public Int32 GetUserTimer(int index)
        {
            return userTimer_[index];
        }
        public void AddUserTimer(Int32 value)
        {
            userTimer_.Add(value);
        }

        public const int userTimerStatusFieldNumber = 10;
        private pbc::PopsicleList<Int32> userTimerStatus_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userTimerStatusList
        {
            get { return pbc::Lists.AsReadOnly(userTimerStatus_); }
        }

        public int userTimerStatusCount
        {
            get { return userTimerStatus_.Count; }
        }

        public Int32 GetUserTimerStatus(int index)
        {
            return userTimerStatus_[index];
        }
        public void AddUserTimerStatus(Int32 value)
        {
            userTimerStatus_.Add(value);
        }

        public const int userTaskFieldNumber = 11;
        private pbc::PopsicleList<Int32> userTask_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userTaskList
        {
            get { return pbc::Lists.AsReadOnly(userTask_); }
        }

        public int userTaskCount
        {
            get { return userTask_.Count; }
        }

        public Int32 GetUserTask(int index)
        {
            return userTask_[index];
        }
        public void AddUserTask(Int32 value)
        {
            userTask_.Add(value);
        }

        public const int userWharfDataFieldNumber = 12;
        private pbc::PopsicleList<Int32> userWharfData_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userWharfDataList
        {
            get { return pbc::Lists.AsReadOnly(userWharfData_); }
        }

        public int userWharfDataCount
        {
            get { return userWharfData_.Count; }
        }

        public Int32 GetUserWharfData(int index)
        {
            return userWharfData_[index];
        }
        public void AddUserWharfData(Int32 value)
        {
            userWharfData_.Add(value);
        }

        public const int marketCountFieldNumber = 13;
        private bool hasMarketCount;
        private Int32 marketCount_ = 0;
        public bool HasMarketCount
        {
            get { return hasMarketCount; }
        }
        public Int32 MarketCount
        {
            get { return marketCount_; }
            set { SetMarketCount(value); }
        }
        public void SetMarketCount(Int32 value)
        {
            hasMarketCount = true;
            marketCount_ = value;
        }

        public const int captainFieldNumber = 14;
        private pbc::PopsicleList<DataCaptain> captain_ = new pbc::PopsicleList<DataCaptain>();
        public scg::IList<DataCaptain> captainList
        {
            get { return pbc::Lists.AsReadOnly(captain_); }
        }

        public int captainCount
        {
            get { return captain_.Count; }
        }

        public DataCaptain GetCaptain(int index)
        {
            return captain_[index];
        }
        public void AddCaptain(DataCaptain value)
        {
            captain_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasLonginMessage)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, LonginMessage);
            }
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Userguid);
            }
            if (HasGold)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Gold);
            }
            if (HasSupply)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Supply);
            }
            if (HasFood)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Food);
            }
            if (HasExploit)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, Exploit);
            }
            if (HasGem)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(7, Gem);
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userLevelList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userLevel_.Count;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userTimerList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userTimer_.Count;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userTimerStatusList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userTimerStatus_.Count;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userTaskList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userTask_.Count;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userWharfDataList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userWharfData_.Count;
            }
            if (HasMarketCount)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(13, MarketCount);
            }
            {
                foreach (DataCaptain element in captainList)
                {
                    int subsize = element.SerializedSize();
                    size += pb::CodedOutputStream.ComputeTagSize((int)14) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
                }
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasLonginMessage)
            {
                output.WriteInt32(1, LonginMessage);
            }

            if (HasUserguid)
            {
                output.WriteString(2, Userguid);
            }

            if (HasGold)
            {
                output.WriteInt32(3, Gold);
            }

            if (HasSupply)
            {
                output.WriteInt32(4, Supply);
            }

            if (HasFood)
            {
                output.WriteInt32(5, Food);
            }

            if (HasExploit)
            {
                output.WriteInt32(6, Exploit);
            }

            if (HasGem)
            {
                output.WriteInt32(7, Gem);
            }
            {
                if (userLevel_.Count > 0)
                {
                    foreach (Int32 element in userLevelList)
                    {
                        output.WriteInt32(8, element);
                    }
                }

            }
            {
                if (userTimer_.Count > 0)
                {
                    foreach (Int32 element in userTimerList)
                    {
                        output.WriteInt32(9, element);
                    }
                }

            }
            {
                if (userTimerStatus_.Count > 0)
                {
                    foreach (Int32 element in userTimerStatusList)
                    {
                        output.WriteInt32(10, element);
                    }
                }

            }
            {
                if (userTask_.Count > 0)
                {
                    foreach (Int32 element in userTaskList)
                    {
                        output.WriteInt32(11, element);
                    }
                }

            }
            {
                if (userWharfData_.Count > 0)
                {
                    foreach (Int32 element in userWharfDataList)
                    {
                        output.WriteInt32(12, element);
                    }
                }

            }

            if (HasMarketCount)
            {
                output.WriteInt32(13, MarketCount);
            }

            do
            {
                foreach (DataCaptain element in captainList)
                {
                    output.WriteTag((int)14, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15002 _inst = (SC15002)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.LonginMessage = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.Gold = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Supply = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Food = input.ReadInt32();
                            break;
                        }
                    case 48:
                        {
                            _inst.Exploit = input.ReadInt32();
                            break;
                        }
                    case 56:
                        {
                            _inst.Gem = input.ReadInt32();
                            break;
                        }
                    case 64:
                        {
                            _inst.AddUserLevel(input.ReadInt32());
                            break;
                        }
                    case 72:
                        {
                            _inst.AddUserTimer(input.ReadInt32());
                            break;
                        }
                    case 80:
                        {
                            _inst.AddUserTimerStatus(input.ReadInt32());
                            break;
                        }
                    case 88:
                        {
                            _inst.AddUserTask(input.ReadInt32());
                            break;
                        }
                    case 96:
                        {
                            _inst.AddUserWharfData(input.ReadInt32());
                            break;
                        }
                    case 104:
                        {
                            _inst.MarketCount = input.ReadInt32();
                            break;
                        }
                    case 114:
                        {
                            DataCaptain subBuilder = new DataCaptain();
                            input.ReadMessage(subBuilder);
                            AddCaptain(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasLonginMessage) return false;
            foreach (DataCaptain element in captainList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15005 : PacketDistributed
    {

        public const int actionTypeFieldNumber = 1;
        private bool hasActionType;
        private Int32 actionType_ = 0;
        public bool HasActionType
        {
            get { return hasActionType; }
        }
        public Int32 ActionType
        {
            get { return actionType_; }
            set { SetActionType(value); }
        }
        public void SetActionType(Int32 value)
        {
            hasActionType = true;
            actionType_ = value;
        }

        public const int stautsFieldNumber = 2;
        private bool hasStauts;
        private Int32 stauts_ = 0;
        public bool HasStauts
        {
            get { return hasStauts; }
        }
        public Int32 Stauts
        {
            get { return stauts_; }
            set { SetStauts(value); }
        }
        public void SetStauts(Int32 value)
        {
            hasStauts = true;
            stauts_ = value;
        }

        public const int captainidxFieldNumber = 3;
        private bool hasCaptainidx;
        private Int32 captainidx_ = 0;
        public bool HasCaptainidx
        {
            get { return hasCaptainidx; }
        }
        public Int32 Captainidx
        {
            get { return captainidx_; }
            set { SetCaptainidx(value); }
        }
        public void SetCaptainidx(Int32 value)
        {
            hasCaptainidx = true;
            captainidx_ = value;
        }

        public const int goldFieldNumber = 4;
        private bool hasGold;
        private Int32 gold_ = 0;
        public bool HasGold
        {
            get { return hasGold; }
        }
        public Int32 Gold
        {
            get { return gold_; }
            set { SetGold(value); }
        }
        public void SetGold(Int32 value)
        {
            hasGold = true;
            gold_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasActionType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, ActionType);
            }
            if (HasStauts)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Stauts);
            }
            if (HasCaptainidx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Captainidx);
            }
            if (HasGold)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Gold);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasActionType)
            {
                output.WriteInt32(1, ActionType);
            }

            if (HasStauts)
            {
                output.WriteInt32(2, Stauts);
            }

            if (HasCaptainidx)
            {
                output.WriteInt32(3, Captainidx);
            }

            if (HasGold)
            {
                output.WriteInt32(4, Gold);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15005 _inst = (SC15005)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.ActionType = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Stauts = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Captainidx = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Gold = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasActionType) return false;
            if (!hasStauts) return false;
            if (!hasCaptainidx) return false;
            if (!hasGold) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15006 : PacketDistributed
    {

        public const int indexFieldNumber = 1;
        private bool hasIndex;
        private string index_ = "";
        public bool HasIndex
        {
            get { return hasIndex; }
        }
        public string Index
        {
            get { return index_; }
            set { SetIndex(value); }
        }
        public void SetIndex(string value)
        {
            hasIndex = true;
            index_ = value;
        }

        public const int statusFieldNumber = 2;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        public const int levelFieldNumber = 3;
        private bool hasLevel;
        private Int32 level_ = 0;
        public bool HasLevel
        {
            get { return hasLevel; }
        }
        public Int32 Level
        {
            get { return level_; }
            set { SetLevel(value); }
        }
        public void SetLevel(Int32 value)
        {
            hasLevel = true;
            level_ = value;
        }

        public const int goldFieldNumber = 4;
        private bool hasGold;
        private Int32 gold_ = 0;
        public bool HasGold
        {
            get { return hasGold; }
        }
        public Int32 Gold
        {
            get { return gold_; }
            set { SetGold(value); }
        }
        public void SetGold(Int32 value)
        {
            hasGold = true;
            gold_ = value;
        }

        public const int userTimerFieldNumber = 5;
        private pbc::PopsicleList<Int32> userTimer_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userTimerList
        {
            get { return pbc::Lists.AsReadOnly(userTimer_); }
        }

        public int userTimerCount
        {
            get { return userTimer_.Count; }
        }

        public Int32 GetUserTimer(int index)
        {
            return userTimer_[index];
        }
        public void AddUserTimer(Int32 value)
        {
            userTimer_.Add(value);
        }

        public const int userTimerStatusFieldNumber = 6;
        private pbc::PopsicleList<Int32> userTimerStatus_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> userTimerStatusList
        {
            get { return pbc::Lists.AsReadOnly(userTimerStatus_); }
        }

        public int userTimerStatusCount
        {
            get { return userTimerStatus_.Count; }
        }

        public Int32 GetUserTimerStatus(int index)
        {
            return userTimerStatus_[index];
        }
        public void AddUserTimerStatus(Int32 value)
        {
            userTimerStatus_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasIndex)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Index);
            }
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Status);
            }
            if (HasLevel)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
            }
            if (HasGold)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Gold);
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userTimerList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userTimer_.Count;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in userTimerStatusList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * userTimerStatus_.Count;
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasIndex)
            {
                output.WriteString(1, Index);
            }

            if (HasStatus)
            {
                output.WriteInt32(2, Status);
            }

            if (HasLevel)
            {
                output.WriteInt32(3, Level);
            }

            if (HasGold)
            {
                output.WriteInt32(4, Gold);
            }
            {
                if (userTimer_.Count > 0)
                {
                    foreach (Int32 element in userTimerList)
                    {
                        output.WriteInt32(5, element);
                    }
                }

            }
            {
                if (userTimerStatus_.Count > 0)
                {
                    foreach (Int32 element in userTimerStatusList)
                    {
                        output.WriteInt32(6, element);
                    }
                }

            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15006 _inst = (SC15006)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Index = input.ReadString();
                            break;
                        }
                    case 16:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Level = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Gold = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.AddUserTimer(input.ReadInt32());
                            break;
                        }
                    case 48:
                        {
                            _inst.AddUserTimerStatus(input.ReadInt32());
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasIndex) return false;
            if (!hasStatus) return false;
            if (!hasLevel) return false;
            if (!hasGold) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15007 : PacketDistributed
    {

        public const int statusFieldNumber = 1;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        public const int dataCaptainFieldNumber = 2;
        private bool hasDataCaptain;
        private DataCaptain dataCaptain_ = new DataCaptain();
        public bool HasDataCaptain
        {
            get { return hasDataCaptain; }
        }
        public DataCaptain DataCaptain
        {
            get { return dataCaptain_; }
            set { SetDataCaptain(value); }
        }
        public void SetDataCaptain(DataCaptain value)
        {
            hasDataCaptain = true;
            dataCaptain_ = value;
        }

        public const int exploitFieldNumber = 3;
        private bool hasExploit;
        private Int32 exploit_ = 0;
        public bool HasExploit
        {
            get { return hasExploit; }
        }
        public Int32 Exploit
        {
            get { return exploit_; }
            set { SetExploit(value); }
        }
        public void SetExploit(Int32 value)
        {
            hasExploit = true;
            exploit_ = value;
        }

        public const int gemFieldNumber = 4;
        private bool hasGem;
        private Int32 gem_ = 0;
        public bool HasGem
        {
            get { return hasGem; }
        }
        public Int32 Gem
        {
            get { return gem_; }
            set { SetGem(value); }
        }
        public void SetGem(Int32 value)
        {
            hasGem = true;
            gem_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Status);
            }
            {
                int subsize = DataCaptain.SerializedSize();
                size += pb::CodedOutputStream.ComputeTagSize((int)2) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
            }
            if (HasExploit)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Exploit);
            }
            if (HasGem)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Gem);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasStatus)
            {
                output.WriteInt32(1, Status);
            }
            {
                output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
                output.WriteRawVarint32((uint)DataCaptain.SerializedSize());
                DataCaptain.WriteTo(output);

            }

            if (HasExploit)
            {
                output.WriteInt32(3, Exploit);
            }

            if (HasGem)
            {
                output.WriteInt32(4, Gem);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15007 _inst = (SC15007)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            DataCaptain subBuilder = new DataCaptain();
                            input.ReadMessage(subBuilder);
                            break;
                        }
                    case 24:
                        {
                            _inst.Exploit = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.Gem = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasStatus) return false;
            if (HasDataCaptain)
            {
                if (!DataCaptain.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15009 : PacketDistributed
    {

        public const int statusFieldNumber = 1;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Status);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasStatus)
            {
                output.WriteInt32(1, Status);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15009 _inst = (SC15009)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasStatus) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15010 : PacketDistributed
    {

        public const int statusFieldNumber = 1;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        public const int typeFieldNumber = 2;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        public const int userShipFieldNumber = 3;
        private bool hasUserShip;
        private DataShipMessage userShip_ = new DataShipMessage();
        public bool HasUserShip
        {
            get { return hasUserShip; }
        }
        public DataShipMessage UserShip
        {
            get { return userShip_; }
            set { SetUserShip(value); }
        }
        public void SetUserShip(DataShipMessage value)
        {
            hasUserShip = true;
            userShip_ = value;
        }

        public const int supplyFieldNumber = 4;
        private bool hasSupply;
        private Int32 supply_ = 0;
        public bool HasSupply
        {
            get { return hasSupply; }
        }
        public Int32 Supply
        {
            get { return supply_; }
            set { SetSupply(value); }
        }
        public void SetSupply(Int32 value)
        {
            hasSupply = true;
            supply_ = value;
        }

        public const int exploitFieldNumber = 5;
        private bool hasExploit;
        private Int32 exploit_ = 0;
        public bool HasExploit
        {
            get { return hasExploit; }
        }
        public Int32 Exploit
        {
            get { return exploit_; }
            set { SetExploit(value); }
        }
        public void SetExploit(Int32 value)
        {
            hasExploit = true;
            exploit_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Status);
            }
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
            }
            {
                int subsize = UserShip.SerializedSize();
                size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
            }
            if (HasSupply)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Supply);
            }
            if (HasExploit)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(5, Exploit);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasStatus)
            {
                output.WriteInt32(1, Status);
            }

            if (HasType)
            {
                output.WriteInt32(2, Type);
            }
            {
                output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
                output.WriteRawVarint32((uint)UserShip.SerializedSize());
                UserShip.WriteTo(output);

            }

            if (HasSupply)
            {
                output.WriteInt32(4, Supply);
            }

            if (HasExploit)
            {
                output.WriteInt32(5, Exploit);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15010 _inst = (SC15010)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }
                    case 26:
                        {
                            DataShipMessage subBuilder = new DataShipMessage();
                            input.ReadMessage(subBuilder);
                            break;
                        }
                    case 32:
                        {
                            _inst.Supply = input.ReadInt32();
                            break;
                        }
                    case 40:
                        {
                            _inst.Exploit = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasStatus) return false;
            if (!hasType) return false;
            if (HasUserShip)
            {
                if (!UserShip.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15011 : PacketDistributed
    {

        public const int statusFieldNumber = 1;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        public const int goldFieldNumber = 2;
        private bool hasGold;
        private Int32 gold_ = 0;
        public bool HasGold
        {
            get { return hasGold; }
        }
        public Int32 Gold
        {
            get { return gold_; }
            set { SetGold(value); }
        }
        public void SetGold(Int32 value)
        {
            hasGold = true;
            gold_ = value;
        }

        public const int supplyFieldNumber = 3;
        private bool hasSupply;
        private Int32 supply_ = 0;
        public bool HasSupply
        {
            get { return hasSupply; }
        }
        public Int32 Supply
        {
            get { return supply_; }
            set { SetSupply(value); }
        }
        public void SetSupply(Int32 value)
        {
            hasSupply = true;
            supply_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Status);
            }
            if (HasGold)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Gold);
            }
            if (HasSupply)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Supply);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasStatus)
            {
                output.WriteInt32(1, Status);
            }

            if (HasGold)
            {
                output.WriteInt32(2, Gold);
            }

            if (HasSupply)
            {
                output.WriteInt32(3, Supply);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15011 _inst = (SC15011)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Gold = input.ReadInt32();
                            break;
                        }
                    case 24:
                        {
                            _inst.Supply = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasStatus) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15012 : PacketDistributed
    {

        public const int statusFieldNumber = 1;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        public const int userguidFieldNumber = 2;
        private bool hasUserguid;
        private string userguid_ = "";
        public bool HasUserguid
        {
            get { return hasUserguid; }
        }
        public string Userguid
        {
            get { return userguid_; }
            set { SetUserguid(value); }
        }
        public void SetUserguid(string value)
        {
            hasUserguid = true;
            userguid_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Status);
            }
            if (HasUserguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Userguid);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasStatus)
            {
                output.WriteInt32(1, Status);
            }

            if (HasUserguid)
            {
                output.WriteString(2, Userguid);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15012 _inst = (SC15012)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            _inst.Userguid = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasStatus) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15013 : PacketDistributed
    {

        public const int statusFieldNumber = 1;
        private bool hasStatus;
        private Int32 status_ = 0;
        public bool HasStatus
        {
            get { return hasStatus; }
        }
        public Int32 Status
        {
            get { return status_; }
            set { SetStatus(value); }
        }
        public void SetStatus(Int32 value)
        {
            hasStatus = true;
            status_ = value;
        }

        public const int typeFieldNumber = 2;
        private bool hasType;
        private Int32 type_ = 0;
        public bool HasType
        {
            get { return hasType; }
        }
        public Int32 Type
        {
            get { return type_; }
            set { SetType(value); }
        }
        public void SetType(Int32 value)
        {
            hasType = true;
            type_ = value;
        }

        public const int itemInfoFieldNumber = 3;
        private bool hasItemInfo;
        private DataItemMessage itemInfo_ = new DataItemMessage();
        public bool HasItemInfo
        {
            get { return hasItemInfo; }
        }
        public DataItemMessage ItemInfo
        {
            get { return itemInfo_; }
            set { SetItemInfo(value); }
        }
        public void SetItemInfo(DataItemMessage value)
        {
            hasItemInfo = true;
            itemInfo_ = value;
        }

        public const int moneyFieldNumber = 4;
        private bool hasMoney;
        private Int32 money_ = 0;
        public bool HasMoney
        {
            get { return hasMoney; }
        }
        public Int32 Money
        {
            get { return money_; }
            set { SetMoney(value); }
        }
        public void SetMoney(Int32 value)
        {
            hasMoney = true;
            money_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasStatus)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Status);
            }
            if (HasType)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Type);
            }
            {
                int subsize = ItemInfo.SerializedSize();
                size += pb::CodedOutputStream.ComputeTagSize((int)3) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
            }
            if (HasMoney)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, Money);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasStatus)
            {
                output.WriteInt32(1, Status);
            }

            if (HasType)
            {
                output.WriteInt32(2, Type);
            }
            {
                output.WriteTag((int)3, pb::WireFormat.WireType.LengthDelimited);
                output.WriteRawVarint32((uint)ItemInfo.SerializedSize());
                ItemInfo.WriteTo(output);

            }

            if (HasMoney)
            {
                output.WriteInt32(4, Money);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15013 _inst = (SC15013)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Status = input.ReadInt32();
                            break;
                        }
                    case 16:
                        {
                            _inst.Type = input.ReadInt32();
                            break;
                        }
                    case 26:
                        {
                            DataItemMessage subBuilder = new DataItemMessage();
                            input.ReadMessage(subBuilder);
                            break;
                        }
                    case 32:
                        {
                            _inst.Money = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasStatus) return false;
            if (!hasType) return false;
            if (HasItemInfo)
            {
                if (!ItemInfo.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15101 : PacketDistributed
    {

        public const int map_idFieldNumber = 1;
        private bool hasMap_id;
        private Int32 map_id_ = 0;
        public bool HasMap_id
        {
            get { return hasMap_id; }
        }
        public Int32 Map_id
        {
            get { return map_id_; }
            set { SetMap_id(value); }
        }
        public void SetMap_id(Int32 value)
        {
            hasMap_id = true;
            map_id_ = value;
        }

        public const int battleArrayFieldNumber = 2;
        private pbc::PopsicleList<DataBattleInfo> battleArray_ = new pbc::PopsicleList<DataBattleInfo>();
        public scg::IList<DataBattleInfo> battleArrayList
        {
            get { return pbc::Lists.AsReadOnly(battleArray_); }
        }

        public int battleArrayCount
        {
            get { return battleArray_.Count; }
        }

        public DataBattleInfo GetBattleArray(int index)
        {
            return battleArray_[index];
        }
        public void AddBattleArray(DataBattleInfo value)
        {
            battleArray_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasMap_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Map_id);
            }
            {
                foreach (DataBattleInfo element in battleArrayList)
                {
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

            if (HasMap_id)
            {
                output.WriteInt32(1, Map_id);
            }

            do
            {
                foreach (DataBattleInfo element in battleArrayList)
                {
                    output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15101 _inst = (SC15101)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Map_id = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            DataBattleInfo subBuilder = new DataBattleInfo();
                            input.ReadMessage(subBuilder);
                            AddBattleArray(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasMap_id) return false;
            foreach (DataBattleInfo element in battleArrayList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15102 : PacketDistributed
    {

        public const int battle_idFieldNumber = 1;
        private bool hasBattle_id;
        private Int32 battle_id_ = 0;
        public bool HasBattle_id
        {
            get { return hasBattle_id; }
        }
        public Int32 Battle_id
        {
            get { return battle_id_; }
            set { SetBattle_id(value); }
        }
        public void SetBattle_id(Int32 value)
        {
            hasBattle_id = true;
            battle_id_ = value;
        }

        public const int userReport_arrayFieldNumber = 2;
        private pbc::PopsicleList<DataReport> userReport_array_ = new pbc::PopsicleList<DataReport>();
        public scg::IList<DataReport> userReport_arrayList
        {
            get { return pbc::Lists.AsReadOnly(userReport_array_); }
        }

        public int userReport_arrayCount
        {
            get { return userReport_array_.Count; }
        }

        public DataReport GetUserReport_array(int index)
        {
            return userReport_array_[index];
        }
        public void AddUserReport_array(DataReport value)
        {
            userReport_array_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasBattle_id)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Battle_id);
            }
            {
                foreach (DataReport element in userReport_arrayList)
                {
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

            if (HasBattle_id)
            {
                output.WriteInt32(1, Battle_id);
            }

            do
            {
                foreach (DataReport element in userReport_arrayList)
                {
                    output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15102 _inst = (SC15102)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Battle_id = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            DataReport subBuilder = new DataReport();
                            input.ReadMessage(subBuilder);
                            AddUserReport_array(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasBattle_id) return false;
            foreach (DataReport element in userReport_arrayList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15103 : PacketDistributed
    {

        public const int battleFieldNumber = 1;
        private bool hasBattle;
        private DataBattle battle_ = new DataBattle();
        public bool HasBattle
        {
            get { return hasBattle; }
        }
        public DataBattle Battle
        {
            get { return battle_; }
            set { SetBattle(value); }
        }
        public void SetBattle(DataBattle value)
        {
            hasBattle = true;
            battle_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                int subsize = Battle.SerializedSize();
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
                output.WriteRawVarint32((uint)Battle.SerializedSize());
                Battle.WriteTo(output);

            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15103 _inst = (SC15103)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            DataBattle subBuilder = new DataBattle();
                            input.ReadMessage(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (HasBattle)
            {
                if (!Battle.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15104 : PacketDistributed
    {

        public const int battleFieldNumber = 1;
        private bool hasBattle;
        private DataBattle battle_ = new DataBattle();
        public bool HasBattle
        {
            get { return hasBattle; }
        }
        public DataBattle Battle
        {
            get { return battle_; }
            set { SetBattle(value); }
        }
        public void SetBattle(DataBattle value)
        {
            hasBattle = true;
            battle_ = value;
        }

        public const int unlock_idFieldNumber = 2;
        private pbc::PopsicleList<Int32> unlock_id_ = new pbc::PopsicleList<Int32>();
        public scg::IList<Int32> unlock_idList
        {
            get { return pbc::Lists.AsReadOnly(unlock_id_); }
        }

        public int unlock_idCount
        {
            get { return unlock_id_.Count; }
        }

        public Int32 GetUnlock_id(int index)
        {
            return unlock_id_[index];
        }
        public void AddUnlock_id(Int32 value)
        {
            unlock_id_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                int subsize = Battle.SerializedSize();
                size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
            }
            {
                int dataSize = 0;
                foreach (Int32 element in unlock_idList)
                {
                    dataSize += pb::CodedOutputStream.ComputeInt32SizeNoTag(element);
                }
                size += dataSize;
                size += 1 * unlock_id_.Count;
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();
            {
                output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
                output.WriteRawVarint32((uint)Battle.SerializedSize());
                Battle.WriteTo(output);

            }
            {
                if (unlock_id_.Count > 0)
                {
                    foreach (Int32 element in unlock_idList)
                    {
                        output.WriteInt32(2, element);
                    }
                }

            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15104 _inst = (SC15104)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            DataBattle subBuilder = new DataBattle();
                            input.ReadMessage(subBuilder);
                            break;
                        }
                    case 16:
                        {
                            _inst.AddUnlock_id(input.ReadInt32());
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (HasBattle)
            {
                if (!Battle.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15105 : PacketDistributed
    {

        public const int shipSizeFieldNumber = 1;
        private bool hasShipSize;
        private Int32 shipSize_ = 0;
        public bool HasShipSize
        {
            get { return hasShipSize; }
        }
        public Int32 ShipSize
        {
            get { return shipSize_; }
            set { SetShipSize(value); }
        }
        public void SetShipSize(Int32 value)
        {
            hasShipSize = true;
            shipSize_ = value;
        }

        public const int itemFieldNumber = 2;
        private pbc::PopsicleList<DataShipMessage> item_ = new pbc::PopsicleList<DataShipMessage>();
        public scg::IList<DataShipMessage> itemList
        {
            get { return pbc::Lists.AsReadOnly(item_); }
        }

        public int itemCount
        {
            get { return item_.Count; }
        }

        public DataShipMessage GetItem(int index)
        {
            return item_[index];
        }
        public void AddItem(DataShipMessage value)
        {
            item_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasShipSize)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, ShipSize);
            }
            {
                foreach (DataShipMessage element in itemList)
                {
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

            if (HasShipSize)
            {
                output.WriteInt32(1, ShipSize);
            }

            do
            {
                foreach (DataShipMessage element in itemList)
                {
                    output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15105 _inst = (SC15105)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.ShipSize = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            DataShipMessage subBuilder = new DataShipMessage();
                            input.ReadMessage(subBuilder);
                            AddItem(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasShipSize) return false;
            foreach (DataShipMessage element in itemList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15201 : PacketDistributed
    {

        public const int senderFieldNumber = 1;
        private bool hasSender;
        private ChatInfo sender_ = new ChatInfo();
        public bool HasSender
        {
            get { return hasSender; }
        }
        public ChatInfo Sender
        {
            get { return sender_; }
            set { SetSender(value); }
        }
        public void SetSender(ChatInfo value)
        {
            hasSender = true;
            sender_ = value;
        }

        public const int chatstyleFieldNumber = 2;
        private bool hasChatstyle;
        private Int32 chatstyle_ = 0;
        public bool HasChatstyle
        {
            get { return hasChatstyle; }
        }
        public Int32 Chatstyle
        {
            get { return chatstyle_; }
            set { SetChatstyle(value); }
        }
        public void SetChatstyle(Int32 value)
        {
            hasChatstyle = true;
            chatstyle_ = value;
        }

        public const int chatcontentFieldNumber = 3;
        private bool hasChatcontent;
        private string chatcontent_ = "";
        public bool HasChatcontent
        {
            get { return hasChatcontent; }
        }
        public string Chatcontent
        {
            get { return chatcontent_; }
            set { SetChatcontent(value); }
        }
        public void SetChatcontent(string value)
        {
            hasChatcontent = true;
            chatcontent_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            {
                int subsize = Sender.SerializedSize();
                size += pb::CodedOutputStream.ComputeTagSize((int)1) + pb::CodedOutputStream.ComputeRawVarint32Size((uint)subsize) + subsize;
            }
            if (HasChatstyle)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(2, Chatstyle);
            }
            if (HasChatcontent)
            {
                size += pb::CodedOutputStream.ComputeStringSize(3, Chatcontent);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();
            {
                output.WriteTag((int)1, pb::WireFormat.WireType.LengthDelimited);
                output.WriteRawVarint32((uint)Sender.SerializedSize());
                Sender.WriteTo(output);

            }

            if (HasChatstyle)
            {
                output.WriteInt32(2, Chatstyle);
            }

            if (HasChatcontent)
            {
                output.WriteString(3, Chatcontent);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15201 _inst = (SC15201)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            ChatInfo subBuilder = new ChatInfo();
                            input.ReadMessage(subBuilder);
                            break;
                        }
                    case 16:
                        {
                            _inst.Chatstyle = input.ReadInt32();
                            break;
                        }
                    case 26:
                        {
                            _inst.Chatcontent = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (HasSender)
            {
                if (!Sender.IsInitialized()) return false;
            }
            if (!hasChatstyle) return false;
            if (!hasChatcontent) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15202 : PacketDistributed
    {

        public const int allianceidFieldNumber = 1;
        private bool hasAllianceid;
        private string allianceid_ = "";
        public bool HasAllianceid
        {
            get { return hasAllianceid; }
        }
        public string Allianceid
        {
            get { return allianceid_; }
            set { SetAllianceid(value); }
        }
        public void SetAllianceid(string value)
        {
            hasAllianceid = true;
            allianceid_ = value;
        }

        public const int alliance_nameFieldNumber = 2;
        private bool hasAlliance_name;
        private string alliance_name_ = "";
        public bool HasAlliance_name
        {
            get { return hasAlliance_name; }
        }
        public string Alliance_name
        {
            get { return alliance_name_; }
            set { SetAlliance_name(value); }
        }
        public void SetAlliance_name(string value)
        {
            hasAlliance_name = true;
            alliance_name_ = value;
        }

        public const int levelFieldNumber = 3;
        private bool hasLevel;
        private Int32 level_ = 0;
        public bool HasLevel
        {
            get { return hasLevel; }
        }
        public Int32 Level
        {
            get { return level_; }
            set { SetLevel(value); }
        }
        public void SetLevel(Int32 value)
        {
            hasLevel = true;
            level_ = value;
        }

        public const int mightFieldNumber = 4;
        private bool hasMight;
        private string might_ = "";
        public bool HasMight
        {
            get { return hasMight; }
        }
        public string Might
        {
            get { return might_; }
            set { SetMight(value); }
        }
        public void SetMight(string value)
        {
            hasMight = true;
            might_ = value;
        }

        public const int alliance_diplomacyFieldNumber = 5;
        private bool hasAlliance_diplomacy;
        private string alliance_diplomacy_ = "";
        public bool HasAlliance_diplomacy
        {
            get { return hasAlliance_diplomacy; }
        }
        public string Alliance_diplomacy
        {
            get { return alliance_diplomacy_; }
            set { SetAlliance_diplomacy(value); }
        }
        public void SetAlliance_diplomacy(string value)
        {
            hasAlliance_diplomacy = true;
            alliance_diplomacy_ = value;
        }

        public const int hairFieldNumber = 6;
        private bool hasHair;
        private string hair_ = "";
        public bool HasHair
        {
            get { return hasHair; }
        }
        public string Hair
        {
            get { return hair_; }
            set { SetHair(value); }
        }
        public void SetHair(string value)
        {
            hasHair = true;
            hair_ = value;
        }

        public const int faceFieldNumber = 7;
        private bool hasFace;
        private string face_ = "";
        public bool HasFace
        {
            get { return hasFace; }
        }
        public string Face
        {
            get { return face_; }
            set { SetFace(value); }
        }
        public void SetFace(string value)
        {
            hasFace = true;
            face_ = value;
        }

        public const int dressFieldNumber = 8;
        private bool hasDress;
        private string dress_ = "";
        public bool HasDress
        {
            get { return hasDress; }
        }
        public string Dress
        {
            get { return dress_; }
            set { SetDress(value); }
        }
        public void SetDress(string value)
        {
            hasDress = true;
            dress_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasAllianceid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(1, Allianceid);
            }
            if (HasAlliance_name)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Alliance_name);
            }
            if (HasLevel)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, Level);
            }
            if (HasMight)
            {
                size += pb::CodedOutputStream.ComputeStringSize(4, Might);
            }
            if (HasAlliance_diplomacy)
            {
                size += pb::CodedOutputStream.ComputeStringSize(5, Alliance_diplomacy);
            }
            if (HasHair)
            {
                size += pb::CodedOutputStream.ComputeStringSize(6, Hair);
            }
            if (HasFace)
            {
                size += pb::CodedOutputStream.ComputeStringSize(7, Face);
            }
            if (HasDress)
            {
                size += pb::CodedOutputStream.ComputeStringSize(8, Dress);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasAllianceid)
            {
                output.WriteString(1, Allianceid);
            }

            if (HasAlliance_name)
            {
                output.WriteString(2, Alliance_name);
            }

            if (HasLevel)
            {
                output.WriteInt32(3, Level);
            }

            if (HasMight)
            {
                output.WriteString(4, Might);
            }

            if (HasAlliance_diplomacy)
            {
                output.WriteString(5, Alliance_diplomacy);
            }

            if (HasHair)
            {
                output.WriteString(6, Hair);
            }

            if (HasFace)
            {
                output.WriteString(7, Face);
            }

            if (HasDress)
            {
                output.WriteString(8, Dress);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15202 _inst = (SC15202)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 10:
                        {
                            _inst.Allianceid = input.ReadString();
                            break;
                        }
                    case 18:
                        {
                            _inst.Alliance_name = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.Level = input.ReadInt32();
                            break;
                        }
                    case 34:
                        {
                            _inst.Might = input.ReadString();
                            break;
                        }
                    case 42:
                        {
                            _inst.Alliance_diplomacy = input.ReadString();
                            break;
                        }
                    case 50:
                        {
                            _inst.Hair = input.ReadString();
                            break;
                        }
                    case 58:
                        {
                            _inst.Face = input.ReadString();
                            break;
                        }
                    case 66:
                        {
                            _inst.Dress = input.ReadString();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasAllianceid) return false;
            if (!hasAlliance_name) return false;
            if (!hasLevel) return false;
            if (!hasMight) return false;
            if (!hasAlliance_diplomacy) return false;
            if (!hasHair) return false;
            if (!hasFace) return false;
            if (!hasDress) return false;
            return true;
        }

    }


    [Serializable]
    public class SC15203 : PacketDistributed
    {

        public const int BagSizeFieldNumber = 1;
        private bool hasBagSize;
        private Int32 BagSize_ = 0;
        public bool HasBagSize
        {
            get { return hasBagSize; }
        }
        public Int32 BagSize
        {
            get { return BagSize_; }
            set { SetBagSize(value); }
        }
        public void SetBagSize(Int32 value)
        {
            hasBagSize = true;
            BagSize_ = value;
        }

        public const int itemFieldNumber = 2;
        private pbc::PopsicleList<DataItemMessage> item_ = new pbc::PopsicleList<DataItemMessage>();
        public scg::IList<DataItemMessage> itemList
        {
            get { return pbc::Lists.AsReadOnly(item_); }
        }

        public int itemCount
        {
            get { return item_.Count; }
        }

        public DataItemMessage GetItem(int index)
        {
            return item_[index];
        }
        public void AddItem(DataItemMessage value)
        {
            item_.Add(value);
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasBagSize)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, BagSize);
            }
            {
                foreach (DataItemMessage element in itemList)
                {
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

            if (HasBagSize)
            {
                output.WriteInt32(1, BagSize);
            }

            do
            {
                foreach (DataItemMessage element in itemList)
                {
                    output.WriteTag((int)2, pb::WireFormat.WireType.LengthDelimited);
                    output.WriteRawVarint32((uint)element.SerializedSize());
                    element.WriteTo(output);

                }
            } while (false);
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15203 _inst = (SC15203)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.BagSize = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            DataItemMessage subBuilder = new DataItemMessage();
                            input.ReadMessage(subBuilder);
                            AddItem(subBuilder);
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasBagSize) return false;
            foreach (DataItemMessage element in itemList)
            {
                if (!element.IsInitialized()) return false;
            }
            return true;
        }

    }


    [Serializable]
    public class SC15204 : PacketDistributed
    {

        public const int isSuccessFieldNumber = 1;
        private bool hasIsSuccess;
        private Int32 isSuccess_ = 0;
        public bool HasIsSuccess
        {
            get { return hasIsSuccess; }
        }
        public Int32 IsSuccess
        {
            get { return isSuccess_; }
            set { SetIsSuccess(value); }
        }
        public void SetIsSuccess(Int32 value)
        {
            hasIsSuccess = true;
            isSuccess_ = value;
        }

        public const int itemguidFieldNumber = 2;
        private bool hasItemguid;
        private string itemguid_ = "";
        public bool HasItemguid
        {
            get { return hasItemguid; }
        }
        public string Itemguid
        {
            get { return itemguid_; }
            set { SetItemguid(value); }
        }
        public void SetItemguid(string value)
        {
            hasItemguid = true;
            itemguid_ = value;
        }

        public const int captainIdxFieldNumber = 3;
        private bool hasCaptainIdx;
        private Int32 captainIdx_ = 0;
        public bool HasCaptainIdx
        {
            get { return hasCaptainIdx; }
        }
        public Int32 CaptainIdx
        {
            get { return captainIdx_; }
            set { SetCaptainIdx(value); }
        }
        public void SetCaptainIdx(Int32 value)
        {
            hasCaptainIdx = true;
            captainIdx_ = value;
        }

        public const int captainPosFieldNumber = 4;
        private bool hasCaptainPos;
        private Int32 captainPos_ = 0;
        public bool HasCaptainPos
        {
            get { return hasCaptainPos; }
        }
        public Int32 CaptainPos
        {
            get { return captainPos_; }
            set { SetCaptainPos(value); }
        }
        public void SetCaptainPos(Int32 value)
        {
            hasCaptainPos = true;
            captainPos_ = value;
        }

        public const int useditemguidFieldNumber = 5;
        private bool hasUseditemguid;
        private string useditemguid_ = "";
        public bool HasUseditemguid
        {
            get { return hasUseditemguid; }
        }
        public string Useditemguid
        {
            get { return useditemguid_; }
            set { SetUseditemguid(value); }
        }
        public void SetUseditemguid(string value)
        {
            hasUseditemguid = true;
            useditemguid_ = value;
        }

        public const int usedcaptainIdxFieldNumber = 6;
        private bool hasUsedcaptainIdx;
        private Int32 usedcaptainIdx_ = 0;
        public bool HasUsedcaptainIdx
        {
            get { return hasUsedcaptainIdx; }
        }
        public Int32 UsedcaptainIdx
        {
            get { return usedcaptainIdx_; }
            set { SetUsedcaptainIdx(value); }
        }
        public void SetUsedcaptainIdx(Int32 value)
        {
            hasUsedcaptainIdx = true;
            usedcaptainIdx_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasIsSuccess)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, IsSuccess);
            }
            if (HasItemguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(2, Itemguid);
            }
            if (HasCaptainIdx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(3, CaptainIdx);
            }
            if (HasCaptainPos)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(4, CaptainPos);
            }
            if (HasUseditemguid)
            {
                size += pb::CodedOutputStream.ComputeStringSize(5, Useditemguid);
            }
            if (HasUsedcaptainIdx)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(6, UsedcaptainIdx);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasIsSuccess)
            {
                output.WriteInt32(1, IsSuccess);
            }

            if (HasItemguid)
            {
                output.WriteString(2, Itemguid);
            }

            if (HasCaptainIdx)
            {
                output.WriteInt32(3, CaptainIdx);
            }

            if (HasCaptainPos)
            {
                output.WriteInt32(4, CaptainPos);
            }

            if (HasUseditemguid)
            {
                output.WriteString(5, Useditemguid);
            }

            if (HasUsedcaptainIdx)
            {
                output.WriteInt32(6, UsedcaptainIdx);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC15204 _inst = (SC15204)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.IsSuccess = input.ReadInt32();
                            break;
                        }
                    case 18:
                        {
                            _inst.Itemguid = input.ReadString();
                            break;
                        }
                    case 24:
                        {
                            _inst.CaptainIdx = input.ReadInt32();
                            break;
                        }
                    case 32:
                        {
                            _inst.CaptainPos = input.ReadInt32();
                            break;
                        }
                    case 42:
                        {
                            _inst.Useditemguid = input.ReadString();
                            break;
                        }
                    case 48:
                        {
                            _inst.UsedcaptainIdx = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasIsSuccess) return false;
            return true;
        }

    }


    [Serializable]
    public class SC20000 : PacketDistributed
    {

        public const int erroridFieldNumber = 1;
        private bool hasErrorid;
        private Int32 errorid_ = 0;
        public bool HasErrorid
        {
            get { return hasErrorid; }
        }
        public Int32 Errorid
        {
            get { return errorid_; }
            set { SetErrorid(value); }
        }
        public void SetErrorid(Int32 value)
        {
            hasErrorid = true;
            errorid_ = value;
        }

        private int memoizedSerializedSize = -1;
        public override int SerializedSize()
        {
            int size = memoizedSerializedSize;
            if (size != -1) return size;
            size = 0;
            if (HasErrorid)
            {
                size += pb::CodedOutputStream.ComputeInt32Size(1, Errorid);
            }
            memoizedSerializedSize = size;
            return size;
        }

        public override void WriteTo(pb::CodedOutputStream output)
        {
            int size = SerializedSize();

            if (HasErrorid)
            {
                output.WriteInt32(1, Errorid);
            }
        }
        public override PacketDistributed MergeFrom(pb::CodedInputStream input, PacketDistributed _base)
        {
            SC20000 _inst = (SC20000)_base;
            while (true)
            {
                uint tag = input.ReadTag();
                switch (tag)
                {
                    case 0:
                        {
                            return _inst;
                        }
                    case 8:
                        {
                            _inst.Errorid = input.ReadInt32();
                            break;
                        }

                }
            }
            return _inst;
        }
        //end merged
        public override bool IsInitialized()
        {
            if (!hasErrorid) return false;
            return true;
        }

    }


}
