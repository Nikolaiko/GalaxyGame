using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBossShip : BaseEnemyShip
{
    public delegate void MissleShotDelegate();
    public event MissleShotDelegate OnMissleShot;


    public GameObject leftBurrel;
    public GameObject rightBurrel;
    public GameObject bullet;
    public GameObject missle;
    public GameObject missleBurrel;

    private SpriteRenderer bossRenderer;
    public float halfWidth = 0.0f;

    public override void Awake() {
        base.Awake();

        shipType = EnemyShipType.blueBoss;
        health = 1000;
        bossRenderer = GetComponent<SpriteRenderer>();
        halfWidth = bossRenderer.sprite.bounds.size.x / 2;
    }

    public void BulletShot() {        
        //shipAnimation.SetBool("BulletShot", true);
        OnBulletReady();
    }

    public void OnBulletReady() {    
        GameObject bulletOne = Instantiate(bullet);
        GameObject bulletTwo = Instantiate(bullet);

        bulletOne.transform.position = leftBurrel.transform.position;
        bulletTwo.transform.position = rightBurrel.transform.position;

        //shipAnimation.SetBool("BulletShot", false);
    }

    public void MissleShot() {
        shipAnimation.SetBool("MissleShot", true);
    }

    public void OnMissleReady() {

        GameObject newMissle = Instantiate(missle);
        newMissle.transform.position = missleBurrel.transform.position;

        shipAnimation.SetBool("MissleShot", false);
        OnMissleShot?.Invoke();
    }
}
