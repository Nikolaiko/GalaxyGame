using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyGroupsConfigManager
{
    List<EnemyGroupType> GetGroupTypesForLevel(int levelNumber);
}
