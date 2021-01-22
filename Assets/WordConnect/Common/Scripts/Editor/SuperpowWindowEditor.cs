using UnityEngine;
using UnityEditor;

public class dotMobWindowEditor
{
    [MenuItem("dotMob/Clear all playerprefs")]
    static void ClearAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    [MenuItem("dotMob/Unlock all levels")]
    static void UnlockAllLevel()
    {
        CPlayerPrefs.useRijndael(CommonConst.ENCRYPTION_PREFS);
        Prefs.unlockedWorld = 10;
        Prefs.unlockedSubWorld = 5;
        Prefs.unlockedLevel = 100;
    }

    [MenuItem("dotMob/Credit balance (ruby, coin..)")]
    static void AddRuby()
    {
        CPlayerPrefs.useRijndael(CommonConst.ENCRYPTION_PREFS);
        CurrencyController.CreditBalance(1000);
    }

    [MenuItem("dotMob/Set balance to 0")]
    static void SetBalanceZero()
    {
        CPlayerPrefs.useRijndael(CommonConst.ENCRYPTION_PREFS);
        CurrencyController.SetBalance(0);
    }
}