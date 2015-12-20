using System;
using UnityEngine;
using LuaInterface;

public class NetworkReachabilityWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("NotReachable", GetNotReachable),
		new LuaMethod("ReachableViaCarrierDataNetwork", GetReachableViaCarrierDataNetwork),
		new LuaMethod("ReachableViaLocalAreaNetwork", GetReachableViaLocalAreaNetwork),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UnityEngine.NetworkReachability", typeof(UnityEngine.NetworkReachability), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetNotReachable(IntPtr L)
	{
		LuaScriptMgr.Push(L, NetworkReachability.NotReachable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReachableViaCarrierDataNetwork(IntPtr L)
	{
		LuaScriptMgr.Push(L, NetworkReachability.ReachableViaCarrierDataNetwork);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetReachableViaLocalAreaNetwork(IntPtr L)
	{
		LuaScriptMgr.Push(L, NetworkReachability.ReachableViaLocalAreaNetwork);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		NetworkReachability o = (NetworkReachability)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

