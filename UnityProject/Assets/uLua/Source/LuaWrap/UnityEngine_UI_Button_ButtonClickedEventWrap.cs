using System;
using LuaInterface;

public class UnityEngine_UI_Button_ButtonClickedEventWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateUnityEngine_UI_Button_ButtonClickedEvent),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("unbind", Lua_UnBind),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isNil", get_isNil, null),
		};

		LuaScriptMgr.RegisterLib(L, "UnityEngine.UI.Button.ButtonClickedEvent", typeof(UnityEngine.UI.Button.ButtonClickedEvent), regs, fields, typeof(UnityEngine.Events.UnityEvent));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_UI_Button_ButtonClickedEvent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			UnityEngine.UI.Button.ButtonClickedEvent obj = new UnityEngine.UI.Button.ButtonClickedEvent();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UnityEngine.UI.Button.ButtonClickedEvent.New");
		}

		return 0;
	}

	static Type classType = typeof(UnityEngine.UI.Button.ButtonClickedEvent);

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
		UnityEngine.UI.Button.ButtonClickedEvent obj = (UnityEngine.UI.Button.ButtonClickedEvent)o;

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
}

