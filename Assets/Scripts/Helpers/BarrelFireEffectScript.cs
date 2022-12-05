using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFireEffectScript : MonoBehaviour
{
    public float appearTime = 0.0f;
    public SpriteRenderer barrelEffectRender;
    
    private float lastShotTime = 0.0f;

    public void Start() {
        barrelEffectRender.enabled = false;
    }

    public void Shoot() {
        barrelEffectRender.enabled = true;
        lastShotTime = Time.time;
    }

    void Update()
    {
        if (Time.time - lastShotTime >= appearTime) {
            barrelEffectRender.enabled = false;
        }        
    }
}
