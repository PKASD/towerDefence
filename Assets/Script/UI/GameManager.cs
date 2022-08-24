using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Center center;

    [Header("체력 바, 에너지 바")]
    public TMP_Text maxShildText;
    public TMP_Text curShildText;
    public TMP_Text maxEnergyText;
    public TMP_Text curEnergyText;

    [Header("패널")]
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;

    [HideInInspector]
    public bool win;
    public int killCount;

    int shild;
    int energy;

    private void Awake()
    {
        instance = this;

        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();
        maxShildText.text = "/ " + center.shild; //최대 실드량
        maxEnergyText.text = "/ " + center.maxEnergy; //최대 실드량
    }

    private void Update()
    {
        shild = center.shild;
        energy = center.curEnergy;

        CurShild(shild);
        CurEnergy(energy);
        ActiveWinPanel();
    }

    public void CurShild(int count) // ui 남은 실드 텍스트 출력
    {
        curShildText.text = count.ToString();
        if (shild == 0)
        {
            gameOverPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void CurEnergy(int count) // ui 남은 에너지 텍스트 출력
    {
        curEnergyText.text = count.ToString();

    }
    void ActiveWinPanel()
    {
        if (win)
        {
            gameWinPanel.SetActive(true);
        }
    }

}
