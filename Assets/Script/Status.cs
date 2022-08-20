using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int hp;
    public int damege;
    public float attackSpeed;
    public float attackRange;
    public GameObject bulletPref;
    public Transform bulletSpawn;

    protected float timer;
    protected int delay;

    public float moveSpeed = 0.0f;

    public void doAttack() {

        Instantiate(bulletPref, new Vector3(bulletSpawn.position.x,
           bulletSpawn.position.y, bulletSpawn.position.z), Quaternion.identity);//�Ѿ� ������ ����
       
    }
    public void doDamaged(int n) // ������ ����
    {
        // Subtract damage from current health
        hp -= n;

        // Destroy if died
        if (hp <= 0)
            Destroy(gameObject);
    }
}
