using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenmySpawner : MonoBehaviour
{
    public GameObject enemypref;
    float timer;
    int delay;

    private void Start()
    {
        timer = 0.0f;
        delay = 2;
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > delay)// 2檬 饶 利 积己
        {
            timer = 0;
            SpawnTower();
        }

    }
    public void SpawnTower()
    {
        Instantiate(enemypref, new Vector3(transform.position.x,
             transform.position.y, transform.position.z), Quaternion.identity);//利 橇府普 积己
    }
}
