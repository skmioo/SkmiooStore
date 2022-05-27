using SLua;

namespace UYMO
{
    [CustomLuaClassAttribute]
    [System.Serializable]
    public struct ResID
    {
        /// <summary>
        /// 空id，全0
        /// </summary>
        public static ResID zero
        {
            get { return new ResID(0, 0, 0); }
        }
        /// <summary>
        /// 一个出错的id，用来特殊处理，全-1
        /// </summary>
        public static ResID errorID
        {
            get { return new ResID(-1, -1, -1); }
        }

        [UnityEngine.SerializeField]
        public int packId;

        [UnityEngine.SerializeField]
        public int grpId;

        [UnityEngine.SerializeField]
        public int resId;

        public ResID(int pack, int grp, int res)
        {
            packId = pack;
            grpId = grp;
            resId = res;
        }

        /// <summary>
        /// 资源id是否有效（只要pack id大于0就算有效）
        /// </summary>
        public bool valid
        {
            get { return packId > 0; }
        }
        /// <summary>
        /// 判断id是否全0
        /// </summary>
        public bool isZero
        {
            get { return packId == 0 && grpId == 0 && resId == 0; }
        }
        /// <summary>
        /// 判断错误id，全-1
        /// </summary>
        public bool isError
        {
            get { return packId == -1 && grpId == -1 && resId == -1; }
        }

        public bool isFullID
        {
            get { return packId > 0 && grpId > 0 && resId > 0; }
        }

        public int this[int idx]
        {
            get
            {
                switch(idx)
                {
                    case 0: return packId;
                    case 1: return grpId;
                    case 2: return resId;
                    default:
                        throw new System.InvalidProgramException("索引超出范围..");
                }
            }
            set
            {
                switch(idx)
                {
                    case 0: packId = value; break;
                    case 1: grpId = value; break;
                    case 2: resId = value; break;
                    default:
                        throw new System.InvalidProgramException("索引超出范围..");
                }
            }
        }

        public int length { get { return 3; } }


        public static bool operator ==(ResID l, ResID r)
        {
            return l.packId == r.packId && l.grpId == r.grpId && l.resId == r.resId;
        }

        public static bool operator !=(ResID l, ResID r)
        {
            return l.packId != r.packId || l.grpId != r.grpId || l.resId != r.resId;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            bool bResID = obj is ResID;
            if (!bResID)
                return false;

            ResID rh = (ResID)obj;
            if (rh.isZero)
            {
                return false;
            }
            return packId == rh.packId && grpId == rh.grpId && resId == rh.resId;
        }

        static int sTypeHasCode = 0;
        public override int GetHashCode()
        {
            if(sTypeHasCode == 0)
            {
                sTypeHasCode = GetType().GetHashCode();
            }
            return sTypeHasCode ^ packId.GetHashCode() ^ grpId.GetHashCode() ^ resId.GetHashCode();
        }

        public string ToCfgStr()
        {
            return MakeString(",");
        }
        public string MakeString(string spliter)
        {
            return packId + spliter + grpId + spliter + resId;
        }

        public override string ToString()
        {
            return string.Format("ResID:{0}_{1}_{2}", packId, grpId, resId);
        }
    }

}