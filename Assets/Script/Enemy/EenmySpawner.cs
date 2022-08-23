using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenmySpawner : MonoBehaviour
{
    public GameObject enemypref;
    public GameObject parentpref;//적 오브젝트의 부모 오브젝트

    public int delay;
    int random;

    public int maxEnemyCount;

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()//최대 적 수만큼 생성
    {
        int enemyCount = 0;
        while (enemyCount < maxEnemyCount)
        {
            random = Random.Range(-2, 2);
            enemyCount++;
            CreatEnemy();
            yield return new WaitForSeconds(delay);
        }
    }
    void CreatEnemy()//적 프리팹 생성
    {
        GameObject EnemyObj = Instantiate(enemypref, new Vector3(transform.position.x,
                transform.position.y + random, transform.position.z), Quaternion.identity);

        EnemyObj.transform.SetParent(parentpref.transform, true);//부모 오브젝트에 하위 오브젝트로 생성
    }
}
