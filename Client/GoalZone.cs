using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZone : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.ToString() == "Player")
        {
            StartCoroutine(ScaleTime(1.0f, 0.0f, 2.0f));
            //GameManager.Instance.gameOver = true;
            //ClientSend.GameOver(GameManager.Instance.gameOver);
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
