using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tweleven_Transparent_ReplacementShader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		//此处会把"rendertype" = "transparent"的替换为12_Transparent_ReplacementShader
		Camera.main.SetReplacementShader(Shader.Find("Skmioo/12_Transparent_ReplacementShader"), "rendertype");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
