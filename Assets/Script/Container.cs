using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public bool IsBuildTower;
    private void Awake()
    {
        IsBuildTower = false;
    }
}
