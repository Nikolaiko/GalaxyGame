using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyGroup : MonoBehaviour, Destroyable
{
    public delegate void DestroyShipHandler(EnemyShipType shipType);
    public event DestroyShipHandler OnGroupShipDestroy;

    public bool isDead = false;

    public void setPosition(Vector3 newPosition) {
        transform.position = newPosition;
    }

    public virtual void DestroyObject()
    {
        Destroy(gameObject);
    }

    protected void InvokeDestroyShipEvent(EnemyShipType shipType) {
        OnGroupShipDestroy?.Invoke(shipType);
    }
}
