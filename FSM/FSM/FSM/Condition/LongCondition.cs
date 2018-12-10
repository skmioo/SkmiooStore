using System;
using System.Collections.Generic;
namespace FSM
{
    public class LongCondition : ITransactionCondition
    {
        public const byte EQUALS = 0;
        public const byte SMALLER = 1;
        public const byte LARGER = 2;
        public const byte NOT_EQUALS = 3;

        private string key;
        private byte compareType;
        private long compareValue;

        /**
         * 
         * @param key
         * @param compareType
         * @param compareValue
         */
        public LongCondition(string key, byte compareType, long compareValue)
        {
            this.key = key;
            this.compareType = compareType;
            this.compareValue = compareValue;
            if (compareType != EQUALS && compareType != LARGER && compareType != SMALLER)
            {
                throw new ArgumentException("compareType can noly be one of the IntCondition.EQUALS、IntCondition.LARGER、IntCondition.SMALLER");
            }
        }

        public bool Check(Dictionary<string, int> intParams, Dictionary<string, bool> boolParams, Dictionary<string, long> longParams)
        {
            if (longParams.ContainsKey(key))
            {
                long longData = longParams[key];
                switch (compareType)
                {
                    case EQUALS:
                        return longData == compareValue;
                    case LARGER:
                        return longData > compareValue;
                    case SMALLER:
                        return longData < compareValue;
                    case NOT_EQUALS:
                        return longData != compareValue;
                }
            }
           
            return false;
        }
    }
}
