using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerpref;
    public GameObject parentpref;

    public void SpawnTower(Vector3 trans)
    {
            GameObject TowerObj = Instantiate(towerpref, trans, Quaternion.identity);
            TowerObj.transform.SetParent(parentpref.transform, true);//부모 오브젝트에 하위 오브젝트로 생성
    }
}
