using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Status
{
    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //doAttack();
    }
}
