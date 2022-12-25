using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLevelItem : MonoBehaviour
{
    public Image itemImage;

    public int levelNumber = -1;

    public void hide() {
        gameObject.SetActive(false);
    }

    public void show() {
        gameObject.SetActive(true);
    }

    public void setImageFromState(LevelState state) {        
        switch (state) {
            case LevelState.completedOneStar:
                itemImage.sprite = Resources.Load<Sprite>("MapScene/Button_02");
                break;
            case LevelState.completedTwoStarts:
                itemImage.sprite = Resources.Load<Sprite>("MapScene/Button_03");
                break;
            case LevelState.completedThreeStars:
                itemImage.sprite = Resources.Load<Sprite>("MapScene/Button_04");
                break;
            default:
                itemImage.sprite = Resources.Load<Sprite>("MapScene/Button_01");
                break;
        }
    }
}
