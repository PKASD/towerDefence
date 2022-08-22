using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjDetector : MonoBehaviour
{
    public Tower tower;
    public Center center;
    public TowerSpawner towerSpawner;
    Container con;
    Camera cam;
    SpriteRenderer render;

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
                    render = con.gameObject.GetComponent<SpriteRenderer>();

                    hitPosition = hit.transform.position;

                    UnitInfoPanel.SetActive(false);
                    newUnitPanel.SetActive(true);
                    UpgradePanel.SetActive(false);

/*                    render.color = new Color32(23, 23, 23, 73);//클릭 시 색 변화

                    if (hit.transform.gameObject.CompareTag("Container"))
                    {
                        render.color = new Color32(255, 255, 255, 70);
                    }*/

                    con.IsBuildTower = false;
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
            Debug.Log("CreatTower " + con.IsBuildTower);
            if (center.curEnergy > tower.consumEnergy) //최소 에너지
            {
                towerSpawner.SpawnTower(hitPosition);//선택 오브젝트 위치에 타워 설치
                center.curEnergy -= tower.consumEnergy;
                con.IsBuildTower = true;
                render.color = new Color32(255, 255, 255, 70);//타워 선택하면 
            }
        }

    }

}

