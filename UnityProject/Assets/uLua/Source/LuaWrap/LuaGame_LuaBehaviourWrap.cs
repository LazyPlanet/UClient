﻿using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class LuaGame_LuaBehaviourWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AddClick", AddClick),
			new LuaMethod("ClearClick", ClearClick),
			new LuaMethod("UnTouchGUIMsg", UnTouchGUIMsg),
			new LuaMethod("TouchGUIMsg", TouchGUIMsg),
			new LuaMethod("DetachEventHandle", DetachEventHandle),
			new LuaMethod("AttachEventHandle", AttachEventHandle),
			new LuaMethod("New", _CreateLuaGame_LuaBehaviour),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
			new LuaMethod("unbind", Lua_UnBind),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isNil", get_isNil, null),
		};

		LuaScriptMgr.RegisterLib(L, "LuaGame.LuaBehaviour", typeof(LuaGame.LuaBehaviour), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaGame_LuaBehaviour(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaGame.LuaBehaviour class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(LuaGame.LuaBehaviour);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNil(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)o;

		if (obj == null)
		{
			LuaScriptMgr.Push(L, true);
		}
		else {
			LuaScriptMgr.Push(L, false);
		}

		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_UnBind(IntPtr L)
	{
		LuaScriptMgr.__gc(L);

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.LuaBehaviour");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.AddClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.LuaBehaviour");
		obj.ClearClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnTouchGUIMsg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.LuaBehaviour");
		obj.UnTouchGUIMsg();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TouchGUIMsg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.LuaBehaviour");
		LuaTable arg0 = LuaScriptMgr.GetLuaTable(L, 2);
		obj.TouchGUIMsg(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DetachEventHandle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.LuaBehaviour");
		obj.DetachEventHandle();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AttachEventHandle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaGame.LuaBehaviour obj = (LuaGame.LuaBehaviour)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.LuaBehaviour");
		obj.AttachEventHandle();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

