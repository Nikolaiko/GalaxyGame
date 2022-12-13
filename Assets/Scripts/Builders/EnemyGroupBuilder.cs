using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupBuilder : MonoBehaviour
{
    public GameObject passiveGroup;
    public GameObject shotingGroup;

    private List<BaseEnemyGroup> createdGroups = new List<BaseEnemyGroup>();

    public BaseEnemyGroup buildEnemyGroup(EnemyGroupType groupType) {
        BaseEnemyGroup createdGroup;
        switch(groupType) {
            case EnemyGroupType.passive:
            {
                createdGroup = Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();            
                break;
            }
            case EnemyGroupType.shooting:
            {
                createdGroup = Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();
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
        createdGroups.ForEach(group => group.destroyObject());
        createdGroups.Clear();
    }
}
