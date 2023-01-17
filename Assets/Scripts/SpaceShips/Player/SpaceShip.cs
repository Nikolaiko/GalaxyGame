using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class SpaceShip : MonoBehaviour, Destroyable
{
    public const float MAX_HEALTH = 100.0f;
    public delegate void PlayerDeathDelegate(SpaceShip player);
    public event PlayerDeathDelegate OnPlayerDeath;

    public SpriteRenderer spriteRenderer;
    public GameObject leftBarrel;
    public GameObject rightBarrel;
    public GameObject bulletOriginal;
    public GameObject leftExhaustObject;
    public GameObject rightExhaustObject;

    private float speed = 0.4f;
    private float health = MAX_HEALTH;
    private float halfWidth;
    private BarrelFireEffectScript leftBarrelEffect;
    private BarrelFireEffectScript rightBarrelEffect;

    private Animator shipAnimation;
    private Collider2D shipCollider;

    public void Awake() {
        shipAnimation = GetComponent<Animator>();
        shipCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        halfWidth = spriteRenderer.bounds.size.x / 2;
        leftBarrelEffect = leftBarrel.GetComponent<BarrelFireEffectScript>();
        rightBarrelEffect = rightBarrel.GetComponent<BarrelFireEffectScript>();
    }

    void Update() {
        if (health <= 0) return;
        
        if (Input.GetKeyUp(KeyCode.Space)) {            
            GameObject left = Instantiate(bulletOriginal);
            GameObject right = Instantiate(bulletOriginal);            

            left.transform.position = leftBarrel.transform.position;
            right.transform.position = rightBarrel.transform.position;

            leftBarrelEffect.Shoot();
            rightBarrelEffect.Shoot();
        }
    }

    void FixedUpdate() {
        if (health <= 0) return;

        Vector3 newRPos = new Vector3(transform.position.x + speed, transform.position.y, 0);
        Vector3 newLPos = new Vector3(transform.position.x - speed, transform.position.y, 0);
        Vector3 checkLPos = new Vector3(newLPos.x - halfWidth, newLPos.y, 0);
        Vector3 checkRPos = new Vector3(newRPos.x + halfWidth, newRPos.y, 0);        

        if (Input.GetKey(KeyCode.D)) {
            bool check = ScreenHelpers.IsPositionOnScreen(checkRPos);
            if (check) {
                transform.position = newRPos; 
            }            
        }

        if (Input.GetKey(KeyCode.A)) {
            bool check = ScreenHelpers.IsPositionOnScreen(checkLPos);
            if (check) {
                transform.position = newLPos; 
            }
        }
    }

    public void OnDestroyAnimationEnd() {
        OnPlayerDeath?.Invoke(this);
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }

    public void DestroyPlayerShip() {
        leftExhaustObject.SetActive(false);
        rightExhaustObject.SetActive(false);
        shipCollider.enabled = false;
                
        shipAnimation.SetBool("IsAlive", false);
    }

    public void OnTriggerEnter2D(Collider2D otherCollider) {        
        GameObject otherObject = otherCollider.gameObject;
        SimpleBullet bullet = otherCollider.GetComponent<SimpleBullet>();
        if (bullet != null) {
            ProcessBulletCollision(bullet);
            return;
        }

        BaseEnemyShip enemyShip = otherCollider.GetComponent<BaseEnemyShip>();        
        if (enemyShip != null) {
            ProcessSpaceShipCollision(enemyShip);
            return;
        }
    }

    public float GetHealth() {
        return health;
    }

    private void ProcessSpaceShipCollision(BaseEnemyShip enemyShip) {
        enemyShip.DestroyShip();
        DestroyPlayerShip();
    }

    private void ProcessBulletCollision(SimpleBullet bullet) {
        health -= bullet.damage;
        Destroy(bullet.gameObject);
        if (health <= 0) {
            DestroyPlayerShip();
        }
    }
}
