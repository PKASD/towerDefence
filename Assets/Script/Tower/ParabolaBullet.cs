using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaBullet : MonoBehaviour
{
    Rigidbody2D rigid;
    public float bulletSpeed;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.position * bulletSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
