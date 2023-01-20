using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyGroup : MonoBehaviour, Destroyable
{
    public delegate void DestroyShipHandler(EnemyShipType shipType);
    public event DestroyShipHandler OnGroupShipDestroy;

    public bool isDead = false;

    protected List<BaseEnemyShip> ships = new List<BaseEnemyShip>();

    public void setPosition(Vector3 newPosition) {
        transform.position = newPosition;
    }

    public virtual void DestroyObject()
    {
        Destroy(gameObject);
    }

    virtual protected void OnGroupDeath() {
        isDead = true;
    }

    protected void OnShipAnimationDestroyComplete(BaseEnemyShip ship) {
        ship.SetAlive(false);   
    }

    protected virtual void OnShipDestroy(BaseEnemyShip ship) {
        OnGroupShipDestroy?.Invoke(ship.GetShipType());
    }
}
