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

        delay = 10.0f / attackSpeed;// ���� �ӵ�

        if (timer > delay)// 1�� �� ����
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
