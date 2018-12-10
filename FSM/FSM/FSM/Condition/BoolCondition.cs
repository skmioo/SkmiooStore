using System.Collections.Generic;

namespace FSM
{
    public class BoolCondition : ITransactionCondition
    {
        private string key;
        private bool expectValue;

        /**
         * 
         * @param key
         * @param expectValue
         */
        public BoolCondition(string key, bool expectValue)
        {
            this.key = key;
            this.expectValue = expectValue;
        }

       
        public bool Check(Dictionary<string, int> intParams, Dictionary<string, bool> boolParams, Dictionary<string, long> longParams)
        {
            if (boolParams.ContainsKey(key))
            {
                bool currBool = boolParams[key];
                return currBool == expectValue;
            }
            return false;
        }
    }
}
