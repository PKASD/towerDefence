using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDetector : MonoBehaviour
{
    public TowerSpawner towerSpawner;

    Camera cam;
    Ray ray;
    RaycastHit2D hit;

    void Start()
    {
        cam = Camera.main;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// 레이캐스트를 사용해 마우스 클릭하 오브젝트 정보 반환
        {
            ray = cam.ScreenPointToRay(Input.mousePosition); 

            hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                GameObject newUnitPanel = GameObject.Find("Upgrade").transform.GetChild(0).gameObject;
                GameObject UpgradePanel = GameObject.Find("Upgrade").transform.GetChild(1).gameObject;

                if (hit.transform.gameObject.CompareTag("Container"))
                {
                    //towerSpawner.SpawnTower(hit.transform);
                    newUnitPanel.SetActive(true);

                    UpgradePanel.SetActive(false);
                }
                else if(hit.transform.gameObject.CompareTag("tower"))
                {
                    newUnitPanel.SetActive(false);

                    UpgradePanel.SetActive(true);
                }
            }
        }

    }
}

