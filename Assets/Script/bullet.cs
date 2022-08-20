using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Status status;

    void FixedUpdate()
    {
        transform.position += new Vector3(-1, 0, 0) * 0.3f;//ÃÑ¾Ë ÀÌµ¿
        
    }
}
