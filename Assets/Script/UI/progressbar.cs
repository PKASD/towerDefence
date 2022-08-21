using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar : MonoBehaviour
{
    public Slider shildSlider;
    public Slider energySlider;

    Center center;

    private void Awake()
    {
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();

        shildSlider.maxValue = center.shild; // �ִ� ���差
        energySlider.maxValue = center.maxEnergy; // �ִ� ��������
    }
    private void Update()
    {
        shildSlider.value = center.shild; // ���� ���差
        energySlider.value = center.curEnergy; // ���� ��������
    }
}
