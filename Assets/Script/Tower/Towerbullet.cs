using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerbullet : MonoBehaviour
{
    Status status;
    Rigidbody2D towerBullet_rigid;
    List<GameObject> list;
    Enemy enemy;

    [HideInInspector]
    public int damege;
    public bool hit;

    private void Awake()
    {
        list = new List<GameObject>();
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();
        towerBullet_rigid = gameObject.GetComponent<Rigidbody2D>();
        hit = false;
    }

    void FixedUpdate()
    {
        damege = transform.parent.gameObject.GetComponent<Tower>().damege;//Tower의 damege 저장

        //Debug.Log(transform.parent.gameObject.GetComponent<Tower>().name + "의 데미지는 = " + damege);
        Bulletmove();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy")&&hit==false) // Tower에 부딪히면 총알 파괴
        {
            hit = true;
            other.gameObject.GetComponent<Enemy>() .shild -= damege;
            Destroy(this.gameObject);
        }
    }

    void Bulletmove()
    {
        towerBullet_rigid.AddForce(Vector2.right * 1, ForceMode2D.Impulse);//총알 이동
    }
}
