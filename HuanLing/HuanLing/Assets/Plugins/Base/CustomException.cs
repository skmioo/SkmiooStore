using UnityEngine;
using System.Collections.Generic;

namespace UYMO
{
	public class UnimplementedException : System.Exception {

		public UnimplementedException(string message)
			: base(message)
		{
		}
	}
    public class EngineException : UnimplementedException
    {
        public EngineException(string expMsg) : base("Engine Exception: " + expMsg)
        {
            //
        }
    }
}
