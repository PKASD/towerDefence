using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerpref;

    public void SpawnTower(Vector3 trans) {
        Instantiate(towerpref, trans, Quaternion.identity);
    }
}
