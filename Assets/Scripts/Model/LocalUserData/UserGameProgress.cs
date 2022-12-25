using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UserGameProgress
{
    private static int initialMoneyAmount = 100;

    public static UserGameProgress BuildInitialProgress() {
        UserGameProgress progress = new UserGameProgress();
        progress.playerMoney = initialMoneyAmount;
        progress.levels.Add(new LevelData(1, LevelState.notCompleted));
        progress.levels.Add(new LevelData(2, LevelState.notAvailable));
        progress.levels.Add(new LevelData(3, LevelState.notAvailable));
        progress.levels.Add(new LevelData(4, LevelState.notAvailable));
        
        return progress;
    }

    public List<LevelData> levels = new List<LevelData>();
    public int playerMoney = 0;
    
    public UserGameProgress() {}
}
