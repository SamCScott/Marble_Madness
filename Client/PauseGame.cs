using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    bool paused = false;

    void TogglePause()
    {
        if (paused)
        {
            Time.timeScale = 0;
            paused = false;
        }
        else
        {
            Time.timeScale = 1;
            paused = true;
        }
    }
}

