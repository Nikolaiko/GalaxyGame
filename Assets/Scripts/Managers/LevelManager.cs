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


    private ScoreManager scoreManager;
    private StarRatingManager ratingManager;
    private UserDataRepository userDataRepository = new UserDataRepository();
    private int levelNumber;
    private int userScore;

    private List<EnemyGroupType> levelGroups = new List<EnemyGroupType>();
    private BaseEnemyGroup currentGroup;
    private SpaceShip playerShip;

    void Awake() {
        scoreManager = GetComponent<ScoreManager>();
        ratingManager = GetComponent<StarRatingManager>();
    }

    void Start()
    {
        userDataRepository.initRepository();
        levelNumber = userDataRepository.getCurrentLevel();
        userScore = 0;

        scoreManager.startLevel();
        
        initEnemyGroups();
        buildPlayerShip();
        createNextGroup();
    }

    void Update()
    {
        if (currentGroup != null && currentGroup.isDead) {
            currentGroup.DestroyObject();
            currentGroup.OnGroupShipDestroy -= OnEnemyShipDestroy;     
            if (levelGroups.Count > 0) {
                createNextGroup();
            } else {
                playerShip.DestroyObject();
                enemyGroupBuilder.removeAllGroups();

                int rating = ratingManager.GetStarsRating(levelNumber, userScore, playerShip.GetHealth());
                uiManager.SetUserRating(rating);
                uiManager.ShowWinScreen();

                userDataRepository.setLevelState(levelNumber, ConvertHelpers.LevelStateFromRating(rating));                
            }      
        } 
    }

    public void replayLevel() {
        userScore = 0;
        uiManager.SetUserScore(userScore);
        uiManager.HideWinScreen();
        uiManager.HideLooseScreen();

        Start();
    }

    public void continueToMap() {
        uiManager.HideWinScreen();
        SceneManager.LoadSceneAsync(SceneIDs.mapSceneId);
    }

    public void ExitGame() {
        Application.Quit();
    }

    private void initEnemyGroups() {
        levelGroups.Clear();
        levelGroups.Add(EnemyGroupType.blueBoss);
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

            currentGroup = enemyGroupBuilder.buildEnemyGroup(currentGroupType, playerShip.gameObject);
            currentGroup.setPosition(enemyStartingPoint.transform.position);
            currentGroup.OnGroupShipDestroy += OnEnemyShipDestroy;
        }        
    }

    private void OnPlayerDeath(SpaceShip player) {
        playerShip.DestroyObject();
        enemyGroupBuilder.removeAllGroups();

        int rating = ratingManager.GetStarsRating(levelNumber, userScore, playerShip.GetHealth());
        uiManager.SetUserRating(rating);
        uiManager.ShowLooseScreen();
    }

    private void OnEnemyShipDestroy(EnemyShipType shipType) {
        userScore += scoreManager.GetShipDestroyScore(shipType);
        uiManager.SetUserScore(userScore);
    }    
}
