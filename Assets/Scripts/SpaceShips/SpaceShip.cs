using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject leftBarrel;
    public GameObject rightBarrel;
    public GameObject bulletOriginal;

    private float speed = 0.04f;    
    private float halfWidth;
    private BarrelFireEffectScript leftBarrelEffect;
    private BarrelFireEffectScript rightBarrelEffect;

    void Start()
    {
        halfWidth = spriteRenderer.bounds.size.x / 2;
        leftBarrelEffect = leftBarrel.GetComponent<BarrelFireEffectScript>();
        rightBarrelEffect = rightBarrel.GetComponent<BarrelFireEffectScript>();
    }

    void Update()
    {
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

        if (Input.GetKeyUp(KeyCode.Space)) {
            GameObject left = Instantiate(bulletOriginal);
            GameObject right = Instantiate(bulletOriginal);

            left.transform.position = leftBarrel.transform.position;
            right.transform.position = rightBarrel.transform.position;

            leftBarrelEffect.Shoot();
            rightBarrelEffect.Shoot();
        }
    }

    
}
