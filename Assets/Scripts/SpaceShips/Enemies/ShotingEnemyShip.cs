using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingEnemyShip : BaseEnemyShip
{
    public GameObject bulletOriginal;

    public void Shot() {
        GameObject cloneBullet = Instantiate(bulletOriginal);
        cloneBullet.transform.position = transform.position;
    }
}
