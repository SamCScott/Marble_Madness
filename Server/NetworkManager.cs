using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviour
{

    public static NetworkManager Instance { get; private set; }

    public GameObject playerPrefab;
    public GameObject[] levelToLoad = new GameObject[4];

    public int level;
    public Vector3 center, size;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    void FixedUpdate()
    {
        LoadLevel(level);
    }

    private void Start()
    {
        for (int i = 0; i < levelToLoad.Length; i++)
        {
            levelToLoad[i].SetActive(false);
        }
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        //Server.Start(4, 26950);
    }

    private void OnApplicationQuit()
    {
        ClearPlayers();
        Server.Stop();
    }

    public void ClearPlayers()
    {
        Time.timeScale = 1;
        Player[] player = FindObjectsOfType<Player>();

        for (int i = 0; i < player.Length; i++)
        {
            Destroy(player[i]);
        }
    }

    public void LoadLevel(int _level)
    {

        //it's messy, but i don't really care any more
        switch (_level)
        {
            case 0:
                levelToLoad[0].SetActive(true);
                levelToLoad[1].SetActive(false);
                levelToLoad[2].SetActive(false);
                levelToLoad[3].SetActive(false);
                break;
            case 1:
                levelToLoad[0].SetActive(false);
                levelToLoad[1].SetActive(true);
                levelToLoad[2].SetActive(false);
                levelToLoad[3].SetActive(false);
                break;
            case 2:
                levelToLoad[0].SetActive(false);
                levelToLoad[1].SetActive(false);
                levelToLoad[2].SetActive(true);
                levelToLoad[3].SetActive(false);
                break;
            case 3:
                levelToLoad[0].SetActive(false);
                levelToLoad[1].SetActive(false);
                levelToLoad[2].SetActive(false);
                levelToLoad[3].SetActive(true);
                break;
        }
    }

    public Player InstantiatePlayer()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        return Instantiate(playerPrefab, pos, Quaternion.identity).GetComponent<Player>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        Gizmos.DrawWireCube(center, size);
    }
}
