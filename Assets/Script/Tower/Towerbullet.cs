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
        tower = GameObject.FindGameObjectWithTag("tower").GetComponent<Tower>();//Tower ������Ʈ ����
        damege = tower.damege; //Tower�� damege ����

        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//�Ѿ� �̵�
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Tower�� �ε����� �Ѿ� �ı�
        {
            Destroy(this.gameObject);
        }
    }
}
