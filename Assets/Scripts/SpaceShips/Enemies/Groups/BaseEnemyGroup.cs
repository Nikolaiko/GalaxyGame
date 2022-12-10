using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyGroup : MonoBehaviour
{
    public bool isDead = false;

    public void setPosition(Vector3 newPosition) {
        transform.position = newPosition;
    }

    public void destroyGroup() {
        Destroy(gameObject);
    }
}
