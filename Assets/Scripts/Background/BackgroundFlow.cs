using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFlow : MonoBehaviour
{
    public GameObject mainBackground;

    private Renderer mainBackRenderer;

    void Start()
    {
        mainBackRenderer = mainBackground.GetComponent<Renderer>();
    }

    void Update()
    {
        if (mainBackRenderer != null) {
            print("Update!");
            mainBackRenderer.material.mainTextureOffset = new Vector2(0f, 0.1f * Time.time);
        }        
    }
}
