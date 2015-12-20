using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LuaGame;

public class Packager {
    public static string platform = string.Empty;
    static List<string> paths = new List<string>();
    static List<string> files = new List<string>();

    /// <summary>
    /// 载入素材
    /// </summary>
    static UnityEngine.Object LoadAsset(string file) {
        if (file.EndsWith(".lua")) file += ".txt";
        return AssetDatabase.LoadMainAssetAtPath("Assets/Builds/" + file);
    }

    [MenuItem("Game/Build iPhone Resource", false, 11)]
    public static void BuildiPhoneResource() { 
        BuildAssetResource(BuildTarget.iOS, false);
    }

    [MenuItem("Game/Build Android Resource", false, 12)]
    public static void BuildAndroidResource() {
        BuildAssetResource(BuildTarget.Android, true);
    }

    [MenuItem("Game/Build Windows Resource", false, 13)]
    public static void BuildWindowsResource() {
        BuildAssetResource(BuildTarget.StandaloneWindows, true);
    }

    [MenuItem("Game/Bundle Name/Attach", false, 14)]
    [MenuItem("Assets/Bundle Name/Attach", false, 14)]
    public static void SetAssetBundleName()
    {
        Object[] selection = Selection.objects;

        AssetImporter import = null;
        foreach (Object s in selection)
        {
            import = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(s));
            import.assetBundleName = s.name + AppConst.ExtName;
        }
        AssetDatabase.Refresh();
    }
    [MenuItem("Game/Bundle Name/Detah", false, 14)]
    [MenuItem("Assets/Bundle Name/Detah", false, 14)]
    public static void ClearAssetBundleName()
    {
        Object[] selection = Selection.objects;

        AssetImporter import = null;
        foreach (Object s in selection)
        {
            import = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(s));
            import.assetBundleName = null;
        }
        AssetDatabase.Refresh();
    }
    //[MenuItem("Game/test")]
    //public static void ExportResource()
    //{
    //    string output = EditorUtility.OpenFolderPanel("Build Assets ", "Assets/StreamingAssets/", "");
    //    if (output.Length == 0)
    //        return;
    //    Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
    //    for (int i=0;i<selection.Length;++i)
    //        BuildPipeline.BuildAssetBundle(selection[i], null, Path.Combine(output,selection[i].name)+".assetbundle", BuildAssetBundleOptions.None);

    //    Selection.objects = selection;
    //}


    /// <summary>
    /// 生成绑定素材
    /// </summary>
    public static void BuildAssetResource(BuildTarget target, bool isWin) {
        string output = EditorUtility.OpenFolderPanel("Build Assets ", "Assets/StreamingAssets/", "");
        if (output.Length == 0)
            return;
        string dataPath = output;

        BuildPipeline.BuildAssetBundles(dataPath, BuildAssetBundleOptions.None, target);

        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("BuildAssetResource Success,target="+target.ToString());
    }

    static bool Contains(string[] filters,string ext)
    {
        for(int i=0;i<filters.Length;++i)
        {
            if (filters[i].Equals(ext))
                return true;
        }
        return false;
    }
    /// <summary>
    /// 遍历目录及其子目录
    /// </summary>
    static void Recursive(string path,string[] filters) {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names) {
            string ext = Path.GetExtension(filename);
            if (filters != null && Contains(filters, ext)) continue;
            files.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs) {
            paths.Add(dir.Replace('\\', '/'));
            Recursive(dir, filters);
        }
    }
}