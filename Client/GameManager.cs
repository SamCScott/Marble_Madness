using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public string targetLevel;
    //public int serverSyncLevel;


    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject localPlayerPrefab, playerPrefab;

    public bool multiplayer = false;
    public bool gameOver = false;
    public bool gameStarted = false;


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

    public void SpawnPlayer(int _id, string _username, Vector3 _pos, Quaternion _rot)
    {
        GameObject _player;

        if(_id == ClientConnect.Instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _pos, _rot);
        }
        else
        {
            _player = Instantiate(playerPrefab, _pos, _rot);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;

        players.Add(_id, _player.GetComponent<PlayerManager>());

    }
}
