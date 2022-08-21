using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenmySpawner : MonoBehaviour
{
    public GameObject enemypref;
    public GameObject parentpref;//적 오브젝트의 부모 오브젝트

    float timer;
    int delay;
    int random;
    private void Start()
    {
        timer = 0.0f;
        delay = 2;
    }
    private void Update()
    {
        random = Random.Range(-2, 2);

        timer += Time.deltaTime;

        if (timer > delay)// 2초 후 적 생성
        {
            timer = 0;
            SpawnTower();
        }

    }
    public void SpawnTower()
    {
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
             transform.position.y + random, transform.position.z), Quaternion.identity);//적 프리팹 생성

        EnemyObj.transform.SetParent(parentpref.transform, true);//부모 오브젝트에 하위 오브젝트로 생성
    }
}
