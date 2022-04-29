using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//添加BoxCollider
[RequireComponent(typeof(BoxCollider))]
// Update()会在场景中对象发生变化或者项目组织发生变化时调用
[ExecuteInEditMode]
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("111");
    }
}
