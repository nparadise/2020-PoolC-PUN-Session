using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private float maxCameraMoveSpeed = 2.0f;

    [SerializeField]
    private GameObject player;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer() {
        if (player == null) return;
        Vector3 nextPos = player.transform.position + new Vector3(10f, 10f, 0f);
        transform.position = Vector3.MoveTowards(transform.position, nextPos, maxCameraMoveSpeed * Time.deltaTime);
    }

    public void SetTargetPlayer(GameObject targetPlayer) {
        if (targetPlayer == null) return;
        player = targetPlayer;
    }
}
