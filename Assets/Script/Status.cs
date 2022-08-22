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

    public void DoAttack()//총알 발사
    {
        GameObject bulletObj = Instantiate(bulletPref, new Vector3(bulletSpawn.position.x,
           bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);//총알 프리팹 생성

        bulletObj.transform.SetParent(parentObj.transform, true);//부모 오브젝트에 하위 오브젝트로 생성

    }
    public void GetDamege(int n) // 데미지 입음
    {
        shild -= n;

        if (shild <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
