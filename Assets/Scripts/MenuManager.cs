using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InitialMenu initialMenu;
    [SerializeField]
    private LobbyMenu lobbyMenu;
    [SerializeField]
    private InRoomMenu inRoomMenu;

    private void Start() {
        initialMenu.TurnOn();
        lobbyMenu.TurnOff();
        inRoomMenu.TurnOff();
    }

    public override void OnConnectedToMaster() {
        if (!initialMenu.gameObject.activeInHierarchy && !PhotonNetwork.InLobby) {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby() {
        initialMenu.TurnOff();
        lobbyMenu.TurnOn();
    }

    public override void OnJoinedRoom() {
        lobbyMenu.TurnOff();
        inRoomMenu.TurnOn();
    }

    public override void OnLeftRoom() {
        inRoomMenu.TurnOff();
        lobbyMenu.TurnOn();
    }
}
