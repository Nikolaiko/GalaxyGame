using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ScoreManager
{
    void startLevel();
    
    int GetShipDestroyScore(EnemyShipType shipType);
}
