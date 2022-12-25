using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class BaseEnemyShip : MonoBehaviour
{
    public delegate void ShipDestroyDelegate(BaseEnemyShip ship);
    public event ShipDestroyDelegate OnShipDestroy;

    public GameObject exhaustObject;

    protected int health = 100;
    protected bool isAlive = true;
   
    protected Animator shipAnimation;
    protected Collider2D shipCollider;

    public void Awake() {
        shipAnimation = GetComponent<Animator>();
        shipCollider = GetComponent<Collider2D>();
    }

    public void releaseFromGroupTransform() {
        transform.parent = null;
    }

    public void setAlive(bool aliveFlag) {
        isAlive = aliveFlag;
    }

    public bool shipAlive() {
        return isAlive;
    }

    public void destroyShip() {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider) {
        print(shipAnimation);
        GameObject otherObject = otherCollider.gameObject;
        SimpleBullet bullet = otherCollider.GetComponent<SimpleBullet>();
        if (bullet != null) {
            health -= bullet.damage;
            Destroy(otherObject);
            if (health <= 0) {
                exhaustObject.SetActive(false);
                shipCollider.enabled = false;

                releaseFromGroupTransform();
                shipAnimation.SetBool("IsAlive", false);                
            }
        }
    }

    public void OnDestroyAnimationComplete() {        
        OnShipDestroy?.Invoke(this);
    }
}
