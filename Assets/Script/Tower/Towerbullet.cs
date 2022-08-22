using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerbullet : MonoBehaviour
{
    Status status;
    Rigidbody2D towerBullet_rigid;
    Tower tower;
    int damege;

    private void Awake()
    {
        tower = GameObject.FindGameObjectWithTag("tower").GetComponent<Tower>();//Tower 오브젝트 저장
        damege = tower.damege; //Tower의 damege 저장

        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//총알 이동
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Tower에 부딪히면 총알 파괴
        {
            Destroy(this.gameObject);
        }
    }
}
