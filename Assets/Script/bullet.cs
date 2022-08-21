using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Status status;
    Rigidbody2D bullet_rigid;
    int damege;

    private void Awake()
    {
        bullet_rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        bullet_rigid.AddForce(Vector2.left * 1, ForceMode2D.Impulse);//ÃÑ¾Ë ÀÌµ¿

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Center")|| other.CompareTag("tower"))
        {
            Destroy(this.gameObject);
        }
    }
    

}
