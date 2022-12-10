using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : SimpleMovingObject
{
    public int damage;

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        if (!ScreenHelpers.IsPositionOnScreen(transform.position)) {
            Destroy(gameObject);
        }
    }
}
