using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovingObject : MonoBehaviour
{
    public MovingDirection direction;
    public float movingSpeed;

    public virtual void FixedUpdate()
    {
        Vector3 newPosition = Vector3.zero;

        switch(direction) {
            case MovingDirection.up: {
                newPosition = new Vector3(
                    transform.position.x,
                    transform.position.y + movingSpeed,
                    0
                );
                break;
            }
            case MovingDirection.down: {
                newPosition = new Vector3(
                    transform.position.x,
                    transform.position.y - movingSpeed,
                    0
                );
                break;
            }
            case MovingDirection.right: {
                newPosition = new Vector3(
                    transform.position.x + movingSpeed,
                    transform.position.y,
                    0
                );
                break;
            }
            case MovingDirection.left: {
                newPosition = new Vector3(
                    transform.position.x - movingSpeed,
                    transform.position.y,
                    0
                );
                break;
            }
        }
        transform.position = newPosition;
    }
}
