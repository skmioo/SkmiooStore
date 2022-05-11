using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

		//luaCallCSharpCode();
		//LuaReturnData();
	}


	void luaCallCSharpCode()
	{
		LuaEnv luaEnv = new LuaEnv();
		luaEnv.DoString("CS.UnityEngine.Debug.Log('Hello World')");
		luaEnv.Dispose();
	}

	private void LuaReturnData()
	{
		LuaEnv luaEnv = new LuaEnv();
		object[] data = luaEnv.DoString("return 100, true");
		Debug.Log("data:" + data[0].ToString() + " " + data[1].ToString());
		luaEnv.Dispose();
	}

}
