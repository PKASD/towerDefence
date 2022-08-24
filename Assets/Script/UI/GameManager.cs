using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Center center;
    EnemySpawner espawner;

    [Header("ü�� ��, ������ ��")]
    public TMP_Text maxShildText;
    public TMP_Text curShildText;
    public TMP_Text maxEnergyText;
    public TMP_Text curEnergyText;

    [Header("���� ���̺�")]
    public TMP_Text maxWaveText;
    public TMP_Text curWaveText;

    [Header("�г�")]
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

        espawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();

        maxShildText.text = "/ " + center.shild; //�ִ� �ǵ差
        maxEnergyText.text = "/ " + center.maxEnergy; //�ִ� �ǵ差
        maxWaveText.text = "/ " + espawner.maxWave; //�ִ� �ǵ差
    }

    private void Update()
    {
        shild = center.shild;
        energy = center.curEnergy;
        int wave = espawner.curWave;

        CurShild(shild);
        CurEnergy(energy);
        CurWave(wave);
        ActiveWinPanel();
    }

    public void CurShild(int count) // ui ���� �ǵ� �ؽ�Ʈ ���
    {
        curShildText.text = count.ToString();
        if (shild == 0)
        {
            gameOverPanel.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    public void CurEnergy(int count) // ui ���� ������ �ؽ�Ʈ ���
    {
        curEnergyText.text = count.ToString();

    }
    public void CurWave(int count) // ui ���� ������ �ؽ�Ʈ ���
    {
        curWaveText.text = count.ToString();

    }
    void ActiveWinPanel()
    {
        if (win)
        {
            gameWinPanel.SetActive(true);
        }
    }

}
