using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Center center;

    public Sprite full_Shild;
    public Sprite high_Shild;
    public Sprite half_Shild;
    public Sprite low_Shild;
    float maxShild;
    Image curimage;

    void Start()
    {
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();
        curimage = GetComponent<Image>();
        maxShild = center.shild;
    }

    // Update is called once per frame
    void Update()
    {
        float ShildPercent = center.shild / maxShild * 100;

        Debug.Log("Shild = "+ShildPercent);
        if (79>=ShildPercent&& ShildPercent >= 50)
        {
            curimage.sprite = high_Shild;
        }
        else if (49 >= ShildPercent && ShildPercent >= 21)
        {
            curimage.sprite = half_Shild;
        }
        else if (ShildPercent <= 20)
        {
            curimage.sprite = low_Shild;
        }
        else {
            curimage.sprite = full_Shild;
        }
    }
}
