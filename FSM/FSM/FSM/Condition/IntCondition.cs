using System;
using System.Collections.Generic;

namespace FSM
{
    public class IntCondition : ITransactionCondition
    {
        public const byte EQUALS = 0;
        public const byte SMALLER = 1;
        public const byte LARGER = 2;
        public const byte NOT_EQUALS = 3;

        private string key;
        private byte compareType;
        private int compareValue;

        public IntCondition(string key, byte compareType, int compareValue)
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
            if (intParams.ContainsKey(key))
            {
                int integer = intParams[key];
                switch (compareType)
                {
                    case EQUALS:
                        return integer == compareValue;
                    case LARGER:
                        return integer > compareValue;
                    case SMALLER:
                        return integer < compareValue;
                    case NOT_EQUALS:
                        return integer != compareValue;
                }
            }
            return false;
        }
    }
}
