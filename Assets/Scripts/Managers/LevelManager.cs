using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public EnemyGroupBuilder enemyGroupBuilder;
    public PlayerShipBuilder playerShipBuilder;
    public UILevelManager uiManager;
    public GameObject enemyStartingPoint;
    public GameObject playerStartingPoint;

    private List<EnemyGroupType> levelGroups = new List<EnemyGroupType>();
    private BaseEnemyGroup currentGroup;
    private SpaceShip playerShip;

    void Start()
    {
        initEnemyGroups();
        buildPlayerShip();
        createNextGroup();
    }

    void Update()
    {
        if (currentGroup != null && currentGroup.isDead) {
            currentGroup.destroyObject();            
            if (levelGroups.Count > 0) {
                createNextGroup();
            } else {
                playerShip.destroyObject();
                enemyGroupBuilder.removeAllGroups();
                uiManager.showWinScreen();
            }      
        } 
    }

    public void replayLevel() {
        uiManager.hideWinScreen();
        Start();
    }

    public void continueToMap() {
        uiManager.hideWinScreen();
        SceneManager.LoadSceneAsync(SceneIDs.mapSceneId);
    }

    private void initEnemyGroups() {
        levelGroups.Add(EnemyGroupType.passive);
    }

    private void buildPlayerShip() {
        playerShip = playerShipBuilder.buildPlayerShip();
        playerShip.transform.position = playerStartingPoint.transform.position;
    }

    private void createNextGroup() {
        if (levelGroups.Count > 0) {
            EnemyGroupType currentGroupType = levelGroups[0];            
            levelGroups.RemoveAt(0);

            currentGroup = enemyGroupBuilder.buildEnemyGroup(currentGroupType);
            currentGroup.setPosition(enemyStartingPoint.transform.position);
        }        
    }
}
