using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LuaInterface;

namespace LuaGame
{
    public class PanelManager : MonoBehaviour
    {
        private static PanelManager _instance = null;
        public static PanelManager TouchInstance(ref GameObject go)
        {
            _instance = go.GetComponent<PanelManager>();
            if (null == _instance)
            {
                _instance = go.AddComponent<PanelManager>();
            }
            return _instance;
        }
        public static PanelManager Instance
        {
            get { return _instance; }
        }


        private Transform guiroot;

        public Transform guiRoot {
            get {
                if (guiroot == null) {
                    GameObject go = new GameObject("GuiCamera");
                    go.tag = "GuiCamera";
                    go.transform.SetParent(Root);
                    go.transform.localPosition = Vector3.zero;
                    go.transform.localScale = Vector3.one;
                    Camera c = go.AddComponent<Camera>();
                    c.clearFlags = CameraClearFlags.Skybox;
                    go.AddComponent<FlareLayer>();
                    go.AddComponent<GUILayer>();
                    go.AddComponent<AudioListener>();

                    guiroot = go.transform;
                    
                }
                return guiroot;
            }
        }

        private Transform root;
        public Transform Root
        {
            get
            {
                if(root == null)
                {
                    GameObject go = new GameObject("UIRoot2D");
                    go.AddComponent<RectTransform>();
                    Canvas c = go.AddComponent<Canvas>();
                    c.renderMode = RenderMode.ScreenSpaceOverlay;
                    CanvasScaler cs = go.AddComponent<CanvasScaler>();
                    GraphicRaycaster gr = go.AddComponent<GraphicRaycaster>();

                    root = go.transform;
                }
                return root;
            }
        }
        
#if ASYNC_MODE
        /// <summary>
        /// 创建面板，请求资源管理器
        /// </summary>
        /// <param name="type"></param>
        public void CreatePanel(string name, LuaFunction func = null) {
            StartCoroutine(OnCreatePanel(name, func));
        }

        IEnumerator OnCreatePanel(string name, LuaFunction func = null) {
            yield return StartCoroutine(Initialize());

            string assetName = name;
            // Load asset from assetBundle.
            string abName = name.ToLower() + AppConst.ExtName;
            AssetBundleAssetOperation request = ResourceManager.LoadAssetAsync(abName, assetName, typeof(GameObject));
            if (request == null) yield break;
            yield return StartCoroutine(request);

            // Get the asset.
            GameObject prefab = request.GetAsset<GameObject>();

            GameObject go = Instantiate(prefab) as GameObject;
            go.name = assetName;
            go.layer = LayerMask.NameToLayer("Default");
            go.transform.SetParent(guiRoot);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            
            if (func != null) func.Call(go);
            Debug.LogWarning("CreatePanel-->> " + name);
        }

        IEnumerator Initialize() {
            // Initialize AssetBundleManifest which loads the AssetBundleManifest object.
            var request = ResourceManager.Initialize(AppConst.AssetDirname);
            if (request != null)
                yield return StartCoroutine(request);
        }
#else
        /// <summary>
        /// 创建面板，请求资源管理器
        /// </summary>
        /// <param name="type"></param>
        public void CreatePanel(string name, LuaFunction func = null) {
            string assetName = name + "Panel";
            GameObject prefab = ResManager.LoadAsset(name, assetName);
            if (Parent.FindChild(name) != null || prefab == null) {
                return;
            }
            GameObject go = Instantiate(prefab) as GameObject;
            go.name = assetName;
            go.layer = LayerMask.NameToLayer("Default");
            go.transform.SetParent(Parent);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
            go.AddComponent<LuaBehaviour>();

            if (func != null) func.Call(go);
            Debug.LogWarning("CreatePanel::>> " + name + " " + prefab);
        }
#endif
    }
}