using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public GameObject bossIcon;

    private UserDataRepository repository = new UserDataRepository();
    private List<LevelData> levels;

    public void Awake() {
        repository.initRepository();
        levels = repository.getUserLevelsData();

        MapLevelItem[] levelObjects = FindObjectsOfType<MapLevelItem>();
        for(int i = 0; i < levelObjects.Length; i++) {
            LevelData data = levels.Find(item => item.levelNumber == levelObjects[i].levelNumber);
            levelObjects[i].setImageFromState(data.state);
            if (data != null && data.state == LevelState.notAvailable) {
                levelObjects[i].hide();
            } else {
                levelObjects[i].show();
                if (i == 3) {
                    bossIcon.SetActive(true);
                }
            }
        }
    }

    public void startLevel(int levelNumber) {
        repository.setCurrentLevel(levelNumber);        
        SceneManager.LoadSceneAsync(SceneIDs.levelSceneId);
    }

    public void ExitGame() {
        Application.Quit();
    }
}
