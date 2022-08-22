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
        timer += Time.deltaTime;

        delay = 10.0f / attackSpeed;// 공격 속도

        if (timer > delay)// 1초 후 공격
        {
            timer = 0;

            DoAttack();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
           GetDamege(enemy.damege);
        }
    }
}
