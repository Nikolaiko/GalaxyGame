using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UserDataRepository
{
    private UserGameProgress gameProgress;

    public void initRepository() {
        if (!PlayerPrefs.HasKey(PlayerPrefsKeyNames.userGameProgressKeyName)) {
            PlayerPrefs.SetString(
                PlayerPrefsKeyNames.userGameProgressKeyName, 
                JsonUtility.ToJson(UserGameProgress.BuildInitialProgress())
            );
        }
        
        gameProgress = JsonUtility.FromJson<UserGameProgress>(
            PlayerPrefs.GetString(PlayerPrefsKeyNames.userGameProgressKeyName)
        );
    }

    public List<LevelData> getUserLevelsData() {
        return gameProgress.levels;
    }

    public void setLevelState(int levelNumber, LevelState newState) {
        int levelIndex = levelNumber - 1;
        int nextLevelIndex = levelNumber;

        gameProgress.levels[levelIndex].state = newState;
        if (newState != LevelState.notAvailable && 
            newState != LevelState.notCompleted &&
            levelIndex < gameProgress.levels.Count - 1 && 
            gameProgress.levels[nextLevelIndex].state == LevelState.notAvailable
        ) {
            gameProgress.levels[nextLevelIndex].state = LevelState.notCompleted;
        }

        saveGameProgress();
    }

    public void setCurrentLevel(int levelNumber) {
        PlayerPrefs.SetInt(PlayerPrefsKeyNames.currentLevelKeyName, levelNumber);
    }

    public int getCurrentLevel() {
        if (!PlayerPrefs.HasKey(PlayerPrefsKeyNames.currentLevelKeyName)) {
            PlayerPrefs.SetInt(PlayerPrefsKeyNames.currentLevelKeyName, 1);
        }
        return PlayerPrefs.GetInt(PlayerPrefsKeyNames.currentLevelKeyName);
    }

    private void saveGameProgress() {
        PlayerPrefs.SetString(
            PlayerPrefsKeyNames.userGameProgressKeyName, 
            JsonUtility.ToJson(gameProgress)
        );
    }
}
