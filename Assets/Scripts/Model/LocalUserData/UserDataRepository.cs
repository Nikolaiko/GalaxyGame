using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class UserDataRepository
{
    void saveUserData() {

    }

    public List<LevelData> getUserLevelData() {
        if (!PlayerPrefs.HasKey(PlayerPrefsKeyNames.userDataKeyName)) {
            PlayerPrefs.SetString(
                PlayerPrefsKeyNames.userDataKeyName, 
                JsonUtility.ToJson(UserData.defaultUserData)
            );
        }

        UserData loadedData = JsonUtility.FromJson<UserData>(
            PlayerPrefs.GetString(PlayerPrefsKeyNames.userDataKeyName)
        );
        return loadedData.levels;
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
}
