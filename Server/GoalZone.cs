using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using UnityEngine;

public class GoalZone : MonoBehaviour
{


    public bool gameOver = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.ToString() == "Player")
        {
            gameOver = true;
            ServerSend.GameOver(gameOver);
            StartCoroutine(ScaleTime(1.0f, 0.0f, 1.0f));
        }
    }

    IEnumerator ScaleTime(float start, float end, float time)
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = end;
    }

}
