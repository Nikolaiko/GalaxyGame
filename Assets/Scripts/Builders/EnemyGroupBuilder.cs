using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupBuilder : MonoBehaviour
{
    public GameObject passiveGroup;
    public GameObject shotingGroup;
    public GameObject shotingRamGroup;

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
