using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class InRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform playerElementParent;
    [SerializeField]
    private GameObject playerElement;

    private List<GameObject> playerList = new List<GameObject>();

    public void TurnOn() {
        gameObject.SetActive(true);

        foreach (Player player in PhotonNetwork.PlayerList) {
            GameObject playerObj = Instantiate(playerElement, playerElementParent);
            playerObj.GetComponentInChildren<Text>().text = player.NickName;
            playerList.Add(playerObj);
        }
    }

    public void TurnOff() {
        foreach(GameObject go in playerList) {
            Destroy(go);
        }
        playerList.Clear();

        gameObject.SetActive(false);
    }

    public void OnClickGameStart() {
        PhotonNetwork.CurrentRoom.IsVisible = false;
        PhotonNetwork.LoadLevel(1);
    }

    public void OnClickLeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer) {
        GameObject player = Instantiate(playerElement, playerElementParent);
        player.GetComponentInChildren<Text>().text = newPlayer.NickName;
        playerList.Add(player);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer) {
        int idx = playerList.FindIndex(x => x.GetComponentInChildren<Text>().text == otherPlayer.NickName);
        if (idx != -1) {
            Destroy(playerList[idx]);
            playerList.RemoveAt(idx);
        }
    }
}
