using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHelpers
{
    public static bool IsPositionOnScreen(Vector3 objPos) {
        Vector3 convPosition = Camera.main.WorldToScreenPoint(objPos);
        if (convPosition.x > 0 
            && convPosition.x < Screen.width 
            && convPosition.y > 0 
            && convPosition.y < Screen.height) 
        {
            return true;
        } else {
            return false;
        }
    }
    
}
