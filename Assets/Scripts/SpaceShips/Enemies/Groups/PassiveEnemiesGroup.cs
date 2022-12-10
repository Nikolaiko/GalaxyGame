using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemiesGroup : BaseEnemyGroup
{
    private float speed = 0.1f;
    private MovingDirection currentDirection = MovingDirection.left;
    private List<BaseEnemyShip> ships = new List<BaseEnemyShip>();


    void Awake() {        
        ships = new List<BaseEnemyShip>(GetComponentsInChildren<BaseEnemyShip>());
    }

    void FixedUpdate()
    {
        ships.RemoveAll(item => item == null);
        if (ships.Count == 0) {
            isDead = true;
        } else {
            Vector3 newPosition = Vector3.zero;        
            if (currentDirection == MovingDirection.left) {
                float mostLeftPosition = GetMostLeftPosition(ships);
                newPosition = new Vector3(
                    mostLeftPosition - speed,
                    transform.position.y,
                    0
                );
                if (ScreenHelpers.IsPositionOnScreen(newPosition)) {
                    transform.position = new Vector3(
                        transform.position.x - speed,
                        transform.position.y,
                        0
                    );
                } else {
                    currentDirection = MovingDirection.right;
                }
            } else if (currentDirection == MovingDirection.right) {
                float mostRightPosition = GetMostRightPosition(ships);
                newPosition = new Vector3(
                    mostRightPosition + speed,
                    transform.position.y,
                    0
                );
                if (ScreenHelpers.IsPositionOnScreen(newPosition)) {
                    transform.position = new Vector3(
                        transform.position.x + speed,
                        transform.position.y,
                        0
                    );
                } else {
                    currentDirection = MovingDirection.left;
                }
            }
        }        
    }

    protected float GetMostLeftPosition(List<BaseEnemyShip> groupShips) {
        float leftPosition = float.MaxValue;
        for (int i = 0; i < groupShips.Count; i++) {
            if (groupShips[i].transform.position.x < leftPosition) {
                leftPosition = groupShips[i].transform.position.x;
            }
        }
        return leftPosition;
    }

    protected float GetMostRightPosition(List<BaseEnemyShip> groupShips) {
        float leftPosition = float.MinValue;
        for (int i = 0; i < groupShips.Count; i++) {
            if (groupShips[i].transform.position.x > leftPosition) {
                leftPosition = groupShips[i].transform.position.x;
            }
        }
        return leftPosition;
    }
}
