using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		LuaEnv luaEnv = new LuaEnv();
		luaEnv.DoString("require('test')");
		luaEnv.Dispose();
	}

}
