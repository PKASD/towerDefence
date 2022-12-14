using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerpref;
    public GameObject parentpref;

    GameObject TowerObj;

    public void SpawnTower(GameObject towerpref, Vector3 trans)
    {
        TowerObj = Instantiate(towerpref, trans, Quaternion.identity);
        TowerObj.transform.SetParent(parentpref.transform, true);//부모 오브젝트에 하위 오브젝트로 생성
    }
}