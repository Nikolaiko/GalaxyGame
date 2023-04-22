using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRamEnemyGroup : ShotingEnemiesGroup
{
    private static string ramMethodName = "GroupRam";
    private static float ramDelay = 0.5f;
    private static float raminterval = 3.5f;

    private List<RamEnemyShip> ramEnemies = new List<RamEnemyShip>();

    private GameObject targetObject;

    public override void Awake() {
        base.Awake();
        ramEnemies = new List<RamEnemyShip>(GetComponentsInChildren<RamEnemyShip>());
    }


    public override void Start() {
        base.Start();
        InvokeRepeating(ramMethodName, ramDelay, raminterval);
    }

    public override void FixedUpdate() {
        ramEnemies.RemoveAll(item => item == null);
        base.FixedUpdate();
    }

    public void SetTarget(GameObject playerObject) {
        targetObject = playerObject;
    }

    protected override void OnGroupDeath() {
        base.OnGroupDeath();
        CancelInvoke(ramMethodName);
    }

    private void GroupRam() {
        if (ramEnemies.Count > 0) {
            int shipIndex = generator.Next(0, ramEnemies.Count);

            if (ramEnemies[shipIndex].GetState() == RamShipState.readyToGo) {
                ramEnemies[shipIndex].StartRamingPlayer(targetObject.transform.position);
            }
        }
    }
}
