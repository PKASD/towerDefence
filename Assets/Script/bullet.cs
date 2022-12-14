using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Status status;
    Rigidbody2D bullet_rigid;
    Enemy enemy;
    int damege;
    float bulletSpeed;
    
    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
        damege = enemy.damege;
        bulletSpeed = enemy.bulletSpeed;
        bullet_rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bullet_rigid.AddForce(Vector2.left * bulletSpeed, ForceMode2D.Impulse);//?Ѿ? ?̵?

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Center") || other.CompareTag("tower"))
        {
            Destroy(this.gameObject);
        }
    }
}
