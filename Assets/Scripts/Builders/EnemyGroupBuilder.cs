using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupBuilder : MonoBehaviour
{
    public GameObject passiveGroup;
    public GameObject shotingGroup;

    private List<BaseEnemyGroup> createdGroups = new List<BaseEnemyGroup>();

    public BaseEnemyGroup buildEnemyGroup(EnemyGroupType groupType) {        
        switch(groupType) {
            case EnemyGroupType.passive:
            {
                return Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();            
            }
            case EnemyGroupType.shooting:
            {
                return Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();                
            }
            default:
            {
                return Instantiate(passiveGroup).GetComponent<BaseEnemyGroup>();
            }
        }        
    }

    public void removeAllGroups() {
        createdGroups.ForEach(group => group.destroyGroup());
        createdGroups.Clear();
    }
}
