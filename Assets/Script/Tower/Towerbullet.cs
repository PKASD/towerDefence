using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerbullet : MonoBehaviour
{
    Status status;
    Rigidbody2D towerBullet_rigid;

    [HideInInspector]
    public int damege;
    public bool hit;

    private void Awake()
    {
        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();
        hit = false;
    }

    void FixedUpdate()
    {
        damege = transform.parent.gameObject.GetComponent<Tower>().damege;//Tower�� damege ����

        //Debug.Log(transform.parent.gameObject.GetComponent<Tower>().name + "�� �������� = " + damege);
        Bulletmove();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Tower�� �ε����� �Ѿ� �ı�
        {
            hit = true;
            if (hit)
            {
                Debug.Log(hit);
            }
            Destroy(this.gameObject);
        }
    }

    void Bulletmove()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//�Ѿ� �̵�
    }
}
