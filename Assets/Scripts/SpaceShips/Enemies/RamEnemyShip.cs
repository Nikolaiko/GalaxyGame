using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnemyShip : BaseEnemyShip
{
    private static float distanceValue = 15.0f;
    private static float returnSpeed = 0.3f;
    private static float rammingSpeed = 0.008f;
    private static float distanceDifferense = 1.0f;

    private RamShipState state = RamShipState.readyToGo;
    private Vector3 groupLocalPosition;
    private Transform groupTransform;

    private Vector3 pathP0;
    private Vector3 pathP1;
    private Vector3 pathP2;
    private Vector3 pathP3;
    private float pathT;

    public RamShipState GetState() {
        return state;
    }

    public void StartRamingPlayer(Vector3 targetPosition) {
        groupLocalPosition = transform.parent.InverseTransformPoint(transform.position);
        groupTransform = transform.parent;

        ReleaseFromGroupTransform();
        
        float distance = (targetPosition.x > transform.position.x) ? distanceValue : -distanceValue;

        pathP0 = transform.position;
        pathP3 = targetPosition;

        pathP1 = new Vector3(pathP0.x + distance, pathP0.y, pathP0.z);
        pathP2 = new Vector3(pathP3.x + distance, pathP3.y, pathP3.z);

        pathT = 0;
        
        state = RamShipState.rammingPlayer;                
    }

    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3) {
        float u = 1.0f - t;
        float squareT = t * t;
        float squareU = u * u;
        float tripleU = u * u * u;
        float tripleT = t * t * t;
    
        Vector3 p = tripleU * p0;
        p += 3 * squareU * t * p1;
        p += 3 * u * squareT * p2; 
        p += tripleT * p3;           
    
        return p;
    }

    void FixedUpdate() {
        switch (state) {
            case RamShipState.rammingPlayer: {
                Vector3 newPosition = CalculateBezierPoint(pathT, pathP0, pathP1, pathP2, pathP3);
                
                transform.position = newPosition;
                pathT += rammingSpeed;

                if (Vector3.Distance(transform.position, pathP3) <= distanceDifferense) {
                    state = RamShipState.returningToGroup;
                }
                break;
            }
            case RamShipState.returningToGroup: {
                Vector3 globalPosition = groupTransform.TransformPoint(groupLocalPosition);
                Vector3 newPosition = Vector3.MoveTowards(transform.position, globalPosition, returnSpeed);

                transform.position = newPosition;
                if (Vector3.Distance(transform.position, globalPosition) <= distanceDifferense) {
                    transform.position = globalPosition;
                    transform.parent = groupTransform;
                    state = RamShipState.readyToGo;
                }
                break;
            }
        }        
    }

    public override void DestroyShip()
    {
        state = RamShipState.destroyed;
        base.DestroyShip();        
    }
}
