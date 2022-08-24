using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    Center center;

    public Sprite high_HP;
    public Sprite half_HP;
    public Sprite low_HP;
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

        if (79>=ShildPercent&& ShildPercent >= 50)
        {
            curimage.sprite = high_HP;
        }
        else if (49 >= ShildPercent && ShildPercent >= 21)
        {
            curimage.sprite = half_HP;
        }
        else if (ShildPercent >= 20)
        {
            curimage.sprite = low_HP;
        }
        else {

        }
    }
}
