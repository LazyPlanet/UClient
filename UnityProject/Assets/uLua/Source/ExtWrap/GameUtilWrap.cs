using UnityEngine;
using System.Collections.Generic;
using System.Reflection;
using LuaInterface;
using System;
using Junfine.Debuger;
using LuaGame;

public static class GameUtilWrap
{

    public static void Register(IntPtr L)
    {
        LuaMethod[] regs = new LuaMethod[]
        {
                new LuaMethod("LoadAsset", LoadAsset),
                new LuaMethod("CreatePanel",CreatePanel),
        };

        LuaScriptMgr.RegisterLib(L, "GameUtil", regs);
    }

   [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int LoadAsset(IntPtr L)
    {
       // LuaScriptMgr.CheckArgsCount(L, 3);
        string arg0 = LuaScriptMgr.GetLuaString(L, 1);
        string arg1 = LuaScriptMgr.GetLuaString(L, 2);
        LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 3);
        ResourceManager.Instance.LoadAsset(arg0, arg1, arg2);
        return 0;
    }

    [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
    static int CreatePanel(IntPtr L)
    {
        LuaScriptMgr.CheckArgsCount(L, 2);
        string arg0 = LuaScriptMgr.GetLuaString(L, 1);
        LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
        PanelManager.Instance.CreatePanel(arg0, arg1);
        return 0;
    }
}