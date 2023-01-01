using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingEnemiesGroup : PassiveEnemiesGroup
{
    private static string shotingMethodName = "GroupShoot";
    private static float shotingDelay = 0.5f;
    private static float shotinginterval = 1.0f;

    protected List<ShotingEnemyShip> shotingShips = new List<ShotingEnemyShip>();
    protected System.Random generator = new System.Random();

    override public void Awake() {
        base.Awake();
        shotingShips = new List<ShotingEnemyShip>(GetComponentsInChildren<ShotingEnemyShip>());
    }

    public override void FixedUpdate()
    {
        shotingShips.RemoveAll(item => item == null);
        base.FixedUpdate();
    }

    public void Start() {
        InvokeRepeating(shotingMethodName, shotingDelay, shotinginterval);
    }

    protected override void OnGroupDeath()
    {
        base.OnGroupDeath();
        CancelInvoke(shotingMethodName);
    }

    private void GroupShoot() {
        if (shotingShips.Count > 0) {
            int shipIndex = generator.Next(0, shotingShips.Count);
            shotingShips[shipIndex].Shot();
        }
    }
}
