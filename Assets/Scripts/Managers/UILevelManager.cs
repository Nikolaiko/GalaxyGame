using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject looseScreen;

    public void showWinScreen() {
        winScreen.SetActive(true);
    }

    public void hideWinScreen() {
        winScreen.SetActive(false);
    }

    public void showLooseScreen() {
        looseScreen.SetActive(true);
    }

    public void hideLooseScreen() {
        looseScreen.SetActive(false);
    }
}
