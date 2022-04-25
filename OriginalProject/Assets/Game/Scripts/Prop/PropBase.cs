using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Datas;

/// <summary>
/// 所有道具功能基类,
/// 子类重写GoAction,实现具体的功能
/// </summary>
public class PropBase : MonoBehaviour
{
    //show启动后面再做
    protected ObjData objData;
    protected ObjLife objLife;


    public void InitProp(ObjData _objData,ObjLife _target)
    {
        objData = _objData;
        objLife = _target;

        GoAction();
    }

    protected virtual void GoAction()
    {
        
    }

}
