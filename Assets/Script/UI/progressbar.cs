using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    public Slider Slider;

    Center center;

    private void Awake()
    {
        center = GameObject.Find("Center").GetComponent<Center>();

        Slider.maxValue = center.shild; // �ִ� ���差
    }
    private void Update()
    {
        Slider.value = center.shild; // ���� ���差
    }
}
