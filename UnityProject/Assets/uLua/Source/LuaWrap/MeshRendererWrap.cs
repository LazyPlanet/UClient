using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MeshRendererWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateMeshRenderer),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
			new LuaMethod("unbind", Lua_UnBind),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("additionalVertexStreams", get_additionalVertexStreams, set_additionalVertexStreams),
			new LuaField("isNil", get_isNil, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.MeshRenderer", typeof(MeshRenderer), regs, fields, typeof(Renderer));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMeshRenderer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			MeshRenderer obj = new MeshRenderer();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MeshRenderer.New");
		}

		return 0;
	}

	static Type classType = typeof(MeshRenderer);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_additionalVertexStreams(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshRenderer obj = (MeshRenderer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name additionalVertexStreams");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index additionalVertexStreams on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.additionalVertexStreams);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNil(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshRenderer obj = (MeshRenderer)o;

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
	static int set_additionalVertexStreams(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MeshRenderer obj = (MeshRenderer)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name additionalVertexStreams");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index additionalVertexStreams on a nil value");
			}
		}

		obj.additionalVertexStreams = (Mesh)LuaScriptMgr.GetUnityObject(L, 3, typeof(Mesh));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_UnBind(IntPtr L)
	{
		LuaScriptMgr.__gc(L);

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

