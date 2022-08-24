using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Center : Status
{
    [Header("Energy")]
    public int maxEnergy;
    public int curEnergy;
    public float increaseEnergyTime = 1;//������ ���� �ð�
    public int increaseEnergy = 1;//������ ������

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
