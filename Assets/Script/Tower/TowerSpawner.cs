using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerpref;

    public void SpawnTower(Transform trans) {
        Instantiate(towerpref, trans.position, Quaternion.identity);
    }
}
