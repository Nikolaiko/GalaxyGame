using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupBuilder : MonoBehaviour
{
    public GameObject passiveGroup;
    public GameObject shotingGroup;
    public GameObject shotingRamGroup;

    public GameObject searchingGroup;

    private List<BaseEnemyGroup> createdGroups = new List<BaseEnemyGroup>();

    public BaseEnemyGroup buildEnemyGroup(EnemyGroupType groupType, GameObject playerShip) {
        BaseEnemyGroup createdGroup;
        switch(groupType) {
            case EnemyGroupType.passive:
            {
                createdGroup = Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();            
                break;
            }
            case EnemyGroupType.shooting:
            {
                createdGroup = Instantiate(shotingGroup).GetComponent<BaseEnemyGroup>();
                break;
            }
            case EnemyGroupType.shootingRam:
            {
                ShootingRamEnemyGroup ramGroup = Instantiate(shotingRamGroup).GetComponent<ShootingRamEnemyGroup>();
                ramGroup.SetTarget(playerShip);
                createdGroup = ramGroup;
                break;
            }
            case EnemyGroupType.searching:
            {
                createdGroup = Instantiate(searchingGroup).GetComponent<RoundSearchingGroup>();                                 
                break;
            }
            default:
            {
                createdGroup = Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();
                break;
            }
        }
        createdGroups.Add(createdGroup);
        return createdGroup;
    }

    public void removeAllGroups() {
        createdGroups.RemoveAll(group => group == null);
        createdGroups.ForEach(group => group.DestroyObject());
        createdGroups.Clear();
    }
}
