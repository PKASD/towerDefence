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
        enemy = GameObject.FindGameObjectWithTag("enemy").GetComponent<Enemy>();

        maxShildText.text = "/ " + hp;
    }
    private void Update()
    {
        //Debug.Log(enemy.damege);
        CurShild(hp);
   
    }
    public void CurShild(int count) // ui 남은 실드 텍스트 출력
    {
        curShild.text = count.ToString();
        if (hp == 0)
        {
            gameOverPanel.SetActive(true);
            Destroy(gameObject);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
          //  hp -= enemy.damege;

        }
    }
}
