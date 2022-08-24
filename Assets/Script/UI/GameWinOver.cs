using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinOver : MonoBehaviour
{
    public void Restart()
    { // 씬 재시작
        SceneManager.LoadScene(0);
    }
    public void GameEnd()
    {// 씬 종료
#if UNITY_EDITOR // 에디터에서 게임 종료
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    
    }

