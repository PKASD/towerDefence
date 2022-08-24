using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("State")]
    public string unitName;
    public int consumEnergy;
    public int shild;
    public int damege;
    public float attackSpeed;
    public float attackRange;
    public float moveSpeed;
    protected float timer;
    protected float delay;

    [Header("Bullet")]
    public GameObject bulletPref;//총알 프리팹
    public Transform bulletSpawn;//총알 생성 위치
    public GameObject parentObj; //총알 오브젝트 부모 오브젝트

    public int leftEnemy;

    protected SpriteRenderer render;
    protected Rigidbody2D rigid;
    protected Tower tower;
    protected Enemy enemy;
    EnemySpawner eSpawner;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        tower = GameObject.FindGameObjectWithTag("tower").GetComponent<Tower>();
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
        render = this.gameObject.GetComponent<SpriteRenderer>();
        eSpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        leftEnemy = eSpawner.maxEnemyCount;
    }
    protected virtual void FixedUpdate()
    {

        timer += Time.deltaTime;

        delay = 10.0f / attackSpeed;// 공격 속도
    }
    public void DoAttack()//총알 발사
    {
        GameObject bulletObj = Instantiate(bulletPref, new Vector3(bulletSpawn.position.x,
           bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);// 총알 프리팹 생성

        bulletObj.transform.SetParent(parentObj.transform, true);// 부모 오브젝트에 하위 오브젝트로 생성

    }
    protected virtual void OnDamege(int n) // 오브젝트 피격
    {
        shild -= n;
        if (shild > 0)
        {
            render.color = new Color32(200, 200, 200, 255);//피격 이펙트
            Invoke("OffDamege", 0.1f);                     //
        }
        else if (shild <= 0)//오브젝트 사망
        {
            Destroy(this.gameObject);
            if (this.gameObject.CompareTag("enemy"))
            {
                /*leftEnemy--;
                Debug.Log(leftEnemy);*/
            }
            leftEnemy--;
            Debug.Log(leftEnemy);
        }
       
    }
    void OffDamege()// 피격 이펙트 종료
    {
        render.color = new Color(1, 1, 1, 1);
    }
    void PlayerWin()
    {
        leftEnemy--;
        if (leftEnemy == 0 && eSpawner.enemyCount == eSpawner.maxEnemyCount)
        {
            GameManager.instance.win = true;
        }
    }
}
