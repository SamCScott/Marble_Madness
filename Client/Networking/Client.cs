using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UnityEngine;

public class Client : MonoBehaviour {

    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        ClientConnect.Instance.myId = _myId;
        ClientSend.WelcomeReceived();

        ClientConnect.Instance.udp.Connect(((IPEndPoint)ClientConnect.Instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _pos = _packet.ReadVector3();
        Quaternion _rot = _packet.ReadQuaternion();

        GameManager.Instance.SpawnPlayer(_id, _username, _pos, _rot);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _pos = _packet.ReadVector3();

        GameManager.players[_id].transform.position = _pos;
    }
    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rot = _packet.ReadQuaternion();

        GameManager.players[_id].transform.rotation = _rot;
    }

    public static void PlayerDisconnected(Packet _packet)
    {
        int _id = _packet.ReadInt();

        Destroy(GameManager.players[_id].gameObject);
        GameManager.players.Remove(_id);

    }

    public static void GameOver(Packet _packet)
    {
        bool _gameOver = _packet.ReadBool();

        GameManager.Instance.gameOver = _gameOver;
    }


    //public static void UDPTest(Packet _packet)
    //{
    //    string _msg = _packet.ReadString();

    //    Debug.Log($"Received packet via UDP. Contains message: {_msg}");
    //    ClientSend.UDPTestReceived();
    //}

}
