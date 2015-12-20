using UnityEngine;
using System.Collections;
using System.IO;
using LuaGame;

public class EntryPoint : MonoBehaviour {

    static EntryPoint _instance = null;
    public static EntryPoint Instance
    {
        get { return _instance; }
    }

    private LuaScriptMgr lua = null;

    IEnumerator RunApp()
    {
        yield return StartCoroutine(SetupPath());
        yield return StartCoroutine(SetupManager());
        yield return StartCoroutine(SetupLua());
        //yield return null;
    }

    IEnumerator SetupPath()
    {
        //E:/UnityWorks/WorkHere/sLuaGame/UnityProject/Assets/../Output/
        string AssetsPath = Util.DataPath;
        LuaScriptMgr.LuaBasePath = Path.Combine(AssetsPath, "Lua");
        LuaScriptMgr.LuaConfigPath = Path.Combine(AssetsPath, "Configs");
#if ASYNC_MODE
        ResourceManager.BaseDownloadingURL = Util.GetRelativePath() + AppConst.AssetDirname + "/";
#endif

        Debug.Log("AssetsPath:" + AssetsPath);
        Debug.Log("LuaBasePath:" + LuaScriptMgr.LuaBasePath);
        Debug.Log("LuaConfigPath:" + LuaScriptMgr.LuaConfigPath);
        Debug.Log("StreamingAssets:" + ResourceManager.BaseDownloadingURL);
        //Debug.Log("streamingAssetsPath:" + Application.streamingAssetsPath);
        yield return null;
    }

    IEnumerator SetupManager()
    {
        GameObject go = new GameObject("GameManager");
        go.tag = "GameManager";
        ResourceManager.TouchInstance(ref go);
        PanelManager.TouchInstance(ref go);
        NetworkManager.TouchInstance(ref go);

        GameObject evt = new GameObject("EventSystem");
        evt.AddComponent<UnityEngine.EventSystems.EventSystem>();
        evt.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        evt.AddComponent<UnityEngine.EventSystems.TouchInputModule>();
        
        var request = ResourceManager.Initialize(AppConst.AssetDirname);
        if (request != null)
            yield return StartCoroutine(request);
    }

    IEnumerator SetupLua()
    {
        lua = new LuaScriptMgr();
        lua.Start();

        yield return null;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;

        StartCoroutine(RunApp());
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
