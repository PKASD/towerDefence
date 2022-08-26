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
        bool increase=false;
        
        if (other.CompareTag("tower")) {
            if (increase)
            {
                tower.attackSpeed += 5;
                increase = true;
            }
        }
    }
}

