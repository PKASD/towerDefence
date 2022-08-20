using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    progressbar pBar;

    [Header("State")]
    public int shild;
    public int damege;
    public float attackSpeed;
    public float attackRange;
    public float moveSpeed;
    protected float timer;
    protected int delay;

    [Header("Bullet")]
    public GameObject bulletPref;
    public Transform bulletSpawn;

    public void doAttack() {
        
        Instantiate(bulletPref, new Vector3(bulletSpawn.position.x,
           bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);//총알 프리팹 생성
       
    }
    public void GetDamege(int n) // 데미지 입음
    {
        shild -= n;
    }
}
