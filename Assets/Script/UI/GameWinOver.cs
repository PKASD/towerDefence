using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinOver : MonoBehaviour
{
    public void Restart() { // �� �����
        SceneManager.LoadScene(0);
    }
    public void GameEnd() {// �� ����
        Application.Quit();
    }
}