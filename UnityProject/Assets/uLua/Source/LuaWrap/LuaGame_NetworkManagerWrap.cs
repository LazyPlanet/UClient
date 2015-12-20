using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class LuaGame_NetworkManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("TouchInstance", TouchInstance),
			new LuaMethod("SendConnect", SendConnect),
			new LuaMethod("SendMessage", SendMessage),
			new LuaMethod("AddEvent", AddEvent),
			new LuaMethod("ConnectToServer", ConnectToServer),
			new LuaMethod("New", _CreateLuaGame_NetworkManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
			new LuaMethod("unbind", Lua_UnBind),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("IsConnected", get_IsConnected, null),
			new LuaField("isNil", get_isNil, null),
		};

		LuaScriptMgr.RegisterLib(L, "LuaGame.NetworkManager", typeof(LuaGame.NetworkManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaGame_NetworkManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaGame.NetworkManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(LuaGame.NetworkManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaGame.NetworkManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsConnected(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.NetworkManager obj = (LuaGame.NetworkManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsConnected");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsConnected on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsConnected);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNil(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.NetworkManager obj = (LuaGame.NetworkManager)o;

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
		LuaGame.NetworkManager o = LuaGame.NetworkManager.TouchInstance(ref arg0);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg0);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendConnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		LuaGame.NetworkManager obj = (LuaGame.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.NetworkManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.SendConnect(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaGame.NetworkManager obj = (LuaGame.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.NetworkManager");
		LuaGame.ByteBuffer arg0 = (LuaGame.ByteBuffer)LuaScriptMgr.GetNetObject(L, 2, typeof(LuaGame.ByteBuffer));
		obj.SendMessage(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		LuaGame.ByteBuffer arg1 = (LuaGame.ByteBuffer)LuaScriptMgr.GetNetObject(L, 2, typeof(LuaGame.ByteBuffer));
		LuaGame.NetworkManager.AddEvent(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ConnectToServer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		LuaGame.NetworkManager obj = (LuaGame.NetworkManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.NetworkManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		LuaGame.ByteBuffer arg2 = (LuaGame.ByteBuffer)LuaScriptMgr.GetNetObject(L, 4, typeof(LuaGame.ByteBuffer));
		obj.ConnectToServer(arg0,arg1,arg2);
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

