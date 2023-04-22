using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSearchingShip : BaseEnemyShip
{
    public RoundSearchDirection searchDirection;

    public SpriteRenderer shipRenderer;

    private float halfWidth;
    private float halfHeight;

    private MovingDirection direction;

    private float speed = 0.5f;
    private bool isDead = false;

    public override void Awake()
    {
        base.Awake();
        if (searchDirection == RoundSearchDirection.clockwise) {
            direction = MovingDirection.right;
        } else {
            direction = MovingDirection.left;
        }
        TurnToCurrentDirection();

        halfHeight = shipRenderer.sprite.bounds.size.y / 2;
        halfWidth = shipRenderer.sprite.bounds.size.x / 2;

        shipType = EnemyShipType.searching;
    }


    public void FixedUpdate() {
        if (isDead) return;

        switch (direction) {
            case MovingDirection.right:
                Vector3 newPosition = transform.position + Vector3.right * speed;

                Vector3 checkPosition = newPosition;
                checkPosition.x += halfWidth;

                if (ScreenHelpers.IsPositionOnScreen(checkPosition)) {
                    transform.position = newPosition;
                } else {
                    if (transform.position.y > 0) {
                        direction = MovingDirection.down;
                    } else {
                        direction = MovingDirection.up;
                    }                    
                    TurnToCurrentDirection();
                }
                break;
            case MovingDirection.left:
                newPosition = transform.position + Vector3.left * speed;

                checkPosition = newPosition;
                checkPosition.x -= halfWidth;

                if (ScreenHelpers.IsPositionOnScreen(checkPosition)) {
                    transform.position = newPosition;
                } else {
                    if (transform.position.y > 0) {
                        direction = MovingDirection.down;
                    } else {
                        direction = MovingDirection.up;
                    }                    
                    TurnToCurrentDirection();
                }
                break;
            case MovingDirection.up:
                newPosition = transform.position + Vector3.up * speed;

                checkPosition = newPosition;
                checkPosition.y += halfHeight;

                if (ScreenHelpers.IsPositionOnScreen(checkPosition)) {
                    transform.position = newPosition;
                } else {
                    if (searchDirection == RoundSearchDirection.clockwise) {
                        direction = MovingDirection.right;
                    } else {
                        direction = MovingDirection.left;
                    }
                    TurnToCurrentDirection();
                }
                break;                
            case MovingDirection.down:
                newPosition = transform.position + Vector3.down * speed;

                checkPosition = newPosition;
                checkPosition.y -= halfHeight;
                
                if (ScreenHelpers.IsPositionOnScreen(checkPosition)) {
                    transform.position = newPosition;
                } else {
                    if (searchDirection == RoundSearchDirection.clockwise) {
                        direction = MovingDirection.left;
                    } else {
                        direction = MovingDirection.right;
                    }
                    TurnToCurrentDirection();
                }
                break;
        }
    }

    private void TurnToCurrentDirection() {
        switch (direction) {
            case MovingDirection.up:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case MovingDirection.down:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case MovingDirection.left:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case MovingDirection.right:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
        }
    }

    public override void DestroyShip()
    {
        isDead = true;
        base.DestroyShip();        
    }
}
