using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Panel;
    public void Restart() { // �� �����
        SceneManager.LoadScene(0);
    }
    public void GameEnd() {// �� ����
        Application.Quit();
    }
}
