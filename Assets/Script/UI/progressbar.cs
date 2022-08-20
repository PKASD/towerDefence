using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class progressbar : MonoBehaviour
{
    public Slider pbar;
    public float shild;

    void Start()
    {
        
    }

    void Update()
    {
        pbar.maxValue = shild;
        pbar.value -= shild;

    }
}
