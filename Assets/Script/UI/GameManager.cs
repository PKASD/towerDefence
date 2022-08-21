using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    Center center;

    int shild;
    int energy;

    [Header("ü�� ��, ������ ��")]
    public TMP_Text maxShildText;
    public TMP_Text curShildText;
    public TMP_Text maxEnergyText;
    public TMP_Text curEnergyText;


    public GameObject gameOverPanel;

    private void Awake()
    {
        center = GameObject.FindGameObjectWithTag("Center").GetComponent<Center>();
        maxShildText.text = "/ " + center.shild; //�ִ� �ǵ差
        maxEnergyText.text = "/ " + center.maxEnergy; //�ִ� �ǵ差
    }

    private void Update()
    {
        shild = center.shild;
        energy = center.curEnergy;
        CurShild(shild);
        CurEnergy(energy);
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
}
