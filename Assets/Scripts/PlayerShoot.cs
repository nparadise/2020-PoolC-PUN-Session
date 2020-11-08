using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShoot : MonoBehaviourPun
{
    [SerializeField]
    private float bulletSpeed = 200.0f;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletCreatePosition;

    void Update()
    {
        if (!photonView.IsMine) return;
        if (GameManager.Instance.isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot();
        }
    }

    private void Shoot() {
        GameObject b = PhotonNetwork.Instantiate(bullet.name, bulletCreatePosition.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
    }
}
