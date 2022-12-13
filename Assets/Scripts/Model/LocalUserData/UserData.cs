using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class UserData
{
    public static UserData defaultUserData = new UserData(
        new List<LevelData>() { 
            new LevelData(1, LevelState.notCompleted),
            new LevelData(2, LevelState.notAvailable),
            new LevelData(3, LevelState.notAvailable),
            new LevelData(4, LevelState.notAvailable),
        }
    );

    public UserData() { }

    public UserData(List<LevelData> levelsData) {
        levels = levelsData;
    }

    public List<LevelData> levels = new List<LevelData>();
}
