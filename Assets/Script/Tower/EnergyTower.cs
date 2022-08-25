using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyTower : Tower
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("tower")) {
            tower.attackSpeed += 5;
        }
    }
}

