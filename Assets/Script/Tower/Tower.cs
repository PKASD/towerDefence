using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Status
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
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
            OnDamege(enemy.damege);
        }
    }
}
