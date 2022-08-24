using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GraphicRaycaster : MonoBehaviour
{
    GameObject canvas;
    GraphicRaycaster gr; // UGUI ����ĳ����
    PointerEventData ped;
    EventSystem es;
    void Awake()
    {
        gr = canvas.GetComponent<GraphicRaycaster>();

        es = GetComponent<EventSystem>();
    }
    void Update()
    {
        UGUIRay();
    }

    void UGUIRay()
    {
        ped = new PointerEventData(es);
        ped.position = Input.mousePosition;

        List<RaycastResult> result = new List<RaycastResult>();

        //gr.Raycast();

        GameObject hitUI = result[0].gameObject;

        if (hitUI.CompareTag("TowerIcon"))
        {
            Debug.Log("��ġ");
           /* if (clickObj != null)
            {
                switch (clickObj.name)//Ŭ���� Ÿ�� ������ ����
                {
                    case "Tower_Red":
                        towerpref = Tower_Red;
                        Destroy(clickObj);

                        break;
                    case "Tower_Blue":
                        towerpref = Tower_Blue;
                        Destroy(clickObj);

                        break;
                    case "Tower_Green":
                        towerpref = Tower_Green;
                        Destroy(clickObj);

                        break;
                    default:
                        towerpref = Tower;
                        break;
                }
            }*/
        }

    }
}
