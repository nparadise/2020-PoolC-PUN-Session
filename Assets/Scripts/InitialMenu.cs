using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class InitialMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private InputField nicknameInputField;

    [SerializeField]
    private Button connectLobbyButton;

    void Start() {
        connectLobbyButton.interactable = false;
    }

    public void TurnOn() {
        gameObject.SetActive(true);
    }

    public void TurnOff() {
        gameObject.SetActive(false);
    }

    public void OnClickConnectLobby() {
        PhotonNetwork.NickName = nicknameInputField.text;
        PhotonNetwork.JoinLobby();
    }

    // Master에 연결 되었을 때, 로비 연결 버튼 활성화
    public override void OnConnectedToMaster() {
        connectLobbyButton.interactable = true;
    }
}
