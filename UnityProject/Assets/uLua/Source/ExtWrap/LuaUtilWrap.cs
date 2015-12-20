using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using LuaInterface;
using System;
using Junfine.Debuger;

public static class LuaUtilWrap
{

    public static void Register(IntPtr L)
    {
        LuaMethod[] regs = new LuaMethod[]
        {
                new LuaMethod("GetType", GetType),
        };

        LuaScriptMgr.RegisterLib(L, "LuaUtil", regs);
    }
    /// <summary>
    /// GetType
    /// </summary>
    /// <param name="classname"></param>
    /// <returns></returns>
    public static System.Type GetType(string classname)
    {
        Assembly assb = Assembly.GetExecutingAssembly();  //.GetExecutingAssembly();
        System.Type t = null;
        t = assb.GetType(classname); ;
        if (t == null)
        {
            t = assb.GetType(classname);
        }
        return t;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int GetType(IntPtr L)
    {
        string classname = LuaScriptMgr.GetString(L, 1);
        Type t = GetType(classname);

        LuaScriptMgr.Push(L, t);

        return 1;
    }
}