using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemypref;
    public GameObject parentpref;//�� ������Ʈ�� �θ� ������Ʈ

    int random;

    [Header("���̺�")]
    public int maxWave;
    public float waveDelay;
    public int curWave;

    [Header("��")]
    public int maxEnemyCount;
    public int enemyCount;
    public float spawnDelay;

    private void Awake()
    {
        StartCoroutine("Wave");
    }
    private IEnumerator Wave()//�ִ� �� ����ŭ ����
    {
        while(curWave < maxWave)
        {
            curWave++;
            StartCoroutine("SpawnEnemy");
            yield return new WaitForSeconds(waveDelay);
        }
    }
    private IEnumerator SpawnEnemy()//�ִ� �� ����ŭ ����
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

    void CreatEnemy()//�� ������ ����
    {
        enemyCount++;
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
                transform.position.y + random, transform.position.z), Quaternion.identity);

        EnemyObj.transform.SetParent(parentpref.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����
    }
}
