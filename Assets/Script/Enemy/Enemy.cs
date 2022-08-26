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
            LayerMask.GetMask("Center", "Tower"));//센터, 타워 레이어 감지

        Debug.DrawRay(rigid.position, Vector3.left * attackRange, new Color(0, 1, 0)); // 레이캐스트 출력

        if (rayHit.collider != null)
        {
            if (rayHit.collider.CompareTag("Center") || rayHit.collider.CompareTag("tower")) // 센터와 타워 공격
            {
                delay = 10.0f / attackSpeed;// 공격 속도

                Stop();
                if (timer > delay)// delay 후 공격
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
        transform.position += new Vector3(-1, 0, 0) * moveSpeed / 1000;//적 이동
       //anim.SetBool("walk",true);
    }
    public void Stop()
    {
        anim.SetBool("walk", false);
        this.gameObject.GetComponent<Animator>().enabled = true;
        transform.position += new Vector3(1, 0, 0) * moveSpeed / 1000;//적 멈춤
       
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TowerBullet"))// 각 타워의 데미지가 저장된 탄환의 데미지만큼 피격
        {
            int hitdamege;
          
            hitdamege = collision.gameObject.GetComponent<Towerbullet>().damege;

            //Debug.Log("맞았다 = "+ hitdamege + "  총알은 ="+ towerbul.name);

            OnDamege(hitdamege);
        }
    }
    protected override void OnDamege(int n) // 오브젝트 피격
    {
        if (shild > 0)
        {
            render.color = new Color32(200, 200, 200, 255);//피격 이펙트
            Invoke("OffDamege", 0.1f);                     //
        }
        else if (shild <= 0)//오브젝트 사망
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
