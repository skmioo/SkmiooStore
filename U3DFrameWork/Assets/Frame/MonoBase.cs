using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public abstract class MonoBase : MonoBehaviour
{
    public abstract void ProcessEvent(MsgBase tmpMsg);
}

