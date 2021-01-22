using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseDialog : Dialog {

    protected override void Start()
    {
        base.Start();
    }

    public void OnContinueClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnMenuClick()
    {
        CUtils.LoadScene(2, true);
        Sound.instance.PlayButton();
        Close();
    }

    public void OnHomeClick()
    {
        CUtils.LoadScene(0, true);
        Sound.instance.PlayButton();
        Close();
    }

    public void OnRateClick()
    {
        Application.OpenURL("https://www.google.com/");
        Sound.instance.PlayButton();
        Close();
    }

    public void OnMoreGameClick()
    {
        Application.OpenURL("https://www.google.com/");
        Sound.instance.PlayButton();
        Close();
    }
    public void OnPolyciClick()
    {
        Application.OpenURL("https://www.google.com/");
        Sound.instance.PlayButton();
        Close();
    }
    public void OnShareClick()
    {
        Sound.instance.PlayButton();
        Close();
    }

    public void OnHowToPlayClick()
    {
        Sound.instance.PlayButton();
        DialogController.instance.ShowDialog(DialogType.HowtoPlay);
    }
}
