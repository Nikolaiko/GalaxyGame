using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    private UserDataRepository repository = new UserDataRepository();
    private List<LevelData> levels;

    public void Awake() {
       levels = repository.getUserLevelData();

       MapLevelItem[] levelObjects = FindObjectsOfType<MapLevelItem>();
       for(int i = 0; i < levelObjects.Length; i++) {
        LevelData data = levels.Find(item => item.levelNumber == levelObjects[i].levelNumber);
        if (data != null && data.state == LevelState.notAvailable) {
            levelObjects[i].hide();
        } else {
            levelObjects[i].show();
        }
       }
    }

    public void startLevel(int levelNumber) {
        repository.setCurrentLevel(levelNumber);        
        SceneManager.LoadSceneAsync(SceneIDs.levelSceneId);
    }

    
}
