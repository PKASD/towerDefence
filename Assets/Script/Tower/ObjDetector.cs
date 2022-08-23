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

    Ray ray;
    RaycastHit2D hit;
    Vector3 hitPosition;

    GameObject clickTower;

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
                    con = GameObject.Find(hit.transform.gameObject.name).GetComponent<Container>();//Ŭ���� �����̳� ������Ʈ con�� ����
                    render = con.gameObject.GetComponent<SpriteRenderer>();

                    UnitInfoPanel.SetActive(false);
                    newUnitPanel.SetActive(true);
                    UpgradePanel.SetActive(false);

                    con.IsBuildTower = false;
                }

                else if (hit.transform.gameObject.CompareTag("tower"))
                {
                    Tower tower = hit.transform.GetComponent<Tower>(); // Ŭ���� Ÿ�� ������Ʈ�� Tower ������Ʈ�� ����

                    clickTower = hit.transform.gameObject;

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
        GameObject towerpref;
        GameObject clickObj = EventSystem.current.currentSelectedGameObject;
        if (!con.IsBuildTower)//Ÿ�� �ߺ� ��ġ ����
        {
            if (center.curEnergy > tower.consumEnergy) //�ּ� ������
            {
                towerpref = Tower;
                towerSpawner.SpawnTower(towerpref, hitPosition);//���� ������Ʈ ��ġ�� Ÿ�� ��ġ
                center.curEnergy -= tower.consumEnergy;
                con.IsBuildTower = true;
                render.color = new Color32(255, 255, 255, 70);//Ÿ�� �����ϸ� 
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
                            towerpref = Tower_Red;
                            Destroy(clickTower);
                            towerSpawner.SpawnTower(towerpref, hitPosition);
                            break;
                        case "Tower_Blue":
                            towerpref = Tower_Blue;
                            Destroy(clickTower);
                            towerSpawner.SpawnTower(towerpref, hitPosition);
                            break;
                        case "Tower_Green":
                            towerpref = Tower_Green;
                            Destroy(clickTower);
                            towerSpawner.SpawnTower(towerpref, hitPosition);
                            break;
                        default:
                            towerpref = Tower;
                            towerSpawner.SpawnTower(towerpref, hitPosition);
                            break;
                    }
                }
            }
        }

    }

}



/*                    render.color = new Color32(23, 23, 23, 73);//Ŭ�� �� �� ��ȭ

                    if (hit.transform.gameObject.CompareTag("Container"))
                    {
                        render.color = new Color32(255, 255, 255, 70);
                    }*/