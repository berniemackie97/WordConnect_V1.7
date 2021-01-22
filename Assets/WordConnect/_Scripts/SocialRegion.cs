using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if EASY_MOBILE_LITE
using EasyMobile;
#endif

public class SocialRegion : MonoBehaviour {
    public GameObject overlay, panel, bottomBanner;
    public Transform panelIn, panelOut;
    public bool isShowing;

    public static SocialRegion instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowPanel()
    {
        overlay.SetActive(true);
        panel.SetActive(true);
        panel.transform.position = panelOut.position;
        iTween.MoveTo(panel, panelIn.position, 0.3f);
        isShowing = true;
    }

    public void HidePanel()
    {
        overlay.SetActive(false);
        iTween.MoveTo(panel, panelOut.position, 0.3f);
        isShowing = false;
    }

    public void OnSocialClick()
    {
        OnAskFriendClick();
    }

    public void OnAskFriendClick()
    {
#if !EASY_MOBILE_LITE
        Toast.instance.ShowMessage("Please install Easy Mobile Lite. \nSee Console for more details", 7);

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("You need to import Easy Mobile Lite (free) to use this function. This is how to import:(Click this log to see full instruction)").AppendLine();
        sb.Append("1. Open the asset store: Windows -> General -> Asset Store").AppendLine();
        sb.Append("2. Search: Easy Mobile Lite").AppendLine();
        sb.Append("3. Download and import it");

        Debug.LogError(sb.ToString());
#else

#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
        StartCoroutine(CROneStepSharing());
#else
        Toast.instance.ShowMessage("This function only works on Android and iOS");
#endif
#endif
    }

    IEnumerator CROneStepSharing()
    {
        yield return new WaitForEndOfFrame();
        HidePanel();
        yield return new WaitForSeconds(0.35f);
        bottomBanner.SetActive(true);
        yield return new WaitForEndOfFrame();

#if EASY_MOBILE_LITE
        Sharing.ShareScreenshot("screenshot", "");
#endif
        bottomBanner.SetActive(false);
    }
}
