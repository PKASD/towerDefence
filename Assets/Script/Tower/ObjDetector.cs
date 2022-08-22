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

    [Header("���� ����")]
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

                if (hit.transform.gameObject.CompareTag("Container"))
                {
                    con = GameObject.Find(hit.transform.gameObject.name).GetComponent<Container>();//Ŭ���� �����̳� ������Ʈ con�� ����
                    render = con.gameObject.GetComponent<SpriteRenderer>();

                    hitPosition = hit.transform.position;

                    UnitInfoPanel.SetActive(false);
                    newUnitPanel.SetActive(true);
                    UpgradePanel.SetActive(false);

/*                    render.color = new Color32(23, 23, 23, 73);//Ŭ�� �� �� ��ȭ

                    if (hit.transform.gameObject.CompareTag("Container"))
                    {
                        render.color = new Color32(255, 255, 255, 70);
                    }*/

                    con.IsBuildTower = false;
                }
                else if (hit.transform.gameObject.CompareTag("tower"))
                {
                    Tower tower = hit.transform.GetComponent<Tower>(); // Ŭ���� Ÿ�� ������Ʈ�� Tower ������Ʈ�� ����

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
        if (!con.IsBuildTower)//Ÿ�� �ߺ� ��ġ ����
        {
            Debug.Log("CreatTower " + con.IsBuildTower);
            if (center.curEnergy > tower.consumEnergy) //�ּ� ������
            {
                towerSpawner.SpawnTower(hitPosition);//���� ������Ʈ ��ġ�� Ÿ�� ��ġ
                center.curEnergy -= tower.consumEnergy;
                con.IsBuildTower = true;
                render.color = new Color32(255, 255, 255, 70);//Ÿ�� �����ϸ� 
            }
        }

    }

}

