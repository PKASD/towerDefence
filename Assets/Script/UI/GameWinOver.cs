using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinOver : MonoBehaviour
{
    public void Restart() { // æ¿ ¿ÁΩ√¿€
        SceneManager.LoadScene(0);
    }
    public void GameEnd() {// æ¿ ¡æ∑·
        Application.Quit();
    }
}
