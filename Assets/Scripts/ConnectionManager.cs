using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "0.0.0";

    void Start()
    {
        Connect();
    }

    void Update()
    {
        
    }

    private void Connect() {
        if (!PhotonNetwork.IsConnected) {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster() {
        Debug.Log("OnConnectedToMaster()");
    }

    public override void OnJoinedLobby() {
        Debug.LogFormat("OnJoinedLobby(), nickname={0}", PhotonNetwork.NickName);
    }

    public override void OnCreatedRoom() {
        Debug.LogFormat("OnCreatedRoom(), room name={0}", PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom() {
        
    }
}
