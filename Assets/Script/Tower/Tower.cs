using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Status
{
    Rigidbody2D rigid;
    Enemy enemy;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
    }
    private void FixedUpdate()
    {
        //doAttack();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            GetDamege(enemy.damege);
        }
    }
}
