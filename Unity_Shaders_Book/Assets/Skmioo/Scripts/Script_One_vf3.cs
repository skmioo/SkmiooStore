using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_One_vf3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
		GetComponent<Renderer>().material.SetVector("_SecondColor", new Vector4(1f, 0, 0, 1.0f));
    }

    

}
