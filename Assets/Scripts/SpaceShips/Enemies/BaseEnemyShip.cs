using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class BaseEnemyShip : MonoBehaviour
{
    public delegate void ShipDestroyDelegate(BaseEnemyShip ship);
    public event ShipDestroyDelegate OnShipDestroyAnimationComplete;
    public event ShipDestroyDelegate OnShipDestroy;

    public GameObject exhaustObject;

    protected EnemyShipType shipType;

    protected int health = 100;
    protected bool isAlive = true;
   
    protected Animator shipAnimation;
    protected Collider2D shipCollider;

    public void Awake() {
        shipAnimation = GetComponent<Animator>();
        shipCollider = GetComponent<Collider2D>();
    }

    public void ReleaseFromGroupTransform() {
        transform.parent = null;
    }

    public void SetAlive(bool aliveFlag) {
        isAlive = aliveFlag;
    }

    public bool shipAlive() {
        return isAlive;
    }

    public EnemyShipType GetShipType() {
        return shipType;
    }

    public void DestroyShipObject() {
        Destroy(gameObject);
    }

    public virtual void DestroyShip() {
        exhaustObject.SetActive(false);
        shipCollider.enabled = false;

        ReleaseFromGroupTransform();
        shipAnimation.SetBool("IsAlive", false);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider) {        
        GameObject otherObject = otherCollider.gameObject;
        SimpleBullet bullet = otherCollider.GetComponent<SimpleBullet>();
        if (bullet != null) {
            health -= bullet.damage;
            Destroy(otherObject);
            if (health <= 0) {
                DestroyShip();
                OnShipDestroy?.Invoke(this);   
            }
        }
    }

    public void OnDestroyAnimationComplete() {        
        OnShipDestroyAnimationComplete?.Invoke(this);
    }
}
