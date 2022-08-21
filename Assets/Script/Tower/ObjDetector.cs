using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjDetector : MonoBehaviour
{
    public TowerSpawner towerSpawner;
    Container con;
    Camera cam;

    Ray ray;
    RaycastHit2D hit;
    Vector3 hitPosition;
    
    [Header("유닛 정보")]
    public TMP_Text unit_NameText;
    public TMP_Text unit_DurationText;
    public TMP_Text unit_DamegeText;
    public TMP_Text unit_ASpeedText;
    public TMP_Text unit_ARangeText;

    void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))// 레이캐스트를 사용해 마우스 클릭 오브젝트 정보 반환
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                //public 으로 수정할 것
                GameObject newUnitPanel = GameObject.Find("Upgrade").transform.GetChild(0).gameObject;
                GameObject UpgradePanel = GameObject.Find("Upgrade").transform.GetChild(1).gameObject;
                GameObject UnitInfoPanel = GameObject.Find("Unitinfo").transform.GetChild(0).gameObject;

                if (hit.transform.gameObject.CompareTag("Container"))
                {
                    con = GameObject.Find(hit.transform.gameObject.name).GetComponent<Container>();//클릭한 컨테이너 오브젝트 con에 저장

                    hitPosition = hit.transform.position;
                    
                    UnitInfoPanel.SetActive(false);
                    newUnitPanel.SetActive(true);
                    UpgradePanel.SetActive(false);
                   
                }
                else if (hit.transform.gameObject.CompareTag("tower"))
                {
                    Tower tower = hit.transform.GetComponent<Tower>(); // 클릭한 타워 오브젝트의 Tower 컴포넌트를 저장

                    unit_NameText.text = tower.unitName;
                    unit_DurationText.text = tower.shild.ToString();
                    unit_DamegeText.text = tower.damege.ToString();
                    unit_ASpeedText.text = tower.attackSpeed.ToString();
                    unit_ARangeText.text = tower.attackRange.ToString();

                    UnitInfoPanel.SetActive(true);
                    newUnitPanel.SetActive(false);
                    UpgradePanel.SetActive(true);
                }
            }
        }
    }
    public void CreatTower()
    {
        if (!con.IsBuildTower)//타워 중복 설치 제한
        {
            towerSpawner.SpawnTower(hitPosition);
            con.IsBuildTower = true;
        }
    }
}

