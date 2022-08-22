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
    public GameObject bulletPref;//�Ѿ� ������
    public Transform bulletSpawn;//�Ѿ� ���� ��ġ
    public GameObject parentObj; //�Ѿ� ������Ʈ �θ� ������Ʈ

    public void DoAttack()//�Ѿ� �߻�
    {
        GameObject bulletObj = Instantiate(bulletPref, new Vector3(bulletSpawn.position.x,
           bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);//�Ѿ� ������ ����

        bulletObj.transform.SetParent(parentObj.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����

    }
    public void GetDamege(int n) // ������ ����
    {
        shild -= n;

        if (shild <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
