using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipBuilder : MonoBehaviour
{
    public GameObject playerShipOriginal;

    public SpaceShip buildPlayerShip() {
        GameObject newPlayerShip = Instantiate(playerShipOriginal);
        return newPlayerShip.GetComponent<SpaceShip>();
    }
}
