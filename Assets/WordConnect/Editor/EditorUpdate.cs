using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;

[InitializeOnLoad]
class EditorUpdate
{
    static EditorUpdate()
    {
        EditorApplication.update += Update;
    }

    static void Update()
    {
        EditorApplication.update -= Update;

        IAPChecker.CheckItNow();

        if (Directory.Exists("Assets/EasyMobile"))
        {
            AddDefine("EASY_MOBILE_LITE", BuildTargetGroup.Android);
            AddDefine("EASY_MOBILE_LITE", BuildTargetGroup.iOS);
        }

        PluginImporter importer = AssetImporter.GetAtPath("Assets/EasyMobile/Plugins/iOS/libEasyMobileLite.a") as PluginImporter;
        if (importer != null)
        {
            importer.SetCompatibleWithAnyPlatform(false);
            importer.SetCompatibleWithPlatform(BuildTarget.iOS, true);
            importer.SaveAndReimport();
        }
    }

    public static void AddDefine(string symbol, BuildTargetGroup platform)
    {
        string symbolStr = PlayerSettings.GetScriptingDefineSymbolsForGroup(platform);
        List<string> symbols = new List<string>(symbolStr.Split(';'));

        if (!symbols.Contains(symbol))
        {
            symbols.Add(symbol);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < symbols.Count; i++)
            {
                sb.Append(symbols[i]);
                if (i < symbols.Count - 1)
                    sb.Append(";");
            }
            PlayerSettings.SetScriptingDefineSymbolsForGroup(platform, sb.ToString());
        }
    }
}