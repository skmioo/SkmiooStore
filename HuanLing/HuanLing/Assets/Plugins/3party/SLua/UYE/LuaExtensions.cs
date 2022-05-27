using SLua;
using System.Collections.Generic;
using UnityEngine;

namespace SLua
{
    public static class LuaExtensions
    {
        public static object CallStaticMethod(this LuaTable table, string function)
        {
            if (table == null)
                return null;
            LuaFunction func = table[function] as LuaFunction;
            if (func == null)
                return null;

            try
            {
                return func.call();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
            return null;
        }

        public static object CallStaticMethod(this LuaTable table, string function, object a1)
        {
            if (table == null)
                return null;
            LuaFunction func = table[function] as LuaFunction;
            if (func == null)
                return null;

            try
            {
                return func.call(a1);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
            return null;
        }

        public static object CallStaticMethod(this LuaTable table, string function, object a1, object a2)
        {
            if (table == null)
                return null;
            LuaFunction func = table[function] as LuaFunction;
            if (func == null)
                return null;

            try
            {
                return func.call(a1, a2);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
            return null;
        }

        public static object CallStaticMethod(this LuaTable table, string function, object a1, object a2, object a3)
        {
            if (table == null)
                return null;
            LuaFunction func = table[function] as LuaFunction;
            if (func == null)
                return null;

            try
            {
                return func.call(a1, a2, a3);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
            return null;
        }

        public static object CallStaticMethod(this LuaTable table, string function, params object[] args)
        {
            if (table == null)
                return null;
            LuaFunction func = table[function] as LuaFunction;
            if (func == null)
                return null;
        
            try
            {
                return args == null ? func.call() : func.call(args);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
            return null;
        }

        public static object CallMethod(this LuaTable table, string func)
        {
            return table.CallStaticMethod(func, table);
        }

        public static object CallMethod(this LuaTable table, string func, object a1)
        {
            return table.CallStaticMethod(func, table, a1);
        }

        public static object CallMethod(this LuaTable table, string func, object a1, object a2)
        {
            return table.CallStaticMethod(func, table, a1, a2);
        }

        static object[][] sArrayPool = new object[18][];//参数数组缓存，最多支持18个...
        public static object CallMethod(this LuaTable table, string function, params object[] args)
        {
            if (args != null)
            {
                int nlength = args.Length + 1;
                object[] nArgs = sArrayPool[nlength];
                if(nArgs ==null)
                {
                    nArgs = new object[nlength];
                    sArrayPool[nlength] = nArgs;
                }
                nArgs[0] = table;
                for (int idx = 0; idx < args.Length && idx < nArgs.Length - 1; ++idx)
                {
                    nArgs[idx + 1] = args[idx];
                }
                return table.CallStaticMethod(function, nArgs);
            }
            else
            {
                return table.CallMethod(function);
            }
        }
    }
}
