using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedScoreManager : MonoBehaviour, ScoreManager
{
    private static int MIN_SCORE_VALUE = 5;
    private float timeLevelStarted;

    public void startLevel() {
        timeLevelStarted = Time.time;
    }

    public int GetShipDestroyScore(EnemyShipType shipType)
    {
        float timeInterval = Time.time - timeLevelStarted;
        int score = 0;
        switch (shipType) {
            case EnemyShipType.basic:
                score =  EnemyShipScoreTable.BASIC_SHIP;
                break;
            case EnemyShipType.shooting:
                score = EnemyShipScoreTable.SHOOTING_SHIP;
                break;
            case EnemyShipType.ramming:
                score =  EnemyShipScoreTable.RAMMING_SHIP;
                break;
            case EnemyShipType.searching:
                score =  EnemyShipScoreTable.SEARCHING_SHIP;
                break;
        }
        score -=  Mathf.RoundToInt(timeInterval);
        if (score <= 0) {
            score = MIN_SCORE_VALUE;
        }

        return score;
    }
}
