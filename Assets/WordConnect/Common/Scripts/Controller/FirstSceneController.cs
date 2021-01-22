using UnityEngine;
using System.Collections;

public class FirstSceneController : MonoBehaviour
{
	public static FirstSceneController instance;

	private void Awake()
	{
		instance = this;
		Application.targetFrameRate = 60;
        CPlayerPrefs.useRijndael(CommonConst.ENCRYPTION_PREFS);
	}

	private void Update()
    {
#if !UNITY_WSA
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogController.instance.IsDialogShowing())
        {
            Application.Quit();
        }
#endif
    }
}
