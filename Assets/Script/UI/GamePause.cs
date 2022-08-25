using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject Center;
    bool isPause;

    private void Awake()
    {
        
    }
    void Update()
    {
        if (isPause)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void Pause() {
        if (!isPause)
        {
            this.isPause = true;
        }
        else {
            this.isPause = false;
        }
    }
}
