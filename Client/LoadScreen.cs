using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{

    GameManager Instance;
    AsyncOperation sceneToLoad;


    [SerializeField]
    Image progressBar;

    private void Awake()
    {
        Instance = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(AsyncLoadOperation());
        
    }

    IEnumerator AsyncLoadOperation()
    {

        sceneToLoad = SceneManager.LoadSceneAsync(Instance.targetLevel, LoadSceneMode.Single);
        while (!sceneToLoad.isDone)
        {
            progressBar.fillAmount = sceneToLoad.progress;
            yield return new WaitForEndOfFrame();
        }
        progressBar.fillAmount = sceneToLoad.progress;

        //if (sceneToLoad.isDone )
        sceneToLoad = null;
    }
}
