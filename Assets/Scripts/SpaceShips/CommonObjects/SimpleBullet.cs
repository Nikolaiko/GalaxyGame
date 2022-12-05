using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : SimpleMovingObject
{
    public int damage;

    public override void Update()
    {
        base.Update();
        if (!ScreenHelpers.IsPositionOnScreen(transform.position)) {
            Destroy(gameObject);
        }
    }
}
