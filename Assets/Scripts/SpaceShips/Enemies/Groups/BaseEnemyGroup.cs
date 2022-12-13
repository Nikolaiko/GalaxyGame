using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyGroup : MonoBehaviour, Destroyable
{
    public bool isDead = false;

    public void setPosition(Vector3 newPosition) {
        transform.position = newPosition;
    }

    public virtual void destroyObject()
    {
        Destroy(gameObject);
    }
}
