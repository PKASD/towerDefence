using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [Header("State")]
    public string unitName;
    public int consumEnergy;
    public int shild;// = H P
    public int damege;
    public float attackSpeed;
    public float attackRange;
    public float moveSpeed;
    protected float timer;
    protected float delay;

    [Header("Bullet")]
    public GameObject bulletPref;//�Ѿ� ������
    public Transform bulletSpawn;//�Ѿ� ���� ��ġ
    public GameObject parentObj; //�Ѿ� ������Ʈ �θ� ������Ʈ

    protected Center center;
    protected SpriteRenderer render;
    protected Rigidbody2D rigid;
    protected Tower tower;
    protected Enemy enemy;
    EnemySpawner eSpawner;

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();
        tower = GameObject.FindGameObjectWithTag("tower").GetComponent<Tower>();
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
        render = this.gameObject.GetComponent<SpriteRenderer>();
        eSpawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }
    protected virtual void FixedUpdate()
    {

        timer += Time.deltaTime;

        delay = 10.0f / attackSpeed;// ���� �ӵ�
    }
    public void DoAttack()//�Ѿ� �߻�
    {
        GameObject bulletObj = Instantiate(bulletPref, new Vector3(bulletSpawn.position.x,
           bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);// �Ѿ� ������ ����

        bulletObj.transform.SetParent(parentObj.transform, true);// �θ� ������Ʈ�� ���� ������Ʈ�� ����

    }
    protected virtual void OnDamege(int n) // ������Ʈ �ǰ�
    {
        shild -= n;
        if (shild > 0)
        {
            render.color = new Color32(200, 200, 200, 255);//�ǰ� ����Ʈ
            Invoke("OffDamege", 0.1f);                     //
        }
        else if (shild <= 0)//������Ʈ ���
        {
            Destroy(this.gameObject);
            if (this.gameObject.CompareTag("enemy"))
            {
                GameManager.instance.killCount++;
                if (GameManager.instance.killCount == eSpawner.maxWave * eSpawner.maxEnemyCount && center.shild >= 1)
                {
                    GameManager.instance.win = true;
                }
            }
        }
    }


    void OffDamege()// �ǰ� ����Ʈ ����
    {
        render.color = new Color(1, 1, 1, 1);
    }
}
