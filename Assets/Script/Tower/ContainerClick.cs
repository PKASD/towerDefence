using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContainerClick : MonoBehaviour
{
    GameObject newUnit;
    GameObject Upgrade_panel;
    bool isTower=false;

    void Start()
    {
        newUnit = GameObject.Find("New_Unit");
        Upgrade_panel = GameObject.Find("Upgrade_panel");
    }
    void Update()
    {
      
    }

    private void showNewUnit()
    {
        if (isTower)
        {
            if (newUnit.activeSelf == true)
            {
                newUnit.SetActive(false);
                Upgrade_panel.SetActive(true);
               
            }
            else
            {
                Upgrade_panel.SetActive(true);
            }
        }
        else {
            newUnit.SetActive(true);
        }
    }

}
