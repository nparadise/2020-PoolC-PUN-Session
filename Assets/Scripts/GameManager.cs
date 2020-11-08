using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;

    [SerializeField]
    public GameObject gameOverMenu;

    [SerializeField]
    private GameObject playerPrefab;

    private CameraFollow cameraFollow;

    public bool isGameOver = false;

    private void Awake() {
        if (Instance != null) {
            Destroy(this);
        } else {
            Instance = this;
        }

        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        gameOverMenu.SetActive(false);
    }

    void Start()
    {
        if (playerPrefab != null) {
            GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
            if (cameraFollow != null) {
                cameraFollow.SetTargetPlayer(player);
            }
        }
    }

    private void Update() {
        if (!isGameOver && PhotonNetwork.CurrentRoom.PlayerCount == 1)
            GameOver();
    }

    public void GameOver() {
        isGameOver = true;
        gameOverMenu.SetActive(true);
    }

    public void OnClickLeaveRoom() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom() {
        PhotonNetwork.LoadLevel(0);
    }
}
