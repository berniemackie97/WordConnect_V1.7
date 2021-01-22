using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class IAPChecker : EditorWindow
{
    private static IAPChecker Instance;

    public static void OpenWelcomeWindow()
    {
        var window = GetWindow<IAPChecker>(true);
        window.position = new Rect(700, 400, 380, 200);
    }

    public static bool IsOpen
    {
        get { return Instance != null; }
    }

    static IAPChecker()
    {
    }

    public static void CheckItNow()
    {
        if (Directory.Exists("Assets/Plugins/UnityPurchasing/Bin"))
        {
            EditorUpdate.AddDefine("IAP", EditorUserBuildSettings.selectedBuildTargetGroup);

            if (Instance != null)
            {
                Instance.Close();
            }
        }
        else
        {
            OpenWelcomeWindow();
        }
    }

    public void OnGUI()
    {
        GUILayoutUtility.GetRect(position.width, 50);

        GUI.skin.label.wordWrap = true;
        GUI.skin.label.alignment = TextAnchor.MiddleLeft;
        GUILayout.Label("1. Open Window->Services\n", GUILayout.MaxWidth(350));
        GUILayout.Label("2. Create a Unity Project ID (if required)\n", GUILayout.MaxWidth(350));
        GUILayout.Label("3. Enable in-app purchasing & follow the instruction\n", GUILayout.MaxWidth(350));
        GUILayout.Label("4. Hit Import button and then Install Now the plugin", GUILayout.MaxWidth(350));
    }

    void OnEnable()
    {
        Instance = this;
        titleContent = new GUIContent("Please import Unity IAP to use this asset");
    }
}
