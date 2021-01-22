using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using dotMob;

public class MainController : BaseController {
    public Text levelNameText;

    private int world, subWorld, level;
    private bool isGameComplete;
    private GameLevel gameLevel;

    public static MainController instance;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void Start()
    {
        base.Start();
        world = GameState.currentWorld;
        subWorld = GameState.currentSubWorld;
        level = GameState.currentLevel;
        //world = Prefs.unlockedWorld;
        //subWorld = Prefs.unlockedSubWorld;
        //level = Prefs.unlockedLevel;
        //Debug.Log("word :" + world.ToString());
        //Debug.Log("subWorld :" + subWorld.ToString());

        //Debug.Log("level :" + level.ToString());
        gameLevel = Utils.Load(world, subWorld, level);
        Pan.instance.Load(gameLevel);
        WordRegion.instance.Load(gameLevel);

        if (world == 0 && subWorld == 0 && level == 0)
        {
            Timer.Schedule(this, 0.5f, () =>
            {
                DialogController.instance.ShowDialog(DialogType.HowtoPlay);
            });
        }

        levelNameText.text = "Level " + (level + 1);
    }

    public void OnComplete()
    {
        if (isGameComplete) return;
        isGameComplete = true;
        //show win
       // Debug.Log("SHOW WIN");
        Timer.Schedule(this, 1f, () =>
        {
            //Ad 2 coin when level complete
            CurrencyController.CreditBalance(2);
            DialogController.instance.ShowDialog(DialogType.Win);
            Sound.instance.Play(Sound.Others.Win);
        });
    }

    private string BuildLevelName()
    {
        return world + "-" + subWorld + "-" + level;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !DialogController.instance.IsDialogShowing())
        {
            DialogController.instance.ShowDialog(DialogType.Pause);
        }
    }
}
