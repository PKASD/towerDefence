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

    private void Awake()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            GetDamege(enemy.damege);
        }
    }
}
