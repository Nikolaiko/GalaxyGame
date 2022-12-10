using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public EnemyGroupBuilder enemyGroupBuilder;
    public PlayerShipBuilder playerShipBuilder;
    public UILevelManager uiManager;
    public GameObject enemyStartingPoint;
    public GameObject playerStartingPoint;

    private List<EnemyGroupType> levelGroups = new List<EnemyGroupType>() { EnemyGroupType.passive };
    private BaseEnemyGroup currentGroup;
    private SpaceShip playerShip;

    void Start()
    {
        buildPlayerShip();
        createNextGroup();
    }

    void Update()
    {
        if (currentGroup != null && currentGroup.isDead) {
            currentGroup.destroyGroup();            
            if (levelGroups.Count > 0) {
                createNextGroup();
            } else {
                Destroy(playerShip.gameObject);
                enemyGroupBuilder.removeAllGroups();
                uiManager.showWinScreen();
            }      
        } 
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
