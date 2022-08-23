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

        tower = GameObject.FindGameObjectWithTag("TowerBullet").GetComponentInParent<Tower>();//Tower 오브젝트 저장

        damege = 10; //Tower의 damege 저장
      //damege = transform.parent.gameObject.GetComponent<Tower>().damege;//Tower의 damege 저장

        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//총알 이동

        
        //Debug.Log(transform.parent.gameObject.GetComponent<Tower>().name+"의 데미지는 = "+damege);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")) // Tower에 부딪히면 총알 파괴
        {
            Destroy(this.gameObject);
        }
    }
}
