using UnityEngine;
using System;

[System.Serializable]
public class GameConfig
{
    public Admob admob;

    [Header("")]
    public int adPeriod;
    public int rewardedVideoPeriod;
    public int rewardedVideoAmount;
    public string androidPackageID;
    public string iosAppID;
    public string macAppID;
    public string facebookPageID;

    [Header("")]
    public int fontSizeInDiskSelectLevel;
    public int fontSizeInDiskMainScene;
    public int fontSizeInCellMainScene;
    [Header("")]
    public bool isWordRightToLeft = false;
}

[System.Serializable]
public class Admob
{
    [Header("Banner")]
    public string androidBanner;
    public string iosBanner;
    [Header("Interstitial")]
    public string androidInterstitial;
    public string iosInterstitial;
    [Header("RewardedVideo")]
    public string androidRewarded;
    public string iosRewarded;
}
