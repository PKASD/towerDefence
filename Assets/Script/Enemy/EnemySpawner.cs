using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemypref;
    public GameObject parentpref;//�� ������Ʈ�� �θ� ������Ʈ

    public int delay;
    int random;

    public int maxEnemyCount;
    public int enemyCount;
    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()//�ִ� �� ����ŭ ����
    {
        enemyCount = 0;
        while (enemyCount < maxEnemyCount)
        {
            random = Random.Range(-2, 2);
            enemyCount++;
            CreatEnemy();
            yield return new WaitForSeconds(delay);
        }
    }
    void CreatEnemy()//�� ������ ����
    {
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
                transform.position.y + random, transform.position.z), Quaternion.identity);

        EnemyObj.transform.SetParent(parentpref.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����
    }
}
