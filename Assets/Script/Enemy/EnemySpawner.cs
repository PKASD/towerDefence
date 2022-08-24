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
    public int spawnDelay;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()//�ִ� �� ����ŭ ����
    {
       /* while (curWave < maxWave)
        {*/
            while (enemyCount < maxEnemyCount)
            {
                random = Random.Range(-2, 2);
                enemyCount++;
                CreatEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }
            Invoke("Wave", waveDelay);
        //}
    }
    private void Wave()//�� ���̺�
    {
        if (enemyCount == maxEnemyCount)
        {
            enemyCount = 0;
            Debug.Log("enemyCount " + enemyCount);

            curWave++;
            Debug.Log("curWave" + curWave);
        }
    }
    void CreatEnemy()//�� ������ ����
    {
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
                transform.position.y + random, transform.position.z), Quaternion.identity);

        EnemyObj.transform.SetParent(parentpref.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����
    }
}
