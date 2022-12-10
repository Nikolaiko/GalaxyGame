using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyShip : MonoBehaviour
{
    private int health = 100;

    void OnTriggerEnter2D(Collider2D otherCollider) {        
        GameObject otherObject = otherCollider.gameObject;
        SimpleBullet bullet = otherCollider.GetComponent<SimpleBullet>();
        if (bullet != null) {
            health -= bullet.damage;
            Destroy(otherObject);

            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
