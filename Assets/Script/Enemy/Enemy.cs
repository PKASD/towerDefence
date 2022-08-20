using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Status
{
    public float move;
    RaycastHit2D hit;
    Rigidbody2D rigid;
    RaycastHit2D RayHit;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        move = moveSpeed;
        //RayHit = Physics2D.Raycast(rigid.position, Vector2.left * attackRange);

        delay = 1;
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(rigid.position, Vector3.left * attackRange, new Color(0, 1, 0)); // ����ĳ��Ʈ ���
      
        if (Physics2D.Raycast(rigid.position, Vector2.left * attackRange))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

        if (RayHit.collider.CompareTag("Center"))
        {
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = move;
        }

        timer += Time.deltaTime;

        if (timer > delay)// 1�� �� ����
        {
            timer = 0;
            doAttack();
        }

        Debug.Log(damege);
    }

    void Update()
    {
        transform.position += new Vector3(-1, 0, 0) * moveSpeed / 1000;
    }
    private void OnCollisionEnter2D(Collision2D collision) // �����Ÿ����� ���ߵ��� ��
    {
        if (collision.gameObject.CompareTag("tower") || collision.gameObject.CompareTag("Center"))
        {

        }
    }
}
