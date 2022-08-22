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
            LayerMask.GetMask("Center", "Tower"));//센터, 타워 레이어 감지

        Debug.DrawRay(rigid.position, Vector3.left, new Color(0, 1, 0)); // 레이캐스트 출력

        if (rayHit.collider != null)
        {
            if (rayHit.collider.CompareTag("Center") || rayHit.collider.CompareTag("tower")) // 센터와 타워 공격
            {
                delay = 10.0f / attackSpeed;// 공격 속도

                transform.position += new Vector3(1, 0, 0) * moveSpeed / 1000; // 사거리에서 멈춤

                if (timer > delay)// 1초 후 공격
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
        transform.position += new Vector3(-1, 0, 0) * moveSpeed / 1000;//적 이동

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TowerBullet"))
        {
            GetDamege(tower.damege);
        }
    }
}
