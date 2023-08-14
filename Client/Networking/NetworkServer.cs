using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkServer : MonoBehaviour {

	public static NetworkServer Server { get; private set; }

	private const string GameType = "Race";
	private const string GameName = "MarbleMadness";
	private const string Comment = "Race Your Friends";

	int serverPort = 25000;
	int maxPlayers = 4;

    void Awake()
    {
		MasterServer.ipAddress = "127.0.0.1";
		MasterServer.port = 23466;
		Network.natFacilitatorIP = "127.0.0.1";
		Network.natFacilitatorPort = 50005;
    }

	void StartServer()
    {
		Network.InitializeServer(maxPlayers, serverPort, true);
		MasterServer.RegisterHost(GameType, GameName, Comment);
		Debug.Log("server port: " + serverPort);
    }

	void OnServerInitialized()
    {
		Debug.Log("Successfully Initiated server");
    }

	void CloseServer()
    {
		Network.Disconnect();
    }
}
