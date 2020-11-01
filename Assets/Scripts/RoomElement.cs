using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class RoomElement : MonoBehaviour
{
    [SerializeField]
    private Text info;

    private string _roomName;
    public string RoomName {
        get {
            return _roomName;
        }
    }

    public void SetRoomElement(RoomInfo ri) {
        _roomName = ri.Name;
        info.text = _roomName + " " + ri.PlayerCount + "/" + ri.MaxPlayers;
    }

    public void OnClickRoomElement() {
        PhotonNetwork.JoinRoom(_roomName);
    }
}
