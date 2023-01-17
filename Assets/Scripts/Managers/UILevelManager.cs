using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILevelManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject looseScreen;
    public TMP_Text userText;

    public TMP_Text winScoreText;
    public TMP_Text looseScoreText;

    public StarRating winStar1;
    public StarRating winStar2;
    public StarRating winStar3;

    public StarRating looseStar1;
    public StarRating looseStar2;
    public StarRating looseStar3;


    public void ShowWinScreen() {
        winScoreText.text = userText.text;
        winScreen.SetActive(true);

        userText.gameObject.SetActive(false);
    }

    public void HideWinScreen() {
        winScreen.SetActive(false);
        userText.gameObject.SetActive(true);
    }

    public void ShowLooseScreen() {
        looseScoreText.text = userText.text;
        looseScreen.SetActive(true);

        userText.gameObject.SetActive(false);
    }

    public void HideLooseScreen() {
        looseScreen.SetActive(false);
        userText.gameObject.SetActive(true);
    }

    public void SetUserScore(int scoreValue) {
        userText.text = scoreValue.ToString();
    }

    public void SetUserRating(int starsCount) {
        winStar1.fullStar.SetActive(starsCount >= 1);
        winStar2.fullStar.SetActive(starsCount >= 2);
        winStar3.fullStar.SetActive(starsCount >= 3);

        looseStar1.fullStar.SetActive(starsCount >= 1);
        looseStar2.fullStar.SetActive(starsCount >= 2);
        looseStar3.fullStar.SetActive(starsCount >= 3);
    }
}
