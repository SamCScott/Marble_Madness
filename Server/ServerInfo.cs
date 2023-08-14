using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServerInfo : MonoBehaviour
{

    public Text portNo, currentPlayers;

    public void StartServer()
    {
        portNo.text = "";
        Server.Start(4, 26950);
        portNo.text = "Server Started and running on port: " + Server.Port.ToString();
    }

    public void StopServer()
    {
        NetworkManager.Instance.ClearPlayers();
        if (Server.serverFirstRun == true)
        {
            Server.Stop();
        }
    }

    public void ResetServerScene()
    {
        NetworkManager.Instance.ClearPlayers();
        if (Server.serverFirstRun == true)
        {
            Server.Stop();
            Destroy(NetworkManager.Instance);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    
    public void Quit()
    {
        Application.Quit();
    }


    
}
