using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSearchingGroup : BaseEnemyGroup
{
    public RoundSearchingShip firstShip;
    public RoundSearchingShip secondShip;   

    public void Awake() {
        firstShip.OnShipDestroyAnimationComplete += OnShipAnimationDestroyComplete;
        firstShip.OnShipDestroy += OnShipDestroy;

        secondShip.OnShipDestroyAnimationComplete += OnShipAnimationDestroyComplete;
        secondShip.OnShipDestroy += OnShipDestroy;

        ships.Add(firstShip);
        ships.Add(secondShip);


    }

    public void FixedUpdate()
    {
        List<BaseEnemyShip> deadShips = ships.FindAll(currentShip => currentShip.shipAlive() == false);
        ships.RemoveAll(item => deadShips.Contains(item) == true);

        foreach(BaseEnemyShip deadShip in deadShips) {
            deadShip.OnShipDestroy -= OnShipDestroy;
            deadShip.OnShipDestroyAnimationComplete -= OnShipAnimationDestroyComplete;
            deadShip.DestroyShipObject();
        }

        ships.RemoveAll(item => item == null);
        if (ships.Count == 0) {
            OnGroupDeath();
        }
    }

    public override void DestroyObject()
    {
        foreach (BaseEnemyShip ship in ships) {
            ship.DestroyShipObject();
        }        
        base.DestroyObject();
    }
}
