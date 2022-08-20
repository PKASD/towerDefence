using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Center : Status
{
    Enemy enemy;
    public GameObject gameOverPanel;

    public TMP_Text maxShildText;
    public TMP_Text curShild;

    public TMP_Text maxEnergyText;
    public TMP_Text curEnergy;

    private void Awake()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

        maxShildText.text = "/ " + shild; //최대 실드량
    }

    private void Update()
    {
        CurShild(shild);
    }

    public void CurShild(int count) // ui 남은 실드 텍스트 출력
    {
        curShild.text = count.ToString();
        if (shild == 0)
        {
            gameOverPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            GetDamege(enemy.damege);
        }
    }
}
