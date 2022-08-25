using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemypref;
    public GameObject parentpref;//적 오브젝트의 부모 오브젝트

    int random;

    [Header("웨이브")]
    public int maxWave;
    public float waveDelay;
    public int curWave;

    [Header("적")]
    public int maxEnemyCount;
    public int enemyCount;
    public float spawnDelay;

    private void Awake()
    {
        StartCoroutine("Wave");
    }
    private IEnumerator Wave()//최대 적 수만큼 생성
    {
        while(curWave < maxWave)
        {
            curWave++;
            StartCoroutine("SpawnEnemy");
            yield return new WaitForSeconds(waveDelay);
        }
    }
    private IEnumerator SpawnEnemy()//최대 적 수만큼 생성
    {
        for (int i= enemyCount; i < maxEnemyCount; i++)
        {
            random = Random.Range(-2, 2);

            CreatEnemy();

            if (enemyCount >= maxEnemyCount)
            {
                enemyCount = 0;
            }

            yield return new WaitForSeconds(spawnDelay);
           
        }
    }

    void CreatEnemy()//적 프리팹 생성
    {
        enemyCount++;
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
                transform.position.y + random, transform.position.z), Quaternion.identity);

        EnemyObj.transform.SetParent(parentpref.transform, true);//부모 오브젝트에 하위 오브젝트로 생성
    }
}
