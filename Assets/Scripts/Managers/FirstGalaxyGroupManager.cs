using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGalaxyGroupManager : MonoBehaviour, EnemyGroupsConfigManager
{
    private List<EnemyGroupType> defaultConfig = new List<EnemyGroupType>() {
        EnemyGroupType.passive,
        EnemyGroupType.shooting,
        EnemyGroupType.passive,
        EnemyGroupType.shooting,
        EnemyGroupType.passive,
        EnemyGroupType.shooting
    };
    private Dictionary<int, List<EnemyGroupType>> config = new Dictionary<int, List<EnemyGroupType>>();

    public void Awake() {
        config[1] = new List<EnemyGroupType>() {
            EnemyGroupType.passive,
            EnemyGroupType.passive,
            EnemyGroupType.passive,
            EnemyGroupType.shooting
        };

        config[2] = new List<EnemyGroupType>() {
            EnemyGroupType.passive,
            EnemyGroupType.shooting,            
            EnemyGroupType.shooting,
            EnemyGroupType.passive,
            EnemyGroupType.shooting,
            EnemyGroupType.shootingRam
        };

        config[3] = new List<EnemyGroupType>() {
            EnemyGroupType.shooting,
            EnemyGroupType.searching,
            EnemyGroupType.shootingRam,
            EnemyGroupType.searching,
            EnemyGroupType.shootingRam,
            EnemyGroupType.shootingRam,
            EnemyGroupType.searching,
        };

        config[4] = new List<EnemyGroupType>() {
            EnemyGroupType.blueBoss
        };
    }


    public List<EnemyGroupType> GetGroupTypesForLevel(int levelNumber)
    {        
        if (config.ContainsKey(levelNumber)) {
            return new List<EnemyGroupType>(config[levelNumber]);
        } else {
            return new List<EnemyGroupType>(defaultConfig);
        }
    }
}
