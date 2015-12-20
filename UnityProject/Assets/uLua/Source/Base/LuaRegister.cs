using UnityEngine;
using System.Collections;
using System;

public class LuaRegister {
    //这里添加所有需要注册的模块
    public static void Register(IntPtr l)
    {
        GameUtilWrap.Register(l);
        LuaUtilWrap.Register(l);
        
    }
}
