using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class LuaGame_ResourceManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("TouchInstance", TouchInstance),
			new LuaMethod("LoadAsset", LoadAsset),
			new LuaMethod("GetLoadedAssetBundle", GetLoadedAssetBundle),
			new LuaMethod("Initialize", Initialize),
			new LuaMethod("UnloadAssetBundle", UnloadAssetBundle),
			new LuaMethod("LoadAssetAsync", LoadAssetAsync),
			new LuaMethod("New", _CreateLuaGame_ResourceManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
			new LuaMethod("unbind", Lua_UnBind),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Instance", get_Instance, null),
			new LuaField("BaseDownloadingURL", get_BaseDownloadingURL, set_BaseDownloadingURL),
			new LuaField("Variants", get_Variants, set_Variants),
			new LuaField("AssetBundleManifestObject", null, set_AssetBundleManifestObject),
			new LuaField("isNil", get_isNil, null),
		};

		LuaScriptMgr.RegisterLib(L, "LuaGame.ResourceManager", typeof(LuaGame.ResourceManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateLuaGame_ResourceManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaGame.ResourceManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(LuaGame.ResourceManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Instance(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaGame.ResourceManager.Instance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BaseDownloadingURL(IntPtr L)
	{
		LuaScriptMgr.Push(L, LuaGame.ResourceManager.BaseDownloadingURL);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Variants(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, LuaGame.ResourceManager.Variants);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNil(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		LuaGame.ResourceManager obj = (LuaGame.ResourceManager)o;

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
	static int set_BaseDownloadingURL(IntPtr L)
	{
		LuaGame.ResourceManager.BaseDownloadingURL = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Variants(IntPtr L)
	{
		LuaGame.ResourceManager.Variants = LuaScriptMgr.GetArrayString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AssetBundleManifestObject(IntPtr L)
	{
		LuaGame.ResourceManager.AssetBundleManifestObject = (AssetBundleManifest)LuaScriptMgr.GetUnityObject(L, 3, typeof(AssetBundleManifest));
		return 0;
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
		LuaGame.ResourceManager o = LuaGame.ResourceManager.TouchInstance(ref arg0);
		LuaScriptMgr.Push(L, o);
		LuaScriptMgr.Push(L, arg0);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		LuaGame.ResourceManager obj = (LuaGame.ResourceManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "LuaGame.ResourceManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		LuaFunction arg2 = LuaScriptMgr.GetLuaFunction(L, 4);
		obj.LoadAsset(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLoadedAssetBundle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = null;
		LuaGame.AssetBundleInfo o = LuaGame.ResourceManager.GetLoadedAssetBundle(arg0,out arg1);
		LuaScriptMgr.PushObject(L, o);
		LuaScriptMgr.Push(L, arg1);
		return 2;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		LuaGame.AssetBundleManifestOperation o = LuaGame.ResourceManager.Initialize(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnloadAssetBundle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		LuaGame.ResourceManager.UnloadAssetBundle(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadAssetAsync(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Type arg2 = LuaScriptMgr.GetTypeObject(L, 3);
		LuaGame.AssetBundleAssetOperation o = LuaGame.ResourceManager.LoadAssetAsync(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
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

