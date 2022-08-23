using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Status
{
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.right, attackRange,
            LayerMask.GetMask("Enemy"));//���̾� ����

        Debug.DrawRay(rigid.position, Vector3.right* attackRange, new Color(1, 0, 0)); // ����ĳ��Ʈ ���

        if (rayHit.collider != null)
        {
            if (rayHit.collider.CompareTag("enemy")) //�� ����
            {
                delay = 10.0f / attackSpeed;// ���� �ӵ�

                if (timer > delay)// 1�� �� ����
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
