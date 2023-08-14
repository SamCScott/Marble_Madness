using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuFunction : MonoBehaviour
{
    GameManager Instance;

    //private string _msg = "packet successfully sent!";
    public GameObject mainMenu, multiPlayer, options, howToPlay, levelSelect, quit;

    public GameObject gameOverText;

    void Awake()
    {
        Instance = FindObjectOfType<GameManager>();
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.gameStarted == true)
        {
            GameOverUI();
        }
    }

    
    public void LoadLevel(string targetLvl)
    {
        Instance.targetLevel = targetLvl;      

        SceneManager.LoadScene(7, LoadSceneMode.Single);
    }

    #region MAIN MENU FUNCTIONS
    public void MultiplayerMenu()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(false);
            multiPlayer.SetActive(true);
        }
        else if (multiPlayer.activeInHierarchy == true)
        {
            multiPlayer.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
    public void LevelSelectMenu()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(false);
            levelSelect.SetActive(true);
        }
        else if (levelSelect.activeInHierarchy == true)
        {
            levelSelect.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void OptionsMenu()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(false);
            options.SetActive(true);
        }
        else if (options.activeInHierarchy == true)
        {
            options.SetActive(false);
            mainMenu.SetActive(true);
        }
    }


    public void GameInstruction()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(false);
            howToPlay.SetActive(true);
        }
        else if (howToPlay.activeInHierarchy == true)
        {
            howToPlay.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    public void QuitOption()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            mainMenu.SetActive(false);
            quit.SetActive(true);
        }
        if (quit.activeInHierarchy == true)
        {
            quit.SetActive(false);
            mainMenu.SetActive(true);
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    #endregion

    #region IN_GAME_UI

    void GameOverUI()
    {

        if (GameManager.Instance.gameOver == true)
        {
            gameOverText.SetActive(true);
        }
        else
        {
            gameOverText.SetActive(false);
        }

    }
    public void GameStart()
    {
        Instance.gameStarted = true;
    }

    public void GameEnd()
    {
        Instance.gameStarted = false;

    }

    public void EnableMP()
    {
        Instance.multiplayer = true;
    }
    public void DisableMP()
    {
        Instance.multiplayer = false;
    }


    #endregion
}
