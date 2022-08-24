using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerbullet : MonoBehaviour
{
    Status status;
    Rigidbody2D towerBullet_rigid;

    [HideInInspector]
    public int damege;

    private void Awake()
    {
        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();
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
            Destroy(this.gameObject);
        }
    }

    void Bulletmove()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//�Ѿ� �̵�
    }
}
