using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{

    //GameManager Instance;
    public static LoginMenu Instance;
    MenuFunction func;

    public InputField usernameField;
    public GameObject startButton;
    //ClientConnect clientConnect;


    public string UserName = "";
    public int target;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    void Start()
    {
        func = FindObjectOfType<MenuFunction>();
    }

    
    public void MenuButton()
    {


        GameObject destroyPlayer = GameObject.FindGameObjectWithTag("Player");
        Destroy(destroyPlayer);

        GameManager.Instance.gameOver = false;
        GameManager.Instance.multiplayer = false;

        
        func.LoadLevel("mMTitle");
    }

    public void ConnectToServer()
    {
        ClientConnect.Instance.ConnectToServer();
    }

    public void DisconnectFromServer()
    {
        ClientConnect.Instance.Disconnect();
    }
}