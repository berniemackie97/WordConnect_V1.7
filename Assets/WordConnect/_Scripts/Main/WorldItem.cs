using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour {
    public MaskableGraphic itemName, itemNumber, itemNumberBack;
    public Image play, clearImage;
    public Button button;
    public Sprite playUnactive;
    public Text processText, subWorldName, txtNumlevelMax;

    public int world, subWorld;

	private void Start()
    {
        clearImage.gameObject.SetActive(false);
        world = transform.parent.parent.GetSiblingIndex();
        subWorld = transform.GetSiblingIndex();
        int numLevels = dotMob.Utils.GetNumLevels(world, subWorld);

        int unlockedWorld = Prefs.unlockedWorld;
        int unlockedSubWorld = Prefs.unlockedSubWorld;
        int unlockedLevel = Prefs.unlockedLevel;

        //Debug.Log("unlockedLevel :" + unlockedLevel.ToString());
       // Debug.Log("numLevels :" + numLevels.ToString());

        if (world > unlockedWorld || (world == unlockedWorld && subWorld > unlockedSubWorld))
        {
           
            SetColorAlpha(itemName, 0.5f);
            SetColorAlpha(itemNumber, 0.5f);
            SetColorAlpha(itemNumberBack, 0.5f);
            button.interactable = false;
            play.sprite = playUnactive;

            processText.text = "0" + "/" + numLevels;
            processText.gameObject.SetActive(false);
        }
        else if (world == unlockedWorld && subWorld == unlockedSubWorld)
        {
            processText.text = unlockedLevel + "/" + numLevels;
            txtNumlevelMax.color = Color.yellow;
            processText.gameObject.SetActive(true);

        }
        else
        {
            processText.text = numLevels + "/" + numLevels;
            clearImage.gameObject.SetActive(true);
            txtNumlevelMax.color = Color.yellow;
            processText.gameObject.SetActive(true);

        }

        button.onClick.AddListener(OnButtonClick);
    }

    private void SetColorAlpha(MaskableGraphic graphic, float alpha)
    {
        graphic.color = new Color(graphic.color.r, graphic.color.g, graphic.color.b, alpha);
    }

    private void OnButtonClick()
    {
        GameState.currentWorld = world;
        GameState.currentSubWorld = subWorld;
        GameState.currentSubWorldName = subWorldName.text;

        CUtils.LoadScene(2, true);
        Sound.instance.PlayButton();
    }
}
