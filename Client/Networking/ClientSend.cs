using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ClientSend : MonoBehaviour
{

    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        //Debug.Log("TCP Data Sent!");
        ClientConnect.Instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        //Debug.Log("UDP Data Sent!");
        _packet.WriteLength();
        ClientConnect.Instance.udp.SendData(_packet);
    }

    #region Packets

    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(ClientConnect.Instance.myId);
            _packet.Write(LoginMenu.Instance.usernameField.text);

            //Debug.Log(LoginMenu.Instance.LoginURL);
            SendTCPData(_packet);
        }
    }

    public static void PlayerMove(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {
            _packet.Write(_inputs.Length);
            foreach( bool _input in _inputs)
            {
                _packet.Write(_input);
            }
            _packet.Write(GameManager.players[ClientConnect.Instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }

   

    //public static void UDPTestReceived()
    //{
    //    using (Packet _packet = new Packet((int)ClientPackets.udpTestReceived))
    //    {
    //        _packet.Write("Received a UDP packet.");

    //        SendUDPData(_packet);
    //    }
    //}
    #endregion

}
