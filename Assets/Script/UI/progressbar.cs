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

        shildSlider.maxValue = center.shild; // 최대 쉴드량
        energySlider.maxValue = center.maxEnergy; // 최대 에너지량
    }
    private void Update()
    {
        shildSlider.value = center.shild; // 현재 쉴드량
        energySlider.value = center.curEnergy; // 현재 에너지량
    }
}
