using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Status
{
    Towerbullet towerbullet;
    Animator anim;

    protected override void Awake()
    {
        base.Awake();
        towerbullet = GameObject.FindGameObjectWithTag("TowerBullet").GetComponent<Towerbullet>();
        anim = GetComponent<Animator>();
    }
    protected override void FixedUpdate()
    {
        anim.SetBool("walk", true);
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

                Stop();
                if (timer > delay)// delay �� ����
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
        this.gameObject.GetComponent<Animator>().enabled = true;
        transform.position += new Vector3(-1, 0, 0) * moveSpeed / 1000;//�� �̵�
       //anim.SetBool("walk",true);
    }
    public void Stop()
    {
        anim.SetBool("walk", false);
        this.gameObject.GetComponent<Animator>().enabled = true;
        transform.position += new Vector3(1, 0, 0) * moveSpeed / 1000;//�� ����
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TowerBullet"))// �� Ÿ���� �������� ����� źȯ�� ��������ŭ �ǰ�
        {
            int hitdamege;
          
            hitdamege = collision.gameObject.GetComponent<Towerbullet>().damege;

            //Debug.Log("�¾Ҵ� = "+ hitdamege + "  �Ѿ��� ="+ towerbul.name);

            OnDamege(hitdamege);
        }
    }
    protected override void OnDamege(int n) // ������Ʈ �ǰ�
    {
        if (shild > 0)
        {
            render.color = new Color32(200, 200, 200, 255);//�ǰ� ����Ʈ
            Invoke("OffDamege", 0.1f);                     //
        }
        else if (shild <= 0)//������Ʈ ���
        {
            col.enabled = false;
            render.enabled = false;

            Destroy(this.gameObject, 2.0f);

            if (this.gameObject.CompareTag("enemy"))
            {
                this.gameObject.GetComponent<Enemy>().enabled = false;
                GameManager.instance.killCount++;
                if (GameManager.instance.killCount == eSpawner.maxWave * eSpawner.maxEnemyCount && center.shild >= 1)
                {
                    GameManager.instance.win = true;
                }
            }
        }
    }
}
