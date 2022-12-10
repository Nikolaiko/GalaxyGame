using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    public GameObject winScreen;



    public void showWinScreen() {
        winScreen.SetActive(true);
    }

    public void hideWinScreen() {
        winScreen.SetActive(false);
    }
}
