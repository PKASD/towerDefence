using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerbullet : MonoBehaviour
{
    Status status;
    Rigidbody2D towerBullet_rigid;
    Tower tower;
    public int damege;
    GameObject bulparent;

    private void Awake()
    {

        tower = GameObject.FindGameObjectWithTag("TowerBullet").GetComponentInParent<Tower>();//Tower ������Ʈ ����

        damege = 10; //Tower�� damege ����
      //damege = transform.parent.gameObject.GetComponent<Tower>().damege;//Tower�� damege ����

        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//�Ѿ� �̵�

        
        //Debug.Log(transform.parent.gameObject.GetComponent<Tower>().name+"�� �������� = "+damege);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Tower�� �ε����� �Ѿ� �ı�
        {
            Destroy(this.gameObject);
        }
    }
}
