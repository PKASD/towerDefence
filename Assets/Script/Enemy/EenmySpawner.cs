using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenmySpawner : MonoBehaviour
{
    public GameObject enemypref;
    public GameObject parentpref;//�� ������Ʈ�� �θ� ������Ʈ

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

        if (timer > delay)// 2�� �� �� ����
        {
            timer = 0;
            SpawnTower();
        }

    }
    public void SpawnTower()
    {
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
             transform.position.y + random, transform.position.z), Quaternion.identity);//�� ������ ����

        EnemyObj.transform.SetParent(parentpref.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����
    }
}
