using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class LuaGame_PanelManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("TouchInstance", TouchInstance),
			new LuaMethod("CreatePanel", CreatePanel),
			new LuaMethod("New", _CreateLuaGame_PanelManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
			new LuaMethod("unbind", Lua_UnBind),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("guiRoot", get_guiRoot, null),
			new LuaField("Root", get_Root, null),
			new LuaField("isNil", get_isNil, null),
		};

		LuaScriptMgr.RegisterLib(L, "LuaGame.PanelManager", typeof(LuaGame.PanelManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaGame_PanelManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaGame.PanelManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(LuaGame.PanelManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaGame.PanelManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_guiRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.PanelManager obj = (LuaGame.PanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name guiRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index guiRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.guiRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Root(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.PanelManager obj = (LuaGame.PanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Root");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Root on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Root);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNil(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.PanelManager obj = (LuaGame.PanelManager)o;

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
	static int TouchInstance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		LuaGame.PanelManager o = LuaGame.PanelManager.TouchInstance(ref arg0);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg0);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LuaGame.PanelManager obj = (LuaGame.PanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.PanelManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 3);
		obj.CreatePanel(arg0,arg1);
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

