using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Status
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.right, attackRange,
            LayerMask.GetMask("Enemy"));//레이어 감지

        Debug.DrawRay(rigid.position, Vector3.right* attackRange, new Color(1, 0, 0)); // 레이캐스트 출력

        if (rayHit.collider != null)
        {
            if (rayHit.collider.CompareTag("enemy")) //적 공격
            {
                delay = 10.0f / attackSpeed;// 공격 속도

                if (timer > delay)// 1초 후 공격
                {
                    timer = 0;

                    DoAttack();
                }
            }
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
