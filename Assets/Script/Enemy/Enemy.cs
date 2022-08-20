using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Status
{
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        delay = 1;// 공격 딜레이
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.left, attackRange, LayerMask.GetMask("Center"));
        Debug.DrawRay(rigid.position, Vector3.left, new Color(0, 1, 0)); // 레이캐스트 출력

        if (rayHit.collider != null)
        {
            if (rayHit.collider.CompareTag("Center") || rayHit.collider.CompareTag("tower"))
            {
                moveSpeed = 0;

                if (timer > delay)// 1초 후 공격
                {
                    timer = 0;

                    doAttack();
                }
            }
        }
        else {
            Move();
        }
    }
    public void Move() {
        transform.position += new Vector3(-1, 0, 0) * moveSpeed / 1000;//적 이동
    }
}
