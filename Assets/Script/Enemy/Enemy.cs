using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Status
{
    Rigidbody2D rigid;
    Tower tower;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        tower = GameObject.FindGameObjectWithTag("tower").GetComponent<Tower>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, attackRange,
            LayerMask.GetMask("Center", "Tower"));//����, Ÿ�� ���̾� ����

        Debug.DrawRay(rigid.position, Vector3.left, new Color(0, 1, 0)); // ����ĳ��Ʈ ���

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
        if (collision.CompareTag("TowerBullet"))
        {
            GetDamege(tower.damege);
        }
    }
}
