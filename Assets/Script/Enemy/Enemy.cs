using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Status
{

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
 
        //rigid.AddForce(new Vector2(0, 0.1f) * 5, ForceMode2D.Impulse); ??

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, attackRange,
            LayerMask.GetMask("Center", "Tower"));//����, Ÿ�� ���̾� ����

        Debug.DrawRay(rigid.position, Vector3.left * attackRange, new Color(0, 1, 0)); // ����ĳ��Ʈ ���

        if (rayHit.collider != null)
        {
            if (rayHit.collider.CompareTag("Center") || rayHit.collider.CompareTag("tower")) // ���Ϳ� Ÿ�� ����
            {
                delay = 10.0f / attackSpeed;// ���� �ӵ�

                transform.position += new Vector3(1, 0, 0) * moveSpeed / 1000; // ��Ÿ����� ����

                if (timer > delay)// 1�� �� ����
                {
                    timer = 0;

                    DoAttack();
                }
            }
        }
        Move();
    }
    public void Move()
    {
        transform.position += new Vector3(-1, 0, 0) * moveSpeed / 1000;//�� �̵�

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TowerBullet"))// �� Ÿ���� �������� �ǰ�
        {
            GameObject towerbul;
            towerbul = collision.gameObject;

            int hitdamege;
            hitdamege = collision.gameObject.GetComponent<Towerbullet>().damege;

            //Debug.Log("�¾Ҵ� = "+ hitdamege + "  �Ѿ��� ="+ towerbul.name);
            OnDamege(hitdamege);
        }
    }
}
