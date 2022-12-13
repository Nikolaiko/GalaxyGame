using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public LevelState state = LevelState.notAvailable;
    public int levelNumber = -1;

    public LevelData() {}

    public LevelData(int levelNumber, LevelState state) {
        this.levelNumber = levelNumber;
        this.state = state;
    }
}
