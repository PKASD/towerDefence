using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjDetector : MonoBehaviour
{
    public TowerSpawner towerSpawner;

    Camera cam;
    Ray ray;
    RaycastHit2D hit;

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
                GameObject newUnitPanel = GameObject.Find("Upgrade").transform.GetChild(0).gameObject;
                GameObject UpgradePanel = GameObject.Find("Upgrade").transform.GetChild(1).gameObject;
                GameObject UnitInfoPanel = GameObject.Find("Unitinfo").transform.GetChild(0).gameObject;

                if (hit.transform.gameObject.CompareTag("Container"))
                {
                    towerSpawner.SpawnTower(hit.transform);

                    UnitInfoPanel.SetActive(false);
                    newUnitPanel.SetActive(true);
                    UpgradePanel.SetActive(false);
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

}

