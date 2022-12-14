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
    
    private UserDataRepository userDataRepository = new UserDataRepository();
    private int levelNumber;

    private List<EnemyGroupType> levelGroups = new List<EnemyGroupType>();
    private BaseEnemyGroup currentGroup;
    private SpaceShip playerShip;

    void Start()
    {        
        userDataRepository.initRepository();
        levelNumber = userDataRepository.getCurrentLevel();

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

                userDataRepository.setLevelState(levelNumber, LevelState.completedOneStar);                
            }      
        } 
    }

    public void replayLevel() {
        uiManager.hideWinScreen();
        uiManager.hideLooseScreen();
        Start();
    }

    public void continueToMap() {
        uiManager.hideWinScreen();
        SceneManager.LoadSceneAsync(SceneIDs.mapSceneId);
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void initEnemyGroups() {
        levelGroups.Add(EnemyGroupType.shootingRam);
        levelGroups.Add(EnemyGroupType.shootingRam);
    }

    private void buildPlayerShip() {
        playerShip = playerShipBuilder.buildPlayerShip();
        playerShip.transform.position = playerStartingPoint.transform.position;
        playerShip.OnPlayerDeath += OnPlayerDeath;
    }

    private void createNextGroup() {
        if (levelGroups.Count > 0) {
            EnemyGroupType currentGroupType = levelGroups[0];            
            levelGroups.RemoveAt(0);

            currentGroup = enemyGroupBuilder.buildEnemyGroup(currentGroupType);
            currentGroup.setPosition(enemyStartingPoint.transform.position);
        }        
    }

    private void OnPlayerDeath(SpaceShip player) {
        playerShip.destroyObject();
        enemyGroupBuilder.removeAllGroups();

        uiManager.showLooseScreen();
    }
}
