using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevelItem : MonoBehaviour
{
    public int levelNumber = -1;

    public void hide() {
        gameObject.SetActive(false);
    }

    public void show() {
        gameObject.SetActive(true);
    }
}
