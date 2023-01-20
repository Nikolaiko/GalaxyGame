using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBossGroup : BaseEnemyGroup
{
    private BlueBossShip bossShip;
    private float speed = 0.2f;    
    private MovingDirection currentDirection = MovingDirection.left;

    private bool isPreparingShot = false;
    
    public void Awake() {
        bossShip = GetComponentInChildren<BlueBossShip>();
        bossShip.OnMissleShot += OnMissleShot;


        InvokeRepeating("BulletAttack", 1.0f, 0.35f);
        InvokeRepeating("MissleAttack", 2.0f, 4.0f); 

        bossShip.OnShipDestroyAnimationComplete += OnShipAnimationDestroyComplete;
        bossShip.OnShipDestroy += OnShipDestroy;      
    }

    public void FixedUpdate() {
        if (!bossShip.shipAlive()) {
            isDead = true;
            bossShip.DestroyShip();            
            OnGroupDeath();    
        } else {
            if (isPreparingShot) return;

            Vector3 newPosition = Vector3.zero;
            Vector3 checkPosition = Vector3.zero;

            if (currentDirection == MovingDirection.left) {                
                newPosition = new Vector3(
                    bossShip.transform.position.x - speed,
                    transform.position.y,
                    0
                );

                checkPosition = newPosition;
                checkPosition.x -= bossShip.halfWidth;
                if (ScreenHelpers.IsPositionOnScreen(checkPosition)) {
                    transform.position = newPosition;
                } else {
                    currentDirection = MovingDirection.right;
                }
            } else if (currentDirection == MovingDirection.right) {                
                newPosition = new Vector3(
                    bossShip.transform.position.x + speed,
                    transform.position.y,
                    0
                );

                checkPosition = newPosition;
                checkPosition.x += bossShip.halfWidth;
                if (ScreenHelpers.IsPositionOnScreen(checkPosition)) {
                    transform.position = newPosition;
                } else {
                    currentDirection = MovingDirection.left;
                }
            }
        }
    }

    public override void DestroyObject() {
        if (bossShip != null) bossShip.DestroyShipObject();
        base.DestroyObject();
    }

    protected override void OnShipDestroy(BaseEnemyShip ship) {
        base.OnShipDestroy(ship);
        CancelInvoke();
    }

    private void BulletAttack() {
        if (!isPreparingShot && bossShip.shipAlive()) {
            bossShip.BulletShot();
        }        
    }

    private void MissleAttack() {
        if (bossShip.shipAlive()) {
            isPreparingShot = true;
            bossShip.MissleShot();
        }        
    }

    private void OnMissleShot() {        
        isPreparingShot = false;
    }
}
