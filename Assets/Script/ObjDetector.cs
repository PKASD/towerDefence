using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ObjDetector : MonoBehaviour
{
    public Tower tower;
    public Center center;
    public TowerSpawner towerSpawner;
    Container con;
    Camera cam;
    SpriteRenderer render;
    SpriteRenderer towerRedner;
    Ray ray;
    RaycastHit2D hit;
    Vector3 hitPosition;

    GameObject clickTower;
    GameObject towerpref;

    [Header("���� ����")]
    public TMP_Text unit_NameText;
    public TMP_Text unit_DurationText;
    public TMP_Text unit_DamegeText;
    public TMP_Text unit_ASpeedText;
    public TMP_Text unit_ARangeText;

    public GameObject Tower;
    public GameObject Tower_Red;
    public GameObject Tower_Blue;
    public GameObject Tower_Green;


    void Awake()
    {
        cam = Camera.main;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))// ����ĳ��Ʈ�� ����� ���콺 Ŭ�� ������Ʈ ���� ��ȯ
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                //public ���� ������ ��
                GameObject newUnitPanel = GameObject.Find("Upgrade").transform.GetChild(0).gameObject;
                GameObject UpgradePanel = GameObject.Find("Upgrade").transform.GetChild(1).gameObject;

                GameObject UnitInfoPanel = GameObject.Find("Unitinfo").transform.GetChild(0).gameObject;

                hitPosition = hit.transform.position;
                if (hit.transform.gameObject.CompareTag("Container"))
                {
                    if (con == null)
                    {
                        con = GameObject.Find(hit.transform.gameObject.name).GetComponent<Container>();
                    }
                    render = con.gameObject.GetComponent<SpriteRenderer>();

                    UnitInfoPanel.SetActive(false);
                    newUnitPanel.SetActive(true);
                    UpgradePanel.SetActive(false);

                    con.IsBuildTower = false;

                }

                else if (hit.transform.gameObject.CompareTag("tower"))
                {
                    tower = hit.transform.GetComponent<Tower>(); // Ŭ���� Ÿ�� ������Ʈ Tower ������Ʈ�� ����
                    clickTower = hit.transform.gameObject;
                    towerRedner = clickTower.GetComponent<SpriteRenderer>();
                    Debug.Log(clickTower.transform.position);
                    UnitInfoPanel.SetActive(true);
                    newUnitPanel.SetActive(false);
                    UpgradePanel.SetActive(true);
                }
            }
        }
        unit_NameText.text = tower.unitName;
        unit_DurationText.text = tower.shild.ToString();
        unit_DamegeText.text = tower.damege.ToString();
        unit_ASpeedText.text = tower.attackSpeed.ToString();
        unit_ARangeText.text = tower.attackRange.ToString();
    }

    public void CreatTower()
    {
        GameObject clickObj = EventSystem.current.currentSelectedGameObject;
        if (!con.IsBuildTower)//Ÿ�� �ߺ� ��ġ ����
        {
            if (center.curEnergy > tower.consumEnergy) //�ּ� ������
            {
                SubCreatTower(Tower);
            }
        }
        else
        {
            if (clickTower != null)
            {
                if (center.curEnergy > tower.consumEnergy) //�ּ� ������
                {
                    switch (clickObj.name)
                    {
                        case "Tower_Red":
                            SubCreatTower(Tower_Red);
                            
                            break;
                        case "Tower_Blue":
                            SubCreatTower(Tower_Blue);
                            break;
                        case "Tower_Green":
                            
                            SubCreatTower(Tower_Green);
                            break;
                        default:
                            Destroy(clickObj);
                            break;
                    }
                }
            }
        }

    }
    void SubCreatTower(GameObject topref)
    {
        Destroy(clickTower);
        Debug.Log(topref);
        if (center.curEnergy > tower.consumEnergy) //�ּ� ������
        {
            towerSpawner.SpawnTower(topref, hitPosition);//���� ������Ʈ ��ġ�� Ÿ�� ��ġ
            center.curEnergy -= tower.consumEnergy;
            con.IsBuildTower = true;
        }
    }

}



/*                    render.color = new Color32(23, 23, 23, 73);//Ŭ�� �� �� ��ȭ

                    if (hit.transform.gameObject.CompareTag("Container"))
                    {
                        render.color = new Color32(255, 255, 255, 70);
                    }*/