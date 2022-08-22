using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Center : Status
{
    Enemy enemy;

    [Header("Energy")]
    public int maxEnergy;
    public int curEnergy;
    public float increaseEnergyTime = 0.2f;//������ ���� �ð�
    public int increaseEnergy = 1;//������ ������
    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();

    }
    private void Update()
    {
        StartCoroutine(IncreaseEn());
    }
    IEnumerator IncreaseEn()//�ʴ� ������ ����
    {
        if (curEnergy < maxEnergy)
        {
            curEnergy += increaseEnergy;
            yield return new WaitForSeconds(increaseEnergyTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            OnDamege(enemy.damege);
        }
    }
}
