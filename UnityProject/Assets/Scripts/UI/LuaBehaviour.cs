using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace LuaGame
{
    public class LuaBehaviour : MonoBehaviour {
        private List<LuaFunction> buttons = new List<LuaFunction>();
        private LuaTable msgHandle = null;
        protected static bool initialize = false;

        protected void Awake() {
            initialize = true;
            CallMethod("onAwake", gameObject);
        }

        protected void Start() {
            CallMethod("onStart");
        }

        protected void OnDestroy()
        {
            CallMethod("onDestroy");
            UnTouchGUIMsg();
            initialize = false;
#if ASYNC_MODE
            string abName = name.ToLower();
            ResourceManager.UnloadAssetBundle(abName + AppConst.ExtName);
#endif
            Debug.Log("~" + name + " was destroy!");
        }
        /// <summary>
        /// 添加单击事件
        /// </summary>
        public void AddClick(GameObject go, LuaFunction luafunc) {
            if (go == null) return;
            buttons.Add(luafunc);
            go.GetComponent<Button>().onClick.AddListener(
                delegate() {
                    luafunc.Call(go);
                }
            );
        }

        /// <summary>
        /// 清除单击事件
        /// </summary>
        public void ClearClick() {
            for (int i = 0; i < buttons.Count; i++) {
                if (buttons[i] != null) {
                    buttons[i].Dispose();
                    buttons[i] = null;
                }
            }
        }

        public void UnTouchGUIMsg()
        {
            ClearClick();
            DetachEventHandle();
            msgHandle = null;
        }

        public void TouchGUIMsg(LuaTable luaMsgHandler)
        {
            msgHandle = luaMsgHandler;
            AttachEventHandle();
        }

        [ContextMenu("UnTouchEvent")]
        public void DetachEventHandle()
        {
            UnTouchButton();
        }

        [ContextMenu("TouchEvent")]
        public void AttachEventHandle()
        {
            DetachEventHandle();

            TouchButton();
        }

        void TouchButton()
        {
            var comps = gameObject.GetComponentsInChildren<Button>(true);
            int Length = comps.Length;
            for(int i=0;i<Length;++i)
            {
                Button button = comps[i];
                EventTriggerListener.Get(button.gameObject).onClick += onClick;
            }
        }
        void UnTouchButton()
        {
            var comps = gameObject.GetComponentsInChildren<Button>(true);
            int Length = comps.Length;
            for (int i = 0; i < Length; ++i)
            {
                Button button = comps[i];
                EventTriggerListener.Get(button.gameObject).onClick -= onClick;
            }
        }


        void onClick(GameObject go)
        {
            CallMethod("onClick",go);
        }

        /// <summary>
        /// 执行Lua方法
        /// </summary>
        object[] CallMethod(string func, params object[] args) {
            if (!initialize || null == msgHandle) return null;
            LuaFunction cb = msgHandle.RawGetFunc(func);
            if (null != cb)
                return cb.Call(args);
            else
            {
                Debug.LogWarning(string.Format("function {0} is not exits", func));
                return null;
            }
        }

        //-----------------------------------------------------------------
    }
}