using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField roomNameInputField;

    [SerializeField]
    private GameObject roomElementParent;

    [SerializeField]
    private RoomElement roomElementPrefab;

    private List<RoomElement> shownRoomList = new List<RoomElement>();

    public void TurnOn() {
        gameObject.SetActive(true);
    }

    public void TurnOff() {
        gameObject.SetActive(false);
    }

    public void OnClickCreateRoom() {
        PhotonNetwork.CreateRoom(roomNameInputField.text, new RoomOptions { MaxPlayers = 4 });
    }

    // 로비에 처음 접속했을 때
    // 방 정보 변경이 있을 때
    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        foreach (RoomInfo ri in roomList) {
            int idx = shownRoomList.FindIndex(x => x.RoomName == ri.Name);
            if (ri.RemovedFromList) {
                if (idx != -1) {
                    Destroy(shownRoomList[idx].gameObject);
                    shownRoomList.RemoveAt(idx);
                }
            } else {
                if (idx == -1) {
                    RoomElement room = Instantiate(roomElementPrefab, roomElementParent.transform);
                    room.SetRoomElement(ri);
                    shownRoomList.Add(room);
                } else {
                    shownRoomList[idx].SetRoomElement(ri);
                }
            }
        }
    }
}
